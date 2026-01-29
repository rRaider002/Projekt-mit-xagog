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
    public partial class Form1 : Form
    {

        private Form2 _form2;
        private Form3 _form3;
        private Form4 _form4;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void SetOtherForms(Form2 form2, Form3 form3, Form4 form4)
        {
            _form2 = form2;
            _form3 = form3;
            _form4 = form4;
        }

        public void SetButtonColor(Color color)
        {
            button4.BackColor = color;
        }

        private void Menu1_Click(object sender, EventArgs e)
        {

        }

        private void Menu2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            _form2.Show();
        }

        private void Menu3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            _form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _form4.Show();
        }
    }
}
