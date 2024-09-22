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
	giorno_settimana VARCHAR(3) 
		CHECK(giorno_settimana in('lun','mar','mer','gio','ven')) NOT NULL,
	max_iscritti INT NOT NULL DEFAULT 0,
 )

 ALTER TABLE Classe ALTER COLUMN giorno_settimana VARCHAR(3) NOT NULL;
 ALTER TABLE Classe ADD CONSTRAINT CHK_giorno_settimana 
	CHECK(giorno_settimana in('lun','mar','mer','gio','ven'));

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

 -- DML

INSERT INTO Istruttore (nome, cognome, specializzazione, orario_entrata, orario_uscita) 
VALUES 
    ('Bianca', 'Bianchi', 'Yoga', '09:00:00', '17:00:00'),
    ('Andrea', 'Verdi', 'Pilates', '10:00:00', '18:00:00'),
    ('Mario', 'Rossi', 'CrossFit', '12:00:00', '20:00:00'),
    ('Valerio', 'Cieli', 'Bodybuilding', '09:00:00', '17:00:00'),
    ('Chiara', 'Neri', 'Zumba', '10:00:00', '18:00:00');

INSERT INTO Abbonamento (tipo_abbonamento, prezzo_abbonamento) 
VALUES 
    ('mensile', 30.00),
    ('trimestrale', 85.00),
    ('annuale', 300.00);

INSERT INTO Membro (nome, cognome, sesso, data_nascita, email, telefono, data_abbonamento, abbonamentoRIF) 
VALUES 
    ('Veronica', 'Gialli', 'f', '1990-05-12', 'vero.gial@mail.com', '3333333333', '2024-01-01 10:00:00', 1);
INSERT INTO Membro (nome, cognome, sesso, data_nascita, email, telefono, data_abbonamento, abbonamentoRIF) 
VALUES 
    ('Elena', 'Giuli', 'f', '1985-07-22', 'elena.gi@mail.com', '3444444444', '2024-01-05 11:00:00', 2);
INSERT INTO Membro (nome, cognome, sesso, data_nascita, email, telefono, data_abbonamento, abbonamentoRIF) 
VALUES 
    ('Giacomo', 'Cocci', 'm', '1992-03-30', 'gia.co@mail.com', '3477777777', '2024-01-10 09:30:00', 3);
INSERT INTO Membro (nome, cognome, sesso, data_nascita, email, telefono, data_abbonamento, abbonamentoRIF) 
VALUES 
    ('Alex', 'Mariani', 'a', '1993-12-09', 'ale.x@mail.com', '3334445555', '2024-09-08 09:40:00', 2);
INSERT INTO Membro (nome, cognome, sesso, data_nascita, email, telefono, data_abbonamento, abbonamentoRIF) 
VALUES 
    ('Daniela', 'Draghi', 'f', '2000-06-28', 'dani.dr@mail.com', '3488889999', '2024-06-10 11:00:00', 1);
INSERT INTO Membro (nome, cognome, sesso, data_nascita, email, telefono, data_abbonamento, abbonamentoRIF) 
VALUES 
    ('Walter', 'Bianco', 'm', '1989-04-21', 'wal.wh@email.com', '3471112222', '2023-11-11 18:00:00', 3);

INSERT INTO Classe (nome, descrizione, orario_inizio, orario_fine, giorno_settimana, max_iscritti) 
VALUES 
    ('Yoga Principianti', 'Lezione di yoga per principianti', '09:00:00', '10:30:00', 'lun', 20),
    ('Yoga Intermedio', 'Lezione di yoga intermedio', '09:00:00', '10:30:00', 'mar', 20),
    ('Yoga Avanzato', 'Lezione di yoga avanzato', '09:00:00', '10:30:00', 'mer', 20),
    ('Pilates Principianti', 'Corso di pilates per principianti', '11:00:00', '12:00:00', 'mer', 15),
    ('Pilates Intermedio', 'Corso di pilates di livello intermedio', '11:00:00', '12:00:00', 'gio', 15),
    ('Pilates Avanzato', 'Corso di pilates di livello avanzato', '11:00:00', '12:00:00', 'ven', 15),
    ('CrossFit', 'Allenamento intenso di CrossFit', '18:00:00', '19:30:00', 'mer', 25),
    ('Zumba per tutti', 'Lezione di Zumba adatta a tutti', '16:00:00', '18:30:00', 'gio', 20);

