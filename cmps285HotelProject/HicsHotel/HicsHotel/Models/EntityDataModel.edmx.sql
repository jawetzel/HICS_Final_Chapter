
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/22/2016 23:33:04
-- Generated from EDMX file: C:\cmps285HotelProject\cmps285HotelProject\HicsHotel\HicsHotel\Models\EntityDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HicsTestDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Booking_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [FK_Booking_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_Booking_Room]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [FK_Booking_Room];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_EmployeeType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_EmployeeType];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeShift_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeShift] DROP CONSTRAINT [FK_EmployeeShift_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeType_SecurityRank]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeType] DROP CONSTRAINT [FK_EmployeeType_SecurityRank];
GO
IF OBJECT_ID(N'[dbo].[FK_Expenses_ExpenseType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expenses] DROP CONSTRAINT [FK_Expenses_ExpenseType];
GO
IF OBJECT_ID(N'[dbo].[FK_Expenses_Room]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expenses] DROP CONSTRAINT [FK_Expenses_Room];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_Building]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Room] DROP CONSTRAINT [FK_Room_Building];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_HouseKeepingStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Room] DROP CONSTRAINT [FK_Room_HouseKeepingStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_RoomType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Room] DROP CONSTRAINT [FK_Room_RoomType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Booking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Booking];
GO
IF OBJECT_ID(N'[dbo].[Building]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Building];
GO
IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[EmployeeShift]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeShift];
GO
IF OBJECT_ID(N'[dbo].[EmployeeType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeType];
GO
IF OBJECT_ID(N'[dbo].[Expenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Expenses];
GO
IF OBJECT_ID(N'[dbo].[ExpenseType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExpenseType];
GO
IF OBJECT_ID(N'[dbo].[HouseKeepingStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HouseKeepingStatus];
GO
IF OBJECT_ID(N'[dbo].[Room]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Room];
GO
IF OBJECT_ID(N'[dbo].[RoomType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomType];
GO
IF OBJECT_ID(N'[dbo].[SecurityRank]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SecurityRank];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [RoomId] int  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [VolumeDaults] int  NOT NULL,
    [VolumeChildren] int  NOT NULL
);
GO

-- Creating table 'Buildings'
CREATE TABLE [dbo].[Buildings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Phone] float  NOT NULL,
    [Address] varchar(max)  NOT NULL,
    [Building1] varchar(max)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NOT NULL,
    [Address] varchar(max)  NOT NULL,
    [Phone] float  NOT NULL,
    [Email] varchar(max)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmployeeTypeId] int  NOT NULL,
    [Email] varchar(max)  NOT NULL,
    [Name] varchar(max)  NOT NULL,
    [Address] varchar(max)  NOT NULL,
    [Phone] float  NOT NULL
);
GO

-- Creating table 'EmployeeShifts'
CREATE TABLE [dbo].[EmployeeShifts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmployeeId] int  NOT NULL,
    [ClockIn] datetime  NOT NULL,
    [ClockOut] datetime  NULL,
    [CashTakeIn] decimal(19,4)  NOT NULL,
    [CashPutInSafe] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'EmployeeTypes'
CREATE TABLE [dbo].[EmployeeTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SecurityRankId] int  NOT NULL,
    [Title] varchar(max)  NOT NULL,
    [PayRate] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'Expenses'
CREATE TABLE [dbo].[Expenses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoomId] int  NOT NULL,
    [ExpenseTypeId] int  NOT NULL
);
GO

-- Creating table 'ExpenseTypes'
CREATE TABLE [dbo].[ExpenseTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] varchar(max)  NOT NULL,
    [Description] varchar(max)  NOT NULL,
    [Ammount] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'HouseKeepingStatus'
CREATE TABLE [dbo].[HouseKeepingStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CleanStatus] varchar(max)  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BuildingId] int  NOT NULL,
    [RoomTypeId] int  NOT NULL,
    [HousekeepingStatusId] int  NOT NULL,
    [FloorNumber] int  NOT NULL,
    [RoomNumber] int  NOT NULL,
    [RoomStatus] varchar(max)  NOT NULL
);
GO

-- Creating table 'RoomTypes'
CREATE TABLE [dbo].[RoomTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bedding] varchar(max)  NOT NULL,
    [Kitchen] varchar(max)  NOT NULL,
    [Rooms] int  NOT NULL,
    [Bathrooms] int  NOT NULL,
    [SleepsVolume] int  NOT NULL,
    [NightlyRate] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'SecurityRanks'
CREATE TABLE [dbo].[SecurityRanks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteAccessLevel] int  NOT NULL,
    [AccessLevelDescription] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Buildings'
ALTER TABLE [dbo].[Buildings]
ADD CONSTRAINT [PK_Buildings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeShifts'
ALTER TABLE [dbo].[EmployeeShifts]
ADD CONSTRAINT [PK_EmployeeShifts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeTypes'
ALTER TABLE [dbo].[EmployeeTypes]
ADD CONSTRAINT [PK_EmployeeTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [PK_Expenses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExpenseTypes'
ALTER TABLE [dbo].[ExpenseTypes]
ADD CONSTRAINT [PK_ExpenseTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HouseKeepingStatus'
ALTER TABLE [dbo].[HouseKeepingStatus]
ADD CONSTRAINT [PK_HouseKeepingStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoomTypes'
ALTER TABLE [dbo].[RoomTypes]
ADD CONSTRAINT [PK_RoomTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SecurityRanks'
ALTER TABLE [dbo].[SecurityRanks]
ADD CONSTRAINT [PK_SecurityRanks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_Booking_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Booking_Customer'
CREATE INDEX [IX_FK_Booking_Customer]
ON [dbo].[Bookings]
    ([CustomerId]);
GO

-- Creating foreign key on [RoomId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_Booking_Room]
    FOREIGN KEY ([RoomId])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Booking_Room'
CREATE INDEX [IX_FK_Booking_Room]
ON [dbo].[Bookings]
    ([RoomId]);
GO

-- Creating foreign key on [BuildingId] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_Room_Building]
    FOREIGN KEY ([BuildingId])
    REFERENCES [dbo].[Buildings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Room_Building'
CREATE INDEX [IX_FK_Room_Building]
ON [dbo].[Rooms]
    ([BuildingId]);
GO

-- Creating foreign key on [EmployeeTypeId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_EmployeeType]
    FOREIGN KEY ([EmployeeTypeId])
    REFERENCES [dbo].[EmployeeTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_EmployeeType'
CREATE INDEX [IX_FK_Employee_EmployeeType]
ON [dbo].[Employees]
    ([EmployeeTypeId]);
GO

-- Creating foreign key on [EmployeeId] in table 'EmployeeShifts'
ALTER TABLE [dbo].[EmployeeShifts]
ADD CONSTRAINT [FK_EmployeeShift_Employee]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeShift_Employee'
CREATE INDEX [IX_FK_EmployeeShift_Employee]
ON [dbo].[EmployeeShifts]
    ([EmployeeId]);
GO

-- Creating foreign key on [SecurityRankId] in table 'EmployeeTypes'
ALTER TABLE [dbo].[EmployeeTypes]
ADD CONSTRAINT [FK_EmployeeType_SecurityRank]
    FOREIGN KEY ([SecurityRankId])
    REFERENCES [dbo].[SecurityRanks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeType_SecurityRank'
CREATE INDEX [IX_FK_EmployeeType_SecurityRank]
ON [dbo].[EmployeeTypes]
    ([SecurityRankId]);
GO

-- Creating foreign key on [ExpenseTypeId] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [FK_Expenses_ExpenseType]
    FOREIGN KEY ([ExpenseTypeId])
    REFERENCES [dbo].[ExpenseTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Expenses_ExpenseType'
CREATE INDEX [IX_FK_Expenses_ExpenseType]
ON [dbo].[Expenses]
    ([ExpenseTypeId]);
GO

-- Creating foreign key on [RoomId] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [FK_Expenses_Room]
    FOREIGN KEY ([RoomId])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Expenses_Room'
CREATE INDEX [IX_FK_Expenses_Room]
ON [dbo].[Expenses]
    ([RoomId]);
GO

-- Creating foreign key on [HousekeepingStatusId] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_Room_HouseKeepingStatus]
    FOREIGN KEY ([HousekeepingStatusId])
    REFERENCES [dbo].[HouseKeepingStatus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Room_HouseKeepingStatus'
CREATE INDEX [IX_FK_Room_HouseKeepingStatus]
ON [dbo].[Rooms]
    ([HousekeepingStatusId]);
GO

-- Creating foreign key on [RoomTypeId] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_Room_RoomType]
    FOREIGN KEY ([RoomTypeId])
    REFERENCES [dbo].[RoomTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Room_RoomType'
CREATE INDEX [IX_FK_Room_RoomType]
ON [dbo].[Rooms]
    ([RoomTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------