/*
 * Operacion.java
 *
 * Created on 27 de septiembre de 2007, 12:30 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package interprete;

import interprete.Listas.ColaConj;
import java.io.File;
import java.io.FileWriter;
import java.util.Vector;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

/**
 * Clase que contiene los metodos de las operaciones entre conjuntos
 * @author gerardo
 */
public class Calculador {
    
    /**Atributo tipo Tool*/
    Tool tools=new Tool();
    
    /** Crea una nueva instancia de Operacion */
    public Calculador() {
    }
    
    /** Escribe los resultados recibidos en el archivo de salida recibido.
     * @param resultados es un vector con los conjuntos que se tienen que escribir en
     * el archivo se salida
     * @param archivoSalida el nombre del archivo en donde se tiene que escribir los resultados
     * @param conjuntos es la cola de todos los conjuntos de donde se sacan los conjuntos que
     * se van a escribir en el archivo de salida
     * @param frame el frame al que pertenece el dialogo
     */
    protected void Escribir(Vector resultados, String archivoSalida, ColaConj conjuntos,JFrame frame){
        /**La ruta con el nombre del archivo de salida*/
        File rutaArchivoSalida;
        try{
            rutaArchivoSalida = new File("c:\\"+archivoSalida);
            
            /*escribiendo*/
            FileWriter escritor=new FileWriter(rutaArchivoSalida);
            
            for(int m=0;m<resultados.size();m++){
                escritor.write(resultados.elementAt(m).toString()+" = { ");
                for(int n=0;n<conjuntos.getElementos((String) resultados.elementAt(m)).size();n++){
                    if(n>0) escritor.write(", ");
                    escritor.write(conjuntos.getElementos((String) resultados.elementAt(m)).elementAt(n).toString());
                }
                if(m!=resultados.size()-1) escritor.write(" }    ");
                else escritor.write(" }");
            }
            escritor.close(); //guardando
            
        }catch(Exception e) {
            tools.mensaje(frame,e,"Error de seleccion de ruta","Error",JOptionPane.ERROR_MESSAGE);
        }
    }
    
    /** Hace una union entre los vectores recibidos. Lo que retorna seria el vector1 donde:
     * vector1=(vector1) union (vector2).
     * @param vector1 el primer vector en la operacion
     * @param vector2 el segundo vector en la operacion
     * @return el vector1 que contiene el resultado de hacer: (vector1) union (vector2)
     */
    public Vector Union(Vector vector1, Vector vector2){
        Vector v1=(Vector)vector1.clone(),v2=(Vector)vector2.clone();
        ColaConj tmp= new ColaConj();
        for(int i=0;i<v2.size();i++) //si el vector2 esta vacio, no se ejecuta
            if(!tmp.existeElemento(v2.elementAt(i),v1))
                v1.addElement(v2.elementAt(i));
        
        return v1;
    }
    
    /** Retorna un vector que contiene el resultado de la diferencia simetrica entre
     * los dos vectores recibidos
     * @param vector1 el primer vector en la operacion
     * @param vector2 el segundo vector en la operacion
     * @return la diferencia simetrica entre los vectores recibidos como un vector
     */
    public Vector diferenciaSimetrica(Vector vector1, Vector vector2){
        Vector v1=(Vector)vector1.clone(),v2=(Vector)vector2.clone();
        Vector resultado;
        try{
            resultado=new Vector( Union( Diferencia(v1,v2),Diferencia(v2,v1) ) );
            return resultado;
        }catch(Exception e){
            return resultado=new Vector();
        }
    }
    
    /** Retorna un vector que contiene el resultado de la interseccion entre
     * los dos vectores recibidos
     * @param vector1 el primer vector en la operacion
     * @param vector2 el segundo vector en la operacion
     * @return la interseccion entre los vectores recibidos como un vector
     */
    public Vector Interseccion(Vector vector1, Vector vector2){
        Vector v1=(Vector)vector1.clone(),v2=(Vector)vector2.clone();
        if(!v1.isEmpty() && !v2.isEmpty()){
            v1.retainAll(v2);
            return v1;
        }
        else{
            v1.removeAllElements();
            return v1;
        }
    }
    
    /** Retorna un vector que contiene el resultado de la diferencia entre
     * los dos vectores recibidos
     * @param vector1 el primer vector en la operacion
     * @param vector2 el segundo vector en la operacion
     * @return la diferencia entre los vectores recibidos como un vector
     */
    public Vector Diferencia(Vector vector1, Vector vector2){
        Vector v1=(Vector)vector1.clone(),v2=(Vector)vector2.clone();
        if(!v1.isEmpty() && !v2.isEmpty())
            v1.removeAll(v2);
        return v1;
    }
    
    /**Retorna el complemento del conjunto recibido y el universo recibido
     * @param vector el vector al que se va a aplicar la operacion complemento
     * @param U el universo para poder hacer el complemento
     * @return un vector que contiene el resultado de la operacion complemento
     * aplicado a vector con el universo U
     */
    public Vector Complemento(Vector vector, Vector U){
        Vector tmp_U=(Vector)U.clone();
        tmp_U.removeAll(vector);
        return tmp_U;
    }
    
}
