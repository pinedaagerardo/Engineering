<?php
include 'sqlman.php';

function getordencompra(){
    return "select (select pro.nombre from producto pro where pro.idproducto=dc.idproducto) producto, dc.idcotizacion,dc.fechacotizacion,(select e.nombre from estado e where e.idestado=dc.idestado) estado,dc.preciounitario from detallecotizacion dc";
}

function getingreso(){
    return "select nombre producto,idlote lote,idcargamento cargamento,fechaingresoinventario \"FECHA INGRESO INV\",nocaja caja,costounitario costo from ingreso natural join producto";
}

function gettarjeta(){
    return 'select * from persona natural join tarjeta tt, tipotarjeta t where tt.idtipotarjeta = t.idtipotarjeta';
}

function gettipopago(){
    return 'select * from tipopago';
}

function gettipoentrega(){
    return 'select * from tipoentrega';
}

function getproducto(){
    return 'select * from producto';
}

function gettipopersona(){
    return 'select * from tipopersona';
}

function gettipotarjeta(){
    return 'select * from tipotarjeta';
}

function getpersona(){
    return "select idpersona,nombre||' '||apellido from persona";
}

function cargar_personas($conn,$tipo){
    /****tipo de persona****/
    $sql="SELECT TPER.IDTIPOPERSONA FROM TIPOPERSONA TPER WHERE UPPER(TPER.NOMBRE) LIKE '$tipo'";
    $res=consultar($conn, $sql);
    odbc_fetch_row($res);
    $idtipopersona=odbc_result($res, 1);
    /****personas****/
    if($tipo=='PROVEEDOR')
        $sql="SELECT DISTINCT S PERSONA FROM EXTERNA";
    else
        if($tipo=='EMPLEADO')
            $sql="SELECT DISTINCT T PERSONA FROM EXTERNA";
        else
            if($tipo=='CLIENTE')
                $sql="SELECT DISTINCT U NOMBRE,V APELLIDO,W EDAD,X SEXO FROM EXTERNA WHERE U NOT LIKE '-'";
    $res=consultar($conn, $sql);
    while(odbc_fetch_row($res)){
        if($tipo<>'CLIENTE'){
            $dato=explode(" ", odbc_result($res, "PERSONA"),2);
            $dato[1]=(isset($dato[1])?$dato[1]:"");
        }else{
            $dato[0]=odbc_result($res, "NOMBRE");
            $dato[1]=odbc_result($res, "APELLIDO");
            $dato[2]=odbc_result($res, "EDAD");
            $dato[3]=odbc_result($res, "SEXO");
        }
        /****verificar repetidos****/
        if($tipo=='CLIENTE')
            $sql="SELECT 1 FROM PERSONA WHERE UPPER(NOMBRE||APELLIDO) LIKE UPPER('$dato[0]$dato[1]') AND IDTIPOPERSONA=$idtipopersona AND EDAD=$dato[2] AND UPPER(SEXO)=UPPER('$dato[3]')";
        else
            $sql="SELECT 1 FROM PERSONA WHERE UPPER(NOMBRE||APELLIDO) LIKE UPPER('$dato[0]$dato[1]') AND IDTIPOPERSONA=$idtipopersona";
        $res_verificar=consultar($conn, $sql);
        odbc_fetch_row($res_verificar);
        $existe=odbc_result($res_verificar, 1);
        if(isset ($existe) && $existe==1){
            liberar($res_verificar);
            continue;
        }
        liberar($res_verificar);
        /****insertar****/
        if($tipo=='CLIENTE')
            $sql="INSERT INTO PERSONA VALUES ((SELECT MAX(PER.IDPERSONA)+1 FROM PERSONA PER),NULL,'$dato[0]','$dato[1]',$dato[2],'$dato[3]',NULL,NULL,$idtipopersona)";
        else
            $sql="INSERT INTO PERSONA VALUES ((SELECT MAX(PER.IDPERSONA)+1 FROM PERSONA PER),NULL,'$dato[0]','$dato[1]',NULL,NULL,NULL,NULL,$idtipopersona)";
        ejecutar($conn, $sql);
    }
    
    liberar($res);
    return 1;
}

