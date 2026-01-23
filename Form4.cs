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
    public partial class Form4 : Form
    {



        private Form2 _form2;
        private Form3 _form3;
        private Form1 _form1;

        public Form4(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        public void SetOtherForms(Form2 form2, Form3 form3, Form1 form1ForNavigation)
        {
            _form2 = form2;
            _form3 = form3;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = tbName.Text;
            string nachname = tBNachname.Text;
            string Telefonnummer = tbTelefonnummer.Text;
            
            int personen = Convert.ToInt32(tbPresonen.Text);

            SaveNameToDatabase(name, nachname, Telefonnummer);

            _form1.SetButtonColor(Color.Red);

        }

        private void SaveNameToDatabase(string name, string nachname, string Telefonnummer)
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO gast(Vorname, Nachname, Telefonnummer) VALUES(@Vorname, @Nachname, @Telefonnummer)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Parameter zuweisen
                    cmd.Parameters.AddWithValue("@Vorname", name);
                    cmd.Parameters.AddWithValue("@Nachname", nachname);
                    cmd.Parameters.AddWithValue("@Telefonnummer", Telefonnummer);

                    // Ausführen
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";
            string query = "SELECT Vorname FROM gast";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            label3.Text = result.ToString(); 
                        }
                        else
                        {
                            label3.Text = "Keine Daten gefunden";
                        }
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
