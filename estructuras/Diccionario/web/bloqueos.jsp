<%-- 
    Document   : bloquear
    Created on : 2/05/2008, 08:56:45 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<%
if(String.valueOf(session.getAttribute("adminlog")).equalsIgnoreCase("out"))
    response.sendRedirect("sessionexpired.jsp");
else{
%>
<jsp:useBean id="beanUsuario" class="Usuarios.beanUsuario" scope="session"/>
<%
String action=request.getParameter("action");
String user=request.getParameter("usuario");
try{
    if(action!=null && action.equals("block")){
        beanUsuario.bloquearUsuario(user);
    }else{
        beanUsuario.desbloquearUsuario(user);
    }
}catch(Exception e){
    javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame(),"No existe el usuario");
}finally{
    response.sendRedirect("menuadmin.jsp");
}
}
%>