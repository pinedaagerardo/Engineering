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
            <h1>Agregar Tarjetas</h1>
            <form action="guardartarjetas.php" method="post" style="margin-top: 100px;">
                <pre>
                Tipo de tarjeta:                        <select name="idtipotarjeta">
                    <?php
                    $conn=conectar();
                    $sql=gettipotarjeta();
                    $res=consultar($conn, $sql);
                    while(odbc_fetch_row($res)){
                        echo "<option value=\"".  odbc_result($res, 1)."\">".  odbc_result($res, 2)."</option>";
                        echo "\n";
                    }
                    liberar($res);
                    desconectar($conn);
                    ?>
                </select><br/>
                Cliente:                                <select name="idpersona">
                    <?php
                    $conn=conectar();
                    $sql=getpersona();
                    $res=consultar($conn, $sql);
                    while(odbc_fetch_row($res)){
                        echo "<option value=\"".  odbc_result($res, 1)."\">".  odbc_result($res, 2)."</option>";
                        echo "\n";
                    }
                    liberar($res);
                    desconectar($conn);
                    ?>
                </select><br/>
                Número de tarjeta:                      <input type="text" name="notarjeta"/><br/>
                Código de autorización:                 <input type="text" name="codautoriz"/><br/>
                <input style="margin-top: 20px;" type="submit" value="Guardar"/><br/>
                </pre>
            </form>
            <a style="margin-left: 500px;" href="personas.php">Volver</a>
        </div>
    </body>
</html>
