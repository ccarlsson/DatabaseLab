using Dapper;
using System.Data;
using System.Data.SqlClient;


namespace DataLayer;

public interface IFilmRepository
{
    Film Add(Film film);
    Film? Get(int id);
    IEnumerable<Film> GetAll();
    Film Update(Film film);
    bool Delete(int id);
}

public class FilmRepository(string connectionString) : IFilmRepository
{
    private IDbConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    // Create
    public Film Add(Film film)
    {
        using var connection = GetConnection();

        var sql = "INSERT INTO Filmer (Titel, Regissör, Genre, År) VALUES (@Titel, @Regissör, @Genre, @År);"
            + "SELECT CAST(SCOPE_IDENTITY() as int)";

        var id = connection.Query<int>(sql, film).Single();

        film.FilmId = id;
        return film;
    }

    // Read
    public Film? Get(int id)
    {
        using var connection = GetConnection();
        return connection.Query<Film>("SELECT * FROM Filmer WHERE FilmId = @Id", new { id }).SingleOrDefault();
    }

    public IEnumerable<Film> GetAll()
    {
        using var connection = GetConnection();
        return connection.Query<Film>("SELECT * FROM Filmer");
    }

    // Update   
    public Film Update(Film film)
    {
        using var connection = GetConnection();
        var sql = "UPDATE Filmer SET Titel = @Titel, Regissör = @Regissör, Genre = @Genre, År = @År WHERE FilmId = @FilmId";
        connection.Execute(sql, film);
        return film;
    }

    // Delete
    public bool Delete(int id)
    {
        using var connection = GetConnection();
        var sql = "DELETE FROM Filmer WHERE FilmId = @Id";
        var affectedRows = connection.Execute(sql, new { id });
        return affectedRows > 0;
    }
}

