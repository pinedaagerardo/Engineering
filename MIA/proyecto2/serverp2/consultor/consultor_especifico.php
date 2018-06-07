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
            $titulo="Reporte individual";
            echo "<html><head><title>" . $titulo . "</title></head><body>\n";
            echo "<center><h2>" . $titulo . "</h2><br>\n";

            $conn = oci_connect("usuario", "1234567", "127.0.0.1/XE");

            if (!$conn) {
                trigger_error("No se puede conectar a la base de datos", E_USER_ERROR);
            }


            $nombre=$_POST["nombre"];

            echo "<br><br><em>Reporte del consultor " . $nombre . "</em><br><br>\n";

            $stid = oci_parse($conn, "select ca.*,cl.nombre as \"CLNOM\",pr.nombre as \"PRNOM\" from caso ca,consultor co,cliente cl,producto pr where lower(co.nombres) like lower('" . $nombre . "') and co.idConsultor=ca.consultor_idConsultor and cl.idCliente=ca.cliente_idCliente and pr.idProducto=ca.producto_idProducto");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>CONTACTO</b></td><td><b>INICIO</b></td><td><b>VERSION SO</b></td><td><b>SEVERIDAD</b></td><td><b>DESCRIPCION</b></td><td><b>ESTADO</b></td><td><b>CLIENTE</b></td><td><b>PRODUCTO</b></td><td><b>ACTUALIZADO</b></td><td><b>DETALLE</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["IDCASO"][$i] . "</td>" . "<td>" . $results["CONTACTO"][$i] . "</td>" . "<td>" . $results["INICIO"][$i] . "</td>" . "<td>" . $results["VERSIONSO"][$i] . "</td>" . "<td>" . $results["SEVERIDAD"][$i] . "</td>" . "<td>" . $results["DESCRIPCION"][$i] . "</td>" . "<td>" . $results["ESTADO"][$i] . "</td>" . "<td>" . $results["CLNOM"][$i] . "</td>" . "<td>" . $results["PRNOM"][$i] . "</td>" . "<td>" . $results["ACTUALIZADO"][$i] . "</td>" . "<td>" . $results["DETALLE"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";

            echo "<br><br><br><a href=\"consultor.php\">Volver a consultores</a><br>\n";
            echo "<a href=\"../menu.php\">Volver al menu</a><br>\n";
            echo "</body></html>\n";
            oci_close($conn);
        ?>
    </body>
</html>
