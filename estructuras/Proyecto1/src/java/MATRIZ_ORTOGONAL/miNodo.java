/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package MATRIZ_ORTOGONAL;

/**
 * Clase que representa al nodo que se usa como una empresa
 * @author gerardo
 */
public class miNodo {

    public String nombre,comentario,direccion,telefono,pagina,logo;
    public String categoria,letra;
    
    /**
     * Constructor de miNodo
     * @param nom el nombre de la empresa
     * @param comment la descripcion de la empresa
     * @param dir la direccion de la empresa
     * @param tel el telefono de la empresa
     * @param pag la pagina web de la empresa
     * @param logo el logo de la empresa
     * @param categ la categoria a la que pertenece la empresa
     * @param let la letra a la que pertenece la empresa
     */
    public miNodo(String nom,String comment,String dir,String tel,String pag,String logo,String categ,String let){
        nombre=new String(nom);
        comentario=new String(comment);
        direccion=new String(dir);
        telefono=new String(tel);
        pagina=new String(pag);
        this.logo=new String(logo);
        categoria=new String(categ);
        letra=new String(let);
    }
    
}
