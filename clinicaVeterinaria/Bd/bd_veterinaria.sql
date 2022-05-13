create database db_veterinaria;

use db_veterinaria;

create table tipoUsuario(
	id int primary key auto_increment,
    usuario varchar(50)
);

create table login(
	usuario varchar(200) primary key,
    senha varchar(200),
    idTipoUsuario int,
    foreign key (idTipoUsuario) references tipoUsuario(id)
);

create table cliente(
	id int primary key auto_increment,
    nome varchar(250),
    telefone varchar(12),
    email varchar (250)
);

create table tipoAnimal(
	id int primary key auto_increment,
    tipo varchar(250)
);

create table animal(
	id int primary key auto_increment,
    nome varchar(250),
    idTipo int,
    idCliente int,
    foreign key (idTipo) references tipoAnimal(id),
    foreign key (idCliente) references cliente(id)
);

create table veterinario(
	id int primary key auto_increment,
    nome varchar(200)
);

create table atendimento(
	id int primary key auto_increment,
    data varchar(20),
    hora varchar(20),
    idVeterinario int,
    idAnimal int,
    foreign key (idVeterinario) references animal(id),
    foreign key (idAnimal) references veterinario(id)
);


