package Datos;

public class TokenValue {
 public int lineaInicio;
 public int columnaInicio;
 public String lexema;
 TokenValue() {
 }
 TokenValue(String lexema, int lineaInicio, int columnaInicio) {
   this.lexema = lexema.toLowerCase();
   this.lineaInicio = lineaInicio;
   this.columnaInicio = columnaInicio;
 }
  public String getLexema( ){
     return lexema;
  }
  public int getLinea(){
     return lineaInicio;
  }
  public int getColumna(){
      return columnaInicio;
  }
}
