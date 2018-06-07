/*
 * Ppila.java
 *
 * Created on 21 de abril de 2007, 06:45 AM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package Puzzle;
import javax.swing.*;

/**
 *
 * @author ONIXX
 */
public class Ppila {
    private PNodo tope;
    private byte Pcontador=0;
    
    
    /**
     * Crea una nueva Ppila con el fondo o final como Null
     */
        public Ppila( )
        {
            tope = null;    
        }    

        /**
     * Dice si la Ppila est� vacia o no
     */
        public boolean esVacia( )
        {
            return tope == null;
        }

        /**
     * Vac�a la Ppila
     */
        public void vaciar( )
        {
            tope = null;    
        }

        /**
     * Ingresa un nuevo nodo a la Ppila con el valor que se da como par�metro
     */
        public void push(byte numero)
        {
            tope = new PNodo(numero,tope);    
            Pcontador++;
        }

        /**Devuelve el valor del atributo 'Numero' que se ingres� de �ltimo*/
        public byte getNumero( ) throws Exception
        {
            if ( esVacia( ) )    
                throw new Exception("No hay datos");

            return tope.Numero;
        }
        
        /**Elimina el �ltimo nodo ingresado*/
        public void pop( ) throws Exception
        {
            if ( esVacia( ) )
                throw new Exception("No hay datos");

            tope = tope.Psiguiente;
            Pcontador--;
        }
        
        /**Dice si el parametro es repetido o no*/
        public boolean esRepetido(byte numero) {
            if ( esVacia( ) )
                return false;
            
            PNodo temp=tope;

            while(true){
                if(temp.Numero==numero)
                    return true;
                else{
                    if(temp.Psiguiente==null)
                        return false;
                    temp=temp.Psiguiente;
                }
            }
        }

    
}
