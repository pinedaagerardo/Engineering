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


/*caso especifico*/
            echo "<em>Caso especifico</em><br><br>\n";
            ?>
            <form action = "caso_especifico.php" method = "post">
                <LABEL>Id de caso: &nbsp</LABEL>
                <INPUT type="text" name="nombre">
                <INPUT type="submit" value="Buscar">
            </form>
            <?php
/*caso especifico detalle*/
            echo "<em>Detalle de caso especifico</em><br><br>\n";
            ?>
            <form action = "caso_especifico_detalle.php" method = "post">
                <LABEL>Id de caso: &nbsp</LABEL>
                <INPUT type="text" name="nombre">
                <INPUT type="submit" value="Buscar">
            </form>
            <?php
/*Caso mas largo*/
            echo "<br><br><em>Caso mas largo</em><br><br>\n";

            $stid = oci_parse($conn, "select cl.nombre as \"EMPRESA\", co.nombres as \"CONSULTOR\", c.*,max(to_date(\"c.actualizado\",\"YYYY/MM/DD-HH:MI:SS\")-to_date(\"c.inicio\",\"YYYY/MM/DD-HH:MI:SS\")) as \"duracion\" from caso c,cliente cl,consultor co where lower(estado) like \"c%\" and cl.idCliente=c.cliente_idCliente and co.idConsultor=c.consultor_idConsultor");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>DETALLE</b></td><td><b>EMPRESA</b></td><td><b>FECHA INICIO</b></td><td><b>CONSULTOR</b></td><td><b>DURACION</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["IDCASO"][$i] . "</td>" . "<td>" . $results["DETALLE"][$i] . "</td>" . "<td>" . $results["EMPRESA"][$i] . "</td>" . "<td>" . $results["INICIO"][$i] . "</td>" . "<td>" . $results["CONSULTOR"][$i] . "</td>" . "<td>" . $results["DURACION"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*casos abiertos*/
            echo "<br><br><em>Casos abiertos</em><br><br>\n";

            $stid = oci_parse($conn, "select cl.nombre as \"EMPRESA\", co.nombres as \"CONSULTOR\", c.*,(to_date('c.actualizado','YYYY/MM/DD-HH:MI:SS')-to_date('c.inicio','YYYY/MM/DD-HH:MI:SS')) as \"DURACION\" from caso c,cliente cl,consultor co where lower(estado) like 'o%' and cl.idCliente=c.cliente_idCliente and co.idConsultor=c.consultor_idConsultor");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>DETALLE</b></td><td><b>EMPRESA</b></td><td><b>FECHA INICIO</b></td><td><b>CONSULTOR</b></td><td><b>DURACION</b></td><td><b>ESTADO</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["IDCASO"][$i] . "</td>" . "<td>" . $results["DETALLE"][$i] . "</td>" . "<td>" . $results["EMPRESA"][$i] . "</td>" . "<td>" . $results["INICIO"][$i] . "</td>" . "<td>" . $results["CONSULTOR"][$i] . "</td>" . "<td>" . $results["DURACION"][$i] . "</td>" . "<td>" . $results["ESTADO"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*fin caso*/


            echo "<br><br><br><a href=\"../menu.php\">Volver al menu</a><br>\n";
            echo "</body></html>\n";
            oci_close($conn);
        ?>
    </body>
</html>
