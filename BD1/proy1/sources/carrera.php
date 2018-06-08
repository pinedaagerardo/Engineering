<?php
if(session_id() == '') {
    session_start();
}
include 'sqlman.php';

$con=conectar();
//CARRERA
$sql="SELECT C.NOMBRE CARRERA,C.DESCRIPCION,C.PENSUM,E.NOMBRE ESCUELA,E.UBICACION FROM CARRERA C,ESCUELA E WHERE UPPER(C.NOMBRE) LIKE '%ELECTR%NICA' AND E.IDESCUELA=C.IDESCUELA;";
$res=consultar($sql);
$row = mysql_fetch_array($res);
$_SESSION['cdescripcion']=$row['DESCRIPCION'];
$_SESSION['cpensum']=$row['PENSUM'];
$_SESSION['escuela']=$row['ESCUELA'];
$_SESSION['ubicacion']=$row['UBICACION'];

//POSTGRADOS
$sql="SELECT P.NOMBRE FROM POSTGRADO P;";
$res=consultar($sql);
$i=0;
while($row = mysql_fetch_array($res)){
    $postgrado[$i++]=$row['NOMBRE'];
}
$_SESSION['postgrado']=$postgrado;

//AREAS
$sql="SELECT A.NOMBRE FROM AREAPROFESIONAL A;";
$res=consultar($sql);
$i=0;
while($row = mysql_fetch_array($res)){
    $area[$i++]=$row['NOMBRE'];
}
$_SESSION['area']=$area;

//NOMBRE USUARIO
$sql="SELECT U.NOMBRE FROM USUARIO U WHERE CARNET=\"".$_SESSION['usuario']."\";";
$res=consultar($sql);
$row = mysql_fetch_array($res);
$_SESSION['nombreusuario']=$row['NOMBRE'];
desconectar($con);

header('Location: aprobar.php?curso=&accion=0');
?>
