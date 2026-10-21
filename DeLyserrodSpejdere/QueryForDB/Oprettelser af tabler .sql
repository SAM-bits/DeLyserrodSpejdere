Create Table Person 
(
	IsSupoervisor BIT ,
	PersonId INT Primary key IDENTITY,
	FirstName NVarChar(50),
	LastName NVarChar(50),
	Email VarChar(50)Unique,
	PhoneNumber VarChar(50)Unique,
	Age int,
	Adress NVarChar(50),
	CityId int foreign key (CityId) references City(CityId) ,
	SpecialCharacter NvarChar(50),
	UserName NvarChar(50)Unique,
	UserPassword NvarChar(50),
	UserPasswordConfirm NvarChar(50)

);

ALTER TABLE activities 
add constraint CityIdFK
foreign key (CityId)
references City(CityId)

Create Table Activities 
(

	ActivitiesId int Primary key IDENTITY , 
	NameOfActivities NvarChar(50),
	DetailsAboutActivites NVarChar (350),
	StartDate Date,
	StartTime Time(0),
	EndTime Time(0),
	LimitOfMembers int ,
	AgeRestrictions int ,
	SpecialCharacterId  int ,
	CityId int foreign key (CityId) references City(CityId),
	Address NvarChar(50)

);


Create Table ActivitiesRegister
(
	ActivitiesRegisterId int Primary key IDENTITY,
	ActivitiesId int foreign key (ActivitiesId) references Activities(ActivitiesId) , 
	PersonId int foreign key (PersonId) references Person(PersonId) ,


);




Create Table SpejderLogin
(
	LoginId int Primary Key IDENTITY,
	PersonId int foreign key (PersonId) references Person(PersonId),
	UserName VarChar(50),
	UserPassword VarChar(50),
	

);
