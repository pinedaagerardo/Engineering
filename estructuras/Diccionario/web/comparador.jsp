
<%--
    Document   : comparador
    Created on : 2/05/2008, 06:51:44 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<jsp:useBean id="beanUsuario" class="Usuarios.beanUsuario" scope="session"/>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        
<%
String usuario=request.getParameter("tUser");
String password=request.getParameter("tPass");
if(usuario.equalsIgnoreCase(session.getAttribute("admin").toString()) && password.equalsIgnoreCase(session.getAttribute("pass").toString())){
    session.setAttribute("adminlog", "in");
    response.sendRedirect("menuadmin.jsp");
}else{
    try{
        Usuarios.NodoUsuario tmp=beanUsuario.tabla.getNodoLetra(String.valueOf(usuario.charAt(0))).getUsuario(usuario);
        if(usuario.equals(tmp.usuario) && password.equals(tmp.pass)){
            session.setAttribute("userlog", "in");
            session.setAttribute("activeuser", tmp);
            response.sendRedirect("menuuser.jsp");
        }else{
        %>
        <title>Error</title>
        <%
        out.println("El usuario no coincide con la contraseña");
        %>
        <br><br>
        <a href="login.jsp">Intentar otra vez</a>
        <%
        }
    }catch(Exception e){
        response.sendRedirect("login.jsp");
    }
}
%>

    </head>
</html>
