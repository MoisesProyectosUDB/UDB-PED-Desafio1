using Desafio1_PED.Model;
using System;
using System.Windows.Forms;

namespace Desafio1_PED
{
    public partial class CapturaDatos : Form

    {

        Arbol<String> raiz = null;
        Funciones funciones = new Funciones();

        public CapturaDatos()
        {
            InitializeComponent();            
            CreaEncabezadoArbol();
           
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
            
            Console.WriteLine(genero);
            if (genero == -1 || sangre == -1 || presion == -1 || string.IsNullOrEmpty(nPaciente)==true)
            {
                MessageBox.Show("Todos Los Datos son Obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                ////Recorremos la raiz
                for (int iRaiz = 0; iRaiz < raiz.getHijos().Count; iRaiz++)
                {
                    if (iRaiz == 0) //comparamos la posicion 0 que es Genero
                    {
                        for (int igenero = 0; igenero < raiz.getHijos()[iRaiz].getHijos().Count; igenero++)//Recorremos Genero
                        {
                            if (genero == igenero)// lo capturado sea igual a la piscion del arreglo genero
                            {
                                //Console.WriteLine(raiz.getHijos()[iRaiz].getHijos()[igenero].getValor());
                                //agregamos a Arbol Masculino
                                Arbol<String> g1 = new Arbol<String>(raiz.getHijos()[iRaiz].getHijos()[igenero], nPaciente);//Se crea hijo  segun lo capturado
                                raiz.getHijos()[iRaiz].getHijos()[igenero].agregarHijo(g1);//se añade el hijo al padre
                            }
                        }
                       
                    }

                    if (iRaiz == 1) //comparamos la posicion 1 que es Sangre
                    {
                        for (int isangre = 0; isangre < raiz.getHijos()[iRaiz].getHijos().Count; isangre++)//Recorremos Genero
                        {
                            if (sangre == isangre)// lo capturado sea igual a la piscion del arreglo genero
                            {
                                //Console.WriteLine(raiz.getHijos()[iRaiz].getHijos()[igenero].getValor());
                                //agregamos a Arbol Masculino
                                Arbol<String> s1 = new Arbol<String>(raiz.getHijos()[iRaiz].getHijos()[isangre], nPaciente);//Se crea hijo  segun lo capturado
                                raiz.getHijos()[iRaiz].getHijos()[isangre].agregarHijo(s1);//se añade el hijo al padre
                            }
                        }

                    }
                    if (iRaiz == 2) //comparamos la posicion 2 que es Presion
                    {
                        for (int ipresion = 0; ipresion < raiz.getHijos()[iRaiz].getHijos().Count; ipresion++)//Recorremos Genero
                        {
                            if (presion == ipresion)// lo capturado sea igual a la piscion del arreglo genero
                            {
                                //Console.WriteLine(raiz.getHijos()[iRaiz].getHijos()[igenero].getValor());
                                //agregamos a Arbol Masculino
                                Arbol<String> p1 = new Arbol<String>(raiz.getHijos()[iRaiz].getHijos()[ipresion], nPaciente);//Se crea hijo  segun lo capturado
                                raiz.getHijos()[iRaiz].getHijos()[ipresion].agregarHijo(p1);//se añade el hijo al padre
                            }
                        }

                    }
                }
                //MessageBox.Show("Todos Los Datos son Oblitarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();//Limpiamos Controles
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;

            }








        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Cadena = DibujarFijura();//Obtienen la cadena a utilzar por Graphviz 
            if (string.IsNullOrEmpty(Cadena) != true)//Evaluamos si no esta null o vacia 
            {
               
                if (funciones.CrearArchivos(Cadena) == true) //Metodo para generar el Archivo
                {
                   if (funciones.Generate_Graph() == true)//metodo que genera la img y ejecuta el Comando // dot -Tjpg C:/ResultadoArbol\abbT.txt -o C:/ResultadoArbol\abbT.jpg
                    {
                        //Cargamos la img al picture
                        System.IO.FileStream AliasFigura; // Declaración del alias del archivo  Figura.jpg
                        try // Intenta abrir el archivo
                        {
                            AliasFigura = new System.IO.FileStream(@"C:\ResultadoArbol\abbT.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            abbIMG.Image = System.Drawing.Bitmap.FromStream(AliasFigura);// Intenta cargar la imagen en el pictureBox
                            AliasFigura.Close(); // Cierra el archivo   
                        }
                        catch (Exception x) // En caso de error ...
                        {
                            MessageBox.Show("No se pudo abrir el archivo", "E R R OR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show("No se pudo cargar la imagen del archivo", "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             

                        }finally
                        {
                            
                            abbIMG.Refresh(); // Refresca la imagen
                        }
                       
                       
                       

                    }
                }
                else
                {
                    MessageBox.Show("Error al Crear al Arbol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           else
            {
                MessageBox.Show("Ningun Valor Agregado al Arbol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Graficcar Arbol
        }


        private void CreaEncabezadoArbol()
        {//Este metdo Crea los 3 Primeros niveles del arbol

            raiz = new Arbol<String>(null, "Pacientes");//Se crea la Raiz Pacientes
            Arbol<String> genero = new Arbol<String>(raiz, "Género");//Se Crea el segundo nivel de Genero
            Arbol<String> gH = new Arbol<String>(genero, "Hombre");//Se crea hijo 1° hijo de genero
            Arbol<String> gF = new Arbol<String>(genero, "Mujer");//Se crea hijo 2° hijo de genero
            Arbol<String> sangre = new Arbol<String>(raiz, "Sangre");//Se Crea el segundo nivel de Sangre
            Arbol<String> sangre1 = new Arbol<String>(sangre, "A");// Se crea hijo 1° hijo de Sangre
            Arbol<String> sangre2 = new Arbol<String>(sangre, "B");// Se crea hijo 2° hijo de Sangre
            Arbol<String> sangre3 = new Arbol<String>(sangre, "O");// Se crea hijo 3° hijo de Sangre
            Arbol<String> sangre4 = new Arbol<String>(sangre, "AB");// Se crea hijo 4° hijo de Sangre            
            Arbol<String> presion = new Arbol<String>(raiz, "Presión");//Se Crea el segundo nivel de presion
            Arbol<String> presion1 = new Arbol<String>(sangre, "Alta");// Se crea hijo 1° hijo de presion
            Arbol<String> presion2 = new Arbol<String>(sangre, "Media");// Se crea hijo 2° hijo de presion
            Arbol<String> presion3 = new Arbol<String>(sangre, "Baja");// Se crea hijo 3° hijo de presion
            //Iniciamos a crear  la realacion de abajo hacia arriba GENERO
            genero.agregarHijo(gH);
            genero.agregarHijo(gF);
            raiz.agregarHijo(genero);
            //Iniciamos a crear  la realacion de abajo hacia arriba Sangre
            sangre.agregarHijo(sangre1);
            sangre.agregarHijo(sangre2);
            sangre.agregarHijo(sangre3);
            sangre.agregarHijo(sangre4);            
            raiz.agregarHijo(sangre);
            //Iniciamos a crear  la realacion de abajo hacia arriba Presion
            presion.agregarHijo(presion1);
            presion.agregarHijo(presion2);
            presion.agregarHijo(presion3);
            raiz.agregarHijo(presion);
           

        }

        public string DibujarFijura()
        {
            String Resultado = null;
            if (raiz.getHijos().Count!= 0)
            {



                Resultado = Resultado + "digraph Figura {";
                Resultado = Resultado + "\n" + raiz.getValor() + "->";//Cabeza de la Raiz
                for (int iRaiz = 0; iRaiz < raiz.getHijos().Count; iRaiz++)//Recoriendo los hijos  del nivel uno
                {
                    if (iRaiz == 0)
                    {
                        Resultado = Resultado + raiz.getHijos()[iRaiz].getValor() + ";";//Complemento de la Cabeza del Arbol
                        for (int igenero = 0; igenero < raiz.getHijos()[iRaiz].getHijos().Count; igenero++)//Recorremos hijos de  Genero
                        {
                            Resultado = Resultado + "\n" + raiz.getHijos()[iRaiz].getValor() + "->" + raiz.getHijos()[iRaiz].getHijos()[igenero].getValor() + ";";
                            for (int ipaciente1 = 0; ipaciente1 < raiz.getHijos()[iRaiz].getHijos()[igenero].getHijos().Count; ipaciente1++)
                            {
                                Resultado = Resultado + "\n" + raiz.getHijos()[iRaiz].getHijos()[igenero].getValor() + "->" + raiz.getHijos()[iRaiz].getHijos()[igenero].getHijos()[ipaciente1].getValor() + ";";
                            }
                        }
                    }
                    if (iRaiz == 1)
                    {
                        Resultado = Resultado + "\n" + raiz.getValor() + "->" + raiz.getHijos()[iRaiz].getValor() + ";";
                        for (int isangre = 0; isangre < raiz.getHijos()[iRaiz].getHijos().Count; isangre++)//Recorremos hijos de  sangre
                        {
                            Resultado = Resultado + "\n" + raiz.getHijos()[iRaiz].getValor() + "->" + raiz.getHijos()[iRaiz].getHijos()[isangre].getValor() + ";";
                            for (int ipaciente2 = 0; ipaciente2 < raiz.getHijos()[iRaiz].getHijos()[isangre].getHijos().Count; ipaciente2++)//Recorremos los Pasientes agregados
                            {
                                Resultado = Resultado + "\n" + raiz.getHijos()[iRaiz].getHijos()[isangre].getValor() + "->" + raiz.getHijos()[iRaiz].getHijos()[isangre].getHijos()[ipaciente2].getValor() + ";";
                            }
                        }
                    }

                    if (iRaiz == 2)
                    {
                        Resultado = Resultado + "\n" + raiz.getValor() + "->" + raiz.getHijos()[iRaiz].getValor() + ";";
                        for (int ipresion = 0; ipresion < raiz.getHijos()[iRaiz].getHijos().Count; ipresion++)//Recorremos hijos de  Preson
                        {
                            Resultado = Resultado + "\n" + raiz.getHijos()[iRaiz].getValor() + "->" + raiz.getHijos()[iRaiz].getHijos()[ipresion].getValor() + ";";
                            for (int ipaciente3 = 0; ipaciente3 < raiz.getHijos()[iRaiz].getHijos()[ipresion].getHijos().Count; ipaciente3++)//Recorremos Pasientes Presion
                            {
                                Resultado = Resultado + "\n" + raiz.getHijos()[iRaiz].getHijos()[ipresion].getValor() + "->" + raiz.getHijos()[iRaiz].getHijos()[ipresion].getHijos()[ipaciente3].getValor() + ";";
                            }
                        }
                    }

                    //else
                    //{
                    //    //Console.WriteLine(raiz.getHijos()[iRaiz].getHijos()[igenero].getValor());
                    //    Resultado = Resultado + "\n" + raiz.getValor() + "->" + raiz.getHijos()[iRaiz].getValor() + ";";
                    //}

                }
                Resultado = Resultado + "\n}";
                Console.WriteLine(Resultado);
                return Resultado;
                

            }else
            {
               
                return Resultado;
            }


           

        }
      







    }
}
