<%-- 
    Document   : Menu
    Created on : 2/05/2008, 05:43:53 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<%
if(String.valueOf(session.getAttribute("userlog")).equalsIgnoreCase("out"))
    response.sendRedirect("sessionexpired.jsp");
%>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
            <link href="Estilo.css" rel="stylesheet" type="text/css" />
        <title>Menu</title>
    </head>
    <body>
        <div id="main">
            <!-- header begins -->
            <div id="header">
                    <div id="logo">
                            <h1><a>estructuras de datos</a></h1>

                            <h3><a id="metamorph">Diccionario web</a></h3>
                            
                            <h2><a id="metamorph">Menu</a></h2>
                    </div>
                    <!--<div id="menu">-->
                            <ul id="menu">
                                    <li><a href="logoutuser.jsp" title="">cerrar</a></li>
                            </ul>
                    <!--</div>-->
            </div>
            <!-- header ends -->
            <!-- content begins -->
            <div id="content">
                <div id="left">

                        <div id="updates" class="boxed">

                                <h2 class="title">Buscar</h2>
                                <div class="content2">
                                </div>
                        </div>
                </div>
                <div id="right">
                    <br><br><br><br>
                    
                    <form method="post">
                        <input type="text" name="texto"><br><br>
                        <input type="submit" value="buscar palabra" onclick="action='bxpalabra.jsp';
                submit()">
                        <input type="submit" value="buscar letra" onclick="action='bxletra.jsp';
                submit()">
                    </form>
                    
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
