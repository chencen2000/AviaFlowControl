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
                System.Threading.Thread.Sleep(3000);
                this.Invoke(new Action(() =>
                {
                    this.Close();
                }));
            });
        }
    }
}
