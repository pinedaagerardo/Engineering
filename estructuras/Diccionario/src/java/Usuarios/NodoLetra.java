/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Usuarios;

import java.util.Iterator;
import java.util.SortedSet;
import java.util.TreeSet;

/**
 *nodo en el que se guardan los usuarios para luego poder guardarlos en orden
 * dentro de TablaUsuarios
 * @author gerardo
 */
public class NodoLetra {

    /**comparador usado para ordenar los datos*/
    private ComparadorUsuario cu;
    /**letra llave*/
    public String letra;
    /**coleccion donde se guardan los usuarios*/
    private SortedSet usuarios;
    
    /**
     * constructor de la clase
     * @param c la letra llave
     */
    public NodoLetra(String c){
        cu=new ComparadorUsuario();
        usuarios=new TreeSet(cu);
        letra=c;
    }

    /**
     * Crea un nuevo usuario. retorna true si guardo el usuario y false si ya
     * existia
     * @param user el identificador del usuario nuevo
     * @param pass la contraseña del usuario
     * @param state el estadp del usuario
     * @return true si guardo el usuario, false si el usuario ya existia
     */
    public boolean crearUsuario(String user, String pass,Character state) {
        return usuarios.add(new NodoUsuario(user,pass,state));
    }
    
    /**
     * Elimina el usuario user. retorna true si fue eliminado o false si no lo
     * encontro.
     * @param user el usuario a eliminar
     * @return true si lo elimino, false si no lo encontro
     */
    public boolean eliminarUsuario(String user){
        NodoUsuario tmp=getUsuario(user);
        if(tmp==null) return false;
        return usuarios.remove(tmp);
    }
    
    /**
     * modifica un usuario existente. Si el usuario no existe retorna false
     * @param Ouser el usuario que se quiere modificar
     * @param Npass nueva contraseña del usuario
     * @param Nstate nuevo estado del usuario
     * @return true si se encontro el usuario, false de lo contrario
     */
    public boolean modificarUsuario(String Ouser,String Npass,Character Nstate){
        NodoUsuario tmp=getUsuario(Ouser);
        if(tmp==null) return false;
        if(Npass!=null) tmp.pass=Npass;
        if(Nstate!=null) tmp.estado=Nstate;
        return true;
    }
    
    /**
     * dice si existe el usuario user en la coleccion actual
     * @param user el id del usuario a buscar
     * @return true si existe, false si no existe en esta coleccion
     */
    public boolean existeUsuario(String user){
        NodoUsuario tmp=getUsuario(user);
        if(tmp==null) return false;
        return true;
    }
    
    /**
     * Busca y retorna el usuario user o null si no existe
     * @param user el identificador del usuario a buscar
     * @return el usuario o false si no lo encuentra
     */
    public NodoUsuario getUsuario(String user){
        if(user==null) return null;
        Iterator it=usuarios.iterator();
        NodoUsuario tmp=null;
        while(it.hasNext()){
            tmp=((NodoUsuario)it.next());
            if(tmp.usuario.equalsIgnoreCase(user))
                return tmp;
        }
        return null;
    }
    
    /**
     * bloquea al usuario user
     * @param user el usuario a bloquear
     */
    public void bloquearUsuario(String user){
        NodoUsuario tmp=getUsuario(user);
        if(tmp==null) return;
        tmp.estado='b';
    }
    
    /**
     * desbloquea al usuario user
     * @param user el usuario a desbloquear
     */
    public void desbloquearUsuario(String user){
        NodoUsuario tmp=getUsuario(user);
        if(tmp==null) return;
        tmp.estado='h';
    }
    
    /**
     * devuelve un iterador que contiene los usuarios del nodo actual
     * @return un iterador con los usuarios del nodo actual
     */
    public Iterator getIterador(){
        return usuarios.iterator();
    }
    
    /**
     * retorna la cantidad de usuarios que tiene
     * @return la cantidad de usuarios que tiene
     */
    public int getSize(){
        return usuarios.size();
    }
    
}
