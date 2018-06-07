/*
 * Archivo.java
 *
 * Created on 31 de octubre de 2007, 11:37 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package Proyecto2;

import Proyecto2.Listas.Cola;
import java.awt.FileDialog;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.PrintWriter;
import java.util.Vector;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JTextPane;

/**
 * Clase que se encarga del manejo de archivos
 * @author gerardo
 */
public class MArchivo {
    
    private Tool tools=new Tool();
    
    /** Crea una nueva instancia de Archivo */
    public MArchivo() {
    }
    
    /** Metodo que sirve para cargar un archivo.
     * Retorna el archivo.
     * Si sucede un error, lanza un mensaje de error de carga.
     * @param frame El frame al que pertenece el dialogo para abrir el archivo.
     * @param text El JTextPane donde se va a mostrar el archivo de entrada
     * @return El archivo a cargar o null si no se carga el archivo.
     */
    protected File abrir(JFrame frame,JTextPane text) {
        File varArchivo;
        try{
            FileDialog dlg = new FileDialog(frame, "Abrir archivo", FileDialog.LOAD);            
            dlg.setVisible(true);
            if (dlg.getFile() == null) return null;
            varArchivo = new File(dlg.getDirectory() + dlg.getFile());
            frame.setTitle("Proyecto2   - "+varArchivo.getName());
            //mostrarArchivo(frame,text,varArchivo);
            return varArchivo;
        }catch(Exception e) {
            tools.mensaje(frame,e,"Error de carga","Error",JOptionPane.ERROR_MESSAGE);
            return null;
        }
    }
    
    /**genera el archivo final
     *@param cola es la cola con datos sin errores
     *@param colaErr es la cola con datos con errores
     *@param vars es un vector que contiene las variables
     *@param varsRep es un vector que contiene las variables repetidas
     */
    protected void GenerarArchivo(JFrame frame,Cola cola,Cola colaErr,Vector[] vars,Vector varsRep){
        String NombreArchivo;
        try{
            FileDialog dlg = new FileDialog(frame, "Generar", FileDialog.SAVE);
            dlg.setVisible(true);
            if(dlg.getFile() == null) return;
            NombreArchivo = dlg.getDirectory() + dlg.getFile()+".txt";
            PrintWriter out = new PrintWriter(new FileWriter(NombreArchivo));
            
            /*comienza escritura y operaciones*/
            while(!cola.esVacia()){
                if(cola.getNodo().tipo.equalsIgnoreCase("comentario"))
                    out.write(cola.getNodo().lexema);
                else{
                    String tmp=Operar(cola.getNodo().lexema,vars);
                    if(!tmp.equalsIgnoreCase("error"))
                        out.write(tmp);
                    else
                        colaErr.push(tmp,"error",cola.getNodo().linea,cola.getNodo().columna);
                }
                cola.pop();
            }
            out.println();out.println();
            out.println("/*********************************************/");
            out.println("ERRORES:");
            while(!colaErr.esVacia()){
                out.println(colaErr.getNodo().lexema+" - Operacion erronea");
                colaErr.pop();
            }
            while(!varsRep.isEmpty()){
                out.println(varsRep.firstElement().toString()+" - Variable repetida");
                varsRep.removeElementAt(0);
            }
            /*termina escritura y operaciones*/
            
            out.close();
        }catch(Exception e){
            
        }
    }
    
    /** Metodo que muestra el archivo de entrada en el JTextPane recibido como
         * parametro
         * @param frame la ventana donde se mostraria un mensaje de error si
         * llegara a ocurrir
         * @param text el JTextPane donde se va a mostrar el archivo de entrada
         * @param archivoEntrada el archivo de entrada que se quiere mostrar en
         * el JTextPane recibido
         */
        private void mostrarArchivo(JFrame frame,JTextPane text,File archivoEntrada){
            try{
                text.setText("");
                BufferedReader lector=new BufferedReader(new FileReader(archivoEntrada));
                String var;
                while( (var=lector.readLine())!=null ) text.setText(text.getText()+"\n"+var);
                lector.close();
            }catch(Exception e){
                tools.mensaje(frame,e,"Error de lectura","Error",JOptionPane.ERROR_MESSAGE);
            }
        }

        /**opera la expresion recibida y retorna el resultado. En caso que diera error, retorna error
         *
         */
    private String Operar(String lexema,Vector[] vars) {
        return "OPERACION";
    }
    
}
