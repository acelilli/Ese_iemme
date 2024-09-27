CREATE DATABASE task_PrestitoLibri;
USE task_PrestitoLibri;

CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY(1,1),
	codiceUni VARCHAR(250) NOT NULL DEFAULT NEWID(),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL UNIQUE,
);

CREATE TABLE Libro(
	libroID INT PRIMARY KEY IDENTITY(1,1),
	codiceUni VARCHAR(250) NOT NULL DEFAULT NEWID(),
	titolo VARCHAR(250) NOT NULL,
	autore VARCHAR(250) NOT NULL,
	anno INT CHECK(anno <= YEAR(GETDATE())),
	disponinile BIT NOT NULL DEFAULT 1,
);

CREATE TABLE Prestito(
	prestitoID INT PRIMARY KEY IDENTITY(1,1),
	codiceUni VARCHAR(250) NOT NULL DEFAULT NEWID(),
	data_prestito DATE NOT NULL,
	data_ritorno DATE NOT NULL,
	utenteRIF INT NOT NULL,
	libroRIF INT NOT NULL,
	FOREIGN KEY (utenteRIF) REFERENCES Utente(utenteID) ON DELETE CASCADE,
	FOREIGN KEY (libroRIF) REFERENCES Libro(libroID) ON DELETE CASCADE,
	CONSTRAINT CHK_dataPrestito CHECK(data_ritorno >= data_prestito)
);

INSERT INTO Utente (nome, cognome, email) VALUES
('Mario', 'Rossi', 'mario.rossi@example.com'),
('Luca', 'Bianchi', 'luca.bianchi@example.com'),
('Giulia', 'Verdi', 'giulia.verdi@example.com'),
('Sofia', 'Neri', 'sofia.neri@example.com'),
('Francesco', 'Gialli', 'francesco.gialli@example.com'),
('Alessia', 'Marroni', 'alessia.marroni@example.com'),
('Andrea', 'Blu', 'andrea.blu@example.com'),
('Chiara', 'Grigi', 'chiara.grigi@example.com'),
('Roberto', 'Rossi', 'roberto.rossi@example.com'),
('Federica', 'Ferri', 'federica.ferri@example.com');

SELECT * FROM Utente;

INSERT INTO Libro (titolo, autore, anno, disponinile) VALUES
('Il codice da Vinci', 'Dan Brown', 2003, 1),
('La ragazza del treno', 'Paula Hawkins', 2015, 1),
('Harry Potter e la pietra filosofale', 'J.K. Rowling', 1997, 1),
('1984', 'George Orwell', 1949, 1),
('Il piccolo principe', 'Antoine de Saint-Exupéry', 1943, 1),
('Il signore degli anelli', 'J.R.R. Tolkien', 1954, 1),
('Il grande Gatsby', 'F. Scott Fitzgerald', 1925, 1),
('Cento anni di solitudine', 'Gabriel García Márquez', 1967, 1),
('La metamorfosi', 'Franz Kafka', 1915, 1),
('Orgoglio e pregiudizio', 'Jane Austen', 1813, 1);

SELECT * FROM Libro;

INSERT INTO Prestito (data_prestito, data_ritorno, utenteRIF, libroRIF) VALUES
('2024-01-10', '2024-01-20', 1, 1),
(N'2024-01-15', '2024-01-25', 2, 2),
('2024-01-20', '2024-01-30', 3, 3),
('2024-02-01', '2024-02-11', 4, 4),
('2024-02-05', '2024-02-15', 5, 5),
('2024-02-10', '2024-02-20', 6, 6),
('2024-02-15', '2024-02-25', 7, 7),
('2024-03-01', '2024-03-11', 8, 8),
('2024-03-05', '2024-03-15', 9, 9),
('2024-03-10', '2024-03-20', 10, 10);

INSERT INTO Prestito (data_prestito, data_ritorno, utenteRIF, libroRIF) VALUES
('2024-02-05', '2024-02-15', 5, 8),
('2024-02-05', '2024-02-15', 5, 9);

SELECT * FROM Prestito;