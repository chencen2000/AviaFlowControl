using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AviaFlowControl
{
    public partial class Form1 : Form
    {
        CancellationTokenSource tokenSource = null;
        public Form1()
        {
            InitializeComponent();
            //pictureBox3.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Bitmap b = new Bitmap(AviaFlowControl.Properties.Resources.AVIA_RGB_web);
            //pictureBox3.Paint += PictureBox3_Paint;
            wizardControl1.Paint += WizardControl1_Paint;
            Task.Run(() => 
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(1000);
                    this.Invoke(new Action(() => { this.Invalidate(); }));
                }
            });
        }

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

        }

        #endregion

        private void WizardControl1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(new Point(0, 0), wizardControl1.ClientSize);
            e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Red), r);
        }

        private void PictureBox3_Paint(object sender, PaintEventArgs e)
        {
            //Bitmap b = new Bitmap(AviaFlowControl.Properties.Resources.AVIA_RGB_web);
            //e.Graphics.DrawImage(b, new Point(0, 0));
            e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Red), new Rectangle(0, 0, 200, 300));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(new Point(0, 0), this.ClientSize);
            e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Red), r);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle r = new Rectangle(new Point(0, 0), this.ClientSize);
            e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Red), r);

        }

        #region page IMEI input
        private void WizardPageScanImei_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {

        }        

        private void WizardPageScanImei_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            if (!labelIMEIWaiting.Visible)
            {
                e.Cancel = true;
                // select all IMEI for user to modify
                {
                    textBoxIMEI.SelectAll();
                    textBoxIMEI.Focus();
                }
                //Program.logIt($"IMEI: {textBoxIMEI.Text}");
                var tokenSource = new CancellationTokenSource();
                wizardPageScanImei.Tag = tokenSource;
                //Task.Run(() =>
                Task.Factory.StartNew((o) =>
                {
                    CancellationToken ct = (CancellationToken)o;
                    int delay = 3;
                    while (delay-- > 0)
                    {
                        this.Invoke(new Action(() =>
                        {
                            labelIMEIWaiting.Visible = true;
                            this.labelIMEIWaiting.Text = $"Enter {textBoxIMEI.Text}, wait for {delay} seconds to continue...";
                        }));
                        System.Threading.Thread.Sleep(1000);
                        if (ct.IsCancellationRequested)
                        {
                            break;
                        }
                    }
                    if (!ct.IsCancellationRequested)
                    {
                        utility.IniFile avia_device = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "AviaDevice.ini"));
                        avia_device.WriteValue("device", "imei", this.textBoxIMEI.Text);
                        wizardControl1.Invoke(new Action(() =>
                        {
                            wizardPageScanImei.Tag = null;
                            wizardControl1.NextPage();
                        }));
                    }
                    else
                    {
                        // cancelled
                        this.Invoke(new Action(() => 
                        {
                            //textBoxIMEI.SelectAll();
                            textBoxIMEI.Focus();
                            labelIMEIWaiting.Visible = false;
                            wizardPageScanImei.Tag = null;
                        }));
                    }
                }, tokenSource.Token);
            }
        }

        void WizardPageScanImei_init()
        {
            if (textBoxIMEI.CanFocus)
            {
                textBoxIMEI.Focus();
            }
            textBoxIMEI.Text = "";
            wizardPageScanImei.Tag = null;
            labelIMEIWaiting.Visible = false;
        }
        private void WizardPageScanImei_Enter(object sender, EventArgs e)
        {
            WizardPageScanImei_init();
        }

        private void TextBoxIMEI_TextChanged(object sender, EventArgs e)
        {
            if (labelIMEIWaiting.Visible)
            {
                // waiting message already displayed, this is re-enter the IMEI
                // we need reset the timer and wait for 3 seconds again.
                if (wizardPageScanImei.Tag != null)
                {
                    CancellationTokenSource cts = (CancellationTokenSource)wizardPageScanImei.Tag;
                    cts.Cancel();                    
                }
            }
            else
            {
                // normal imei entered
            }
        }
        #endregion

        #region page load device
        private void WizardPagePlaceDevice_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            //pictureBox1.Image = Image.FromFile(@"C:\Tools\logs\Rotating_earth_(large).gif");
            Program.logIt("WizardPagePlaceDevice_Initialize: ");
            tokenSource = new CancellationTokenSource();
            // start task wait for device loaded
            Task t = Task.Factory.StartNew((o) => 
            {
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
            }, tokenSource.Token);
        }
        #endregion

        #region page scan in progress
        private void WizardPageInProcess_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            Task t = Task.Run(() =>
            {
                bool done = false;
                int step = 0;
                utility.IniFile avia_device = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "AviaDevice.ini"));
                while (!done)
                {
                    System.Threading.Thread.Sleep(450);
                    wizardControl1.Invoke(new Action(() =>
                    {
                        progressBar1.Value = step++;
                        progressBar1.Update();
                    }));
                    // check result
                    string grade = avia_device.GetString("device", "grade", "");
                    if (!string.IsNullOrEmpty(grade))
                    {
                        done = true;
                        step = 100;
                        wizardControl1.Invoke(new Action(() =>
                        {
                            progressBar1.Value = step++;
                            progressBar1.Update();
                        }));
                    }
                }
                wizardControl1.Invoke(new Action(() =>
                {
                    wizardControl1.NextPage();
                }));
            });
        }
        #endregion

        #region page unload device
        private void WizardPageResult_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            Program.logIt("WizardPageResult_Initialize: ");
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
