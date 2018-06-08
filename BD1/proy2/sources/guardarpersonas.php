<?php
include 'sqlman.php';

$conn=conectar();

//tomando máximo id de la tabla
$sql='select nvl(max(idpersona),0)+1 id from persona';
$res=consultar($conn, $sql);
odbc_fetch_row($res);
$id=odbc_result($res, 1);
liberar($res);

//insertando nueva persona
$sql="insert into persona values($id,$_POST[nit],'$_POST[nombre]','$_POST[apellido]',$_POST[edad],'$_POST[sexo]','$_POST[direccionentrega]','$_POST[direccionfacturacion]',$_POST[idtipopersona])";
ejecutar($conn, $sql);

desconectar($conn);
header("location:/proyecto2/personas.php");
?>
