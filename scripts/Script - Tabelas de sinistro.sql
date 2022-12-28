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
	InclusionUserId			INT,
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
	InclusionUserId			INT,
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_CommunicantType_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


IF OBJECT_ID('dbo.Notification', 'U') IS NOT NULL 
  DROP TABLE dbo.Notification; 
GO
CREATE TABLE  Notification
(
	Id						INT IDENTITY(1,1) NOT NULL,
	PolicyId				INT NOT NULL,
	StatusId				INT NOT NULL,
	SituationId				INT NOT NULL,
	Stage					INT NOT NULL,	
	DateNotification        DATETIME NULL,	
	InclusionUserId			INT,
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_Notification_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

IF OBJECT_ID('dbo.Policy', 'U') IS NOT NULL 
  DROP TABLE dbo.Policy; 
GO
CREATE TABLE  Policy
(
	Id						INT IDENTITY(1,1) NOT NULL,
	ProductId			    INT NOT NULL,
	EndorsementId			VARCHAR (15) NOT NULL,	
	ProposalNumber          INT  NOT NULL,
	ProposalDate			DATETIME NOT NULL,
	PolicyId                INT  NOT NULL,
	PolicyNumber            BIGINT  NOT NULL,
	PolicyDate				DATETIME NOT NULL,
	StartOfTerm				DATETIME NOT NULL,
	EndOfTerm					DATETIME NOT NULL,	
	Item					INT NOT NULL,	
	InclusionUserId			INT NOT NULL,
	CreatedDate             DATETIME NOT NULL,	
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_Policy_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



IF OBJECT_ID('dbo.Status', 'U') IS NOT NULL 
  DROP TABLE dbo.Status; 
GO
CREATE TABLE  Status
(
	Id		INT IDENTITY(1,1) NOT NULL,
	Name					VARCHAR(50)  NOT NULL,	
	Active					BIT,	
	InclusionUserId			INT,
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_Status_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

IF OBJECT_ID('dbo.Situation', 'U') IS NOT NULL 
  DROP TABLE dbo.Situation; 
GO
CREATE TABLE  Situation
(
	Id						INT IDENTITY(1,1) NOT NULL,
	Name					VARCHAR(50)  NOT NULL,	
	Active					BIT,
	InclusionUserId			INT,
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_Situation_Id] PRIMARY KEY CLUSTERED 
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
	InclusionUserId			INT,
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_Product_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Status_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO

ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Situation_SituationId] FOREIGN KEY([SituationId])
REFERENCES [dbo].[Situation] ([Id])
GO

ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Policy_PolicyId] FOREIGN KEY([PolicyId])
REFERENCES [dbo].[Policy] ([Id])
GO

Insert into PeriodType values('Data do Comunicado',1,1,Getdate(),null)
Insert into PeriodType values('Data da Ocorrência',1,1,Getdate(),null)
Insert into PeriodType values('Data do Registro',1,1,Getdate(),null)
Insert into PeriodType values('Data da Entrada na CIA',1,1,Getdate(),null)

Insert into Situation values('Aberto',1,1,Getdate(),null)
Insert into Situation values('Em Análise',1,1,Getdate(),null)
Insert into Situation values('Regulação',1,1,Getdate(),null)
Insert into Situation values('Suspenso',1,1,Getdate(),null)
Insert into Situation values('Liquidado',1,1,Getdate(),null)
Insert into Situation values('Indeferido',1,1,Getdate(),null)
Insert into Situation values('Deferido',1,1,Getdate(),null)

Insert into Status values('Completo',1,1,Getdate(),null)
Insert into Status values('Incompleto',1,1,Getdate(),null)

Insert into CommunicantType values('Corretor',1,1,Getdate(),null)
Insert into CommunicantType values('Segurado',1,1,Getdate(),null)
Insert into CommunicantType values('Terceiro',1,1,Getdate(),null)
Insert into CommunicantType values('Outros',1,1,Getdate(),null)


insert Product values ('GARANTIA SETOR PÚBLICO - UNIFICADO','11953'	 ,'/img/teste.jpg',1,1,getdate(), null)
insert Product values ('GARANTIA SETOR PÚBLICO - PORTAL SME','11980' ,'/img/teste.jpg',1,1,getdate(), null)
insert Product values ('GARANTIA DE OBRIGAÇÕES PRIVADAS','11926	'	 ,'/img/teste.jpg',1,1,getdate(), null)
insert Product values ('GARANTIA SETOR PÚBLICO - UNIFICADO','12012'	 ,'/img/teste.jpg',1,1,getdate(), null)


select * from CommunicantType

-- Notification
-- Policy
-- Communicant
-- Insured
-- Occurrence
--ProductParameter


--  Notification
--	Id
--	ProtocolNumber
--	SinisterNumber
--	DateNotification	
--	DateRegister
--	DateSinister
--	StatusId
--  Stage
--  SituationId
--	Contentious
--	CreatedDate             DATETIME NOT NULL,
--	UpdatedDate             DATETIME NULL,


--AdditionalInformation
--	Id
--	NotificationId
--  Contentious
--	ProcessType   
--	ProcessNumber
--  IncidentReport
--  IncidentReportNumber
--	CreatedDate             DATETIME NOT NULL,
--	UpdatedDate             DATETIME NULL,



-- Communicant
--	Id
--  NotificationId
--	CommunicantTypeId
--  PersonId
--	CreatedDate             DATETIME NOT NULL,
--	UpdatedDate             DATETIME NUL

-- Person
--	Name
--	Email

-- PersonPhone

-- PersonEmail

-- PersonAddress


--  Occurrence
--	Id
--	NotificationId
--	DateOccurrence


select * from Notification
select * from Policy