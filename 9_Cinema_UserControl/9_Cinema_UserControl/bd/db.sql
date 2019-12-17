-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `mydb` ;

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`sala`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`sala` (
  `sal_id` INT(11) NOT NULL,
  `sal_nom` VARCHAR(45) NOT NULL,
  `sal_adreca` VARCHAR(200) NOT NULL,
  `sal_municipi` VARCHAR(45) NOT NULL,
  `sal_telefon` VARCHAR(9) NULL DEFAULT NULL,
  PRIMARY KEY (`sal_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`cadcategoria`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`cadcategoria` (
  `cat_sal_id` INT(11) NOT NULL,
  `cat_num` INT(11) NOT NULL,
  `cat_nom` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`cat_sal_id`, `cat_num`),
  INDEX `fk_Categoria_Sala1_idx` (`cat_sal_id` ASC),
  CONSTRAINT `fk_Categoria_Sala1`
    FOREIGN KEY (`cat_sal_id`)
    REFERENCES `mydb`.`sala` (`sal_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`cadira`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`cadira` (
  `cad_sal_id` INT(11) NOT NULL,
  `cad_num` INT(11) NOT NULL,
  `cad_x` INT(11) NOT NULL,
  `cad_y` INT(11) NOT NULL,
  `cad_cat_num` INT(11) NOT NULL,
  `cad_desc` VARCHAR(40) NULL DEFAULT NULL,
  PRIMARY KEY (`cad_sal_id`, `cad_num`),
  INDEX `fk_Cadira_Sala_idx` (`cad_sal_id` ASC),
  INDEX `fk_Cadira_Categoria1_idx` (`cad_sal_id` ASC, `cad_cat_num` ASC),
  CONSTRAINT `fk_Cadira_Categoria1`
    FOREIGN KEY (`cad_sal_id` , `cad_cat_num`)
    REFERENCES `mydb`.`cadcategoria` (`cat_sal_id` , `cat_num`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Cadira_Sala`
    FOREIGN KEY (`cad_sal_id`)
    REFERENCES `mydb`.`sala` (`sal_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`catespectacle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`catespectacle` (
  `cae_id` INT NOT NULL,
  `cae_nom` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`cae_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`espectacle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`espectacle` (
  `esp_id` INT(11) NOT NULL,
  `esp_nom` VARCHAR(200) NOT NULL,
  `esp_data_inici` DATETIME NOT NULL,
  `esp_data_fi` DATE NULL DEFAULT NULL,
  `esp_sal_id` INT(11) NOT NULL,
  `esp_cae_id` INT NOT NULL,
  `esp_desc` VARCHAR(1000) NULL,
  PRIMARY KEY (`esp_id`),
  INDEX `fk_Espectacle_Sala1_idx` (`esp_sal_id` ASC),
  INDEX `fk_espectacle_catespectacle1_idx` (`esp_cae_id` ASC),
  CONSTRAINT `fk_Espectacle_Sala1`
    FOREIGN KEY (`esp_sal_id`)
    REFERENCES `mydb`.`sala` (`sal_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_espectacle_catespectacle1`
    FOREIGN KEY (`esp_cae_id`)
    REFERENCES `mydb`.`catespectacle` (`cae_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`funcio`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`funcio` (
  `fun_esp_id` INT(11) NOT NULL,
  `fun_num` VARCHAR(45) NOT NULL,
  `fun_data` DATETIME NOT NULL,
  PRIMARY KEY (`fun_esp_id`, `fun_num`),
  INDEX `fk_Funcio_Espectacle1_idx` (`fun_esp_id` ASC),
  CONSTRAINT `fk_Funcio_Espectacle1`
    FOREIGN KEY (`fun_esp_id`)
    REFERENCES `mydb`.`espectacle` (`esp_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`entrada`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`entrada` (
  `ent_id` VARCHAR(45) NOT NULL,
  `ent_fun_esp_id` INT(11) NOT NULL,
  `ent_fun_num` VARCHAR(45) NOT NULL,
  `ent_cad_sal_id` INT(11) NOT NULL,
  `ent_cad_num` INT(11) NOT NULL,
  `ent_preu` DECIMAL(10,0) NULL DEFAULT NULL,
  PRIMARY KEY (`ent_id`),
  INDEX `fk_Entrada_Funcio1_idx` (`ent_fun_esp_id` ASC, `ent_fun_num` ASC),
  INDEX `fk_Entrada_Cadira1_idx` (`ent_cad_sal_id` ASC, `ent_cad_num` ASC),
  CONSTRAINT `fk_Entrada_Cadira1`
    FOREIGN KEY (`ent_cad_sal_id` , `ent_cad_num`)
    REFERENCES `mydb`.`cadira` (`cad_sal_id` , `cad_num`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Entrada_Funcio1`
    FOREIGN KEY (`ent_fun_esp_id` , `ent_fun_num`)
    REFERENCES `mydb`.`funcio` (`fun_esp_id` , `fun_num`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`itemescenari`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`itemescenari` (
  `itm_sal_id` INT(11) NOT NULL,
  `itm_num` INT(11) NOT NULL,
  `itm_x1` INT(11) NOT NULL,
  `itm_y1` INT(11) NOT NULL,
  `itm_x2` INT(11) NOT NULL,
  `itm_y2` INT(11) NOT NULL,
  PRIMARY KEY (`itm_sal_id`, `itm_num`),
  INDEX `fk_ItemEscenari_Sala1_idx` (`itm_sal_id` ASC),
  CONSTRAINT `fk_ItemEscenari_Sala1`
    FOREIGN KEY (`itm_sal_id`)
    REFERENCES `mydb`.`sala` (`sal_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`preucatespec`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`preucatespec` (
  `ptc_cat_sal_id` INT(11) NOT NULL,
  `ptc_cat_num` INT(11) NOT NULL,
  `ptc_esp_id` INT(11) NOT NULL,
  `pct_preu` DECIMAL(10,0) NOT NULL,
  PRIMARY KEY (`ptc_cat_sal_id`, `ptc_cat_num`, `ptc_esp_id`),
  INDEX `fk_PreuCatEspec_Categoria1_idx` (`ptc_cat_sal_id` ASC, `ptc_cat_num` ASC),
  INDEX `fk_PreuCatEspec_Espectacle1_idx` (`ptc_esp_id` ASC),
  CONSTRAINT `fk_PreuCatEspec_Categoria1`
    FOREIGN KEY (`ptc_cat_sal_id` , `ptc_cat_num`)
    REFERENCES `mydb`.`cadcategoria` (`cat_sal_id` , `cat_num`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PreuCatEspec_Espectacle1`
    FOREIGN KEY (`ptc_esp_id`)
    REFERENCES `mydb`.`espectacle` (`esp_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


insert into Cadira values (1,1,10,10,1, '');
insert into Cadira values (1,2,20,10,1, '');
insert into Cadira values (1,3,30,10,1, '');
insert into Cadira values (1,4,40,10,1, '');
insert into Cadira values (1,5,50,10,1, '');
insert into Cadira values (1,6,60,10,1, '');
insert into Cadira values (1,7,70,10,1, '');
insert into Cadira values (1,8,80,10,1, '');
insert into Cadira values (1,9,90,10,1, '');
insert into Cadira values (1,10,100,10,1, '');
insert into Cadira values (1,11,110,10,1, '');
insert into Cadira values (1,12,120,10,1, '');
insert into Cadira values (1,13,130,10,1, '');
insert into Cadira values (1,14,140,10,1, '');
insert into Cadira values (1,15,10,20,2, '');
insert into Cadira values (1,16,20,20,2, '');
insert into Cadira values (1,17,30,20,2, '');
insert into Cadira values (1,18,40,20,2, '');
insert into Cadira values (1,19,50,20,2, '');
insert into Cadira values (1,20,60,20,2, '');
insert into Cadira values (1,21,70,20,2, '');
insert into Cadira values (1,22,80,20,2, '');
insert into Cadira values (1,23,90,20,2, '');
insert into Cadira values (1,24,100,20,2, '');
insert into Cadira values (1,25,110,20,2, '');
insert into Cadira values (1,26,120,20,2, '');
insert into Cadira values (1,27,130,20,2, '');
insert into Cadira values (1,28,140,20,2, '');
insert into Cadira values (1,29,10,30,3, '');
insert into Cadira values (1,30,20,30,3, '');
insert into Cadira values (1,31,30,30,3, '');
insert into Cadira values (1,32,40,30,3, '');
insert into Cadira values (1,33,50,30,3, '');
insert into Cadira values (1,34,60,30,3, '');
insert into Cadira values (1,35,70,30,3, '');
insert into Cadira values (1,36,80,30,3, '');
insert into Cadira values (1,37,90,30,3, '');
insert into Cadira values (1,38,100,30,3, '');
insert into Cadira values (1,39,110,30,3, '');
insert into Cadira values (1,40,120,30,3, '');
insert into Cadira values (1,41,130,30,3, '');
insert into Cadira values (1,42,140,30,3, '');
