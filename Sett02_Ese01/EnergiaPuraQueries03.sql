--Crea una view che mostra l'elenco completo dei membri con il loro nome, cognome e tipo di abbonamento.
--CREATE VIEW MembriRegistrati AS
--	SELECT Membro.nome + ' ' + cognome AS nominativo, Abbonamento.tipo_abbonamento AS abbonamento
--	FROM Membro
--	JOIN Abbonamento ON Membro.abbonamentoRIF = Abbonamento.abbonamentoID;

--Crea una view che elenca tutte le classi disponibili con i rispettivi nomi degli istruttori.
--CREATE VIEW ClassiPalestra AS
--	SELECT Classe.nome AS nome_classe, Istruttore.nome + ' ' + Istruttore.cognome AS istruttore_nominativo
--	FROM Classe
--	JOIN Istruttore_Classe ON Classe.classeID = Istruttore_Classe.classeRIF
--	JOIN Istruttore ON Istruttore_Classe.istruttoreRIF = Istruttore.istruttoreID

--Crea una view che mostra le classi prenotate dai membri insieme al nome della classe e alla data di prenotazione.
--Crea una view che elenca tutte le attrezzature attualmente disponibili, con la descrizione e lo stato.
--Crea una view che mostra i membri che hanno prenotato una classe di spinning negli ultimi 30 giorni.
--Crea una view che elenca gli istruttori con il numero totale di classi che conducono.
--Crea una view che mostri il nome delle classi e il numero di partecipanti registrati per ciascuna classe.
--Crea una view che elenca i membri che hanno un abbonamento attivo insieme alla data di inizio e la data di scadenza.
--Crea una view che mostra l'elenco degli istruttori che conducono classi il luned� e il venerd�.
--Crea una view che elenca tutte le attrezzature acquistate nel 2023 insieme al loro stato attuale.
