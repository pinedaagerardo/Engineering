--tipotarjeta
insert into tipopersona values(1,'PROVEEDOR');
insert into tipopersona values(2,'CLIENTE');
insert into tipopersona values(3,'EMPLEADO');
insert into tipopersona values(4,'OTRO');
--tipopersona
insert into tipotarjeta values(1,'CREDITO');
insert into tipotarjeta values(2,'DEBITO');
insert into tipotarjeta values(3,'ESPECIAL');
--tipopago
insert into tipopago values(1,'CREDITO');
insert into tipopago values(2,'DEBITO');
insert into tipopago values(3,'CHEQUE');
insert into tipopago values(4,'EFECTIVO');
insert into tipopago values(5,'ESPECIAL');
--estado
insert into estado values(1,'SOLICITADO');
insert into estado values(2,'AUTORIZADO');
--tipooperacion
insert into tipooperacion values(1,'COTIZACION');
insert into tipooperacion values(2,'COMPRA');
--moneda
insert into moneda values(1,'QUETZAL','Q',1);
insert into moneda values(2,'DOLAR','$',8);
insert into moneda values(3,'EURO','Euro',10);
insert into moneda values(4,'YEN','Yen',13);
--tipoentrega
insert into tipoentrega values(1,'PRESENCIAL');
insert into tipoentrega values(2,'DOMICILIO');
--tipooferta
insert into tipooferta values(1,'DESCUENTO');
insert into tipooferta values(2,'INCREMENTO');
--tipounidad
insert into tipounidad values(1,'%');
insert into tipounidad values(2,'U');
--categoria
insert into categoria values(0,0,'RAIZ');
--oferta
insert into oferta values(0,'ninguna',0,1,1);
--persona
insert into persona values(0,'-','-','-',0,'M','-','-',1);
commit;
