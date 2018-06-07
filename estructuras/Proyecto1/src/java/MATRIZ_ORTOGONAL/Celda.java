/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package MATRIZ_ORTOGONAL;

import HERRAMIENTAS.ComparadorAlfabetico;
import java.util.SortedSet;
import java.util.TreeSet;

/**
 * Es un nodo que contiene a todas las empresas de la categoria y letra que
 * corresponde. (la letra es para llevar un orden alfabetico)
 * @author gerardo
 */
public class Celda {

    public String categoria;
    public Character letra;
    
    public Celda r;
    public Celda l;
    public Celda u;
    public Celda d;
    
    public SortedSet empresa;
    ComparadorAlfabetico ordenAlfabetico;
    
    /**
     * constructor de la clase Celda.
     * @param cat la categoria a la que pertenece
     * @param let la letra que corresponde para llevar el orden
     */
    public Celda(String cat,char let){
        ordenAlfabetico=new ComparadorAlfabetico();
        empresa = new TreeSet(ordenAlfabetico);
        categoria=new String(cat);
        letra=new Character(let);
        r=null;
        l=null;
        u=null;
        d=null;
    }
    
    /**
     * Constructor de la clase Celda.
     */
    public Celda(){
        ordenAlfabetico=new ComparadorAlfabetico();
        empresa =new TreeSet(ordenAlfabetico);
        categoria=null;
        letra=null;
        r=null;
        l=null;
        u=null;
        d=null;
    }
}
