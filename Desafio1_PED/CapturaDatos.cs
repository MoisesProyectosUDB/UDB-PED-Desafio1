using Desafio1_PED.Model;
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
        
        Nodo<String> raiz = null;
        public CapturaDatos()
        {
            InitializeComponent();
            CreaEncabezadoNodo();

        }


        private void CapturaDatos_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frmlogin = new Form1();
            frmlogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Lehemos lo capturado 
            string nPaciente = textBox1.Text;
            int genero = comboBox1.SelectedIndex;
            int sangre = comboBox2.SelectedIndex;
            int presion = comboBox3.SelectedIndex;
            List<string> listOfUsers = new List<string>();
         
            Console.WriteLine(genero);
            if (genero == -1 || sangre == -1 || presion == -1)
            {
                MessageBox.Show("Todos Los Datos son Oblitarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                ////Recorremos el mismo para agregar 
                //for (int iRaiz = 0; iRaiz < 2; iRaiz ++)
                //{
                //     if (iRaiz == 0) //agregamos  paciente al sexo
                //    {
                //        for (int igenero = 0; igenero < 1; igenero++)
                //        {
                //            if (genero == igenero)
                //            {
                //                //agregamos a nodo Masculino
                //                listOfUsers[igenero].agregarHijo(nPaciente);
                //            }
                //        }
                //    }
                //}
                MessageBox.Show("Todos Los Datos son Oblitarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }








        }


        private void CreaEncabezadoNodo()
        {

            raiz = new Nodo<String>(null, "Pacientes");//Se crea la Raiz Pacientes
            Nodo<String> genero = new Nodo<String>(raiz, "Género");//Se Crea el segundo nivel de Genero
            Nodo<String> gH = new Nodo<String>(genero, "Hombre");//Se crea hijo 1° hijo de genero
            Nodo<String> gF = new Nodo<String>(genero, "Mujer");//Se crea hijo 2° hijo de genero
            Nodo<String> sangre = new Nodo<String>(raiz, "Sangre");//Se Crea el segundo nivel de Sangre
            Nodo<String> sangre1 = new Nodo<String>(sangre, "A+");// Se crea hijo 1° hijo de Sangre
            Nodo<String> sangre2 = new Nodo<String>(sangre, "B+");// Se crea hijo 2° hijo de Sangre
            Nodo<String> sangre3 = new Nodo<String>(sangre, "O+");// Se crea hijo 3° hijo de Sangre
            Nodo<String> sangre4 = new Nodo<String>(sangre, "AB+");// Se crea hijo 4° hijo de Sangre
            Nodo<String> sangre5 = new Nodo<String>(sangre, "A-");// Se crea hijo 5° hijo de Sangre
            Nodo<String> sangre6 = new Nodo<String>(sangre, "A-");// Se crea hijo 6° hijo de Sangre
            Nodo<String> sangre7 = new Nodo<String>(sangre, "B-");// Se crea hijo 7° hijo de Sangre
            Nodo<String> sangre8 = new Nodo<String>(sangre, "O-");// Se crea hijo 8° hijo de Sangre
            Nodo<String> sangre9 = new Nodo<String>(sangre, "AB-");// Se crea hijo 9° hijo de Sangre 
            Nodo<String> presion = new Nodo<String>(raiz, "Presión");//Se Crea el segundo nivel de presion
            Nodo<String> presion1 = new Nodo<String>(sangre, "Alta");// Se crea hijo 1° hijo de presion
            Nodo<String> presion2 = new Nodo<String>(sangre, "Media");// Se crea hijo 2° hijo de presion
            Nodo<String> presion3 = new Nodo<String>(sangre, "Baja");// Se crea hijo 3° hijo de presion
            //Iniciamos a crear  la realacion de abajo hacia arriba GENERO
            genero.agregarHijo(gH);
            genero.agregarHijo(gF);
            raiz.agregarHijo(genero);
            //Iniciamos a crear  la realacion de abajo hacia arriba Sangre
            sangre.agregarHijo(sangre1);
            sangre.agregarHijo(sangre2);
            sangre.agregarHijo(sangre3);
            sangre.agregarHijo(sangre4);
            sangre.agregarHijo(sangre5);
            sangre.agregarHijo(sangre6);
            sangre.agregarHijo(sangre7);
            sangre.agregarHijo(sangre8);
            sangre.agregarHijo(sangre9);
            raiz.agregarHijo(sangre);
            //Iniciamos a crear  la realacion de abajo hacia arriba Presion
            presion.agregarHijo(presion1);
            presion.agregarHijo(presion2);
            presion.agregarHijo(presion3);
            raiz.agregarHijo(presion);
            //Arbol<String> a = new Arbol<String>(raiz);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Arbol<String> a = new Arbol<String>(raiz);

            //Graficcar Arbol
        }
    }
}
