/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Datos;

import java.util.Comparator;

/**
 * Clase que sirve como comparador. Lo que hace es comparar letra por letra de
 * la palabra de un nodo y retorna un numero positivo, negativo o cero, dependiendo de
 * cual palabra se encuentra primero tomando en cuenta el orden alfabetico
 * @author gerardo
 */
public class ComparadorNodoArbol implements Comparator{

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
    @Override
    public int compare(Object aa, Object bb) {
        char a=((NodoArbol)aa).letra;
        char b=((NodoArbol)bb).letra;
        /*en este ciclo va comparando letra por letra y cuando encuentra una
         diferente de la otra las resta (como char) y retorna el resultado que
         seria un numero positivo o negativo*/
        if(a!=b)
            return (a-b);
        /*si no se retorno nada en el ciclo se retorna 0 si la longitud es la
         misma, o sea si las palabras son iguales*/
        else
            return 0;
    }

}
