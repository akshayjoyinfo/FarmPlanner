
if not exists (select * from sysobjects where name in ('tbl_Corps','tbl_Section','tbl_FarmView') and xtype='U')
  create table tbl_Corps (CorpId int primary key identity(100,1), Name varchar(45), Period int, Color varchar(45));
  create table tbl_Section (SectionId int primary key identity(1,1), Name varchar(45)) ;
  create table tbl_FarmView(SectionName varchar(45), CorpsName varchar(45), StartDate date, EndDate date, quantity money, expectedOpt money,rate money, expense money,   totalProfit money);

