<%-- 
    Document   : RemoveEmpresa
    Created on : 17/03/2008, 10:17:43 PM
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
    if(!session.getAttribute("estadoadmin").toString().equalsIgnoreCase("re"))
        session.setAttribute("estadoadmin", "re");
    else{
        String action=request.getParameter("action");
        if(action!=null && action.equals("submit")){

            String nom=session.getAttribute("nomviejo").toString();
            String cat=session.getAttribute("catvieja").toString();
            session.setAttribute("estadoadmin", "");
            ((Matriz)session.getAttribute("matriz")).removeEmpresa(nom,cat);

        }
    }
    response.sendRedirect("MenuAdmin.jsp");
}
%>