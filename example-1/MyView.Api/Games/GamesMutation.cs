using System;
using System.Linq;
using HotChocolate;

namespace MyView.Api.Games;

[GraphQLDescription("Manage games")]
public sealed class GamesMutation
{
   [GraphQLDescription("Submit a game review")]
   public GameReviewDto SubmitGameReview(GameReviewDto gameReview)
   {
      var game = GameData
         .Games
         .FirstOrDefault(game => game.GameId == gameReview.GameId)
         ?? throw new Exception("Game not found");

      var gameReviewFromDb = game.Reviews.FirstOrDefault(review =>
         review.GameId == gameReview.GameId && review.ReviewerId == gameReview.ReviewerId);

      if (gameReviewFromDb is null)
      {
         game.Reviews.Add(gameReview);
      }
      else
      {
         gameReviewFromDb.Rating = gameReview.Rating;
         gameReviewFromDb.Summary = gameReview.Summary;
      }

      return gameReview;
   }

   [GraphQLDescription("Remove a game review")]
   public GameReviewDto DeleteGameReview(Guid gameId, Guid reviewerId)
   {
      var game = GameData
         .Games
         .FirstOrDefault(game => game.GameId == gameId)
         ?? throw new Exception("Game not found");

      var gameReviewFromDb = game
         .Reviews
         .FirstOrDefault(review => review.GameId == gameId && review.ReviewerId == reviewerId)
         ?? throw new Exception("Game review not found");

      game.Reviews.Remove(gameReviewFromDb);

      return gameReviewFromDb;
   }
}
