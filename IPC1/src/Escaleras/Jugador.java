/*
 * Jugador.java
 *
 * Created on 8 de mayo de 2007, 07:24 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package Escaleras;

import javax.swing.ImageIcon;
import javax.swing.JLabel;

/**
 *
 * @author ONIXX
 */
public class Jugador extends JLabel {
    String Nombre;
    Casilla casillaActual;
    int Lanzamientos;
    byte NumeroDeJugador;
    Jugador Siguiente;
    
    /** Crea un nuevo Jugador.
     * @Parametros: nombre: el nombre del jugador.
     * @Parametros: numero_de_jugador: el número de jugador en el orden en que
     * se van ingresando.
     * @Parametros: casillaInicial: la casilla con que se va a inicializar
     * el jugador (la casilla (tipo Casilla) de inicio del archivo de entrada).
     * @Parametros: siguiente: el siguiente jugador (de tipo Jugador).
     * @Parametros: icon: el ícono del jugador.
     */
    public Jugador(String nombre,byte numero_de_jugador,Casilla casillaInicial,Jugador siguiente,ImageIcon icon) {
        Nombre=nombre;
        NumeroDeJugador=numero_de_jugador;
        casillaActual=casillaInicial;
        Lanzamientos=0;
        Siguiente=siguiente;
        this.setIcon(icon);
    }
    
    /** Crea un nuevo Jugador con los mismos parámetros que el otro constructor
     * pero asigna el jugador siguiente como null.
     */
    public Jugador(String nombre,byte numero_de_jugador,Casilla casillaInicial,ImageIcon icon) {
        this(nombre,numero_de_jugador,casillaInicial,null,icon);
    }
    
}
