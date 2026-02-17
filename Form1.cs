using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Projekt
{
    public partial class Form1 : Form
    {
        private Form2 _form2;
        private Form3 _form3;
        private Form4 _form4;
        private Form5 _form5;
        public Button _lastClickedButton;

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

        public void AnyButton_Click(object sender, EventArgs e)
        {
            _form4.Hide();

            _lastClickedButton = sender as Button;
                          
            _form4.Show();

            string TischName = _lastClickedButton.Text;


            SaveTischNameToDatabase(TischName);
        }

        private void SaveTischNameToDatabase(string TischName)
        {   
            string connStr = "server=localhost;user=root;password=root;database=vesuv";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO tisch(TischName) values(@TischName)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TischName", TischName);
                    cmd.ExecuteNonQuery();
                }
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
