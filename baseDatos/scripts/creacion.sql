
drop table PreRegistro
go

CREATE TABLE [dbo].[PreRegistro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](150) NULL,
	[genero] [nvarchar](1) NULL,
	[edad] [int] NULL,
	[fechaNacimiento] [date] NULL,
	[estadoCivil] [nvarchar](1) NULL,
	[telefono] [nvarchar](max) NULL,
	[correo] [nvarchar](max) NULL,
	[tieneReligion] [bit] NULL,
	[religion] [nvarchar](100) NULL,
	[tieneCongregacion] [bit] NULL,
	[congregacion] [nvarchar](100) NULL,
	[tieneEnfermedad] [bit] NULL,
	[enfermedad] [nvarchar](100) NULL,
	[tieneRetiroT] [bit] NULL,
	[invitador] [nvarchar](100) NULL,
	[descripcion] [nvarchar](max) NULL,
	[info] [nvarchar](max) NULL,
	[notas] [nvarchar](max) NULL,
	[idSuscriptor] [int] NULL,
	[estatus] [smallint] NULL,
	[clase] [varchar](max) NULL,
	[ministerios] [varchar](max) NULL,
 CONSTRAINT [PK_PreRegistro] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
