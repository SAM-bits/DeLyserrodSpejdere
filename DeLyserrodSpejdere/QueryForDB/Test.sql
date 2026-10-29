create trigger CheckLimitsOfMemebers
on ActivitiesRegister 
AFTER insert 
As
Begin 
if(SELECT Count(*)
from ActivitiesRegister
where ActivitiesId = (SELECT ActivitiesId from inserted)
) > 
(Select LimitOfMembers 
from Activities 
where ActivitiesId = (select ActivitiesId from inserted))
begin 
Rollback Transaction;
end
end;


Create Table TestLimits
(
	TestLimitId int Primary key IDENTITY,
	NameOfConcert varchar(50),
	LimitOfPeople int
);
Create Table TestLimitReg
(
	TestLimitRegId int Primary key IDENTITY,
	TestLimitId int foreign key (TestLimitId) references TestLimits(TestLimitId)
);
insert into TestLimits
Values  ('SaifConcert' , 3);




--Create TRIGGER LimitOfGuestFinal
--On TestLimitReg
--after insert as begin 
--if (select Count(*) from TestLimitReg where TestLimitId =(select TestLimitId from inserted))
-->(select LimitOfPeople from TestLimits where TestLimitId =(select TestLimitId from inserted))
--begin 
--rollback transaction ; 
--end 
--end;

SELECT *
FROM sys.triggers;

insert into ActivitiesRegister(ActivitiesId,PersonId)
values (5,1)
insert into ActivitiesRegister(ActivitiesId,PersonId)
values (5,2)
insert into ActivitiesRegister(ActivitiesId,PersonId)
values (5,3)
insert into ActivitiesRegister(ActivitiesId,PersonId)
values (5,4)
insert into ActivitiesRegister(ActivitiesId,PersonId)
values (5,5)

delete from ActivitiesRegister where PersonId=  1


DELETE FROM Person; DBCC CHECKIDENT ('Person', RESEED, 0);	
DELETE FROM Activities; DBCC CHECKIDENT ('Activities', RESEED, 0);	
DELETE FROM ActivitiesRegister; DBCC CHECKIDENT ('ActivitiesRegister', RESEED, 0);	

select * from Person 
select * from SpejderLogin
select * from Activities
select * from City
select * from ActivitiesRegister 

Select * from Activities 


delete from ActivitiesRegister
where ActivitiesId = 5 and PersonId = 3















--select Person.Userpassword from Person
--                                        where PersonID = 1



--select Person.UserName,Person.UserPassword , Person.IsSupervisor , ConCat(Person.FirstName , ' ' , Person.LastName) as FullName from Person
--where Person.UserName='SaifMaide' and Person.UserPassword='123456789!!!'






--Select UserPassword from SpejderLogin
--where PersonId = 7
--update SpejderLogin
--SET UserPassword = 'testtest2!'
--where PersonId = 7


--update Person
--                                    Set UserPassword ='123456789!!' , UserPasswordConfirm = '123456789!!'
--                                    where Person.PersonId = 1






--Select Person.* , City.CityName as CityName , City.PostCode as PostCode from Person
--left join City on Person.CityId=City.CityId
--where Person.PersonId=1



--update Person
--Set FirstName = 'Saif' , LastName='Atyaif' , Email ='SaifAtyaif@gmail.com' , PhoneNumber='52177690' , Age=35 , Adress = 'Majengen 12' ,
--CityId=(select CityId from City where CityName like '%Solrød Strand%' and PostCode like 2680 ),SpecialCharacter =0,
--UserName='SaifMaide'
--where Person.PersonId = 1

--SELECT CityId, CityName, PostCode
--FROM City
--WHERE CityName Like '%so%'
--  AND PostCode Like 2680;





--  Select UserPassword from Person
                                   
--                                    where PersonId=1






--Select CONCAT( Person.FirstName ,' ', Person.LastName) from Person where PersonId = 1

--Select Person.FirstName , Person.LastName from Person where PersonId = 1

--select Person.* ,City.CityName as CityName , City.PostCode as PostCode from Person 
--inner join City on Person.CityId = city.CityId


--update person
--set Firstname = 'Saif' , LastName='Maide' , CityId=(Select CityId from City where CityName='Køge' and PostCode = 4600 )


--Select Person.* , City.CityName as CityName , City.PostCode as PostCode from Person
--                                    inner join City on Person.CityId=City.CityId 
--                                    where Person.PersonId=1


--select SpejderLogin.Username,SpejderLogin.UserPassword , person.IsSupervisor as iSSuperVisor , Person.PersonId as PersonId , ConCat(Person.FirstName , ' ' , Person.LastName) from SpejderLogin
--                                inner join Person on SpejderLogin.PersonId = Person.PersonId
--                                where SpejderLogin.UserName='SaifMadie' and SpejderLogin.UserPassword= '123456789!'