function cargar_tarjetas($conn,$tipo){
    /****tarjetas de crédito****/
    $str_tipotarjeta=$tipo;
    if($str_tipotarjeta=='E')
        $sql="SELECT DISTINCT U NOMBRE,V APELLIDO,W EDAD,X SEXO,Z TARJETA FROM EXTERNA WHERE UPPER(SUBSTR(Y,0,1)) NOT IN ('C','D') AND LENGTH(Z)>4";
    else
        $sql="SELECT DISTINCT U NOMBRE,V APELLIDO,W EDAD,X SEXO,Z TARJETA FROM EXTERNA WHERE UPPER(SUBSTR(Y,0,1)) LIKE '$str_tipotarjeta' AND UPPER(Y) NOT LIKE 'CHEQUE'";
    $res=consultar($conn, $sql);
    while(odbc_fetch_row($res)){
        $dato[0]=odbc_result($res, "NOMBRE");
        $dato[1]=odbc_result($res, "APELLIDO");
        $dato[2]=odbc_result($res, "EDAD");
        $dato[3]=odbc_result($res, "SEXO");
        $notarjeta=odbc_result($res, "TARJETA");
        /****verificar repetidos****/
        /*
        $sql="SELECT 1 FROM TARJETA WHERE UPPER(NOTARJETA) LIKE UPPER('$notarjeta')";
        $res_verificar=consultar($conn, $sql);
        odbc_fetch_row($res_verificar);
        $existe=odbc_result($res_verificar, 1);
        if(isset ($existe) && $existe==1){
            liberar($res_verificar);
            continue;
        }
        liberar($res_verificar);
        */
        /****insertar****/
        $sql="SELECT IDPERSONA FROM PERSONA WHERE UPPER(NOMBRE||APELLIDO) LIKE UPPER('$dato[0]$dato[1]') AND EDAD=$dato[2] AND UPPER(SEXO)=UPPER('$dato[3]')";
        $res_cliente=consultar($conn, $sql);
        odbc_fetch_row($res_cliente);
        $idpersona=odbc_result($res_cliente, 1);
        if(isset ($idpersona) && $idpersona>0){
            if($str_tipotarjeta=='C')
                $limite=2000;
            else
                $limite=0;
            $sql="INSERT INTO TARJETA VALUES ('$notarjeta','$idpersona',$limite,SUBSTR('$notarjeta',-4,4),(SELECT IDTIPOTARJETA FROM TIPOTARJETA WHERE UPPER(SUBSTR(NOMBRE,0,1)) LIKE '$str_tipotarjeta'))";
            ejecutar($conn, $sql);
        }else{
            echo "Persona no encontrada: ".$dato[0]." ".$dato[1].", ".$dato[2].", ".$dato[3]."<br/>";
            return 0;
        }
    }
    
    liberar($res);
    return 1;
}

function cargar_categorias($conn){
    /****padres****/
    $sql="SELECT MAX(IDCATEGORIA) FROM CATEGORIA";
    $res_max=consultar($conn, $sql);
    odbc_fetch_row($res_max);
    $id_max=odbc_result($res_max, 1);
    liberar($res_max);
    /****insertando****/
    $sql="INSERT INTO CATEGORIA(SELECT $id_max+ROWNUM ID,0 PADRE,S.CAT FROM((SELECT D CAT FROM EXTERNA MINUS SELECT E CAT FROM EXTERNA) MINUS SELECT NOMBRE FROM CATEGORIA) S)";
    ejecutar($conn, $sql);
    /****hijos****/
    $continuar=true;
    while($continuar){
        $sql="SELECT DISTINCT 1 FROM (SELECT E CAT FROM EXTERNA MINUS SELECT NOMBRE CAT FROM CATEGORIA) S, EXTERNA EXT, CATEGORIA C WHERE EXT.E = S.CAT AND C.NOMBRE = EXT.D";
        $res_verificar=consultar($conn, $sql);
        odbc_fetch_row($res_verificar);
        $existe=odbc_result($res_verificar, 1);
        if(!isset ($existe) || $existe<>1){
            liberar($res_verificar);
            $continuar=false;
            break;
        }
        liberar($res_verificar);

        $sql="SELECT MAX(IDCATEGORIA) FROM CATEGORIA";
        $res_max=consultar($conn, $sql);
        odbc_fetch_row($res_max);
        $id_max=odbc_result($res_max, 1);
        liberar($res_max);
        /****insertando****/
        $sql="INSERT INTO CATEGORIA(SELECT $id_max+ROWNUM ID,PADRE,CAT FROM (SELECT DISTINCT C.IDCATEGORIA PADRE, S.CAT FROM (SELECT E CAT FROM EXTERNA MINUS SELECT NOMBRE CAT FROM CATEGORIA) S, EXTERNA EXT, CATEGORIA C WHERE EXT.E = S.CAT AND C.NOMBRE = EXT.D))";
        ejecutar($conn, $sql);
    }
}

