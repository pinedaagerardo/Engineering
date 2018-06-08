<?php
if(session_id() == '') {
    session_start();
}

include 'sqlman.php';

$codCurso=$_POST["curso"];

$sql[0]=str_replace('\\', '', $_POST["sql0"]);
$sql[1]=str_replace('\\', '', $_POST["sql1"]);
$sql[2]=str_replace('\\', '', $_POST["sql2"]);

$con=conectar();

$res0=consultar($sql[0]);
$res1=consultar($sql[1]);
$res2=consultar($sql[2]);

$cantRequisitos=0;
while($row = mysql_fetch_array($res0)){ //info curso, pre y post
    $nomCurso=$row['NOMBRE'];
    $creditos=$row['CREDITOS'];
    $desCurso=$row['DESCRIPCION'];
    $pre[$cantRequisitos]=$row['PRE'];
    $post[$cantRequisitos++]=$row['POST'];
}
$contLibros=0;
if($res1!=""){
    while($row = mysql_fetch_array($res1)){ //info libros
        $nomAtrib=strtoupper($row['NOMBRE']);
        if($nomAtrib=="IMAGEN" || $nomAtrib=="CONSULTA" || $nomAtrib=="DESCARGA")
            $libros[$contLibros++]="<a href=\"".$row['VALOR']."\" target=\"_blank\">".$row['NOMBRE']."</a>";
        else
            $libros[$contLibros++]=$row['VALOR'];
    }
}
$contEjemplos=0;
if($res2!=""){
    while($row = mysql_fetch_array($res2)){ //info ejemplos
        $nomAtrib=strtoupper($row['NOMBRE']);
        if($nomAtrib=="IMAGEN" || $nomAtrib=="CONSULTA" || $nomAtrib=="DESCARGA")
            $ejemplos[$contEjemplos++]="<a href=\"".$row['VALOR']."\" target=\"_blank\">".$row['NOMBRE']."</a>";
        else
            $ejemplos[$contEjemplos++]=$row['VALOR'];
    }
}

desconectar($con);

?>
<html>
    <body>
        <h2><?php echo $codCurso." - $nomCurso"; ?></h2>
        <br/><br/>
        <?php echo "$desCurso"; ?>
        <br/><br/>
        <b>Créditos:&nbsp;</b> <?php echo "$creditos"; ?>
        <br/><br/>
        <b>Pre-Requisitos:&nbsp;</b>
        <br/><br/>
        <ul>
            <?php
            $contCurso=0;
            for($i=0; $i<$cantRequisitos; $i++){
                if($pre[$i]!=0){
                    if((int)$pre[$i]>=5000)
                        echo "<li> Curso requiere creditos </li><br/>";
                    else
                        echo "<li>".$pre[$i]." - Curso # ".++$contCurso."</li><br/>";
                }
            }
            if($contCurso==0) echo "Este curso no tiene pre-requisitos";
            ?>
        </ul>
        <br/><br/>
        <b>Post-Requisitos:&nbsp;</b>
        <br/><br/>
        <ul>
            <?php
            $contCurso=0;
            for($i=0; $i<$cantRequisitos; $i++){
                if($post[$i]!=0 && $post[$i]<5000){
                    echo "<li>".$post[$i]." - Curso # ".++$contCurso."</li><br/>";
                }
            }
            if($contCurso==0) echo "Este curso no tiene post-requisitos";
            ?>
        </ul>
        <br/><br/>
        <b>Libros Recomendados:&nbsp;</b> <?php echo $contLibros/7; ?>
        <br/><br/>
        <ul>
            <?php
            for($i=0,$j=0; $i<$contLibros; $i++,$j++){
                if($j==7) $j=0;
                echo ($j==0?"<li>":"") . $libros[$i] . ($j!=6?", ":"</li><br/>");
            }
            ?>
        </ul>
        <br/><br/>
        <b>Ejemplos:&nbsp;</b> <?php echo $contEjemplos/7; ?>
        <br/><br/>
        <ul>
            <?php
            for($i=0,$j=0; $i<$contEjemplos; $i++,$j++){
                if($j==7) $j=0;
                echo ($j==0?"<li>":"") . $ejemplos[$i] . ($j!=6?", ":"</li><br/>");
            }
            ?>
        </ul>
    </body>
</html>