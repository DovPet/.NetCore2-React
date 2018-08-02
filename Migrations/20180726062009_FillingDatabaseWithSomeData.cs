using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Amidus.Migrations
{
    public partial class FillingDatabaseWithSomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres (Name, Description) VALUES ('Drama','Within film, television and radio (but not theatre), drama is a genre of narrative fiction (or semi-fiction) intended to be more serious than humorous in tone,[2] focusing on in-depth development of realistic characters who must deal with realistic emotional struggles. A drama is commonly considered the opposite of a comedy, but may also be considered separate from other works of some broad genre, such as a fantasy.')");
            migrationBuilder.Sql("INSERT INTO Genres (Name, Description) VALUES ('Action','An action story is similar to adventure, and the protagonist usually takes a risky turn, which leads to desperate situations (including explosions, fight scenes, daring escapes, etc.). Action and Adventure are usually categorized together (sometimes even as action-adventure) because they have much in common, and many stories fall under both genres simultaneously (for instance, the James Bond series can be classified as both).')");
            migrationBuilder.Sql("INSERT INTO Genres (Name, Description) VALUES ('Comedy','Comedy is a story that tells about a series of funny, or comical events, intended to make the audience laugh. It is a very open genre, and thus crosses over with many other genres on a frequent basis.')");

            migrationBuilder.Sql("INSERT INTO Actors (FirstName, LastName, Description) VALUES ('Brad','Pitt','An actor and producer known as much for his versatility as he is for his handsome face, Golden Globe-winner Brad Pitt`s most widely recognized role may be Tyler Durden in Fight Club (1999). However, his portrayals of Billy Beane in Moneyball (2011), and Rusty Ryan in the remake of Ocean`s Eleven (2001) and its sequels, also loom large in his filmography.')");
            migrationBuilder.Sql("INSERT INTO Actors (FirstName, LastName, Description) VALUES ('Johnny','Depp','Johnny Depp is perhaps one of the most versatile actors of his day and age in Hollywood. He was born John Christopher Depp II in Owensboro, Kentucky, on June 9, 1963, to Betty Sue (Wells), who worked as a waitress, and John Christopher Depp, a civil engineer. Depp was raised in Florida. He dropped out of school when he was 15, and fronted a series of music-garage bands, including one named The Kids. However, it was when he married Lori Anne Allison (Lori A. Depp) that he took up the job of being a ballpoint-pen salesman to support himself and his wife. A visit to Los Angeles, California, with his wife, however, happened to be a blessing in disguise, when he met up with actor Nicolas Cage, who advised him to turn to acting, which culminated in Depp`s film debut in the low-budget horror film, A Nightmare on Elm Street (1984), where he played a teenager who falls prey to dream-stalking demon Freddy Krueger')");
            migrationBuilder.Sql("INSERT INTO Actors (FirstName, LastName, Description) VALUES ('Leonardo','DiCaprio','Few actors in the world have had a career quite as diverse as Leonardo DiCaprio`s. DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains (1985) and low budget horror movies, such as Critters 3 (1991), to a major teenage heartthrob in the 1990s, as the hunky lead actor in movies such as Romeo + Juliet (1996) and Titanic (1997), to then become a leading man in Hollywood blockbusters, made by internationally renowned directors such as Martin Scorsese and Christopher Nolan.')");
        
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql("DELETE FROM Genres WHERE Name IN ('Drama', 'Action', 'Comedy')");
           migrationBuilder.Sql("DELETE FROM Actors WHERE LastName IN ('Pitt', 'Depp', 'DiCaprio')");

           
        }
    }
}
