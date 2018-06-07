/*
 * Tool.java
 *
 * Created on 23 de septiembre de 2007, 10:42 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package Proyecto2;

import Proyecto2.Listas.Cola;
import Proyecto2.Listas.Nodo;
import java.awt.Color;
import java.util.Vector;
import javax.swing.JDialog;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JTextPane;
import javax.swing.text.Style;
import javax.swing.text.StyleConstants;
import javax.swing.text.StyleContext;

/**
 * Esta clase tiene herramientas que sirven para desplegar mensajes, agregar
 * datos a colas, etc.
 * @author gerardo
 */
public class Tool {
    
    /**Instancia de la clase Style que se usa para cambiar las propiedades del texto en el JTextPane*/
    private Style estilo=new StyleContext().addStyle("subrayado",null);
    /**Vector que contiene las variables declaradas*/
    public Vector[] vars=new Vector[2];
    /**Vector que contiene las variables repetidas (se va a mostrar en los errores)*/
    public Vector varsRepetidas=new Vector();
    
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

	/** Metodo que agrega a una cola los parametros recibidos
	 * @param lex El lexema que se quiere agregar
	 * @param tip El tipo del lexema. En caso que el tipo sea error, tambien
         * contiene la descripcion del error
	 * @param lin La linea del archivo de entrada en que se encuentra el
	 * lexema
	 * @param col La columna del archivo de entrada en que comienza el lexema
	 * @param c La cola en que se agregan los datos
	 */
	public void meterEnCola(String lex,String tip,int lin, int col, Cola c){
		c.push(lex,tip,lin,col);
	}
        
        /**Cambia el formato del contenido de un JTextPane recibido
         *@param texto el JTextPane al que se le aplica los cambios
         *@param color el color nuevo que va a tener las letras seleccionadas
         *@param start la posicion desde donde va a comenzar los cambios al texto
         *@param length la cantidad de caracteres que se toman desde la posicion de
         *inicio para aplicar los cambios
         */
        protected void Resaltar(JTextPane texto,Color color,int start,int length){
            StyleConstants.setForeground(estilo,color);
            texto.getStyledDocument().setCharacterAttributes(start,length,estilo,false);
        }
        
        /** Metodo que dice si un token es una letra aceptada por el interprete
	 * @param token Es el token que se quiere analizar
	 * @return True si el token es una letra aceptada, false de lo contrario
	 */
	protected boolean esLetra(char token){
		return (Character.isLetter(token)||token=='_'||token=='$');
	}

        /**dice si el lexema recibido en el rango dado es una lista con valores constantes y variables
         *@param entrada el lexema a verificar
         *@param inicio el inicio del rango
         *@param fin el fin del rango
         */
    protected boolean esListaVI(String entrada, int inicio, int fin) {
        String fragmento=entrada.substring(inicio,fin);
        String[] lexemas;
        if(fragmento.startsWith("(") && fragmento.endsWith(")"))
            fragmento=fragmento.substring(1,fragmento.length()-2);
        else
            return false;
        if(fragmento.length()==0) return false;
        
        if(fragmento.indexOf(",")!=-1){
            lexemas=fragmento.split(",");
            for(int i=0;i<lexemas.length;i++)
                if(!esIdentificador(lexemas[i]) && !esValor(lexemas[i])) return false;
        }else
            if(!esIdentificador(fragmento)) return false;
        
        return true;
    }

    /**dice si el lexema recibido en el rango dado es una lista con variables
     *@param entrada el lexema a verificar
     *@param inicio el inicio del rango
     *@param fin el fin del rango
     */
    protected boolean esListaI(String entrada, int inicio, int fin) {
        String fragmento=entrada.substring(inicio,fin);
        String[] lexemas;
        if(fragmento.startsWith("(") && fragmento.endsWith(")"))
            fragmento=fragmento.substring(1,fragmento.length()-1);
        else
            return false;
        if(fragmento.length()==0) return false;
        
        if(fragmento.indexOf(",")!=-1){
            lexemas=fragmento.split(",");
            for(int i=0;i<lexemas.length;i++)
                if(!esIdentificador(lexemas[i])) return false;
        }else
            if(!esIdentificador(fragmento)) return false;
        
        return true;
    }
    
    /**si el lexema recibido es un identificador retorna true, si no, false
     *@param lexema el lexema a verificar
     *@return si el lexema recibido es un identificador retorna true, si no, false
     */
    protected boolean esIdentificador(String lexema){
        lexema=lexema.trim();
        String aux_var=lexema;
        if(lexema.length()==0) return false;
        int estado=0;
        
        while(lexema.length()>0){
            switch (estado){
                case 0:
                    if(esLetra(lexema.charAt(0))) estado=1;
                    else return false;
                    break;
                case 1:
                    if(!(esLetra(lexema.charAt(0)) || Character.isDigit(lexema.charAt(0)))) return false;
            }
            lexema=lexema.substring(1);
        }
        
        if(vars[0].contains((Object)aux_var)) varsRepetidas.addElement((Object)aux_var);
        else{
            vars[0].addElement((Object)aux_var);
            vars[1].addElement((Object)0);
        }
        return true;
    }
    
    /**dice si el lexema recibido es un valor (numerico) o no
     *@param lexema el lexema a verificar
     *@return true si lexema es un valor (numerico), false de lo contrario
     */
    protected boolean esValor(String lexema){
        lexema=lexema.trim();
        if(lexema.length()==0) return false;
        int estado=0;
        
        while(lexema.length()>0){
            switch (estado){
                case 0:
                    if(Character.isDigit(lexema.charAt(0))) estado=1;
                    else
                        if(lexema.charAt(0)=='.') estado=2;
                        else return false;
                    break;
                case 1:
                    if(lexema.charAt(0)=='.') estado=2;
                    else
                        if(!Character.isDigit(lexema.charAt(0))) return false;
                    break;
                case 2:
                    if(Character.isDigit(lexema.charAt(0))) estado=3;
                    else return false;
                    break;
                case 3:
                    if(!Character.isDigit(lexema.charAt(0))) return false;
            }
            lexema=lexema.substring(1);
        }
        
        return true;
    }
    
}
