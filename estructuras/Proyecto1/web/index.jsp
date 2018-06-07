<%--
    Document   : index
    Created on : 9/03/2008, 05:10:36 PM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="HERRAMIENTAS.Matriz"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<%
Matriz MO=new Matriz();
session.setAttribute("matriz", MO);
session.setAttribute("admin", "admin");
session.setAttribute("pass", "nimda");
session.setAttribute("log", "out");
session.setAttribute("estadoadmin", "");
response.sendRedirect("Menu.jsp");
%>

