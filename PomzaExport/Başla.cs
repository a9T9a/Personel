using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PomzaExport
{
    public partial class Basla : Form
    {
        public Basla()
        {
            InitializeComponent();
        }


        private void Başla_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 fff = new Form2();
            fff.Show();
        }
    }
}
