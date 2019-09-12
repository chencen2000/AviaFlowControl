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
        List<string> models = new List<string>();
        Process theApp = null;
        Rectangle theRect = Rectangle.Empty; // new Rectangle(582,432,10,12);

        public Form1()
        {
            InitializeComponent();
            
        }
        #region form function
        private void Form1_Load(object sender, EventArgs e)
        {
            this.UseWaitCursor = false;
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
#if false
            Task.Run(() => 
            {
                // start oe app
                utility.IniFile config = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "config.ini"));
                string s = config.GetString("ui", "rect", "");
                if (string.IsNullOrEmpty(s))
                {
                    try
                    {
                        string[] ss = s.Split(',');
                        int x = Int32.Parse(ss[0]);
                        int y = Int32.Parse(ss[1]);
                        int w = Int32.Parse(ss[2]);
                        int h = Int32.Parse(ss[3]);
                        Rectangle theRect = new Rectangle(x, y, w, h);
                    }
                    catch (Exception) { }
                }
                s = config.GetString("ui", "app", @"evaoi-3.1.0.3\evaoi-3.1.0.3.exe");
                string ui_exe = System.IO.Path.GetFullPath(s);
                s = System.IO.Path.GetFileNameWithoutExtension(ui_exe);
                Process[] p = Process.GetProcessesByName(s);
                if (p.Length > 0)
                {
                    ShowWindow(p[0].MainWindowHandle, 2);
                    theApp = p[0];
                }
                else
                {
                    if (System.IO.File.Exists(ui_exe))
                    {
                        try
                        {
                            Process ui = new Process();
                            ui.StartInfo.FileName = ui_exe;
                            ui.StartInfo.Arguments = "-ControlMode";
                            ui.StartInfo.UseShellExecute = true;
                            ui.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(ui_exe);
                            theApp = ui;
                            ui.Start();
                            ui.WaitForInputIdle();
                        }
                        catch (Exception) { }
                    }
                }

                // connect to OE server
                if (!OEControl.connect())
                {
                    // fail to connect the OE server
                    this.Invoke(new Action(() => 
                    {
                        MessageBox.Show("Fail to connect UI", "Error");
                    }));
                }
                else
                {
                    // connected
                    // load models
                    s = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(ui_exe), "evaoi.xml");
                    if (System.IO.File.Exists(s))
                    {
                        XmlDocument doc = new XmlDocument();
                        try
                        {
                            doc.Load(s);
                            if (doc.DocumentElement != null)
                            {
                                s = doc.DocumentElement["system"]?["ModelDir"]?.InnerText;
                                if (System.IO.Directory.Exists(s))
                                {
                                    foreach (string m in System.IO.Directory.GetDirectories(s))
                                    {
                                        models.Add(System.IO.Path.GetFileName(m));                                       
                                    }
                                }
                            }
                        }
                        catch (Exception) { }
                    }
                }
            });
#endif
            // connect to OE server
            if (!OEControl.connect())
            {
                // fail to connect the OE server
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show("Fail to connect UI", "Error");
                    this.Close();
                }));
            }

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            OEControl.stop();
            OEControl.disconnect();
            // clean up
            //if (theApp != null)
            //{
            //    try { theApp.Kill(); }
            //    catch (Exception) { }
            //}
            // shutdown FDPhoneRecognition.exe
            //{
            //    Process ui = new Process();
            //    ui.StartInfo.FileName = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "FDPhoneRecognition.exe");
            //    ui.StartInfo.Arguments = "-Kill-TcpServer";
            //    ui.StartInfo.UseShellExecute = false;
            //    ui.StartInfo.CreateNoWindow = true;
            //    ui.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //    ui.Start();
            //}
        }
#endregion

#region login page
        private void WizardPageLogin_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {            
            //Point p = System.Windows.Forms.Cursor.Position;
            //Point p1 = new Point();
            //p1.X = p.X - this.DesktopLocation.X ;
            //p1.Y = p.Y - this.DesktopLocation.Y ;
            //Program.logIt($"position: {p1} on N {theRect}: {theRect.Contains(p1)}");

            if (wizardPageLogin.Tag == null)
            {
                this.Enabled = false;
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
                                        // clear ini device section
                                        utility.IniFile ini = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "aviaDevice.ini"));
                                        ini.DeleteSection("device");
                                        // OE Control start
                                        OEControl.start();
                                    }
                                    catch (Exception) { }
                                }
                            }
                            else
                            {
                                wizardControl1.Invoke(new Action(() =>
                                {
                                    labelLoginStatus.Text = $"Fail to login, error code: {res.Item1}";
                                    labelLoginStatus.Visible = true;
                                }));
                            }
                        }
                    }
                    catch (Exception) { }
                    finally
                    {
                        this.Invoke(new Action(() => 
                        {
                            this.Enabled = true;
                            wizardPageLogin.Tag = null;
                        }));
                        //wizardPageLogin.Tag = null;
                    }
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
            labelLoginStatus.Visible = false;
            //Task.Run(() => 
            //{
            //    Process[] p = Process.GetProcessesByName("evaoi_3.1.0.0");
            //    if (p.Length > 0)
            //    {
            //        ShowWindow(p[0].MainWindowHandle, 2);
            //    }
            //});
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
#if false
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
#endif
        }
        private void WizardPagePlaceDevice_Enter(object sender, EventArgs e)
        {
            this.imeiInput1.clear();
            this.imeiInput1.Focus();
            utility.IniFile ini = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "aviaDevice.ini"));
            //ini.WriteValue("device", "select", comboBoxModels.SelectedItem.ToString());
            ini.DeleteSection("device");

            //this.wizardPagePlaceDevice.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPagePlaceDevice_Commit);
            //this.wizardPagePlaceDevice.Commit += WizardPagePlaceDevice_Commit;
            Task.Run(() => OEControl.load());
        }

        private void WizardPagePlaceDevice_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            this.UseWaitCursor = true;
            Task.Run(() => 
            {
                // wait for check device size
                utility.IniFile avia_device = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "AviaDevice.ini"));
                bool done = false;
                while (!done)
                {
                    System.Threading.Thread.Sleep(1000);
                    string s = avia_device.GetString("device", "device", "");
                    if (string.Compare(s, "ready", true) == 0)
                    {
                        done = true;
                    }
                }
                this.Invoke(new Action(() => wizardControl1.NextPage(this.wizardPageSelect, true)));
            });
            e.Cancel = true;

