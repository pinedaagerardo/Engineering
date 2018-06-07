--
-- ER/Studio 7.1 SQL Code Generation
-- Company :      ygeR@ZWT
-- Project :      erp2.dm1
-- Author :       asdf
--
-- Date Created : Thursday, May 06, 2010 16:39:34
-- Target DBMS : Oracle 10g
--

-- 
-- TABLE: Area 
--

CREATE TABLE Area(
    idArea    NUMBER(10, 0)    NOT NULL,
    nombre    VARCHAR2(80)     NOT NULL,
    CONSTRAINT PK2 PRIMARY KEY (idArea)
)
;



-- 
-- TABLE: Caso 
--

CREATE TABLE Caso(
    idCaso                   NUMBER(10, 0)    NOT NULL,
    consultor_idConsultor    NUMBER(10, 0)    NOT NULL,
    area_idArea              NUMBER(10, 0)    NOT NULL,
    producto_idProducto      NUMBER(10, 0)    NOT NULL,
    cliente_idCliente        NUMBER(10, 0)    NOT NULL,
    contacto                 VARCHAR2(80),
    inicio                   VARCHAR2(80),
    versionSO                VARCHAR2(80),
    severidad                VARCHAR2(80),
    descripcion              VARCHAR2(80),
    estado                   VARCHAR2(80),
    actualizado              VARCHAR2(80),
    detalle                  VARCHAR2(80),
    CONSTRAINT PK7 PRIMARY KEY (idCaso, consultor_idConsultor, area_idArea, producto_idProducto, cliente_idCliente)
)
;



-- 
-- TABLE: Cliente 
--

CREATE TABLE Cliente(
    idCliente    NUMBER(10, 0)    NOT NULL,
    sector       VARCHAR2(80),
    nombre       VARCHAR2(80),
    direccion    VARCHAR2(80),
    contacto     VARCHAR2(80),
    puesto       VARCHAR2(80),
    email        VARCHAR2(80),
    admin        VARCHAR2(1),
    tecnico      VARCHAR2(1),
    CONSTRAINT PK8 PRIMARY KEY (idCliente)
)
;



-- 
-- TABLE: Consultor 
--

CREATE TABLE Consultor(
    idConsultor    NUMBER(10, 0)    NOT NULL,
    area_idArea    NUMBER(10, 0)    NOT NULL,
    nombres        VARCHAR2(80),
    email          VARCHAR2(80),
    CONSTRAINT PK6 PRIMARY KEY (idConsultor, area_idArea)
)
;



-- 
-- TABLE: Licencia 
--

CREATE TABLE Licencia(
    idLicencia           NUMBER(10, 0)    NOT NULL,
    cliente_idCliente    NUMBER(10, 0)    NOT NULL,
    producto             VARCHAR2(80),
    sistOperativo        VARCHAR2(80),
    tipo                 VARCHAR2(80),
    cantUsuarios         NUMBER(10, 0),
    inicio               VARCHAR2(80),
    fin                  VARCHAR2(80),
    CONSTRAINT PK10 PRIMARY KEY (idLicencia, cliente_idCliente)
)
;



-- 
-- TABLE: Producto 
--

CREATE TABLE Producto(
    idProducto     NUMBER(10, 0)    NOT NULL,
    area_idArea    NUMBER(10, 0)    NOT NULL,
    nombre         VARCHAR2(80),
    CONSTRAINT PK3 PRIMARY KEY (idProducto, area_idArea)
)
;



-- 
-- TABLE: Venta 
--

CREATE TABLE Venta(
    idVenta                NUMBER(10, 0)    NOT NULL,
    cliente_idCliente      NUMBER(10, 0)    NOT NULL,
    producto_idProducto    NUMBER(10, 0)    NOT NULL,
    area_idArea            NUMBER(10, 0)    NOT NULL,
    licencia_idLicencia    NUMBER(10, 0)    NOT NULL,
    unidades               NUMBER(10, 0),
    sistOperativo          VARCHAR2(80),
    inicio                 VARCHAR2(80),
    fin                    VARCHAR2(80),
    CONSTRAINT PK9 PRIMARY KEY (idVenta, cliente_idCliente, producto_idProducto, area_idArea, licencia_idLicencia)
)
;



