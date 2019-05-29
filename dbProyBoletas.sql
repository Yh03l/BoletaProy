create database dbProyBoletas
use dbProyBoletas
/*
Integrantes:
Jhon Guzman 
Joel Herbas
Fernando Mercado
*/
create table tipo_persona
(
  id int identity not null,
  descripcion char(25) not null,
  estado varchar(1) not null,
  check (estado='A' or estado='B'),
  check(descripcion<>''),
  primary key (id)
)
go


create table tipo_usuario
(
  id int identity(1,1) not null,
  descripcion char(25) not null,
  estado varchar(1) not null,
  check (estado='A' or estado='B'),
  check(descripcion<>''),
  primary key (id)
)
go


create table area
(
  id int identity(1,1) not null,
  nombre char(25) not null,
  estado varchar(1) not null,
  check (estado='A' or estado='B'),
  primary key (id)
)
go



create table persona(
  id  int identity not null,
  nombre varchar(25) not null,
  apellidop varchar(20) not null,
  apellidom varchar(20),
  ci        varchar(8) unique not null,
  direccion varchar(60) not null,
  email     varchar(40) unique not null,
  telefono  int not null,
  tipo_per int not null,
  id_area int not null,
  sexo varchar (1) not null,
  check (sexo='F' or sexo='M'),
  estado varchar(1) not null,
  check (estado='A' or estado='B'),
  primary key(id),
  foreign key (tipo_per) references tipo_persona(id),
  foreign key (id_area) references area(id)
)

create table usuario
( 
  id int not null,
  nombre_usuario varchar(15) not null UNIQUE  ,
  password_usuario varbinary(max) not null,
  id_usr int not null,
  estado char(1) not null,
  check (estado='A' or estado='B'),
  check(nombre_usuario<>''),
  check(password_usuario<>''),
  primary key(id),
  foreign key(id) references persona(id),
  foreign key(id_usr) references tipo_usuario(id)
)
go


create table tipo_servicio
(
  id int identity not null,
  nombre varchar(25) not null,
  estado varchar(1) not null,
  check (estado='A' or estado='B'),
  check(nombre<>''),
  primary key (id)
)
go

create table servicio
(
	id int identity not null,
	nombre varchar(25) not null,
	tipo_ser int not null,
	estado varchar (1) not null,
	check (estado='A' or estado ='B'),
	primary key (id),
	foreign key (tipo_ser) references tipo_servicio(id)
)

create table boleta
(
	id int identity not null,
	nro_orden int  not null,
	descripcion varchar(max) not null,
	estado varchar (1) not null,
	check (estado='A' or estado ='B'),
	fecha_inicio date not null,
	fecha_asignacion date not null,
	fecha_fin date not null,
	hora_inicio datetime not null,
	hora_asignacion datetime,
	hora_fin datetime not null,
	prioridad varchar(10) not null,
	id_usr int not null,
	id_pers int not null,
	id_serv int not null,
	primary key (id),
	foreign key (id_usr) references usuario(id),
	foreign key (id_pers) references persona(id),
	foreign key (id_serv) references servicio(id)
)

create table solucion
(
	id int identity not null,
	descripcion varchar(max),
	id_boleta int not null,
	primary key(id),
	foreign key (id_boleta) references boleta (id)
)

