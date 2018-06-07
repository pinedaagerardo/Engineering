/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Datos;

import java.util.Iterator;
import java.util.SortedSet;
import java.util.TreeSet;

/**
 * clase que representa el nodo interno de un arbol
 * @author gerardo
 */
public class NodoArbol {

    /**el padre del nodo*/
    public NodoArbol padre;
    /**los hijos del nodo*/
    public SortedSet hijos;
    /**la traduccion de la palabra*/
    public String traduccion;
    /**la palabra o una parte de ella, dependiendo la posicion del nodo en el arbol*/
    public String palabra;
    /**Direccion de la imagen*/
    public String path;
    /**la letra llave*/
    public char letra;
    /**la profundidad del nodo en el arbol*/
    public int profundidad;
    /**comparador usado para ordenar los nodos hijos*/
    private ComparadorNodoArbol cna;
    
    /**
     * constructor usado para las hojas
     * @param father el padre del nodo
     * @param word la palabra en español
     * @param traduction la traduccion de la palabra
     * @param p la direccion de la imagen
     * @param c la letra llave
     * @param deep la profundidad del nodo en el arbol
     */
    public NodoArbol(NodoArbol father,String traduction,String word,String p,char c,int deep){
        cna=new ComparadorNodoArbol();
        padre=father;
        hijos=new TreeSet(cna);
        traduccion=traduction;
        palabra=word;
        path=p;
        letra=c;
        profundidad=deep;
    }
    
    /**
     * constructor usado para los nodos internos
     * @param father el padre del nodo
     * @param word la palabra en español
     * @param traduction la traduccion de la palabra
     * @param c la letra llave
     * @param deep la profundidad del nodo en el arbol
     */
    public NodoArbol(NodoArbol father,String word,char c,int deep){
        cna=new ComparadorNodoArbol();
        padre=father;
        hijos=new TreeSet(cna);
        traduccion=null;
        palabra=word;
        path=null;
        letra=c;
        profundidad=deep;
    }
    
    /**
     * constuctor usado para la raiz del arbol
     * @param c la letra llave
     * @param deep la profundidad del nodo en el arbol
     */
    public NodoArbol(char c,int deep){
        cna=new ComparadorNodoArbol();
        padre=null;
        hijos=new TreeSet(cna);
        traduccion=null;
        palabra=null;
        path=null;
        letra=c;
        profundidad=deep;
    }
    
    /**
     * Borra el hijo n del nodo actual
     * @param n el hijo a borrar
     */
    public void borrarHijo(NodoArbol n){
        hijos.remove(n);
    }
    
    /**
     * Inserta los nodos necesarios para formar la palabra nueva y asigna todos
     * los datos a la nueva palabra.
     * @param substring la cadena necesaria para formar una nueva palabra
     * @param traduccion la traduccion de la palabra
     * @param direccion la direccion de la imagen
     */
    public void insertarHijo(int pos,String palabra,String traduccion,String direccion){
        NodoArbol tmp=this;
        for(int i=pos;i<palabra.length();i++){
            if(i!=palabra.length()-1){
                tmp.hijos.add(new NodoArbol(tmp,palabra.substring(0, i+1),palabra.charAt(i),tmp.profundidad+1));
                tmp=tmp.getHijo(palabra.charAt(i));
            }
            else{
                tmp.hijos.add(new NodoArbol(tmp,traduccion,palabra,direccion,palabra.charAt(i),tmp.profundidad+1));
            }
        }
    }
    
    /**
     * Devuelve un hijo que tenga como llave la letra recibida como parametro o
     * null si no existe ese hijo.
     * @param c la letra llave con que se busca el hijo
     * @return un hijo de tipo NodoArbol que tenga como llave el parametro c o
     * null si no existe
     */
    public NodoArbol getHijo(char c){
        NodoArbol tmp;
        Iterator it=hijos.iterator();
        while(it.hasNext()){
            tmp=(NodoArbol)it.next();
            if(tmp.letra==c)
                return tmp;
        }
        return null;
    }
}
