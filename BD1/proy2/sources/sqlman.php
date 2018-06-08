<?php
/*odbc_result_all($res,"border=1");*/

$host="localhost";

/*
 * Realiza una conexión
 */
function conectar(){
    global $host;
    $conn = odbc_connect("DRIVER={Microsoft ODBC for Oracle};SERVER=$host;Uid=gerardo;Pwd=200611226;","gerardo","200611226"); //oci_connect("user_bases1","12345","//localhost:1521/XE","UTF8");
    if (odbc_error($conn)) {
            echo odbc_errormsg($conn);
    }
    return $conn;
}

/*
 * Termina una conexión
 */
function desconectar($conn){
    odbc_close($conn);
}

/*
 * Realiza una consulta
 */
function consultar($conn,$sql){
    $res=odbc_prepare($conn,$sql);
	odbc_execute($res);
	return $res;
}

/*
 * Ejecuta una instrucción para modificación
 */
function ejecutar($conn,$sql){
    $res=odbc_prepare($conn,$sql);
	odbc_execute($res);
}

/*
 * Libera recursos usados del parámetro recibido
 */
function liberar($res){
    odbc_free_result($res);
}

/*
 * Establece el auto-commit para la conexión recibida
 */
function auto_commit($conn,$bool){
    odbc_autocommit($conn, $bool);
}

/*
 * Realiza un commit para la conexión recibida
 */
function commit($conn){
    odbc_commit($conn);
}

/*
 * Realiza un rollback para la conexión recibida
 */
function rollback($conn){
    odbc_rollback($conn);
}
?>