/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[nombre]
      ,[genero]
      ,[edad]
      ,[fechaNacimiento]
      ,[estadoCivil]
      ,[telefono]
      ,[correo]
      ,[tieneReligion]
      ,[religion]
      ,[tieneCongregacion]
      ,[congregacion]
      ,[tieneEnfermedad]
      ,[enfermedad]
      ,[tieneRetiroT]
      ,[invitador]
      ,[descripcion]
      ,[info]
      ,[notas]
      ,[idSuscriptor]
      ,[estatus]
      ,[clase]
      ,[ministerios]
  FROM [db_a983df_ayr].[dbo].[PreRegistro]
  where  nombre like '%Maria%'


  update [db_a983df_ayr].[dbo].[PreRegistro]
  set nombre='' , estatus=0
  where id  in  ( 46,47)

  select nombre, count(*)
  FROM [db_a983df_ayr].[dbo].[PreRegistro]
  group  by  nombre
  having count(*)>1



  update [db_a983df_ayr].[dbo].[PreRegistro]
  set invitador='Iglesia' 
where  invitador like '%Iglesia%'


   select id, invitador,*
   FROM [db_a983df_ayr].[dbo].[PreRegistro]
   where  invitador like '%Guada%'

   update [db_a983df_ayr].[dbo].[PreRegistro]
   set invitador='Guadalupe Alfaro' 
   where  id in ( 24 )

   select invitador,count(*)  as Cuenta
   FROM [db_a983df_ayr].[dbo].[PreRegistro]
   GROUP  BY   invitador 
   order by  2  desc