INSERT INTO Classe (nome, descrizione, orario_inizio, orario_fine, giorno_settimana, max_iscritti) 
VALUES 
    ('Spinning', 'Lezione di spinning energico', '11:00:00', '12:30:00', 'lun', 15),
    ('Sollevamento pesi', 'Lezione di sollevamento pesi', '16:00:00', '18:30:00', 'ven', 15);

INSERT INTO Classe (nome, descrizione, orario_inizio, orario_fine, giorno_settimana, max_iscritti) 
VALUES 
    ('Spinning energico', 'Lezione di spinning energico', '11:00:00', '12:30:00', 'mer', 15),
	('Spinning extra', 'Lezione di spinning energico', '12:00:00', '13:00:00', 'ven', 10),
    ('Sollevamento pesi extra', 'Lezione di sollevamento pesi', '09:00:00', '10:30:00', 'gio', 10);

INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
    (13, 2, '2024-01-05 09:10:00');
INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
    (19, 2, '2024-01-10 18:20:00');
INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
    (14, 3, '2024-01-06 09:15:00');
INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
    (15, 4, '2024-01-07 09:10:00');
INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
    (17, 4, '2024-01-09 11:20:00');
INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
    (16, 5, '2024-01-08 11:10:00');
INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
    (17, 6, '2024-01-09 11:20:00');
INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
    (19, 7, '2024-01-10 18:10:00');
INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
    (16, 8, '2024-01-08 11:40:00');
INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
    (15, 8, '2024-01-07 09:40:00');
INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
    (17, 9, '2024-01-09 11:10:00');
INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
    (14, 9, '2024-01-06 09:30:00');

INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
	(19, 1002, '2024-04-11 18:10:00'),
	(15, 1002, '2024-05-08 09:00:00');

INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
	(19, 1003, '2024-04-11 18:10:00'),
	(16, 1003, '2024-01-08 11:40:00'),
	(15, 1003, '2024-05-08 09:00:00');

INSERT INTO Membro_Classe (membroRIF, classeRIF, data_prenotazione)
VALUES 
 (16, 1006, '2024-01-08 11:40:00'),
 (17, 1008, '2024-01-09 11:10:00'),
 (15, 1007, '2024-05-08 09:00:00');

--Bianca Bianchi Yoga
INSERT INTO Istruttore_Classe(istruttoreRIF, classeRIF) 
VALUES
	(1,2),
	(1,3),
	(1,4);

-- Andrea Verdi Pilates
INSERT INTO Istruttore_Classe(istruttoreRIF, classeRIF)
VALUES
	(2,5),
	(2,6),
	(2,7);

--Mario Rossi Crossfit e Chiara Neri Zumba
INSERT INTO Istruttore_Classe(istruttoreRIF, classeRIF)
VALUES
	(3,8),
	(5,9);

--Valerio Cieli Spinning e Sollevamento Pesi
INSERT INTO Istruttore_Classe(istruttoreRIF, classeRIF)
VALUES
	(4,1002),
	(4,1003);

INSERT INTO Istruttore_Classe(istruttoreRIF, classeRIF)
VALUES
	(4,1006),
	(4,1008),
	(4,1007);

INSERT INTO Attrezzatura (tipo, descrizione, data_acquisto, stato)
VALUES
    ('10x Tappetino Yoga', '10 Tappetini antiscivolo per yoga', '2023-01-01 10:00:00', 'disponibile'),
    ('Rullo Pilates', 'Rullo per esercizi di pilates', '2023-02-01 11:00:00', 'disponibile'),
    ('Bilanciere CrossFit', 'Bilanciere olimpico da 20 kg', '2023-03-01 12:00:00', 'in manutenzione'),
    ('Pesi', 'Set di pesi regolabili', '2023-04-01 13:00:00', 'disponibile'),
	('10x Biciclette Spinning', '10 biciclette per lo spinning', '2023-06-01 11:00:00', 'in manutenzione'),
    ('Corda Zumba', 'Corda da salto per Zumba', '2023-05-01 14:00:00', 'non disponibile');
	 