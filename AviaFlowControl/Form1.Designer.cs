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
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
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
            this.labelGrade = new System.Windows.Forms.Label();
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
            this.wizardControl1.Size = new System.Drawing.Size(709, 431);
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = "AVIA Grading System";
            // 
            // wizardPageLogin
            // 
            this.wizardPageLogin.Controls.Add(this.pictureBox2);
            this.wizardPageLogin.Controls.Add(this.textBoxPassword);
            this.wizardPageLogin.Controls.Add(this.textBoxUsername);
            this.wizardPageLogin.Controls.Add(this.label2);
            this.wizardPageLogin.Controls.Add(this.Username);
            this.wizardPageLogin.Name = "wizardPageLogin";
            this.wizardPageLogin.Size = new System.Drawing.Size(662, 277);
            this.wizardPageLogin.TabIndex = 0;
            this.wizardPageLogin.Text = "Login";
            this.wizardPageLogin.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPageLogin_Commit);
            this.wizardPageLogin.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPageLogin_Initialize);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(135, 277);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(254, 117);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(287, 23);
            this.textBoxPassword.TabIndex = 3;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(254, 79);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(287, 23);
            this.textBoxUsername.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(163, 79);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(60, 15);
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
            this.wizardPageScanImei.Size = new System.Drawing.Size(662, 281);
            this.wizardPageScanImei.TabIndex = 1;
            this.wizardPageScanImei.Text = "Scan IMEI";
            this.wizardPageScanImei.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.WizardPageScanImei_Commit);
            this.wizardPageScanImei.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPageScanImei_Initialize);
            this.wizardPageScanImei.Enter += new System.EventHandler(this.WizardPageScanImei_Enter);
            // 
            // labelIMEIWaiting
            // 
            this.labelIMEIWaiting.AutoSize = true;
            this.labelIMEIWaiting.Location = new System.Drawing.Point(50, 144);
            this.labelIMEIWaiting.Name = "labelIMEIWaiting";
            this.labelIMEIWaiting.Size = new System.Drawing.Size(265, 15);
            this.labelIMEIWaiting.TabIndex = 2;
            this.labelIMEIWaiting.Text = "Enter 0123456789, wait for 3 seconds to continue.";
            // 
            // textBoxIMEI
            // 
            this.textBoxIMEI.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIMEI.Location = new System.Drawing.Point(50, 67);
            this.textBoxIMEI.Name = "textBoxIMEI";
            this.textBoxIMEI.Size = new System.Drawing.Size(462, 39);
            this.textBoxIMEI.TabIndex = 1;
            this.textBoxIMEI.TextChanged += new System.EventHandler(this.TextBoxIMEI_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scan IMEI";
            // 
            // wizardPagePlaceDevice
            // 
            this.wizardPagePlaceDevice.Controls.Add(this.label6);
            this.wizardPagePlaceDevice.Controls.Add(this.pictureBox1);
            this.wizardPagePlaceDevice.Name = "wizardPagePlaceDevice";
            this.wizardPagePlaceDevice.Size = new System.Drawing.Size(662, 281);
            this.wizardPagePlaceDevice.TabIndex = 2;
            this.wizardPagePlaceDevice.Text = "Place the Device on Tray";
            this.wizardPagePlaceDevice.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPagePlaceDevice_Initialize);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(475, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "Place the device and click Next to continue";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(58, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(439, 174);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // wizardPageInProcess
            // 
            this.wizardPageInProcess.AllowBack = false;
            this.wizardPageInProcess.Controls.Add(this.label3);
            this.wizardPageInProcess.Controls.Add(this.progressBar1);
            this.wizardPageInProcess.Name = "wizardPageInProcess";
            this.wizardPageInProcess.Size = new System.Drawing.Size(662, 277);
            this.wizardPageInProcess.TabIndex = 3;
            this.wizardPageInProcess.Text = "In Progress ...";
            this.wizardPageInProcess.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPageInProcess_Initialize);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Scan in progress";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(62, 81);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(445, 21);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // wizardPageResult
            // 
            this.wizardPageResult.AllowBack = false;
            this.wizardPageResult.Controls.Add(this.label5);
            this.wizardPageResult.Controls.Add(this.labelGrade);
            this.wizardPageResult.Name = "wizardPageResult";
            this.wizardPageResult.NextPage = this.wizardPageScanImei;
            this.wizardPageResult.Size = new System.Drawing.Size(662, 277);
            this.wizardPageResult.TabIndex = 4;
            this.wizardPageResult.Text = "Grade Result";
            this.wizardPageResult.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.WizardPageResult_Initialize);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(446, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "Remove the device and Click Next to continue.";
            // 
            // labelGrade
            // 
            this.labelGrade.AutoSize = true;
            this.labelGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 144F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrade.Location = new System.Drawing.Point(154, 0);
            this.labelGrade.Name = "labelGrade";
            this.labelGrade.Size = new System.Drawing.Size(220, 217);
            this.labelGrade.TabIndex = 0;
            this.labelGrade.Text = "A";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 431);
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
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
        private System.Windows.Forms.Label labelGrade;
        private System.Windows.Forms.Label labelIMEIWaiting;
    }
}

