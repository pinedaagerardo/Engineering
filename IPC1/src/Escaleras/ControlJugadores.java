/*
 * ControlJugadores.java
 *
 * Created on 8 de mayo de 2007, 08:42 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package Escaleras;

import javax.swing.ImageIcon;
import javax.swing.JOptionPane;

/**
 *
 * @author ONIXX
 */
public class ControlJugadores {
    /**Contiene la cola de todos los Jugadores. Al apuntarle se le está
     * apuntando al primer Jugador.
     */
    private Jugador primero;
    /**Toma el valor de la cola para poder desplazarse por todos los Jugadores
     * y retornar sus propiedades sin afectar la estructura de la cola.
     */
    private Jugador espejo;
    /**contador lleva la cuenta del número de jugadores, y al mismo tiempo le
     * asigna un número a cada jugador.
     */
    byte contador=0;
    
    /** Lleva un control para los jugadores.*/
    public ControlJugadores() {
        primero=null;
        espejo=null;
    }
    
    /** Retorna true si existe por lo menos un jugador ya ingresado a la cola,
     * false de lo contrario.
     */
    public boolean existenJugadores(){
        return !(primero==null);
    }
    
    /** Borra todos los jugadores de la cola y asigna null al espejo*/
    public void borrarTodos(){
        primero=null;
        espejo=null;
    }
    
    /** Ingresa un nuevo jugador a la cola. Retorna true si lo ingresó; si el
     * jugador ya existía y no lo ingresó retorna false. Actualiza el espejo.
     * @Parametros: nombre: el nombre del jugador.
     * @Parametros: casillaInicial: la casilla con que se va a inicializar
     * el jugador (la casilla (tipo Casilla) de inicio del archivo de entrada).
     * @Parametros: icon: el ícono del jugador.
     */
    public boolean nuevoJugador(String nombre,Casilla casillaInicial,ImageIcon icon){
        if(!existenJugadores()){
            primero=new Jugador(nombre,++contador,casillaInicial,icon);
            espejo=primero;
            return true;
        }
        Jugador temp;
        for(temp=primero;temp.Siguiente!=null;temp=temp.Siguiente){}
        if(!esRepetido(nombre)){
            temp.Siguiente=new Jugador(nombre,++contador,casillaInicial,icon);
            espejo=primero;
            return true;
        }else return false;
    }
    
    /** Mueve el espejo al siguiente Jugador de la cola; si el espejo está en el
     * último Jugador, el espejo toma el valor entero de la cola para poder
     * moverse al primer Jugador de la cola. Se usa para cambiar el turno al
     * Jugador siguiente.
     * Si la cola está vacía, no hace nada.
     */
    public void jugadorSiguiente(){
        if(existenJugadores()){
            if(espejo.Siguiente!=null)
                espejo=espejo.Siguiente;
            else
                espejo=primero;
        }
    }
    
    /**Retorna el jugador actual.
     * (retorna el que está apuntando el espejo)
     */
    public Jugador jugadorActual(){
        return espejo;
    }
    
    /**Al invocar, se apunta a toda la cola de Jugadores.
     * Retorna el primer Jugador.
     */
    public Jugador primerJugador(){
        return primero;
    }

    /** Retorna true si encuentra un jugador con el mismo nombre que el
     * parámetro, si no, retorna false. (solo uso interno)
     */
    protected boolean esRepetido(String nombre) {
        for(Jugador tmp=primero;tmp!=null;tmp=tmp.Siguiente)
            if(tmp.Nombre.equalsIgnoreCase(nombre)) return true;
        return false;
    }
    
    /**Retorna la cantidad total de jugadores en la cola.*/
    public byte cantidadJugadores(){
        return contador;
    }
    
}