--Select Activities.NameOfActivites as NameAct,Activities.DetailsAboutActivities as Details, Activities.StartDate as StartDate, Activities.StartTime as TimeStart , Activities.EndTime as EndTime , Activities.AgeRestrictions as AgeLimit,Activities.LimitOfMembers as Limits ,Count(ActivitiesRegister.ActivitiesId) as LimitCounter , City.CityName as City, City.PostCode as PostNumber , Activities.ActivitiesId as Id from Activities
--                left join ActivitiesRegister on Activities.ActivitiesId= ActivitiesRegister.ActivitiesId
--                inner join City on Activities.CityId = City.CityId
--                where  activities.StartDate between @dateTime and @dateTime1
--                group by ActivitiesRegister.ActivitiesId,Activities.NameOfActivites,StartDate,AgeRestrictions,LimitOfMembers,CityName,PostCode"



--Select Activities.NameOfActivites as NameAct,Activities.DetailsAboutActivities as Details, Activities.StartDate as StartDate, Activities.StartTime as TimeStart , Activities.EndTime as EndTime , Activities.AgeRestrictions as AgeLimit,Activities.LimitOfMembers as Limits ,Count(ActivitiesRegister.ActivitiesId) as LimitCounter , City.CityName as City, City.PostCode as PostNumber , Activities.ActivitiesId as Id from Activities
--                left join ActivitiesRegister on Activities.ActivitiesId= ActivitiesRegister.ActivitiesId
--                inner join City on Activities.CityId = City.CityId
--                where  activities.StartDate between '2026-01-01' and '2027-01-01'
--                group by ActivitiesRegister.ActivitiesId,Activities.NameOfActivites,StartDate,AgeRestrictions,LimitOfMembers,CityName,PostCode




--Select ActivitiesRegister.*, Activities.NameOfActivites as AcName , Activities.StartDate as StartDate , Activities.StartTime as TimeStart , Activities.Address as Adresse , City.CityName as CityName , city.PostCode as PostCode from ActivitiesRegister
--inner join Activities on ActivitiesRegister.ActivitiesId = Activities.ActivitiesId
--inner join City on Activities.CityId = City.CityId
--where ActivitiesRegister.PersonId = 3











--select Activities.NameOfActivites as NameAct,Activities.DetailsAboutActivities as Details, Activities.StartDate as StartDate, Activities.StartTime as TimeStart , Activities.EndTime as EndTime , Activities.AgeRestrictions as AgeLimit,Activities.LimitOfMembers as Limits ,Count(ActivitiesRegister.ActivitiesId) as LimitCounter , City.CityName as City, City.PostCode as PostNumber , Activities.ActivitiesId as Id from Activities
--                left join ActivitiesRegister on Activities.ActivitiesId= ActivitiesRegister.ActivitiesId
--                inner join City on Activities.CityId = City.CityId
--                where  activities.StartDate between '2026-01-01' and '2027-01-01'
--                group by ActivitiesRegister.ActivitiesId,Activities.NameOfActivites,StartDate,AgeRestrictions,LimitOfMembers,CityName,PostCode,Activities.DetailsAboutActivities,Activities.StartTime,Activities.EndTime,Activities.ActivitiesId


--          select      Activities.NameOfActivites as NameAct,Activities.DetailsAboutActivities as Details, Activities.StartDate as StartDate, Activities.StartTime as TimeStart , Activities.EndTime as EndTime , Activities.AgeRestrictions as AgeLimit,Activities.LimitOfMembers as Limits ,Count(ActivitiesRegister.ActivitiesId) as LimitCounter , City.CityName as City, City.PostCode as PostNumber , Activities.ActivitiesId as Id from Activities
--                left join ActivitiesRegister on Activities.ActivitiesId= ActivitiesRegister.ActivitiesId
--                inner join City on Activities.CityId = City.CityId
--                where  activities.StartDate between @dateTime and @dateTime1
--                group by ActivitiesRegister.ActivitiesId,Activities.NameOfActivites,StartDate,AgeRestrictions,LimitOfMembers,CityName,PostCode,Activities.DetailsAboutActivities,Activities.StartTime,Activities.EndTime,Activities.ActivitiesId



--select Activities.NameOfActivites as NameAct,Activities.DetailsAboutActivities as Details, Activities.StartDate as StartDate, Activities.StartTime as TimeStart , Activities.EndTime as EndTime , Activities.AgeRestrictions as AgeLimit,Activities.LimitOfMembers as Limits ,Count(ActivitiesRegister.ActivitiesId) as LimitCounter , City.CityName as City, City.PostCode as PostNumber from ActivitiesRegister
--                inner join Activities on ActivitiesRegister.ActivitiesId=Activities.ActivitiesId
--                inner join City on Activities.CityId = City.CityId
--                where  activities.StartDate between '2026-01-01' and '2026-12-01'
--                group by ActivitiesRegister.ActivitiesId,Activities.NameOfActivites,StartDate,AgeRestrictions,LimitOfMembers,CityName,PostCode,Activities.DetailsAboutActivities,Activities.StartTime,Activities.EndTime



