USE Filmer;

--SELECT * FROM Filmer;


--SELECT * from Filmer
--WHERE År > 2000 AND Titel Like 'Star Wars%'
--ORDER BY År Asc;

SELECT FilmID id FROM Filmer
WHERE Genre = 'Comedy' AND Regissör = 'Steven Spielberg' AND År > 2000;

