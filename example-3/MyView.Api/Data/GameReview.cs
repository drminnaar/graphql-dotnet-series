using System;

namespace MyView.Api.Data;

public sealed class GameReview
{
   public Guid GameId { get; set; }
   public Game? Game { get; set; }
   public Guid ReviewerId { get; set; }
   public Reviewer? Reviewer { get; set; }
   public int Rating { get; set; }
   public string Summary { get; set; } = string.Empty;
   public DateTime ReviewedOn { get; set; }
}
