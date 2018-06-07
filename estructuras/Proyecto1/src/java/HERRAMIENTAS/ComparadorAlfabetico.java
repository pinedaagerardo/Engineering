/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package HERRAMIENTAS;

import MATRIZ_ORTOGONAL.*;
import java.util.Comparator;

/**
 * Clase que sirve como comparador. Lo que hace es comparar letra por letra de
 * una palabra y retorna un numero positivo, negativo o cero, dependiendo de
 * cual palabra se encuentra primero tomando en cuenta el orden alfabetico
 * @author gerardo
 */
public class ComparadorAlfabetico implements Comparator{

    /**
     * Este metodo es usado para comparar las palabras recibidas como parametro.
     * Lo que hace es comparar letra por letra de una palabra y retorna un
     * numero positivo, negativo o cero, dependiendo de cual palabra se encuentra
     * primero tomando en cuenta el orden alfabetico
     * @param a es una de las palabras como tipo Object que se quiere comparar
     * para definir el orden. Esta se compara con el parametro b
     * @param b es una de las palabras como tipo Object que se quiere comparar
     * para definir el orden. Esta se compara con el parametro a
     * @return un numero positivo, negativo o cero dependiendo del resultado de
     * la comparacion
     */
    public int compare(Object a, Object b) {
        if(a.getClass().getName().equalsIgnoreCase("MATRIZ_ORTOGONAL.Categoria")){
            for(int i=0;i<((Categoria)a).nombre.length() && i<((Categoria)b).nombre.length();i++){
                if(((Categoria)a).nombre.charAt(i)!=((Categoria)b).nombre.charAt(i)){
                    return (((Categoria)a).nombre.charAt(i)-((Categoria)b).nombre.charAt(i));
                }
            }
            if(((Categoria)a).nombre.length()==((Categoria)b).nombre.length()){
                //JOptionPane.showMessageDialog(null,"ERROR!!!!!!!!!!\nNO PUEDE HABER ELEMENTOS REPETIDOS!! (cat)","ERROR!!",JOptionPane.ERROR_MESSAGE);
                return 0;
            }
            else
                return (((Categoria)a).nombre.length()-((Categoria)b).nombre.length());
        }else{
            if(a.getClass().getName().equalsIgnoreCase("MATRIZ_ORTOGONAL.miNodo")){
                for(int i=0;i<((miNodo)a).nombre.length() && i<((miNodo)b).nombre.length();i++)
                    if(((miNodo)a).nombre.charAt(i)!=((miNodo)b).nombre.charAt(i))
                        return (((miNodo)a).nombre.charAt(i)-((miNodo)b).nombre.charAt(i));
                if(((miNodo)a).nombre.length()==((miNodo)b).nombre.length()){
                    //JOptionPane.showMessageDialog(null,"ERROR!!!!!!!!!!\nNO PUEDE HABER ELEMENTOS REPETIDOS!! (emp)","ERROR!!",JOptionPane.ERROR_MESSAGE);
                    return 0;
                }
                else
                    return (((miNodo)a).nombre.length()-((miNodo)b).nombre.length());
            }else
                if(((Celda)a).letra.compareTo(((Celda)b).letra.charValue())!=0)
                    return ((Celda)a).letra.compareTo(((Celda)b).letra.charValue());
                else{
                    //JOptionPane.showMessageDialog(null,"ERROR!!!!!!!!!!\nNO PUEDE HABER ELEMENTOS REPETIDOS!! (cel)","ERROR!!",JOptionPane.ERROR_MESSAGE);
                    return 0;
                }
        }
    }

}
