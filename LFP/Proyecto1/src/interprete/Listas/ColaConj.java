/*
 * ColaConj.java
 *
 * Created on 26 de septiembre de 2007, 06:43 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package interprete.Listas;

import java.util.Vector;
import javax.swing.JOptionPane;

/**
 * Clase que se encarga de hacer todas las operaciones de un NodoConj (como 
 * insertar,eliminar,etc)
 * @author gerardo
 */
public class ColaConj {
    
    /**Atributo que contiene todos los nodos de la cola*/
    NodoConj tope;
    
    /** Crea una nueva instancia de ColaConj */
    public ColaConj() {
        tope=null;
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

    /** Inserta un NodoConj en la cola
     * @param conjunto es el conjunto que se va a insertar en la cola
     */
    public void push(NodoConj conjunto){
        if(esVacia())
            tope = new NodoConj(conjunto);
        else{
            NodoConj temp=tope;
            while(temp.Siguiente!=null)
                temp=temp.Siguiente;
            temp.Siguiente=new NodoConj(conjunto);
        }
    }

    /** Metodo que retorna el primer nodo
     * @return el nodo que contiene a todos los demas nodos
     * @exception Cola Vacia si la cola esta vacia
     */
    public NodoConj getNodoConj() throws Exception {
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

        tope = tope.Siguiente;
    }
    
    /** Metodo que busca en la cola un conjunto que coincida con el nombre recibido.
     * Cuando lo encuentra, retorna los elementos de ese conjunto como un vector.
     * Si el conjunto no tiene elementos retorna null. usa equalsIgnoreCase()
     * @param nombre el nombre del conjunto a buscar para retornar sus elementos
     * @exception Cola Vacia o no existe - si la cola esta vacia o no existe el
     * conjunto
     * @return los elementos del conjunto a buscar
     */
    public Vector getElementos(String nombre) throws Exception {
        if (esVacia()||!existeConj(nombre))
            throw new Exception("Cola vacia o no existe");

        NodoConj temp=tope;
        boolean encontrada=false;

        while(encontrada==false){
            if(temp.Nombre.equalsIgnoreCase(nombre)) encontrada=true;
            else temp=temp.Siguiente; //es seguro que siempre lo va a encontrar
        }
        return temp.Elementos;
    }
    
    /** Busca un conjunto que su nombre coincida con el nombre recibido. Usa
     * equalsIgnoreCase()
     * @param nombre el nombre del conjunto a buscar
     * @return true si encuentra el conjunto con el nombre recibido, false si no
     * lo encuentra o si la cola esta vacia
     */
    public boolean existeConj(String nombre){
        if(esVacia()) return false;
        NodoConj temp=tope;
        boolean encontrada=false;

        while(encontrada==false){
            if(temp.Nombre.equalsIgnoreCase(nombre)) encontrada=true;
            else{
                if(temp.Siguiente==null) return false;
                temp=temp.Siguiente;
            }
        }
        return true;
    }
    
    /** Busca en un vector de elementos el elemento recibido para ver si existe
     * en el vector. Si existe retorna true, si no false. Se comparan con equalsIgnoreCase().
     * @param elemento el elemento a buscar
     * @param elementos el vector en el que se busca el elemento
     * @return true si lo encuentra, false si no lo encuentra o si el vector esta vacio
     */
    public boolean existeElemento(Object elemento, Vector elementos){
        try{
            for(int i=0;i<elementos.size();i++) //si elementos esta vacio no se ejecuta
                if(elementos.elementAt(i).toString().equalsIgnoreCase(elemento.toString()))
                    return true;
            return false;
        }catch(Exception e){
            return false;
        }
    }
    
    /** Reemplaza los elementos de un NodoConj ya creado en la cola de conjuntos
     * que su nombre coincida con el nombre del NodoConj recibido por los elementos
     * del NodoConj recibido
     * @param conjunto el conjunto que contiene los elementos que se van a sustituir
     * en el NodoConj que tenga un nombre igual al conjunto recibido
     */
    public void reemplazarElementos(NodoConj conjunto){
        NodoConj temp=tope;
        boolean encontrado=false;

        while(!encontrado){
            if(temp.Nombre.equalsIgnoreCase(conjunto.Nombre)) encontrado=true;
            else temp=temp.Siguiente;
        }
        if(!temp.Elementos.isEmpty())
            temp.Elementos.removeAllElements();
        if(!conjunto.Elementos.isEmpty())
            temp.Elementos.addAll(conjunto.Elementos);
    }
    
}