-- 
-- TABLE: Caso 
--

ALTER TABLE Caso ADD CONSTRAINT RefConsultor6 
    FOREIGN KEY (consultor_idConsultor, area_idArea)
    REFERENCES Consultor(idConsultor, area_idArea) ON DELETE CASCADE
;

ALTER TABLE Caso ADD CONSTRAINT RefProducto7 
    FOREIGN KEY (producto_idProducto, area_idArea)
    REFERENCES Producto(idProducto, area_idArea) ON DELETE CASCADE
;

ALTER TABLE Caso ADD CONSTRAINT RefCliente8 
    FOREIGN KEY (cliente_idCliente)
    REFERENCES Cliente(idCliente) ON DELETE CASCADE
;


-- 
-- TABLE: Consultor 
--

ALTER TABLE Consultor ADD CONSTRAINT RefArea5 
    FOREIGN KEY (area_idArea)
    REFERENCES Area(idArea) ON DELETE CASCADE
;


-- 
-- TABLE: Licencia 
--

ALTER TABLE Licencia ADD CONSTRAINT RefCliente11 
    FOREIGN KEY (cliente_idCliente)
    REFERENCES Cliente(idCliente) ON DELETE CASCADE
;


-- 
-- TABLE: Producto 
--

ALTER TABLE Producto ADD CONSTRAINT RefArea4 
    FOREIGN KEY (area_idArea)
    REFERENCES Area(idArea) ON DELETE CASCADE
;


-- 
-- TABLE: Venta 
--

ALTER TABLE Venta ADD CONSTRAINT RefCliente9 
    FOREIGN KEY (cliente_idCliente)
    REFERENCES Cliente(idCliente) ON DELETE CASCADE
;

ALTER TABLE Venta ADD CONSTRAINT RefProducto10 
    FOREIGN KEY (producto_idProducto, area_idArea)
    REFERENCES Producto(idProducto, area_idArea) ON DELETE CASCADE
;

ALTER TABLE Venta ADD CONSTRAINT RefLicencia12 
    FOREIGN KEY (licencia_idLicencia, cliente_idCliente)
    REFERENCES Licencia(idLicencia, cliente_idCliente) ON DELETE CASCADE
;


-- 
-- PROCEDURE: AreaInsProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE AreaInsProc 
( 
    v_idArea      IN NUMBER, 
    v_nombre      IN VARCHAR2) 
AS 
BEGIN 
    INSERT INTO Area(idArea, 
                     nombre) 
    VALUES(v_idArea, 
           v_nombre); 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: AreaUpdProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE AreaUpdProc 
( 
    v_idArea      IN NUMBER, 
    v_nombre      IN VARCHAR2) 
AS 
BEGIN 
    UPDATE Area 
       SET nombre      = v_nombre 
     WHERE idArea = v_idArea; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: AreaDelProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE AreaDelProc 
( 
    v_idArea      IN NUMBER) 
AS 
BEGIN 
    DELETE 
      FROM Area 
     WHERE idArea = v_idArea; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 


-- 
-- PROCEDURE: CasoInsProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE CasoInsProc 
( 
    v_idCaso                     IN NUMBER, 
    v_consultor_idConsultor      IN NUMBER, 
    v_area_idArea                IN NUMBER, 
    v_producto_idProducto        IN NUMBER, 
    v_cliente_idCliente          IN NUMBER, 
    v_contacto                   IN VARCHAR2, 
    v_inicio                     IN VARCHAR2, 
    v_versionSO                  IN VARCHAR2, 
    v_severidad                  IN VARCHAR2, 
    v_descripcion                IN VARCHAR2, 
    v_estado                     IN VARCHAR2, 
    v_actualizado                IN VARCHAR2, 
    v_detalle                    IN VARCHAR2) 
