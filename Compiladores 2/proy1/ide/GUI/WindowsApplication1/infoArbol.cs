using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    //clase que almacena informacion usada en treeView_Explorador y listView_ExploradorArchivos
    class infoArbol
    {
        string raiz;

        // constructor.
        public infoArbol(string p_raiz)
        {
            if (!p_raiz.EndsWith("\\"))
                raiz = p_raiz + "\\";
            else
                raiz = p_raiz;
        }

        //Devuelve la raiz del arbol.
        public string v_raiz
        {
            get { return raiz; }
        }

        // Devuelve el nombre al final de la cadena
        public string nodo(string item)
        {
            int ubi_pos;

            for (ubi_pos = item.Length - 1; ubi_pos >= 0; ubi_pos--)
            {
                if (item[ubi_pos] == '\\') break;
            }

            return (item.Substring(ubi_pos + 1));
        }
    }
}
