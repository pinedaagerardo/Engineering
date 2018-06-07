/*
 * Scan.java
 *
 * Created on 23 de septiembre de 2007, 10:48 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package interprete;

import interprete.Listas.Cola;
import interprete.Listas.Nodo;
import java.awt.FileDialog;
import java.io.File;
import java.io.FileInputStream;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JTextArea;

/**
 * Clase que contiene todos los metodos necesarios para hacer un analisis lexico
 * a un documento
 * @author gerardo
 */
public class Scan {
    
    /** Atributo que representa el archivo que se va a analizar con el scanner.*/
    protected File varArchivo;
    
    /** Atributo tipo Cola. En esta cola se agregan los datos sin error */
    public Cola varCola=new Cola();
    
    /** Atributo tipo Cola. En esta cola se agregan los datos con error */
    public Cola varCola_error=new Cola();
    
    /** Atributo tipo Tool */
    private Tool varTool=new Tool();
    
    /** Crea una nueva instancia de Scan */
    public Scan() {
    }
    
    /** Metodo que sirve para cargar un archivo que se va a analizar en el scanner.
     * Retorna un valor boolean dependiendo si se cargo el archivo o no.
     * Si sucede un error, lanza un mensaje de error de carga.
     * @param frame El frame al que pertenece el dialogo para abrir el archivo.
     * @param text El texto donde se va a mostrar el archivo de entrada
     * @return True si se cargo el archivo, de lo contrario False.
     */
    protected boolean abrir(JFrame frame,JTextArea text) {
        try{
            FileDialog dlg = new FileDialog(frame, "Abrir archivo", FileDialog.LOAD);            
            dlg.setVisible(true);
            if (dlg.getFile() == null) return false;
            varArchivo = new File(dlg.getDirectory() + dlg.getFile());
            frame.setTitle("Interprete   - "+varArchivo.getName());
            varTool.mostrarArchivo(frame,text,varArchivo);
            return true;
        }catch(Exception e) {
            varTool.mensaje(frame,e,"Error de carga","Error",JOptionPane.ERROR_MESSAGE);
            return false;
        }
    }

    /** Metodo usado para analizar lexicamente el archivo de entrada. Esta
     * disponible solo cuando se ha escogido un archivo de entrada. Si sucede un
     * error, lanza un mensaje de error de lectura.
     * @param frame El frame al que perteneceria un mensaje de error (si ocurriera).
     */
    protected Nodo analizar(JFrame frame) {
        varCola.vaciar();
        varCola_error.vaciar();
        FileInputStream lector; //lee el archivo
        String lexema="";
        int estado=0;
        int columna=0; //la columna actual en el archivo de entrada.
        int linea=1; //la linea actual en el archivo de entrada.
        int tmp; //toma el valor numerico del caracter leido
        char token[]; //toma el valor transformado a char (tiene que ser array)
        
        try{
            lector = new FileInputStream(varArchivo);
            while( (tmp=lector.read()) !=-1){
                token=Character.toChars(tmp);
                columna++;
                
                /////////////////////////////////
                /* empieza el uso del automata */
                /////////////////////////////////
                
                if(esError(token[0])) estado=-1;
                switch (estado){
                	
                	case 0:
	                	if( esLetra(token[0]) ) estado=2;
		                else
                                	if(Character.isDigit(token[0])) estado=3;
			            	else
			            		if(token[0]=='.') estado=-1;
                	break;
                	
                	case 1:
                		if( !esEspecial(token[0]) ) estado=-1;
                	break;
                	
                	case 2:case 4:
                		if(token[0]=='.'){ //procedimiento para .txt
                			String _tmp=""+token[0];
                			while( (tmp=lector.read()) !=-1){ //busco los siguientes tokens (la extension)
                                                token=Character.toChars(tmp);
            					columna++;
                                                if(!esEspecial(token[0]))
            						_tmp=_tmp+token[0];
            					else{
            						if(!_tmp.equalsIgnoreCase(".txt")) estado=-1;
            						else estado=1;
            						lexema=lexema+_tmp;
            						int _itmp=linea;
				                	linea=funcionEspecial(lexema,estado,linea,columna,token[0]);
				                	if(linea!=_itmp) columna=0;
            						lexema="";
                                                        estado=0;
                                                        break;
            					}
                			}
                			if(tmp==-1){
                				if(!_tmp.equalsIgnoreCase(".txt")) estado=-1;
                				else estado=1;
                				
                				lexema=lexema+_tmp;
                			}
                			token[0]=' ';
                		}
                	break;
                	
                	case 3:
                		if( esLetra(token[0]) ) estado=4;
                		else
                			if(token[0]=='.'){ //procedimiento para .txt
	                			String _tmp=""+token[0];
	                			while( (tmp=lector.read()) !=-1){ //busco los siguientes tokens (la extension)
	            					token=Character.toChars(tmp);
                                                        columna++;
	            					if(!esEspecial(token[0]))
	            						_tmp=_tmp+token[0];
	            					else{
	            						if(!_tmp.equalsIgnoreCase(".txt")) estado=-1;
	            						else estado=1;
	            						lexema=lexema+_tmp;
	            						int _itmp=linea;
					                	linea=funcionEspecial(lexema,estado,linea,columna,token[0]);
					                	if(linea!=_itmp) columna=0;
	            						lexema="";
                                                                estado=0;
                                                                break;
	            					}
	                			}
	                			if(tmp==-1){
	                				if(!_tmp.equalsIgnoreCase(".txt")) estado=-1;
	                				else estado=1;
	                				
	                				lexema=lexema+_tmp;
	                			}
	                			token[0]=' ';
	                		}
                	break;
                }
                if(esEspecial(token[0])){ //los especiales tambien son separadores
                	int _tmp=linea;
                	linea=funcionEspecial(lexema,estado,linea,(tmp==-1)?columna+1:columna,token[0]);
                	if(linea!=_tmp) columna=0;
                	lexema="";
                        estado=0;
            	}
            	else
            		lexema=lexema+token[0];
            }
            lector.close();
            
            linea=funcionEspecial(lexema,estado,linea,columna+1,' ');//para el ultimo lexema (si quedara uno sin guardar)
            
            /////////////////////////////////
            /* termina el uso del automata */
            /////////////////////////////////
            
            return varCola.getNodo();
        }catch(Exception e){
            varTool.mensaje(frame,e,"Error de lectura","Error",JOptionPane.ERROR_MESSAGE);
        }
        return null;
    }

