using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AviaFlowControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //pictureBox3.BringToFront();
        }

        private void WizardPagePlaceDevice_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            //pictureBox1.Image = Image.FromFile(@"C:\Tools\logs\Rotating_earth_(large).gif");
        }

        private void WizardPageInProcess_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            Task t = Task.Run(() => 
            {
                for (int i = 0; i < 100; i++)
                {
                    System.Threading.Thread.Sleep(300);
                    wizardControl1.Invoke(new Action(() =>
                    {
                        progressBar1.Value = i;
                        progressBar1.Update();
                    }));
                }
                wizardControl1.Invoke(new Action(() =>
                {
                    wizardControl1.NextPage();
                }));
            });
        }

        private void WizardPageLogin_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {

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
    }
}
