/*
 * Automata.java
 *
 * Created on 3 de noviembre de 2007, 11:03 AM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package Proyecto2;

import Proyecto2.Listas.Cola;
import Proyecto2.Listas.Pila;
import java.awt.Color;
import java.awt.HeadlessException;
import java.io.File;
import java.io.FileInputStream;
import java.util.Vector;
import javax.swing.JOptionPane;
import javax.swing.JTextPane;

/**
 * Clase que se encarga de los procedimientos del automata de pila
 * @author gerardo
 */
public class AutomataP {
    
    /**Variable a la que se le asigna el archivo que se va a analizar*/
    private File varArchivo;
    /**Instancia de la clase Tool*/
    protected Tool tools=new Tool();
    /**Instancia de la clase Cola. Contiene todos los lexemas (incluyendo erroneos)*/
    protected Cola instCola=new Cola();
    /**Instancia de la clase Cola. Contiene todos los lexemas erroneos*/
    protected Cola instCola_error=new Cola();
    
    /** Crea una nueva instancia de Automata. Inicializa la variable entrada
     * @param archivo El archivo que se va a analizar
     */
    public AutomataP(File archivo) {
        varArchivo=archivo.getAbsoluteFile();
    }
    
    /**Analiza el archivo y crea una lista (cola) que contiene los lexemas que van a ser analizados. Tambien
     *escribe y modifica el formato en el JTextPane recibido y crea una cola con errores (si hubiera)
     *@param texto El JTextPane al que se va a aplicar cambios en el formato del contenido
     */
    protected boolean Analizar(JTextPane texto){
        tools.vars[0]=new Vector(); tools.vars[1]=new Vector();
        tools.varsRepetidas.removeAllElements();
        tools.Resaltar(texto,Color.BLACK,0,texto.getText().length());//regresando color natural
        instCola_error.vaciar();
        instCola.vaciar();
        texto.setText("");
        Vector[] posicionSubrayado=new Vector[2];
        posicionSubrayado[0]=new Vector();posicionSubrayado[1]=new Vector();//0=pos inicio;1=longitud a subrayar
        
        try{
            FileInputStream lector = new FileInputStream(varArchivo);
            int tmp,pos=0,linea=0;
            char[] token;
            String lexema="";
            boolean esOperacion=true;
            
            while( (tmp=lector.read()) !=-1){
                token=Character.toChars(tmp);
                pos++;
                boolean esLlaveCierre=false;
                
                if(token[0]=='{'){
                    if(lexema.length()>0) tools.meterEnCola(lexema,"comentario",linea,pos-1-lexema.length(),instCola);
                    texto.setText(texto.getText()+lexema);
                    lexema="";
                }
                else
                    if(token[0]=='}'){
                        esLlaveCierre=true;
                        lexema+="}";
                        texto.setText(texto.getText()+lexema);
                        if(lexema.startsWith("{%") && lexema.endsWith("%}")){
                            esOperacion=verificar(lexema);
                            if(esOperacion)
                                tools.meterEnCola(lexema,"operacion",linea,pos-1-lexema.length(),instCola);
                            else
                                tools.meterEnCola(lexema,"error",linea,pos-1-lexema.length(),instCola_error);
                            /*guardando las posiciones para subrayar. le resto el numero de lineas que hay en el
                             momento en que se guarda porque por cada enter la posicion se corre 1 espacio adelante*/
                            posicionSubrayado[0].addElement((Object)(texto.getText().lastIndexOf("{")-linea));
                            posicionSubrayado[1].addElement((Object)(lexema.length()));
                        }else
                            tools.meterEnCola(lexema,"comentario",linea,pos-1-lexema.length(),instCola);
                        lexema="";
                    }
                    else
                        if( (int)token[0]==10 ){//si el caracter es 'enter'
                            linea++;
                            pos=0;
                        }
                    
                if(!esLlaveCierre) lexema+=token[0];
            }
            texto.setText(texto.getText()+lexema);
            tools.meterEnCola(lexema,"comentario",linea,pos-1-lexema.length(),instCola);
            while(posicionSubrayado[0].size()>0){//subrayando
                tools.Resaltar(texto,Color.BLUE,Integer.valueOf(posicionSubrayado[0].firstElement().toString()),Integer.valueOf(posicionSubrayado[1].firstElement().toString()));
                posicionSubrayado[0].remove(0);
                posicionSubrayado[1].remove(0);
            }
            
            lector.close();
        }catch(Exception e){
            tools.mensaje(null,e,"Error de lectura","Error",JOptionPane.ERROR_MESSAGE);
            return false;
        }
        return true;
    }

