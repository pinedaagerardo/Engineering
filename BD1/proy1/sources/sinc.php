<?php
if(session_id() == '') {
    session_start();
}
include 'sqlman.php';

$codCurso=$_GET["curso"];
if($codCurso!=""){ //logueando
    $con=conectar();

    /*el curso esta aprobado?*/
    $sql="SELECT COUNT(1) ESTADO FROM CURSOAPROBADO WHERE CARNET='".$_SESSION['usuario']."' AND IDCURSO=$codCurso;";
    echo $sql;
    $res=consultar($sql);
    $row = mysql_fetch_array($res);
    $_SESSION['estado']=$row['ESTADO'];

    /*pre y post*/
    $sql="SELECT R.POST FROM REQUISITO R WHERE R.PRE=$codCurso";
    $res=consultar($sql);
    $i=0;
    while($row = mysql_fetch_array($res)){
        $disponibles[$i++]=$row['POST'];
    }
    $_SESSION['disponibles']=$disponibles;
    $_SESSION['cant']=$i;
    desconectar($con);
}
    header('Location: portada.php?curso='.$codCurso."&reloaded=1");
?>
