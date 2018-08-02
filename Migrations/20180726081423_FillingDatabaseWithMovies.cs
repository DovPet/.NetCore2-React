using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Amidus.Migrations
{
    public partial class FillingDatabaseWithMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, Description, ReleaseDate) VALUES ('The Shawshank Redemption',(SELECT ID FROM Genres WHERE Name = 'Drama'),'Chronicles the experiences of a formerly successful banker as a prisoner in the gloomy jailhouse of Shawshank after being found guilty of a crime he did not commit. The film portrays the man`s unique way of dealing with his new, torturous life; along the way he befriends a number of fellow prisoners, most notably a wise long-term inmate named Red. Written by J-S-Golden.','1994-01-01')");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, Description, ReleaseDate) VALUES ('The Godfather',(SELECT ID FROM Genres WHERE Name = 'Drama'),'When the aging head of a famous crime family decides to transfer his position to one of his subalterns, a series of unfortunate events start happening to the family, and a war begins between all the well-known families leading to insolence, deportation, murder and revenge, and ends with the favorable successor being finally chosen. Written by J. S. Golden','1972-01-01')");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, Description, ReleaseDate) VALUES ('The Dark Knight',(SELECT ID FROM Genres WHERE Name = 'Action'),'Set within a year after the events of Batman Begins, Batman, Lieutenant James Gordon, and new district attorney Harvey Dent successfully begin to round up the criminals that plague Gotham City until a mysterious and sadistic criminal mastermind known only as the Joker appears in Gotham, creating a new wave of chaos. Batman`s struggle against the Joker becomes deeply personal, forcing him to confront everything he believes and improve his technology to stop him. A love triangle develops between Bruce Wayne, Dent and Rachel Dawes. Written by Leon Lombardi','2008-01-01')");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, Description, ReleaseDate) VALUES ('12 Angry Men',(SELECT ID FROM Genres WHERE Name = 'Comedy'),'The defense and the prosecution have rested and the jury is filing into the jury room to decide if a young man is guilty or innocent of murdering his father. What begins as an open-and-shut case of murder soon becomes a detective story that presents a succession of clues creating doubt, and a mini-drama of each of the jurors prejudices and preconceptions about the trial, the accused, and each other. Based on the play, all of the action takes place on the stage of the jury room.','1957-01-01')");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, Description, ReleaseDate) VALUES ('Inception',(SELECT ID FROM Genres WHERE Name = 'Action'),'Dom Cobb is a skilled thief, the absolute best in the dangerous art of extraction, stealing valuable secrets from deep within the subconscious during the dream state, when the mind is at its most vulnerable. Cobb`s rare ability has made him a coveted player in this treacherous new world of corporate espionage, but it has also made him an international fugitive and cost him everything he has ever loved. Now Cobb is being offered a chance at redemption. One last job could give him his life back but only if he can accomplish the impossible - inception. Instead of the perfect heist, Cobb and his team of specialists have to pull off the reverse: their task is not to steal an idea but to plant one. If they succeed, it could be the perfect crime. But no amount of careful planning or expertise can prepare the team for the dangerous enemy that seems to predict their every move. An enemy that only Cobb could have seen coming.','2010-01-01')");
            

            migrationBuilder.Sql("INSERT INTO MovieActors (MovieId, ActorId) VALUES ((SELECT ID FROM Movies WHERE Name = 'The Shawshank Redemption'),(SELECT ID FROM Actors WHERE LastName = 'Depp'))");
            migrationBuilder.Sql("INSERT INTO MovieActors (MovieId, ActorId) VALUES ((SELECT ID FROM Movies WHERE Name = 'The Shawshank Redemption'),(SELECT ID FROM Actors WHERE LastName = 'Pitt'))");
            migrationBuilder.Sql("INSERT INTO MovieActors (MovieId, ActorId) VALUES ((SELECT ID FROM Movies WHERE Name = 'The Godfather'),(SELECT ID FROM Actors WHERE LastName = 'Depp'))");
            migrationBuilder.Sql("INSERT INTO MovieActors (MovieId, ActorId) VALUES ((SELECT ID FROM Movies WHERE Name = 'The Godfather'),(SELECT ID FROM Actors WHERE LastName = 'Pitt'))");
            migrationBuilder.Sql("INSERT INTO MovieActors (MovieId, ActorId) VALUES ((SELECT ID FROM Movies WHERE Name = 'The Dark Knight'),(SELECT ID FROM Actors WHERE LastName = 'Depp'))");
            migrationBuilder.Sql("INSERT INTO MovieActors (MovieId, ActorId) VALUES ((SELECT ID FROM Movies WHERE Name = 'The Dark Knight'),(SELECT ID FROM Actors WHERE LastName = 'Pitt'))");
            migrationBuilder.Sql("INSERT INTO MovieActors (MovieId, ActorId) VALUES ((SELECT ID FROM Movies WHERE Name = 'The Dark Knight'),(SELECT ID FROM Actors WHERE LastName = 'DiCaprio'))");
            migrationBuilder.Sql("INSERT INTO MovieActors (MovieId, ActorId) VALUES ((SELECT ID FROM Movies WHERE Name = '12 Angry Men'),(SELECT ID FROM Actors WHERE LastName = 'Depp'))");
            migrationBuilder.Sql("INSERT INTO MovieActors (MovieId, ActorId) VALUES ((SELECT ID FROM Movies WHERE Name = '12 Angry Men'),(SELECT ID FROM Actors WHERE LastName = 'DiCaprio'))");
            migrationBuilder.Sql("INSERT INTO MovieActors (MovieId, ActorId) VALUES ((SELECT ID FROM Movies WHERE Name = 'Inception'),(SELECT ID FROM Actors WHERE LastName = 'Pitt'))");
            migrationBuilder.Sql("INSERT INTO MovieActors (MovieId, ActorId) VALUES ((SELECT ID FROM Movies WHERE Name = 'Inception'),(SELECT ID FROM Actors WHERE LastName = 'DiCaprio'))");
            
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
