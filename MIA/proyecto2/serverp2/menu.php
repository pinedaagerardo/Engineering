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

/*inicia reporte*/
            $stid = oci_parse($conn, "select * from cliente");
            oci_execute($stid);
            $nrows = oci_fetch_all($stid, $results);
            echo "Numero total de clientes: " . $nrows . "<br>\n";

            $stid = oci_parse($conn, "select * from consultor");
            oci_execute($stid);
            $nrows = oci_fetch_all($stid, $results);
            echo "Numero total de consultores: " . $nrows . "<br>\n";

            $stid = oci_parse($conn, "select * from caso");
            oci_execute($stid);
            $nrows = oci_fetch_all($stid, $results);
            echo "Numero total de casos: " . $nrows . "<br>\n";

            $stid = oci_parse($conn, "select distinct contacto from caso union select distinct contacto from cliente");
            oci_execute($stid);
            $nrows = oci_fetch_all($stid, $results);
            echo "Numero total de contactos: " . $nrows . "<br>\n";

            $stid = oci_parse($conn, "select * from producto");
            oci_execute($stid);
            $nrows = oci_fetch_all($stid, $results);
            echo "Numero total de productos: " . $nrows . "<br>\n";

            $stid = oci_parse($conn, "select * from licencia");
            oci_execute($stid);
            $nrows = oci_fetch_all($stid, $results);
            echo "Numero total de licencias: " . $nrows . "<br>\n";
/*termina reporte*/
            
            echo "<br><br><br>Otros reportes:<br><br></center>\n";
            echo "<a href=\"cliente/cliente.php\">Reporte de clientes</a><br>\n";
            echo "<a href=\"consultor/consultor.php\">Reporte de consultores</a><br>\n";
            echo "<a href=\"area/area.php\">Reporte de areas</a><br>\n";
            echo "<a href=\"producto/producto.php\">Reporte de productos</a><br>\n";
            echo "<a href=\"so/so.php\">Reporte de sistemas operativos</a><br>\n";
            echo "<a href=\"contacto/contacto.php\">Reporte de contactos</a><br>\n";
            echo "<a href=\"licencia/licencia.php\">Reporte de licencias</a><br>\n";
            echo "<a href=\"caso/caso.php\">Reporte de casos</a><br>\n";
            echo "</body></html>\n";
            oci_close($conn);
        ?>
    </body>
</html>

<!--/*inicia reporte*/
            $stid = oci_parse($conn, "select * from cliente");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            echo "<td><b>CODIGO</b></td><td><b>DATA</b></td>\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              echo "<td>" . $results["CODIGO"][$i] . "</td>" . "<td>" . $results["DATA"][$i] . "</td>\n";
              echo "</tr>\n";
            }

            echo "</table>";
/*termina reporte*/-->