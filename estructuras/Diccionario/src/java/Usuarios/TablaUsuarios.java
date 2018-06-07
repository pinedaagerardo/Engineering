/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Usuarios;

import java.util.Iterator;
import java.util.SortedSet;
import java.util.TreeSet;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

/**
 *clase que simula una tabla donde se almacenan los usuarios
 * @author gerardo
 */
public class TablaUsuarios {

    /**comparador usado para ordenar los datos*/
    private ComparadorUsuario cu;
    /**coleccion donde se guardan los usuarios*/
    private SortedSet letra;
    
    /**
     * constructor de la clase
     */
    public TablaUsuarios(){
        cu=new ComparadorUsuario();
        letra=new TreeSet(cu);
    }
    
    /**
     * Crea un usuario nuevo.
     * @param user el identificador del usuario nuevo
     * @param pass la contraseña del usuario
     * @param state el estado del usuario
     */
    public void crearUsuario(String user,String pass,Character state){
        letra.add(new NodoLetra(String.valueOf(user.charAt(0))));
        NodoLetra tmp=getNodoLetra(String.valueOf(user.charAt(0)));
        if(!tmp.crearUsuario(user,pass,state))
            JOptionPane.showMessageDialog(new JFrame(), "El usuario "+user+" ya existe","Error",JOptionPane.ERROR_MESSAGE);
    }
    
    /**
     * elimina un usuario. Si el nodo queda vacio despues de la eliminacion, el
     * nodo es borrado
     * @param user el usuario a eliminar
     */
    public void eliminarUsuario(String user){
        NodoLetra tmp=getNodoLetra(String.valueOf(user.charAt(0)));
        if(tmp==null || !tmp.eliminarUsuario(user)){
            JOptionPane.showMessageDialog(new JFrame(), "El usuario "+user+" no existe y no se puede eliminar","Error",JOptionPane.ERROR_MESSAGE);
            return;
        }
        if(tmp.getSize()==0)
            letra.remove(tmp);
    }
    
    /**
     * modifica un usuario existente si el id no es cambiado; si el id es cambiado
     * se elimina el usuario existente y se crea uno nuevo con los datos nuevos
     * para que quede en el nodo correcto
     * @param Ouser el id del usuario a modificar
     * @param Nuser el nuevo id
     * @param Npass la nueva contraseña
     * @param Nstate el nuevo estado
     */
    public void modificarUsuario(String Ouser,String Nuser,String Npass,Character Nstate){
        NodoLetra O=getNodoLetra(String.valueOf(Ouser.charAt(0)));
        if(O==null){
            JOptionPane.showMessageDialog(new JFrame(), "El usuario "+Ouser+" no se puede editar porque no existe","Error",JOptionPane.ERROR_MESSAGE);
            return;
        }
        if(Nuser==null){
            O.modificarUsuario(Ouser, Npass, Nstate);
            return;
        }
        if(!O.existeUsuario(Ouser)){
            JOptionPane.showMessageDialog(new JFrame(), "El usuario "+Ouser+" no se puede editar porque no existe","Error",JOptionPane.ERROR_MESSAGE);
            return;
        }
        
        NodoLetra N=getNodoLetra(String.valueOf(Nuser.charAt(0)));
        if(N==null){
            letra.add(new NodoLetra(String.valueOf(Nuser.charAt(0))));
            N=getNodoLetra(String.valueOf(Nuser.charAt(0)));
        }
        if(N.existeUsuario(Nuser)){
            JOptionPane.showMessageDialog(new JFrame(), "Ya existe un usuario con el identificador "+Nuser,"Error",JOptionPane.ERROR_MESSAGE);
            return;
        }
        NodoUsuario Ousr=O.getUsuario(Ouser);
        if(Nstate==null)
            Nstate=Ousr.estado;
        if(Npass==null)
            Npass=Ousr.pass;
        
        O.eliminarUsuario(Ouser);
        N.crearUsuario(Nuser, Npass,Nstate);
    }
    
    /**
     * retorna un nodo de las letras (una coleccion de usuarios que su identificador
     * comienza con la misma letra)
     * @param c la letra del nodo
     * @return el nodo o null si no existe
     */
    public NodoLetra getNodoLetra(String c){
        if(c==null) return null;
        Iterator it=letra.iterator();
        NodoLetra tmp = null;
        while(it.hasNext()){
            tmp=(NodoLetra)it.next();
            if(tmp.letra.charAt(0)==c.charAt(0))
                return tmp;
        }
        return null;
    }
    
    /**
     * muestra los usuarios que tengan el estado c recibido como parametro. Si
     * c es 'H' muestra los usuarios habilitados; si c es 'B' muestra los usuarios
     * bloqueados; si c es '*' muestra todos los usuarios.
     * @param c el estado en que deben estar los usuarios para ser mostrados
     */
    public StringBuffer mostrarUsuarios(Character c){
        StringBuffer s=new StringBuffer();
        if(letra.size()==0) return null;
        
        Iterator itLetra=letra.iterator();
        while(itLetra.hasNext()){
            NodoLetra tmpLetra=(NodoLetra)itLetra.next();
            s.append("\n"+tmpLetra.letra+"\n");
            Iterator itUsuario=tmpLetra.getIterador();
            while(itUsuario.hasNext()){
                NodoUsuario tmpUsuario=(NodoUsuario)itUsuario.next();
                if(tmpUsuario.estado==c || c=='*')
                    s.append(tmpUsuario.usuario+" "+(tmpUsuario.estado=='b'?"Bloqueado":"Habilitado")+"\n");
            }
        }
        return s;
    }
    
    /**
     * devuelve un iterador que contiene los nodos de usuarios
     * @return un iterador que contiene los nodos de usuarios
     */
    public Iterator getIterador(){
        return letra.iterator();
    }
    
    /**
     * bloquea un usuario
     * @param usr el usuario a bloquear
     */
    public void bloquearUsuario(String usr){
        NodoLetra tmp=getNodoLetra(usr);
        tmp.bloquearUsuario(usr);
    }
    
    /**
     * desbloquea un usuario
     * @param usr el usuario a desbloquear
     */
    public void desbloquearUsuario(String usr){
        NodoLetra tmp=getNodoLetra(usr);
        tmp.desbloquearUsuario(usr);
    }
    
}
