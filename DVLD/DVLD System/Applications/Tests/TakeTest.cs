﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DVLD_System.Applications.Tests
{
    public partial class TakeTest : Form
    {
        public TakeTest()
        {
            InitializeComponent();
            ucTopBar1.ChangeTitle("Take Test");
            ucTopBar1.delClose += () => this.Close();
            ucTopBar1.delMinimize += () => this.WindowState = FormWindowState.Minimized;
        }
    }
}
