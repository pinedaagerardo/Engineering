/*
 * Parse.java
 *
 * Created on 25 de septiembre de 2007, 12:54 PM
 *
 * To change this template, choose Tools | Template Manager
 * and open the template in the editor.
 */

package interprete;

import interprete.Listas.Cola;
import interprete.Listas.ColaConj;
import interprete.Listas.Nodo;
import interprete.Listas.NodoConj;
import java.awt.HeadlessException;
import java.util.Vector;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

/**
 * Clase que contiene todos los metodos necesarios para hacer un analisis
 * sintactico a algun documento.
 * @author gerardo
 */
public class Parse {
    
    /** Atributo que contiene el numero del error que se produjo. -1 significa que no hay error */
    private int num_Error=-1;
    
    /** Atributo tipo Cola. Contiene los errores sintacticos del archivo de entrada */
    public Cola colaError=new Cola();
    
    /** Atributo tipo Tool */
    private Tool tools=new Tool();
    
    /** Atributo usado para saber el estado actual en el archivo de entrada */
    private int estado=0;
    
    /** Atributo usado para guardar el nodo que contiene los datos sin error lexico para no perder
     * datos al hacer busquedas*/
    private Nodo nodo;
    
    /** Atributo que hace busquedas dentro de nodo para que nodo no pierda informacion */
    private Nodo nodo_tmp;
    
    /**Contiene todos los conjuntos y sus elementos que no tienen error*/
    public ColaConj colaConjuntos=new ColaConj();
    
    /** Vector que contiene la union de todos los elementos de todos los conjuntos.*/
    private Vector Universo=new Vector();
    
    /** Atributo tipo calc. Sirve para invocar las operaciones entre conjuntos */
    private Calculador calc=new Calculador();
    
    /** Atributo que contiene el nombre del archivo en el que se van a escribir los resultados */
    public String archivoSalida="";
    
    /** Vector que contiene los resultados que se van a escribir en el archivo de salida */
    public Vector vectorResultados=new Vector();
    
    /** Crea una nueva instancia de Parse */
    public Parse() {
    }
    
