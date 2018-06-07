/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Datos;

import java.io.File;
import java.io.FileInputStream;
import java.io.Serializable;
import java.util.Vector;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

/**
 *bean que sirve de comunicacion entre jsp y java
 * @author gerardo
 */
public class beanArbol implements Serializable {

    /**instancia para poder usar el arbol*/
    MiArbol arbol=new MiArbol();
    /**listado de imagenes del archivo de entrada*/
    Vector imagen;
    /**listado de palabras del archivo de entrada*/
    Vector palabra;
    /**listado de traducciones del archivo de entrada*/
    Vector traduccion;
    
    public beanArbol(){}
    
    /**
     * carga un archivo
     */
    public void abrir(){
        int opcion=1;    
        File archivo=null;
        JFileChooser chooser = new JFileChooser("abrir archivo");
        opcion=chooser.showOpenDialog(null);
        if(opcion==0){
              archivo=chooser.getSelectedFile();
              String nombre =archivo.getPath();
              procesar(nombre);
              importarDatos();
        }else{
             JOptionPane.showMessageDialog(new JFrame(),"No se selecciono ningun archivo para abrir","Error",JOptionPane.ERROR_MESSAGE);
        }
        
    }

    /**
     * procesa el archivo de entrada
     * @param path el archivo de entrada
     */
    private void procesar(String path) {
        miScannerArbol scanner;
        scanner=null;
        miParserArbol parser;
        parser=null;
          try
           {
             //Se crea el scanner para el archivo
             scanner=new miScannerArbol(new FileInputStream(path));
              //Se crea el parser para el archivo
            parser=new miParserArbol(scanner);
                 try
                  {
                      parser.parse();
                 }
                 catch(Exception er)
                 {
                      System.out.println("El Archivo contiene Errores");
                 }
          }
                catch(java.io.FileNotFoundException e1)
          {
                 System.out.println("No se puede crear el Parser porque NO existe el archivo de entrada");
          }
        imagen=parser.action_obj.Vimagen;
        palabra=parser.action_obj.Vpalabra;
        traduccion=parser.action_obj.Vtraduccion;
    }
    
    /**
     * retorna una palabra del archivo de entrada
     * @param indice el indice del vector que se quiere mostrar
     * @return una palabra del archivo de entrada
     */
    public String getPalabra(int indice){
        return palabra.elementAt(indice).toString();
    }
    
    /**
     * retorna una traduccion del archivo de entrada
     * @param indice el indice del vector que se quiere mostrar
     * @return una traduccion del archivo de entrada
     */
    public String getTraduccion(int indice){
        return traduccion.elementAt(indice).toString();
    }
    
    /**
     * retorna un path del archivo de entrada
     * @param indice el indice del vector que se quiere mostrar
     * @return un path del archivo de entrada
     */
    public String getPath(int indice){
        return imagen.elementAt(indice).toString();
    }
    
    /**
     * guarda los datos del archivo de entrada en el arbol
     */
    private void importarDatos(){
        for(int i=0;i<palabra.size();i++){
            arbol.agregarPalabra(getPalabra(i), getTraduccion(i), getPath(i));
        }
        JOptionPane.showMessageDialog(new JFrame(),"Datos guardados","Importar",JOptionPane.INFORMATION_MESSAGE);
    }
    
    /**
     * busca la traduccion de la palabra recibida
     * @param palabra palabra a la que se busca traduccion
     * @return la traduccion de la palabra
     */
    public String buscarTraduccion(String palabra){
        String resultado=arbol.getTraduccion(palabra);
        TreeMaker t=new TreeMaker("miArbol");
        
        if(resultado==null)
            resultado="No existe la palabra o traduccion";
        
        NodoArbol tmp=arbol.raiz.getHijo(palabra.charAt(0));
        if(tmp==null)
            tmp=arbol.raiz;
        arbol.dibujarArbol(tmp, t);
        t.guardarGrafo();
        t.publicar();
        
        return resultado;
    }
    
    /**
     * busca en el arbol la rama que comience con el caracter recibido y dibuja un
     * arbol para mostrarlo en una pagina jsp
     * @param c llave de la rama a buscar
     */
    public void buscarLetra(char c){
        TreeMaker t=new TreeMaker("miArbol");
        NodoArbol tmp;
        if(c=='/')
            tmp=arbol.raiz;
        else
            tmp=arbol.raiz.getHijo(c);
        
        if(tmp==null){
            JOptionPane.showMessageDialog(new JFrame(),"No existe esa rama de datos","Error",JOptionPane.ERROR_MESSAGE);
            return;
        }
        arbol.dibujarArbol(tmp, t);
        t.guardarGrafo();
        t.publicar();
    }
    
    /**
     * elimina una palabra del arbol
     * @param pal la palabra a ser eliminada
     */
    public void eliminarPalabra(String pal){
        arbol.eliminarPalabra(pal);
    }
    
    /**
     * modifica una palabra existente en el arbol
     * @param palabraVieja la palabra a editar
     * @param palabraNueva la nueva palabra
     * @param traduccionNueva la nueva traduccion
     * @param direccionNueva la nueva direccion
     */
    public void modificarPalabra(String palabraVieja,String palabraNueva,String traduccionNueva,String direccionNueva){
        arbol.editar(palabraVieja, palabraNueva, traduccionNueva, direccionNueva);
    }
    
}
