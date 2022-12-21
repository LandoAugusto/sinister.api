USE Sinister
GO
IF OBJECT_ID('dbo.PeriodType', 'U') IS NOT NULL 
  DROP TABLE dbo.PeriodType; 
GO
CREATE TABLE  PeriodType
(
	Id			INT IDENTITY(1,1) NOT NULL,
	Name					VARCHAR(50)  NOT NULL,	
	Active					BIT,	
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_PeriodType_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


IF OBJECT_ID('dbo.CommunicantType', 'U') IS NOT NULL 
  DROP TABLE dbo.CommunicantType; 
GO
CREATE TABLE  CommunicantType
(
	Id			INT IDENTITY(1,1) NOT NULL,
	Name					VARCHAR(50)  NOT NULL,	
	Active					BIT,	
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_CommunicantType_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

IF OBJECT_ID('dbo.StatusSinister', 'U') IS NOT NULL 
  DROP TABLE dbo.StatusSinister; 
GO
CREATE TABLE  StatusSinister
(
	Id		INT IDENTITY(1,1) NOT NULL,
	Name					VARCHAR(50)  NOT NULL,	
	Active					BIT,	
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_StatusSinister_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

IF OBJECT_ID('dbo.Product', 'U') IS NOT NULL 
  DROP TABLE dbo.Product; 
GO
CREATE TABLE  Product
(
	Id				INT IDENTITY(1,1) NOT NULL,
	Name					VARCHAR(50)  NOT NULL,	
	ExternalId				VARCHAR(10)  NOT NULL,
	ImageUrl				VARCHAR(50)  NOT NULL,	
	Active					BIT,	
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_Productr_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


Insert into PeriodType values('Data do Comunicado',1,Getdate(),null)
Insert into PeriodType values('Data da Ocorrência',1,Getdate(),null)
Insert into PeriodType values('Data do Registro',1,Getdate(),null)
Insert into PeriodType values('Data da Entrada na CIA',1,Getdate(),null)

Insert into StatusSinister values('Completo',1,Getdate(),null)
Insert into StatusSinister values('Incompleto',1,Getdate(),null)

Insert into CommunicantType values('Corretor',1,Getdate(),null)
Insert into CommunicantType values('Segurado',1,Getdate(),null)
Insert into CommunicantType values('Terceiro',1,Getdate(),null)
Insert into CommunicantType values('Outros',1,Getdate(),null)


insert product values ('GARANTIA SETOR PÚBLICO - UNIFICADO','11953'	 ,'/img/teste.jpg',1,getdate(), null)
insert product values ('GARANTIA SETOR PÚBLICO - PORTAL SME','11980' ,'/img/teste.jpg',1,getdate(), null)
insert product values ('GARANTIA DE OBRIGAÇÕES PRIVADAS','11926	'	 ,'/img/teste.jpg',1,getdate(), null)
insert product values ('GARANTIA SETOR PÚBLICO - UNIFICADO','12012'	 ,'/img/teste.jpg',1,getdate(), null)


--SinisterNotification
--SinisterPolicy
--SinisterCommunicant
--SinisterInsured
--SinisterOccurrence
--ProductParameter


