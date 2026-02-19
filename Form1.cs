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

            Tisch1.Click += AnyButton_Click;
            Tisch2.Click += AnyButton_Click;
            Tisch3.Click += AnyButton_Click;
            Tisch4.Click += AnyButton_Click;
            Tisch5.Click += AnyButton_Click;
            Tisch6.Click += AnyButton_Click;
            Tisch7.Click += AnyButton_Click;
            Tisch8.Click += AnyButton_Click;
            Tisch9.Click += AnyButton_Click;
            Tisch10.Click += AnyButton_Click;
            Tisch11.Click += AnyButton_Click;
            Tisch12.Click += AnyButton_Click;
            Tisch13.Click += AnyButton_Click;
            Tisch14.Click += AnyButton_Click;
            Tisch15.Click += AnyButton_Click;
            Tisch16.Click += AnyButton_Click;
            Tisch17.Click += AnyButton_Click;
            Tisch18.Click += AnyButton_Click;
            Tisch19.Click += AnyButton_Click;
            Tisch20.Click += AnyButton_Click;
            Tisch21.Click += AnyButton_Click;
            Tisch22.Click += AnyButton_Click;
            Tisch23.Click += AnyButton_Click;
            Tisch24.Click += AnyButton_Click;
            Tisch25.Click += AnyButton_Click;
            Tisch26.Click += AnyButton_Click;
            Tisch27.Click += AnyButton_Click;
            Tisch28.Click += AnyButton_Click;
            Tisch29.Click += AnyButton_Click;
            Tisch30.Click += AnyButton_Click;
            Tisch31.Click += AnyButton_Click;
            Tisch32.Click += AnyButton_Click;
            Tisch33.Click += AnyButton_Click;
            Tisch34.Click += AnyButton_Click;
            Tisch35.Click += AnyButton_Click;
            Tisch36.Click += AnyButton_Click;
            Tisch37.Click += AnyButton_Click;
            Tisch38.Click += AnyButton_Click;
            Tisch39.Click += AnyButton_Click;
            Tisch40.Click += AnyButton_Click;
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

            string TischName = _lastClickedButton.Name;

            string connStr = "server=localhost;user=root;password=root;database=vesuv";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "DELETE FROM tischName";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            SaveTischNameToDatabase(TischName);
        }

        public void SaveTischNameToDatabase(string TischName)
        {   
            string connStr = "server=localhost;user=root;password=root;database=vesuv";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO tischName(TischName) values(@TischName)";

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

        private void Tisch2_Click(object sender, EventArgs e)
        {

        }

        private void Tisch3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
