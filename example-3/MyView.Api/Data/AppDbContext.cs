using Microsoft.EntityFrameworkCore;

namespace MyView.Api.Data;

public sealed class AppDbContext : DbContext
{
   public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
   {
   }

   public DbSet<Game> Games { get; set; } = null!;
   public DbSet<GameReview> Reviews { get; set; } = null!;
   public DbSet<Reviewer> Reviewers { get; set; } = null!;

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<Game>(game =>
      {
         // configure properties
         game.Property(e => e.ReleasedOn).IsRequired();
         game.Property(e => e.Summary).IsRequired();
         game.Property(e => e.Title).IsRequired();

         // configure primary key
         game.HasKey(e => e.Id);

         // configure game relationship
         game.HasMany(e => e.Reviews).WithOne(e => e.Game);
      });

      modelBuilder.Entity<Reviewer>(reviewer =>
      {
         // configure properties
         reviewer.Property(e => e.Email).IsRequired();
         reviewer.Property(e => e.Name).IsRequired();
         reviewer.Property(e => e.Picture).IsRequired();
         reviewer.Property(e => e.Username).IsRequired();

         // configure primary key
         reviewer.HasKey(e => e.Id);

         // configure reviewer relationship
         reviewer.HasMany(e => e.GameReviews).WithOne(e => e.Reviewer);
      });

      modelBuilder.Entity<GameReview>(gameReview =>
      {
         // configure properties
         gameReview.Property(e => e.GameId).IsRequired();
         gameReview.Property(e => e.ReviewerId).IsRequired();
         gameReview.Property(e => e.Rating).IsRequired();
         gameReview.Property(e => e.ReviewedOn).IsRequired();
         gameReview.Property(e => e.Summary).IsRequired();

         // configure primary key
         gameReview.HasKey(e => new { e.GameId, e.ReviewerId });

         // configure game relationship
         gameReview.HasOne(e => e.Game).WithMany(e => e.Reviews);

         gameReview.HasIndex(e => e.GameId);

         // configure reviewer relationship
         gameReview.HasOne(e => e.Reviewer).WithMany(e => e.GameReviews);

         gameReview.HasIndex(e => e.ReviewerId);
      });

      base.OnModelCreating(modelBuilder);
   }
}
