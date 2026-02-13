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

        public Form4()
        {
            InitializeComponent();
        }

        public Form4(Form1 form1)
        {
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

            _form1.SetButtonColor(Color.Red);

            _form1.ReceiveText(nachname);

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

        private void button2_Click(object sender, EventArgs e)
        {
            _form1.SetButtonColor(Color.Lime);
            _form1.ChangeButtonname(Buttonname);

            this.Hide();
        }
    }
}
