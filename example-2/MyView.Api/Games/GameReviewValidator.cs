using System.Linq;
using FluentValidation;

namespace MyView.Api.Games;

public sealed class GameReviewValidator : AbstractValidator<GameReviewDto>
{
   public GameReviewValidator()
   {
      RuleFor(e => e.GameId)
         .Must(gameId => GameData.Games.Any(game => game.GameId == gameId))
         .WithMessage(e => $"A game having id '{e.GameId}' does not exist");

      RuleFor(e => e.Rating)
      .LessThanOrEqualTo(100)
      .GreaterThanOrEqualTo(0);

      RuleFor(e => e.Summary)
         .NotNull()
         .NotEmpty()
         .MinimumLength(20)
         .MaximumLength(500);
   }
}
