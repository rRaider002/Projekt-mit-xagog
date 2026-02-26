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

        private string _tischName;


        public void SetTischName(string name)
        {
            _tischName = name;
        }


        private int GetTischID()
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT TischID FROM Tisch WHERE TischName = @name";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", _tischName);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        return Convert.ToInt32(result);
                }
            }

            return -1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string Nachname = tBNachname.Text;

            int tischID = GetTischID();

            if (tischID == -1)
            {
                MessageBox.Show("Tisch nicht gefunden!");
                return;
            }

            if (!KannReservieren(tischID))
            {
                MessageBox.Show("Maximale Reservierungen erreicht!");
                return;
            }

            SaveNameToDatabase(tbName.Text, tBNachname.Text, tbTelefonnummer.Text);

            UpdateTischStatus();

            _form1.SetButtonColor(Color.Red);
            _form1._lastClickedButton.Text = Nachname;

            tbName.Clear();
            tBNachname.Clear();
            tbTelefonnummer.Clear();
            tbPresonen.Clear();

            this.Hide();
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


        private void UpdateTischStatus()
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                UPDATE Tisch 
                SET istBesetzt = 1,
                Slot = Slot + 1
                WHERE TischName = @name";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", _tischName);
                    cmd.ExecuteNonQuery();
                }
            }
        }
      
        
        private void button2_Click(object sender, EventArgs e)
        {
            _form1.SetButtonColor(Color.Lime);
            string tischName = _form1._lastClickedButton.Name;
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
                        return slot < 4;
                    }

                    return false; 
                }
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
        }


        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "HH:mm";
            dateTimePicker2.ShowUpDown = true;
        }


        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "HH:mm";
            dateTimePicker3.ShowUpDown = true;
        }


    }
}
