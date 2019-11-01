CREATE DATABASE M_Cleveland

use m_cleveland

CREATE TABLE Medicos(
	Crm INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100) NOT NULL,
	DataNascimento Date NOT NULL
)

INSERT Medicos(nome,dataNascimento)
	VALUES('Cleiton','1988-03-01')

	
INSERT Medicos(nome,dataNascimento)
	VALUES('Camila','1900-01-10'),('Gabriel','2020-03-01')


ALTER TABLE medicos
ADD Ativo BIT;

ALTER TABLE medicos
ADD Especialidade int foreign key references especialidade(id);

UPDATE medicos
SET especialidade = 3
WHERE crm =3;



CREATE TABLE Especialidade(
	Id INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100) NOT NULL
)

INSERT Especialidade(Nome)
	VALUES('Ginecologista'),('Clinico geral'),('Cardiologista'),('Pediatra')
	select * from medicos


select * from Especialidade