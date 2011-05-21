/*
 * Created at: 2011-05-09 03:24 PM UTC
 * Machine: SERGIO-RED
 */

    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_EntityToCreatedBy]') AND parent_object_id = OBJECT_ID('Sheets'))
alter table Sheets  drop constraint FK_EntityToCreatedBy


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_EntityToUpdatedBy]') AND parent_object_id = OBJECT_ID('Sheets'))
alter table Sheets  drop constraint FK_EntityToUpdatedBy


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK69E598CE901178E1]') AND parent_object_id = OBJECT_ID('Sheets'))
alter table Sheets  drop constraint FK69E598CE901178E1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_SheetRating_User]') AND parent_object_id = OBJECT_ID('SheetRatings'))
alter table SheetRatings  drop constraint FK_SheetRating_User


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_SheetRating_Sheet]') AND parent_object_id = OBJECT_ID('SheetRatings'))
alter table SheetRatings  drop constraint FK_SheetRating_Sheet


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_SheetRating_CreatedBy]') AND parent_object_id = OBJECT_ID('SheetRatings'))
alter table SheetRatings  drop constraint FK_SheetRating_CreatedBy


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_SheetRating_UpdatedBy]') AND parent_object_id = OBJECT_ID('SheetRatings'))
alter table SheetRatings  drop constraint FK_SheetRating_UpdatedBy


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_User_CreatedBy]') AND parent_object_id = OBJECT_ID('Users'))
alter table Users  drop constraint FK_User_CreatedBy


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_User_UpdatedBy]') AND parent_object_id = OBJECT_ID('Users'))
alter table Users  drop constraint FK_User_UpdatedBy


    if exists (select * from dbo.sysobjects where id = object_id(N'Sheets') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Sheets

    if exists (select * from dbo.sysobjects where id = object_id(N'SheetRatings') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SheetRatings

    if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users

    create table Sheets (
        ID BIGINT IDENTITY NOT NULL,
       CreatedAtUtc DATETIME not null,
       UpdatedAtUtc DATETIME not null,
       ContentMarkdown NVARCHAR(MAX) not null,
       Name NVARCHAR(50) not null,
       Description NVARCHAR(200) null,
       Permalink NVARCHAR(60) not null,
       CreatedByID BIGINT not null,
       UpdatedByID BIGINT not null,
       UserID BIGINT null,
       primary key (ID)
    )

    create table SheetRatings (
        ID BIGINT IDENTITY NOT NULL,
       Rating INT null,
       Comment NVARCHAR(255) null,
       CreatedAtUtc DATETIME null,
       UpdatedAtUtc DATETIME null,
       UserID BIGINT null,
       SheetID BIGINT null,
       CreatedByUserID BIGINT null,
       UpdatedByUserID BIGINT null,
       primary key (ID)
    )

    create table Users (
        ID BIGINT IDENTITY NOT NULL,
       Email NVARCHAR(255) null,
       DisplayName NVARCHAR(255) null,
       HomePageUrl NVARCHAR(255) null,
       TwitterName NVARCHAR(255) null,
       JoinedAt DATETIME null,
       PasswordHash NVARCHAR(255) null,
       PasswordSalt NVARCHAR(255) null,
       Status NVARCHAR(255) null,
       LastLoginAt DATETIME null,
       FailedLoginCount INT null,
       AdminNotes NVARCHAR(255) null,
       CreatedAtUtc DATETIME null,
       UpdatedAtUtc DATETIME null,
       CreatedByUserID BIGINT null,
       UpdatedByUserID BIGINT null,
       primary key (ID)
    )

    alter table Sheets 
        add constraint FK_EntityToCreatedBy 
        foreign key (CreatedByID) 
        references Users

    alter table Sheets 
        add constraint FK_EntityToUpdatedBy 
        foreign key (UpdatedByID) 
        references Users

    alter table Sheets 
        add constraint FK69E598CE901178E1 
        foreign key (UserID) 
        references Users

    alter table SheetRatings 
        add constraint FK_SheetRating_User 
        foreign key (UserID) 
        references Users

    alter table SheetRatings 
        add constraint FK_SheetRating_Sheet 
        foreign key (SheetID) 
        references Sheets

    alter table SheetRatings 
        add constraint FK_SheetRating_CreatedBy 
        foreign key (CreatedByUserID) 
        references Users

    alter table SheetRatings 
        add constraint FK_SheetRating_UpdatedBy 
        foreign key (UpdatedByUserID) 
        references Users

    alter table Users 
        add constraint FK_User_CreatedBy 
        foreign key (CreatedByUserID) 
        references Users

    alter table Users 
        add constraint FK_User_UpdatedBy 
        foreign key (UpdatedByUserID) 
        references Users