AS 
BEGIN 
    INSERT INTO Caso(idCaso, 
                     consultor_idConsultor, 
                     area_idArea, 
                     producto_idProducto, 
                     cliente_idCliente, 
                     contacto, 
                     inicio, 
                     versionSO, 
                     severidad, 
                     descripcion, 
                     estado, 
                     actualizado, 
                     detalle) 
    VALUES(v_idCaso, 
           v_consultor_idConsultor, 
           v_area_idArea, 
           v_producto_idProducto, 
           v_cliente_idCliente, 
           v_contacto, 
           v_inicio, 
           v_versionSO, 
           v_severidad, 
           v_descripcion, 
           v_estado, 
           v_actualizado, 
           v_detalle); 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: CasoUpdProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE CasoUpdProc 
( 
    v_idCaso                     IN NUMBER, 
    v_consultor_idConsultor      IN NUMBER, 
    v_area_idArea                IN NUMBER, 
    v_producto_idProducto        IN NUMBER, 
    v_cliente_idCliente          IN NUMBER, 
    v_contacto                   IN VARCHAR2, 
    v_inicio                     IN VARCHAR2, 
    v_versionSO                  IN VARCHAR2, 
    v_severidad                  IN VARCHAR2, 
    v_descripcion                IN VARCHAR2, 
    v_estado                     IN VARCHAR2, 
    v_actualizado                IN VARCHAR2, 
    v_detalle                    IN VARCHAR2) 
AS 
BEGIN 
    UPDATE Caso 
       SET contacto                   = v_contacto, 
           inicio                     = v_inicio, 
           versionSO                  = v_versionSO, 
           severidad                  = v_severidad, 
           descripcion                = v_descripcion, 
           estado                     = v_estado, 
           actualizado                = v_actualizado, 
           detalle                    = v_detalle 
     WHERE idCaso                = v_idCaso 
       AND consultor_idConsultor = v_consultor_idConsultor 
       AND area_idArea           = v_area_idArea 
       AND producto_idProducto   = v_producto_idProducto 
       AND cliente_idCliente     = v_cliente_idCliente; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: CasoDelProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE CasoDelProc 
( 
    v_idCaso                     IN NUMBER, 
    v_consultor_idConsultor      IN NUMBER, 
    v_area_idArea                IN NUMBER, 
    v_producto_idProducto        IN NUMBER, 
    v_cliente_idCliente          IN NUMBER) 
AS 
BEGIN 
    DELETE 
      FROM Caso 
     WHERE idCaso                = v_idCaso 
       AND consultor_idConsultor = v_consultor_idConsultor 
       AND area_idArea           = v_area_idArea 
       AND producto_idProducto   = v_producto_idProducto 
       AND cliente_idCliente     = v_cliente_idCliente; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 


-- 
-- PROCEDURE: ClienteInsProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE ClienteInsProc 
( 
    v_idCliente      IN NUMBER, 
    v_sector         IN VARCHAR2, 
    v_nombre         IN VARCHAR2, 
    v_direccion      IN VARCHAR2, 
    v_contacto       IN VARCHAR2, 
    v_puesto         IN VARCHAR2, 
    v_email          IN VARCHAR2, 
    v_admin          IN VARCHAR2, 
    v_tecnico        IN VARCHAR2) 
AS 
BEGIN 
    INSERT INTO Cliente(idCliente, 
                        sector, 
                        nombre, 
                        direccion, 
                        contacto, 
                        puesto, 
                        email, 
                        admin, 
                        tecnico) 
    VALUES(v_idCliente, 
           v_sector, 
           v_nombre, 
           v_direccion, 
           v_contacto, 
           v_puesto, 
           v_email, 
           v_admin, 
           v_tecnico); 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: ClienteUpdProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE ClienteUpdProc 
( 
    v_idCliente      IN NUMBER, 
    v_sector         IN VARCHAR2, 
    v_nombre         IN VARCHAR2, 
    v_direccion      IN VARCHAR2, 
    v_contacto       IN VARCHAR2, 
    v_puesto         IN VARCHAR2, 
    v_email          IN VARCHAR2, 
    v_admin          IN VARCHAR2, 
    v_tecnico        IN VARCHAR2) 
