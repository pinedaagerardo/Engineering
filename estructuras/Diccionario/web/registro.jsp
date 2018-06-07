<%-- 
    Document   : registro
    Created on : 2/05/2008, 01:56:30 PM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<jsp:useBean id="beanUsuario" class="Usuarios.beanUsuario" scope="session"/>
<%
if(String.valueOf(session.getAttribute("adminlog")).equalsIgnoreCase("out"))
    response.sendRedirect("sessionexpired.jsp");
else{
    String user=request.getParameter("usuario");
    String pass=request.getParameter("clave");
    beanUsuario.registrarUsuario(user, pass);
    response.sendRedirect("menuadmin.jsp");
}
%>