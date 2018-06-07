/*
 * controlCasilla.java
 *
 * Created on 16 de mayo de 2007, 11:32 AM
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
public class controlCasilla {
    private Casilla primera,espejoC;
    
    /** Creates a new instance of controlCasilla */
    public controlCasilla() {
        primera=null;
        espejoC=null;
    }
    
    public Casilla primera(){
        return primera;
    }
    
    public boolean estaVacia(){
        return primera==null;
    }
    
    public void addCasilla(Casilla cas,ImageIcon i){
        if(estaVacia()){
            primera=new Casilla(cas.columna,cas.fila,cas.etiqueta,cas.penalizacion,cas.cantidad,i,cas.nombre);
            espejoC=primera;
        }
        Casilla temp;
        for(temp=primera;temp.sig!=null;temp=temp.sig){}
        temp.sig=new Casilla(cas.columna,cas.fila,cas.etiqueta,cas.penalizacion,cas.cantidad,i,cas.nombre);
        espejoC=primera;
    }
    
    public void borrarTodas(){
        primera=null;
        espejoC=null;
    }

    void crearPila(int total) {
        Casilla pila=null;
        
        while(primera.sig!=null){
            primera=primera.sig;
            pila=new Casilla(primera.columna,primera.fila,primera.etiqueta,primera.penalizacion,primera.cantidad,primera.getIcon(),total--,pila);
        }
        primera=new Casilla(pila.columna,pila.fila,pila.etiqueta,pila.penalizacion,pila.cantidad,pila.getIcon(),pila.nombre,pila.sig);
    }
    
}
