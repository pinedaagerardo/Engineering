/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package HERRAMIENTAS;

import MATRIZ_ORTOGONAL.Categoria;
import MATRIZ_ORTOGONAL.Celda;
import MATRIZ_ORTOGONAL.miNodo;
import java.util.Iterator;
import java.util.SortedSet;

/**
 *Clase que se encarga de hacer todas las busquedas, ya sea para insercion,
 * eliminacion o para una busqueda simple
 * @author gerardo
 */
public class Busqueda {

    /**
     * busca el nombre d una categoria entre las categorias que se reciben
     * como parametro. Al encontrar la categoria la retorna o null de lo contrario
     * @param cat la categoria a buscar
     * @param cats el conjunto de categorias en donde se debe buscar
     * @return la categoria encontrada o null si no la encuentra
     */
    public Categoria getCat(String cat, SortedSet cats) {
        if(cats==null) return null;
        Iterator it=cats.iterator();
        Categoria c;
        while(it.hasNext())
            if((c=(Categoria)it.next()).nombre.equalsIgnoreCase(cat))
                return c;
        
        return null;
    }

    /**
     * busca una celda entre las de celdas recibidas como parametro
     * y la retorna si la encuentra, de lo contrario retorna null
     * @param letra la letra a la que pertenece el conjunto de categorias en esta celda
     * @param celdas el conjunto de celdas en que se buscara, en otras palabras,
     * es la categoria en que se busca la celda
     * @return la celda encontrada o null si no se encuentra
     */
    public Celda getCel(String letra, Categoria celdas) {
        if(celdas==null) return null;
        Iterator it=celdas.listado.iterator();
        Celda c;
        while(it.hasNext())
            if((c=(Celda)it.next()).letra.toString().equalsIgnoreCase(letra))
                return c;
        
        return null;
    }

    /**
     * busca una empresa que coincida con el nombre de la categoria y letra que
     * se recibe como parametros
     * @param emp el nombre de la empresa que se quiere encontrar. Aqui se toma
     * la primera letra para saber a que celda pertenece la empresa.
     * @param cat el nombre de la categoria a la que pertenece la empresa que se
     * busca
     * @return la empresa que se encontro o null si no se encontro la empresa
     */
    public miNodo getEmpresa(String emp, String cat) {
        Categoria cat_actual=getCat(cat, Matriz.cat);
        Celda c_actual=getCel(String.valueOf(emp.toLowerCase().charAt(0)),cat_actual);
        if(c_actual==null) return null;
        Iterator it=c_actual.empresa.iterator();
        miNodo emp_tmp;
        while(it.hasNext()){
            if((emp_tmp=(miNodo)it.next()).nombre.equalsIgnoreCase(emp))
                return emp_tmp;
        }
        
        return null;
    }

}
