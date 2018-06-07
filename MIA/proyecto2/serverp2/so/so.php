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
            $titulo="Reportes";
            echo "<html><head><title>" . $titulo . "</title></head><body>\n";
            echo "<center><h2>" . $titulo . "</h2><br>\n";

            $conn = oci_connect("usuario", "1234567", "127.0.0.1/XE");

            if (!$conn) {
                trigger_error("No se puede conectar a la base de datos", E_USER_ERROR);
            }


/*todos los so*/
            echo "<em>Reporte de todos los sistemas operativos</em><br><br>\n";

            $stid = oci_parse($conn, "select distinct sistOperativo from licencia");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>SISTEMA OPERATIVO</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["SISTOPERATIVO"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*num productos por so*/
            echo "<br><br><em>Numero de productos por sistema operativo</em><br><br>\n";

            $stid = oci_parse($conn, "select sistOperativo,count(producto_idProducto) as \"TOTAL\" from venta group by sistOperativo");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>SISTEMA OPERATIVO</b></td><td><b>TOTAL</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["SISTOPERATIVO"][$i] . "</td>" . "<td>" . $results["TOTAL"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*so mas usado*/
            echo "<br><br><em>Sistema operativo mas usado</em><br><br>\n";

            $stid = oci_parse($conn, "select sistOperativo,count(sistOperativo) as \"TOTAL\" from venta group by sistOperativo order by sistoperativo desc");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>SISTEMA OPERATIVO</b></td><td><b>TOTAL</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < 1; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["SISTOPERATIVO"][$i] . "</td>" . "<td>" . $results["TOTAL"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*so menos usado*/
            echo "<br><br><em>Sistema operativo menos usado</em><br><br>\n";

            $stid = oci_parse($conn, "select sistOperativo,count(sistOperativo) as \"TOTAL\" from venta group by sistOperativo order by sistoperativo");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>SISTEMA OPERATIVO</b></td><td><b>TOTAL</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < 1; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["SISTOPERATIVO"][$i] . "</td>" . "<td>" . $results["TOTAL"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*fin cliente*/


            echo "<br><br><br><a href=\"../menu.php\">Volver al menu</a><br>\n";
            echo "</body></html>\n";
            oci_close($conn);
        ?>
    </body>
</html>
