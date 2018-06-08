<?php
include 'sqlman.php';

$conn=conectar();

//insertando nueva tarjeta
$sql="insert into tarjeta values('$_POST[notarjeta]',$_POST[idpersona],2000,'$_POST[codautoriz]',$_POST[idtipotarjeta])";
ejecutar($conn, $sql);

desconectar($conn);
header("location:/proyecto2/tarjetas.php");
?>
