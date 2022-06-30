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
         // configure table
         game.ToTable(nameof(Game).ToLower());

         // configure properties
         game.Property(e => e.Id).HasColumnName("id");
         game.Property(e => e.ReleasedOn).HasColumnName("released_on").IsRequired();
         game.Property(e => e.Summary).HasColumnName("summary").IsRequired();
         game.Property(e => e.Title).HasColumnName("title").IsRequired();

         // configure primary key
         game.HasKey(e => e.Id).HasName("pk_game_id");

         // configure game relationship
         game.HasMany(e => e.Reviews).WithOne(e => e.Game);
      });

      modelBuilder.Entity<Reviewer>(reviewer =>
      {
         // configure table
         reviewer.ToTable(nameof(Reviewer).ToLower());

         // configure properties
         reviewer.Property(e => e.Id).HasColumnName("id");
         reviewer.Property(e => e.Email).HasColumnName("email").IsRequired();
         reviewer.Property(e => e.Name).HasColumnName("name").IsRequired();
         reviewer.Property(e => e.Picture).HasColumnName("picture").IsRequired();
         reviewer.Property(e => e.Username).HasColumnName("username").IsRequired();

         // configure primary key
         reviewer.HasKey(e => e.Id).HasName("pk_reviewer_id");

         // configure reviewer relationship
         reviewer.HasMany(e => e.GameReviews).WithOne(e => e.Reviewer);
      });

      modelBuilder.Entity<GameReview>(gameReview =>
      {
         // configure table
         gameReview.ToTable("game_review");

         // configure properties
         gameReview.Property(e => e.GameId).HasColumnName("game_id").IsRequired();
         gameReview.Property(e => e.ReviewerId).HasColumnName("reviewer_id").IsRequired();
         gameReview.Property(e => e.Rating).HasColumnName("rating").IsRequired();
         gameReview.Property(e => e.ReviewedOn).HasColumnName("reviewed_on").IsRequired();
         gameReview.Property(e => e.Summary).HasColumnName("summary").HasDefaultValue("");

         // configure primary key
         gameReview
            .HasKey(e => new { e.GameId, e.ReviewerId })
            .HasName("pk_gamereview_gameidreviewerid");

         // configure game relationship
         gameReview
            .HasOne(e => e.Game)
            .WithMany(e => e.Reviews)
            .HasConstraintName("fk_gamereview_gameid");

         gameReview
            .HasIndex(e => e.GameId)
            .HasDatabaseName("ix_gamereview_gameid");

         // configure reviewer relationship
         gameReview
            .HasOne(e => e.Reviewer)
            .WithMany(e => e.GameReviews)
            .HasConstraintName("fk_gamereview_reviewerid");

         gameReview
            .HasIndex(e => e.ReviewerId)
            .HasDatabaseName("ix_gamereview_reviewerid");
      });

      base.OnModelCreating(modelBuilder);
   }
}
