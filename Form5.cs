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
    public partial class Login : Form
    {

        private Form1 _form1;

        public void SetOtherForms(Form1 form1)
        {
            _form1 = form1;

        }

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = button1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mitarbeiterID = textBox1.Text;
            string passwort = textBox2.Text;

            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Mitarbeiter WHERE MitarbeiterID=@MitarbeiterID AND passwort_hash=@passwort_hash";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MitarbeiterID", mitarbeiterID);
                    cmd.Parameters.AddWithValue("@passwort_hash", passwort);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        _form1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Falsche Daten!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.KeyPress += NurZahlen_KeyPress;
            textBox1.TextChanged += textBox1_TextChanged;
        }

        public void NurZahlen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
