<%-- 
    Document   : AddEmpresa
    Created on : 17/03/2008, 10:16:10 PM
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
    if(!session.getAttribute("estadoadmin").toString().equalsIgnoreCase("ae"))
        session.setAttribute("estadoadmin", "ae");
    else{
        String action=request.getParameter("action");
        if(action!=null && action.equals("submit")){

            String nom=request.getParameter("tNom");
            String des=request.getParameter("tDes");
            String dir=request.getParameter("tDir");
            String tel=request.getParameter("tTel");
            String pag=request.getParameter("tPag");
            String lo=request.getParameter("tLog");
            String cat=request.getParameter("tCat");
            if(nom!="" && des!="" && dir!="" && tel!="" && pag!="" && lo!="" && cat!="")
                ((Matriz)session.getAttribute("matriz")).addEmpresa(nom.toLowerCase(), des, dir, tel, pag, lo, cat, String.valueOf(nom.toLowerCase().charAt(0)));
            else
                JOptionPane.showMessageDialog(new JFrame("Error"),"Se debe llenar todos los campos","Error",JOptionPane.ERROR_MESSAGE);

        }
    }
    response.sendRedirect("MenuAdmin.jsp");
}
%>
