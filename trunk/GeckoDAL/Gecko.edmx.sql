
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/10/2014 21:22:59
-- Generated from EDMX file: C:\Users\Erica\Dropbox\GeckoProject\WebApp\GeckoLabSiteWithEntityFramework\GeckoDAL\Gecko.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Gecko];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_UserBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingSession]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sessions] DROP CONSTRAINT [FK_BookingSession];
GO
IF OBJECT_ID(N'[dbo].[FK_CourtSession]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sessions] DROP CONSTRAINT [FK_CourtSession];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Courts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courts];
GO
IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Sessions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sessions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Courts'
CREATE TABLE [dbo].[Courts] (
    [CourtID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [HourlyFee] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [BookingID] int IDENTITY(1,1) NOT NULL,
    [BookingDate] nvarchar(max)  NOT NULL,
    [TotalCost] decimal(18,0)  NOT NULL,
    [IsDeleted] nvarchar(max)  NOT NULL,
    [UserUserID] int  NOT NULL
);
GO

-- Creating table 'Sessions'
CREATE TABLE [dbo].[Sessions] (
    [SessionID] int IDENTITY(1,1) NOT NULL,
    [StartDateTime] datetime  NOT NULL,
    [EndDateTime] datetime  NOT NULL,
    [SessionCost] decimal(18,0)  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [BookingBookingID] int  NOT NULL,
    [CourtCourtID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [CourtID] in table 'Courts'
ALTER TABLE [dbo].[Courts]
ADD CONSTRAINT [PK_Courts]
    PRIMARY KEY CLUSTERED ([CourtID] ASC);
GO

-- Creating primary key on [BookingID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([BookingID] ASC);
GO

-- Creating primary key on [SessionID] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [PK_Sessions]
    PRIMARY KEY CLUSTERED ([SessionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserUserID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_UserBooking]
    FOREIGN KEY ([UserUserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBooking'
CREATE INDEX [IX_FK_UserBooking]
ON [dbo].[Bookings]
    ([UserUserID]);
GO

-- Creating foreign key on [BookingBookingID] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [FK_BookingSession]
    FOREIGN KEY ([BookingBookingID])
    REFERENCES [dbo].[Bookings]
        ([BookingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingSession'
CREATE INDEX [IX_FK_BookingSession]
ON [dbo].[Sessions]
    ([BookingBookingID]);
GO

-- Creating foreign key on [CourtCourtID] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [FK_CourtSession]
    FOREIGN KEY ([CourtCourtID])
    REFERENCES [dbo].[Courts]
        ([CourtID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtSession'
CREATE INDEX [IX_FK_CourtSession]
ON [dbo].[Sessions]
    ([CourtCourtID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------