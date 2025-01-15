using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient 
{
    private readonly Genre[] genres =
    [
        new () {
            ID = 1,
            Name = "JRPG"
        },
        new () {
            ID = 2,
            Name = "Fighting"
        },
        new () {
            ID = 3,
            Name = "Adventure"
        },
        new () {
            ID = 4,
            Name = "Sports"
        },
        new () {
            ID = 5,
            Name = "Family"
        }
    ];

    public Genre[] GetGenres() => genres;
}