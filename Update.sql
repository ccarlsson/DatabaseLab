USE Filmer;

--UPDATE Filmer
--SET Genre = 'Sci-Fi'
--WHERE Titel = 'Star wars';

UPDATE Filmer
SET År = År + 10
WHERE År < 2000;