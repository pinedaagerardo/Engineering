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

            echo "<br><br><em>Reporte del cliente " . $nombre . "</em><br><br>\n";

            $stid = oci_parse($conn, "select c.* from cliente c where lower(c.nombre) like lower('" . $nombre . "')");
            $stid_lic = oci_parse($conn, "select l.idLicencia as \"ID\" from licencia l where l.cliente_idcliente = (select idCliente from cliente where lower(nombre) like lower('" . $nombre . "')) order by l.idLicencia");
            oci_execute($stid);
            oci_execute($stid_lic);

            $nrows = oci_fetch_all($stid, $results);
            $nrows_lic = oci_fetch_all($stid_lic, $results_lic);
            if ($nrows_lic==0){
                $nrows_lic=1;
                $results_lic["ID"][0]="ninguna";
            }

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>NOMBRE</b></td><td><b>DIRECCION</b></td><td><b>SECTOR</b></td><td><b>CONTACTO</b></td><td><b>PUESTO</b></td><td><b>EMAIL</b></td><td><b>ADMINISTRADOR</b></td><td><b>TECNICO</b></td><td><b>IDLICENCIA</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows_lic; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["IDCLIENTE"][0] . "</td>" . "<td>" . $results["NOMBRE"][0] . "</td>" . "<td>" . $results["DIRECCION"][0] . "</td>" . "<td>" . $results["SECTOR"][0] . "</td>" . "<td>" . $results["CONTACTO"][0] . "</td>" . "<td>" . $results["PUESTO"][0] . "</td>" . "<td>" . $results["EMAIL"][0] . "</td>" . "<td>" . $results["ADMIN"][0] . "</td>" . "<td>" . $results["TECNICO"][0] . "</td>" . "<td>" . $results_lic["ID"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";

            echo "<br><br><br><a href=\"cliente.php\">Volver a clientes</a><br>\n";
            echo "<a href=\"../menu.php\">Volver al menu</a><br>\n";
            echo "</body></html>\n";
            oci_close($conn);
        ?>
    </body>
</html>
