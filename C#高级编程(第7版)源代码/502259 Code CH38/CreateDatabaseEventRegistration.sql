
-- --------------------------------------------------
-- Date Created: 12/01/2009 20:05:15
-- Generated from EDMX file: K:\ProC# 4.0\code\Silverlight\SilverlightDemos\SilverlightDemos.Web\EventRegistrationModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
SET ANSI_NULLS ON;
GO

USE [EventRegistration]
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]')
GO

-- --------------------------------------------------
-- Dropping existing FK constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Attendees_Events]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Attendees] DROP CONSTRAINT [FK_Attendees_Events]
GO
IF OBJECT_ID(N'[dbo].[FK_RegistrationCodes_Events]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistrationCodes] DROP CONSTRAINT [FK_RegistrationCodes_Events]
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Attendees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Attendees];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[RegistrationCodes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegistrationCodes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Attendees'
CREATE TABLE [dbo].[Attendees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EventId] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NULL,
    [Company] nvarchar(50)  NULL,
    [RegistrationCode] nchar(10)  NULL
);
GO
-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [DateFrom] datetime  NOT NULL,
    [DateTo] datetime  NOT NULL,
    [Description] nvarchar(1000)  NULL
);
GO
-- Creating table 'RegistrationCodes'
CREATE TABLE [dbo].[RegistrationCodes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EventId] int  NOT NULL,
    [RegistrationCode1] nchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all Primary Key Constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Attendees'
ALTER TABLE [dbo].[Attendees] WITH NOCHECK 
ADD CONSTRAINT [PK_Attendees]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events] WITH NOCHECK 
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'RegistrationCodes'
ALTER TABLE [dbo].[RegistrationCodes] WITH NOCHECK 
ADD CONSTRAINT [PK_RegistrationCodes]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO

-- --------------------------------------------------
-- Creating all Foreign Key Constraints
-- --------------------------------------------------

-- Creating foreign key on [EventId] in table 'Attendees'
ALTER TABLE [dbo].[Attendees] WITH NOCHECK 
ADD CONSTRAINT [FK_Attendees_Events]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [EventId] in table 'RegistrationCodes'
ALTER TABLE [dbo].[RegistrationCodes] WITH NOCHECK 
ADD CONSTRAINT [FK_RegistrationCodes_Events]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------