CREATE TABLE Persona(
	personaID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL UNIQUE,
	telefono VARCHAR(15) NOT NULL,
);

CREATE TABLE CodiceFiscale(
	codiceID INT PRIMARY KEY IDENTITY(1,1),
	cod_fis VARCHAR(16) NOT NULL UNIQUE,
	personaRIF INT NOT NULL,
	data_emissione DATE NOT NULL,
	data_scadenza DATE NOT NULL,
	FOREIGN KEY(personaRIF) REFERENCES Persona(personaID) ON DELETE CASCADE,
	CONSTRAINT CK_DataScadenza CHECK(data_scadenza > data_emissione)
);

INSERT INTO Persona (nome, cognome, email, telefono) 
VALUES 
('Mario', 'Rossi', 'mario.rossi@example.com', '1234567890'),
('Giulia', 'Verdi', 'giulia.verdi@example.com', '0987654321'),
('Luca', 'Bianchi', 'luca.bianchi@example.com', '1122334455');

INSERT INTO CodiceFiscale (cod_fis, data_emissione, data_scadenza, personaRIF)
VALUES 
('MRARSS80A01H501Z', '2022-01-01', '2032-01-01', 1),
('GLUVRD90B02H501A', '2023-02-02', '2033-02-02', 2),
('LCUBNC95C03H501B', '2024-03-03', '2034-03-03', 3);

SELECT * FROM Persona;
SELECT * FROM CodiceFiscale;