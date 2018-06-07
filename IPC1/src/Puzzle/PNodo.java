/*
 * PNodo.java
 *
 * Created on 25 de abril de 2007, 07:46 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package Puzzle;

/**
 *
 * @author ONIXX
 */
public class PNodo {
    public byte Numero;
    public PNodo Psiguiente;
    
    /** Crea un PNodo */
    public PNodo(byte num, PNodo sgte)
    {
        this.Numero = num;
        this.Psiguiente = sgte; 
    }    
    
    /** Crea un PNodo con Psiguiente=null*/
    public PNodo(byte num)
    {
        this(num,null);    
    }

}
