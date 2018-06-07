/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package HERRAMIENTAS;

import MATRIZ_ORTOGONAL.*;
import MATRIZ_ORTOGONAL.miNodo;
import java.util.Iterator;
import java.util.SortedSet;
import java.util.TreeSet;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

/**
 * Esta clase contiene todas las operaciones de la matriz que se usan para
 * construir, modificar o destruir la misma
 * @author gerardo
 */
public class Matriz {

    public static SortedSet cat;//,let
    ComparadorAlfabetico ordenAlfabetico;
    public Busqueda buscar;
    
    /**
     * Constructor de Matriz. Instancia las variables necesarias para el funcionamiento
     */
    public Matriz(){
        ordenAlfabetico=new ComparadorAlfabetico();
        cat=new TreeSet(ordenAlfabetico);
        //let=new TreeSet(ordenAlfabetico);
        buscar=new Busqueda();
    }
    
    /**
     * Metodo que sirve para insertar una categoria em la matriz. Si la categoria
     * ya existe no la inserta. Al final retorna la categoria insertada o la
     * encontrada.
     * @param nombre el nombre de la categoria a insertar
     * @return la categoria insertada o, si ya existe, la categoria encontrada
     */
    public Categoria addCategoria(String nombre){
        Categoria cat_tmp=buscar.getCat(nombre, cat);
        if(cat_tmp!=null) return cat_tmp;
        
        Categoria c=new Categoria(nombre);
        cat.add(c);
        return c;
    }
    
    /**
     * Metodo que sirve para editar una categoria ya existente en la matriz
     * @param nombre el nombre actual de la categoria. Sirve para buscar la
     * categoria a editar
     * @param nomNuevo el nombre nuevo que tendra la categoria despues de editarla
     */
    public void editCategoria(String nombre,String nomNuevo){
        if(buscar.getCat(nomNuevo, cat)!=null){
            JOptionPane.showMessageDialog(new JFrame("Error"),"no se puede renombrar porque ya existe una categoria con nombre "+nombre,"Error",JOptionPane.ERROR_MESSAGE);
            return;
        }
        Categoria cat_tmp=buscar.getCat(nombre, cat);
        if(cat_tmp==null){
            JOptionPane.showMessageDialog(new JFrame("Error"),"no existe la categoria "+nombre,"Error",JOptionPane.ERROR_MESSAGE);
            return;
        }
        
        Categoria nuevaCat=addCategoria(nomNuevo);
        nuevaCat.listado=new TreeSet(cat_tmp.listado);//agregue todas las celdas q tenia
        Iterator it=nuevaCat.listado.iterator();
        while(it.hasNext()){
            Celda c_actual=(Celda)it.next();
            c_actual.categoria=new String(nomNuevo);
            fixHLinks(nuevaCat,c_actual);
            Iterator itC=c_actual.empresa.iterator();
            while(itC.hasNext()){
                miNodo emp=(miNodo)itC.next();
                emp.categoria=new String(nomNuevo);//arreglando el nombre nuevo de la categoria
            }
        }
        
        removeCategoria(cat_tmp);
    }
    
   /* public void addLetra(String letra){
        throw new UnsupportedOperationException("no es necesario creo");
        Categoria c=new Categoria(letra);
        let.add(c);
    }*/
    
    /**
     * Metodo que sirve para insertar una celda en una categoria existente.
     * Este metodo es solo de uso interno, o sea que no existe una funcion para
     * el usuario que le permita agregar una celda, esta se construye sola.
     * Al final se retorna la celda agregada o encontrada en caso que ya exista
     * @param categ el nombre de la categoria a la que pertenecera la celda
     * @param letra la letra a la que pertenecera la celda
     * @return la celda recien insertada o, si ya existia, la celda encontrada
     */
    public Celda addCelda(String categ,String letra){
        Celda c_tmp=buscar.getCel(letra, buscar.getCat(categ, cat));
        if(c_tmp!=null) return c_tmp;
        
        Celda c=new Celda(categ,letra.charAt(0));
        METODOaddCelda(c);
        return c;
        /*no se si es necesario esto (ver tambien addLetra y removeLetra)*/
        //METODOaddCelda(c,let,c.letra.toString(),c.categoria);
    }
    
    /**
     * Este metodo es usado por el metodo addCelda, y hace el verdadero proceso
     * de insercion de celdas.
     * @param cel la celda a insertar
     */
    private void METODOaddCelda(Celda cel){

        Categoria cat_actual=buscar.getCat(cel.categoria,cat);
        
        cat_actual.listado.add(cel);
        
        Celda c_siguiente,c_anterior;
        
        Iterator it=cat_actual.listado.iterator();
        
        while(((Celda) it.next()) != cel){}
        c_siguiente=it.hasNext()?(Celda) it.next():null;
        try{
            Celda c_tmp[]=(Celda[])cat_actual.listado.toArray();
            int i;
            for(i=0;c_tmp[i].letra!=cel.letra;i++){}
            Iterator it2=cat_actual.listado.iterator();
            while((c_anterior=(Celda)it2.next()).letra != c_tmp[i-1].letra){}
        }catch(Exception e){c_anterior=null;}
        
        cel.u=c_anterior;
        cel.d=c_siguiente;
        if(c_anterior!=null)
            c_anterior.d=cel;
        if(c_siguiente!=null)
            c_siguiente.u=cel;
        
    fixHLinks(cat_actual,cel);
    
    }
    
