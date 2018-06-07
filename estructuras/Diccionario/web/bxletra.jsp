<%-- 
    Document   : bxletra
    Created on : 2/05/2008, 08:15:52 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<jsp:useBean id="beanArbol" class="Datos.beanArbol" scope="session"/>
<jsp:useBean id="beanUsuario" class="Usuarios.beanUsuario" scope="session"/>
<%
if(String.valueOf(session.getAttribute("userlog")).equalsIgnoreCase("out"))
    response.sendRedirect("sessionexpired.jsp");
else{
    String pal=request.getParameter("texto");
    beanArbol.buscarLetra(pal.charAt(0));
    response.sendRedirect("menuuser.jsp");
}
%>

