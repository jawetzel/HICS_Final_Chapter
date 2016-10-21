
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/21/2016 12:12:57
-- Generated from EDMX file: C:\Cmps285Project\cmps285HotelProject\HotelIntegratedComputerSystems\HotelIntegratedComputerSystems\Models\HicsDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HicsDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Booking_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_Booking_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_Booking_Room]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_Booking_Room];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_Building]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK_Room_Building];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_EmployeeType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employee_EmployeeType];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeShift_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeShifts] DROP CONSTRAINT [FK_EmployeeShift_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeType_SecurityRank]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeTypes] DROP CONSTRAINT [FK_EmployeeType_SecurityRank];
GO
IF OBJECT_ID(N'[dbo].[FK_Expenses_ExpenseType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expenses1] DROP CONSTRAINT [FK_Expenses_ExpenseType];
GO
IF OBJECT_ID(N'[dbo].[FK_Expenses_Room]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expenses1] DROP CONSTRAINT [FK_Expenses_Room];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_HouseKeepingStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK_Room_HouseKeepingStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_RoomType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK_Room_RoomType];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomMaintenanceLogs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MaintenanceLogs] DROP CONSTRAINT [FK_RoomMaintenanceLogs];
GO
IF OBJECT_ID(N'[dbo].[FK_MaintenanceTypesMaintenanceLogs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MaintenanceLogs] DROP CONSTRAINT [FK_MaintenanceTypesMaintenanceLogs];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingExpens]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expenses1] DROP CONSTRAINT [FK_BookingExpens];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomStatusRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK_RoomStatusRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingStatusBooking1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_BookingStatusBooking1];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailsEmailRecipients]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmailRecipients] DROP CONSTRAINT [FK_EmailsEmailRecipients];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeEmails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emails] DROP CONSTRAINT [FK_EmployeeEmails];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Buildings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Buildings];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[EmployeeShifts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeShifts];
GO
IF OBJECT_ID(N'[dbo].[EmployeeTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeTypes];
GO
IF OBJECT_ID(N'[dbo].[Expenses1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Expenses1];
GO
IF OBJECT_ID(N'[dbo].[ExpenseTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExpenseTypes];
GO
IF OBJECT_ID(N'[dbo].[HouseKeepingStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HouseKeepingStatus];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO
IF OBJECT_ID(N'[dbo].[RoomTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomTypes];
GO
IF OBJECT_ID(N'[dbo].[SecurityRanks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SecurityRanks];
GO
IF OBJECT_ID(N'[dbo].[MaintenanceLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaintenanceLogs];
GO
IF OBJECT_ID(N'[dbo].[MaintenanceTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaintenanceTypes];
GO
IF OBJECT_ID(N'[dbo].[RoomStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomStatus];
GO
IF OBJECT_ID(N'[dbo].[BookingStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingStatus];
GO
IF OBJECT_ID(N'[dbo].[Emails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emails];
GO
IF OBJECT_ID(N'[dbo].[EmailRecipients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailRecipients];
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
    [VolumeAdults] int  NULL,
    [VolumeChildren] int  NULL,
    [BookingStatusId] int  NOT NULL,
    [CheckedInDate] datetime  NULL,
    [CheckedOutDate] datetime  NULL
);
GO

-- Creating table 'Buildings'
CREATE TABLE [dbo].[Buildings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Phone] bigint  NOT NULL,
    [Address] varchar(max)  NOT NULL,
    [BuildingName] varchar(max)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NOT NULL,
    [Address] varchar(max)  NOT NULL,
    [Phone] bigint  NOT NULL,
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
    [Phone] bigint  NOT NULL
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

-- Creating table 'Expenses1'
CREATE TABLE [dbo].[Expenses1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoomId] int  NOT NULL,
    [ExpenseTypeId] int  NOT NULL,
    [BookingId] int  NOT NULL
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
    [RoomNumber] nvarchar(max)  NOT NULL,
    [RoomStatusId] int  NOT NULL
);
GO

-- Creating table 'RoomTypes'
CREATE TABLE [dbo].[RoomTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bedding] varchar(max)  NOT NULL,
    [Kitchen] varchar(max)  NOT NULL,
    [Rooms] int  NOT NULL,
    [Bathrooms] decimal(18,0)  NOT NULL,
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

-- Creating table 'MaintenanceLogs'
CREATE TABLE [dbo].[MaintenanceLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoomId] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [MaintenanceTypesId] int  NOT NULL
);
GO

-- Creating table 'MaintenanceTypes'
CREATE TABLE [dbo].[MaintenanceTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RoomStatus'
CREATE TABLE [dbo].[RoomStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BookingStatus'
CREATE TABLE [dbo].[BookingStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BookingStatusDescription] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Emails'
CREATE TABLE [dbo].[Emails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [DateSent] datetime  NOT NULL,
    [EmployeeId] int  NOT NULL
);
GO

-- Creating table 'EmailRecipients'
CREATE TABLE [dbo].[EmailRecipients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmailAddress] nvarchar(max)  NOT NULL,
    [EmailsId] int  NOT NULL
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

-- Creating primary key on [Id] in table 'Expenses1'
ALTER TABLE [dbo].[Expenses1]
ADD CONSTRAINT [PK_Expenses1]
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

-- Creating primary key on [Id] in table 'MaintenanceLogs'
ALTER TABLE [dbo].[MaintenanceLogs]
ADD CONSTRAINT [PK_MaintenanceLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MaintenanceTypes'
ALTER TABLE [dbo].[MaintenanceTypes]
ADD CONSTRAINT [PK_MaintenanceTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoomStatus'
ALTER TABLE [dbo].[RoomStatus]
ADD CONSTRAINT [PK_RoomStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BookingStatus'
ALTER TABLE [dbo].[BookingStatus]
ADD CONSTRAINT [PK_BookingStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [PK_Emails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmailRecipients'
ALTER TABLE [dbo].[EmailRecipients]
ADD CONSTRAINT [PK_EmailRecipients]
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

-- Creating foreign key on [ExpenseTypeId] in table 'Expenses1'
ALTER TABLE [dbo].[Expenses1]
ADD CONSTRAINT [FK_Expenses_ExpenseType]
    FOREIGN KEY ([ExpenseTypeId])
    REFERENCES [dbo].[ExpenseTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Expenses_ExpenseType'
CREATE INDEX [IX_FK_Expenses_ExpenseType]
ON [dbo].[Expenses1]
    ([ExpenseTypeId]);
GO

-- Creating foreign key on [RoomId] in table 'Expenses1'
ALTER TABLE [dbo].[Expenses1]
ADD CONSTRAINT [FK_Expenses_Room]
    FOREIGN KEY ([RoomId])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Expenses_Room'
CREATE INDEX [IX_FK_Expenses_Room]
ON [dbo].[Expenses1]
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

-- Creating foreign key on [RoomId] in table 'MaintenanceLogs'
ALTER TABLE [dbo].[MaintenanceLogs]
ADD CONSTRAINT [FK_RoomMaintenanceLogs]
    FOREIGN KEY ([RoomId])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomMaintenanceLogs'
CREATE INDEX [IX_FK_RoomMaintenanceLogs]
ON [dbo].[MaintenanceLogs]
    ([RoomId]);
GO

-- Creating foreign key on [MaintenanceTypesId] in table 'MaintenanceLogs'
ALTER TABLE [dbo].[MaintenanceLogs]
ADD CONSTRAINT [FK_MaintenanceTypesMaintenanceLogs]
    FOREIGN KEY ([MaintenanceTypesId])
    REFERENCES [dbo].[MaintenanceTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaintenanceTypesMaintenanceLogs'
CREATE INDEX [IX_FK_MaintenanceTypesMaintenanceLogs]
ON [dbo].[MaintenanceLogs]
    ([MaintenanceTypesId]);
GO

-- Creating foreign key on [BookingId] in table 'Expenses1'
ALTER TABLE [dbo].[Expenses1]
ADD CONSTRAINT [FK_BookingExpens]
    FOREIGN KEY ([BookingId])
    REFERENCES [dbo].[Bookings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingExpens'
CREATE INDEX [IX_FK_BookingExpens]
ON [dbo].[Expenses1]
    ([BookingId]);
GO

-- Creating foreign key on [RoomStatusId] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_RoomStatusRoom]
    FOREIGN KEY ([RoomStatusId])
    REFERENCES [dbo].[RoomStatus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomStatusRoom'
CREATE INDEX [IX_FK_RoomStatusRoom]
ON [dbo].[Rooms]
    ([RoomStatusId]);
GO

-- Creating foreign key on [BookingStatusId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_BookingStatusBooking1]
    FOREIGN KEY ([BookingStatusId])
    REFERENCES [dbo].[BookingStatus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingStatusBooking1'
CREATE INDEX [IX_FK_BookingStatusBooking1]
ON [dbo].[Bookings]
    ([BookingStatusId]);
GO

-- Creating foreign key on [EmailsId] in table 'EmailRecipients'
ALTER TABLE [dbo].[EmailRecipients]
ADD CONSTRAINT [FK_EmailsEmailRecipients]
    FOREIGN KEY ([EmailsId])
    REFERENCES [dbo].[Emails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailsEmailRecipients'
CREATE INDEX [IX_FK_EmailsEmailRecipients]
ON [dbo].[EmailRecipients]
    ([EmailsId]);
GO

-- Creating foreign key on [EmployeeId] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [FK_EmployeeEmails]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeEmails'
CREATE INDEX [IX_FK_EmployeeEmails]
ON [dbo].[Emails]
    ([EmployeeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------