<?php
include 'scripts.php';
?>
<!--
To change this template, choose Tools | Templates
and open the template in the editor.
-->
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title></title>
        <script>
            /*
             * Función que evita que se seleccione más de 1 vez la carga de datos
             */
            function cargar(){
                x=document.getElementById("cargadatos");
                x.innerHTML='<H1>Cargando...</H1>';
            }
            
            /*
             * Función que ejecuta otras funciones al cargar la página
             */
            window.onload=function WindowLoad(){
                <?php
                if(isset($_GET['carga']) && $_GET['carga']==1){
                    echo "cargar();";
                }
                ?>
            }
        </script>
    </head>
    <body>
        <div id="cargadatos" style="margin-top: 100px; margin-left: 300px;">
            <a href="cargar.php?carga=1" onclick="cargar()">Cargar datos</a><br/><br/><br/>
            <a href="menu.php">Volver al menú</a>
        </div>
        <?php
        if(isset($_GET['carga']) && $_GET['carga']==1){
            $conn=conectar();
            auto_commit($conn, false);
            
            /*$proveedores=cargar_personas($conn,'PROVEEDOR');//el tipo se envía directamente a la query, no modificar
            $empleados=cargar_personas($conn,'EMPLEADO');
            $clientes=cargar_personas($conn,'CLIENTE');
            //commit($conn);
            $t_credito=cargar_tarjetas($conn,'C');//el tipo se envía directamente a la query, no modificar
            $t_debito=cargar_tarjetas($conn,'D');
            $t_especiales=cargar_tarjetas($conn,'E');
            //commit($conn);
            cargar_categorias($conn);
            cargar_productos($conn);
            //commit($conn);
            cargar_cargamento($conn);
            cargar_lotes($conn);
            cargar_ingreso($conn);
            //commit($conn);
            cargar_venta($conn);
            cargar_detalleventa($conn);
            //commit($conn);
            cargar_ordencompra($conn);
            cargar_detalleordencompra($conn);*/
            
            commit($conn);
            
            desconectar($conn);
            header("location:/proyecto2/menu.php");
        }
        ?>
    </body>
</html>
