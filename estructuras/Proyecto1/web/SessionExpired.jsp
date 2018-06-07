<%-- 
    Document   : SessionExpired
    Created on : 18/03/2008, 03:37:45 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<%
session.setAttribute("estadoadmin", "");
%>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
            <link href="Estilo.css" rel="stylesheet" type="text/css" />
        <title>Sesión expirada</title>
    </head>
    <body>
        <div id="main">
            <!-- header begins -->
            <div id="header">
                    <div id="logo">
                            <h1><a>ESTRUCTURAS DE DATOS</a></h1>

                            <h3><a id="metamorph">Proyecto 1</a></h3>
                            
                            <h2><a id="metamorph">Sesión expirada</a></h2>
                    </div>
            </div>
            <!-- header ends -->
            <!-- content begins -->
            <div id="content">
                <div id="right">
                    
                    <h1>La sesión ha expirado</h1>			
                            
                        <br><br><br><br>
                        <a href="Menu.jsp">Regresar al menu</a>
                        <br><br><br><br>
                            
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
