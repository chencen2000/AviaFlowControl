namespace AviaFlowControl
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wizardControl1 = new AeroWizard.WizardControl();
            this.wizardPageScanColor = new AeroWizard.WizardPage();
            this.label1 = new System.Windows.Forms.Label();
            this.imeiInput1 = new AviaFlowControl.IMEIInput();
            this.wizardPagePlaceDevice = new AeroWizard.WizardPage();
            this.wizardPagePreScan = new AeroWizard.WizardPage();
            this.wizardPageScan = new AeroWizard.WizardPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.wizardPageResult = new AeroWizard.WizardPage();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardPageScanColor.SuspendLayout();
            this.wizardPageScan.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.BackColor = System.Drawing.Color.White;
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.Add(this.wizardPageScanColor);
            this.wizardControl1.Pages.Add(this.wizardPagePlaceDevice);
            this.wizardControl1.Pages.Add(this.wizardPagePreScan);
            this.wizardControl1.Pages.Add(this.wizardPageScan);
            this.wizardControl1.Pages.Add(this.wizardPageResult);
            this.wizardControl1.Size = new System.Drawing.Size(860, 562);
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = "Avia";
            // 
            // wizardPageScanColor
            // 
            this.wizardPageScanColor.AllowBack = false;
            this.wizardPageScanColor.Controls.Add(this.label1);
            this.wizardPageScanColor.Controls.Add(this.imeiInput1);
            this.wizardPageScanColor.Name = "wizardPageScanColor";
            this.wizardPageScanColor.Size = new System.Drawing.Size(813, 406);
            this.wizardPageScanColor.TabIndex = 0;
            this.wizardPageScanColor.Text = "Scan Color";
            this.wizardPageScanColor.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPageScanColor_Commit);
            this.wizardPageScanColor.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPageScanColor_Initialize);
            this.wizardPageScanColor.Enter += new System.EventHandler(this.WizardPageScanColor_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please place the device on the color sensor and click Next.";
            // 
            // imeiInput1
            // 
            this.imeiInput1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imeiInput1.Dock = System.Windows.Forms.DockStyle.Top;
            this.imeiInput1.Location = new System.Drawing.Point(0, 0);
            this.imeiInput1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imeiInput1.Name = "imeiInput1";
            this.imeiInput1.Size = new System.Drawing.Size(813, 33);
            this.imeiInput1.TabIndex = 0;
            // 
            // wizardPagePlaceDevice
            // 
            this.wizardPagePlaceDevice.AllowBack = false;
            this.wizardPagePlaceDevice.Name = "wizardPagePlaceDevice";
            this.wizardPagePlaceDevice.Size = new System.Drawing.Size(813, 406);
            this.wizardPagePlaceDevice.TabIndex = 2;
            this.wizardPagePlaceDevice.Text = "Place Device in AVIA";
            this.wizardPagePlaceDevice.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPagePlaceDevice_Commit);
            this.wizardPagePlaceDevice.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPagePlaceDevice_Initialize);
            this.wizardPagePlaceDevice.Enter += new System.EventHandler(this.WizardPagePlaceDevice_Enter);
            // 
            // wizardPagePreScan
            // 
            this.wizardPagePreScan.Name = "wizardPagePreScan";
            this.wizardPagePreScan.Size = new System.Drawing.Size(813, 406);
            this.wizardPagePreScan.TabIndex = 4;
            this.wizardPagePreScan.Text = "Confirm";
            this.wizardPagePreScan.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPagePreScan_Initialize);
            this.wizardPagePreScan.Enter += new System.EventHandler(this.WizardPagePreScan_Enter);
            // 
            // wizardPageScan
            // 
            this.wizardPageScan.AllowBack = false;
            this.wizardPageScan.Controls.Add(this.progressBar1);
            this.wizardPageScan.Controls.Add(this.labelStatus);
            this.wizardPageScan.Name = "wizardPageScan";
            this.wizardPageScan.NextPage = this.wizardPageResult;
            this.wizardPageScan.ShowNext = false;
            this.wizardPageScan.Size = new System.Drawing.Size(813, 406);
            this.wizardPageScan.TabIndex = 3;
            this.wizardPageScan.Text = "Scan Device";
            this.wizardPageScan.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPageScan_Initialize);
            this.wizardPageScan.Enter += new System.EventHandler(this.WizardPageScan_Enter);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(91, 260);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(652, 30);
            this.progressBar1.TabIndex = 1;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(327, 222);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(124, 17);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Scan in progressing";
            // 
            // wizardPageResult
            // 
            this.wizardPageResult.AllowBack = false;
            this.wizardPageResult.Name = "wizardPageResult";
            this.wizardPageResult.NextPage = this.wizardPageScanColor;
            this.wizardPageResult.Size = new System.Drawing.Size(813, 406);
            this.wizardPageResult.TabIndex = 1;
            this.wizardPageResult.Text = "Grading Result";
            this.wizardPageResult.Enter += new System.EventHandler(this.WizardPageResult_Enter);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 562);
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardPageScanColor.ResumeLayout(false);
            this.wizardPageScanColor.PerformLayout();
            this.wizardPageScan.ResumeLayout(false);
            this.wizardPageScan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AeroWizard.WizardControl wizardControl1;
        private AeroWizard.WizardPage wizardPageScanColor;
        private IMEIInput imeiInput1;
        private System.Windows.Forms.Label label1;
        private AeroWizard.WizardPage wizardPageResult;
        private AeroWizard.WizardPage wizardPagePlaceDevice;
        private AeroWizard.WizardPage wizardPageScan;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private AeroWizard.WizardPage wizardPagePreScan;
    }
}