    /** Metodo principal. Se encarga de hacer el analisis sintactico
     * @param frame el frame en el que se debe desplegar los mensajes (si es 
     * necesario desplegar alguno)
     * @param _nodo un nodo sin errores lexicos para analizarlo sintacticamente
     */
    public void analizar(JFrame frame, Nodo _nodo){
        colaError.vaciar();
        colaConjuntos.vaciar();
        vectorResultados.removeAllElements();
        Universo.removeAllElements();
        nodo_tmp=null;
        estado=0;
        num_Error=-1;
        boolean s16=false; //bandera para saber si se pasa a s14 desde s16.
        nodo=_nodo; //por si se puede perder algun dato.
        
        /** tmp_NodoConj se usa para guardar temporalmente un conjunto para ir
         * metiendole poco a poco los elementos y si al terminar no hay errores,
         * se mete a la cola
         */
        NodoConj tmp_NodoConj = null;
        
        /*el receptor es el que recibe el resultado, Op1 y 2=operador1 y 2.
         Hay que declararlos afuera del while para que se pueda modificar sus atributos*/
        NodoConj conjReceptor=null,conjOp1=null,conjOp2=null; //(almacenadores temporales).
        String operador=""; //el operador de los conjuntos (temporal). Tambien afuera del while (ver los comentarios de la linea de arriba).
        
        while(estado!=-2){ //mientras que nodo!=null
            
            switch(estado){
                case 0:
                    if(nodo.lexema.equalsIgnoreCase("programa")) estado=1;
                    else num_Error=estado;
                    break;
                case 1:
                    if(nodo.tipo.equalsIgnoreCase("IDENTIFICADOR")) estado=2;
                    else num_Error=estado;
                    break;
                case 2:
                    if(nodo.lexema.equalsIgnoreCase("CONJUNTOS")) estado=3;
                    else num_Error=estado;
                    break;
                case 3:
                    if(nodo.tipo.equalsIgnoreCase("IDENTIFICADOR")){
                        estado=4;
                        if(!colaConjuntos.existeConj(nodo.lexema))
                            tmp_NodoConj=new NodoConj(nodo.lexema);
                        else
                            num_Error=estado; //el conj esta repetido
                    }
                    else num_Error=estado;
                    break;
                case 4:
                    if(nodo.lexema.equalsIgnoreCase("=")) estado=5;
                    else num_Error=estado;
                    break;
                case 5:
                    if(nodo.lexema.equalsIgnoreCase("{")) estado=6;
                    else num_Error=estado;
                    break;
                case 6:
                    if(nodo.lexema.equalsIgnoreCase("}")){
                        estado=9;
                        colaConjuntos.push(tmp_NodoConj); //se termino de agregar elementos y no hay errores
                    }
                    else
                        if( (nodo.tipo.equalsIgnoreCase("IDENTIFICADOR")||nodo.tipo.equalsIgnoreCase("NUMERO"))&&!colaConjuntos.existeElemento(nodo.lexema,tmp_NodoConj.Elementos) ){
                            estado=7;
                            tmp_NodoConj.Elementos.addElement((Object)nodo.lexema);
                        }
                        else num_Error=estado;
                    break;
                case 7:
                    if(nodo.lexema.equalsIgnoreCase("}")){
                        estado=9;
                        colaConjuntos.push(tmp_NodoConj); //se termino de agregar elementos y no hay errores
                    }
                    else
                        if(nodo.lexema.equalsIgnoreCase(",")) estado=8;
                        else num_Error=estado;
                    break;
                case 8:
                    if( (nodo.tipo.equalsIgnoreCase("IDENTIFICADOR")||nodo.tipo.equalsIgnoreCase("NUMERO"))&&!colaConjuntos.existeElemento(nodo.lexema,tmp_NodoConj.Elementos) ){
                        estado=7;
                        tmp_NodoConj.Elementos.addElement((Object)nodo.lexema);
                    }
                    else num_Error=estado;
                    break;
                case 9:
                    if(nodo.lexema.equalsIgnoreCase("INICIO")){
                        estado=10;
                        crearUniverso();
                    }
                    else
                        if(nodo.tipo.equalsIgnoreCase("IDENTIFICADOR")){
                            estado=4;
                            if(!colaConjuntos.existeConj(nodo.lexema))
                                tmp_NodoConj=new NodoConj(nodo.lexema);
                            else
                                num_Error=estado; //el conj esta repetido
                        }
                        else num_Error=estado; //no es INICIO ni IDENTIFICADOR
                    break;
                case 10:
                    if(colaConjuntos.existeConj(nodo.lexema)){
                        estado=11;
                        try{
                            conjReceptor=new NodoConj(nodo.lexema,colaConjuntos.getElementos(nodo.lexema));//creando nodo receptor
                        }catch(Exception e){JOptionPane.showMessageDialog(frame,"ERROR INTERNO "+estado+": "+e);} //nunca se da esta excepcion porque si se pudiera dar, ni siquiera hubiera entrado al if
                    }
                    else num_Error=estado;
                    break;
                case 11:
                    if(nodo.lexema.equalsIgnoreCase("=")) estado=12;
                    else num_Error=estado;
                    break;
                case 12:
                    if(colaConjuntos.existeConj(nodo.lexema)){
                        estado=13;
                        try{
                            conjOp1=new NodoConj(nodo.lexema,colaConjuntos.getElementos(nodo.lexema));//creando nodo operador1
                        }catch(Exception e){JOptionPane.showMessageDialog(frame,"ERROR INTERNO "+estado+": "+e);}
                    }
                    else num_Error=estado;
                    break;
                case 13:
                    if(nodo.lexema.equalsIgnoreCase(";")){
                        estado=17;
                        if(!conjReceptor.Elementos.isEmpty())
                            conjReceptor.Elementos.removeAllElements();
                        if(!conjOp1.Elementos.isEmpty())
                            conjReceptor.Elementos.addAll(conjOp1.Elementos);
                        colaConjuntos.reemplazarElementos(conjReceptor);
                    }
                    else
                        if(nodo.lexema.equalsIgnoreCase("@")){
                            estado=14;
                            if(!conjReceptor.Elementos.isEmpty())
                                conjReceptor.Elementos.removeAllElements();
                            conjReceptor.Elementos.addAll(calc.Complemento(conjOp1.Elementos,Universo));
                            if(!conjOp1.Elementos.isEmpty())
                                conjOp1.Elementos.removeAllElements();
                            conjOp1.Elementos.addAll(conjReceptor.Elementos);
                        }
                        else
                            if(nodo.tipo.equalsIgnoreCase("OPERADOR")){
                                estado=15;
                                operador=nodo.lexema;
                            }
                            else
                                if(nodo.tipo.equalsIgnoreCase("OPERADOR1") && nodo.siguiente!=null && nodo.siguiente.tipo.equalsIgnoreCase("OPERADOR2")){
                                    nodo=nodo.siguiente;
                                    estado=15;
                                    operador="<>";
                                    }
                                else num_Error=estado;
                    break;
                case 14:
                    if(!s16){ //no viene de s16, viene de s13.
                        if(nodo.lexema.equalsIgnoreCase(";")){
                            estado=17;
                            if(!conjReceptor.Elementos.isEmpty())
                                conjReceptor.Elementos.removeAllElements();
                            if(!conjOp1.Elementos.isEmpty())
                                conjReceptor.Elementos.addAll(conjOp1.Elementos);
                            colaConjuntos.reemplazarElementos(conjReceptor);
                        }
                        else
                            if(nodo.tipo.equalsIgnoreCase("OPERADOR")){
                                estado=15;
                                operador=nodo.lexema;
                            }
                            else
                                if(nodo.tipo.equalsIgnoreCase("OPERADOR1") && nodo.siguiente!=null && nodo.siguiente.tipo.equalsIgnoreCase("OPERADOR2") ){
                                    nodo=nodo.siguiente;
                                    estado=15;
                                    operador="<>";
                                }
                                else num_Error=estado;
                    break;
                    }
                    else //viene de s16.
                        if(nodo.lexema.equalsIgnoreCase(";")){
                            estado=17;
                            if(!conjReceptor.Elementos.isEmpty())
                                conjReceptor.Elementos.removeAllElements();
                            calcular(operador,conjOp1,conjOp2);
                            conjReceptor.Elementos.addAll(conjOp1.Elementos);
                            colaConjuntos.reemplazarElementos(conjReceptor);
                        }
                        else
                            if(nodo.tipo.equalsIgnoreCase("OPERADOR")){
                                estado=15;
                                calcular(operador,conjOp1,conjOp2);
                                operador=nodo.lexema;
                            }
                            else
                                if(nodo.tipo.equalsIgnoreCase("OPERADOR1") && nodo.siguiente!=null && nodo.siguiente.tipo.equalsIgnoreCase("OPERADOR2")){
                                    nodo=nodo.siguiente;
                                    estado=15;
                                    calcular(operador,conjOp1,conjOp2);
                                    operador="<>";
                                }
                                else num_Error=estado;
                    break;
                case 15:
                    if(colaConjuntos.existeConj(nodo.lexema)){
                        estado=16;
                        try{
                            conjOp2=new NodoConj(nodo.lexema,colaConjuntos.getElementos(nodo.lexema));//creando nodo operador2
                        }catch(Exception e){JOptionPane.showMessageDialog(frame,"ERROR INTERNO "+estado+": "+e);}
                    }
                    else num_Error=estado;
                    break;
                case 16:
                    if(nodo.lexema.equalsIgnoreCase(";")){
                        estado=17;
                        if(!conjReceptor.Elementos.isEmpty())
                            conjReceptor.Elementos.removeAllElements();
                        calcular(operador,conjOp1,conjOp2);
                        conjReceptor.Elementos.addAll(conjOp1.Elementos);
                        colaConjuntos.reemplazarElementos(conjReceptor);
                    }
                    else
                        if(nodo.tipo.equalsIgnoreCase("OPERADOR")){
                            estado=15;
                            calcular(operador,conjOp1,conjOp2);
                            operador=nodo.lexema;
                        }
                        else
                            if(nodo.tipo.equalsIgnoreCase("OPERADOR1") && nodo.siguiente!=null && nodo.siguiente.tipo.equalsIgnoreCase("OPERADOR2")){
                                nodo=nodo.siguiente;
                                estado=15;
                                calcular(operador,conjOp1,conjOp2);
                                operador="<>";
                            }
                            else
                                if(nodo.lexema.equalsIgnoreCase("@")){
                                    s16=true;
                                    estado=14;
                                    if(!conjReceptor.Elementos.isEmpty())
                                        conjReceptor.Elementos.removeAllElements();
                                    conjReceptor.Elementos.addAll(calc.Complemento(conjOp2.Elementos,Universo));
                                    if(!conjOp2.Elementos.isEmpty())
                                        conjOp2.Elementos.removeAllElements();
                                    conjOp2.Elementos.addAll(conjReceptor.Elementos);
                                }
                                else num_Error=estado;
                    break;
                case 17:
                    s16=false;
                    if(colaConjuntos.existeConj(nodo.lexema)){
                        estado=11;
                        try{
                            conjReceptor=new NodoConj(nodo.lexema,colaConjuntos.getElementos(nodo.lexema));//creando nodo receptor
                        }catch(Exception e){JOptionPane.showMessageDialog(frame,"ERROR INTERNO "+estado+": "+e);} //nunca se da esta excepcion porque si se pudiera dar, ni siquiera hubiera entrado al if
                    }
                    else
                        if(nodo.lexema.equalsIgnoreCase("RESULTADOS")) estado=18;
                        else num_Error=estado;
                    break;
                case 18:
                    if(nodo.lexema.equalsIgnoreCase("Salida")) estado=19;
                    else num_Error=estado;
                    break;
                case 19:
                    if(nodo.tipo.equalsIgnoreCase("ARCHIVO")){
                        estado=20;
                        archivoSalida=nodo.lexema;
                    }
                    else num_Error=estado;
                    break;
                case 20:
                    if(colaConjuntos.existeConj(nodo.lexema)){
                        estado=21;
                        vectorResultados.addElement((Object)nodo.lexema);
                    }
                    else num_Error=estado;
                    break;
                case 21:
                    if(nodo.lexema.equalsIgnoreCase("FIN")) estado=22;
                    else
                        if(colaConjuntos.existeConj(nodo.lexema))
                            vectorResultados.addElement((Object)nodo.lexema); //ya esta en estado=21
                        else num_Error=estado;
                    break;
                case 22:
                    num_Error=estado;
                    estado=23;
                    break;
                case 23:
                    num_Error=22;
            }

            if(num_Error!=-1){
                String err="";
                
                if(num_Error>=0 && num_Error<=2){ //para que no tome en cuenta num_Error=-2 que es cuando nodo=null.
                    err="ERROR "+num_Error+": inicio no valido. No se esperaba "+nodo.lexema;
                    buscarReservadas();
                }
                else
                    if(num_Error>=3 && num_Error<=8){
                        err="ERROR "+num_Error+": <CONJUNTOS> no se esperaba: "+nodo.lexema;
                        buscarEnNodo("}");
                        if(estado!=-2) estado=9; //si encontro el lexema }, estado=9
                    }
                    else
                        if(num_Error==9){
                            err="ERROR "+num_Error+": se esperaba 'INICIO' o un conjunto";
                            buscarEnNodo("}");// el estado ya es estado=9
                            if(estado==-2) buscarReservadas(); //solo si no se encontro }
                        }
                        else
                            if(num_Error>=10 && num_Error<=16){
                                err="ERROR "+num_Error+": <INICIO> no se esperaba: "+nodo.lexema;
                                buscarEnNodo(";");
                                if(estado!=-2) estado=17; //si encontro el lexema ;, estado=17
                            }
                            else
                                if(num_Error==17){
                                    err="ERROR "+num_Error+": se esperaba 'RESULTADOS' o un conjunto";
                                    buscarEnNodo(";");// el estado ya es estado=17
                                    if(estado==-2) buscarReservadas(); //solo si no se encontro ;
                                }
                                else
                                    if(num_Error==18){
                                        err="ERROR "+num_Error+": <RESULTADOS> se esperaba 'Salida'";
                                        buscarReservadas(); //buscar 'Salida'
                                    }
                                    else
                                        if(num_Error>=19){
                                            err="ERROR "+num_Error+": <RESULTADOS> no se esperaba: "+nodo.lexema;
                                            buscarReservadas(); //buscar 'FIN'
                                        }
                tools.meterEnCola(nodo.lexema,err,nodo.linea,nodo.columna,null,colaError);
                nodo=nodo_tmp;
                num_Error=-1;
            }
            try{
                nodo=nodo.siguiente;
                if(nodo==null) break;
            }catch(Exception e){
                //estado=-2; //significa que nodo=null
                break;
            }
        }
        if(estado!=22){
            nodo=_nodo;
            while(nodo.siguiente!=null) nodo=nodo.siguiente;
            tools.meterEnCola(nodo.lexema,"ERROR: <FIN> se esperaba 'FIN'",nodo.linea,nodo.columna,null,colaError);
        }
        
    }

