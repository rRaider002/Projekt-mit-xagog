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
        private Form5 _form5;

        public string Buttonname { get; set; }
        public string Nachname { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            button4.Click += AnyButton_Click;
            button1.Click += AnyButton_Click;
            button2.Click += AnyButton_Click;
            button5.Click += AnyButton_Click;
            button6.Click += AnyButton_Click;            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void SetOtherForms(Form2 form2, Form3 form3, Form4 form4,Form5 form5)
        {
            _form2 = form2;
            _form3 = form3;
            _form4 = form4;
            _form5 = form5;
        }


        private Button _lastClickedButton;

        public void AnyButton_Click(object sender, EventArgs e)
        {
            _form4.Hide();

            _lastClickedButton = sender as Button;
                          
            _form4.Show();
        }

        public void SetLastClickedButtonText(string text)
        {
            Buttonname = text;

            if (_lastClickedButton != null)
            {
                _lastClickedButton.Text = text;
            }
        }

        public void SetButtonColor(Color color)
        {
            if (_lastClickedButton != null)
            {
                _lastClickedButton.BackColor = color;
            }
        }

        public void ReceiveText(string text)
        {
            Nachname = text;
            _lastClickedButton.Text = text;
        }

        public void ChangeButtonname(string text)
        {
            Buttonname = text;
            _lastClickedButton.Text = text;
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

        public void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }






    }
}
