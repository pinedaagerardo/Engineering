<%-- 
    Document   : BxEmpresa
    Created on : 20/03/2008, 02:47:43 AM
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
        <title>Búsqueda</title>
    </head>
    <body>
        <div id="main">
            <!-- header begins -->
            <div id="header">
                    <div id="logo">
                            <h1><a>ESTRUCTURAS DE DATOS</a></h1>

                            <h3><a id="metamorph">Proyecto 1</a></h3>
                            
                            <h2><a id="metamorph">Búsqueda por empresa</a></h2>
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
<%
Matriz m=((Matriz)session.getAttribute("Matriz"));
if(m.cat.size()==0){
    javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"), "No existen categorias", "Error", javax.swing.JOptionPane.ERROR_MESSAGE);
    response.sendRedirect("Menu.jsp");
}else{
    final javax.swing.JComboBox c=new javax.swing.JComboBox();
    java.util.Vector v=new java.util.Vector(),empresas=new java.util.Vector();
        java.util.Iterator it=m.cat.iterator();
        while(it.hasNext()){
            Categoria cat=(Categoria)it.next();
            java.util.Iterator itcel=cat.listado.iterator();
            while(itcel.hasNext()){
                Celda cel=(Celda)itcel.next();
                java.util.Iterator itemp=cel.empresa.iterator();
                while(itemp.hasNext()){
                    miNodo e=(miNodo)itemp.next();
                    empresas.addElement(e);
                    if(v.indexOf(e.nombre)==-1){
                        v.addElement(e.nombre);
                        c.addItem(e.nombre);
                    }
                }
            }
        }
        if(c.getItemCount()==0){
            javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"), "No existen empresas", "Error", javax.swing.JOptionPane.ERROR_MESSAGE);
            response.sendRedirect("Menu.jsp");
        }else{

            javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Seleccione la categoria"), c, "Seleccione la empresa", javax.swing.JOptionPane.PLAIN_MESSAGE);
            String c_nom=new String(c.getSelectedItem().toString());

            for(int i=0;i<empresas.size();i++){
                miNodo Etmp=((miNodo)empresas.elementAt(i));
                if(c_nom.equalsIgnoreCase(Etmp.nombre)){
                %>
                <br>
                <form method="post" action="BespecialC.jsp">
                <input type="hidden" name="Hcat" value="<%=Etmp.categoria%>">
                <h1>Categoria: &nbsp; <input type="submit" value="<%=Etmp.categoria%>"></h1>
                </form>
                <br><br>

                <%=Etmp.nombre%><br>
                <%=Etmp.comentario%><br>
                <%=Etmp.direccion%><br>
                <%=Etmp.telefono%><br>
                <%=Etmp.pagina%><br>
                <div class="pic"><img src="<%=Etmp.logo%>" alt="" /></div>&nbsp;<%=Etmp.logo%>
                <br><br>
                <%
                }
            }
        }
}
%>
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