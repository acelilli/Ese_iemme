-- DDL
CREATE DATABASE task_EnergiaPura;
USE task_EnergiaPura;

CREATE TABLE Istruttore(
	istruttoreID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(150) NOT NULL,
	cognome VARCHAR(150) NOT NULL,
	specializzazione VARCHAR(150) NOT NULL,
	orario_entrata TIME NOT NULL,
	orario_uscita TIME NOT NULL,
)

CREATE TABLE Abbonamento(
	abbonamentoID INT PRIMARY KEY IDENTITY(1,1),
	tipo_abbonamento VARCHAR(150) NOT NULL,
	CHECK(tipo_abbonamento 
	in('mensile','trimestrale','annuale')),
	prezzo_abbonamento DECIMAL(5,2) NOT NULL
)

 CREATE TABLE Membro(
	membroID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(150) NOT NULL,
	cognome VARCHAR(150) NOT NULL,
	sesso CHAR 
		CHECK(sesso in('m', 'f', 'a'))
		NOT NULL,
	data_nascita DATE NOT NULL,
	email VARCHAR(250) NOT NULL,
	telefono VARCHAR(10) NOT NULL,
	data_abbonamento DATETIME NOT NULL,
	abbonamentoRIF INT NOT NULL,
	FOREIGN KEY (abbonamentoRIF) REFERENCES Abbonamento(abbonamentoID) ON DELETE CASCADE
 )

 CREATE TABLE Classe(
	classeID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(150) NOT NULL,
	descrizione TEXT NOT NULL,
	orario_inizio TIME NOT NULL,
	orario_fine TIME NOT NULL,
	giorno_settimana VARCHAR 
		CHECK(giorno_settimana in('lun','mar','mer','gio','ven')) NOT NULL,
	max_iscritti INT NOT NULL DEFAULT 0,
 )

 CREATE TABLE Membro_Classe(
	membroRIF INT NOT NULL,
	classeRIF INT NOT NULL,
	data_prenotazione DATETIME NOT NULL 
	FOREIGN KEY (membroRIF) 
		REFERENCES Membro(membroID) ON DELETE CASCADE,
	FOREIGN KEY (classeRIF)
		REFERENCES Classe(classeID) ON DELETE CASCADE,
	UNIQUE(membroRIF, classeRIF)
 )

 CREATE TABLE Istruttore_Classe(
	istruttoreRIF INT NOT NULL,
	classeRIF INT NOT NULL,
	FOREIGN KEY (istruttoreRIF)
		REFERENCES Istruttore(istruttoreID) ON DELETE CASCADE,
	FOREIGN KEY (classeRIF) 
		REFERENCES Classe(classeID) ON DELETE CASCADE,
	UNIQUE(istruttoreRIF, classeRIF)
 )

 CREATE TABLE Attrezzatura(
	attrezzaturaID INT PRIMARY KEY IDENTITY(1,1),
	tipo VARCHAR(150) NOT NULL,
	descrizione TEXT NOT NULL,
	data_acquisto DATETIME,
	stato VARCHAR(150)
		CHECK(stato in('disponibile', 'in manutenzione', 'non disponibile'))
 )