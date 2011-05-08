/*
 * Created at: 2011-05-08 11:37 PM UTC
 * Machine: SERGIO-RED
 */

    drop table if exists Sheets

    drop table if exists SheetRatings

    drop table if exists Users

    create table Sheets (
        ID  integer,
       Name TEXT,
       Description TEXT,
       Private INTEGER,
       ContentMarkdown TEXT,
       Permalink TEXT,
       AverageRating INTEGER,
       CreatedAtUtc DATETIME,
       UpdatedAtUtc DATETIME,
       CreatedByID INTEGER,
       UpdatedByID INTEGER,
       UserID INTEGER,
       primary key (ID)
    )

    create table SheetRatings (
        ID  integer,
       Rating INTEGER,
       Comment TEXT,
       CreatedAtUtc DATETIME,
       UpdatedAtUtc DATETIME,
       UserID INTEGER,
       SheetID INTEGER,
       CreatedByID INTEGER,
       UpdatedByID INTEGER,
       primary key (ID)
    )

    create table Users (
        ID  integer,
       Email TEXT,
       DisplayName TEXT,
       HomePageUrl TEXT,
       TwitterName TEXT,
       JoinedAt DATETIME,
       PasswordHash TEXT,
       PasswordSalt TEXT,
       Status TEXT,
       LastLoginAt DATETIME,
       FailedLoginCount INTEGER,
       AdminNotes TEXT,
       CreatedAtUtc DATETIME,
       UpdatedAtUtc DATETIME,
       CreatedByID INTEGER,
       UpdatedByID INTEGER,
       primary key (ID)
    )
