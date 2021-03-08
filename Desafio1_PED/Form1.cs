using System;
using System.Windows.Forms;
using System.Configuration;
namespace Desafio1_PED
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuarioEntrada = textBox1.Text.Trim();
            string passwordEntrada = textBox2.Text.Trim();
            string usuarioValida;
            string passwordValida;

            //login simple

            //se toman los valores del cofig
            if (string.IsNullOrEmpty(usuarioEntrada) || string.IsNullOrEmpty(passwordEntrada))
            {
                errorProvider1.SetError(textBox1, "Debe Ingresar un Valor");
                errorProvider1.SetError(textBox2, "Debe Ingresar un Valor");
            }
            else
            {
                usuarioValida=ConfigurationManager.AppSettings["Usuario"];
                passwordValida = ConfigurationManager.AppSettings["Password"];
                if (usuarioEntrada == usuarioValida && passwordEntrada == passwordValida)
                {
                    this.Hide();
                    CapturaDatos frmCap = new CapturaDatos();
                    frmCap.Show();
                } else
                {
                    MessageBox.Show("Credenciales Invalidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear(); textBox2.Clear(); textBox1.Focus();
                }


            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
