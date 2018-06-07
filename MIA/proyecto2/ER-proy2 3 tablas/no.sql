SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci ;

-- -----------------------------------------------------
-- Table `mydb`.`Cliente`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`Cliente` (
  `idCliente` INT NOT NULL ,
  `sector` VARCHAR(45) NULL ,
  `nombre` VARCHAR(45) NULL ,
  `direccion` VARCHAR(45) NULL ,
  `contacto` VARCHAR(45) NULL ,
  `puesto` VARCHAR(45) NULL ,
  `email` VARCHAR(45) NULL ,
  `admin` CHAR NULL ,
  `tecnico` CHAR NULL ,
  PRIMARY KEY (`idCliente`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Caso`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`Caso` (
  `idCaso` INT NOT NULL ,
  `contacto` VARCHAR(45) NULL ,
  `inicio` DATETIME NULL ,
  `versionSO` VARCHAR(45) NULL ,
  `Consultor` VARCHAR(45) NULL ,
  `severidad` VARCHAR(45) NULL ,
  `descripcion` VARCHAR(80) NULL ,
  `estado` VARCHAR(45) NULL ,
  `Cliente_idCliente` INT NOT NULL ,
  `Producto` VARCHAR(45) NULL ,
  `actualizado` DATETIME NULL ,
  `detalle` VARCHAR(45) NULL ,
  `areaProducto` VARCHAR(45) NULL ,
  `emailConsultor` VARCHAR(45) NULL ,
  `areaConsultor` VARCHAR(45) NULL ,
  PRIMARY KEY (`idCaso`) ,
  INDEX `fk_Caso_Cliente1` (`Cliente_idCliente` ASC) ,
  CONSTRAINT `fk_Caso_Cliente1`
    FOREIGN KEY (`Cliente_idCliente` )
    REFERENCES `mydb`.`Cliente` (`idCliente` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Venta`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`Venta` (
  `idVenta` INT NOT NULL ,
  `Cliente_idCliente` INT NOT NULL ,
  `tipoLicencia` VARCHAR(45) NULL ,
  `unidades` INT NULL ,
  `Producto` VARCHAR(45) NULL ,
  `sistOperativo` VARCHAR(45) NULL ,
  `inicio` DATETIME NULL ,
  `fin` DATETIME NULL ,
  `areaProducto` VARCHAR(45) NULL ,
  PRIMARY KEY (`idVenta`) ,
  INDEX `fk_Venta_Cliente1` (`Cliente_idCliente` ASC) ,
  CONSTRAINT `fk_Venta_Cliente1`
    FOREIGN KEY (`Cliente_idCliente` )
    REFERENCES `mydb`.`Cliente` (`idCliente` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
