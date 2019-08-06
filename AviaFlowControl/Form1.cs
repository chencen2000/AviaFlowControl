using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AviaFlowControl
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        CancellationTokenSource tokenSource = null;
        public Form1()
        {
            InitializeComponent();
            
        }
        #region form function
        private void Form1_Load(object sender, EventArgs e)
        {
            //Bitmap b = new Bitmap(AviaFlowControl.Properties.Resources.AVIA_RGB_web);
            //pictureBox3.Paint += PictureBox3_Paint;
            //wizardControl1.Paint += WizardControl1_Paint;
            //Task.Run(() => 
            //{
            //    while (true)
            //    {
            //        System.Threading.Thread.Sleep(1000);
            //        this.Invoke(new Action(() => { this.Invalidate(); }));
            //    }
            //});
            Task.Run(() => 
            {
                // connect to OE server
                if(!OEControl.connect())
                {
                    // fail to connect the OE server
                    this.Invoke(new Action(() => 
                    {
                        MessageBox.Show("Fail to connect UI", "Error");
                    }));
                }
            });
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            OEControl.stop();
            OEControl.disconnect();
        }
        #endregion

        #region login page
        private void WizardPageLogin_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            if (wizardPageLogin.Tag == null)
            {
                Cursor.Current = Cursors.WaitCursor;
                e.Cancel = true;
                // start log in process
                Task t = Task.Run(() =>
                {
                    try
                    {
                        // log in
                        string dir = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "hydra");
                        System.IO.File.Delete(System.IO.Path.Combine(dir, "HydraLogin.xml"));
                        string exe = System.IO.Path.Combine(dir, "HydraLogin.exe");
                        string param = $"-u={textBoxUsername.Text} -p={textBoxPassword.Text}";
                        if (System.IO.File.Exists(exe))
                        {
                            System.Collections.Specialized.StringDictionary envs = new System.Collections.Specialized.StringDictionary();
                            envs.Add("APSTHOME", System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA"));
                            //Tuple<int, string[]> res = Program.run_exe(@"c:\windows\system32\notepad.exe", param, envs);
                            Tuple<int, string[]> res = Program.run_exe(exe, param, envs);
                            if (res.Item1 == 0)
                            {
                                // login success, run OE
                                //Task tt = Task.Run(() => 
                                //{
                                //    string exe1 = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "iLauncher.exe");
                                //    string param1 = $"-desktop=test -exe=\"{System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "AviaToolset.exe")}\" -args=\"-oecontrol -start\"";
                                //    Process p = new Process();
                                //    p.StartInfo.FileName = exe1;
                                //    p.StartInfo.Arguments = param1;
                                //    p.StartInfo.UseShellExecute = false;
                                //    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                //    p.StartInfo.CreateNoWindow = true;
                                //    p.Start();
                                //});
                                if (System.IO.File.Exists(System.IO.Path.Combine(dir, "HydraLogin.xml")))
                                {
                                    utility.IniFile config = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "config.ini"));
                                    // load xml
                                    try
                                    {
                                        XmlDocument doc = new XmlDocument();
                                        doc.Load(System.IO.Path.Combine(dir, "HydraLogin.xml"));
                                        string uid = doc.DocumentElement?["id"]?.InnerText;
                                        config.WriteValue("config", "uid", uid);
                                        //tt.Wait();
                                        wizardControl1.Invoke(new Action(() =>
                                        {
                                            wizardControl1.NextPage();
                                        }));
                                        // OE Control start
                                        OEControl.start();
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }
                    }
                    catch (Exception) { }
                    finally { wizardPageLogin.Tag = null; }
                });
                wizardPageLogin.Tag = t;
            }
            else
            {
                wizardPageLogin.Tag = null;
            }
        }
        private void WizardPageLogin_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            Task.Run(() => 
            {
                Process[] p = Process.GetProcessesByName("evaoi_3.1.0.0");
                if (p.Length > 0)
                {
                    ShowWindow(p[0].MainWindowHandle, 2);
                }
            });
        }
        private void WizardPageLogin_Enter(object sender, EventArgs e)
        {
            textBoxUsername.Focus();
        }
        #endregion


        #region page load device
        private void WizardPagePlaceDevice_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            this.wizardPagePlaceDevice.Controls.Add(this.imeiInput1);
            this.imeiInput1.clear();
            this.imeiInput1.Focus();
            //pictureBox1.Image = Image.FromFile(@"C:\Tools\logs\Rotating_earth_(large).gif");
            Program.logIt("WizardPagePlaceDevice_Initialize: ");
            tokenSource = new CancellationTokenSource();
            // start task wait for device loaded
            Task t = Task.Factory.StartNew((o) => 
            {
                // oe control
                Task tt = Task.Run(() => OEControl.load());
                CancellationToken ct = (CancellationToken)o;
                utility.IniFile avia_device = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "AviaDevice.ini"));
                bool done = false;
                while (!done)
                {
                    System.Threading.Thread.Sleep(1000);
                    if (ct.IsCancellationRequested)
                    {
                        // camcelled.
                        break;
                    }
                    else
                    {
                        string s = avia_device.GetString("device", "device", "");
                        if (string.Compare(s, "ready", true) == 0)
                        {
                            done = true;
                        }
                    }
                }
                // device connect.
                if (done)
                {
                    this.Invoke(new Action(() => wizardControl1.NextPage()));
                }
                tt.Wait();
            }, tokenSource.Token);
        }
        private void WizardPagePlaceDevice_Enter(object sender, EventArgs e)
        {
            this.imeiInput1.Focus();
        }
        #endregion

        #region page scan in progress
        private void WizardPageInProcess_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            this.wizardPageInProcess.Controls.Add(this.imeiInput1);
            this.imeiInput1.Focus();
            labelStatus.Text = "Scan in progress";
            this.wizardPageInProcess.Text = labelStatus.Text;
            Task t = Task.Run(() =>
            {
                Task tt = Task.Run(() => OEControl.scan());
                bool done = false;
                int step = 0;
                utility.IniFile avia_device = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "AviaDevice.ini"));
                while (!done)
                {
                    System.Threading.Thread.Sleep(300);
                    wizardControl1.Invoke(new Action(() =>
                    {
                        progressBar1.Value = Math.Min(step++, progressBar1.Maximum);
                        progressBar1.Update();
                    }));
                    // check the progress
                    string cmd = avia_device.GetString("query", "command", "");
                    if (string.Compare(cmd, "PMP", true) == 0)
                    {
                        wizardControl1.Invoke(new Action(() =>
                        {
                            labelStatus.Text = "Inspection in progress";
                            this.wizardPageInProcess.Text = labelStatus.Text;
                        }));
                    }
                    // check result
                    string grade = avia_device.GetString("device", "grade", "");                    
                    if (!string.IsNullOrEmpty(grade))
                    {
                        Program.logIt($"Result: {grade}");
                        done = true;
                        step = 100;
                        wizardControl1.Invoke(new Action(() =>
                        {
                            progressBar1.Value = progressBar1.Maximum;
                            progressBar1.Update();
                        }));
                    }
                }
                wizardControl1.Invoke(new Action(() =>
                {
                    wizardControl1.NextPage();
                }));
                tt.Wait();
            });
        }
        private void WizardPageInProcess_Enter(object sender, EventArgs e)
        {
            this.imeiInput1.Focus();
        }
        #endregion

        #region page unload device
        private void WizardPageResult_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            Program.logIt("WizardPageResult_Initialize: ");
            //this.wizardPageResult.Controls.Add(this.imeiInput1);
            // load grade
            {
                utility.IniFile avia_device = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "AviaDevice.ini"));
                string grade = avia_device.GetString("device", "grade", "D");
                labelGrade.Text = grade;
            }
            tokenSource = new CancellationTokenSource();
            // start task wait for device loaded
            Task t = Task.Factory.StartNew((o) =>
            {
                CancellationToken ct = (CancellationToken)o;
                // oe control
                Task tt = Task.Run(() => OEControl.unload());
                //OEControl.unload();
                utility.IniFile avia_device = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "AviaDevice.ini"));
                bool done = false;
                while (!done)
                {
                    System.Threading.Thread.Sleep(1000);
                    if (ct.IsCancellationRequested)
                    {
                        // camcelled.
                        break;
                    }
                    else
                    {
                        string s = avia_device.GetString("device", "device", "");
                        if (string.Compare(s, "removed", true) == 0)
                        {
                            done = true;
                        }
                    }
                }
                // device connect.
                if (done)
                {
                    this.Invoke(new Action(() => wizardControl1.NextPage()));
                }

            }, tokenSource.Token);
        }

        #endregion




    }
}
