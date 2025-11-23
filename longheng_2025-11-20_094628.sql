-- MySQL dump 10.13  Distrib 8.4.6, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: longheng
-- ------------------------------------------------------
-- Server version	8.4.6

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `cvfields`
--

DROP TABLE IF EXISTS `cvfields`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cvfields` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Type` int NOT NULL,
  `Name` longtext NOT NULL,
  `Note` longtext,
  `Values` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `cvtemplates`
--

DROP TABLE IF EXISTS `cvtemplates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cvtemplates` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `Note` longtext,
  `CreatorId` int NOT NULL,
  `FilePath` longtext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_cvtemplates_CreatorId` (`CreatorId`),
  CONSTRAINT `FK_cvtemplates_users_CreatorId` FOREIGN KEY (`CreatorId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `fieldvalues`
--

DROP TABLE IF EXISTS `fieldvalues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fieldvalues` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FieldId` int NOT NULL,
  `Value` longtext,
  `UserTemplateId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_fieldvalues_FieldId` (`FieldId`),
  KEY `IX_fieldvalues_UserTemplateId` (`UserTemplateId`),
  CONSTRAINT `FK_fieldvalues_cvfields_FieldId` FOREIGN KEY (`FieldId`) REFERENCES `cvfields` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_fieldvalues_usertemplates_UserTemplateId` FOREIGN KEY (`UserTemplateId`) REFERENCES `usertemplates` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `PasswordHash` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usertemplates`
--

DROP TABLE IF EXISTS `usertemplates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usertemplates` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `TemplateId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_usertemplates_TemplateId` (`TemplateId`),
  KEY `IX_usertemplates_UserId` (`UserId`),
  CONSTRAINT `FK_usertemplates_cvtemplates_TemplateId` FOREIGN KEY (`TemplateId`) REFERENCES `cvtemplates` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_usertemplates_users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping routines for database 'longheng'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-11-20  9:46:33
