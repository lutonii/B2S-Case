create database dbcliente;
use dbcliente;

create table cliente(
id int auto_increment,
nome varchar(100) not null,
data_cadastro date not null,
primary key(id)
)

select * from cliente;

alter table dbcliente convert to character set utf8 collate utf8_general_ci;
