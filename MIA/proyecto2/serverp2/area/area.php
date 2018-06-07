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


/*numero casos abiertos*/
            echo "<br><br><em>Cantidad de casos abiertos clasificados segun el area del producto</em><br><br>\n";

            $stid = oci_parse($conn, "select a.nombre,tt.* from (select t.area_idArea as \"ID\",count(t.idcaso) as \"CASOS\" from (select c.* from caso c where lower(c.estado) like 'o%') t group by t.area_idArea) tt,area a where a.idarea=tt.ID");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>AREA</b></td><td><b>CASOS</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["ID"][$i] . "</td>" . "<td>" . $results["NOMBRE"][$i] . "</td>" . "<td>" . $results["CASOS"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*fin casos*/


            echo "<br><br><br><a href=\"../menu.php\">Volver al menu</a><br>\n";
            echo "</body></html>\n";
            oci_close($conn);
        ?>
    </body>
</html>
