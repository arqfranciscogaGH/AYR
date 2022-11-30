select id, nombre, invitador, estatus   from PreRegistro where estatus=1  and ( invitador  is null or invitador='' )
select *   from PreRegistro where  nombre like '%Miguel%' or  nombre like '%rosa%'

update  PreRegistro
set  clase='rojo' 
where id
in ( select id   from PreRegistro where  clase is null  or  clase='')
update  PreRegistro
set  clase='negro' 
where id >0   and  id<20

update  PreRegistro
set  clase='azul' 
where id >=21   and  id<=60

update  PreRegistro
set  clase='Verde' 
where id >=59


select id, Nombre , telefono  from PreRegistro where  telefono is  null
select Nombre   from PreRegistro where estatus=0 or  estatus is  null
select *   from PreRegistro where estatus=1
select id, nombre, invitador ,*  from PreRegistro where  id =  20




update  PreRegistro
set  invitador='Iglesia'
where id >  29 and  id < 40

select invitador, count(*)  as cuenta  from PreRegistro
where  estatus=1
group by  invitador
order  by 2 desc

select id, nombre, invitador, estatus   from PreRegistro where invitador='Alondra Itzel  Aguilar'

select id, nombre, invitador, estatus   from PreRegistro where id in (60,67,80 )
 

update  PreRegistro
set  invitador='Alondra Aguilar'
where id in (60,67,80 )


update  PreRegistro
set  genero='H'
where id in (47,48,77,81)

update  PreRegistro
set  genero='M'
where id in (11,19,20,27,28,29,36,37,41,42 ,45,46,50,54,56,57,59,74,76,78)

select id, nombre,genero , invitador, estatus   from PreRegistro  where  genero is  null or  genero=''

select genero, count(*)  as cuenta  from PreRegistro
where  estatus=1
group by  genero
order  by 2 desc

select *   from PreRegistro where genero is null
update  PreRegistro set genero=''  where genero is null

select *   from PreRegistro where estadoCivil is null
update  PreRegistro set estadoCivil=''  where estadoCivil is null


select *   from PreRegistro where edad is null
update  PreRegistro set edad=0  where edad is null

update  PreRegistro set estatus=1  where estatus is null
update  PreRegistro
set estatus=1
where   id in ( 98 )

update  PreRegistro
set estatus=0 ,  invitador='Federico Pérez'
where   id in ( 20 )

update  PreRegistro
set   invitador='Maribel Barajas Herrera'
where   id in ( 38 )




update  PreRegistro
set edad= 55  , genero='H' ,  estadoCivil='C' , congregacion='PIB Satelite' , religion='Cristiana' , invitador='Amalia Mendoza'
where   id =55

update  PreRegistro
set edad= 30  , genero='H', nombre ='Alexander Baltazar Villanueva' , invitador='Federico Pérez'
where   id =17

update  PreRegistro
set edad= 49  , genero='H' , invitador='Federico Pérez'
where   id =33


update  PreRegistro
set edad= 59  , genero='H' , invitador='Federico Pérez'
where   id =30

update  PreRegistro
set edad= 49  , genero='M' , invitador='Jose Angel Meza'
where   id =39

select *   from PreRegistro where invitador='Federico'

update  PreRegistro
set  invitador='Federico Pérez'
where   invitador='Federico'

