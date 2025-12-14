using Kanjiro.API.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace Kanjiro.API.Database
{
    public class Kanjiro_Context : DbContext
    {

        public Kanjiro_Context(DbContextOptions<Kanjiro_Context> db) : base(db)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardInfo> CardInfos { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Log>().Property(x => x.Origin).HasConversion<string>();
            modelBuilder.Entity<Log>().Property(x => x.Type).HasConversion<string>();
            modelBuilder.Entity<User>().Property(x => x.AccountType).HasConversion<string>();
        }
    }
}
