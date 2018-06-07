/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package proy2;

import java.io.BufferedReader;
import java.io.FileReader;
import java.util.Vector;
import javax.swing.JOptionPane;

/**
 *
 * @author elzher
 */
public class Lector {

    /**
     * toma los datos de los archivos de entrada y los mete en los vectores parametros
     * @param ruta
     * @param v1 datos1
     * @param v2 datos2
     * @param v3 datos3
     */
    public void getData(String ruta, Vector v1, Vector v2, Vector v3){
        String linea="";
        try {
            BufferedReader datos1 = new BufferedReader(new FileReader(ruta+"/datos1.txt"));
            BufferedReader datos2 = new BufferedReader(new FileReader(ruta+"/datos2.txt"));
            BufferedReader datos3 = new BufferedReader(new FileReader(ruta+"/datos3.txt"));

            while((linea=datos1.readLine())!=null){
                String[] tmp=new String[17];
                tmp=divideTab(linea);
                for(int i=0;i<tmp.length;i++){
                    tmp[i]=tmp[i].trim();
                }
                if(tmp[13].length()>80) tmp[13]=tmp[13].substring(0, 80);
                v1.add(tmp);
            }
            while((linea=datos2.readLine())!=null){
                String[] tmp=new String[8];
                tmp=dividePComa(linea);
                for(int i=0;i<tmp.length;i++){
                    tmp[i]=tmp[i].trim();
                }
                v2.add(tmp);
            }
            while((linea=datos3.readLine())!=null){
                String[] tmp=new String[10];
                tmp=divide3(linea);
                for(int i=0;i<tmp.length;i++){
                    tmp[i]=tmp[i].trim();
                }
                v3.add(tmp);
            }
            datos1.close();
            datos2.close();
            datos3.close();

        } catch (Exception ex) {
            JOptionPane.showMessageDialog(null, "Error al leer los archivos. "+ex.toString());
        }
    }

    /**
     * split para datos1
     * @param linea
     * @return
     */
    private String[] divideTab(String linea){
        String[] res=(linea.replaceAll("\"", "")).split("\t");//17 posiciones tiene que tener
        return res;
    }

    /**
     * split para datos2
     * @param linea
     * @return
     */
    private String[] dividePComa(String linea){
        String[] res=(linea.replaceAll("\"", "")).split(";");//8 posiciones tiene que tener
        return res;
    }

    /**
     * split para datos3
     * @param linea
     * @return
     */
    private String[] divide3(String linea){
        String[] tmp=(linea.replaceAll("\"", "")).split(">>");
        String[] res=new String[10];

        for(int i=1;i<tmp.length-1;i++){
            int fin=tmp[i].lastIndexOf(" ");
            res[i-1]=tmp[i].substring(0, fin);
        }
        res[res.length-1]=tmp[tmp.length-1].toString();
        
        return res;
    }
}