    /** Busca en el nodo el lexema recibida como parametro. Si no lo encuentra
     * asigna estado=-2
     * @param lexema el lexema a buscar
     */
    private void buscarEnNodo(String lexema) {
        nodo_tmp=nodo;
        try{
            while(!nodo_tmp.lexema.equalsIgnoreCase(lexema))
                nodo_tmp=nodo_tmp.siguiente;
            }catch(Exception e){
                estado=-2; //significa que nodo=null
            }
    }
    
    /** Busca las palabras reservadas que puedan haber en el nodo. Si encuentra 
     * alguna establece el estado como el estado que deberia estar al encontrar
     * esa palabra; si no encuentra ninguna establece estado=-2. Este algoritmo
     * no busca palabras reservadas que ya se hayan pasado, o sea que si el
     * estado esta en la seccion de RESULTADOS no busca INICIO ni
     * PROGRAMA, solo las que le siguen
     */
    private void buscarReservadas(){
        if(num_Error<=2){
            estado=2;
            buscarEnNodo("CONJUNTOS");
            if(estado!=-2){
                estado=3;
                return;
            }
        }
        if(num_Error<=9){
            estado=9;
            buscarEnNodo("INICIO");
            if(estado!=-2){
                estado=10;
                return;
            }
        }
        if(num_Error<=17){
            estado=17;
            buscarEnNodo("RESULTADOS");
            if(estado!=-2){
                estado=18;
                return;
            }
        }
        if(num_Error<=18){
            estado=18;
            buscarEnNodo("SALIDA");
            if(estado!=-2){
                estado=19;
                return;
            }
        }
        if(num_Error<=21){
            estado=21;
            buscarEnNodo("FIN");
            if(estado!=-2){
                estado=22;
                return;
            } //si no lo encontro, el estado ya es estado=-2; buscarEnNodo() le asigno el -2
        }
    }

