/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Usuarios;

/**
 *clase que almacena los datos de los usuarios
 * @author gerardo
 */
public class NodoUsuario {

    /**el identificador del usuario*/
    public String usuario;
    /**la contraseña*/
    public String pass;
    /**el estado del usuario (H=habilitado|B=de baja) */
    public Character estado;
    
    /**
     * constructor de la clase
     * @param user el identificador del usuario
     * @param p la contraseña
     * @param state el estado del usuario (H=habilitado|B=de baja)
     */
    public NodoUsuario(String user,String p,Character state){
        usuario=user;
        pass=p;
        estado=state;
    }
    
    
}