function cargar_productos($conn){
    $sql="SELECT NVL(MAX(IDPRODUCTO),0) FROM PRODUCTO";
    $res_max=consultar($conn, $sql);
    odbc_fetch_row($res_max);
    $id_max=odbc_result($res_max, 1);
    liberar($res_max);
    /****insertando****/
    $sql="INSERT INTO PRODUCTO(SELECT $id_max+ROWNUM ID, S.PRODUCTO, S.COSTOUNITARIO, 0 CANTIDAD, S.IDCATEGORIA FROM(SELECT DISTINCT TO_CHAR(EXT.C) PRODUCTO,TO_CHAR(EXT.J) COSTOUNITARIO,TO_CHAR(CAT.IDCATEGORIA) IDCATEGORIA FROM EXTERNA EXT, CATEGORIA CAT WHERE CAT.NOMBRE = EXT.E MINUS SELECT TO_CHAR(PRO.NOMBRE),TO_CHAR(PRO.COSTOUNITARIO),TO_CHAR(PRO.IDCATEGORIA) FROM PRODUCTO PRO) S)";
    ejecutar($conn, $sql);
}

function cargar_cargamento($conn){
    $sql="INSERT INTO CARGAMENTO(SELECT DISTINCT EXT.M IDCARGAMENTO,EXT.F FECHAINGINV,EXT.N CANTIDADLOTES,EXT.R CARGRECIBIDO,EXT.L MANIFIESTO,(SELECT IDPERSONA FROM PERSONA WHERE UPPER(REPLACE(NOMBRE||APELLIDO,' ','')) = UPPER(REPLACE(EXT.T,' ',''))) RECIBIDOPOR,(SELECT IDPERSONA FROM PERSONA WHERE UPPER(NOMBRE||APELLIDO) = UPPER(REPLACE(EXT.S,' ',''))) DELEGADO FROM EXTERNA EXT)";
    ejecutar($conn, $sql);
}

function cargar_lotes($conn){
    $sql="INSERT INTO LOTE(SELECT DISTINCT EXT.O NOLOTE,EXT.M IDCARGAMENTO,EXT.F FECHAINGINV,EXT.H FECHAPRODUCCION,EXT.I FECHAEXPIRACION,EXT.P CANTIDADCAJAS FROM EXTERNA EXT)";
    ejecutar($conn, $sql);
}

function cargar_ingreso($conn){
    $sql="INSERT INTO INGRESO(SELECT DENSE_RANK() OVER (PARTITION BY S.IDCARGAMENTO ORDER BY S.ID) IDINGRESO, S.NOLOTE,S.IDCARGAMENTO,S.FECHAINGINV,S.IDPRODUCTO,S.NOCAJA,S.IDOFERTA FROM (SELECT ROWNUM ID,EXT.O NOLOTE,EXT.M IDCARGAMENTO,EXT.F FECHAINGINV,PRO.IDPRODUCTO,EXT.Q NOCAJA,0 IDOFERTA FROM EXTERNA EXT, CATEGORIA CAT, PRODUCTO PRO WHERE UPPER(CAT.NOMBRE) LIKE UPPER(EXT.E) AND UPPER(PRO.NOMBRE) LIKE UPPER(EXT.C) AND PRO.IDCATEGORIA=CAT.IDCATEGORIA AND PRO.COSTOUNITARIO=EXT.J) S)";
    ejecutar($conn, $sql);
}

