using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AviaFlowControl
{
    class MyApplicationContext : ApplicationContext
    {
        MyApplicationContext()
        {
            Task.Run(() => 
            {
                //System.Threading.Thread.Sleep(1000);
                test();
            });
            Program.logIt("MyApplicationContext: --");
        }

        public static void start()
        {
            //Application.Run(new MyApplicationContext());
            //test();
        }

        void test()
        {
            Program.logIt("test: ++");
            //
            System.Threading.Thread.Sleep(1000);
            Program.logIt("test: --");
            ExitThread();
        }
    }

    static class Program
    {
        public static void logIt(String msg)
        {
            System.Diagnostics.Trace.WriteLine(msg);
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if !true
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new Form2());
#else
            //MyApplicationContext.start();
            test();
#endif
        }

        public static Tuple<int,string[]> run_exe(string exeFilename, string param, System.Collections.Specialized.StringDictionary env = null, int timeout = 60 * 1000, string wd="")
        {
            int exitCode = -1;
            List<string> ret = new List<string>();
            Program.logIt(string.Format("[runExe]: ++ exe={0}, param={1}", exeFilename, param));
            try
            {
                if (System.IO.File.Exists(exeFilename))
                {
                    System.Threading.AutoResetEvent ev = new System.Threading.AutoResetEvent(false);
                    Process p = new Process();
                    p.StartInfo.FileName = exeFilename;
                    p.StartInfo.Arguments = param;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    if (!string.IsNullOrEmpty(wd))
                        p.StartInfo.WorkingDirectory = wd;
                    if (env != null && env.Count > 0)
                    {
                        foreach (DictionaryEntry de in env)
                        {
                            p.StartInfo.EnvironmentVariables.Add(de.Key as string, de.Value as string);
                            //p.StartInfo.Environment.Add(de.Key as string, de.Value as string);
                        }
                    }
                    p.OutputDataReceived += (obj, args) =>
                    {
                        if (!string.IsNullOrEmpty(args.Data))
                        {
                            Program.logIt(string.Format("[runExe]: {0}", args.Data));
                            ret.Add(args.Data);
                        }
                        if (args.Data == null)
                            ev.Set();
                    };
                    p.Start();
                    p.BeginOutputReadLine();
                    if (p.WaitForExit(timeout))
                    {
                        ev.WaitOne(timeout);
                        if (!p.HasExited)
                        {
                            exitCode = 1460;
                            p.Kill();
                        }
                        else
                            exitCode = p.ExitCode;
                    }
                    else
                    {
                        if (!p.HasExited)
                        {
                            p.Kill();
                        }
                        exitCode = 1460;
                        Program.logIt(string.Format("[runExe]: Kill by caller due to timeout={0}", timeout));
                    }
                }
            }
            catch (Exception ex)
            {
                Program.logIt(string.Format("[runExe]: {0}", ex.Message));
                Program.logIt(string.Format("[runExe]: {0}", ex.StackTrace));
            }
            Program.logIt(string.Format("[runExe]: -- ret={0}", exitCode));
            return new Tuple<int, string[]>(exitCode, ret.ToArray());
        }
        static void test()
        {
            try
            {
                string s = System.IO.File.ReadAllText("avia_models.json");
                var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                var data = jss.Deserialize<List<Dictionary<string,object>>>(s);
                foreach(var v in data.GroupBy(d => d["Size"]))
                {

                }
            }
            catch (Exception) { }
        }
    }
}
