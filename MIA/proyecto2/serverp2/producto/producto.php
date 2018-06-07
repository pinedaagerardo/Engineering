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


/*todos los productos*/
            echo "<em>Reporte de todos los productos</em><br><br>\n";

            $stid = oci_parse($conn, "select p.*,a.nombre as \"NOMAREA\" from producto p,area a where p.area_idArea=a.idArea");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>NOMBRE</b></td><td><b>AREA</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < $nrows; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["IDPRODUCTO"][$i] . "</td>" . "<td>" . $results["NOMBRE"][$i] . "</td>" . "<td>" . $results["NOMAREA"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*mejor producto*/
            echo "<br><br><em>Producto mas usado</em><br><br>\n";

            $stid = oci_parse($conn, "select p.idproducto as \"ID\",a.nombre as \"ANOM\",p.nombre as \"PNOM\",t.TOTAL as \"UNIDADES\" from (select producto_idProducto as \"ID\",sum(unidades) as \"TOTAL\" from venta group by producto_idProducto) t,producto p,area a where p.idproducto=t.ID and a.idarea=p.area_idarea order by unidades desc");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>NOMBRE</b></td><td><b>AREA</b></td><td><b>UNIDADES</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < 1; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["ID"][$i] . "</td>" . "<td>" . $results["PNOM"][$i] . "</td>" . "<td>" . $results["ANOM"][$i] . "</td>" . "<td>" . $results["UNIDADES"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*peor producto*/
            echo "<br><br><em>Producto menos usado</em><br><br>\n";

            $stid = oci_parse($conn, "select p.idproducto as \"ID\",a.nombre as \"ANOM\",p.nombre as \"PNOM\",t.TOTAL as \"UNIDADES\" from (select producto_idProducto as \"ID\",sum(unidades) as \"TOTAL\" from venta group by producto_idProducto) t,producto p,area a where p.idproducto=t.ID and a.idarea=p.area_idarea order by unidades");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>NOMBRE</b></td><td><b>AREA</b></td><td><b>UNIDADES</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < 1; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["ID"][$i] . "</td>" . "<td>" . $results["PNOM"][$i] . "</td>" . "<td>" . $results["ANOM"][$i] . "</td>" . "<td>" . $results["UNIDADES"][$i] . "</td>";
              echo $str2 . "\n";
              echo "</tr>\n";
            }

            echo "</table>\n";
/*producto especifico*/
            echo "<br><br><em>Producto especifico</em><br><br>\n";
            ?>
            <form action = "producto_especifico.php" method = "post">
                <LABEL>nombre: &nbsp</LABEL>
                <INPUT type="text" name="nombre">
                <INPUT type="submit" value="Buscar">
            </form>
            <?php
/*mayor numero de casos*/
            echo "<br><br><em>Mayor numero de casos abiertos de contactos administrativos</em><br><br>\n";

            $stid = oci_parse($conn, "select p.nombre as \"PNOM\",t.* from producto p, (select producto_idProducto as \"ID\",count(producto_idProducto) as \"CANTIDAD\" from caso where cliente_idCliente in (select idCliente from cliente where upper(admin) like 'S%') and lower(estado) like 'o%' group by producto_idProducto) t where t.ID=p.idProducto");
            oci_execute($stid);

            $nrows = oci_fetch_all($stid, $results);

            echo "<table border=1 cellspacing='0' width='50%'>\n<tr>\n";
            $str1="<td><b>ID</b></td><td><b>NOMBRE</b></td><td><b>CANTIDAD</b></td>";
            echo $str1 . "\n</tr>\n";

            for ($i = 0; $i < 1; $i++ ) {
              echo "<tr>\n";
              $str2="<td>" . $results["ID"][$i] . "</td>" . "<td>" . $results["PNOM"][$i] . "</td>" . "<td>" . $results["CANTIDAD"][$i] . "</td>";
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
