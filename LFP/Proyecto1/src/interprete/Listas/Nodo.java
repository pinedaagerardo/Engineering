/*
 * Nodo.java
 *
 * Created on 23 de septiembre de 2007, 10:12 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package interprete.Listas;

/**
 * Clase que almacena datos en tiempo de ejecucion para usarlos en una lista enlazada
 * @author gerardo
 */
public class Nodo {
    
    /**Es el lexema*/
    public String lexema;
    /**Es el tipo del lexema*/
    public String tipo;
    /**Es el numero del nodo en la cola (como identificador)*/
    public int numero;
    /**La linea en donde esta el lexema en el archivo de entrada*/
    public int linea;
    /**La columna en donde comienza el lexema en el archivo de entrada*/
    public int columna;
    /**El siguiente Nodo*/
    public Nodo siguiente;
    
    /** Crea una nueva instancia de Nodo */
    public Nodo(String lex,String tip,int num, int lin, int col, Nodo sig) {
        this.lexema = lex;
        this.tipo = tip;
        this.numero = num;
        this.linea = lin;
        this.columna=col;
        this.siguiente = sig;
    }
    
    /** Crea una nueva instancia de Nodo */
    public Nodo(String lex,String tip,int num, int lin, int col){
        this(lex,tip,num,lin,col,null);
    }
    
}