    /**
     * Arregla los links horizontales para una celda enviada como parametro
     * @param cat_actual la categoria donde esta la celda que se arreglara
     * @param c_actual la celda nueva. A esta se le arregla los links
     */
    private void fixHLinks(Categoria cat_actual,Celda c_actual){
        Celda c_izq,c_der;
        Iterator der_it=cat.iterator();
        /*situando en categoria actual; siempre lo encuentra*/
        while(((Categoria)der_it.next())!=cat_actual){}
        while(der_it.hasNext()){
            Categoria cat_sig=(Categoria)der_it.next();
            c_der=buscar.getCel(String.valueOf(c_actual.letra), cat_sig);
            if(c_der!=null){
                c_actual.r=c_der;
                c_der.l=c_actual;
                break;
            }
        }
        Object[] cat_tmp=cat.toArray();
        int i;
        for(i=0;((Categoria)cat_tmp[i])!=cat_actual;i++){}//esto siempre lo encuentra
        i--;
        Categoria cat_ant;
        while(i>=0){
            c_izq=buscar.getCel(String.valueOf(c_actual.letra), (Categoria)cat_tmp[i]);
            if(c_izq!=null){
                cat_ant=buscar.getCat(((Categoria)cat_tmp[i]).nombre, cat);
                c_izq=buscar.getCel(String.valueOf(c_actual.letra), cat_ant);
                c_actual.l=c_izq;
                c_izq.r=c_actual;
                break;
            }
            i--;
        }
    }
    
    /**
     * Metodo que sirve para agregar una empresa en una categoria ya existente
     * @param nom el nombre de la empresa
     * @param comment la descripcion de la empresa
     * @param dir la direccion de la empresa
     * @param tel el telefono de la empresa
     * @param pag la pagina web de la empresa
     * @param logo el logo de la empresa
     * @param categ la categoria a la que pertenece la empresa
     * @param let la letra a la que pertenece la empresa
     */
    public void addEmpresa(String nom,String comment,String dir,String tel,String pag,String logo,String categ,String let){
        miNodo emp=new miNodo(nom,comment,dir,tel,pag,logo,categ,let);
    
        Categoria catTmp=buscar.getCat(categ, cat);
        if(catTmp==null){
            JOptionPane.showMessageDialog(new JFrame("Error"),"no existe la categoría "+categ,"Error",JOptionPane.ERROR_MESSAGE);
            return;
        }
        //addCategoria(categ);
        Celda c_actual=addCelda(categ, let);
        
        miNodo emp_temp=buscar.getEmpresa(nom,c_actual.categoria);
        if(emp_temp==null)
            c_actual.empresa.add(emp);
        else
            JOptionPane.showMessageDialog(new JFrame("Error"),"ya existe la empresa "+nom,"Error",JOptionPane.ERROR_MESSAGE);
    }
    
    
    /**
     * Metodo que sirve para editar una empresa ya existente
     * @param nom el nombre actual de la empresa. Esto no se permite editar
     * @param comment la descripcion nueva de la empresa
     * @param dir la direccion nueva de la empresa
     * @param tel el telefono nuevo de la empresa
     * @param pag la pagina web nueva de la empresa
     * @param logo el logo nuevo de la empresa
     * @param categ la categoria a la que pertenece actualmente la empresa.
     * Esto no se permite editar
     */
    public void editEmpresa(String nom,String categ,String comment,String dir,String tel,String pag,String logo){
        miNodo emp_temp=buscar.getEmpresa(nom, categ);
        if(emp_temp==null){
            JOptionPane.showMessageDialog(new JFrame("Error"),"no existe la empresa "+nom+" en la categoria "+categ,"Error",JOptionPane.ERROR_MESSAGE);
            return;
        }
        
        miNodo nuevaE= new miNodo(nom, comment, dir, tel, pag, logo, categ, String.valueOf(nom.charAt(0)));
        Celda c_actual=buscar.getCel(String.valueOf(nom.charAt(0)), buscar.getCat(categ, cat));
        c_actual.empresa.remove(emp_temp);
        c_actual.empresa.add(nuevaE);
    }
    
    /**
     * Metodo que elimina una categoria y todas sus empresas
     * @param nombre el nombre de la categoria a eliminar
     */
    public void removeCategoria(String nombre){
        Categoria cat_actual=buscar.getCat(nombre, cat);
        if(cat_actual==null) JOptionPane.showMessageDialog(new JFrame("Error"),"no existe la categoria "+nombre,"Error",JOptionPane.ERROR_MESSAGE);
        
        Iterator it=cat_actual.listado.iterator();
        while(it.hasNext()){
            Celda c_actual=(Celda)it.next();
            removeEnlaces(c_actual);
            it.remove();
        }
        
        cat.remove(cat_actual);
    }
    
