using System;
using System.Threading.Tasks;
using FluentValidation;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using MyView.Api.Data;

namespace MyView.Api.Games;

[GraphQLDescription("Manage games")]
public sealed class GamesMutation
{
   private readonly AbstractValidator<GameReviewDto> _validator;

   public GamesMutation(AbstractValidator<GameReviewDto> validator)
   {
      _validator = validator ?? throw new ArgumentNullException(nameof(validator));
   }

   [GraphQLDescription("Submit a game review")]
   public async Task<GameReviewDto> SubmitGameReview([Service] AppDbContext context, GameReviewDto gameReview)
   {
      // use fluent validator
      await _validator.ValidateAndThrowAsync(gameReview);

      var game = await context
         .Games
         .FirstOrDefaultAsync(game => game.Id == gameReview.GameId)
         ?? throw GameNotFoundException.WithGameId(gameReview.GameId);
      
      var reviewer = await context
         .Reviewers
         .FirstOrDefaultAsync(reviewer => reviewer.Id == gameReview.ReviewerId)
         ?? throw ReviewerNotFoundException.WithReviewerId(gameReview.ReviewerId);

      var gameReviewFromDb = await context
         .Reviews
         .FirstOrDefaultAsync(review => review.GameId == gameReview.GameId && review.ReviewerId == gameReview.ReviewerId);

      if (gameReviewFromDb is null)
      {
         context.Reviews.Add(new GameReview
         {
            GameId = gameReview.GameId,
            Rating = gameReview.Rating,
            ReviewedOn = DateTime.UtcNow,
            ReviewerId = gameReview.ReviewerId,
            Summary = gameReview.Summary
         });
      }
      else
      {
         gameReviewFromDb.Rating = gameReview.Rating;
         gameReviewFromDb.Summary = gameReview.Summary;
      }

      await context.SaveChangesAsync();

      return gameReview;
   }

   [GraphQLDescription("Remove a game review")]
   public async Task<GameReviewDto> DeleteGameReview(
      [Service] AppDbContext context,
      Guid gameId,
      Guid reviewerId)
   {
      var gameReviewFromDb = await context
         .Reviews
         .FirstOrDefaultAsync(review => review.GameId == gameId && review.ReviewerId == reviewerId)
         ?? throw GameReviewNotFoundException.WithGameReviewId(gameId, reviewerId);

      context.Reviews.Remove(gameReviewFromDb);

      return new GameReviewDto
      {
         GameId = gameReviewFromDb.GameId,
         Rating = gameReviewFromDb.Rating,
         ReviewerId = gameReviewFromDb.ReviewerId,
         Summary = gameReviewFromDb.Summary
      };
   }
}
