/*
 * Tool.java
 *
 * Created on 23 de septiembre de 2007, 10:42 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package interprete;

import interprete.Listas.Cola;
import interprete.Listas.Nodo;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import javax.swing.JDialog;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JTable;
import javax.swing.JTextArea;
import javax.swing.table.DefaultTableModel;

/**
 * Esta clase tiene herramientas que sirven para desplegar mensajes, agregar
 * datos a colas y tablas, etc.
 * @author gerardo
 */
public class Tool {
    
    /** Crea una nueva instancia de Tool */
    public Tool() {
    }
    
    /** Metodo que sirve para mandar un mensaje a la pantalla usando la clase
     * JOptionPane. Muestra como mensaje el parametro ex o el parametro msg si
     * ex es tipo null.
     * <n>
     * @param frame El frame al que pertenece el mensaje.
     * @param ex La excepcion que se muestra como mensaje (en caso de usar try-catch).
     * @param msg El mensaje a mostrar solo en caso que ex sea tipo null.
     * @param titulo El titulo del mensaje.
     * @param tipo El tipo de mensaje que se va a mostrar. Ej: JOptionPane.ERROR_MESSAGE
     */
    public void mensaje(JFrame frame,Exception ex,String msg,String titulo,int tipo) {
        JOptionPane.showMessageDialog(frame,(ex!=null&&ex.getMessage()!=null)?ex.getMessage():msg,titulo,tipo);
    }
    
    /** Metodo que sirve para mostrar un dialogo con una pregunta para que el
     * usuario de una respuesta afirmativa o negativa. Retorna un valor boolean
     * dependiendo de la respuesta del usuario.
     * @param frame El frame al que pertenece el dialogo.
     * @param pregunta La pregunta a mostrar.
     * @param titulo El titulo del mensaje.
     * @return True si el usuario da una respuesta afirmativa, de lo contrario
     * False.
     */
    public boolean preguntar(JFrame frame,String pregunta,String titulo) {
        JOptionPane pane=new JOptionPane(pregunta,JOptionPane.QUESTION_MESSAGE,JOptionPane.YES_NO_OPTION);
        JDialog dialog=pane.createDialog(frame,titulo);
        dialog.setDefaultCloseOperation(dialog.DO_NOTHING_ON_CLOSE);
        dialog.setVisible(true);
        Object s=pane.getValue();
        if(((Integer)s).intValue()==pane.NO_OPTION)return false;
        else return true;
    }

    /** Metodo que sirve para insertar datos de un nodo a una tabla
     * @param nodo El nodo del que se sacan los datos
     * @param tabla_fila El numero de la fila
     * @param tabla La tabla en donde se va a insertar los datos.
     * @param modelo El modelo de la tabla.
     */
    public void meterEnTabla(Nodo nodo, int tabla_fila, JTable tabla,DefaultTableModel modelo) {
        modelo.addRow(new Object[]{tabla_fila,nodo.tipo,nodo.linea,nodo.columna}); //agrega una fila con los parametros recibidos
    }
    
    /** Metodo que invoca el metodo meterEnTabla para desplegar todos los datos
     * del nodo que recibe como parametro
     * @param nodo el nodo del que se sacan los datos para desplegarlos en una
     * tabla
     * @param tabla la tabla en que se va a mostrar los datos
     * @param modelo el modelo de la tabla
     */
     public void mostrarDatos(Nodo nodo, JTable tabla, DefaultTableModel modelo){
     	int i=0;
     	while(nodo!=null){
     		meterEnTabla(nodo,++i,tabla,modelo);
     		nodo=nodo.siguiente;
     	}
     }

    /** Metodo que sirve para limpiar todas las celdas de una tabla.
     * @param tabla La tabla que se va a limpiar
     * @param modelo El modelo de la tabla
     */
    public void limpiarTabla(JTable tabla,DefaultTableModel modelo) {
        modelo.setRowCount(0);
        
        tabla.getColumnModel().getColumn(0).setMinWidth(30);
        
        tabla.getColumnModel().getColumn(1).setMinWidth(400);
        
        tabla.getColumnModel().getColumn(2).setMinWidth(50);
        
        tabla.getColumnModel().getColumn(3).setMinWidth(50);
    }

	/** Metodo que agrega a una cola los parametros recibidos
	 * @param lex El lexema que se quiere agregar
	 * @param tip El tipo del lexema. En caso que el tipo sea error, tambien
         * contiene la descripcion del error
	 * @param lin La linea del archivo de entrada en que se encuentra el
	 * lexema
	 * @param col La columna del archivo de entrada en que comienza el lexema
	 * @param c La cola en que se agregan los datos sin errores
	 * @param c_e La cola en que se agregan los datos con errores
	 */
	public void meterEnCola(String lex,String tip,int lin, int col, Cola c, Cola c_e){
		if(tip.toUpperCase().startsWith("ERROR")) c_e.push(lex,tip,lin,col);
		else c.push(lex,tip,lin,col);
	}
        
        /** Metodo que muestra el archivo de entrada en el texto recibido como
         * parametro
         * @param frame la ventana donde se mostraria un mensaje de error si
         * llegara a ocurrir
         * @param text el texto donde se va a mostrar el archivo de entrada
         * @param archivoEntrada el archivo de entrada que se quiere mostrar en
         * el texto recibido
         */
        public void mostrarArchivo(JFrame frame,JTextArea text,File archivoEntrada){
            try{
                text.setText("");
                BufferedReader lector=new BufferedReader(new FileReader(archivoEntrada));
                String var;
                while( (var=lector.readLine())!=null ) text.append(var+"\n");
            }catch(Exception e){
                mensaje(frame,e,"Error de lectura","Error",JOptionPane.ERROR_MESSAGE);
            }
        }
    
}
