<!--
To change this template, choose Tools | Templates
and open the template in the editor.
-->
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title></title>
    </head>
    <body>
        <div action="res.php" method="post" style="margin-top: 100px; margin-left: 300px; margin-bottom: 100px;">
            <form action="res.php" method="post">
                <h2>Reporte 1</h2>
                <input type="submit" value="Ir"/>
                <input type="hidden" name="reporte" value="1"/>
            </form>
            <form action="res.php" method="post">
                <h2>Reporte 2</h2>
                <input type="submit" value="Ir"/>
                <input type="hidden" name="reporte" value="2"/>
            </form>
            <form action="res.php" method="post">
                <h2>Reporte 3</h2>
                fecha inicio: <input type="text" name="inicio"/><br/>
                fecha fin: <input type="text" name="fin"/><br/>
                <input type="submit" value="Ir"/>
                <input type="hidden" name="reporte" value="3"/>
            </form>
            <form action="res.php" method="post">
                <h2>Reporte 4</h2>
                <input type="submit" value="Ir"/>
                <input type="hidden" name="reporte" value="4"/>
            </form>
            <form action="res.php" method="post">
                <h2>Reporte 5</h2>
                fecha inicio: <input type="text" name="inicio"/><br/>
                fecha fin: <input type="text" name="fin"/><br/>
                cargamento: <input type="text" name="cargamento"/><br/>
                lote: <input type="text" name="lote"/><br/>
                caja: <input type="text" name="caja"/><br/>
                <input type="submit" value="Ir"/>
                <input type="hidden" name="reporte" value="5"/>
            </form>
            <form action="res.php" method="post">
                <h2>Reporte 6</h2>
                <input type="submit" value="Ir"/>
                <input type="hidden" name="reporte" value="6"/>
            </form>
            <form action="res.php" method="post">
                <h2>Reporte 7 a</h2>
                <input type="submit" value="Ir"/>
                <input type="hidden" name="reporte" value="7a"/>
            </form>
            <form action="res.php" method="post">
                <h2>Reporte 7 b</h2>
                <input type="submit" value="Ir"/>
                <input type="hidden" name="reporte" value="7b"/>
            </form>
            <form action="res.php" method="post">
                <h2>Reporte 8</h2>
                factura (107062012): <input type="text" name="factura"/><br/>
                <input type="submit" value="Ir"/>
                <input type="hidden" name="reporte" value="8"/>
            </form>
            <br/><br/>
            <a href="menu.php">volver</a>
        </div>
    </body>
</html>
