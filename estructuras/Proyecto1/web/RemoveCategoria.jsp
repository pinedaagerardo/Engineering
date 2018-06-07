<%-- 
    Document   : RemoveCategoria
    Created on : 17/03/2008, 10:08:04 PM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="HERRAMIENTAS.Matriz"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<%
if(session.getAttribute("log").toString().equalsIgnoreCase("out"))
    response.sendRedirect("SessionExpired.jsp");
else{
    if(!session.getAttribute("estadoadmin").toString().equalsIgnoreCase("rc"))
        session.setAttribute("estadoadmin", "rc");
    else{
        String action=request.getParameter("action");
        if(action!=null && action.equals("submit")){

            String nom=session.getAttribute("nomviejo").toString();
            session.setAttribute("estadoadmin", "");
            ((Matriz)session.getAttribute("matriz")).removeCategoria(nom);

        }
    }
    response.sendRedirect("MenuAdmin.jsp");
}
%>