    /**
     * Metodo que elimina una categoria y todas sus empresas
     * @param categ la categoria que se quiere eliminar
     */
    public void removeCategoria(Categoria categ){
        Iterator it=categ.listado.iterator();
        while(it.hasNext()){
            Celda c_actual=(Celda)it.next();
            removeEnlaces(c_actual);
            it.remove();
        }
        
        cat.remove(categ);
    }
    
    /**
     * Metodo que sirve para eliminar una letra de la matriz.
     * Este metodo es para uso interno. (sin uso)
     * @param let la letra que se quiere borrar
     */
    public void removeLetra(String let){
        boolean existe=false;
        Categoria cat_actual;
        Celda c_actual=null;
        Iterator it=cat.iterator();
        
        while(it.hasNext()){
            c_actual=buscar.getCel(let,cat_actual=(Categoria) it.next());
            if(c_actual!=null){
                existe=true;
                removeEnlaces(c_actual);
                cat_actual.listado.remove(c_actual);
            }
        }
        
        if(!existe) JOptionPane.showMessageDialog(new JFrame("Error"),"no existe la fila "+let,"Error",JOptionPane.ERROR_MESSAGE);
    }
    
    /**
     * Metodo que remueve los enlaces de la celda recibida como parametro. Este
     * metodo es usado antes de eliminar una celda.
     * Este metodo es para uso interno.
     * @param c_actual la celda a la que se quitara los enlaces
     */
    private void removeEnlaces(Celda c_actual){
        if(c_actual.u!=null) c_actual.u.d=c_actual.d;
        if(c_actual.d!=null) c_actual.d.u=c_actual.u;
        if(c_actual.r!=null) c_actual.r.l=c_actual.l;
        if(c_actual.l!=null) c_actual.l.r=c_actual.r;
    }
    
    /**
     * Metodo que elimina una celda que coincida con los parametros recibidos.
     * Este metodo es para uso interno.
     * @param categ el nombre de la categoria a la que pertenece la celda
     * @param letra la letra a la que pertenece la celda
     */
    public void removeCelda(String categ,String letra){
        Categoria cat_actual=buscar.getCat(categ, cat);
        Celda c_actual=buscar.getCel(letra, cat_actual);
        
        removeEnlaces(c_actual);
        
        cat_actual.listado.remove(c_actual);
    }
    
    /**
     * Metodo que elimina de la matriz la empresa que coincida con los parametros
     * recibidos
     * @param nombre el nombre de la empresa a eliminar
     * @param categ el nombre de la categoria a la que pertenece la empresa a eliminar
     */
    public void removeEmpresa(String nombre,String categ){
        Categoria cat_actual=buscar.getCat(categ, cat);
        Celda c_actual=buscar.getCel(String.valueOf(nombre.charAt(0)), cat_actual);
        if(c_actual==null) JOptionPane.showMessageDialog(new JFrame("Error"),"(celda) no existe la empresa "+nombre,"Error",JOptionPane.ERROR_MESSAGE);
        
        miNodo emp=buscar.getEmpresa(nombre, c_actual.categoria);
        if(emp==null) JOptionPane.showMessageDialog(new JFrame("Error"),"(empresa) no existe la empresa "+nombre,"Error",JOptionPane.ERROR_MESSAGE);
        
        c_actual.empresa.remove(emp);
        
        if(c_actual.empresa.isEmpty()) removeCelda(c_actual.categoria,c_actual.letra.toString());
    }
    
    /**
     * Metodo que elimina de la matriz la empresa que coincida con los parametros
     * recibidos
     * @param nombre nombre el nombre de la empresa a eliminar
     * @param categ la categoria a la que pertenece la empresa a eliminar
     */
    private void removeEmpresa(String nombre,Categoria categ){
        Celda c_actual=buscar.getCel(String.valueOf(nombre.charAt(0)), categ);
        if(c_actual==null) JOptionPane.showMessageDialog(new JFrame("Error"),"no existe la empresa "+nombre,"Error",JOptionPane.ERROR_MESSAGE);
        
        miNodo emp=buscar.getEmpresa(nombre, c_actual.categoria);
        if(emp==null) JOptionPane.showMessageDialog(new JFrame("Error"),"no existe la empresa "+nombre,"Error",JOptionPane.ERROR_MESSAGE);
        
        c_actual.empresa.remove(emp);
        
        if(c_actual.empresa.isEmpty()) removeCelda(c_actual.categoria,c_actual.letra.toString());
    }
    
    public void getCategorias(javax.swing.JComboBox cC){
        Iterator it=cat.iterator();
        while(it.hasNext())
            cC.addItem(((Categoria)it.next()).nombre);
    }
    
    public void getEmpresas(String categoria,javax.swing.JComboBox cE){
        Categoria cat_actual=buscar.getCat(categoria, cat);
        Iterator it=cat_actual.listado.iterator();
        while(it.hasNext()){
            Iterator it2=((Celda)it.next()).empresa.iterator();
            while(it2.hasNext())
                cE.addItem(((miNodo)it2.next()).nombre);
        }
    }
}
