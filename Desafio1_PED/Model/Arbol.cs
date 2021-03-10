
using System.Collections.Generic;

namespace Desafio1_PED.Model
{
    class Arbol<Tipo>
    {
        private Arbol<Tipo> padre;
        private Tipo valor;
        private List<Arbol<Tipo>> hijos;

     /**
    * Construye un Nuevo Nodo estableciendo a un padre y con un valor inicial     
    */
        public Arbol(Arbol<Tipo> padre, Tipo valor)
        {
            this.padre = padre;
            this.valor = valor;
            hijos = new List<Arbol<Tipo>> ();
        }
              

        public void setValor(Tipo valor) //Modifica el Valor
        {
            this.valor = valor;
        }
        public Tipo getValor() //obtiene el valor  "Paciente","Genero",etc
        {
            return valor;
        }

        public void agregarHijo(Arbol<Tipo> hijo) //agrega hijos al nodo<Tipo>
        {
            hijos.Add(hijo);
        }
        public List<Arbol<Tipo>> getHijos()//Devuelve una lista de los hijos del  nodo<Tipo>
        {
            return this.hijos;
        }

        //public Boolean esPadre() // Indica si el nodo tiene hijos
        //{
        //    return !hijos.isEmpty();
        //}

        public Arbol<Tipo> getPadre()//  Devuelve el nodo padre
        {
            return this.padre;
        }

    }
}
