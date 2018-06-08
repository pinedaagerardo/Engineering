<?php
/*
 * Realiza una conexión y asigna una base de datos
 */
$host="localhost";//"mysql1.000webhost.com";
function conectar(){
    global $host;
    $con = mysql_connect($host,'a6308780_rootelc','root66toor'); 
    if (!$con) { 
            die('No se pudo conectar a MySQL: ' . mysql_error()); 
    }
    mysql_select_db("a6308780_electro", $con);
    return $con;
}

/*
 * Termina una conexión
 */
function desconectar($con){
    mysql_close($con);
}

/*
 * Realiza una consulta
 */
function consultar($sql){
    $result = mysql_query($sql) or die(mysql_error());
    return $result;
}

/*
 * Ejecuta una instrucción para modificación
 */
function ejecutar($sql){
    mysql_query($sql) or die(mysql_error());
}
?>