    /*AUTOMATA*/
    /**verifica que el lexema recibido sea una operacion valida. Retorna el tipo de
     *operacion del lexema y en caso que no sea valido retorna null
     *@param lexema el lexema a analizar
     *@return el tipo de operacion del lexema o null si el lexema es erroneo
     */
    private boolean verificar(String entrada) {
        char estado='i';
        Pila pila=new Pila();
        
        pila.push("#");
        estado='p';
        pila.push("{%B#");//A={%B
        estado='q';
        if(entrada.length()==0) return false;
        while(!pila.getLexema().equals("#")){
            if(pila.primerToken()==entrada.charAt(0) && entrada.charAt(0)=='{'){
                pila.push(pila.Extraer());
                entrada=entrada.substring(1);
                if(entrada.length()==0) return false;
            }else
                if(pila.primerToken()==entrada.charAt(0) && entrada.charAt(0)=='%'){
                    pila.push(pila.Extraer());
                    entrada=entrada.substring(1);
                    if(entrada.length()==0) return false;
                }else
                    if(pila.primerToken()=='B'||pila.primerToken()=='Z'){
                        entrada=entrada.trim();
                        if(entrada.length()==0) return false;
                        
                        if(entrada.startsWith("OPER ")){//tiene que tener un espacio despues de OPER
                            pila.push("C"+pila.Extraer());
                            entrada=entrada.substring(5);
                        }
                        else
                            if(entrada.startsWith("ESCRIBIR")){
                                pila.push("D"+pila.Extraer());
                                entrada=entrada.substring(8);
                            }
                            else
                                if(entrada.startsWith("VAR")){
                                    pila.push("E"+pila.Extraer());
                                    entrada=entrada.substring(3);
                                }else
                                    if(pila.primerToken()=='Z'&&entrada.equals("%}")){
                                        pila.push(pila.Extraer());
                                        entrada=entrada.substring(2);
                                        estado='f';
                                        break;
                                    }else
                                        return false;
                        
                        if(entrada.length()==0) return false;
                    }else
                        if(pila.primerToken()=='C'){
                            String aux="";
                            while(entrada.charAt(0)!=' '){
                                aux+=entrada.charAt(0);
                                entrada=entrada.substring(1);
                                if(entrada.length()==0) return false;
                            }
                            if(!tools.esIdentificador(aux)) return false;
                            entrada=entrada.substring(1);
                            if(entrada.length()==0) return false;
                            pila.push("F"+pila.Extraer());
                        }else
                            if(pila.primerToken()=='D' || pila.primerToken()=='E'){
                                entrada=entrada.trim();
                                if(entrada.length()==0) return false;
                                
                                if(pila.primerToken()=='E'){
                                    if(tools.esListaI(entrada,0,entrada.indexOf(")")+1)){
                                        pila.push("Z"+pila.Extraer());
                                        entrada=entrada.substring(entrada.indexOf(")")+1);
                                    }else
                                        return false;
                                }else
                                    if(tools.esListaVI(entrada,0,entrada.indexOf(")")+1)){
                                        pila.push("Z"+pila.Extraer());
                                        entrada=entrada.substring(entrada.indexOf(")")+1);
                                    }else
                                        return false;
                                
                                if(entrada.length()==0) return false;
                            }else
                                if(pila.primerToken()=='F'){
                                    entrada=entrada.trim();
                                    if(entrada.length()==0) return false;
                                    
                                    if(entrada.startsWith("SUMA") || entrada.startsWith("PROM") || entrada.startsWith("MAX") || entrada.startsWith("MIN") || entrada.startsWith("CONT")){
                                        pila.push("D"+pila.Extraer());
                                        if(entrada.startsWith("MAX")||entrada.startsWith("MIN")) entrada=entrada.substring(3);
                                        else entrada=entrada.substring(4);
                                    }else
                                        return false;
                                    
                                    if(entrada.length()==0) return false;
                                }
        }
        
        return true;
    }
    
}
