<%-- 
    Document   : modius
    Created on : 2/05/2008, 12:43:46 PM
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
    String viejo=request.getParameter("vusuario");
    String nuevo=request.getParameter("nusuario");
    String clave=request.getParameter("nclave");
    beanUsuario.modificarUsuario(viejo, nuevo, clave, null);
    response.sendRedirect("menuadmin.jsp");
}
%>