<%-- 
    Document   : estadous
    Created on : 2/05/2008, 02:04:11 PM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<jsp:useBean id="beanUsuario" class="Usuarios.beanUsuario" scope="session"/>

<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
            <link href="Estilo.css" rel="stylesheet" type="text/css" />
        <title>Menu del administrador</title>
    </head>
    <body>
        <%
        if(String.valueOf(session.getAttribute("adminlog")).equalsIgnoreCase("out"))
            response.sendRedirect("sessionexpired.jsp");
        %>
        
        <script type="text/javascript">
         <!--
          function ShowMenu(menu) {
             var thisMenu = document.getElementById(menu);

             if (menu == "Menu1") pos = "17em";
             else if (menu == "Menu2") pos = "24em";

             for (var i = 1; i<=2; i++) {
                if (document.getElementById('Menu'+i)) {
                  document.getElementById('Menu'+i).style.left="-999em";
                }
             }
             if (thisMenu) {
               thisMenu.style.left=pos;
             }
          }
        </script>

        <div id="main">
            <!-- header begins -->
            <div id="header">
                    <div id="logo">
                            <h1><a>estructuras de datos</a></h1>

                            <h3><a id="metamorph">diccionario web</a></h3>
                            
                            <h2><a id="metamorph">Administrando</a></h2>
                    </div>
                    <!--<div id="menu">-->
                            <ul id="menu">
                                    
                                    <li id="Button2"><a onmouseover="ShowMenu('Menu1')"
                                    onfocus="ShowMenu('Menu1')"
                                    onmouseout="ShowMenu()">Usuarios</a>
                                        <ul id="Menu1"
                                        onmouseover="ShowMenu('Menu1')"
                                        onfocus="ShowMenu('Menu1')"
                                        onmouseout="ShowMenu()"
                                        onblur="ShowMenu()">
                                            <li><a href="cargarus.jsp">Cargar</a></li>
                                            <li><a href="registrarus.jsp">Registrar</a></li>
                                            <li><a href="modificarus.jsp">Modificar</a></li>
                                        </ul>
                                    </li>
                                        
                                    <li id="Button3"><a onmouseover="ShowMenu('Menu2')"
                                    onfocus="ShowMenu('Menu2')"
                                    onmouseout="ShowMenu()">Diccionario</a>
                                        <ul id="Menu2"
                                        onmouseover="ShowMenu('Menu2')"
                                        onfocus="ShowMenu('Menu2')"
                                        onmouseout="ShowMenu()"
                                        onblur="ShowMenu()">
                                            <li><a href="cargardicc.jsp">Cargar</a></li>
                                            <li><a href="eliminardicc.jsp">Eliminar</a></li>
                                            <li><a href="modificardicc.jsp">Modificar</a></li>
                                        </ul>
                                    </li>
                                    
                                    <li><a href="logoutadmin.jsp">Cerrar</a></li>
                            </ul>
                    <!--</div>-->
            </div>
            <!-- header ends -->
            <!-- content begins -->
            <div id="content">
                <div id="right">
                    <br><br><br>
                        
                    <%
                    String st=request.getParameter("state");
                    if(st.toLowerCase().charAt(0)!='b' && st.toLowerCase().charAt(0)!='h')
                        st="*";
                    try{
                        out.println(beanUsuario.mostrarEstado(st.toLowerCase().charAt(0)));
                    }catch(Exception e){}
                    %>
                        
                    <br><br><br>
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