function cargar_venta($conn){
    /****tipo de entrega****/
    $sql="SELECT IDTIPOENTREGA FROM TIPOENTREGA WHERE UPPER(NOMBRE) LIKE UPPER('PRESENCIAL')";
    $res_tentrega=consultar($conn, $sql);
    odbc_fetch_row($res_tentrega);
    $id_tentrega=odbc_result($res_tentrega, 1);
    liberar($res_tentrega);
    /****tipo de pago****/
    $sql="SELECT IDTIPOPAGO FROM TIPOPAGO WHERE UPPER(NOMBRE) LIKE UPPER('EFECTIVO')";
    $res_tpago=consultar($conn, $sql);
    odbc_fetch_row($res_tpago);
    $id_tpago=odbc_result($res_tpago, 1);
    liberar($res_tpago);
    /****insertando****/
    $sql="SELECT DENSE_RANK() OVER (PARTITION BY S.FECHA ORDER BY S.NODOCPAGO,S.NOTARJETA,S.IDPERSONA) IDVENTA,S.FECHA,S.TOTAL,S.TIPOENTREGA,S.TIPOPAGO,S.NODOCPAGO,S.NOTARJETA,S.IDPERSONA FROM(SELECT ROWNUM ID,EXT.G FECHA,0 TOTAL,1 TIPOENTREGA,4 TIPOPAGO,EXT.Z NODOCPAGO,EXT.Z NOTARJETA,(SELECT PER.IDPERSONA FROM PERSONA PER WHERE UPPER(PER.NOMBRE||PER.APELLIDO) = UPPER(EXT.U||EXT.V)) IDPERSONA FROM EXTERNA EXT WHERE EXT.G NOT LIKE '-')S";
    $res=consultar($conn, $sql);
    while(odbc_fetch_row($res)){
        $idventa=odbc_result($res, "IDVENTA");
        $fecha=odbc_result($res, "FECHA");
        $total=odbc_result($res, "TOTAL");
        $tipoentrega=odbc_result($res, "TIPOENTREGA");
        $tipopago=odbc_result($res, "TIPOPAGO");
        $nodocpago=odbc_result($res, "NODOCPAGO");
        $notarjeta=odbc_result($res, "NOTARJETA");
        $idpersona=odbc_result($res, "IDPERSONA");
        if($notarjeta==0 || $notarjeta=='' || $notarjeta=='-'){
            $notarjeta=0;
            $sql="INSERT INTO TARJETA (SELECT TO_NUMBER($notarjeta),TO_NUMBER($idpersona),TO_NUMBER(0),TO_NUMBER(0),TO_NUMBER(1) FROM DUAL MINUS SELECT TO_NUMBER(NOTARJETA),TO_NUMBER(IDPERSONA),TO_NUMBER(LIMITE),TO_NUMBER(CODIGOAUTORIZACION),TO_NUMBER(IDTIPOTARJETA) FROM TARJETA)";
            ejecutar($conn, $sql);
        }
        $sql="INSERT INTO VENTA VALUES($idventa,'$fecha',$total,$tipoentrega,$tipopago,'$nodocpago',$notarjeta,$idpersona)";
        ejecutar($conn, $sql);
    }
}

