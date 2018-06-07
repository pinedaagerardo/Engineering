<%-- 
    Document   : Menu
    Created on : 12/03/2008, 10:44:22 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

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
                            <h1><a>ESTRUCTURAS DE DATOS</a></h1>

                            <h3><a id="metamorph">Proyecto 1</a></h3>
                            
                            <h2><a id="metamorph">Menu</a></h2>
                    </div>
                    <!--<div id="menu">-->
                            <ul id="menu">
                                    <li><a href="Login.jsp" title="">Administrar</a></li>
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
                                        <br>
                                        <ul>
                                            <p><a href="BxCategoria.jsp">Buscar Categoria</a></p>
                                        </ul>
                                        <br>
                                        <ul>
                                            <p><a href="BxEmpresa.jsp">Buscar Empresa</a></p>
                                        </ul>
                                </div>
                        </div>
                </div>
                <div id="right">
                    
                    <br>
                    <h1>Bienvenido</h1>			
                    <br><br>
                    <p>Puede escoger en el panel de la izquierda una opcion
                    para busqueda o si es administrador, puede seleccionar en la
                    barra de menu 'Administrar' y puede administrar los datos
                    despues de ingresar con el usuario administrador</p>
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
