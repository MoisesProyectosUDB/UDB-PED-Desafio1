using System;
using System.Collections;
using System.Collections.Generic;

namespace Desafio1_PED.Model
{
    class Nodo<Tipo>
    {
        private Nodo<Tipo> padre;
        private Tipo valor;
        private List<Nodo<Tipo>> hijos;

     /**
    * Construye un Nuevo Nodo estableciendo a un padre y con un valor inicial     
    */
        public Nodo(Nodo<Tipo> padre, Tipo valor)
        {
            this.padre = padre;
            this.valor = valor;
            hijos = new List<Nodo<Tipo>> ();
        }

      

        public void setValor(Tipo valor) //Modifica el Valor
        {
            this.valor = valor;
        }
        public Tipo getValor() //obtiene el valor 
        {
            return valor;
        }

        public void agregarHijo(Nodo<Tipo> hijo) //agrega hijos al nodo<Tipo>
        {
            hijos.Add(hijo);
        }
        public List<Nodo<Tipo>> getHijos()//Devuelve una lista de los hijos del  nodo<Tipo>
        {
            return this.hijos;
        }

        //public Boolean esPadre() // Indica si el nodo tiene hijos
        //{
        //    return !hijos.isEmpty();
        //}

        public Nodo<Tipo> getPadre()//  Devuelve el nodo padre
        {
            return this.padre;
        }

    }
}
