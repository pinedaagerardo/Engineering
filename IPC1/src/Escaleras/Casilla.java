/*
 * Casilla.java
 *
 * Created on 6 de mayo de 2007, 02:25 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package Escaleras;

import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JLabel;

/**
 *
 * @author ONIXX
 * Es una clase para las casillas del tablero de Escaleras
 */
public class Casilla extends JLabel {
    int fila,columna;
    int cantidad,nombre;
    String penalizacion,etiqueta;
    Casilla sig;
    
    /** Crea una nueva Casilla (cola).
     * @Parametros: fila=f;
     * @Parametros: columna=col;
     * @Parametros: nombre o número de la casilla=nom;
     * @Parametros: cantidad de pasos/tiros por la penalización=cant;
     * @Parametros: penalización (dice si avanza,tira,retrocede,etc)=penal;
     * @Parametros: etiqueta de la penalización=etiq;
     * @Parametros: icono para la casilla=icono;
     */
    public Casilla(int col,int f,String etiq,String penal,int cant,ImageIcon icono,int nom) {
        fila=f;
        columna=col;
        nombre=nom;
        cantidad=cant;
        penalizacion=penal;
        etiqueta=etiq;
        this.setIcon(icono);
        sig=null;
    }
    
    public Casilla(int col,int f,String etiq,String penal,int cant,Icon icono,int nom,Casilla siguiente) {
        fila=f;
        columna=col;
        nombre=nom;
        cantidad=cant;
        penalizacion=penal;
        etiqueta=etiq;
        this.setIcon(icono);
        sig=siguiente;
    }
    
}
