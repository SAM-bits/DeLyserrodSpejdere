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




Create TRIGGER LimitOfGuestFinal
On TestLimitReg
after insert as begin 
if (select Count(*) from TestLimitReg where TestLimitId =(select TestLimitId from inserted))
>(select LimitOfPeople from TestLimits where TestLimitId =(select TestLimitId from inserted))
begin 
rollback transaction ; 
end 
end;

SELECT *
FROM sys.triggers;

insert into TestLimitReg(TestLimitId)
values (1)

DELETE FROM Person; DBCC CHECKIDENT ('Person', RESEED, 0);	
DELETE FROM SpejderLogin; DBCC CHECKIDENT ('SpejderLogin', RESEED, 0);	
DELETE FROM Activities; DBCC CHECKIDENT ('Activities', RESEED, 0);	

select * from Person
select * from SpejderLogin
select * from Activities
select * from City


-- viser aktivites med postnummer og bynavn

select Activities.* ,CityName as City , PostCode as PostCode from Activities 
inner join City on City.CityId = Activities.CityId where ActivitiesId = 2;


-- 