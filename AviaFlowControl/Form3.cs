﻿using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //DeviceSelect _ds = new DeviceSelect();
            ModelPicker mp = new ModelPicker();
            mp.Dock = DockStyle.Fill;
            panel1.Controls.Add(mp);
        }
    }
}
