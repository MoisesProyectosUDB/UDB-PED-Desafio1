using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_PED.Model
{
     class Arbol<Tipo>
    {
        Nodo<Tipo> raiz;

        /**
         * Constructor del árbol con raíz
         * @param raiz  
         */
        public Arbol(Nodo<Tipo> raiz)
        {
            this.raiz = raiz;
        }

    }   
}