function cargar_detalleventa($conn){
    $sql="INSERT INTO DETALLEVENTA(SELECT DENSE_RANK() OVER (PARTITION BY SS.FECHA,SS.IDVENTA ORDER BY SS.ID) IDDETALLE,SS.IDVENTA,SS.FECHA,SS.IDINGRESO,SS.IDLOTE,SS.IDCARGAMENTO,SS.FECHAINGINV,SS.IDPRODUCTO,SS.PRECIO FROM(SELECT ROWNUM ID, DENSE_RANK() OVER (PARTITION BY S.FECHA ORDER BY S.NODOCPAGO,S.NOTARJETA,S.IDPERSONA) IDVENTA,S.FECHA,(SELECT IDINGRESO FROM INGRESO WHERE IDLOTE=S.IDLOTE AND IDCARGAMENTO=S.IDCARGAMENTO AND FECHAINGRESOINVENTARIO=S.FECHAINGINV AND IDPRODUCTO=S.IDPRODUCTO AND NOCAJA=S.NOCAJA AND ROWNUM=1) IDINGRESO,S.IDLOTE,S.IDCARGAMENTO,S.FECHAINGINV,S.IDPRODUCTO,S.PRECIO FROM(SELECT EXT.G FECHA,EXT.Z NODOCPAGO,EXT.Z NOTARJETA,(SELECT PER.IDPERSONA FROM PERSONA PER WHERE UPPER(PER.NOMBRE||PER.APELLIDO) = UPPER(EXT.U||EXT.V)) IDPERSONA, EXT.O IDLOTE,EXT.M IDCARGAMENTO,EXT.F FECHAINGINV,PRO.IDPRODUCTO,EXT.J PRECIO,EXT.Q NOCAJA FROM EXTERNA EXT, PRODUCTO PRO, CATEGORIA CAT WHERE UPPER(CAT.NOMBRE) LIKE UPPER(EXT.E) AND PRO.IDCATEGORIA=CAT.IDCATEGORIA AND PRO.COSTOUNITARIO=EXT.J AND UPPER(PRO.NOMBRE) LIKE UPPER(EXT.C) AND EXT.G NOT LIKE '-')S)SS)";
    ejecutar($conn, $sql);
}

function cargar_ordencompra($conn){
    /****estado****/
    $sql="SELECT IDESTADO FROM ESTADO WHERE UPPER(NOMBRE) LIKE UPPER('A%')";
    $res_estado=consultar($conn, $sql);
    odbc_fetch_row($res_estado);
    $id_estado=odbc_result($res_estado, 1);
    liberar($res_estado);
    /****moneda****/
    $sql="SELECT IDMONEDA FROM MONEDA WHERE UPPER(SIMBOLO) LIKE UPPER('Q')";
    $res_moneda=consultar($conn, $sql);
    odbc_fetch_row($res_moneda);
    $id_moneda=odbc_result($res_moneda, 1);
    liberar($res_moneda);
    /****tipo operacion****/
    $sql="SELECT IDTIPOOPER FROM TIPOOPERACION WHERE UPPER(NOMBRE) LIKE UPPER('%COMPRA%')";
    $res_operacion=consultar($conn, $sql);
    odbc_fetch_row($res_operacion);
    $id_operacion=odbc_result($res_operacion, 1);
    liberar($res_operacion);
    /****tipo pago****/
    $sql="SELECT IDTIPOPAGO FROM TIPOPAGO WHERE UPPER(SUBSTR(NOMBRE,0,2)) LIKE UPPER(SUBSTR('EF',0,2))";
    $res_pago=consultar($conn, $sql);
    odbc_fetch_row($res_pago);
    $id_pago=odbc_result($res_pago, 1);
    liberar($res_pago);
    /****insertar****/
    $sql="INSERT INTO COTIZACION(SELECT DISTINCT EXT.A IDORDENCOMPRA,EXT.B FECHAESTIMADA, $id_estado IDESTADO,0 TOTAL,'-' JUST,'-' CODAPROB,$id_moneda IDMONEDA,$id_operacion IDTIPOOPER,$id_pago IDTIPOPAGO,0 IDSOLICITANTE,0 IDCREADOR,0 IDAUTORIZACION FROM EXTERNA EXT)";
    ejecutar($conn, $sql);
}

