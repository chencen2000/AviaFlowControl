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
    public partial class CustomControl1 : AeroWizard.WizardControl
    {
        public CustomControl1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Rectangle r = new Rectangle(new Point(0, 0), this.ClientSize);
            //pe.Graphics.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Yellow), r); 
            pe.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Yellow), r);
        }
    }
}
