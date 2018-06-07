/*
 * cuadro.java
 *
 * Created on 23 de abril de 2007, 04:16 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package Puzzle;

import javax.swing.ImageIcon;
import javax.swing.JLabel;

/**
 *
 * @author ONIXX
 */
public class cuadro extends JLabel {
    /**Indice del icono que contiene */
    public byte iconoActual;
    short x,y;
    
    /** Crea un nuevo cuadro.
     * @Parametros:
     *iconoInicial: índice del icono con el que inicia.
     *x: posición en x.
     *y: posición en y.
     *i: el icono con el que empieza.
     */
    public cuadro(byte iconoInicial,short x,short y,ImageIcon i) {
        this.iconoActual=iconoInicial;
        this.x=x;
        this.y=y;
        this.setIcon(i);
    }
    
    /** Crea un cuadro vacio*/
    public cuadro() {
        
    }
    
}
