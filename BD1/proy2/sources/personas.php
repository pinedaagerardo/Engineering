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
        <title>Gestionar Personas</title>
    </head>
    <body>
        <div style="margin-top: 100px; margin-left: 300px;">
            <h1>Agregar Persona</h1>
            <form action="guardarpersonas.php" method="post" style="margin-top: 100px;">
                <a href="tarjetas.php">Gestionar tarjetas</a><br/><br/>
                <pre>
                Tipo de persona:            <select name="idtipopersona">
                    <?php
                    $conn=conectar();
                    $sql=gettipopersona();
                    $res=consultar($conn, $sql);
                    while(odbc_fetch_row($res)){
                        echo "<option value=\"".  odbc_result($res, 1)."\">".  odbc_result($res, 2)."</option>";
                        echo "\n";
                    }
                    liberar($res);
                    desconectar($conn);
                    ?>
                </select><br/>
                Nit:                        <input type="text" name="nit"/><br/>
                Nombre:                     <input type="text" name="nombre"/><br/>
                Apellido:                   <input type="text" name="apellido"/><br/>
                edad:                       <input type="text" name="edad"/><br/>
                Sexo:                       <input type="text" name="sexo"/><br/>
                Dirección de entrega:       <input type="text" name="direccionentrega"/><br/>
                Dirección de facturación:   <input type="text" name="direccionfacturacion"/><br/>
                <input style="margin-top: 20px;" type="submit" value="Guardar"/><br/>
                </pre>
            </form>
            <a style="margin-left: 500px;" href="menu.php">Volver al menú</a>
        </div>
    </body>
</html>
