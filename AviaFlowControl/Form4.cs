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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        #region wizard page scan color
        private void WizardPageScanColor_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            this.wizardPageScanColor.Controls.Add(this.imeiInput1);
        }

        private void WizardPageScanColor_Enter(object sender, EventArgs e)
        {
            this.UseWaitCursor = false;
            this.imeiInput1.clear();
            this.imeiInput1.Focus();
            wizardPageScanColor.Tag = true;
        }
        private void WizardPageScanColor_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            bool skip = (bool)wizardPageScanColor.Tag;
            if (skip)
            {
                this.UseWaitCursor = true;
                Task.Run(() =>
                {
                    // get color value.
                    System.Threading.Thread.Sleep(3000);
                    this.Invoke(new Action(() => {
                        wizardPageScanColor.Tag = false;
                        wizardControl1.NextPage();
                    }));
                });
                e.Cancel = true;
            }
            else
            {

            }
        }
        #endregion

        #region wizard page result
        private void WizardPageResult_Enter(object sender, EventArgs e)
        {
            this.UseWaitCursor = false;
        }
        #endregion

        #region wizard page place device in avia
        private void WizardPagePlaceDevice_Enter(object sender, EventArgs e)
        {
            this.UseWaitCursor = false;
            wizardPagePlaceDevice.Tag = true;
            this.imeiInput1.Focus();
        }

        private void WizardPagePlaceDevice_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            this.wizardPagePlaceDevice.Controls.Add(this.imeiInput1);
        }
        private void WizardPagePlaceDevice_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            bool skip = (bool)wizardPagePlaceDevice.Tag;
            if (skip)
            {
                this.UseWaitCursor = true;
                e.Cancel = skip;
                Task.Run(() => 
                {
                    // check please device in avia 
                    System.Threading.Thread.Sleep(3000);
                    this.Invoke(new Action(() => {
                        wizardPagePlaceDevice.Tag = false;
                        wizardControl1.NextPage();
                    }));
                });
            }
            else
            {

            }
        }
        #endregion

        #region wizard page scan
        private void WizardPageScan_Enter(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            this.imeiInput1.Focus();
            Task.Run(()=> 
            {
                int step = 0;
                DateTime _start = DateTime.Now;
                while ((DateTime.Now - _start).TotalSeconds < 10)
                {
                    wizardControl1.Invoke(new Action(() =>
                    {
                        progressBar1.Value = Math.Min(step++, progressBar1.Maximum);
                        progressBar1.Update();
                    }));
                    System.Threading.Thread.Sleep(1000);
                }
                this.Invoke(new Action(() => {
                    //wizardPagePlaceDevice.Tag = false;
                    wizardControl1.NextPage();
                }));
            });
        }
        private void WizardPageScan_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            this.wizardPageScan.Controls.Add(this.imeiInput1);
        }
        #endregion

    }
}