function cargar_detalleordencompra($conn){
    /****estado****/
    $sql="SELECT IDESTADO FROM ESTADO WHERE UPPER(NOMBRE) LIKE UPPER('A%')";
    $res_estado=consultar($conn, $sql);
    odbc_fetch_row($res_estado);
    $id_estado=odbc_result($res_estado, 1);
    liberar($res_estado);
    /****moneda****/
    $sql="SELECT IDMONEDA FROM MONEDA WHERE UPPER(SIMBOLO) LIKE UPPER('Q')";
    $res_moneda=consultar($conn, $sql);
    odbc_fetch_row($res_moneda);
    $id_moneda=odbc_result($res_moneda, 1);
    liberar($res_moneda);
    /****insertar****/
    $sql="INSERT INTO DETALLECOTIZACION(SELECT DENSE_RANK() OVER (PARTITION BY S.IDORDENCOMPRA,S.FECHAESTIMADA,S.IDESTADO ORDER BY S.ID) IDDETALLE,S.IDPRODUCTO,S.IDORDENCOMPRA,S.FECHAESTIMADA,S.IDESTADO,S.CANTIDAD,S.FECHAENTREGA,S.COSTOUNITARIO,S.IDMONEDA,S.SUBTOTAL FROM(SELECT ROWNUM ID,PRO.IDPRODUCTO,EXT.A IDORDENCOMPRA,EXT.B FECHAESTIMADA, $id_estado IDESTADO,0 CANTIDAD,'' FECHAENTREGA,EXT.K COSTOUNITARIO,$id_moneda IDMONEDA,0 SUBTOTAL FROM EXTERNA EXT, PRODUCTO PRO, CATEGORIA CAT WHERE UPPER(PRO.NOMBRE) LIKE UPPER(EXT.C) AND PRO.COSTOUNITARIO=EXT.J AND PRO.IDCATEGORIA=CAT.IDCATEGORIA AND UPPER(CAT.NOMBRE) LIKE UPPER(EXT.E))S)";
    ejecutar($conn, $sql);
}

function reporte1($conn){
    $sql="SELECT DISTINCT P.NOMBRE,CAT.NOMBRE CATEGORIA,P.COSTOUNITARIO PRECIO,'|' \" \",MIN(TO_DATE(D.FECHA,'MM/DD/YYYY') - TO_DATE(D.FECHAINGRESOINVENTARIO,'MM/DD/YYYY')) OVER (PARTITION BY P.NOMBRE,CAT.NOMBRE,P.COSTOUNITARIO)||' DIAS' MINIMO,MAX(TO_DATE(D.FECHA,'MM/DD/YYYY') - TO_DATE(D.FECHAINGRESOINVENTARIO,'MM/DD/YYYY')) OVER (PARTITION BY P.NOMBRE,CAT.NOMBRE,P.COSTOUNITARIO)||' DIAS' MAXIMO,AVG(TO_DATE(D.FECHA,'MM/DD/YYYY') - TO_DATE(D.FECHAINGRESOINVENTARIO,'MM/DD/YYYY')) OVER (PARTITION BY P.NOMBRE,CAT.NOMBRE,P.COSTOUNITARIO)||' DIAS' PROMEDIO FROM DETALLEVENTA D NATURAL JOIN PRODUCTO P,CATEGORIA CAT WHERE CAT.IDCATEGORIA = P.IDCATEGORIA";
    $res=consultar($conn, $sql);
    return $res;
}

function reporte2($conn){
    $sql="SELECT NOMBRE PRODUCTO,FECHADETALLE \"NO ITEM\",TO_CHAR(TO_DATE(FECHACOTIZACION,'MM/DD/YYYY'),'DD - MONTH - YYYY') \"FECHA ESTIMADA RECEPCION\",TO_DATE(SYSDATE,'MM/DD/YYYY') - TO_DATE(FECHACOTIZACION,'MM/DD/YYYY')||' DIAS' RETRASO FROM(SELECT IDPRODUCTO FROM DETALLECOTIZACION WHERE TO_DATE(FECHACOTIZACION,'MM/DD/YYYY') < TO_DATE(SYSDATE,'MM/DD/YYYY')MINUS(SELECT IDPRODUCTO FROM INGRESO)) NATURAL JOIN DETALLECOTIZACION NATURAL JOIN PRODUCTO ORDER BY \"NO ITEM\"";
    $res=consultar($conn, $sql);
    return $res;
}