--Select Activities.*, City.CityName as CityName , City.PostCode as PostCode from Activities
--                                inner join City on Activities.CityId = City.CityId
--                                where ActivitiesId = @id


--Select Activities.*, City.CityName as CityName , City.PostCode as Postcode  from Activities
--inner join City on Activities.CityId = City.CityId
--where ActivitiesId = 5






--select  Activities.NameOfActivites as NameAct, Activities.StartDate as StartDate , Activities.AgeRestrictions as AgeLimit,Activities.LimitOfMembers as Limits ,Count(ActivitiesRegister.ActivitiesId) as LimitCounter , City.CityName as City, City.PostCode as PostNumber  from ActivitiesRegister
--inner join Activities on ActivitiesRegister.ActivitiesId=Activities.ActivitiesId
--inner join City on Activities.CityId = City.CityId
--where City.CityName like '' or Activities.NameOfActivites like '%final%'
--group by ActivitiesRegister.ActivitiesId,Activities.NameOfActivites,StartDate,AgeRestrictions,LimitOfMembers,CityName,PostCode

--select * ,NameOfActivites , StartDate, Activities.AgeRestrictions , Activities.LimitOfMembers, Count(ActivitiesRegister.ActivitiesId) as MemberCounter, CityName as City , PostCode as PostCode from Activities

--inner join City on City.CityId = Activities.CityId
--where ActivitiesId = 5

--select ActivitiesRegister.* ,Activities.NameOfActivites as Name , Activities.StartDate as Date ,Activities.AgeRestrictions as Age , 
--Activities.LimitOfMembers as Limit, Count(ActivitiesRegister.ActivitiesId) as CounterMember from ActivitiesRegister
--inner join Activities on ActivitiesRegister.ActivitiesId = Activities.ActivitiesId
--where Activities.ActivitiesId = 5
--group by Activities.ActivitiesId


--select ActivitiesRegister.* ,Activities.NameOfActivites as NameOf , Activities.StartDate as DateOf ,Activities.AgeRestrictions as Age , 
--Activities.LimitOfMembers as Limit, Count(ActivitiesRegister.ActivitiesId) as CounterLimit from ActivitiesRegister
--inner join Activities on ActivitiesRegister.ActivitiesId = Activities.ActivitiesId
--where Activities.ActivitiesId = 5


--Select  Activities.NameOfActivites as AktivitieNavn ,Activities.StartDate as StartDato ,Activities.Address as Adresse ,Person.FirstName as FistName ,Person.LastName as LastName , Person.PhoneNumber as PhoneNumber , ActivitiesRegister.Personid as PersonId From ActivitiesRegister
--inner join Activities on ActivitiesRegister.ActivitiesId = Activities.ActivitiesId
--inner join Person on ActivitiesRegister.PersonId = Person.PersonId
--where ActivitiesRegister.ActivitiesId = 5 or ActivitiesRegister.PersonId = 0

--Update Activities 
--set LimitOfMembers = 5
--where ActivitiesId = 5


--Select Count(*) from Person where Person.Personid =6


--select SpejderLogin.Username,SpejderLogin.UserPassword , person.IsSupervisor as iSSuperVisor from SpejderLogin
--inner join Person on SpejderLogin.PersonId = Person.PersonId

--Select  NameOfActivites as AktivtetsNavn , DetailsAboutActivities as AktivitetsDetaljer , StartDate as OpstartsDato , StartTime as StartTidspunkt,EndTime as SlutTid , AgeRestrictions as AlderGrænse , SpecialCharacter as SpejderTegn , Address as Adresse from Activities

--Select ActivitiesRegister.*, Person.FirstName , Person.LastName , Activities.NameOfActivites,Activities.StartDate   From ActivitiesRegister
--inner join Person on ActivitiesRegister.PersonId = Person.Personid
--inner join Activities on ActivitiesRegister.ActivitiesId = Activities.ActivitiesId Where Activities.ActivitiesId = 2;

--select SpejderLogin.Username,SpejderLogin.UserPassword , person.IsSupervisor as iSSuperVisor from SpejderLogin
--                                inner join Person on SpejderLogin.PersonId = Person.PersonId 
--                                where SpejderLogin.UserName='SaifMadie' and SpejderLogin.UserPassword='3299256331!';

--Select * from Activities where Activities.ActivitiesId = 1

---- viser aktivites med postnummer og bynavn

--select Activities.* ,CityName as City , PostCode as PostCode from Activities 
--inner join City on City.CityId = Activities.CityId where ActivitiesId = 2;


---- 

--Update Activities 
--                           SET NameOfActivites =@NameOfActivites ,DetailsAboutActivities=@DetailsAboutActivities, StartDate=@StartDate,StartTime=@StartTime,EndTime=@EndTime,LimitOfMembers=@LimitOfMembers,AgeRestrictions=@AgeRestrictions , SpecialCharacter =@SpecialCharacter,Address=@Adress,CityId=(Select CityId from City where CityName=@CityName And PostCode=@PostCode)
--                            Where ActivitiesId = 2;