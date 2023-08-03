CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `agencia` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Numero` int NOT NULL,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Endereco` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_agencia` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

CREATE TABLE `cliente` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CPF` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Profissao` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_cliente` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

CREATE TABLE `conta_corrente` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Numero` int NOT NULL,
    `ClienteId` int NOT NULL,
    `AgenciaId` int NOT NULL,
    `Saldo` double NOT NULL,
    CONSTRAINT `PK_conta_corrente` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_conta_corrente_agencia_AgenciaId` FOREIGN KEY (`AgenciaId`) REFERENCES `agencia` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_conta_corrente_cliente_ClienteId` FOREIGN KEY (`ClienteId`) REFERENCES `cliente` (`Id`) ON DELETE CASCADE
) CHARACTER SET utf8mb4;

CREATE INDEX `IX_conta_corrente_AgenciaId` ON `conta_corrente` (`AgenciaId`);

CREATE INDEX `IX_conta_corrente_ClienteId` ON `conta_corrente` (`ClienteId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20211022000603_Inicial', '5.0.11');

COMMIT;

