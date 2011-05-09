/*
 * Created at: 2011-05-09 02:50 AM UTC
 * Machine: SERGIO-RED
 */

    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Sheet_User]') AND parent_object_id = OBJECT_ID('Sheets'))
alter table Sheets  drop constraint FK_Sheet_User


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Sheet_CreatedBy]') AND parent_object_id = OBJECT_ID('Sheets'))
alter table Sheets  drop constraint FK_Sheet_CreatedBy


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Sheet_UpdatedBy]') AND parent_object_id = OBJECT_ID('Sheets'))
alter table Sheets  drop constraint FK_Sheet_UpdatedBy


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
