using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AviaFlowControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox3.BringToFront();
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
            Bitmap b = new Bitmap(AviaFlowControl.Properties.Resources._980478);
            b.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox2.Image = b;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Bitmap b = new Bitmap(AviaFlowControl.Properties.Resources.AVIA_RGB_web);
            pictureBox3.Paint += PictureBox3_Paint;
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
            e.Cancel = true;
            Program.logIt($"IMEI: {textBoxIMEI.Text}");

        }

        private void WizardPageScanImei_Enter(object sender, EventArgs e)
        {
            bool b = false;
            if (textBoxIMEI.CanFocus)
            {
                b = textBoxIMEI.Focus();
                Program.logIt($"focus: return {b}");
            }
            string s = textBoxIMEI.Text;
            if (!string.IsNullOrEmpty(s))
                textBoxIMEI.Text = "";
        }
    }
}
