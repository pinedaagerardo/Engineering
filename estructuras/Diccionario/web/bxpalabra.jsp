<%-- 
    Document   : bxpalabra
    Created on : 2/05/2008, 08:16:08 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<jsp:useBean id="beanArbol" class="Datos.beanArbol" scope="session"/>
<jsp:useBean id="beanUsuario" class="Usuarios.beanUsuario" scope="session"/>
<%
if(session.getAttribute("userlog")==null || String.valueOf(session.getAttribute("userlog")).equalsIgnoreCase("out"))
    response.sendRedirect("sessionexpired.jsp");
else{
    String pal=request.getParameter("texto");

    if(((Usuarios.NodoUsuario)session.getAttribute("activeuser")).estado=='b'){
        beanArbol.buscarLetra(pal.charAt(0));
    }else{
        javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame(),"La traduccion es: "+beanArbol.buscarTraduccion(pal));
        beanArbol.buscarLetra(pal.charAt(0));
    }
    response.sendRedirect("menuuser.jsp");
}
%>
