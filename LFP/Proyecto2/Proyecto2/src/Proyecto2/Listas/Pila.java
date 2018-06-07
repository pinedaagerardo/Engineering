/*
 * Pila.java
 *
 * Created on 4 de noviembre de 2007, 05:26 AM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package Proyecto2.Listas;

/**
 *Clase que sirve para almacenar datos en forma de una pila. Es usada para definir un lexema.
 * @author gerardo
 */
public class Pila {
    
    /**Variable que contiene los datos de la pila*/
    private Nodo tope;
    
    /** Crea una nueva instancia de Pila */
    public Pila() {
        tope=null;
    }
    
    /**Inserta un lexema en la pila
     *@param lexema el lexema a insertar
     */
    public void push(String lexema){
        if(tope==null) tope=new Nodo(lexema,null,0,0,0);
        else
            tope=new Nodo(lexema,null,0,0,0,tope);
    }
    
    /**Devuelve el lexema del tope de la pila
     *@return el lexema del tope de la pila
     */
    public String getLexema(){
        if(tope!=null) return tope.lexema;
        else return null;
    }
    
    /**extrae el primer caracter del lexema del tope y retorna lo que queda
     *@return lo que queda en el lexema del tope
     */
    public String Extraer(){
        if(tope==null) return null;
        if(tope.lexema.length()>0) return tope.lexema.substring(1);
        else return null;
    }
    
    /**vacia la pila*/
    public void Vaciar(){
        tope=null;
    }
    
    /**retorna true si la pila esta vacia, false de lo contrario
     *@return true si la pila esta vacia, false de lo contrario
     */
    public boolean estaVacia(){
        return tope==null;
    }

    /**Retorna el primer caracter del lexema
     *@return el primer caracter del lexema
     */
    public char primerToken() {
        if(tope==null || tope.lexema.length()==0) return '-';
        return tope.lexema.charAt(0);
    }
    
}
