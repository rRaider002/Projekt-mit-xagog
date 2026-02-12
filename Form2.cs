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
            LoadData();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tB_TextChanged(object sender, EventArgs e)
        {

        }

        private void bTMitarbeiterErstellen_Click(object sender, EventArgs e)
        {
            string Vorname = tBName.Text;
            string Nachname = tBNachname.Text;
            string Geburtsjahr = tBjahr.Text;
            string Telefonnummer = tBTelefon.Text;
            string Passwort = tBPasswort.Text;
            string Benutzername = Vorname + Nachname + Geburtsjahr;

            SaveMitarbeiterToDatabase(Vorname, Nachname, Geburtsjahr, Telefonnummer, Passwort, Benutzername);

            LoadData();
        }

        private void SaveMitarbeiterToDatabase(string Vorname, string Nachname, string Telefonnummer, string Passwort, string Geburtsjahr, string Benutzername)
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO mitarbeiter(Vorname, Nachname, Telefon, passwort, geburtsjahr, benutzername) VALUES(@Vorname, @Nachname, @Telefon, @passwort, @geburtsjahr, @benutzername)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@Vorname", Vorname);
                    cmd.Parameters.AddWithValue("@Nachname", Nachname);
                    cmd.Parameters.AddWithValue("@Telefon", Telefonnummer);
                    cmd.Parameters.AddWithValue("@passwort", Passwort);
                    cmd.Parameters.AddWithValue("@geburtsjahr", int.Parse(Geburtsjahr));
                    cmd.Parameters.AddWithValue("@benutzername", Benutzername);


                    cmd.ExecuteNonQuery();
                }
            }


        }

        private void LoadData()
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";
            string query = "SELECT * FROM mitarbeiter";
            { 

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(reader);

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = table;
                }
            }

        }

        private void btLoeschen_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int MitarbeiterID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MitarbeiterID"].Value);

                string connStr = "server=localhost;user=root;password=root;database=vesuv";
                string query = "DELETE FROM mitarbeiter WHERE MitarbeiterID = @MitarbeiterID";

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MitarbeiterID", MitarbeiterID);
                    cmd.ExecuteNonQuery();
                }

                LoadData();
            }
        }
    }
}
