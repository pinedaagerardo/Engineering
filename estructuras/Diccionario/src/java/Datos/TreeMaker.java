/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Datos;

import java.io.FileWriter;
import java.io.PrintWriter;

/**
 *clase que genera un arbol usando graphviz
 * @author gerardo
 */
public class TreeMaker {

    /**escribe en el archivo*/
    private PrintWriter escritor;
    /**es el nombre del archivo*/
    private String archivo;
    /**proceso con que se guarda el grafo y se abre en una pagina web de firefox*/
    private Process p;
    /**dice si ya se inserto la raiz*/
    private Boolean yaHayRaiz=false;
    
    /**
     * constructor de la clase
     * @param nombre el nombre del grafo
     */
    public TreeMaker(String nombre){
        try{
            escritor=new PrintWriter(new FileWriter(nombre));
        }catch(Exception e){}
            escritor.println("digraph "+nombre+"{");
            archivo=nombre; //lo guardo para usarlo con exec
    }
    
    /**
     * escribe la sintaxis de un nodo
     * @param nombre el nombre interno del nodo
     * @param label la etiqueta con que se visualiza el nodo
     * @param nodoPadre el nodo padre del nodo que se esta insertando
     */
    public void insertarNodo(String nombre,String label,String nodoPadre){
        if(nodoPadre==null && !yaHayRaiz){ //es la raiz
            escritor.println("{node[label=\""+label+"\"]}");
            yaHayRaiz=true;
        }
        else{
            if(nodoPadre==null) nodoPadre="/";
            escritor.println("{node[label=\""+label+"\"]\""+nombre+"\";}");
            escritor.println("\""+nodoPadre+"\" -> \""+nombre+"\";");
        }
    }
    
    /**
     * guarda el grafo al disco duro en formato png
     */
    public void guardarGrafo(){
        escritor.print("}");
        escritor.close();
        try{
            p = Runtime.getRuntime().exec("dot "+archivo+" -Tpng -o grafo.png");
            p.waitFor();
        }catch(Exception e){}
    }
    
    /**
     * publica el grafo en una pagina de firefox
     */
    public void publicar(){
        try {
            p.waitFor();
            p = Runtime.getRuntime().exec("firefox grafo.png");
        } catch (Exception e) {}
    }
    
}
