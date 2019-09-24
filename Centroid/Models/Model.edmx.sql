
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/22/2019 13:08:42
-- Generated from EDMX file: D:\Projects\Centroid\Centroid\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Centroid];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DocumentProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfileDocuments] DROP CONSTRAINT [FK_DocumentProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_JobApplicationProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobApplications] DROP CONSTRAINT [FK_JobApplicationProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_JobApplicationJob]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobApplications] DROP CONSTRAINT [FK_JobApplicationJob];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRole];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkExperiencePersonalInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkExperiences] DROP CONSTRAINT [FK_WorkExperiencePersonalInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonalInfoEducation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Educations] DROP CONSTRAINT [FK_PersonalInfoEducation];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceServiceDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceDetails] DROP CONSTRAINT [FK_ServiceServiceDetails];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Homes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Homes];
GO
IF OBJECT_ID(N'[dbo].[Abouts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Abouts];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[ServiceDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceDetails];
GO
IF OBJECT_ID(N'[dbo].[QHSEs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QHSEs];
GO
IF OBJECT_ID(N'[dbo].[PersonalInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonalInfoes];
GO
IF OBJECT_ID(N'[dbo].[Jobs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jobs];
GO
IF OBJECT_ID(N'[dbo].[ProfileDocuments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfileDocuments];
GO
IF OBJECT_ID(N'[dbo].[ContactUs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactUs];
GO
IF OBJECT_ID(N'[dbo].[JobApplications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobApplications];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[Educations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Educations];
GO
IF OBJECT_ID(N'[dbo].[WorkExperiences]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkExperiences];
GO
IF OBJECT_ID(N'[dbo].[Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Services];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Homes'
CREATE TABLE [dbo].[Homes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'Abouts'
CREATE TABLE [dbo].[Abouts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AboutUs] nvarchar(max)  NOT NULL,
    [Vision] nvarchar(max)  NOT NULL,
    [Mission] nvarchar(max)  NOT NULL,
    [CoreBusiness] nvarchar(max)  NOT NULL,
    [Experience] nvarchar(max)  NOT NULL,
    [Expertise] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectTitle] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [Client] nvarchar(max)  NOT NULL,
    [ClientLogo] nvarchar(max)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ServiceDetails'
CREATE TABLE [dbo].[ServiceDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL,
    [ServiceId] int  NOT NULL
);
GO

-- Creating table 'QHSEs'
CREATE TABLE [dbo].[QHSEs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Vision] nvarchar(max)  NOT NULL,
    [Mission] nvarchar(max)  NOT NULL,
    [QhsePolicy] nvarchar(max)  NOT NULL,
    [QhsePolicyAr] nvarchar(max)  NOT NULL,
    [QhseIMS] nvarchar(max)  NOT NULL,
    [Hse] nvarchar(max)  NOT NULL,
    [IsoCertificates] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PersonalInfoes'
CREATE TABLE [dbo].[PersonalInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [DateOfBirth] nvarchar(max)  NULL,
    [Nationality] nvarchar(max)  NULL,
    [Phone1] nvarchar(max)  NULL,
    [Phone2] nvarchar(max)  NULL,
    [Gender] nvarchar(max)  NULL
);
GO

-- Creating table 'Jobs'
CREATE TABLE [dbo].[Jobs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [JobTitle] nvarchar(max)  NOT NULL,
    [JobDetails] nvarchar(max)  NOT NULL,
    [JobType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProfileDocuments'
CREATE TABLE [dbo].[ProfileDocuments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Document] nvarchar(max)  NOT NULL,
    [DocType] nvarchar(max)  NOT NULL,
    [ProfileId] int  NOT NULL
);
GO

-- Creating table 'ContactUs'
CREATE TABLE [dbo].[ContactUs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Address1] nvarchar(max)  NOT NULL,
    [Address2] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Fax] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Facebook] nvarchar(max)  NOT NULL,
    [Twitter] nvarchar(max)  NOT NULL,
    [LinkedIn] nvarchar(max)  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'JobApplications'
CREATE TABLE [dbo].[JobApplications] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ApplyDate] datetime  NOT NULL,
    [ProfileId] int  NOT NULL,
    [JobId] int  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'Educations'
CREATE TABLE [dbo].[Educations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EducationalInstitution] nvarchar(max)  NOT NULL,
    [Discipline] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [Highest] bit  NOT NULL,
    [PersonalInfoId] int  NOT NULL,
    [EducationLevel] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'WorkExperiences'
CREATE TABLE [dbo].[WorkExperiences] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Employer] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [JobTitle] nvarchar(max)  NOT NULL,
    [PersonalInfoId] int  NOT NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ServiceHead] nvarchar(max)  NOT NULL,
    [ServiceFoot] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Careers'
CREATE TABLE [dbo].[Careers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CareerMsg] nvarchar(max)  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [RoleId] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Homes'
ALTER TABLE [dbo].[Homes]
ADD CONSTRAINT [PK_Homes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Abouts'
ALTER TABLE [dbo].[Abouts]
ADD CONSTRAINT [PK_Abouts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceDetails'
ALTER TABLE [dbo].[ServiceDetails]
ADD CONSTRAINT [PK_ServiceDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QHSEs'
ALTER TABLE [dbo].[QHSEs]
ADD CONSTRAINT [PK_QHSEs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonalInfoes'
ALTER TABLE [dbo].[PersonalInfoes]
ADD CONSTRAINT [PK_PersonalInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Jobs'
ALTER TABLE [dbo].[Jobs]
ADD CONSTRAINT [PK_Jobs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProfileDocuments'
ALTER TABLE [dbo].[ProfileDocuments]
ADD CONSTRAINT [PK_ProfileDocuments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContactUs'
ALTER TABLE [dbo].[ContactUs]
ADD CONSTRAINT [PK_ContactUs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JobApplications'
ALTER TABLE [dbo].[JobApplications]
ADD CONSTRAINT [PK_JobApplications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Educations'
ALTER TABLE [dbo].[Educations]
ADD CONSTRAINT [PK_Educations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkExperiences'
ALTER TABLE [dbo].[WorkExperiences]
ADD CONSTRAINT [PK_WorkExperiences]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Careers'
ALTER TABLE [dbo].[Careers]
ADD CONSTRAINT [PK_Careers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [RoleId], [UserId] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([RoleId], [UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProfileId] in table 'ProfileDocuments'
ALTER TABLE [dbo].[ProfileDocuments]
ADD CONSTRAINT [FK_DocumentProfile]
    FOREIGN KEY ([ProfileId])
    REFERENCES [dbo].[PersonalInfoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentProfile'
CREATE INDEX [IX_FK_DocumentProfile]
ON [dbo].[ProfileDocuments]
    ([ProfileId]);
GO

-- Creating foreign key on [ProfileId] in table 'JobApplications'
ALTER TABLE [dbo].[JobApplications]
ADD CONSTRAINT [FK_JobApplicationProfile]
    FOREIGN KEY ([ProfileId])
    REFERENCES [dbo].[PersonalInfoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobApplicationProfile'
CREATE INDEX [IX_FK_JobApplicationProfile]
ON [dbo].[JobApplications]
    ([ProfileId]);
GO

-- Creating foreign key on [JobId] in table 'JobApplications'
ALTER TABLE [dbo].[JobApplications]
ADD CONSTRAINT [FK_JobApplicationJob]
    FOREIGN KEY ([JobId])
    REFERENCES [dbo].[Jobs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobApplicationJob'
CREATE INDEX [IX_FK_JobApplicationJob]
ON [dbo].[JobApplications]
    ([JobId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [RoleId] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRole]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUser'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUser]
ON [dbo].[AspNetUserRoles]
    ([UserId]);
GO

-- Creating foreign key on [PersonalInfoId] in table 'WorkExperiences'
ALTER TABLE [dbo].[WorkExperiences]
ADD CONSTRAINT [FK_WorkExperiencePersonalInfo]
    FOREIGN KEY ([PersonalInfoId])
    REFERENCES [dbo].[PersonalInfoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkExperiencePersonalInfo'
CREATE INDEX [IX_FK_WorkExperiencePersonalInfo]
ON [dbo].[WorkExperiences]
    ([PersonalInfoId]);
GO

-- Creating foreign key on [PersonalInfoId] in table 'Educations'
ALTER TABLE [dbo].[Educations]
ADD CONSTRAINT [FK_PersonalInfoEducation]
    FOREIGN KEY ([PersonalInfoId])
    REFERENCES [dbo].[PersonalInfoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonalInfoEducation'
CREATE INDEX [IX_FK_PersonalInfoEducation]
ON [dbo].[Educations]
    ([PersonalInfoId]);
GO

-- Creating foreign key on [ServiceId] in table 'ServiceDetails'
ALTER TABLE [dbo].[ServiceDetails]
ADD CONSTRAINT [FK_ServiceServiceDetails]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceServiceDetails'
CREATE INDEX [IX_FK_ServiceServiceDetails]
ON [dbo].[ServiceDetails]
    ([ServiceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------