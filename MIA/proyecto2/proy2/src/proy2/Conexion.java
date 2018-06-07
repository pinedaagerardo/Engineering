/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package proy2;

import java.sql.*;

/**
 *
 * @author elzher
 */
public class Conexion {

    Connection con=null;
    Statement s=null;
    Abc abc=new Abc();

    public boolean abrir(String user,String pass){
       try {
          Class.forName("oracle.jdbc.driver.OracleDriver");
          con=DriverManager.getConnection("jdbc:oracle:thin:@localhost:1521:XE",user,pass);
       } catch(Exception e){
            return false;
       }
       return true;
    }

    public void execute(String comando){
        try{
            s=con.createStatement();
            s.execute(comando);
            s.close();
        }catch(Exception e){
            e.printStackTrace();
        }
    }

    public ResultSet executeQ(String comando){
        ResultSet rs=null;
        try{
            s=con.createStatement();
            rs=s.executeQuery(comando);
        }catch(Exception e){
            e.printStackTrace();
        }
        return rs;
    }

    public void cerrar(){
        try{
            s.close();
        }catch(Exception e){}
        try{
            con.close();
        }catch(Exception e){
            e.printStackTrace();
        }
    }
}
