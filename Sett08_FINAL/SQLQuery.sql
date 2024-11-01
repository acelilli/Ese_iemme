CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY(1,1),
	codice_utente VARCHAR(50) NOT NULL UNIQUE,
	username VARCHAR(250) NOT NULL UNIQUE,
	psw VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL UNIQUE,
	tipo_utente VARCHAR(50) DEFAULT 'User' CHECK (tipo_utente IN('User', 'Admin'))
);


INSERT INTO Utente(codice_utente, username, psw, email, tipo_utente) 
VALUES('AAA000','accountadmin','password123', 'admin@admin.it', 'Admin');

INSERT INTO Utente(codice_utente, username, psw, email, tipo_utente) 
VALUES('BBB001','testaccount','password124','test@test.it', 'User');