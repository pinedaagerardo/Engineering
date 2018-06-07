<%-- 
    Document   : CargarXML
    Created on : 18/03/2008, 12:51:11 AM
    Author     : gerardo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="org.jdom.*"%>
<%@page import="org.jdom.input.*"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

<%
if(session.getAttribute("log").toString().equalsIgnoreCase("out"))
    response.sendRedirect("SessionExpired.jsp");
else{
    session.setAttribute("estadoadmin", "");
    javax.swing.JFileChooser fc=new javax.swing.JFileChooser();

    javax.swing.filechooser.FileFilter ff=new javax.swing.filechooser.FileFilter() {
    public boolean accept(java.io.File f) {
        return f.isDirectory() || f.getName().toLowerCase().endsWith(".xml");
    }
    public String getDescription() {
        return (".xml");
    }
    };

    fc.addChoosableFileFilter(ff);
    try {
    int y=fc.showOpenDialog(new javax.swing.JFrame("Cargar archivo xml"));
    if(fc.getSelectedFile()==null) response.sendRedirect("MenuAdmin.jsp");
    if(y==javax.swing.JFileChooser.APPROVE_OPTION)
        if (fc.getSelectedFile().getName().toLowerCase().endsWith(".xml")){
            String path = fc.getSelectedFile().getAbsolutePath().toString();

            /**********************xml begin********************/
            SAXBuilder builder = new SAXBuilder();
            Document doc = builder.build(new java.io.File(path));
            java.util.List lista=doc.getRootElement().getChildren();
            for(int i=0;i<lista.size();i++){
                try{
                    Element elem=(Element)lista.get(i);

                    String categ=elem.getAttributeValue("categoria");
                    String nom=elem.getChild("nombre").getText();
                    String desc=elem.getChild("descripcion").getText();
                    String dir=elem.getChild("direccion").getText();
                    String tel=elem.getChild("telefono").getText();
                    String pag=elem.getChild("sitio").getText();
                    String lo=elem.getChild("logo").getText();

                    ((HERRAMIENTAS.Matriz)session.getAttribute("matriz")).addEmpresa(nom.toLowerCase(), desc, dir, tel, pag, lo, categ, String.valueOf(nom.toLowerCase().charAt(0)));
                    }catch(java.lang.NullPointerException e){
                        javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"),"Error - el archivo no está completo","Error",javax.swing.JOptionPane.ERROR_MESSAGE);
                    }catch(Exception e){
                        javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"),"Error - "+e.getMessage(),"Error",javax.swing.JOptionPane.ERROR_MESSAGE);
                    }
            }
            /**********************xml end*********************/

            javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Información"),"Terminó la carga del archivo","Información",javax.swing.JOptionPane.INFORMATION_MESSAGE);
            response.sendRedirect("MenuAdmin.jsp");

        }else{
            response.sendRedirect("CargarXML.jsp");
        }
    }catch(java.io.IOException e){
        javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"),"Error de carga - "+e.getMessage(),"Error",javax.swing.JOptionPane.ERROR_MESSAGE);
        response.sendRedirect("MenuAdmin.jsp");
    }catch(Exception e){
        javax.swing.JOptionPane.showMessageDialog(new javax.swing.JFrame("Error"),"Error en el archivo xml - "+e.getMessage(),"Error",javax.swing.JOptionPane.ERROR_MESSAGE);
        response.sendRedirect("MenuAdmin.jsp");
    }
}
%>
