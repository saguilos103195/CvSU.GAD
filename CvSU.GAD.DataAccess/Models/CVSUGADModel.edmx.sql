
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/17/2019 21:08:47
-- Generated from EDMX file: C:\Users\mjavier\source\repos\saguilos103195\CvSU.GAD\CvSU.GAD.DataAccess\Models\CVSUGADModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CVSUGAD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Profile_Account]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Profiles] DROP CONSTRAINT [FK_Profile_Account];
GO
IF OBJECT_ID(N'[dbo].[FK_Seminar_Account]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Seminars] DROP CONSTRAINT [FK_Seminar_Account];
GO
IF OBJECT_ID(N'[dbo].[FK_Department_College]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Departments] DROP CONSTRAINT [FK_Department_College];
GO
IF OBJECT_ID(N'[dbo].[FK_Program_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Programs] DROP CONSTRAINT [FK_Program_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_Education_Profile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Educations] DROP CONSTRAINT [FK_Education_Profile];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Colleges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Colleges];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Educations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Educations];
GO
IF OBJECT_ID(N'[dbo].[Profiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profiles];
GO
IF OBJECT_ID(N'[dbo].[Programs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Programs];
GO
IF OBJECT_ID(N'[dbo].[Seminars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Seminars];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [AccountID] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(200)  NOT NULL,
    [Password] nvarchar(200)  NOT NULL,
    [Status] nvarchar(50)  NOT NULL,
    [Type] nvarchar(50)  NOT NULL,
    [CollegeID] int  NULL
);
GO

-- Creating table 'Colleges'
CREATE TABLE [dbo].[Colleges] (
    [CollegeID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(200)  NOT NULL,
    [Alias] nvarchar(50)  NOT NULL,
    [IsMain] bit  NOT NULL,
    [IsArchived] bit  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [DepartmentID] int IDENTITY(1,1) NOT NULL,
    [CollegeID] int  NOT NULL,
    [Title] nvarchar(200)  NOT NULL,
    [Alias] nvarchar(50)  NOT NULL,
    [IsArchived] bit  NOT NULL
);
GO

-- Creating table 'Educations'
CREATE TABLE [dbo].[Educations] (
    [EducationID] int IDENTITY(1,1) NOT NULL,
    [ProfileID] int  NOT NULL,
    [SchoolName] nvarchar(500)  NOT NULL,
    [Course] nvarchar(500)  NOT NULL,
    [EducationalLevel] nvarchar(50)  NOT NULL,
    [DateFrom] datetime  NOT NULL,
    [DateTo] datetime  NOT NULL
);
GO

-- Creating table 'Profiles'
CREATE TABLE [dbo].[Profiles] (
    [ProfileID] int IDENTITY(1,1) NOT NULL,
    [AccountID] int  NOT NULL,
    [Firstname] nvarchar(200)  NOT NULL,
    [Middlename] nvarchar(200)  NOT NULL,
    [Lastname] nvarchar(200)  NOT NULL,
    [Birthdate] datetime  NOT NULL,
    [Gender] nvarchar(20)  NOT NULL,
    [Address] nvarchar(500)  NOT NULL,
    [CellphoneNumber] nvarchar(50)  NOT NULL,
    [TelephoneNumber] nvarchar(50)  NOT NULL,
    [EmailAddress] nvarchar(500)  NOT NULL,
    [Religion] nvarchar(200)  NOT NULL,
    [Designation] nvarchar(200)  NOT NULL,
    [OfficeAddress] nvarchar(500)  NOT NULL,
    [EngagedFrom] datetime  NOT NULL,
    [EngagedTo] datetime  NOT NULL,
    [WillTravel] bit  NOT NULL
);
GO

-- Creating table 'Programs'
CREATE TABLE [dbo].[Programs] (
    [ProgramID] int IDENTITY(1,1) NOT NULL,
    [DepartmentID] int  NOT NULL,
    [Title] nvarchar(200)  NOT NULL,
    [Alias] nvarchar(50)  NOT NULL,
    [IsArchived] bit  NOT NULL
);
GO

-- Creating table 'Seminars'
CREATE TABLE [dbo].[Seminars] (
    [SeminarID] int IDENTITY(1,1) NOT NULL,
    [AccountID] int  NOT NULL,
    [Name] nvarchar(500)  NOT NULL,
    [Year] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AccountID] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([AccountID] ASC);
GO

-- Creating primary key on [CollegeID] in table 'Colleges'
ALTER TABLE [dbo].[Colleges]
ADD CONSTRAINT [PK_Colleges]
    PRIMARY KEY CLUSTERED ([CollegeID] ASC);
GO

-- Creating primary key on [DepartmentID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([DepartmentID] ASC);
GO

-- Creating primary key on [EducationID] in table 'Educations'
ALTER TABLE [dbo].[Educations]
ADD CONSTRAINT [PK_Educations]
    PRIMARY KEY CLUSTERED ([EducationID] ASC);
GO

-- Creating primary key on [ProfileID] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [PK_Profiles]
    PRIMARY KEY CLUSTERED ([ProfileID] ASC);
GO

-- Creating primary key on [ProgramID] in table 'Programs'
ALTER TABLE [dbo].[Programs]
ADD CONSTRAINT [PK_Programs]
    PRIMARY KEY CLUSTERED ([ProgramID] ASC);
GO

-- Creating primary key on [SeminarID] in table 'Seminars'
ALTER TABLE [dbo].[Seminars]
ADD CONSTRAINT [PK_Seminars]
    PRIMARY KEY CLUSTERED ([SeminarID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountID] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [FK_Profile_Account]
    FOREIGN KEY ([AccountID])
    REFERENCES [dbo].[Accounts]
        ([AccountID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Profile_Account'
CREATE INDEX [IX_FK_Profile_Account]
ON [dbo].[Profiles]
    ([AccountID]);
GO

-- Creating foreign key on [AccountID] in table 'Seminars'
ALTER TABLE [dbo].[Seminars]
ADD CONSTRAINT [FK_Seminar_Account]
    FOREIGN KEY ([AccountID])
    REFERENCES [dbo].[Accounts]
        ([AccountID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Seminar_Account'
CREATE INDEX [IX_FK_Seminar_Account]
ON [dbo].[Seminars]
    ([AccountID]);
GO

-- Creating foreign key on [CollegeID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [FK_Department_College]
    FOREIGN KEY ([CollegeID])
    REFERENCES [dbo].[Colleges]
        ([CollegeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Department_College'
CREATE INDEX [IX_FK_Department_College]
ON [dbo].[Departments]
    ([CollegeID]);
GO

-- Creating foreign key on [DepartmentID] in table 'Programs'
ALTER TABLE [dbo].[Programs]
ADD CONSTRAINT [FK_Program_Department]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Departments]
        ([DepartmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Program_Department'
CREATE INDEX [IX_FK_Program_Department]
ON [dbo].[Programs]
    ([DepartmentID]);
GO

-- Creating foreign key on [ProfileID] in table 'Educations'
ALTER TABLE [dbo].[Educations]
ADD CONSTRAINT [FK_Education_Profile]
    FOREIGN KEY ([ProfileID])
    REFERENCES [dbo].[Profiles]
        ([ProfileID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Education_Profile'
CREATE INDEX [IX_FK_Education_Profile]
ON [dbo].[Educations]
    ([ProfileID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------