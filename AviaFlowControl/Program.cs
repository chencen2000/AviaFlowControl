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
            //Task.Run(() => 
            //{
            //    //System.Threading.Thread.Sleep(1000);
            //    test();
            //});
            //test();
            this.ThreadExit += MyApplicationContext_ThreadExit;
            startup();
            Program.logIt("MyApplicationContext: --");
        }

        private void MyApplicationContext_ThreadExit(object sender, EventArgs e)
        {
            Program.logIt("MyApplicationContext_ThreadExit: ++");
            //throw new NotImplementedException();
            // kill ui
            utility.IniFile config = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "config.ini"));
            string s = config.GetString("ui", "app", @"evaoi-3.1.0.3\evaoi-3.1.0.3.exe");
            s = System.IO.Path.GetFileNameWithoutExtension(s);
            Process[] p = Process.GetProcessesByName(s);
            if (p.Length > 0)
            {
                try
                {
                    p[0].Kill();
                }
                catch (Exception) { }
            }
            // kill server
            {
                s = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "avia", "FDPhoneRecognition.exe");
                Process ui = new Process();
                ui.StartInfo.FileName = s;
                ui.StartInfo.Arguments = "-kill-tcpserver";
                ui.StartInfo.UseShellExecute = false;
                ui.StartInfo.CreateNoWindow = true;
                ui.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ui.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(s);
                ui.Start();
            }
            Program.logIt("MyApplicationContext_ThreadExit: --");
        }

        public static void start()
        {
            Application.Run(new MyApplicationContext());
            //test();
        }

        void test()
        {
            Program.logIt("test: ++");
            //
            FormLogIn f1 = new FormLogIn();
            f1.Show();
            //f1.FormClosed += (s, e) => 
            //{
            //    Form3 f2 = new Form3();
            //    f2.Show();
            //    f2.FormClosed += (s1, e1) => { ExitThread(); };
            //};
            //System.Threading.Thread.Sleep(1000);
            //f1.Close();
            Program.logIt("test: --");
            //ExitThread();
        }
        void startup()
        {
            Program.logIt("startup: ++");
            SplashScreen ss = new SplashScreen();
            ss.Show();
            ss.FormClosed += (s, o) => 
            {
                FormLogIn f1 = new FormLogIn();
                f1.StartPosition = ss.StartPosition;
                f1.Show();
                f1.FormClosed += (s1, o1) => 
                {
                    if (f1.terminate)
                        ExitThread();
                    else
                    {
                        startup_wizard();
                    }
                };
            };
            Program.logIt("startup: --");
        }

        void startup_wizard()
        {
            Program.logIt("startup_wizard: ++");
#if true
            Form1 f = new Form1();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
            f.FormClosed += (s, o) => { ExitThread(); };
#else
            Form4 f = new Form4();
            f.Show();
            f.FormClosed += (s, o) => { ExitThread(); };
#endif
            Program.logIt("startup_wizard: --");
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
            //Application.Run(new Form1());
            Application.Run(new Form3());
#else
            MyApplicationContext.start();
            //test();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            ////Application.Run(new Form1());
            //Application.Run(new FormLogIn());
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
                util.read_color();
            }
            catch (Exception) { }
        }
    }
}
