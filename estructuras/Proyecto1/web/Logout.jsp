<%-- 
    Document   : Logout
    Created on : 17/03/2008, 11:26:40 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<%
session.setAttribute("log", "out");
session.setAttribute("estadoadmin", "");
response.sendRedirect("Menu.jsp");
%>