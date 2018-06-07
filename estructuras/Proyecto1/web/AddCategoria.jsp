<%-- 
    Document   : AddCategoria
    Created on : 17/03/2008, 10:06:54 PM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="HERRAMIENTAS.Matriz"%>
<%@page import="javax.swing.JOptionPane"%>
<%@page import="javax.swing.JFrame"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<%
if(session.getAttribute("log").toString().equalsIgnoreCase("out"))
    response.sendRedirect("SessionExpired.jsp");
else{
    if(!session.getAttribute("estadoadmin").toString().equalsIgnoreCase("ac"))
        session.setAttribute("estadoadmin", "ac");
    else{
        String action=request.getParameter("action");
        if(action!=null && action.equals("submit")){

            String nom=request.getParameter("tNom");
            if(nom!="")
                ((Matriz)session.getAttribute("matriz")).addCategoria(nom.toLowerCase());
            else
                JOptionPane.showMessageDialog(new JFrame("Error"),"No se escribio el nombre","Error",JOptionPane.ERROR_MESSAGE);

        }
    }
    response.sendRedirect("MenuAdmin.jsp");
}
%>