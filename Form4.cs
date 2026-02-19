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

        public string Buttonname { get; set; }

        public Form4(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        public void SetOtherForms(Form2 form2, Form3 form3, Form1 form1)
        {
            _form2 = form2;
            _form3 = form3;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = tbName.Text;
            string nachname = tBNachname.Text;
            string Telefon = tbTelefonnummer.Text;
            
            int personen = Convert.ToInt32(tbPresonen.Text);

            SaveNameToDatabase(name, nachname, Telefon);

            _form1.ReceiveText(nachname);
            _form1.SetButtonColor(Color.Red);

            this.Hide();

            tbName.Clear();
            tBNachname.Clear();
            tbTelefonnummer.Clear();
            tbPresonen.Clear();



        }

        private void SaveNameToDatabase(string name, string nachname, string Telefon)
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO gast(Vorname, Nachname, Telefon) VALUES(@Vorname, @Nachname, @Telefon)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {                  
                    cmd.Parameters.AddWithValue("@Vorname", name);
                    cmd.Parameters.AddWithValue("@Nachname", nachname);
                    cmd.Parameters.AddWithValue("@Telefon", Telefon);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void ReceiveButtonname(string text)
        {
            Buttonname = text;
        }

        public string LoadTableName()
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";
            string query = "SELECT TischName FROM tischName LIMIT 1";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["TischName"].ToString();
                    }
                }
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _form1.SetButtonColor(Color.Lime);
            string tischName = LoadTableName();
            _form1._lastClickedButton.Text = tischName;
            this.Hide();
        }

        private bool KannReservieren(int tischID)
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT Slot FROM Tisch WHERE TischID = @tischID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tischID", tischID);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int slot = Convert.ToInt32(result);
                        return slot < 4; // maximal 4 Reservierungen
                    }

                    return false; // Tisch existiert nicht
                }
            }
        }
    }
}
