<%-- 
    Document   : logoutadmin
    Created on : 2/05/2008, 07:56:16 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<%
session.setAttribute("adminlog", "out");
response.sendRedirect("login.jsp");
%>