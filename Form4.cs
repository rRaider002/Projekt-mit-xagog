using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            _form1 = form1; // always assign Form1 here
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        public void SetOtherForms(Form2 form2, Form3 form3, Form1 form1ForNavigation)
        {
            _form2 = form2;
            _form3 = form3;
            // optional: _form1 = form1ForNavigation; // we already have _form1 from constructor
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            int personen = Convert.ToInt32(tbPresonen.Text);

            // This will never be null now
            _form1.SetButtonColor(Color.Red);



        }
    }
}
