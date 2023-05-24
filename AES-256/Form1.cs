using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES_256
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ProcessStartInfo Ps = null;

        private void button1_Click(object sender, EventArgs e)
        {
            Ps = new ProcessStartInfo("cmd.exe");

            Ps.UseShellExecute = false;

            Ps.RedirectStandardOutput = true;

            Ps.CreateNoWindow = true;

            Ps.FileName = "java";

            string Password = textBox2.Text;

            string PathOf = textBox1.Text;

            string PathTo = textBox3.Text;

            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            string DirExePath = System.IO.Path.GetDirectoryName(exePath);

            string AESPath = System.IO.Path.Combine(DirExePath, "AES");

            string eOrD = null;

            if(radioButton1.Checked)
            {
                eOrD = "e";
            }

            else if(radioButton2.Checked)
            {
                eOrD = "d";
            }

            Ps.Arguments = String.Format("-cp {0} es.vocali.util.AESCrypt {1} {2} {3} {4}", AESPath, eOrD, Password, PathOf, PathTo);

            Process.Start(Ps);
        }
    }
}
