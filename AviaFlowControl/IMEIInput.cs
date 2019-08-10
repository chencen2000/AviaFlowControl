using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AviaFlowControl
{
    public partial class IMEIInput : UserControl
    {
        public IMEIInput()
        {
            InitializeComponent();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar=='\t')
            {
                //textBox1.Text = textBox1.Text.Trim();
                e.Handled = true;
                textBox1.SelectAll();
                utility.IniFile ini = new utility.IniFile(System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "AVIA", "aviaDevice.ini"));
                ini.WriteValue("device", "imei", textBox1.Text);
            }
        }

        private void IMEIInput_Enter(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        public void clear()
        {
            textBox1.Text = "";
        }
    }
}
