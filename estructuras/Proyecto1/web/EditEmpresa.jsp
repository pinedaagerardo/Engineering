<%-- 
    Document   : EditEmpresa
    Created on : 17/03/2008, 10:16:37 PM
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
    if(!session.getAttribute("estadoadmin").toString().equalsIgnoreCase("ee"))
        session.setAttribute("estadoadmin", "ee");
    else{
        String action=request.getParameter("action");
        if(action!=null && action.equals("submit")){

            String nom=session.getAttribute("nomviejo").toString();
            String cat=session.getAttribute("catvieja").toString();
            String comentario=request.getParameter("tDes");
            String direccion=request.getParameter("tDir");
            String logo=request.getParameter("tLog");
            String pagina=request.getParameter("tPag");
            String telefono=request.getParameter("tTel");
            if(nom!="" && cat!="" && comentario!="" && direccion!="" && logo!="" && pagina!="" && telefono!=""){
                session.setAttribute("estadoadmin", "");
                ((Matriz)session.getAttribute("matriz")).editEmpresa(nom, cat, comentario, direccion, telefono, pagina, logo);
            }
            else
                JOptionPane.showMessageDialog(new JFrame("Error"),"La información no es correcta","Error",JOptionPane.ERROR_MESSAGE);

        }
    }
    response.sendRedirect("MenuAdmin.jsp");
}
%>