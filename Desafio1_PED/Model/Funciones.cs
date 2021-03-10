
using System;
using System.IO;
using System.Windows.Forms;

namespace Desafio1_PED.Model
{
   public   class Funciones
    {

        

        public bool CrearArchivos(string ArbolFijura)
        {
            try
            {
                TextWriter text;
                text = new StreamWriter("C:\\ResultadoArbol\\abbT.txt");//Crear El Archivo


                text.WriteLine(ArbolFijura);//Escribe en el Archivo
                text.Close();
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }


        }

        public  bool Generate_Graph()
        {
            string fileName = "abbT.txt";
            string path = "C:/ResultadoArbol";
            try
            {
                var command = string.Format("dot -Tjpg {0} -o {1}", Path.Combine(path, fileName), Path.Combine(path, fileName.Replace(".txt", ".jpg")));
                Console.WriteLine(command);
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/C " + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
                return true;
            }
            catch (Exception x)
            {
                Console.WriteLine(x.ToString());
                return false;
            }
        }

    }   
}
