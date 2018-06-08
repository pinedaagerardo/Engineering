<?php
session_start();
$_SESSION['curso']=$_GET['curso'];
?>
<!--
To change this template, choose Tools | Templates
and open the template in the editor.
-->
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Bases de datos 1</title>
        <script>
            /*
             * Al recargar la página muestra información del curso seleccionado
             * y muestra los post-requisitos
             */
            window.onload=function WindowLoad() {
                <?php
                if(isset ($_SESSION['curso']) && $_SESSION['curso']!=""){
                    echo "VerInfo(".$_SESSION['curso'].");";
                    echo "Pintar(".$_SESSION['curso'].");";
                    if(isset ($_SESSION['estado']) && $_SESSION['estado']!="0" && $_SESSION['estado']!="") //aprobado=1, else=0
                        echo "MostrarDisponibles();";
                }
                echo "verAprobados();";
                ?>
            }
            
            /*
             * colorea los cursos aprobados
             */
            function verAprobados(){
                <?php
                if(isset ($_SESSION['aprobados']) && $_SESSION['aprobados']!=""){
                    for($i=0; $i<count($_SESSION['aprobados']);$i++){
                        echo "celda=document.getElementById(".$_SESSION['aprobados'][$i].");";
                        echo "celda.style.background='lightblue';";
                    }
                }
                ?>
            }
            
            /*
             *  Aprueba un curso
             */
            function Aprobar(){
                <?php
                if($_SESSION['curso']==""){
                    echo "alert(\"Selecciona un curso primero\");";
                    echo "return;";
                }
                echo "window.location.replace('aprobar.php?curso=".$_SESSION['curso']."&accion=1');";
                ?>
            }
            
            /*
             *  Desaprueba un curso
             */
            function Desaprobar(){
                <?php
                if($_SESSION['curso']==""){
                    echo "alert(\"Selecciona un curso primero\");";
                    echo "return;";
                }
                echo "window.location.replace('aprobar.php?curso=".$_SESSION['curso']."&accion=2');";
                ?>
            }
            
            /*
             * Selecciona el curso recibido (rojo) y limpia cualquier
             * selección hecha anteriormente
             */
            function Pintar(curso){
                celda=document.getElementById(curso);
                if(celda.style.borderColor=='red') return;
                Limpiar();
                celda.style.borderColor='red';
            }
            
            /*
             * Selecciona el curso recibido y carga los cursos post-requisito
             */
            function SeleccionarCurso(curso){
                window.location.replace('sinc.php?curso='+curso);
            }
            
            /*
             * Muestra la información del curso recibido
             */
            function VerInfo(curso){
                var contenedor;
                contenedor = document.getElementById('informacion');
                ajax=nuevoAjax();
                ajax.open("POST", "contenedor.php",true);
                ajax.onreadystatechange=function() {
                    if (ajax.readyState==4) {
                        contenedor.innerHTML = ajax.responseText
                    }
                }
                ajax.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                sql=new Array();
                sql[0]="SELECT C.*,REPLACE(R.PRE,"+curso+",0) AS PRE,REPLACE(R.POST,"+curso+",0) AS POST FROM CURSO C,REQUISITO R WHERE (C.IDCURSO=R.POST OR C.IDCURSO=R.PRE) AND C.IDCURSO="+curso+";";
                sql[1]="SELECT I.VALOR,AM.NOMBRE FROM CURSO_MATERIAL CM,INFOMATERIAL I,CLASIFMATERIAL CFM,MATERIALAPOYO MA,ATRIBUTOMATERIAL AM WHERE I.IDMATERIAL=CM.IDMATERIAL AND MA.IDCLASIF=CFM.IDCLASIF AND MA.IDMATERIAL=CM.IDMATERIAL AND AM.IDATRIBUTO=I.IDATRIBUTO AND UPPER(CFM.NOMBRE) = \"LIBRO\" AND CM.IDCURSO="+curso+" ORDER BY I.IDMATERIAL,I.IDATRIBUTO;";
                sql[2]="SELECT I.VALOR,AM.NOMBRE FROM CURSO_MATERIAL CM,INFOMATERIAL I,CLASIFMATERIAL CFM,MATERIALAPOYO MA,ATRIBUTOMATERIAL AM WHERE I.IDMATERIAL=CM.IDMATERIAL AND MA.IDCLASIF=CFM.IDCLASIF AND MA.IDMATERIAL=CM.IDMATERIAL AND AM.IDATRIBUTO=I.IDATRIBUTO AND UPPER(CFM.NOMBRE) = \"EJEMPLO\" AND CM.IDCURSO="+curso+" ORDER BY I.IDMATERIAL,I.IDATRIBUTO;";
                ajax.send("curso="+curso+"&sql0="+sql[0]+"&sql1="+sql[1]+"&sql2="+sql[2]);
                /*sql0: curso, pre y post
                 *sql1: información de libros
                 *sql2: información de ejemplos*/
            }
            
            /*
             * Muestra los cursos disponibles a partir del curso recibido
             * (verde)
             */
            function MostrarDisponibles(){
                <?php
                for($i=0; $i<$_SESSION['cant']; $i++){
                    echo "document.getElementById(".$_SESSION['disponibles'][$i].").style.borderColor='lightgreen';";
                }
                $_SESSION['cant']=0;
                ?>
            }
            
            /*
             * AJAX
             */
            function nuevoAjax(){
                var xmlhttp=false;
                try {
                    xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
                } catch (e) {
                    try {
                        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                    } catch (E) {
                        xmlhttp = false;
                    }
                }

                if (!xmlhttp && typeof XMLHttpRequest!='undefined') {
                    xmlhttp = new XMLHttpRequest();
                }
                return xmlhttp;
            }
            
            /*
             * Limpia todas las celdas a negro (default)
             */
            function Limpiar(){
                var tabla = document.getElementById("tabla");
                var celdas = tabla.getElementsByTagName("td");
                for(var i=0; i<celdas.length; i++)
                    celdas[i].style.borderColor='black';
            }
        </script>
    </head>
    <body">
        <div style="width: 75%; margin: 0px auto; text-align: right;">
            Bienvenido, <?php echo $_SESSION['nombreusuario']; ?><a href="login.php" style="padding-left: 75px;">Desconectarse</a>
        </div>
        <div style="width: 50%; margin: 0px auto;">
            <h1><center>Ingenieria Electronica</center></h1>
            <?php echo $_SESSION['cdescripcion']; ?><br/><br/>
            <a href="<?php echo $_SESSION['cpensum']; ?>" target="_blank">Pensum</a><br/><br/>
            Escuela: <?php echo $_SESSION['escuela']; ?>, <?php echo $_SESSION['ubicacion']; ?><br/><br/>
            <table>
                <tr>
                    <td>
                        <h3>Postgrados:</h3>
                        <?php
                        for($i=0; $i<count($_SESSION['postgrado']); $i++)
                            echo $_SESSION['postgrado'][$i]."<br/>";
                        ?>
                    </td>
                    <td style="padding-left: 100px;"></td>
                    <td>
                        <h3>Areas profesionales:</h3>
                        <?php
                        for($i=0; $i<count($_SESSION['area']); $i++)
                            echo $_SESSION['area'][$i]."<br/>";
                        ?>
                    </td>
                </tr>
            </table>
        </div>
        <div style="padding-top: 50px; width: 75%; margin: 0px auto;">
            <h2>Creditos actuales: <?php echo $_SESSION['creditosactuales']; ?></h2>
            <font size="2">
                <table id="tabla">
                    <tr>
                        <td><h2>SEM 1</h2></td>
                        <td><h2>SEM 2</h2></td>
                        <td><h2>SEM 3</h2></td>
                        <td><h2>SEM 4</h2></td>
                        <td><h2>SEM 5</h2></td>
                    </tr>
                    <tr>
                        <td style="width: 150px;"></td>
                        <td id="769" style="border: 3px black solid; height: 30px;" onclick="SeleccionarCurso('769')">Intro a la programación<br/>de computadoras 1</td>
                        <td id="991" style="border: 3px black solid;" onclick="SeleccionarCurso('991')">Lenguajes de progra.<br/>aplicados a la ing. electrica</td>
                        <td id="73" style="border: 3px black solid;" onclick="SeleccionarCurso('73')">Dibujo tecnico mecanico</td>
                        <td id="204" style="border: 3px black solid;" onclick="SeleccionarCurso('204')">Circuitos electricos 1</td>
                    </tr>
                    <tr>
                        <td style="height: 30px;"></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td id="462" style="border: 3px black solid;" onclick="SeleccionarCurso('462')">Electricidad y electronica<br/>basica</td>
                    </tr>
                    <tr>
                        <td style="padding-top: 50px;"></td>
                    </tr>
                    <tr>
                        <td style="height: 30px;"></td>
                        <td><h2>SEM 6</h2></td>
                        <td><h2>SEM 7</h2></td>
                        <td><h2>SEM 8</h2></td>
                        <td><h2>SEM 9</h2></td>
                        <td><h2>SEM 10</h2></td>
                    </tr>
                    <tr>
                        <td style="height: 30px;"></td>
                        <td></td>
                        <td id="242" style="border: 3px black solid;" onclick="SeleccionarCurso('242')">Comunicaciones 1</td>
                        <td id="211" style="border: 3px black solid;" onclick="SeleccionarCurso('211')">Teoria electromagnetica 2</td>
                        <td id="969" style="border: 3px black solid;" onclick="SeleccionarCurso('969')">Telecomunicaciones<br/>y redes locales</td>
                        <td id="241" style="border: 3px black solid;" onclick="SeleccionarCurso('241')">Radiocomunicaciones<br/>terrestres</td>
                    </tr>
                    <tr>
                        <td style="height: 30px;"></td>
                        <td></td>
                        <td></td>
                        <td id="980" style="border: 3px black solid;" onclick="SeleccionarCurso('980')">Proyecto de comp<br/>aplicados a ing elec</td>
                        <td id="245" style="border: 3px black solid;" onclick="SeleccionarCurso('245')">Comunicaciones 3</td>
                        <td id="243" style="border: 3px black solid;" onclick="SeleccionarCurso('243')">Comunicaciones 4</td>
                    </tr>
                    <tr>
                        <td style="height: 30px;"></td>
                        <td></td>
                        <td></td>
                        <td id="244" style="border: 3px black solid;" onclick="SeleccionarCurso('244')">Comunicaciones 2</td>
                    </tr>
                    <tr>
                        <td style="height: 30px;"></td>
                        <td></td>
                        <td id="246" style="border: 3px black solid;" onclick="SeleccionarCurso('246')">Electronica 3</td>
                        <td id="248" style="border: 3px black solid;" onclick="SeleccionarCurso('248')">Electronica 5</td>
                        <td id="233" style="border: 3px black solid;" onclick="SeleccionarCurso('233')">Electronica aplicada 1</td>
                        <td id="235" style="border: 3px black solid;" onclick="SeleccionarCurso('235')">Robotica</td>
                    </tr>
                    <tr>
                        <td style="height: 30px;"></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td id="249" style="border: 3px black solid;" onclick="SeleccionarCurso('249')">Electronica 6</td>
                        <td id="239" style="border: 3px black solid;" onclick="SeleccionarCurso('239')">Electronica aplicada 2</td>
                    </tr>
                    <tr>
                        <td style="height: 30px;"></td>
                        <td id="232" style="border: 3px black solid;" onclick="SeleccionarCurso('232')">Electronica 1</td>
                        <td id="240" style="border: 3px black solid;" onclick="SeleccionarCurso('240')">Electronica 2</td>
                        <td id="234" style="border: 3px black solid;" onclick="SeleccionarCurso('234')">Electronica 4</td>
                        <td id="236" style="border: 3px black solid;" onclick="SeleccionarCurso('236')">Sistemas de control 1</td>
                        <td id="209" style="border: 3px black solid;" onclick="SeleccionarCurso('209')">Instalacion de<br/>equipos electronicos</td>
                    </tr>
                    <tr>
                        <td style="height: 30px;"></td>
                        <td id="206" style="border: 3px black solid;" onclick="SeleccionarCurso('206')">Circuitos electricos 2</td>
                        <td id="230" style="border: 3px black solid;" onclick="SeleccionarCurso('230')">Instrumentacion electrica</td>
                        <td id="218" style="border: 3px black solid;" onclick="SeleccionarCurso('218')">Lineas de<br/>transmision</td>
                        <td id="214" style="border: 3px black solid;" onclick="SeleccionarCurso('214')">Maquinas electricas</td>
                        <td id="238" style="border: 3px black solid;" onclick="SeleccionarCurso('238')">Automatizacion<br/>industrial</td>
                    </tr>
                    <tr>
                        <td style="height: 30px;"></td>
                        <td id="210" style="border: 3px black solid;" onclick="SeleccionarCurso('210')">Teoria electromagnetica 1</td>
                        <td id="212" style="border: 3px black solid;" onclick="SeleccionarCurso('212')">Conv de energia<br/>electomec 1</td>
                        <td></td>
                        <td id="601" style="border: 3px black solid;" onclick="SeleccionarCurso('601')">Investigacion de<br/>operaciones 1</td>
                    </tr>
                </table>
            </font>
            <div style="padding-top: 25px; padding-bottom: 25px;">
                <button onclick="Aprobar()">Aprobar</button>
                <button onclick="Desaprobar()">Desaprobar</button>
            </div>
        </div>
        
        <div id="informacion" style="border: 1px black solid; width: 50%; margin: 0px auto; padding-top: 50px; padding-left: 50px;">
            
        </div>
    </body>
</html>
