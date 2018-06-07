<%-- 
    Document   : Login
    Created on : 16/03/2008, 04:14:47 PM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<%
if(String.valueOf(session.getAttribute("log")).equalsIgnoreCase("in"))
    response.sendRedirect("MenuAdmin.jsp");
%>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
            <link href="Estilo.css" rel="stylesheet" type="text/css" />
        <title>Login</title>
    </head>
    <body>
        <div id="main">
            <!-- header begins -->
            <div id="header">
                    <div id="logo">
                            <h1><a>ESTRUCTURAS DE DATOS</a></h1>

                            <h3><a id="metamorph">Proyecto 1</a></h3>
                            
                            <h2><a id="metamorph">ingresando administrador</a></h2>
                    </div>
            </div>
            <!-- header ends -->
            <!-- content begins -->
            <div id="content">
                <div id="right">
                    
                    <h1>Ingresar a su cuenta (solo administrador)</h1>			
                            
                            <form method="post" action="Comparador.jsp">
                                <br><br><br><br>
                                Usuario: <input type="text" name="tUser">
                                <br><br>
                                Contraseña: <input type="password" name="tPass">
                                <br><br>
                                <input type="submit" value="Ingresar">
                                <br><br><br>
                                <a href="Menu.jsp">Regresar al menu</a>
                                <br><br><br><br>
                            </form>
                            
                    <!-- footer begins -->
                    <div id="metamorph1">
                            <p>Gerardo Pineda</p>
                            <p>2006-11226</p>
                    </div>
                    <!-- footer ends -->
                </div>
            </div>
             <!-- content ends -->
        </div>
    </body>
</html>
