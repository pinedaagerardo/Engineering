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
        <div style="margin-top: 100px; margin-left: 300px;">
            <form action="agregarcarro.php" method="post" style="margin-top: 100px;">
                <pre>
                Producto: <select name="idproducto">
                    <?php
                    $conn=conectar();
                    $sql=getproducto();
                    $res=consultar($conn, $sql);
                    while(odbc_fetch_row($res)){
                        echo "<option value=\"".  odbc_result($res, 1)."\">".  odbc_result($res, 2)."</option>";
                        echo "\n";
                    }
                    liberar($res);
                    desconectar($conn);
                    ?>
                </select><br/>
                Tipo de entrega: <select name="idtipoentrega">
                    <?php
                    $conn=conectar();
                    $sql=gettipoentrega();
                    $res=consultar($conn, $sql);
                    while(odbc_fetch_row($res)){
                        echo "<option value=\"".  odbc_result($res, 1)."\">".  odbc_result($res, 2)."</option>";
                        echo "\n";
                    }
                    liberar($res);
                    desconectar($conn);
                    ?>
                </select><br/>
                Forma de pago: <select name="idtipopago">
                    <?php
                    $conn=conectar();
                    $sql=  gettipopago();
                    $res=consultar($conn, $sql);
                    while(odbc_fetch_row($res)){
                        echo "<option value=\"".  odbc_result($res, 1)."\">".  odbc_result($res, 2)."</option>";
                        echo "\n";
                    }
                    liberar($res);
                    desconectar($conn);
                    ?>
                </select><br/>
                Tarjeta: <select name="notarjeta">
                    <?php
                    $conn=conectar();
                    $sql=  gettarjeta();
                    $res=consultar($conn, $sql);
                    while(odbc_fetch_row($res)){
                        echo "<option value=\"".  odbc_result($res, 'notarjeta')."\">".  odbc_result($res, 'notarjeta')."/".odbc_result($res, 15)."/".odbc_result($res, 'nombre')." ".odbc_result($res, 'apellido')."</option>";
                        echo "\n";
                    }
                    liberar($res);
                    desconectar($conn);
                    ?>
                </select><br/>
                No. documento: <input type="text" name="nodoc"/><br/>
                <input style="margin-top: 20px;" type="submit" value="Guardar"/><br/>
                </pre>
            </form>
            <a style="margin-left: 500px;" href="menu.php">Volver</a>
        </div>
    </body>
</html>
