/*
 * Cola.java
 *
 * Created on 23 de septiembre de 2007, 10:30 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package interprete.Listas;

/**
 * Clase que usa Nodos para construir una lista enlazada con los datos del
 * archivo de entrada
 * @author gerardo
 */
public class Cola {
    
    /**Atributo que contiene todos los nodos de la cola*/
    private Nodo tope; //es la cabeza.
    /**Un contador para saber cuantos nodos se han ingresado a la cola*/
    private int contador=0; //lleva la cuenta de los nodos en la cola.
    
    /** Crea una nueva instancia de Cola */
    public Cola() {
        tope = null;
    }
    
    /** Verifica si la cola esta vacia
     * @return true si la cola esta vacia, si no, false
     */
    public boolean esVacia(){
        return tope == null;
    }

    /** Borra todos los datos de la cola */
    public void vaciar(){
        tope = null;    
    }

    /** Inserta datos en la cola
     * @param lexema El lexema que se va a guardar
     * @param tipo El tipo de dato del lexema
     * @param linea Es el numero de la linea en el archivo donde se localiza
     * el lexema
     * @param columna Es la columna del archivo en donde comienza el lexema
     */
    public void push(String lexema,String tipo, int linea,int columna){
        if(esVacia())
            tope = new Nodo(lexema,tipo,++contador,linea,columna);
        else{
            Nodo temp=tope;
            while(temp.siguiente!=null)
                temp=temp.siguiente;
            temp.siguiente=new Nodo(lexema,tipo,++contador,linea,columna);
        }
    }

    /** Metodo que retorna el primer nodo
     * @return el nodo que contiene a todos los demas nodos
     * @exception Cola Vacia si la cola esta vacia
     */
    public Nodo getNodo() throws Exception {
        if(esVacia())
            throw new Exception("Cola vacia");

        return tope;
    }

    /** Metodo que borra el primer nodo para que el segundo tome su lugar
     * @exception Cola Vacia si la cola esta vacia
     */
    public void pop() throws Exception{
        if(esVacia())
            throw new Exception("Cola vacia");

        tope = tope.siguiente;
    }

    /** Metodo que busca en la cola un nodo que coincida con los parametros
     * recibidos. Cuando lo encuentra, retorna el lexema de ese nodo
     * @param linea entero que debe coincidir con la linea del nodo
     * @param posicion entero que debe coincidir con la linea del nodo
     * @exception Cola Vacia si la cola esta vacia
     * @return el lexema del nodo si lo encuentra, si no retorna null
     */
    public String Buscar(int linea,int posicion) throws Exception {
        if (esVacia())
            throw new Exception("Cola vacia");

        Nodo temp=tope;
        boolean encontrada=false;

        while(encontrada==false){
            if(temp.linea==linea && temp.columna==posicion)
                encontrada=true;
            else{
                if(temp.siguiente==null)
                    return null;
                temp=temp.siguiente;
            }
        }
        return temp.lexema;
    }
    
}
