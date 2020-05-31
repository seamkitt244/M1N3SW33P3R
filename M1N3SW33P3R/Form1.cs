using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M1N3SW33P3R
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
            StartMenu st = new StartMenu();
            this.Controls.Add(st);
        }
    }
}