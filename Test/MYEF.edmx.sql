
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/29/2017 14:04:23
-- Generated from EDMX file: F:\C#\基础知识\MyEF\Test\MYEF.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [qds236354159_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StudentStudentAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Student] DROP CONSTRAINT [FK_StudentStudentAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductProductType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_ProductProductType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[ProductType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductType];
GO
IF OBJECT_ID(N'[dbo].[Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Student];
GO
IF OBJECT_ID(N'[dbo].[StudentAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentAddress];
GO
IF OBJECT_ID(N'[dbo].[Person]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ProductType_Id] int  NOT NULL
);
GO

-- Creating table 'ProductType'
CREATE TABLE [dbo].[ProductType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Student'
CREATE TABLE [dbo].[Student] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [StudentAddress_Id] int  NOT NULL
);
GO

-- Creating table 'StudentAddress'
CREATE TABLE [dbo].[StudentAddress] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Course'
CREATE TABLE [dbo].[Course] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Score'
CREATE TABLE [dbo].[Score] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CourseScore'
CREATE TABLE [dbo].[CourseScore] (
    [Course_Id] int  NOT NULL,
    [Score_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductType'
ALTER TABLE [dbo].[ProductType]
ADD CONSTRAINT [PK_ProductType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Student'
ALTER TABLE [dbo].[Student]
ADD CONSTRAINT [PK_Student]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentAddress'
ALTER TABLE [dbo].[StudentAddress]
ADD CONSTRAINT [PK_StudentAddress]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [PK_Person]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Course'
ALTER TABLE [dbo].[Course]
ADD CONSTRAINT [PK_Course]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Score'
ALTER TABLE [dbo].[Score]
ADD CONSTRAINT [PK_Score]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Course_Id], [Score_Id] in table 'CourseScore'
ALTER TABLE [dbo].[CourseScore]
ADD CONSTRAINT [PK_CourseScore]
    PRIMARY KEY CLUSTERED ([Course_Id], [Score_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StudentAddress_Id] in table 'Student'
ALTER TABLE [dbo].[Student]
ADD CONSTRAINT [FK_StudentStudentAddress]
    FOREIGN KEY ([StudentAddress_Id])
    REFERENCES [dbo].[StudentAddress]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentStudentAddress'
CREATE INDEX [IX_FK_StudentStudentAddress]
ON [dbo].[Student]
    ([StudentAddress_Id]);
GO

-- Creating foreign key on [ProductType_Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK_ProductProductType]
    FOREIGN KEY ([ProductType_Id])
    REFERENCES [dbo].[ProductType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductType'
CREATE INDEX [IX_FK_ProductProductType]
ON [dbo].[Product]
    ([ProductType_Id]);
GO

-- Creating foreign key on [Course_Id] in table 'CourseScore'
ALTER TABLE [dbo].[CourseScore]
ADD CONSTRAINT [FK_CourseScore_Course]
    FOREIGN KEY ([Course_Id])
    REFERENCES [dbo].[Course]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Score_Id] in table 'CourseScore'
ALTER TABLE [dbo].[CourseScore]
ADD CONSTRAINT [FK_CourseScore_Score]
    FOREIGN KEY ([Score_Id])
    REFERENCES [dbo].[Score]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseScore_Score'
CREATE INDEX [IX_FK_CourseScore_Score]
ON [dbo].[CourseScore]
    ([Score_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------