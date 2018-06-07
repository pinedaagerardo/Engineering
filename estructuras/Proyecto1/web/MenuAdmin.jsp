<%-- 
    Document   : MenuAdmin
    Created on : 16/03/2008, 11:09:35 PM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="HERRAMIENTAS.Matriz"%>
<%@page import="MATRIZ_ORTOGONAL.Categoria"%>
<%@page import="MATRIZ_ORTOGONAL.Celda"%>
<%@page import="MATRIZ_ORTOGONAL.miNodo"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
            <link href="Estilo.css" rel="stylesheet" type="text/css" />
        <title>Menu del administrador</title>
    </head>
    <body>
        <%
        final Matriz m=((Matriz)session.getAttribute("Matriz"));
        if(String.valueOf(session.getAttribute("log")).equalsIgnoreCase("out"))
            response.sendRedirect("SessionExpired.jsp");
        %>
        
        <script type="text/javascript">
         <!--
          function ShowMenu(menu) {
             var thisMenu = document.getElementById(menu);

             if (menu == "Menu1") pos = "24em";
             else if (menu == "Menu2") pos = "31em";

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
                            <h1><a>ESTRUCTURAS DE DATOS</a></h1>

                            <h3><a id="metamorph">Proyecto 1</a></h3>
                            
                            <h2><a id="metamorph">Administrando</a></h2>
                    </div>
                    <!--<div id="menu">-->
                            <ul id="menu">
                                    <li><a href="CargarXML.jsp">Cargar</a></li>
                                    
                                    <li id="Button2"><a onmouseover="ShowMenu('Menu1')"
                                    onfocus="ShowMenu('Menu1')"
                                    onmouseout="ShowMenu()">Categoría</a>
                                        <ul id="Menu1"
                                        onmouseover="ShowMenu('Menu1')"
                                        onfocus="ShowMenu('Menu1')"
                                        onmouseout="ShowMenu()"
                                        onblur="ShowMenu()">
                                            <li><a href="AddCategoria.jsp">Agregar</a></li>
                                            <li><a href="EditCategoria.jsp">Editar</a></li>
                                            <li><a href="RemoveCategoria.jsp">Eliminar</a></li>
                                        </ul>
                                    </li>
                                        
                                    <li id="Button3"><a onmouseover="ShowMenu('Menu2')"
                                    onfocus="ShowMenu('Menu2')"
                                    onmouseout="ShowMenu()">Empresa</a>
                                        <ul id="Menu2"
                                        onmouseover="ShowMenu('Menu2')"
                                        onfocus="ShowMenu('Menu2')"
                                        onmouseout="ShowMenu()"
                                        onblur="ShowMenu()">
                                            <li><a href="AddEmpresa.jsp">Agregar</a></li>
                                            <li><a href="EditEmpresa.jsp">Editar</a></li>
                                            <li><a href="RemoveEmpresa.jsp">Eliminar</a></li>
                                        </ul>
                                    </li>
                                    
                                    <li><a href="Logout.jsp">Cerrar</a></li>
                            </ul>
                    <!--</div>-->
            </div>
            <!-- header ends -->
            <!-- content begins -->
            <div id="content">
                <div id="right">
                    
                    <br>
                    <%
                    if(session.getAttribute("estadoadmin").toString()==""){
                    %>
                    <h1>Administrar</h1>			
                    <br><br>
                    <p>Para administrar los datos se puede elegir
                    las opciones del menú superior.</p>
                    <%
                    }else
                        if(session.getAttribute("estadoadmin").toString()=="ac"){
                    %>
                    <form method="post" action="AddCategoria.jsp">
                        <input type="hidden" name="action" value="submit">
                        <h1>Agregar Categoría</h1>			
                        <br><br>
                        <p>Nombre:<input type="text" name="tNom">
                        <br><br>
                        <input type="submit" value="Guardar">
                    </form>
                    <%
                    }else
                        if(session.getAttribute("estadoadmin").toString()=="ec"){
                            if(m.cat.size()==0){
                                javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"), "No existen categorias", "Error", javax.swing.JOptionPane.ERROR_MESSAGE);
                                session.setAttribute("estadoadmin","");
                                response.sendRedirect("MenuAdmin.jsp");
                            }else{
                                final javax.swing.JComboBox c=new javax.swing.JComboBox();
                                    java.util.Iterator it=m.cat.iterator();
                                    while(it.hasNext())
                                        c.addItem(((Categoria)it.next()).nombre);
                                
                                javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Seleccione la categoria"), c, "Seleccione la categoria", javax.swing.JOptionPane.PLAIN_MESSAGE);
                                session.setAttribute("nomviejo",new String(c.getSelectedItem().toString()));
                            }
                    %>
                    <form method="post" action="EditCategoria.jsp">
                        <input type="hidden" name="action" value="submit">
                        <h1>Editar Categoría</h1>			
                        <br><br>
                        <p>Nombre actual: &nbsp; <%=session.getAttribute("nomviejo").toString()%>
                        <br><br>
                        <p>Nombre nuevo:<input type="text" name="tNom">
                        <br><br>
                        <input type="submit" value="Renombrar">
                    </form>
                    <%
                    }else
                        if(session.getAttribute("estadoadmin").toString()=="rc"){
                            if(m.cat.size()==0){
                                javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"), "No existen categorias", "Error", javax.swing.JOptionPane.ERROR_MESSAGE);
                                session.setAttribute("estadoadmin","");
                                response.sendRedirect("MenuAdmin.jsp");
                            }else{
                                final javax.swing.JComboBox c=new javax.swing.JComboBox();
                                    java.util.Iterator it=m.cat.iterator();
                                    while(it.hasNext())
                                        c.addItem(((Categoria)it.next()).nombre);
                                
                                javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Seleccione la categoria"), c, "Seleccione la categoria", javax.swing.JOptionPane.PLAIN_MESSAGE);
                                session.setAttribute("nomviejo",new String(c.getSelectedItem().toString()));
                            }
                    %>
                    <form method="post" action="RemoveCategoria.jsp">
                        <input type="hidden" name="action" value="submit">
                        <h1>Borrar Categoría</h1>			
                        <br><br>
                        <p>Se borrará la categoría: &nbsp; <%=session.getAttribute("nomviejo")%>
                        <br><br>
                        <input type="submit" value="Borrar">
                    </form>
                    <%
                    }else
                        if(session.getAttribute("estadoadmin").toString()=="ae"){
                    %>
                    <form method="post" action="AddEmpresa.jsp">
                        <input type="hidden" name="action" value="submit">
                        <h1>Agregar Empresa</h1>			
                        <br><br>
                        <p>Nombre:<input type="text" name="tNom">
                        <br><br>
                        <p>Descripción:<input type="text" name="tDes">
                        <br><br>
                        <p>Dirección:<input type="text" name="tDir">
                        <br><br>
                        <p>Teléfono:<input type="text" name="tTel">
                        <br><br>
                        <p>Sitio web:<input type="text" name="tPag">
                        <br><br>
                        <p>Logo:<input type="text" name="tLog">
                        <br><br>
                        <p>Categoría:<input type="text" name="tCat">
                        <br><br>
                        <input type="submit" value="Guardar">
                    </form>
                    <%
                    }else
                        if(session.getAttribute("estadoadmin").toString()=="ee"){
                            miNodo empv=new miNodo("","","","","","","","");
                            if(m.cat.size()==0){
                                javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"), "No existen categorias", "Error", javax.swing.JOptionPane.ERROR_MESSAGE);
                                session.setAttribute("estadoadmin","");
                                response.sendRedirect("MenuAdmin.jsp");
                            }else{
                                final javax.swing.JComboBox c[]=new javax.swing.JComboBox[2];
                                c[0]=new javax.swing.JComboBox();
                                    java.util.Iterator it=m.cat.iterator();
                                    while(it.hasNext()){
                                        Categoria ctmp=(Categoria)it.next();
                                        if(ctmp.listado.size()>0)
                                            c[0].addItem(ctmp.nombre);
                                    }
                                c[1]=new javax.swing.JComboBox();
                                
                                c[0].addItemListener(new java.awt.event.ItemListener() {
                                    public void itemStateChanged(java.awt.event.ItemEvent evt) {
                                        c[1].removeAllItems();
                                        java.util.Iterator itm=m.cat.iterator();
                                        Categoria cat_actual;
                                        while(!(cat_actual=(Categoria)itm.next()).nombre.equalsIgnoreCase(c[0].getSelectedItem().toString())){}
                                        java.util.Iterator it=cat_actual.listado.iterator();
                                        while(it.hasNext()){
                                            java.util.Iterator it2=((Celda)it.next()).empresa.iterator();
                                            while(it2.hasNext())
                                                c[1].addItem(((miNodo)it2.next()).nombre);
                                        }
                                    }
                                });
                                
                                if(c[0].getItemCount()==0){
                                    javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"), "No existen empresas", "Error", javax.swing.JOptionPane.ERROR_MESSAGE);
                                    session.setAttribute("estadoadmin","");
                                    response.sendRedirect("MenuAdmin.jsp");
                                }else{
                                    c[0].getItemListeners()[0].itemStateChanged(null);
                                    javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Seleccione la empresa"), c, "Seleccione la empresa", javax.swing.JOptionPane.PLAIN_MESSAGE);
                                    String nv=c[1].getSelectedItem().toString();
                                    String cv=c[0].getSelectedItem().toString();

                                    java.util.Iterator itcat=m.cat.iterator();
                                    Categoria cattmp;
                                    while(!(cattmp=(Categoria)itcat.next()).nombre.equalsIgnoreCase(cv)){}
                                    java.util.Iterator itcel=cattmp.listado.iterator();
                                    Celda ctmp;
                                    while(!(ctmp=(Celda)itcel.next()).letra.toString().equalsIgnoreCase(String.valueOf(nv.charAt(0))));
                                    java.util.Iterator itemp=ctmp.empresa.iterator();
                                    while(!(empv=(miNodo)itemp.next()).nombre.equalsIgnoreCase(nv)){}

                                    session.setAttribute("nomviejo",nv);
                                    session.setAttribute("catvieja",cv);
                                }
                            }
                    %>
                    <form method="post" action="EditEmpresa.jsp">
                        <input type="hidden" name="action" value="submit">
                        <h1>Editar Empresa</h1>
                        <br><br>
                        <p>Descripción:<input type="text" name="tDes"> &nbsp; valor anterior: &nbsp;<%=empv.comentario%>
                        <br><br>
                        <p>Dirección:<input type="text" name="tDir"> &nbsp; valor anterior: &nbsp;<%=empv.direccion%>
                        <br><br>
                        <p>Teléfono:<input type="text" name="tTel"> &nbsp; valor anterior: &nbsp;<%=empv.telefono%>
                        <br><br>
                        <p>Sitio web:<input type="text" name="tPag"> &nbsp; valor anterior: &nbsp;<%=empv.pagina%>
                        <br><br>
                        <p>Logo:<input type="text" name="tLog"> &nbsp; valor anterior: &nbsp;<%=empv.logo%>
                        <br><br>
                        <input type="submit" value="Editar">
                    </form>
                    <%
                    }else
                        if(session.getAttribute("estadoadmin").toString()=="re"){
                            miNodo empv=new miNodo("","","","","","","","");
                            if(m.cat.size()==0){
                                javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"), "No existen categorias", "Error", javax.swing.JOptionPane.ERROR_MESSAGE);
                                session.setAttribute("estadoadmin","");
                                response.sendRedirect("MenuAdmin.jsp");
                            }else{
                                final javax.swing.JComboBox c[]=new javax.swing.JComboBox[2];
                                c[0]=new javax.swing.JComboBox();
                                    java.util.Iterator it=m.cat.iterator();
                                    while(it.hasNext()){
                                        Categoria ctmp=(Categoria)it.next();
                                        if(ctmp.listado.size()>0)
                                            c[0].addItem(ctmp.nombre);
                                    }
                                c[1]=new javax.swing.JComboBox();
                                
                                c[0].addItemListener(new java.awt.event.ItemListener() {
                                    public void itemStateChanged(java.awt.event.ItemEvent evt) {
                                        c[1].removeAllItems();
                                        java.util.Iterator itm=m.cat.iterator();
                                        Categoria cat_actual;
                                        while(!(cat_actual=(Categoria)itm.next()).nombre.equalsIgnoreCase(c[0].getSelectedItem().toString())){}
                                        java.util.Iterator it=cat_actual.listado.iterator();
                                        while(it.hasNext()){
                                            java.util.Iterator it2=((Celda)it.next()).empresa.iterator();
                                            while(it2.hasNext())
                                                c[1].addItem(((miNodo)it2.next()).nombre);
                                        }
                                    }
                                });
                                
                                if(c[0].getItemCount()==0){
                                    javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"), "No existen empresas", "Error", javax.swing.JOptionPane.ERROR_MESSAGE);
                                    session.setAttribute("estadoadmin","");
                                    response.sendRedirect("MenuAdmin.jsp");
                                }else{
                                    c[0].getItemListeners()[0].itemStateChanged(null);
                                    javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Seleccione la empresa"), c, "Seleccione la empresa", javax.swing.JOptionPane.PLAIN_MESSAGE);
                                    String nv=c[1].getSelectedItem().toString();
                                    String cv=c[0].getSelectedItem().toString();

                                    java.util.Iterator itcat=m.cat.iterator();
                                    Categoria cattmp;
                                    while(!(cattmp=(Categoria)itcat.next()).nombre.equalsIgnoreCase(cv)){}
                                    java.util.Iterator itcel=cattmp.listado.iterator();
                                    Celda ctmp;
                                    while(!(ctmp=(Celda)itcel.next()).letra.toString().equalsIgnoreCase(String.valueOf(nv.charAt(0))));
                                    java.util.Iterator itemp=ctmp.empresa.iterator();
                                    while(!(empv=(miNodo)itemp.next()).nombre.equalsIgnoreCase(nv)){}

                                    session.setAttribute("nomviejo",nv);
                                    session.setAttribute("catvieja",cv);
                                }
                            }
                    %>
                    <form method="post" action="RemoveEmpresa.jsp">
                        <input type="hidden" name="action" value="submit">
                        <h1>Borrar Empresa</h1>			
                        <br><br>
                        Se borrará la empresa con los siguientes datos:
                        <br><br>
                        <p>Nombre: &nbsp;<%=empv.nombre%>
                        <br><br>
                        <p>Categoría: &nbsp;<%=empv.categoria%>
                        <br><br>
                        <p>Descripción: &nbsp;<%=empv.comentario%>
                        <br><br>
                        <p>Dirección: &nbsp;<%=empv.direccion%>
                        <br><br>
                        <p>Teléfono: &nbsp;<%=empv.telefono%>
                        <br><br>
                        <p>Sitio web: &nbsp;<%=empv.pagina%>
                        <br><br>
                        <p>Logo: &nbsp;<%=empv.logo%>
                        <br><br>
                        **Nota: al borrar todas las empresas de una categoría
                        la categoria no se borra automáticamente;<br>se deberá
                        hacer manualmente**<br>
                        <input type="submit" value="Borrar">
                    </form>
                    <%
                    }
                    %>
                    <br><br>
                    <p>No olvide cerrar su sesión al finalizar los cambios<br><br>
                    <a href="Menu.jsp">Ir al menú sin salir de sesión</a></p>
                    <br>
                            
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
