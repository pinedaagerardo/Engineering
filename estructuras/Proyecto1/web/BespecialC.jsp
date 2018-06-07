<%-- 
    Document   : BespecialC
    Created on : 20/03/2008, 07:38:05 PM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="HERRAMIENTAS.Matriz"%>
<%@page import="MATRIZ_ORTOGONAL.Categoria"%>
<%@page import="MATRIZ_ORTOGONAL.Celda"%>
<%@page import="MATRIZ_ORTOGONAL.miNodo"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
            <link href="Estilo.css" rel="stylesheet" type="text/css" />
        <title>Búsqueda</title>
    </head>
    <body>
        <div id="main">
            <!-- header begins -->
            <div id="header">
                    <div id="logo">
                            <h1><a>ESTRUCTURAS DE DATOS</a></h1>

                            <h3><a id="metamorph">Proyecto 1</a></h3>
                            
                            <h2><a id="metamorph">Búsqueda por categoría</a></h2>
                    </div>
                    <!--<div id="menu">-->
                            <ul id="menu">
                                    <li><a href="Login.jsp" title="">Administrar</a></li>
                            </ul>
                    <!--</div>-->
            </div>
            <!-- header ends -->
            <!-- content begins -->
            <div id="content">
                <div id="left">

                        <div id="updates" class="boxed">

                                <h2 class="title">Buscar</h2>
                                <div class="content2">
                                        <br>
                                        <ul>
                                            <p><a href="BxCategoria.jsp">Buscar Categoria</a></p>
                                        </ul>
                                        <br>
                                        <ul>
                                            <p><a href="BxEmpresa.jsp">Buscar Empresa</a></p>
                                        </ul>
                                </div>
                        </div>
                </div>
                <div id="right">
<%
Matriz m=((Matriz)session.getAttribute("Matriz"));
java.util.Vector letras=new java.util.Vector(),nombres=new java.util.Vector();
java.io.PrintWriter escribir=null;
java.io.File f=new java.io.File("graph.dot");

Categoria cat_actual;
String c_nom=request.getParameter("Hcat");
java.util.Iterator itcat=m.cat.iterator();
while(!(cat_actual=(Categoria)itcat.next()).nombre.equalsIgnoreCase(c_nom)){}

try{
    escribir = new java.io.PrintWriter(new java.io.FileWriter(f));
    escribir.println("digraph modelo{");
    escribir.println("node [color=Blue,fontname=Courier]");
    escribir.println(cat_actual.nombre+"->{ ");
    //sigue abajo ->
}catch(Exception e){}

java.util.Iterator itcel=cat_actual.listado.iterator();
%>
<br>
<h1>Categoria: &nbsp; <%=cat_actual.nombre%></h1>
<br><br>
<%
while(itcel.hasNext()){
    java.util.Iterator itemp=((Celda)itcel.next()).empresa.iterator();
    while(itemp.hasNext()){
        miNodo emp=((miNodo)itemp.next());
        nombres.addElement(emp.nombre);
        %>
        <%=emp.nombre%><br>
        <%=emp.comentario%><br>
        <%=emp.direccion%><br>
        <%=emp.telefono%><br>
        <%=emp.pagina%><br>
        <div class="pic"><img src="<%=emp.logo%>" alt="" /></div>&nbsp;<%=emp.logo%>
        <br><br>
        <%
    }
    char tmp=nombres.lastElement().toString().charAt(0);
    if(!letras.contains(tmp))
        letras.addElement(tmp);
}
try{
    String tmpN="",tmpL="";
    for(int i=0;i<letras.size();i++){
        String tmp="";
        escribir.print(tmp=letras.elementAt(i).toString()+" ");
        tmpL=tmpL+tmp;
    }
    escribir.println("}");
    escribir.println("{rank=same "+tmpL+"}");
    for(int i=0;i<letras.size();i++){
        String tmp="";
        tmpL="";
        escribir.print((tmpL=letras.elementAt(i).toString())+"->{ ");
        for(int j=0;j<nombres.size();j++)
            if((tmp=nombres.elementAt(j).toString()).charAt(0)==tmpL.charAt(0)){
                tmpN=tmpN+tmp+" ";
                escribir.print(tmp+" ");
            }
        escribir.println("}");
    }
    escribir.println("{rank=same "+tmpN+"}");
    escribir.print("}");
    escribir.close();
}catch(Exception e){}

try{
    //(desde consola) para verlo sin crear archivo: dot archivo.dot -Tps|gv -
    Process p = Runtime.getRuntime().exec("dot "+f.getName()+" -Tpng -o graph.png");
    //javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame(),"Se creo el archivo "+f.getAbsolutePath());
    p = Runtime.getRuntime().exec("firefox graph.png");
}catch(Exception e){
    javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"),e.getMessage(),"Error",javax.swing.JOptionPane.ERROR_MESSAGE);
}
%>
                    <br><br><br><br>
                    <!-- footer begins -->
                    <div id="metamorph1">
                            <p>Gerardo Pineda</p>
                            <p>2006-11226</p>
                    </div>
                    <!-- footer ends -->
                </div>
            </div>
             <!-- content ends -->
        </div>
    </body>
</html>