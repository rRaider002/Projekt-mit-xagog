using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form1 = new Form1();
            Form2 form2 = new Form2();
            Form3 form3 = new Form3(form1);
            Form4 form4 = new Form4(form1);
            Login form5 = new Login();
            Form6 form6 = new Form6();

            
            form1.SetOtherForms(form2, form3, form4, form6);
            form2.SetOtherForms(form1, form3, form4);
            form3.SetOtherForms(form2, form1, form4);
            form4.SetOtherForms(form2, form3, form1);
            form5.SetOtherForms(form1);
            form6.SetOtherForms(form1, form2);

            Application.Run(form1);

        }
    }
}
