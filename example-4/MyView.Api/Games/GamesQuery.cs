using System;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using MyView.Api.Data;

namespace MyView.Api.Games;

[ExtendObjectType(OperationTypeNames.Query)]
[GraphQLDescription("Query games")]
public sealed class GamesQuery
{
   [GraphQLDescription("Get list of games")]
   [UsePaging]
   [UseProjection]
   [UseFiltering]
   [UseSorting]
   public IQueryable<GameDto> GetGames([Service] AppDbContext context)
   {
      return context
         .Games
         .AsNoTracking()
         .TagWith($"{nameof(GamesQuery)}::{nameof(GetGames)}")
         .OrderByDescending(game => game.ReleasedOn)
         .Include(game => game.Reviews)
         .Select(game => new GameDto
         {
            GameId = game.Id,
            Reviews = game.Reviews.Select(review => new GameReviewDto
            {
               GameId = review.GameId,
               Rating = review.Rating,
               ReviewerId = review.ReviewerId,
               Summary = review.Summary
            }),
            ReleasedOn = game.ReleasedOn,
            Summary = game.Summary,
            Title = game.Title
         });
   }

   [GraphQLDescription("Find game by id")]
   public async Task<GameDto?> FindGameById([Service] AppDbContext context, Guid gameId)
   {
      var game = await context
         .Games
         .AsNoTracking()
         .TagWith($"{nameof(GamesQuery)}::{nameof(FindGameById)}")
         .Include(game => game.Reviews)
         .FirstOrDefaultAsync(game => game.Id == gameId);

      if (game is null) return null;

      return new GameDto
      {
         GameId = game.Id,
         Reviews = game.Reviews.Select(review => new GameReviewDto
         {
            GameId = review.GameId,
            Rating = review.Rating,
            ReviewerId = review.ReviewerId,
            Summary = review.Summary
         }),
         ReleasedOn = game.ReleasedOn,
         Summary = game.Summary,
         Title = game.Title
      };
   }
}
