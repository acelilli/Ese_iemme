CREATE DATABASE task_VacanGio;
USE task_VacanGio;

CREATE TABLE Destinazione(
	destinazioneID INT PRIMARY KEY IDENTITY(1,1),
	codiceDes VARCHAR(50) NOT NULL,
	nome VARCHAR(250) NOT NULL,
	descrizione TEXT,
	paese VARCHAR(250) NOT NULL,
	imgURL VARCHAR(250) NOT NULL
);

 CREATE TABLE Pacchetto_Vacanza(
	pacchettoID INT PRIMARY KEY IDENTITY(1,1),
	codicePac VARCHAR(50) NOT NULL,
	nome VARCHAR(250) NOT NULL,
	prezzo DECIMAL(8,2) NOT NULL CHECK (prezzo > 0),
	durata INT DEFAULT 0,
	dataInizio DATE,
	dataFine DATE
 );

 CREATE TABLE Destinazione_Pacchetto(
	destinazione_pacchettoID INT PRIMARY KEY IDENTITY(1,1),
	destinazioneRIF INT NOT NULL,
	pacchettoRIF INT NOT NULL,
	FOREIGN KEY(destinazioneRIF) REFERENCES Destinazione(destinazioneID) ON DELETE CASCADE,
	FOREIGN KEY(pacchettoRIF) REFERENCES Pacchetto_Vacanza(pacchettoID) ON DELETE CASCADE,
	UNIQUE(destinazioneRIF, pacchettoRIF)
 );

CREATE TABLE Recensione(
	recensioneID INT PRIMARY KEY IDENTITY(1,1),
	codiceRec VARCHAR(50) NOT NULL, 
	nomeUtente VARCHAR(250) NOT NULL,
	voto INT CHECK(voto BETWEEN 1 AND 5),
	commento TEXT,
	dataRece DATE,
	pacchettoRIF INT NOT NULL,
	FOREIGN KEY(pacchettoRIF) REFERENCES Pacchetto_Vacanza(pacchettoID) ON DELETE CASCADE,
	UNIQUE(nomeUtente, pacchettoRIF)
);

-- INSERIMENTO DATI --
INSERT INTO Destinazione (codiceDes, nome, descrizione, paese, imgURL)
VALUES 
('DES001', 'Roma', 'La città eterna, ricca di storia e cultura.', 'Italia', 'https://example.com/roma.jpg'),
('DES002', 'Parigi', 'Città romantica, con la famosa Torre Eiffel.', 'Francia', 'https://example.com/parigi.jpg'),
('DES003', 'Tokyo', 'Una metropoli che fonde tradizione e modernità.', 'Giappone', 'https://example.com/tokyo.jpg'),
('DES004', 'New York', 'La città che non dorme mai, con la Statua della Libertà.', 'USA', 'https://example.com/newyork.jpg'),
('DES005', 'Sydney', 'la famosa Opera House e le sue spiagge ti aspettano.', 'Australia', 'https://example.com/sydney.jpg'),
('DES006', 'Berlino', 'Città con un ricco patrimonio storico e culturale.', 'Germania', 'https://example.com/berlino.jpg'),
('DES007', 'Londra', 'La capitale del Regno Unito, con il Big Ben e il London Eye.', 'Regno Unito', 'https://example.com/londra.jpg'),
('DES008', 'Rio de Janeiro', 'Città vibrante, famosa per il carnevale.', 'Brasile', 'https://example.com/rio.jpg'),
('DES009', 'Barcellona', 'Città famosa per la vida loca', 'Spagna', 'https://example.com/barcellona.jpg'),
('DES010', 'Atene', 'Culla della civiltà occidentale,', 'Grecia', 'https://example.com/atene.jpg'),
('DES011', 'Milano', 'Capitale della moda e del design, con il Duomo e la Galleria Vittorio Emanuele.', 'Italia', 'https://example.com/milano.jpg'),
('DES012', 'Seoul', 'Una città dinamica che fonde il moderno e il tradizionale.', 'Corea del Sud', 'https://example.com/seoul.jpg'),
('DES013', 'Pechino', 'Capitale della Cina, con la Città Proibita e la Grande Muraglia.', 'Cina', 'https://example.com/pechino.jpg');


