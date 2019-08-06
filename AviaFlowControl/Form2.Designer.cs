namespace AviaFlowControl
{
    partial class Form2
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
            this.imeiInput1 = new AviaFlowControl.IMEIInput();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imeiInput1
            // 
            this.imeiInput1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imeiInput1.Location = new System.Drawing.Point(85, 72);
            this.imeiInput1.Name = "imeiInput1";
            this.imeiInput1.Size = new System.Drawing.Size(586, 31);
            this.imeiInput1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(476, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form2
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 415);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imeiInput1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        private IMEIInput imeiInput1;
        private System.Windows.Forms.Button button1;

        #endregion
        //private myButton button1;
    }
}