AS 
BEGIN 
    UPDATE Cliente 
       SET sector         = v_sector, 
           nombre         = v_nombre, 
           direccion      = v_direccion, 
           contacto       = v_contacto, 
           puesto         = v_puesto, 
           email          = v_email, 
           admin          = v_admin, 
           tecnico        = v_tecnico 
     WHERE idCliente = v_idCliente; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: ClienteDelProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE ClienteDelProc 
( 
    v_idCliente      IN NUMBER) 
AS 
BEGIN 
    DELETE 
      FROM Cliente 
     WHERE idCliente = v_idCliente; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 


-- 
-- PROCEDURE: ConsultorInsProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE ConsultorInsProc 
( 
    v_idConsultor      IN NUMBER, 
    v_area_idArea      IN NUMBER, 
    v_nombres          IN VARCHAR2, 
    v_email            IN VARCHAR2) 
AS 
BEGIN 
    INSERT INTO Consultor(idConsultor, 
                          area_idArea, 
                          nombres, 
                          email) 
    VALUES(v_idConsultor, 
           v_area_idArea, 
           v_nombres, 
           v_email); 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: ConsultorUpdProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE ConsultorUpdProc 
( 
    v_idConsultor      IN NUMBER, 
    v_area_idArea      IN NUMBER, 
    v_nombres          IN VARCHAR2, 
    v_email            IN VARCHAR2) 
AS 
BEGIN 
    UPDATE Consultor 
       SET nombres          = v_nombres, 
           email            = v_email 
     WHERE idConsultor = v_idConsultor 
       AND area_idArea = v_area_idArea; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: ConsultorDelProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE ConsultorDelProc 
( 
    v_idConsultor      IN NUMBER, 
    v_area_idArea      IN NUMBER) 
AS 
BEGIN 
    DELETE 
      FROM Consultor 
     WHERE idConsultor = v_idConsultor 
       AND area_idArea = v_area_idArea; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 


-- 
-- PROCEDURE: LicenciaInsProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE LicenciaInsProc 
( 
    v_idLicencia             IN NUMBER, 
    v_cliente_idCliente      IN NUMBER, 
    v_producto               IN VARCHAR2, 
    v_sistOperativo          IN VARCHAR2, 
    v_tipo                   IN VARCHAR2, 
    v_cantUsuarios           IN NUMBER, 
    v_inicio                 IN VARCHAR2, 
    v_fin                    IN VARCHAR2) 
AS 
BEGIN 
    INSERT INTO Licencia(idLicencia, 
                         cliente_idCliente, 
                         producto, 
                         sistOperativo, 
                         tipo, 
                         cantUsuarios, 
                         inicio, 
                         fin) 
    VALUES(v_idLicencia, 
           v_cliente_idCliente, 
           v_producto, 
           v_sistOperativo, 
           v_tipo, 
           v_cantUsuarios, 
           v_inicio, 
           v_fin); 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: LicenciaUpdProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE LicenciaUpdProc 
( 
    v_idLicencia             IN NUMBER, 
    v_cliente_idCliente      IN NUMBER, 
    v_producto               IN VARCHAR2, 
    v_sistOperativo          IN VARCHAR2, 
    v_tipo                   IN VARCHAR2, 
    v_cantUsuarios           IN NUMBER, 
    v_inicio                 IN VARCHAR2, 
    v_fin                    IN VARCHAR2) 
AS 
BEGIN 
    UPDATE Licencia 
       SET producto               = v_producto, 
           sistOperativo          = v_sistOperativo, 
           tipo                   = v_tipo, 
           cantUsuarios           = v_cantUsuarios, 
           inicio                 = v_inicio, 
           fin                    = v_fin 
     WHERE idLicencia        = v_idLicencia 
       AND cliente_idCliente = v_cliente_idCliente; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: LicenciaDelProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE LicenciaDelProc 
( 
    v_idLicencia             IN NUMBER, 
    v_cliente_idCliente      IN NUMBER) 
AS 
BEGIN 
    DELETE 
      FROM Licencia 
     WHERE idLicencia        = v_idLicencia 
       AND cliente_idCliente = v_cliente_idCliente; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 


