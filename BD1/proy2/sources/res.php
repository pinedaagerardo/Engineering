<?php
include 'scripts.php';

$reporte=$_POST['reporte'];
$conn=conectar();

if($reporte=='1'){
    $res=reporte1($conn);
    odbc_result_all($res,"border=1");
}
if($reporte=='2'){
    $res=reporte2($conn);
    odbc_result_all($res,"border=1");
}
if($reporte=='3'){
    $res=reporte3($conn,$_POST['inicio'],$_POST['fin']);
    odbc_result_all($res,"border=1");
}
if($reporte=='4'){
    $res=reporte4($conn);
    odbc_result_all($res,"border=1");
}
if($reporte=='5'){
    $res=reporte5($conn,$_POST['inicio'],$_POST['fin'],$_POST['cargamento'],$_POST['lote'],$_POST['caja']);
    odbc_result_all($res,"border=1");
}
if($reporte=='6'){
    $res=reporte6($conn);
    odbc_result_all($res,"border=1");
}
if($reporte=='7a'){
    $res=reporte7a($conn);
    odbc_result_all($res,"border=1");
}
if($reporte=='7b'){
    $res=reporte7b($conn);
    odbc_result_all($res,"border=1");
}
if($reporte=='8'){
    $factura=$_POST['factura'];
    $idventa=substr($factura, 0,-8);
    $fecha=substr($factura, -8, 2)."/".substr($factura, -6, 2)."/".substr($factura, -4);
    $res=reporte8($conn,$idventa,$fecha);
    odbc_result_all($res,"border=1");
}

liberar($res);
desconectar($conn);

echo "<br/>";
echo "<a href=\"reportes.php\">Volver</a>";
?>
