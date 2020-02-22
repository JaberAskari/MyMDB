-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema M2947_2
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema M2947_2
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `M2947_2` DEFAULT CHARACTER SET utf8 ;
USE `M2947_2` ;

-- -----------------------------------------------------
-- Table `M2947_2`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `M2947_2`.`user` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(200) NOT NULL,
  `LastName` VARCHAR(200) NOT NULL,
  `Email` VARCHAR(150) NOT NULL,
  `Phone` VARCHAR(40) NOT NULL,
  `Password` VARCHAR(150) NOT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `M2947_2`.`FavoriteList`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `M2947_2`.`FavoriteList` (
  `ID` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `user_ID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_FavoriteList_user1_idx` (`user_ID` ASC),
  CONSTRAINT `fk_FavoriteList_user1`
    FOREIGN KEY (`user_ID`)
    REFERENCES `M2947_2`.`user` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `M2947_2`.`Movie`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `M2947_2`.`Movie` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `omdbID` INT NOT NULL,
  `user_ID` INT NOT NULL,
  `FavoriteList_ID` INT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_Movie_user_idx` (`user_ID` ASC),
  INDEX `fk_Movie_FavoriteList1_idx` (`FavoriteList_ID` ASC),
  CONSTRAINT `fk_Movie_user`
    FOREIGN KEY (`user_ID`)
    REFERENCES `M2947_2`.`user` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Movie_FavoriteList1`
    FOREIGN KEY (`FavoriteList_ID`)
    REFERENCES `M2947_2`.`FavoriteList` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
