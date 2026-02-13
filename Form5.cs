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
    public partial class Form5 : Form
    {

        private Form1 _form1;

        public void SetOtherForms(Form1 form1)
        {
            _form1 = form1;

        }

        public Form5()
        {
            InitializeComponent();
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
            string benutzername = textBox1.Text;
            string passwort = textBox2.Text;

            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM mitarbeiter WHERE benutzername=@benutzername AND passwort=@passwort";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@benutzername", benutzername);
                    cmd.Parameters.AddWithValue("@passwort", passwort);

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
    }
}