	/** Metodo que dice si un token es especial o no. Los tokens especiales son
	 * los que separan los otros tokens unos de otros y tambien sirven como
	 * operadores.
	 * @param token Es el token que se quiere analizar para saber si es especial
	 * @return True si el token es especial, false si no es especial
	 */
	private boolean esEspecial(char token){
		return (Character.isWhitespace(token)||token=='+'||token=='*'||token=='-'||token=='<'||token=='>'||token=='='||token=='@'||token==','||token=='{'||token=='}'||token==';');//son separadores
	}
	
	/** Metodo que dice si un token es erroneo o no. Si esta en el alfabeto no
	 * es erroneo, si no esta en el alfabeto es erroneo.
	 * @param token Es el token que se quiere analizar para saber si es erroneo
	 * @return True si el token es erroneo, false si no es erroneo
	 */
	private boolean esError(char token){
		return !(esEspecial(token)||esLetra(token)||Character.isDigit(token)||token=='.');
	}
	
	/** Metodo que dice si un lexema es una palabra reservada o no.
	 * @param lex Es el lexema que se quiere analizar para saber si es palabra
	 * reservada
	 * @return True si el lexema es una palabra reservada, false de lo contrario
	 */
	private boolean esReservada(String lex){
		return (lex.equalsIgnoreCase("programa")||lex.equalsIgnoreCase("conjuntos")||lex.equalsIgnoreCase("inicio")||lex.equalsIgnoreCase("resultados")||lex.equalsIgnoreCase("fin")||lex.equalsIgnoreCase("salida"));
	}
	
	/** Metodo que dice si un token es una letra aceptada por el interprete
	 * @param token Es el token que se quiere analizar para saber si es una
	 * letra aceptada por el interprete
	 * @return True si el token es una letra aceptada, false de lo contrario
	 */
	private boolean esLetra(char token){
		return (Character.isLetter(token)||token=='_'||token=='$');
	}
	
	/** Metodo que define el tipo de un lexema y lo agrega a una Cola (si el
	 * lexema no es nulo); despues analiza el token recibido como parametro y le
	 * asigna un tipo y lo agrega a la Cola. Por ultimo, si el token es un
	 * separador de parrafo, retorna linea+1.
	 * @param lexema El lexema a analizar
	 * @param estado El estado actual
	 * @param linea La linea actual en el archivo de entrada
	 * @param columna La columna actual en el archivo de entrada
	 * @param token El token a analizar
	 * @return Si el token no es un separador de parrafo retorna el numero de linea
	 * actual en el archivo de entrada, si es un separador de parrafo retorna
	 * el numero de linea actual mas uno
	 */
	private int funcionEspecial(String lexema,int estado,int linea,int columna,char token){
		if(lexema!=""){
			String _tmp;
			switch(estado){
				case 3: _tmp="NUMERO"; break;
				case 1: _tmp="ARCHIVO"; break;
				case 2: _tmp=(esReservada(lexema))?"RESERVADA":"IDENTIFICADOR"; break;
				default: _tmp="ERROR LEXICO: No se reconoce "+lexema;
			}
			
			varTool.meterEnCola(lexema,_tmp,linea,columna-1-lexema.length(),varCola,varCola_error);
		}
		
		switch (token){
			case '+': varTool.meterEnCola("+","OPERADOR",linea,columna-1,varCola,varCola_error); break;
			case '-': varTool.meterEnCola("-","OPERADOR",linea,columna-1,varCola,varCola_error); break;
			case '*': varTool.meterEnCola("*","OPERADOR",linea,columna-1,varCola,varCola_error); break;
			case '<': varTool.meterEnCola("<","OPERADOR1",linea,columna-1,varCola,varCola_error); break;
			case '>': varTool.meterEnCola(">","OPERADOR2",linea,columna-1,varCola,varCola_error); break;
			case '@': varTool.meterEnCola("@","OPERADOR@",linea,columna-1,varCola,varCola_error); break;
			case '=': varTool.meterEnCola("=","OPERADOR=",linea,columna-1,varCola,varCola_error); break;
			case ',': varTool.meterEnCola(",","OPERADOR,",linea,columna-1,varCola,varCola_error); break;
			case '{': varTool.meterEnCola("{","OPERADOR{",linea,columna-1,varCola,varCola_error); break;
			case '}': varTool.meterEnCola("}","OPERADOR}",linea,columna-1,varCola,varCola_error); break;
			case ';': varTool.meterEnCola(";","OPERADOR;",linea,columna-1,varCola,varCola_error); break;
			default: if( (int)token==10 ) return ++linea;
		}
		return linea;
	}
    
}
