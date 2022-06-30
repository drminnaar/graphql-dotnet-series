using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using MyView.Api.Data;

namespace MyView.Api.Reviewers;

[ExtendObjectType(OperationTypeNames.Query)]
[GraphQLDescription("Queries to manage and query data")]
public class ReviewerQuery
{
   [GraphQLDescription("Get a list of reviewers")]
   [UseProjection]
   [UseFiltering]
   [UseSorting]
   public IQueryable<ReviewerDto> GetReviewers([Service] AppDbContext context) => context
      .Reviewers
      .AsNoTracking()
      .TagWith($"{nameof(ReviewerQuery)}::{nameof(GetReviewers)}")
      .Select(reviewer => new ReviewerDto
      {
         Email = reviewer.Email,
         ReviewerId = reviewer.Id.ToString(),
         Name = reviewer.Name,
         PictureUrl = reviewer.Picture,
         Username = reviewer.Username
      });
}
