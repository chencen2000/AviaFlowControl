namespace AviaFlowControl
{
    partial class Form1
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
            this.wizardPageLogin = new AeroWizard.WizardPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.wizardPageScanImei = new AeroWizard.WizardPage();
            this.labelIMEIWaiting = new System.Windows.Forms.Label();
            this.textBoxIMEI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wizardPagePlaceDevice = new AeroWizard.WizardPage();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.wizardPageInProcess = new AeroWizard.WizardPage();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.wizardPageResult = new AeroWizard.WizardPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardPageLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.wizardPageScanImei.SuspendLayout();
            this.wizardPagePlaceDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.wizardPageInProcess.SuspendLayout();
            this.wizardPageResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.wizardControl1.BackColor = System.Drawing.Color.White;
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.Add(this.wizardPageLogin);
            this.wizardControl1.Pages.Add(this.wizardPageScanImei);
            this.wizardControl1.Pages.Add(this.wizardPagePlaceDevice);
            this.wizardControl1.Pages.Add(this.wizardPageInProcess);
            this.wizardControl1.Pages.Add(this.wizardPageResult);
            this.wizardControl1.Size = new System.Drawing.Size(625, 446);
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = "AVIA Grading System";
            // 
            // wizardPageLogin
            // 
            this.wizardPageLogin.Controls.Add(this.pictureBox2);
            this.wizardPageLogin.Controls.Add(this.textBox2);
            this.wizardPageLogin.Controls.Add(this.textBox1);
            this.wizardPageLogin.Controls.Add(this.label2);
            this.wizardPageLogin.Controls.Add(this.Username);
            this.wizardPageLogin.Name = "wizardPageLogin";
            this.wizardPageLogin.Size = new System.Drawing.Size(578, 290);
            this.wizardPageLogin.TabIndex = 0;
            this.wizardPageLogin.Text = "Login";
            this.wizardPageLogin.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPageLogin_Initialize);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(135, 292);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(254, 127);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(287, 23);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(254, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(287, 23);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(163, 86);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(67, 17);
            this.Username.TabIndex = 0;
            this.Username.Text = "Username";
            // 
            // wizardPageScanImei
            // 
            this.wizardPageScanImei.AllowBack = false;
            this.wizardPageScanImei.Controls.Add(this.labelIMEIWaiting);
            this.wizardPageScanImei.Controls.Add(this.textBoxIMEI);
            this.wizardPageScanImei.Controls.Add(this.label1);
            this.wizardPageScanImei.Name = "wizardPageScanImei";
            this.wizardPageScanImei.Size = new System.Drawing.Size(578, 290);
            this.wizardPageScanImei.TabIndex = 1;
            this.wizardPageScanImei.Text = "Scan IMEI";
            this.wizardPageScanImei.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPageScanImei_Commit);
            this.wizardPageScanImei.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPageScanImei_Initialize);
            this.wizardPageScanImei.Enter += new System.EventHandler(this.WizardPageScanImei_Enter);
            // 
            // labelIMEIWaiting
            // 
            this.labelIMEIWaiting.AutoSize = true;
            this.labelIMEIWaiting.Location = new System.Drawing.Point(50, 156);
            this.labelIMEIWaiting.Name = "labelIMEIWaiting";
            this.labelIMEIWaiting.Size = new System.Drawing.Size(298, 17);
            this.labelIMEIWaiting.TabIndex = 2;
            this.labelIMEIWaiting.Text = "Enter 0123456789, wait for 3 seconds to continue.";
            // 
            // textBoxIMEI
            // 
            this.textBoxIMEI.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIMEI.Location = new System.Drawing.Point(50, 73);
            this.textBoxIMEI.Name = "textBoxIMEI";
            this.textBoxIMEI.Size = new System.Drawing.Size(462, 39);
            this.textBoxIMEI.TabIndex = 1;
            this.textBoxIMEI.TextChanged += new System.EventHandler(this.TextBoxIMEI_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scan IMEI";
            // 
            // wizardPagePlaceDevice
            // 
            this.wizardPagePlaceDevice.Controls.Add(this.label6);
            this.wizardPagePlaceDevice.Controls.Add(this.pictureBox1);
            this.wizardPagePlaceDevice.Name = "wizardPagePlaceDevice";
            this.wizardPagePlaceDevice.Size = new System.Drawing.Size(578, 292);
            this.wizardPagePlaceDevice.TabIndex = 2;
            this.wizardPagePlaceDevice.Text = "Place the Device on Tray";
            this.wizardPagePlaceDevice.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPagePlaceDevice_Initialize);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(475, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "Place the device and click Next to continue";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(58, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(439, 188);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // wizardPageInProcess
            // 
            this.wizardPageInProcess.AllowBack = false;
            this.wizardPageInProcess.Controls.Add(this.label3);
            this.wizardPageInProcess.Controls.Add(this.progressBar1);
            this.wizardPageInProcess.Name = "wizardPageInProcess";
            this.wizardPageInProcess.Size = new System.Drawing.Size(578, 292);
            this.wizardPageInProcess.TabIndex = 3;
            this.wizardPageInProcess.Text = "In Progress ...";
            this.wizardPageInProcess.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPageInProcess_Initialize);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Scan in progress";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(62, 88);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(445, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // wizardPageResult
            // 
            this.wizardPageResult.AllowBack = false;
            this.wizardPageResult.Controls.Add(this.label5);
            this.wizardPageResult.Controls.Add(this.label4);
            this.wizardPageResult.Name = "wizardPageResult";
            this.wizardPageResult.NextPage = this.wizardPageScanImei;
            this.wizardPageResult.Size = new System.Drawing.Size(578, 290);
            this.wizardPageResult.TabIndex = 4;
            this.wizardPageResult.Text = "Grade Result";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(445, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "Remove the device and Click Next to continue.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 144F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(154, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 249);
            this.label4.TabIndex = 0;
            this.label4.Text = "A";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 446);
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardPageLogin.ResumeLayout(false);
            this.wizardPageLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.wizardPageScanImei.ResumeLayout(false);
            this.wizardPageScanImei.PerformLayout();
            this.wizardPagePlaceDevice.ResumeLayout(false);
            this.wizardPagePlaceDevice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.wizardPageInProcess.ResumeLayout(false);
            this.wizardPageInProcess.PerformLayout();
            this.wizardPageResult.ResumeLayout(false);
            this.wizardPageResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AeroWizard.WizardControl wizardControl1;
        private AeroWizard.WizardPage wizardPageLogin;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Username;
        private AeroWizard.WizardPage wizardPageScanImei;
        private System.Windows.Forms.TextBox textBoxIMEI;
        private System.Windows.Forms.Label label1;
        private AeroWizard.WizardPage wizardPagePlaceDevice;
        private AeroWizard.WizardPage wizardPageInProcess;
        private AeroWizard.WizardPage wizardPageResult;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelIMEIWaiting;
    }
}

