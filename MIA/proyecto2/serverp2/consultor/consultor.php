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

/*todos los consultores*/
            echo "<em>Reporte de todos los consultores</em><br><br>\n";

            $stid = oci_parse($conn, "select c.*,a.nombre as \"AREA\" from consultor c,area a where c.area_idArea=a.idArea order by c.idConsultor");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>NOMBRES</b></td><td><b>EMAIL</b></td><td><b>AREA</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["IDCONSULTOR"][$i] . "</td>" . "<td>" . $results["NOMBRES"][$i] . "</td>" . "<td>" . $results["EMAIL"][$i] . "</td>" . "<td>" . $results["AREA"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*cliente especifico*/
            echo "<br><br><em>Consultor especifico</em><br><br>\n";
            ?>
            <form action = "consultor_especifico.php" method = "post">
                <LABEL>nombre: &nbsp</LABEL>
                <INPUT type="text" name="nombre">
                <INPUT type="submit" value="Buscar">
            </form>
            <?php
/*consultor con mas casos*/
            echo "<br><br><em>Consultor con mas casos</em><br><br>\n";

            $stid = oci_parse($conn, "select a.nombre as \"AREA\",c.*,t.TOTAL as \"CASOS\" from (select consultor_idConsultor as \"ID\",count(idCaso) as \"TOTAL\" from caso group by consultor_idConsultor) t, consultor c,area a where t.ID=c.idConsultor and a.idArea=c.area_idArea order by CASOS desc");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>NOMBRES</b></td><td><b>CASOS</b></td><td><b>EMAIL</b></td><td><b>AREA</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < 1; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["IDCONSULTOR"][$i] . "</td>" . "<td>" . $results["NOMBRES"][$i] . "</td>" . "<td>" . $results["CASOS"][$i] . "</td>" . "<td>" . $results["EMAIL"][$i] . "</td>" . "<td>" . $results["AREA"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*consultor con menos casos*/
            echo "<br><br><em>Consultor con menos casos</em><br><br>\n";

            $stid = oci_parse($conn, "select a.nombre as \"AREA\",c.*,t.TOTAL as \"CASOS\" from (select consultor_idConsultor as \"ID\",count(idCaso) as \"TOTAL\" from caso group by consultor_idConsultor) t, consultor c,area a where t.ID=c.idConsultor and a.idArea=c.area_idArea order by CASOS");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>NOMBRES</b></td><td><b>CASOS</b></td><td><b>EMAIL</b></td><td><b>AREA</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["IDCONSULTOR"][$i] . "</td>" . "<td>" . $results["NOMBRES"][$i] . "</td>" . "<td>" . $results["CASOS"][$i] . "</td>" . "<td>" . $results["EMAIL"][$i] . "</td>" . "<td>" . $results["AREA"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*fin consultor*/

            echo "<br><br><br><a href=\"../menu.php\">Volver al menu</a><br>\n";
            echo "</body></html>\n";
            oci_close($conn);
        ?>
    </body>
</html>
