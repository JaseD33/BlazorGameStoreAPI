using GameStore.Frontend.Models;
namespace GameStore.Frontend.Clients;

public class GamesClient {
    
    private readonly List<GameSummary> games = 
    [
        new() {
            ID = 1,
            Name = "Persona 5",
            Genre = "JRPG",
            Price = 29.99M,
            ReleaseDate = new DateOnly(2016, 8, 15)
        },
        new() {
            ID = 2,
            Name = "Final Fantasy XIV",
            Genre = "Adventure",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2010, 9, 30)
        },
        new() {
            ID = 3,
            Name = "FIFA 23",
            Genre = "Sports",
            Price = 69.99M,
            ReleaseDate = new DateOnly(2022, 9, 27)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreByID(game.GenreID);

        var gameSummary = new GameSummary
        {
            ID = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }


    public GameDetails GetGame(int ID)
    {
        GameSummary? game = GetGameSummaryByID(ID);

        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            ID = game.ID,
            Name = game.Name,
            GenreID = genre.ID.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreByID(updatedGame.GenreID);
        GameSummary existingGame = GetGameSummaryByID(updatedGame.ID);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int ID)
    {
        var game = GetGameSummaryByID(ID);
        games.Remove(game);
    }

    private GameSummary GetGameSummaryByID(int ID)
    {
        GameSummary? game = games.Find(game => game.ID == ID);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreByID(string? ID)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(ID);
        return genres.Single(genre => genre.ID == int.Parse(ID));
    }
}