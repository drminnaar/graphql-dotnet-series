using System;
using HotChocolate;

namespace MyView.Api.Games;

[GraphQLDescription("Game review information")]
[GraphQLName("GameReview")]
public sealed record GameReviewDto
{
   [GraphQLDescription("Game identifier")]
   public Guid GameId { get; set; }

   [GraphQLDescription("Reviewer identifier")]
   public Guid ReviewerId { get; set; }

   [GraphQLDescription("Game rating")]
   public int Rating { get; set; }

   [GraphQLDescription("A brief description of game experience")]
   public string Summary { get; set; } = string.Empty;
}