#if false
            if (!theRect.IsEmpty)
            {
                Point p = System.Windows.Forms.Cursor.Position;
                Point p1 = this.PointToClient(p);
                Program.logIt($"position: {p1} on N {theRect.Contains(p1)}");
                if (theRect.Contains(p1))
                {
                    avia_device.WriteValue("override", "grade", "D");
                }
            }
            string s = avia_device.GetString("device", "device", "");
            if (string.Compare(s, "ready", true) != 0)
            {
                avia_device.WriteValue("device", "device", "ready");
                e.Cancel = true;
            }
#endif
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
                tt.Wait();
                // device connect.
                if (done)
                {
                    this.Invoke(new Action(() => wizardControl1.NextPage()));
                }
            }, tokenSource.Token);
        }

        private void WizardPageResult_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            utility.IniFile avia_device = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "AviaDevice.ini"));
            string s = avia_device.GetString("device", "device", "");
            if (string.Compare(s, "removed", true) != 0)
            {
                avia_device.WriteValue("device", "device", "removed");
                e.Cancel = true;
            }
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            // hold for print
            string avia = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("fdhome"), "avia");
            string tool = System.IO.Path.Combine(avia, "fdprinter", "fdprinter.exe");

            // invoke fdprinter
            if (System.IO.File.Exists(tool))
            {
                System.Collections.Specialized.StringDictionary envs = new System.Collections.Specialized.StringDictionary();
                envs.Add("APSTHOME", System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "fdprinter"));
                //Tuple<int, string[]> res = Program.run_exe(@"c:\windows\system32\notepad.exe", param, envs);
                Tuple<int, string[]> res = Program.run_exe(tool, $"-print -portnumber=1 -inputxml=\"{System.IO.Path.Combine(avia, "label.xml")}\"", envs, wd:System.IO.Path.GetDirectoryName(tool));
                
            }
        }
        #endregion

        #region model selection
        private void WizardPageSelect_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            this.wizardPageSelect.Controls.Add(this.imeiInput1);
            this.checkBox1.Click += delegate { WizardPageSelect_PrepareModels(); };
            //comboBoxModels.Items.Clear();
            //if (comboBoxModels.Items.Count==0)
            //    comboBoxModels.DataSource = models.ToArray();
            //utility.IniFile ini = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "aviaDevice.ini"));
            //ini.WriteValue("device", "select", comboBoxModels.SelectedItem.ToString());
            //ini.DeleteSection("device");
        }
        private void WizardPageSelect_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            utility.IniFile ini = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "aviaDevice.ini"));
            if (!theRect.IsEmpty)
            {
                Point p = System.Windows.Forms.Cursor.Position;
                Point p1 = this.PointToClient(p);
                Program.logIt($"position: {p1} on N {theRect.Contains(p1)}");
                if (theRect.Contains(p1))
                {
                    ini.WriteValue("override", "grade", "D");
                }
            }
            //comboBoxModels.Tag = comboBoxModels.SelectedItem;
            ini.WriteValue("device", "select", comboBoxModels.SelectedItem.ToString());
        }
        private void WizardPageSelect_Enter(object sender, EventArgs e)
        {
            //this.imeiInput1.clear();
            this.imeiInput1.Focus();
            this.UseWaitCursor = false;
            WizardPageSelect_PrepareModels();
        }
        void WizardPageSelect_PrepareModels()
        {
            if (checkBox1.Checked)
            {
                utility.IniFile ini = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "aviaDevice.ini"));
                Dictionary<string, string> models = ini.GetSectionValues("models");
                comboBoxModels.DataSource = models.Keys.ToArray();
            }
            else
            {
                Tuple<bool, SizeF> current_device = util.get_current_device_size();
                Tuple<bool, Dictionary<string, SizeF>> models = util.get_all_device_size();
                if (current_device.Item1 && models.Item1)
                {
                    List<string> ms = new List<string>();
                    foreach (KeyValuePair<string, SizeF> kvp in models.Item2)
                    {
                        SizeF diff = current_device.Item2 - kvp.Value;
                        if (Math.Abs(diff.Height) < 2 && Math.Abs(diff.Width) < 2)
                        {
                            ms.Add(kvp.Key);
                        }
                    }
                    comboBoxModels.DataSource = ms.ToArray();
                }
            }
        }

        #endregion
    }
}
