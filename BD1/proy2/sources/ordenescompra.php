<?php
include 'scripts.php';
?>
<!--
To change this template, choose Tools | Templates
and open the template in the editor.
-->
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title></title>
    </head>
    <body>
        <div style="margin-top: 100px; margin-left: 300px; margin-right: 300px;">
            <h1>Ordenes de compra</h1>
            <?php
            $conn=conectar();
            $sql=getordencompra();
            $res=consultar($conn, $sql);
            odbc_result_all($res,"border=1");
            liberar($res);
            desconectar($conn);
            ?>
        </div><br/><br/>
        <a style="margin-left: 350px;" href="menu.php">Volver al menú</a>
    </body>
</html>
