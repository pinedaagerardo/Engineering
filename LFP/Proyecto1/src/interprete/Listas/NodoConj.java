/*
 * NodoConj.java
 *
 * Created on 26 de septiembre de 2007, 06:28 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package interprete.Listas;

import java.util.Vector;

/**
 * Clase que contiene todos los conjuntos y elementos sin error del archivo de
 * entrada. Esta clase tiene un atributo que es un vector de todos sus elementos.
 * Si un elemento tiene error, no se agrega el conjunto a la cola.
 * @author gerardo
 */
public class NodoConj {
    
    /**El nombre del conjunto*/
    public String Nombre=new String();
    /**El siguiente conjunto en la cola*/
    public NodoConj Siguiente=null;
    /**Un vector que contiene los elementos del conjunto*/
    public Vector Elementos=new Vector();
    
    /** Crea una nueva instancia de NodoConj usando los datos de conjunto
     * @param conjunto es el conjunto del que se va a tomar los datos para crear
     * el nuevo NodoConj
     */
    public NodoConj(NodoConj conjunto) {
        this.Nombre=new String(conjunto.Nombre);
        if(!conjunto.Elementos.isEmpty())
            this.Elementos.addAll(conjunto.Elementos);//=conjunto.Elementos
    }
    
    /** Crea una nueva instancia de NodoConj usando el nombre recibido
     * @param Nombre es el nombre que se le va a asignar al nuevo NodoConj
     */
    public NodoConj(String Nombre) {
        this.Nombre=new String(Nombre);
    }
    
    /** Crea una nueva instancia de NodoConj usando el nombre y los elementos recibidos
     * @param Nombre es el nombre que se le va a asignar al nuevo NodoConj
     * @param elementos son los elementos que se le va a asignar al nuevo NodoConj
     */
    public NodoConj(String Nombre, Vector elementos) {
        this.Nombre=new String(Nombre);
        if(!elementos.isEmpty())
            this.Elementos.addAll(elementos);
    }
    
}
