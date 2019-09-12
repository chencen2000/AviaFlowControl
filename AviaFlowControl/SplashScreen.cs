using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AviaFlowControl
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            Task.Run(() => 
            {
                string s = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("FDHOME"), "avia", "AviaToolset.exe");
                Process ui = new Process();
                ui.StartInfo.FileName = s;
                ui.StartInfo.Arguments = "-prepareEnv";
                ui.StartInfo.UseShellExecute = false;
                ui.StartInfo.CreateNoWindow = true;
                ui.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ui.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(s);
                ui.Start();
                ui.WaitForExit();
                //System.Threading.Thread.Sleep(3000);
                this.Invoke(new Action(() =>
                {
                    this.Close();
                }));
            });
        }
    }
}
