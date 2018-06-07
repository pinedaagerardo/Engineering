<%-- 
    Document   : login
    Created on : 2/05/2008, 05:56:54 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

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
                            <h1><a>estructuras de datos</a></h1>

                            <h3><a id="metamorph">diccionario web</a></h3>
                            
                            <h2><a id="metamorph">ingresando al sistema</a></h2>
                    </div>
            </div>
            <!-- header ends -->
            <!-- content begins -->
            <div id="content">
                <div id="right">
                    
                    <h1>Ingresar a su cuenta</h1>			
                            
                            <form method="post" action="comparador.jsp">
                                <br><br><br><br>
                                Usuario: <input type="text" name="tUser">
                                <br><br>
                                Contraseña: <input type="password" name="tPass">
                                <br><br>
                                <input type="submit" value="Ingresar">
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