<%-- 
    Document   : EditCategoria
    Created on : 17/03/2008, 10:07:38 PM
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
    if(!session.getAttribute("estadoadmin").toString().equalsIgnoreCase("ec"))
        session.setAttribute("estadoadmin", "ec");
    else{
        String action=request.getParameter("action");
        if(action!=null && action.equals("submit")){

            String nom=request.getParameter("tNom");
            if(nom!="" && !nom.equalsIgnoreCase(session.getAttribute("nomviejo").toString())){
                session.setAttribute("estadoadmin", "");
                ((Matriz)session.getAttribute("matriz")).editCategoria(session.getAttribute("nomviejo").toString(), nom);
                }
            else
                JOptionPane.showMessageDialog(new JFrame("Error"),"No se escribio un nombre correcto. el nombre no puede ser igual al anterior","Error",JOptionPane.ERROR_MESSAGE);

        }
    }
    response.sendRedirect("MenuAdmin.jsp");
}
%>