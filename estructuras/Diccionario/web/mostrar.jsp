<%-- 
    Document   : mostrar
    Created on : 1/05/2008, 11:54:15 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<jsp:useBean id="beanArbol" class="Datos.beanArbol" scope="session"/>
<jsp:useBean id="beanUsuario" class="Usuarios.beanUsuario" scope="session"/>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <%
        beanUsuario.registrarUsuario("nuevo", "passnuevo");
        out.println(beanUsuario.mostrarEstado('*').toString());
        for(int i=0;i<0;i++){
            /*out.println(beanArbol.getPalabra(i)+",");
            out.println(beanArbol.getTraduccion(i)+",");
            out.println(beanArbol.getPath(i)+";");*/
            /*out.println(beanUsuario.getUsuario(i)+",");
            out.println(beanUsuario.getClave(i)+",");
            out.println(beanUsuario.getEstado(i)+";");*/
        %>
        <br>
        <%
        }
        %>
    </body>
</html>