    /** Crea el universo. Toma la colaConjuntos y hace una Union de todos los
     * elementos de todos sus conjuntos, o sea que no pueden haber elementos
     * repetidos en el universo
     */
    private void crearUniverso() {
        try{
            NodoConj tmp_NodoConj=colaConjuntos.getNodoConj(); //para no perder datos
            
            while(tmp_NodoConj!=null){
                Universo=new Vector(calc.Union(Universo,tmp_NodoConj.Elementos)); //se lo agrega automatico
                tmp_NodoConj=tmp_NodoConj.Siguiente;
            }
        }catch(Exception e){}
    }
    
    /** Metodo que calcula la operacion que se necesite, dependiendo lo que indique el parametro
     * _operador. Tambien le asigna el nuevo valor al objeto que representa Op1
     * @param _operador es el operador de la operacion que se va a realizar
     * @param Op1 el primer operador en la operacion
     * @param Op2 el segundo operador en la operacion
     */
    private void calcular(String _operador, NodoConj Op1, NodoConj Op2){
        NodoConj tmp_Op1=new NodoConj("tmp");
        if(_operador.equalsIgnoreCase("+"))
            tmp_Op1.Elementos.addAll(calc.Union(Op1.Elementos,Op2.Elementos));
        else
            if(_operador.equalsIgnoreCase("-"))
                tmp_Op1.Elementos.addAll(calc.Diferencia(Op1.Elementos,Op2.Elementos));
            else
                if(_operador.equalsIgnoreCase("*"))
                    tmp_Op1.Elementos.addAll(calc.Interseccion(Op1.Elementos,Op2.Elementos));
                else
                    if(_operador.equalsIgnoreCase("<>"))
                        tmp_Op1.Elementos.addAll(calc.diferenciaSimetrica(Op1.Elementos,Op2.Elementos));
        if(!Op1.Elementos.isEmpty())
            Op1.Elementos.removeAllElements();
        Op1.Elementos.addAll(tmp_Op1.Elementos);
    }
    
}
