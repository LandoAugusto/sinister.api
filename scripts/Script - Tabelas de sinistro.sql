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

IF OBJECT_ID('dbo.Communicant', 'U') IS NOT NULL 
  DROP TABLE dbo.Communicant; 
GO
CREATE TABLE  Communicant
(
	Id						INT IDENTITY(1,1) NOT NULL,
	NotificationId			INT NOT NULL,
	CommunicantTypeId		INT NOT NULL,	
	Name					VARCHAR(50),
	InclusionUserId			INT,
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_Communicant_Id] PRIMARY KEY CLUSTERED 
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


IF OBJECT_ID('dbo.CommunicantPhone', 'U') IS NOT NULL 
  DROP TABLE dbo.CommunicantPhone; 
GO
CREATE TABLE  CommunicantPhone
(
	Id						INT IDENTITY(1,1) NOT NULL,
	CommunicantId			INT NOT NULL,
	PhoneTypeId				INT NOT NULL,	
	Ddd						VARCHAR(3),
	Phone					VARCHAR(14),
	InclusionUserId			INT,
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_CommunicanPhone_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


IF OBJECT_ID('dbo.CommunicantEmail', 'U') IS NOT NULL 
  DROP TABLE dbo.CommunicantEmail; 
GO
CREATE TABLE  CommunicantEmail
(
	Id						INT IDENTITY(1,1) NOT NULL,
	CommunicantId			INT NOT NULL,
	EmailTypeId				INT NOT NULL,		
	Email					VARCHAR(50),
	InclusionUserId			INT,
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_CommunicantEmail_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




IF OBJECT_ID('dbo.PhoneType', 'U') IS NOT NULL 
  DROP TABLE dbo.PhoneType; 
GO
CREATE TABLE  PhoneType
(
	Id						INT IDENTITY(1,1) NOT NULL,
	Name					VARCHAR(50)  NOT NULL,	
	Active					BIT,
	InclusionUserId			INT,
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_PhoneType_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


IF OBJECT_ID('dbo.EmailType', 'U') IS NOT NULL 
  DROP TABLE dbo.EmailType; 
GO
CREATE TABLE  EmailType
(
	Id						INT IDENTITY(1,1) NOT NULL,
	Name					VARCHAR(50)  NOT NULL,	
	Active					BIT,
	InclusionUserId			INT,
	CreatedDate             DATETIME NOT NULL,
	UpdatedDate             DATETIME NULL,
 
CONSTRAINT [PK_EmailType_Id] PRIMARY KEY CLUSTERED 
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

ALTER TABLE [dbo].[Policy]  WITH CHECK ADD  CONSTRAINT [FK_Policy_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[Communicant]  WITH CHECK ADD  CONSTRAINT [FK_Communicant_CommunicanType_CommunicanTypeId] FOREIGN KEY([CommunicantTypeId])
REFERENCES [dbo].[CommunicantType] ([Id])
GO

ALTER TABLE [dbo].[CommunicantPhone]  WITH CHECK ADD  CONSTRAINT [FK_CommunicantPhone_Communicant_CommunicantId] FOREIGN KEY([CommunicantId])
REFERENCES [dbo].[Communicant] ([Id])
GO

ALTER TABLE [dbo].[CommunicantPhone]  WITH CHECK ADD  CONSTRAINT [FK_CommunicantPhone_PhoneType_PhoneTypeId] FOREIGN KEY([PhoneTypeId])
REFERENCES [dbo].[PhoneType] ([Id])
GO


ALTER TABLE [dbo].[CommunicantEmail]  WITH CHECK ADD  CONSTRAINT [FK_CommunicantEmail_Communicant_CommunicantId] FOREIGN KEY([CommunicantId])
REFERENCES [dbo].[Communicant] ([Id])
GO


ALTER TABLE [dbo].[CommunicantEmail]  WITH CHECK ADD  CONSTRAINT [FK_CommunicantEmail_EmailType_EmailTypeId] FOREIGN KEY([EmailTypeId])
REFERENCES [dbo].[EmailType] ([Id])
GO



Insert into PhoneType values('Residencial',1,1,Getdate(),null)
Insert into PhoneType values('Celular',1,1,Getdate(),null)

Insert into EmailType values('Pessoal',1,1,Getdate(),null)
Insert into EmailType values('Corporativo',1,1,Getdate(),null)


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


select * from Communicant

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