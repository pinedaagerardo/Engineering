<%-- 
    Document   : Comparador
    Created on : 16/03/2008, 05:39:29 PM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        
<%
session.setAttribute("estadoadmin", "");
String usuario=request.getParameter("tUser");
String password=request.getParameter("tPass");
if(usuario.equalsIgnoreCase(session.getAttribute("admin").toString()) && password.equalsIgnoreCase(session.getAttribute("pass").toString())){
    session.setAttribute("log", "in");
    response.sendRedirect("MenuAdmin.jsp");
}else{
    %>
    <title>Error</title>
    <%
    out.println("El usuario no coincide con la contraseña");
    %>
    <br><br>
    <a href="Login.jsp">Intentar otra vez</a>
    <%
}
%>

    </head>
</html>