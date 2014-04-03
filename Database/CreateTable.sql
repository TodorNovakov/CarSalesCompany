use CarSalesCompany

create table VehicleTypes
(
   TypeOfVehicle varchar(16) not null,
   constraint PK_VehicleType primary key (TypeOfVehicle) 


)

create table EngineTypes
(
   TypeOfEngine varchar(16) not null,
   constraint PK_EngineType primary key(TypeOfEngine)
)

create table Manufacturers
(
  Name varchar(16) not null,
  constraint PK_Producer primary key(Name)
)

create table Persons
(
  Id_Person int not null identity(1,1),
  LastName varchar(16) not null,
  FirstName varchar(16) not null,
  Contact varchar(16) not null,
  constraint PK_Person primary key (Id_Person)
)

create table VehicleExtras
(
    Id_Extras int not null identity(100,1),
	ABS bit not null default 0,
	ESP bit not null default 0,
	ElectricWindows bit not null default 0,
	ElectricSideMirrors bit not null default 0,
	AirConditioner bit not null default 0,
	AuxiliaryHeater bit not null default 0,
	constraint PK_VehicleExtras primary key (Id_Extras),

)

create table Vehicles
(
   Id_Vehicle int not null identity(10001,1),
   Model varchar(16) not null,
   VehicleType varchar(16) not null,
   EngineType varchar(16) not null,
   Producer varchar(16) not null,
   Id_Extras int not null,
   YearOfProduction datetime not null,
   TransmissionType varchar(16) not null,
   Colour varchar(16) not null,
   CoupeType varchar(16) not null,
   Sold bit not null default 0,
   constraint  PK_Vehicle primary key (Id_Vehicle),
   constraint FK_Vehicle_VehicleType foreign key (VehicleType) references VehicleTypes(TypeOfVehicle) on delete cascade
                                                                                                         on update cascade,

  constraint FK_Vehicle_EngineType foreign key (EngineType) references EngineTypes(TypeOfEngine) on delete cascade
                                                                                                    on update cascade,

  constraint FK_Vehicle_Manufacturers foreign key (Producer) references Manufacturers(Name) on delete cascade
                                                                                           on update cascade,
  constraint FK_Vehicle_VehicleExtras foreign key (Id_Extras) references VehicleExtras(Id_Extras) on delete cascade
                                                                                                  on update cascade,
)

create table SalesHistory
(
   Id_Person int not null,
   Id_Vehicle int not null,
   DateSale datetime not null default getdate(),
   constraint PK_SalesHistory primary key (Id_Person,Id_Vehicle),
   constraint FK_SalesHistory_Person  foreign key (Id_Person) references Persons(Id_Person) on update cascade 
                                                                                           on delete cascade,
   constraint FK_SalesHistory_Vehicle foreign key (Id_Vehicle) references Vehicles(Id_vehicle) on update cascade
                                                                                              on delete cascade,
)
