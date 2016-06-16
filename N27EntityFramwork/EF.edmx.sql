
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2015 19:32:57
-- Generated from EDMX file: C:\Users\daxiong\desktop\Code\DotNetStudy\N27EntityFramwork\EF.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DotNetStudy];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Msg_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Msgs] DROP CONSTRAINT [FK_Msg_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Msg_Users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Msgs] DROP CONSTRAINT [FK_Msg_Users1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Msgs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Msgs];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [uId] int IDENTITY(1,1) NOT NULL,
    [uName] nvarchar(20)  NOT NULL,
    [uLoginName] nvarchar(20)  NOT NULL,
    [uPwd] char(32)  NOT NULL,
    [uAddtime] datetime  NOT NULL,
    [uIsDel] bit  NOT NULL
);
GO

-- Creating table 'Msgs'
CREATE TABLE [dbo].[Msgs] (
    [mId] int IDENTITY(1,1) NOT NULL,
    [mFromUser] int  NOT NULL,
    [mToUser] int  NOT NULL,
    [mMsg] nvarchar(500)  NOT NULL,
    [mAddtime] datetime  NOT NULL,
    [mIsDel] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [uId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([uId] ASC);
GO

-- Creating primary key on [mId] in table 'Msgs'
ALTER TABLE [dbo].[Msgs]
ADD CONSTRAINT [PK_Msgs]
    PRIMARY KEY CLUSTERED ([mId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [mFromUser] in table 'Msgs'
ALTER TABLE [dbo].[Msgs]
ADD CONSTRAINT [FK_Msg_Users]
    FOREIGN KEY ([mFromUser])
    REFERENCES [dbo].[Users]
        ([uId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Msg_Users'
CREATE INDEX [IX_FK_Msg_Users]
ON [dbo].[Msgs]
    ([mFromUser]);
GO

-- Creating foreign key on [mToUser] in table 'Msgs'
ALTER TABLE [dbo].[Msgs]
ADD CONSTRAINT [FK_Msg_Users1]
    FOREIGN KEY ([mToUser])
    REFERENCES [dbo].[Users]
        ([uId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Msg_Users1'
CREATE INDEX [IX_FK_Msg_Users1]
ON [dbo].[Msgs]
    ([mToUser]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------