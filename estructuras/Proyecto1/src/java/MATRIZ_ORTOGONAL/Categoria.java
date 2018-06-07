/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package MATRIZ_ORTOGONAL;

import HERRAMIENTAS.ComparadorAlfabetico;
import java.util.SortedSet;
import java.util.TreeSet;

/**
 * Esta clase es el nodo que representa las categorias de la matriz
 * @author gerardo
 */
public class Categoria{

    public String nombre;
    
    //public Categoria sig;
    //public Categoria ant; no son necesarios porq uso SortedSet y TreeSet
    
    public SortedSet listado;
    ComparadorAlfabetico ordenAlfabetico;
    
    /**
     * Constructor de Categoria
     * @param nom el nombre de la categoria
     */
    public Categoria(String nom){
        ordenAlfabetico=new ComparadorAlfabetico();
        this.listado=new TreeSet(ordenAlfabetico);
        this.nombre=new String(nom);
        //this.sig=null;
        //this.ant=null;
    }
    
    /**
     * Constructor de Categoria
     */
    public Categoria(){
        ordenAlfabetico=new ComparadorAlfabetico();
        this.listado=new TreeSet(ordenAlfabetico);
        this.nombre=null;
        //this.sig=null;
        //this.ant=null;
    }
    
}
