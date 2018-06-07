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


/*todos los contactos*/
            echo "<em>Reporte de todos los contactos</em><br><br>\n";

            $stid = oci_parse($conn, "select * from cliente");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>NOMBRE</b></td><td><b>PUESTO</b></td><td><b>EMAIL</b></td><td><b>ADMIN</b></td><td><b>TECNICO</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["CONTACTO"][$i] . "</td>" . "<td>" . $results["PUESTO"][$i] . "</td>" . "<td>" . $results["EMAIL"][$i] . "</td>" . "<td>" . $results["ADMIN"][$i] . "</td>" . "<td>" . $results["TECNICO"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*contacto especifico*/
            echo "<br><br><em>Contactos de una empresa</em><br><br>\n";
            ?>
            <form action = "contacto_especifico.php" method = "post">
                <LABEL>nombre: &nbsp</LABEL>
                <INPUT type="text" name="nombre">
                <INPUT type="submit" value="Buscar">
            </form>
            <?php
/*casos de contactos no registrados*/
            echo "<br><br><em>Casos de contactos no registrados de una empresa</em><br><br>\n";
            ?>
            <form action = "contacto2_especifico.php" method = "post">
                <LABEL>nombre: &nbsp</LABEL>
                <INPUT type="text" name="nombre">
                <INPUT type="submit" value="Buscar">
            </form>
            <?php
/*fin contacto*/


            echo "<br><br><br><a href=\"../menu.php\">Volver al menu</a><br>\n";
            echo "</body></html>\n";
            oci_close($conn);
        ?>
    </body>
</html>
