<?php
if(session_id() != '') {
    session_destroy();
}
?>
<!--
To change this template, choose Tools | Templates
and open the template in the editor.
-->
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Login</title>
    </head>
    <body>
        <table style="padding-top: 150px; width: 75%; margin: 0px auto;">
            <tr>
                <td>
                    <h3>Entrar</h3>
                    <form method="post" action="usuario.php" style="padding-top: 25px;">
                        Carnet: <input name="carnet" type="text"/><br/>
                        Clave: <input name="clave" type="password"/><br/>
                        <input type="submit" value="Entrar"/>
                        <input name="tipo" type="hidden" value="0"/>
                    </form>
                </td>
                <td style="padding-left: 150px;">
                    <h3>Crear usuario</h3>
                    <form method="post" action="usuario.php" style="padding-top: 25px;">
                        Carnet: <input name="carnet" type="text"/><br/>
                        Clave: <input name="clave" type="password"/><br/>
                        Correo: <input name="correo" type="text"/><br/>
                        Nombre: <input name="nombre" type="text"/><br/>
                        <input type="submit" value="Crear"/>
                        <input name="tipo" type="hidden" value="1"/>
                    </form>
                </td>
            </tr>
        </table>
    </body>
</html>
