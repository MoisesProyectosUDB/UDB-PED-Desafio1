using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio1_PED
{
    public partial class CapturaDatos : Form
    {
        public CapturaDatos()
        {
            InitializeComponent();
        }

        private void CapturaDatos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.Write("Prueba");
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frmlogin = new Form1();
            frmlogin.Show();
        }
    }
}