INSERT INTO Pacchetto_Vacanza (codicePac, nome, prezzo, durata, dataInizio, dataFine)
VALUES 
('PAC001', 'Weekend Europeo', 350.50, 7, '2024-05-01', '2024-05-07'),
('PAC002', 'Settimana della moda', 1200.99, 7, '2024-06-10', '2024-06-17'),
('PAC003', 'Tokyo moderno e antico', 2000.00, 10, '2024-07-20', '2024-07-30'),
('PAC004', 'Tour di New York', 1500.75, 5, '2024-08-05', '2024-08-10'),
('PAC005', 'Vacanze Orientali', 1800.25, 8, '2024-09-01', '2024-09-09'),
('PAC006', 'Storia e cultura Europea', 900.60, 4, '2024-04-15', '2024-04-19'),
('PAC007', 'Esplora Londra', 1100.40, 5, '2024-10-10', '2024-10-15'),
('PAC008', 'Carnevale a Rio', 2500.99, 7, '2024-02-20', '2024-02-27'),
('PAC009', 'Arte e architettura Europea', 950.30, 5, '2024-03-05', '2024-03-10'),
('PAC010', 'Tour Antichità Greco Romana', 1400.50, 6, '2024-11-01', '2024-11-07');


INSERT INTO Destinazione_Pacchetto (destinazioneRIF, pacchettoRIF)
VALUES
-- 'Weekend Europeo' (PAC001) include Roma, Parigi e Milano
(1, 1),  -- Roma
(2, 1),  -- Parigi
(11, 1), -- Milano

-- 'Settimana della moda' (PAC002) include Parigi e Milano
(2, 2),  -- Parigi
(11, 2), -- Milano

-- 'Tokyo moderno e antico' (PAC003) include Tokyo e Seoul
(3, 3),  -- Tokyo

-- 'Tour di New York' (PAC004) include New York
(4, 4),  -- New York

-- 'Vacanze Orientali' (PAC005) include Sydney, Pechino, Tokyo e Seoul
(5, 5),  -- Sydney
(13, 5), -- Pechino
(3, 5),  -- Tokyo
(12, 5), -- Seoul

-- 'Storia e cultura Europea' (PAC006) include Berlino, Roma e Atene
(6, 6),  -- Berlino
(10, 6), -- Atene
(1, 6), -- Roma

-- 'Esplora Londra' (PAC007) include Londra e Barcellona
(7, 7),  -- Londra

-- 'Carnevale a Rio' (PAC008) include Rio de Janeiro
(8, 8),  -- Rio de Janeiro

-- 'Arte e architettura Europea' (PAC009) include Barcellona e Milano
(9, 9),  -- Barcellona
(11, 9), -- Milano

-- 'Tour Antichità Greco Romana' (PAC010) include Roma e Atene
(1, 10), -- Roma
(10, 10); -- Atene


INSERT INTO Recensione (codiceRec, nomeUtente, voto, commento, dataRece, pacchettoRIF)
VALUES
-- Recensioni per "Weekend Europeo" (PAC001)
('REC001', 'mariorossi', 4, 'Ottimo pacchetto per chi vuole vedere Roma, Parigi e Milano in poco tempo. Ne vale la pena!', '2024-05-10', 1),
('REC002', 'laurabianchi', 5, 'Viaggio stupendo! Tutto ben organizzato e guide professionali. Milano è stata la mia tappa preferita.', '2024-05-12', 1),

-- Recensioni per "Settimana della moda" (PAC002)
('REC003', 'giovanniferrari', 5, 'Esperienza fantastica! Parigi e Milano sono perfette per chi ama la moda.', '2024-06-20', 2),
('REC004', 'federicagallo', 4, 'Bella esperienza, ma un po costosa. Tuttavia, Milano è stata un sogno per gli appassionati di moda.', '2024-06-22', 2),

-- Recensioni per "Tokyo moderno e antico" (PAC003)
('REC005', 'antoniosantini', 5, 'Tokyo è incredibile! Un mix perfetto di tradizione e modernità. Consiglio vivamente.', '2024-08-02', 3),
('REC006', 'giuliaverdi', 4, 'Viaggio interessante, ma avrei voluto più tempo per esplorare Seoul. Tokyo comunque stupenda.', '2024-08-05', 3),

-- Recensioni per "Tour di New York" (PAC004)
('REC007', 'stefanobrunetti', 5, 'New York è la città dei miei sogni. Organizzazione impeccabile e esperienza unica.', '2024-08-15', 4),
('REC008', 'alessiabianchi', 3, 'Bellissima città, ma troppo caos e pochi momenti di relax. Preferisco viaggi più tranquilli.', '2024-08-18', 4),

-- Recensioni per "Vacanze Orientali" (PAC005)
('REC009', 'francescocosta', 5, 'Fantastico tour tra Sydney, Pechino e Tokyo. Non avrei potuto chiedere di meglio!', '2024-09-15', 5),
('REC010', 'martinavilla', 4, 'Molto bello, ma leggermente frenetico. Seoul è stata una sorpresa molto piacevole.', '2024-09-18', 5);
