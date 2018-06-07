/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Usuarios;

import java.io.File;
import java.io.FileInputStream;
import java.io.Serializable;
import java.util.Vector;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

/**
 *clase que une jsp con java
 * @author gerardo
 */
public class beanUsuario implements Serializable {

    /**instancia para tener acceso a la tabla de usuarios*/
    public TablaUsuarios tabla=new TablaUsuarios();
    /**listado de palabras del archivo de entrada*/
    Vector usuario;
    /**listado de traducciones del archivo de entrada*/
    Vector clave;
    /**listado de direcciones de imagenes del archivo de entrada*/
    Vector estado;
    
    public beanUsuario(){}
    
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
        miScannerUsuario scanner;
        scanner=null;
        miParserUsuario parser;
        parser=null;
          try
           {
             //Se crea el scanner para el archivo
             scanner=new miScannerUsuario(new FileInputStream(path));
              //Se crea el parser para el archivo
            parser=new miParserUsuario(scanner);
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
        usuario=parser.action_obj.Vusuario;
        clave=parser.action_obj.Vclave;
        estado=parser.action_obj.Vestado;
    }
    
    /**
     * retorna un usuario del archivo de entrada
     * @param indice el indice del vector que se quiere mostrar
     * @return un usuario del archivo de entrada
     */
    public String getUsuario(int indice){
        String s=usuario.elementAt(indice).toString();
        return s.substring(1, s.length()-1);
    }
    
    /**
     * retorna una clave del archivo de entrada
     * @param indice el indice del vector que se quiere mostrar
     * @return una clave del archivo de entrada
     */
    public String getClave(int indice){
        String s=clave.elementAt(indice).toString();
        return s.substring(1, s.length()-1);
    }
    
    /**
     * retorna un estado del archivo de entrada
     * @param indice el indice del vector que se quiere mostrar
     * @return un estado del archivo de entrada
     */
    public Character getEstado(int indice){
        return (estado.elementAt(indice).toString().charAt(1));
    }
    
    /**
     * guarda los datos del archivo de entrada en la tabla de usuarios
     */
    private void importarDatos() {
        for(int i=0;i<usuario.size();i++){
            tabla.crearUsuario(getUsuario(i), getClave(i), getEstado(i));
        }
        JOptionPane.showMessageDialog(new JFrame(),"Datos guardados","Importar",JOptionPane.INFORMATION_MESSAGE);
    }
    
    /**
     * muestra los usuarios que tengan estado st
     * @param st el estado a buscar en un usuario. 0 = 'B'; 1 = 'H'; cualquier otro
     * numero es '*'
     * @return un StringBuffer con todos los datos a mostrar
     */
    public StringBuffer mostrarEstado(Character c){
        return tabla.mostrarUsuarios(c);
    }
    
    /**
     * registra un nuevo usuario y lo pone como habilitado
     * @param nom el nombre de usuario
     * @param cl la clave
     */
    public void registrarUsuario(String nom,String cl){
        tabla.crearUsuario(nom, cl, 'h');
    }
    
    /**
     * bloquea a un usuario
     * @param usr el usuario a bloquear
     */
    public void bloquearUsuario(String usr){
        tabla.bloquearUsuario(usr);
    }
    
    /**
     * desbloquea a un usuario
     * @param usr el usuario a desbloquear
     */
    public void desbloquearUsuario(String usr){
        tabla.desbloquearUsuario(usr);
    }
    
    /**
     * modifica un usuario
     * @param Ousr el id actual
     * @param Nusr nuevo id
     * @param Npass nueva clave
     * @param Nst nuevo estado
     */
    public void modificarUsuario(String Ousr,String Nusr,String Npass,Character Nst){
        tabla.modificarUsuario(Ousr, Nusr, Npass, Nst);
    }
    
}
