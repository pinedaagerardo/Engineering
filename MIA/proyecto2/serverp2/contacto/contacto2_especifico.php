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

            echo "<br><br><em>Casos de la empresa " . $nombre . " con contactos no registrados</em><br><br>\n";

            $stid = oci_parse($conn, "select t.IDCL,c.*,co.nombres as \"CONSULTOR\",cl.nombre as \"EMPRESA\" from consultor co,caso c,cliente cl,(select idCliente as \"IDCL\" from cliente where lower(nombre) like lower('" . $nombre . "')) t where c.contacto not in (select cl.contacto from cliente cl where lower(cl.nombre) like lower('" . $nombre . "')) and c.cliente_idCliente=cl.idCliente and co.idConsultor=c.consultor_idConsultor and c.cliente_idCliente=t.IDCL");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>EMPRESA</b></td><td><b>CONTACTO</b></td><td><b>FECHA INICIO</b></td><td><b>CONSULTOR</b></td><td><b>ESTADO</b></td><td><b>DESCRIPCION</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["IDCASO"][$i] . "</td>" . "<td>" . $results["EMPRESA"][$i] . "</td>" . "<td>" . $results["CONTACTO"][$i] . "</td>" . "<td>" . $results["INICIO"][$i] . "</td>" . "<td>" . $results["CONSULTOR"][$i] . "</td>" . "<td>" . $results["ESTADO"][$i] . "</td>" . "<td>" . $results["DESCRIPCION"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";

            echo "<br><br><br><a href=\"contacto.php\">Volver a contactos</a><br>\n";
            echo "<a href=\"../menu.php\">Volver al menu</a><br>\n";
            echo "</body></html>\n";
            oci_close($conn);
        ?>
    </body>
</html>