function reporte3($conn,$inicio,$fin){
    $sql="SELECT DISTINCT P.NOMBRE PRODUCTO,CAT.NOMBRE CATEGORIA,P.COSTOUNITARIO PRECIO,TO_CHAR(TO_DATE(I.FECHAINGRESOINVENTARIO,'MM/DD/YYYY'),'DD - MONTH - YYYY') \"FECHA INGRESO\",'|' \" \",TO_CHAR(TO_DATE(D.FECHACOTIZACION,'MM/DD/YYYY'),'DD - MONTH - YYYY') \"FECHA ESTIMADA RECEPCION\" FROM INGRESO I NATURAL JOIN PRODUCTO P NATURAL JOIN DETALLECOTIZACION D,CATEGORIA CAT WHERE CAT.IDCATEGORIA=P.IDCATEGORIA AND TO_DATE(I.FECHAINGRESOINVENTARIO,'MM/DD/YYYY') > TO_DATE('$inicio','MM/DD/YYYY') AND TO_DATE(I.FECHAINGRESOINVENTARIO,'MM/DD/YYYY') < TO_DATE('$fin','MM/DD/YYYY') ORDER BY PRODUCTO,CATEGORIA,PRECIO,\"FECHA INGRESO\"";
    $res=consultar($conn, $sql);
    return $res;
}

function reporte4($conn){
    $sql="SELECT DISTINCT P.NOMBRE PRODUCTO,CAT.NOMBRE CATEGORIA,P.COSTOUNITARIO PRECIO,FECHAPRODUCCION,FECHAEXPIRACION,TO_DATE(FECHAEXPIRACION,'MM/DD/YYYY') - TO_DATE(SYSDATE,'MM/DD/YYYY') CADUCIDAD FROM LOTE NATURAL JOIN INGRESO NATURAL JOIN PRODUCTO P,CATEGORIA CAT WHERE CAT.IDCATEGORIA=P.IDCATEGORIA AND (TO_DATE(FECHAEXPIRACION,'MM/DD/YYYY') - TO_DATE(SYSDATE,'MM/DD/YYYY')) <= 100 AND (TO_DATE(FECHAEXPIRACION,'MM/DD/YYYY') - TO_DATE(SYSDATE,'MM/DD/YYYY')) > 0";
    $res=consultar($conn, $sql);
    return $res;
}

function reporte5($conn,$inicio,$fin,$cargamento,$lote,$caja){
    $sql="SELECT DISTINCT MANIFIESTO,IDCARGAMENTO \"NO. CARGAMENTO\",TO_CHAR(TO_DATE(FECHAINGRESOINVENTARIO,'MM/DD/YYYY'),'DD - MONTH - YYYY') \"FECHA DE INGRESO\",(SELECT NOMBRE||' '||APELLIDO FROM PERSONA WHERE IDPERSONA=RECIBIDOPOR) \"RECIBIDO POR\",(SELECT NOMBRE||' '||APELLIDO FROM PERSONA WHERE IDPERSONA=DELEGADO) DELEGADO,CANTIDADLOTES \"NO LOTES\",IDLOTE LOTE,TO_CHAR(TO_DATE(FECHAPRODUCCION,'MM/DD/YYYY'),'DD - MONTH - YYYY') PRODUCCION,TO_CHAR(TO_DATE(FECHAEXPIRACION,'MM/DD/YYYY'),'DD - MONTH - YYYY') EXPIRA,CANTIDADCAJAS \"NO CAJAS\",NOCAJA CAJA,P.NOMBRE PRODUCTO,P.COSTOUNITARIO PRECIO,CAT.NOMBRE CATEGORIA FROM INGRESO NATURAL JOIN PRODUCTO P NATURAL JOIN CARGAMENTO NATURAL JOIN LOTE,CATEGORIA CAT WHERE CAT.IDCATEGORIA=P.IDCATEGORIA ".(((isset($cargamento)&&$cargamento<>'')||(isset($lote)&&$lote<>'')||(isset($caja)&&$caja<>''))?"AND IDCARGAMENTO=NVL('$cargamento',IDCARGAMENTO) AND IDLOTE=NVL('$lote',IDLOTE) AND NOCAJA=NVL('$caja',NOCAJA)":"AND TO_DATE(FECHAINGRESOINVENTARIO,'MM/DD/YYYY') > TO_DATE('$inicio','MM/DD/YYYY') AND TO_DATE(FECHAINGRESOINVENTARIO,'MM/DD/YYYY') < TO_DATE('$fin','MM/DD/YYYY')");
    $res=consultar($conn, $sql);
    return $res;
}

