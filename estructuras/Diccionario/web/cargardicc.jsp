<%-- 
    Document   : cargardicc
    Created on : 2/05/2008, 10:42:38 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<jsp:useBean id="beanArbol" class="Datos.beanArbol" scope="session"/>
<jsp:useBean id="beanUsuario" class="Usuarios.beanUsuario" scope="session"/>
<%
if(String.valueOf(session.getAttribute("adminlog")).equalsIgnoreCase("out"))
    response.sendRedirect("sessionexpired.jsp");
else{
    beanArbol.abrir();
    response.sendRedirect("menuadmin.jsp");
}
%>