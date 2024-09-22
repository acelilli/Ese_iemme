---------- QL
--Query base: Recupera tutti i membri registrati nel sistema.
SELECT * FROM Membro;

--Recupera il nome e il cognome di tutti i membri che hanno un abbonamento mensile.
SELECT nome, cognome, tipo_abbonamento FROM Membro
	JOIN Abbonamento on Membro.abbonamentoRIF = Abbonamento.abbonamentoID
WHERE abbonamentoRIF = 1

--Recupera l'elenco delle classi di yoga offerte dal centro fitness.
SELECT * FROM Classe WHERE nome LIKE 'Yoga%';

--Recupera il nome e cognome degli istruttori che insegnano Pilates.
SELECT * FROM Istruttore
WHERE specializzazione = 'Pilates';

--Recupera i dettagli delle classi programmate per il lunedì.
SELECT * FROM Classe WHERE giorno_settimana = 'lun';

--Recupera l'elenco dei membri che hanno prenotato una classe di spinning.
SELECT Classe.nome, Membro.nome, cognome FROM Membro_Classe 
	JOIN Membro ON Membro_Classe.membroRIF = Membro.membroID
	JOIN Classe ON Membro_Classe.classeRIF = Classe.classeID
WHERE classeRIF = 1002;

--Recupera tutte le attrezzature che sono attualmente fuori servizio.
SELECT * FROM Attrezzatura WHERE stato = 'non disponibile' OR stato = 'in manutenzione'

--Conta il numero di partecipanti per ciascuna classe programmata per il mercoledì.
SELECT COUNT(*) AS partecipanti_mercoledi FROM Classe 
	JOIN Membro_Classe ON Classe.classeID = Membro_Classe.classeRIF
	JOIN Membro ON Membro_Classe.membroRIF = Membro.membroID
	WHERE giorno_settimana = 'mer';

--Recupera l'elenco degli istruttori disponibili per tenere una lezione il sabato.
--//

--Recupera tutti i membri che hanno un abbonamento attivo dal 2023.
SELECT * FROM Membro 
	WHERE data_abbonamento >= '2023-01-01' AND data_abbonamento < '2024-01-01'

--Trova il numero massimo di partecipanti per tutte le classi di sollevamento pesi.
SELECT max_iscritti FROM Classe WHERE nome = 'Sollevamento Pesi'

--Recupera le prenotazioni effettuate da un membro specifico.
SELECT Membro.nome,Membro.cognome, data_prenotazione, Classe.nome FROM Membro_Classe 
	JOIN Membro ON Membro_Classe.membroRIF = Membro.membroID
	JOIN Classe ON Membro_Classe.classeRIF = Classe.classeID
WHERE membroRIF = 16;

--Recupera l'elenco degli istruttori che conducono più di 5 classi alla settimana.
SELECT Istruttore.nome, Istruttore.cognome, COUNT(istruttoreRIF) AS tot_classi FROM Istruttore_Classe 
	JOIN Istruttore ON Istruttore_Classe.istruttoreRIF = Istruttore.istruttoreID
	JOIN Classe ON Istruttore_Classe.classeRIF = Classe.classeID
	GROUP BY Istruttore.nome, Istruttore.cognome, Istruttore.istruttoreID
HAVING COUNT(istruttoreRIF) >=5

--Recupera le classi che hanno ancora posti disponibili per nuove prenotazioni.
--Recupera l'elenco dei membri che hanno annullato una prenotazione negli ultimi 30 giorni.
--Recupera tutte le attrezzature acquistate prima del 2022.
--Recupera l'elenco dei membri che hanno prenotato una classe in cui l'istruttore è "Mario Rossi".
SELECT Membro.nome, Membro.cognome, data_prenotazione FROM Istruttore_Classe 
	JOIN Classe ON Istruttore_Classe.classeRIF = Classe.classeID
	JOIN Membro_Classe ON Istruttore_Classe.classeRIF = Membro_Classe.classeRIF
	JOIN Membro ON Membro_Classe.membroRIF = Membro.membroID
WHERE istruttoreRIF = 3;

--Calcola il numero totale di prenotazioni per ogni classe per un determinato periodo di tempo.
SELECT * FROM Membro_Classe 
WHERE data_prenotazione = '2024-05-01'

--Trova tutte le classi associate a un'istruttore specifico e i membri che vi hanno partecipato.
SELECT Istruttore.nome, Istruttore.cognome, Classe.nome, Classe.giorno_settimana, Membro.nome, Membro.cognome FROM Istruttore
	JOIN Istruttore_Classe ON Istruttore.istruttoreID = Istruttore_Classe.istruttoreRIF
	JOIN Classe ON Istruttore_Classe.classeRIF = Classe.classeID
	JOIN Membro_Classe ON Classe.classeID = Membro_Classe.classeRIF
	JOIN Membro ON Membro_Classe.membroRIF = Membro.membroID
WHERE Istruttore.nome = 'Andrea' AND Istruttore.cognome = 'Verdi';

--Recupera tutte le attrezzature in manutenzione e il nome degli istruttori che le utilizzano nelle loro classi.
