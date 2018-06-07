/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Datos;

import java.util.Iterator;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

/**
 *clase que se encarga de crear, modificar o eliminar el arbol
 * @author gerardo
 */
public class MiArbol {

    /**Es la raiz del arbol*/
    NodoArbol raiz;
    
    /**
     * constructor de la clase
     */
    public MiArbol(){
        raiz=new NodoArbol('/',0);
    }
    
    /**
     * Metodo que busca la palabra recibida y devuelve el nodo completo de la
     * palabra; si no la encuentra devuelve null.
     * @param palabra la palabra en el nodo a buscar
     * @return el nodo donde esta la palabra. null si no la encuentra en el arbol.
     */
    public NodoArbol getNodo(String palabra){
        if(palabra.equals("/")) return raiz;
        if(raiz.hijos.size()==0) return null;
        NodoArbol tmp=raiz;
        for(int i=0;i<palabra.length();i++){
            tmp=tmp.getHijo(palabra.charAt(i));
            if(tmp==null)
                return null;
        }
        return tmp;
    }
    
    /**
     * busca la traduccion de la palabra recibida y devuelve la traduccion o null
     * si no existe la palabra en el arbol o la traduccion es " " que significa
     * que no se ingreso traduccion al ingresar la palabra
     * @param palabra la palabra a traducir
     * @return la traduccion de palabra o null si no se encontro en el arbol
     */
    public String getTraduccion(String palabra){
        NodoArbol tmp=getNodo(palabra);
        if(tmp!=null && tmp.traduccion!=null && !tmp.traduccion.equals(" "))
            return tmp.traduccion;
        else
            return null;
    }
    
    /**
     * retorna la direccion de la imagen o null si no existe.
     * @param palabra la palabra asociada con la imagen
     * @return la direccion de la imagen
     */
    public String getPath(String palabra){
        NodoArbol tmp=getNodo(palabra);
        if(tmp!=null)
            return tmp.path;
        else
            return null;
    }
    
    /**
     * Agrega una palabra al arbol
     * @param palabra la palabra que se agrega al arbol
     * @param traduccion la traduccion de la palabra
     */
    public void agregarPalabra(String palabra,String traduccion,String direccion){
        NodoArbol tmp=raiz,tmp2 = null;
        for(int i=0;i<palabra.length();i++){
            tmp2=tmp.getHijo(palabra.charAt(i));
            if(tmp2==null){
                tmp.insertarHijo(i,palabra, traduccion,direccion);
                break;
            }
            else
                tmp=tmp2;
        }
        if(tmp2!=null)
            JOptionPane.showMessageDialog(new JFrame(),"El dato ya existe","Error",JOptionPane.ERROR_MESSAGE);
    }
    
    /**
     * Borra del arbol la palabra recibida como parametro
     * @param palabra la palabra a borrar
     */
    public void eliminarPalabra(String palabra){
        NodoArbol tmp=getNodo(palabra);
        if(tmp==null){
            JOptionPane.showMessageDialog(new JFrame(),"No se encontro la palabra","Error",JOptionPane.ERROR_MESSAGE);
            return;
        }
        if(tmp.hijos.size()!=0)
            tmp.traduccion=null;
        else{
            while(tmp.padre.hijos.size()<=1 && tmp.padre.traduccion==null && tmp.padre.profundidad>0){
                tmp=tmp.padre;
                tmp.borrarHijo((NodoArbol)tmp.hijos.first());
            }
            NodoArbol Ptmp=tmp.padre;
            Ptmp.borrarHijo(tmp);
        }
    }
    
    /**
     * Cambia la palabra recibida pvieja por la nueva palabra pnueva y si se le
     * da una nueva traduccion, se le asocia, de lo contrario se le asigna la
     * traduccion anterior
     * @param pvieja la palabra a editar
     * @param pnueva la nueva palabra
     * @param tnueva la traduccion nueva
     */
    public void editar(String pvieja,String pnueva,String tnueva,String dnueva){
        if(tnueva==null)
            tnueva=getTraduccion(pvieja);
        if(dnueva==null)
            dnueva=getPath(pvieja);
        
        eliminarPalabra(pvieja);
        agregarPalabra(pnueva,tnueva,dnueva);
    }
    
    /**
     * dibuja un arbol o subarbol haciendo un recorrido por el mismo
     * @param raiz el nodo que actua como raiz en el arbol o subarbol a dibujarse
     */
    public void dibujarArbol(NodoArbol raiz,TreeMaker t){
        if(raiz.padre==null)
            t.insertarNodo(raiz.palabra, String.valueOf(raiz.letra), null);
        else
            t.insertarNodo(raiz.palabra, String.valueOf(raiz.letra), raiz.padre.palabra);
        
        if(raiz.traduccion!=null && !raiz.traduccion.equals(" "))
            t.insertarNodo(raiz.traduccion, raiz.traduccion, raiz.palabra);
        
        Iterator it=raiz.hijos.iterator();
        while(it.hasNext()){
            dibujarArbol((NodoArbol)it.next(),t);
        }
    }
    
}
