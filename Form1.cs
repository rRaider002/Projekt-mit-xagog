using System;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace Projekt
{
    public partial class Form1 : Form
    {
        private Form2 _form2;
        private Form3 _form3;
        private Form4 _form4;
        private Form6 _form6;
        public Button _lastClickedButton;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;

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

        public void SetOtherForms(Form2 form2, Form3 form3, Form4 form4, Form6 form6)
        {
            _form2 = form2;
            _form3 = form3;
            _form4 = form4;
            _form6 = form6;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(1);
            comboBox1.Items.Add(2);
            comboBox1.Items.Add(3);
            comboBox1.Items.Add(4);
            comboBox1.SelectedIndex = 0;

            LadeTischStatus();
        }

        public int GetSelectedSlot()
        {
            if (comboBox1.SelectedItem == null)
                return -1;

            return Convert.ToInt32(comboBox1.SelectedItem);
        }

        public void LadeTischStatus()
        {
            if (comboBox1.SelectedItem == null)
                return;

            int slot = GetSelectedSlot();

            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Name.StartsWith("Tisch"))
                {
                    int tischID = GetTischIDFromName(button.Name);

                    if (tischID == -1)
                        continue;

                    if (IstTischReserviert(tischID, slot))
                    {
                        button.BackColor = Color.Red;
                        button.Enabled = true;

                        string nachname = GetNachnameVonReservierung(tischID, slot);

                        if (!string.IsNullOrWhiteSpace(nachname))
                            button.Text = nachname;
                        else
                            button.Text = "Reserviert";
                    }
                    else
                    {
                        button.BackColor = Color.Lime;
                        button.Text = button.Name;
                        button.Enabled = true;
                    }
                }
            }
        }


        private string GetNachnameVonReservierung(int tischID, int slot)
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
        SELECT g.Nachname
        FROM Reservierung r
        INNER JOIN Gast g ON r.GastID = g.GastID
        WHERE r.TischID = @tischID
          AND r.Slot = @slot
          AND r.IsDeleted = 0
        ORDER BY r.ReservierungID DESC
        LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tischID", tischID);
                    cmd.Parameters.AddWithValue("@slot", slot);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        return result.ToString();
                }
            }

            return "";
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
                    AND IsDeleted = 0";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tischID", tischID);
                    cmd.Parameters.AddWithValue("@slot", slot);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private int GetTischIDFromName(string tischName)
        {
            string connStr = "server=localhost;user=root;password=root;database=vesuv";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT TischID FROM Tisch WHERE TischName = @name";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", tischName);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        return Convert.ToInt32(result);
                }
            }

            return -1;
        }

        public void AnyButton_Click(object sender, EventArgs e)
        {
            _form4.Hide();
            _lastClickedButton = sender as Button;

            if (_lastClickedButton == null)
                return;

            int tischID = GetTischIDFromName(_lastClickedButton.Name);


            _form4.SetTischName(_lastClickedButton.Name);
            _form4.Show();
        }

        public void SetButtonColor(Color color)
        {
            if (_lastClickedButton != null)
            {
                _lastClickedButton.BackColor = color;
            }
        }

        private void Menu2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            _form2.Show();
        }

        private void Menu3_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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

        private void Tisch9_Click(object sender, EventArgs e)
        {

        }

        private void Tisch13_Click(object sender, EventArgs e)
        {

        }

        private void Tisch17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LadeTischStatus();

        }
    }
}
