using DataLayer;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

IFilmRepository repo = 
    new FilmRepository("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Filmer;Integrated Security=True");

//var filmer = repo.GetAll();

//foreach (var film in filmer)
//{
//    Console.WriteLine(film.Titel);
//}

var film = new Film
{
    Titel = "The Matrix",
    Regissör = "Wachowski",
    Genre = "Sci-fi",
    År = 1999
};

repo.Add(film);

Console.WriteLine($"La till filmen {film.Titel}");

film.Titel = "The Matrix Reloaded";
repo.Update(film);

Console.WriteLine($"Uppdaterade filmen till {film.Titel}");

var film2 = repo.Get(film.FilmId);
Console.WriteLine($"Filmen {film2.Titel} finns i databasen");

var success = repo.Delete(film.FilmId);

if (success)
{
    Console.WriteLine($"Raderade filmen {film.Titel}");
}
else
{
    Console.WriteLine($"Kunde inte radera filmen {film.Titel}");
}

success = repo.Delete(film.FilmId);

if (success)
{
    Console.WriteLine($"Raderade filmen {film.Titel}");
}
else
{
    Console.WriteLine($"Kunde inte radera filmen {film.Titel}");
}

