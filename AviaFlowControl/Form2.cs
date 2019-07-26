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
    //public class myButton : Button
    //{
    //    protected override void OnPaint(PaintEventArgs pevent)
    //    {
    //        base.OnPaint(pevent);
    //        Rectangle r = new Rectangle(new Point(0, 0), this.ClientSize);
    //        pevent.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Red), r);
    //    }
    //}
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle r = new Rectangle(new Point(0, 0), this.ClientSize);
            e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Red), r);

            Bitmap b = new Bitmap(AviaFlowControl.Properties.Resources.AVIA_RGB_web);
            e.Graphics.DrawImage(b, new Point(0, 0));
        }

    }
}
