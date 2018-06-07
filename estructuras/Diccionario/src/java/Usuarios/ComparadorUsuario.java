/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Usuarios;

import java.util.Comparator;

/**
 *Clase que sirve como comparador. Lo que hace es comparar letra por letra de
 * la palabra de un nodo y retorna un numero positivo, negativo o cero, dependiendo de
 * cual palabra se encuentra primero tomando en cuenta el orden alfabetico
 * @author gerardo
 */
public class ComparadorUsuario implements Comparator {

    /**
     * Este metodo es usado para comparar las palabras recibidas como parametro.
     * Lo que hace es comparar letra por letra de la palabra de un nodo y retorna
     * un numero positivo, negativo o cero, dependiendo de cual palabra se encuentra
     * primero tomando en cuenta el orden alfabetico
     * @param aa es uno de los nodos como tipo Object que se quiere comparar
     * para definir el orden. Este se compara con el parametro bb
     * @param bb es uno de los nodos como tipo Object que se quiere comparar
     * para definir el orden. Este se compara con el parametro aa
     * @return un numero positivo, negativo o cero dependiendo del resultado de
     * la comparacion
     */
    public int compare(Object aa, Object bb) {
        Object a=null,b=null;
        if(aa.getClass().getName().equals("Usuarios.NodoUsuario")){
            a=((NodoUsuario)aa).usuario;
            b=((NodoUsuario)bb).usuario;
        }else{
            a=((NodoLetra)aa).letra;
            b=((NodoLetra)bb).letra;
        }
        /*en este ciclo va comparando letra por letra y cuando encuentra una
         diferente de la otra las resta (como char) y retorna el resultado que
         seria un numero positivo o negativo*/
        for(int i=0;i<a.toString().length() && i<b.toString().length();i++){
            if(a.toString().charAt(i)!=b.toString().charAt(i)){
                return (a.toString().charAt(i)-b.toString().charAt(i));
            }
        }
        /*si no se retorno nada en el ciclo se retorna 0 si la longitud es la
         misma, o sea si las palabras son iguales*/
        if(a.toString().length()==b.toString().length()){
            return 0;
        }
        /*si las palabras no son iguales pero las letras son las mismas se
         retorna la diferencia entre la longitud de las cadenas. ej:
         palabra  -  pala
         retorna un numero positivo;
         caza  -  cazador
         retorna un numero negativo.*/
        else
            return (a.toString().length()-b.toString().length());
    }

}
