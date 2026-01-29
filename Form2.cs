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
    public partial class Form2 : Form
    {

        private Form1 _form1;
        private Form3 _form3;
        private Form4 _form4;

        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

        }

        // Assign the other forms after creation
        public void SetOtherForms(Form1 form1, Form3 form3, Form4 form4)
        {
            _form1 = form1;
            _form3 = form3;
            _form4 = form4;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btMenu1_Click(object sender, EventArgs e)
        {
            this.Hide();
            _form1.Show();

        }

        private void btMenu2_Click(object sender, EventArgs e)
        {


        }

        private void btMenu3_Click(object sender, EventArgs e)
        {

            this.Hide();
            _form3.Show();

        }
    }
}
