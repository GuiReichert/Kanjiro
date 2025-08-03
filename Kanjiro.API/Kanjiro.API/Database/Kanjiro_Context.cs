using Kanjiro.API.Enums;
using Kanjiro.API.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace Kanjiro.API.Database
{
    public class Kanjiro_Context : DbContext
    {

        public Kanjiro_Context(DbContextOptions<Kanjiro_Context> db) : base(db)
        {
            
        }

        public DbSet<User> Users {get;set; }
        public DbSet<Deck> Decks {get;set; }
        public DbSet<Card> Cards {get;set; }   
        public DbSet<CardInfo> CardInfos {get;set; }
    }
}
