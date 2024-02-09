CREATE DATABASE prueba_1 

use prueba_1

create table USUARIOS(
IdUsuario int primary key identity(1,1),
Nombre varchar(100),
Apellido varchar(100),
Edad varchar(10),
IdTipo int,
constraint FK_Tipo FOREIGN KEY  (IdTipo) REFERENCES TIPO (IdTipo)
)

create table TIPO(
IdTipo int primary key identity(1,1),
Descripcion varchar(200)
)
SELECT*FROM USUARIOS
SELECT*FROM TIPO

