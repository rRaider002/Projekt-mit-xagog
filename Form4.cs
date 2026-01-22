using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }


        public void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            string Name = tbName.Text;
            int personen = Convert.ToInt32(tbPresonen.Text);

            form1.SetButton3Color(Color.Red);
            form1.Refresh();


        }
    }
}
