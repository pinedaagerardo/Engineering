/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package proy2;

import java.io.*;

/**
 *
 * @author elzher
 */
public class Abc {

    FileWriter escribir,escribirS;
    int repetido=0,insercion=0,excepcion=0;
    
    public Abc(){
    }

    public void borrar(){
        //borrar archivo (log)
        try{
            File f=new File("/home/elzher/logp2.txt");
            if(f.exists()) f.delete();
        }catch(Exception e){}
    }
    
    public void log(String msj){
        if(msj.toLowerCase().startsWith("rep")) repetido++;
        if(msj.toLowerCase().startsWith("ins")) insercion++;
        if(msj.toLowerCase().startsWith("ex")) excepcion++;
        try{
            escribir = new FileWriter("/home/elzher/logp2.txt",true);
            escribir.write(msj+"\n");
            escribir.close();
        }catch(Exception e){}
    }

    public void cLog(){
        try{
            escribir = new FileWriter("/home/elzher/logp2.txt",true);
            escribir.write("\nDatos no ingresados: "+repetido+"\n");
            escribir.write("Datos insertados: "+insercion+"\n");
            escribir.write("excepciones: "+excepcion+"\n");
            escribir.close();
        }catch(Exception e){}
    }

    public void oScript(){
        //borrar archivo (log)
        try{
            File f1=new File("/home/elzher/dato1.sql");
            File f2=new File("/home/elzher/dato2.sql");
            File f3=new File("/home/elzher/dato3.sql");
            if(f1.exists()) f1.delete();
            if(f2.exists()) f2.delete();
            if(f3.exists()) f3.delete();
        }catch(Exception e){}
    }

    public void wScript(String msj,String archivo){
        try{
            escribirS = new FileWriter("/home/elzher/"+archivo+".sql",true);
            escribirS.write(msj+";\n");
            escribirS.close();
        }catch(Exception e){}
    }
}