-- 
-- PROCEDURE: ProductoInsProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE ProductoInsProc 
( 
    v_idProducto       IN NUMBER, 
    v_area_idArea      IN NUMBER, 
    v_nombre           IN VARCHAR2) 
AS 
BEGIN 
    INSERT INTO Producto(idProducto, 
                         area_idArea, 
                         nombre) 
    VALUES(v_idProducto, 
           v_area_idArea, 
           v_nombre); 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: ProductoUpdProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE ProductoUpdProc 
( 
    v_idProducto       IN NUMBER, 
    v_area_idArea      IN NUMBER, 
    v_nombre           IN VARCHAR2) 
AS 
BEGIN 
    UPDATE Producto 
       SET nombre           = v_nombre 
     WHERE idProducto  = v_idProducto 
       AND area_idArea = v_area_idArea; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: ProductoDelProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE ProductoDelProc 
( 
    v_idProducto       IN NUMBER, 
    v_area_idArea      IN NUMBER) 
AS 
BEGIN 
    DELETE 
      FROM Producto 
     WHERE idProducto  = v_idProducto 
       AND area_idArea = v_area_idArea; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 


-- 
-- PROCEDURE: VentaInsProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE VentaInsProc 
( 
    v_idVenta                  IN NUMBER, 
    v_cliente_idCliente        IN NUMBER, 
    v_producto_idProducto      IN NUMBER, 
    v_area_idArea              IN NUMBER, 
    v_licencia_idLicencia      IN NUMBER, 
    v_unidades                 IN NUMBER, 
    v_sistOperativo            IN VARCHAR2, 
    v_inicio                   IN VARCHAR2, 
    v_fin                      IN VARCHAR2) 
AS 
BEGIN 
    INSERT INTO Venta(idVenta, 
                      cliente_idCliente, 
                      producto_idProducto, 
                      area_idArea, 
                      licencia_idLicencia, 
                      unidades, 
                      sistOperativo, 
                      inicio, 
                      fin) 
    VALUES(v_idVenta, 
           v_cliente_idCliente, 
           v_producto_idProducto, 
           v_area_idArea, 
           v_licencia_idLicencia, 
           v_unidades, 
           v_sistOperativo, 
           v_inicio, 
           v_fin); 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: VentaUpdProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE VentaUpdProc 
( 
    v_idVenta                  IN NUMBER, 
    v_cliente_idCliente        IN NUMBER, 
    v_producto_idProducto      IN NUMBER, 
    v_area_idArea              IN NUMBER, 
    v_licencia_idLicencia      IN NUMBER, 
    v_unidades                 IN NUMBER, 
    v_sistOperativo            IN VARCHAR2, 
    v_inicio                   IN VARCHAR2, 
    v_fin                      IN VARCHAR2) 
AS 
BEGIN 
    UPDATE Venta 
       SET unidades                 = v_unidades, 
           sistOperativo            = v_sistOperativo, 
           inicio                   = v_inicio, 
           fin                      = v_fin 
     WHERE idVenta             = v_idVenta 
       AND cliente_idCliente   = v_cliente_idCliente 
       AND producto_idProducto = v_producto_idProducto 
       AND area_idArea         = v_area_idArea 
       AND licencia_idLicencia = v_licencia_idLicencia; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 

-- 
-- PROCEDURE: VentaDelProc 
--

-- BEGIN PL/SQL BLOCK (do not remove this line) -------------------------------- 
CREATE OR REPLACE PROCEDURE VentaDelProc 
( 
    v_idVenta                  IN NUMBER, 
    v_cliente_idCliente        IN NUMBER, 
    v_producto_idProducto      IN NUMBER, 
    v_area_idArea              IN NUMBER, 
    v_licencia_idLicencia      IN NUMBER) 
AS 
BEGIN 
    DELETE 
      FROM Venta 
     WHERE idVenta             = v_idVenta 
       AND cliente_idCliente   = v_cliente_idCliente 
       AND producto_idProducto = v_producto_idProducto 
       AND area_idArea         = v_area_idArea 
       AND licencia_idLicencia = v_licencia_idLicencia; 
 
END; 
 
-- END PL/SQL BLOCK (do not remove this line) ---------------------------------- 
/ 


