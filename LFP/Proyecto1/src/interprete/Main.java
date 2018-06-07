/*
 * Main.java
 *
 * Created on 23 de septiembre de 2007, 10:08 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package interprete;

/**
 *
 * @author gerardo
 */
public class Main {
    
    /** Crea una nueva instancia de Main */
    public Main() {
    }
    
    /**
     * @param args los argumentos de la linea de comandos
     */
    public static void main(String[] args) {
        IGrafica compilador=new IGrafica();
        compilador.setVisible(true);
    }
    
}
