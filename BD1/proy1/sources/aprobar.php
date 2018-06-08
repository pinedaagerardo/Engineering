<?php
if(session_id() == '') {
    session_start();
}

include 'sqlman.php';
$codCurso=$_GET["curso"];
$accion=$_GET["accion"]; //0=mostrar, 1=aprobar, 2=desaprobar

$con=conectar();

/*aprobar el curso recibido*/
if($accion==1) aprobar($codCurso);
if($accion==2) desaprobar($codCurso);
function aprobar($curso){
    //buscar si el curso ya esta aprobado
    $sql="SELECT COUNT(1) ESTADO FROM CURSOAPROBADO WHERE CARNET=\"".$_SESSION['usuario']."\" AND IDCURSO=$curso;";
    $res=consultar($sql);
    $row = mysql_fetch_array($res);
    if($row['ESTADO']==0){ //1=aprobado, else = 0
        //si no, aprobarlo
        $sql="INSERT INTO CURSOAPROBADO VALUES($curso,\"".$_SESSION['usuario']."\");";
        ejecutar($sql);
    }
}
function desaprobar($curso){
    //buscar si el curso esta aprobado
    $sql="SELECT COUNT(1) ESTADO FROM CURSOAPROBADO WHERE CARNET=\"".$_SESSION['usuario']."\" AND IDCURSO=$curso;";
    $res=consultar($sql);
    $row = mysql_fetch_array($res);
    if($row['ESTADO']==1){ //1=aprobado, else = 0
        //si lo esta, desaprobarlo
        $sql="DELETE FROM CURSOAPROBADO WHERE IDCURSO=$curso AND CARNET=\"".$_SESSION['usuario']."\";";
        ejecutar($sql);
    }
}

/*cursos aprobados*/
$sql="SELECT IDCURSO FROM CURSOAPROBADO WHERE CARNET=\"".$_SESSION['usuario']."\"";
$res=consultar($sql);
$i=0;
while($row = mysql_fetch_array($res)){
    $aprobados[$i++]=$row['IDCURSO'];
}
$_SESSION['aprobados']=$aprobados;

/*creditos*/
$sql="SELECT SUM(C.CREDITOS) CREDITOS FROM CURSOAPROBADO CA,CURSO C WHERE CA.CARNET=\"".$_SESSION['usuario']."\" AND C.IDCURSO=CA.IDCURSO;";
$res=consultar($sql);
$row = mysql_fetch_array($res);
$_SESSION['creditosactuales']=$row['CREDITOS'];

desconectar($con);

header('Location: sinc.php?curso='.$codCurso);

?>
