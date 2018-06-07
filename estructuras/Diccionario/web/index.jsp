<%-- 
    Document   : index
    Created on : 28/04/2008, 05:15:52 PM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<jsp:useBean id="beanArbol" class="Datos.beanArbol" scope="session"/>
<jsp:useBean id="beanUsuario" class="Usuarios.beanUsuario" scope="session"/>
<%
session.setAttribute("admin", "admin");
session.setAttribute("pass", "nimda");

session.setAttribute("adminlog", "out");
session.setAttribute("userlog", "out");
session.setAttribute("activeuser", null);

response.sendRedirect("login.jsp");
%>
