<!--
To change this template, choose Tools | Templates
and open the template in the editor.
-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title></title>
    </head>
    <body>
        <?php
            $titulo="Reportes (licencia pagina 2)";
            echo "<html><head><title>" . $titulo . "</title></head><body>\n";
            echo "<center><h2>" . $titulo . "</h2><br>\n";

            $conn = oci_connect("usuario", "1234567", "127.0.0.1/XE");

            if (!$conn) {
                trigger_error("No se puede conectar a la base de datos", E_USER_ERROR);
            }
            
            echo "<em>Reporte de todas las licencias</em><br><br>\n";

            $stid = oci_parse($conn, "select l.*,c.nombre as \"CLIENTE\" from licencia l,cliente c where l.cliente_idCliente=c.idCliente");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>PRODUCTO</b></td><td><b>SISTEMA OPERATIVO</b></td><td><b>TIPO</b></td><td><b>CANT USUARIOS</b></td><td><b>INICIO</b></td><td><b>FIN</b></td><td><b>CLIENTE</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["IDLICENCIA"][$i] . "</td>" . "<td>" . $results["PRODUCTO"][$i] . "</td>" . "<td>" . $results["SISTOPERATIVO"][$i] . "</td>" . "<td>" . $results["TIPO"][$i] . "</td>" . "<td>" . $results["CANTUSUARIOS"][$i] . "</td>" . "<td>" . $results["INICIO"][$i] . "</td>" . "<td>" . $results["FIN"][$i] . "</td>" . "<td>" . $results["CLIENTE"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";

            echo "<br><br><br><a href=\"licencia.php\">Volver</a><br>\n";
            echo "</body></html>\n";
            oci_close($conn);
        ?>
    </body>
</html>
