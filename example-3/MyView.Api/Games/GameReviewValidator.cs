using FluentValidation;
using MyView.Api.Data;

namespace MyView.Api.Games;

public sealed class GameReviewValidator : AbstractValidator<GameReviewDto>
{
   public GameReviewValidator(AppDbContext context)
   {
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