function reporte6($conn){
    $sql="SELECT DISTINCT SS.PRODUCTO,SS.PRECIO,SS.CATEGORIA,(SELECT COUNT(1) FROM INGRESO NATURAL JOIN PRODUCTO WHERE IDPRODUCTO=SS.IDPRODUCTO AND IDCATEGORIA=SS.IDCATEGORIA AND COSTOUNITARIO=SS.PRECIO)-(SELECT COUNT(1) FROM DETALLEVENTA NATURAL JOIN PRODUCTO WHERE IDPRODUCTO=SS.IDPRODUCTO AND IDCATEGORIA=SS.IDCATEGORIA AND PRECIO=SS.PRECIO) \"VOLUMEN ACTUAL\",AVG(SS.VENTASMES) OVER (PARTITION BY SS.PRODUCTO,SS.PRECIO,SS.CATEGORIA) \"PROMEDIO VENTA MES\" FROM(SELECT S.IDPRODUCTO,S.PRODUCTO,S.PRECIO,S.IDCATEGORIA,S.CATEGORIA,COUNT(1) OVER (PARTITION BY S.PRODUCTO,S.PRECIO,S.CATEGORIA,S.FECHAVENTA) VENTASMES FROM(SELECT IDPRODUCTO,P.NOMBRE PRODUCTO,P.COSTOUNITARIO PRECIO,P.IDCATEGORIA,CAT.NOMBRE CATEGORIA,TO_CHAR(TO_DATE(FECHA,'MM/DD/YYYY'),'MM/YYYY') FECHAVENTA FROM PRODUCTO P NATURAL JOIN DETALLEVENTA,CATEGORIA CAT WHERE CAT.IDCATEGORIA=P.IDCATEGORIA)S)SS";
    $res=consultar($conn, $sql);
    return $res;
}

function reporte7a($conn){
    $sql="SELECT ROWNUM,S.PRODUCTO,S.COSTOUNITARIO,S.CATEGORIA,S.CANTIDAD FROM (SELECT DISTINCT P.NOMBRE PRODUCTO,P.COSTOUNITARIO,CAT.NOMBRE CATEGORIA,COUNT(1) OVER (PARTITION BY P.NOMBRE,P.COSTOUNITARIO,CAT.NOMBRE) CANTIDAD FROM DEVOLUCIONVENTA NATURAL JOIN DETALLEVENTA NATURAL JOIN PRODUCTO P INNER JOIN CATEGORIA CAT USING (IDCATEGORIA) ORDER BY CANTIDAD DESC)S WHERE ROWNUM<=3";
    $res=consultar($conn, $sql);
    return $res;
}

function reporte7b($conn){
    $sql="SELECT ROWNUM,SS.* FROM(SELECT S.PRODUCTO,S.COSTOUNITARIO,S.CATEGORIA,S.CANTIDAD,S.COSTOUNITARIO*S.CANTIDAD PERDIDA FROM (SELECT DISTINCT P.NOMBRE PRODUCTO,P.COSTOUNITARIO,CAT.NOMBRE CATEGORIA,COUNT(1) OVER (PARTITION BY P.NOMBRE,P.COSTOUNITARIO,CAT.NOMBRE) CANTIDAD FROM DEVOLUCIONVENTA NATURAL JOIN DETALLEVENTA NATURAL JOIN PRODUCTO P INNER JOIN CATEGORIA CAT USING (IDCATEGORIA))S ORDER BY PERDIDA DESC)SS WHERE ROWNUM<=3";
    $res=consultar($conn, $sql);
    return $res;
}

function reporte8($conn,$idventa,$fecha){
    $sql="SELECT IDINGRESO,IDLOTE,IDCARGAMENTO,FECHAINGRESOINVENTARIO,IDPRODUCTO,NOCAJA FROM DETALLEVENTA NATURAL JOIN INGRESO WHERE IDVENTA=$idventa AND TO_DATE(FECHA,'MM/DD/YYYY') = TO_DATE('$fecha','MM/DD/YYYY')";
    $res=consultar($conn, $sql);
    return $res;
}
?>
