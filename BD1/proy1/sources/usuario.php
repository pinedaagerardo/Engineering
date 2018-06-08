<?php
session_start();
include 'sqlman.php';

$carnet=$_POST['carnet'];
$clave=$_POST['clave'];
$tipo=$_POST['tipo'];
/* tipo=0 - entrar
 * tipo=1 - crear usuario
 */
if($tipo==0){
    $con=conectar();
    $sql="SELECT CONTRASENIA FROM USUARIO WHERE CARNET=\"$carnet\";";
    $res=consultar($sql);
    $row = mysql_fetch_array($res);
    desconectar($con);
    if($clave==$row['CONTRASENIA']){
        $_SESSION['usuario']=$carnet;
        header('Location: carrera.php');
    }else
        header('Location: login.php');
}
if($tipo==1){
    $correo=$_POST['correo'];
    $nombre=$_POST['nombre'];
    $con=conectar();
    $sql="INSERT INTO USUARIO VALUES(\"$carnet\",\"$nombre\",\"$clave\",\"$correo\");";
    ejecutar($sql);
    desconectar($con);
    header('Location: login.php');
}
?>
