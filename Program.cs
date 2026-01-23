using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form1 = new Form1();
            Form2 form2 = new Form2();
            Form3 form3 = new Form3();
            Form4 form4 = new Form4(form1); 

            
            form1.SetOtherForms(form2, form3, form4);
            form2.SetOtherForms(form1, form3, form4);
            form3.SetOtherForms(form2, form1, form4);
            form4.SetOtherForms(form2, form3, form1);

            Application.Run(form1);

        }
    }
}
