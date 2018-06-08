<?php
include 'scripts.php';

$conn=conectar();


/**
$sql="insert into tipounidad values(2,'U')";
ejecutar($conn, $sql);
/**/


/**/
$sql="select * from externa";
$res=consultar($conn, $sql);
odbc_result_all($res,"border=1 style=\"margin-left: 200px; margin-top: 100px;\"");
/*while(odbc_fetch_row($res)){
    echo odbc_result($res, "idtipopersona");
    echo " - ";
    echo odbc_result($res, 2);
    echo "<br/>";
}
/**/
liberar($res);
/**/
/**/



desconectar($conn);
?>
