USE [DB_A72B95_drp]
GO

/****** Object:  Table [dbo].[Suscripcion]    Script Date: 17/12/2022 06:24:59 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

DROP TABLE SuscripcionLLave
GO

CREATE TABLE [dbo].[SuscripcionLLave](
    id INT IDENTITY(1,1) NOT NULL,
	[llave] nvarchar(MAX) NOT NULL,
	[llaveE] varbinary(MAX) NULL,
	[IdSuscriptor] [int]  NOT NULL,
	cuenta varchar(100) NULL,
	servicio varchar(50),
	[FechaInicio] [smalldatetime] NULL,
	[FechaVencimiento] [smalldatetime] NULL,
	[estacionTrabajo] [varchar](250) NULL,

 CONSTRAINT [PK_SuscripcionLLave] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


ALTER PROCEDURE RegistrarSuscripcionLLave
	@idSuscriptor int  ,
	@cuenta varchar(100) ,
	@servicio varchar(50) ,
	@estacionTrabajo varchar(250) 
AS
DECLARE @Intervalo INT=60, @diasVigencia INT
DECLARE @llave nvarchar(MAX) 
DECLARE @UNI UNIQUEIDENTIFIER
DECLARE @cf Nvarchar(200); 
DECLARE @llaveE varbinary(MAX) 

DECLARE	@fechaInicio smalldatetime ,
	    @fechaVencimiento smalldatetime 

SET @cf = N'Olimpo26';
SELECT @cf=valor FROM [dbo].[Configuracion]  WHERE id='ClaveCertificado'
SELECT @Intervalo=valor FROM [dbo].[Configuracion]  WHERE id='TiempoCertificado'
PRINT @cf
PRINT @Intervalo

SELECT @diasVigencia=DATEDIFF(dd, isnull(FechaVencimiento,GETDATE()) ,GETDATE() ) FROM  Suscripcion  WHERE IdSuscriptor=@idSuscriptor  and  Activo=1
PRINT @diasVigencia
if @diasVigencia<=0
BEGIN
	--SET @UNI = NEWID()
	SET @llave =  NEWID()
	PRINT @llave

	SET @llaveE= ENCRYPTBYPASSPHRASE(@cf,  @llave)
	PRINT @llaveE

	SET @fechaInicio=GETDATE()
	SET @fechaVencimiento=DATEADD(mi,@Intervalo,GETDATE())
	INSERT INTO SuscripcionLLave (  llave, llaveE,idSuscriptor, cuenta, servicio, fechaInicio, fechaVencimiento, estacionTrabajo)  VALUES ( @llave, @llaveE,@idSuscriptor,@cuenta, @servicio, @fechaInicio, @fechaVencimiento, @estacionTrabajo )
     
END
---SELECT  convert(int,@@Identity) as id   , @llave AS llave, @fechaVencimiento as fechaVencimiento, DATEDIFF(mi, GETDATE(),isnull(@fechaVencimiento,GETDATE()) )  AS tiempo , @diasVigencia AS diasVigencia
RETURN @llave
GO

 
ALTER PROCEDURE VerificarSuscripcionLLave
	@idSuscriptor int  ,
	@llave NVARCHAR(MAX),
	@llaveE varbinary(MAX)
    
AS
 DECLARE @cf Nvarchar(200)
 DECLARE @Intervalo INT=60,  @díasVigencia INT
 DECLARE @llaveT varbinary(MAX) 
 SET @cf = N'Olimpo26';

SELECT @díasVigencia=DATEDIFF(dd, isnull(FechaVencimiento,GETDATE()) ,GETDATE() ) FROM  Suscripcion  WHERE IdSuscriptor=@idSuscriptor  and  Activo=1
PRINT @díasVigencia
if @díasVigencia<=0
BEGIN

	SELECT @cf=valor FROM [dbo].[Configuracion]  WHERE id='ClaveCertificado'
	SELECT @Intervalo=valor FROM [dbo].[Configuracion]  WHERE id='TiempoCertificado'
	PRINT @cf
	PRINT @Intervalo

	 IF @llave<>''
		SET @llaveE= ENCRYPTBYPASSPHRASE(@cf,  @llave)
	 ELSE IF @llaveE<>''
		SET @llave=CAST( DECRYPTBYPASSPHRASE(@cf,@llaveE) AS NVARCHAR(MAX))

END
ELSE
BEGIN
 SET @llave=''
 SET @llaveE=NULL
END
SELECT convert(int,id) as id , @llave AS llave,  fechaVencimiento,DATEDIFF(mi, GETDATE(),isnull(fechaVencimiento,GETDATE()) )  AS tiempo ,  @diasVigencia AS díasVigencia FROM  SuscripcionLLave  WHERE llave=@llave  AND DATEDIFF(mi, GETDATE(),isnull(fechaVencimiento,GETDATE()) ) <=@Intervalo

go





SELECT valor,* FROM [dbo].[Configuracion]  WHERE id='ClaveCertificado'


UPDATE [dbo].[Configuracion] 
SET TIPO='string'
WHERE id='ClaveCertificado'


INSERT INTO  [dbo].[Configuracion]  SELECT 'TiempoCertificado', 'Tiempo hrs. certificdoa Api'  ,60, 'int',1,1


INSERT INTO  [dbo].[Configuracion]  SELECT 'ClaveCertificado', 'Clave certificdoa Api'  ,'Olimpo26', 'string',1,1





----------------------------------------------------------------------------


EXEC RegistrarSuscripcionLLave  1,'giorgio','AAA','FGA'

delete  FROM SuscripcionLLave
SELECT  * FROM SuscripcionLLave

EXEC VerificarSuscripcionLLave 1,'394677AA-0755-4E42-8E55-C833190713DC', null

delete from  SuscripcionLlave

SELECT * FROM  Suscripcion
UPDATE  Suscripcion
SET fechaVencimiento='2024-01-30 19:26:00'  , Activo=1


 DECLARE @DATO Nvarchar(MAX); 
 DECLARE @cf Nvarchar(200); 
 SET @DATO = N'ESTO ES ES UN EJEMPLO'
 SET @cf = N'Olimpo26';

 DECLARE @DatoEncriptado varbinary(8000)
 SELECT @DatoEncriptado= ENCRYPTBYPASSPHRASE(@cf,  @DATO)
 SELECT @DatoEncriptado
 SELECT CAST( DECRYPTBYPASSPHRASE(@cf,@DatoEncriptado) AS NVARCHAR(MAX))



SELECT  CAST(0x020000007980E85975490D0023FE0916B3E2817C106253EB4C3FE6F76D6C7AEFB1B03A6E4B5C6FA92BD12C63071279495548D2EF3A1FB2635123CA31ADBC338360F9AEF274CC915ADE692C6DBF42AFF844517D0A1732D368DFEAA1F20E0BF7C77653B437B3CB66C68E74449E103BCE3C725F18C2 AS VARCHAR(MAX))



 declare @b varbinary(max)
 declare @V  NVARCHAR(MAX)

 SET @V='1'
 SET @b=CONVERT (varbinary(max) ,@V )
 SELECT @V , @b
 SELECT CONVERT(NVARCHAR(MAX), @b)
 SELECT CONVERT (varbinary(max) ,@V )


 CONVERT(VARCHAR(max), @b, 0)
set @b = '0x020000007980E85975490D0023FE0916B3E2817C106253EB4C3FE6F76D6C7AEFB1B03A6E4B5C6FA92BD12C63071279495548D2EF3A1FB2635123CA31ADBC338360F9AEF274CC915ADE692C6DBF42AFF844517D0A1732D368DFEAA1F20E0BF7C77653B437B3CB66C68E74449E103BCE3C725F18C2'
SET @V=CONVERT(VARCHAR(max), @b, 0)
SET @V='0x020000007980E85975490D0023FE0916B3E2817C106253EB4C3FE6F76D6C7AEFB1B03A6E4B5C6FA92BD12C63071279495548D2EF3A1FB2635123CA31ADBC338360F9AEF274CC915ADE692C6DBF42AFF844517D0A1732D368DFEAA1F20E0BF7C77653B437B3CB66C68E74449E103BCE3C725F18C2'
SELECT @V , CONVERT (varbinary(max) ,@V, 0 )



select cast(@b as varchar(max))
SELECT CONVERT (varbinary(max) ,CONVERT(VARCHAR(max), @b, 0))
select CONVERT(varchar(max), @b, 0)


select  genero   from  Preregistro