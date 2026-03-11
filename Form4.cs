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
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            _form1 = form1;

            tbName.KeyPress += NurBuchstaben_KeyPress;
            tbName.TextChanged += tbName_TextChanged;

            tBNachname.KeyPress += NurBuchstaben_KeyPress;
            tBNachname.TextChanged += tBNachname_TextChanged;

            tbTelefonnummer.KeyPress += NurZahlen_KeyPress;
            tbTelefonnummer.TextChanged += tbTelefonnummer_TextChanged;

            tbPresonen.KeyPress += NurZahlen_KeyPress;
            tbPresonen.TextChanged += tbPresonen_TextChanged;

            tbTelefonnummer.MaxLength = 20;
            tbPresonen.MaxLength = 2;

        }


        public void NurBuchstaben_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        public void NurZahlen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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
            LadeGastdaten();
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

        private int GetSelectedSlot()
        {
            return _form1.GetSelectedSlot();
        }

        private void LadeGastdaten()
        {
            if (string.IsNullOrEmpty(_tischName))
                return;

            int selectedSlot = GetSelectedSlot();
            if (selectedSlot == -1)
                return;

            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                    SELECT g.Vorname, g.Nachname, g.Telefon, r.Personenanzahl
                    FROM Reservierung r
                    INNER JOIN Gast g ON r.GastID = g.GastID
                    INNER JOIN Tisch t ON r.TischID = t.TischID
                    WHERE t.TischName = @tischName
                      AND r.Slot = @slot
                      AND r.IsDeleted = 0
                    ORDER BY r.ReservierungID DESC
                    LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tischName", _tischName);
                    cmd.Parameters.AddWithValue("@slot", selectedSlot);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tbName.Text = reader["Vorname"].ToString();
                            tBNachname.Text = reader["Nachname"].ToString();
                            tbTelefonnummer.Text = reader["Telefon"].ToString();
                            tbPresonen.Text = reader["Personenanzahl"].ToString();
                        }
                        else
                        {
                            tbName.Clear();
                            tBNachname.Clear();
                            tbTelefonnummer.Clear();
                            tbPresonen.Clear();
                        }
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LadeGastdaten();
        }

        private int GetTischPlaetze(int tischID)
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT Plaetze FROM Tisch WHERE TischID = @tischID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tischID", tischID);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        return Convert.ToInt32(result);
                }
            }

            return -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nachname = tBNachname.Text;

            int tischID = GetTischID();

            if (tischID == -1)
            {
                MessageBox.Show("Tisch nicht gefunden!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Bitte geben Sie einen Vornamen ein");
                return;
            }

            if (string.IsNullOrWhiteSpace(tBNachname.Text))
            {
                MessageBox.Show("Bitte geben Sie einen Nachnamen ein");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbTelefonnummer.Text))
            {
                MessageBox.Show("Bitte geben Sie Ihre Telefonnummer an");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbPresonen.Text))
            {
                MessageBox.Show("Bitte geben Sie an, wie viele Personen kommen");
                return;
            }

            int personenanzahl;
            if (!int.TryParse(tbPresonen.Text, out personenanzahl))
            {
                MessageBox.Show("Bitte geben Sie eine gültige Personenzahl ein");
                return;
            }

            int maxPlaetze = GetTischPlaetze(tischID);
            if (maxPlaetze == -1)
            {
                MessageBox.Show("Tischkapazität konnte nicht ermittelt werden.");
                return;
            }

            if (personenanzahl > maxPlaetze)
            {
                MessageBox.Show($"Dieser Tisch hat nur {maxPlaetze} Plätze.");
                return;
            }

            int selectedSlot = GetSelectedSlot();

            if (selectedSlot == -1)
            {
                MessageBox.Show("Bitte wählen Sie einen Slot aus.");
                return;
            }

            if (IstTischReserviert(tischID, selectedSlot))
            {
                MessageBox.Show("Dieser Slot ist schon reserviert");
                return;
            }

            int gastID = SaveGastToDatabase(tbName.Text, tBNachname.Text, tbTelefonnummer.Text);
            SaveReservierungToDatabase(dateTimePicker1.Value.Date, selectedSlot, personenanzahl, gastID, tischID);

            UpdateTischStatus();
            _form1.LadeTischStatus();

            tbName.Clear();
            tBNachname.Clear();
            tbTelefonnummer.Clear();
            tbPresonen.Clear();

            this.Hide();
        }



        private bool IstTischReserviert(int tischID, int slot)
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                SELECT COUNT(*)
                FROM Reservierung
                WHERE TischID = @tischID
                AND Slot = @slot
                AND IsDeleted = 0
                AND TIMESTAMP(Datum, Uhrzeit) <= NOW()
                AND TIMESTAMP(Datum, Uhrzeit) + INTERVAL 2 HOUR > NOW()";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tischID", tischID);
                    cmd.Parameters.AddWithValue("@slot", slot);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }


        private int SaveGastToDatabase(string name, string nachname, string telefon)
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO Gast (Vorname, Nachname, Telefon) 
                         VALUES (@Vorname, @Nachname, @Telefon);
                         SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Vorname", name);
                    cmd.Parameters.AddWithValue("@Nachname", nachname);
                    cmd.Parameters.AddWithValue("@Telefon", telefon);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void SaveReservierungToDatabase(DateTime datum, int slot, int personenanzahl, int gastID, int tischID)
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO Reservierung 
                    (Datum, Uhrzeit, Slot, Personenanzahl, GastID, TischID, IsDeleted)
                    VALUES
                    (@Datum, @Uhrzeit, @Slot, @Personenanzahl, @GastID, @TischID, 0)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Datum", datum);
                    cmd.Parameters.AddWithValue("@Uhrzeit", dateTimePicker2.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@Slot", slot);
                    cmd.Parameters.AddWithValue("@Personenanzahl", personenanzahl);
                    cmd.Parameters.AddWithValue("@GastID", gastID);
                    cmd.Parameters.AddWithValue("@TischID", tischID);

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
                Slot = CASE
                      WHEN Slot < 4 THEN Slot + 1
                      ELSE Slot
                   END
                WHERE TischName = @name";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", _tischName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ReservierungFreigeben(int tischID)
        {
            int selectedSlot = GetSelectedSlot();
            if (selectedSlot == -1)
                return;

            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"DELETE FROM Reservierung
                         WHERE TischID = @tischID
                         AND Datum = @datum
                         AND Slot = @slot";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tischID", tischID);
                    cmd.Parameters.AddWithValue("@datum", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@slot", selectedSlot);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int tischID = GetTischID();

            if (tischID == -1)
            {
                MessageBox.Show("Tisch nicht gefunden!");
                return;
            }

            ReservierungFreigeben(tischID);
            TischFreigeben();

            tbName.Clear();
            tBNachname.Clear();
            tbTelefonnummer.Clear();
            tbPresonen.Clear();

            _form1.LadeTischStatus();
            this.Hide();
        }

        private void TischFreigeben()
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"UPDATE Tisch
                         SET istBesetzt = 0
                         WHERE TischName = @name";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", _tischName);
                    cmd.ExecuteNonQuery();
                }
            }
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

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            _form3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tbPresonen_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbTelefonnummer_TextChanged(object sender, EventArgs e)
        {
        }

        private void tBNachname_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
