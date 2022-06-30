using System;
using System.Collections.Generic;
using HotChocolate;

namespace MyView.Api.Games;

[GraphQLDescription("Basic game information")]
[GraphQLName("Game")]
public sealed record GameDto
{
   public GameDto()
   {
      Reviews = new List<GameReviewDto>();
   }

   [GraphQLDescription("A unique game identifier")]
   public Guid GameId { get; set; }

   [GraphQLDescription("A brief description of game")]
   public string Summary { get; set; } = string.Empty;

   [GraphQLDescription("The name of the game")]
   public string Title { get; set; } = string.Empty;

   [GraphQLDescription("The date that game was released")]
   public DateTime ReleasedOn { get; init; }

   [GraphQLDescription("A list of game reviews")]
   public ICollection<GameReviewDto> Reviews { get; set; } = new List<GameReviewDto>();
}
