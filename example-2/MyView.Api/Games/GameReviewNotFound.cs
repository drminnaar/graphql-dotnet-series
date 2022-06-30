using System;
using System.Runtime.Serialization;

namespace MyView.Api.Games;

[Serializable]
public class GameReviewNotFoundException : Exception
{
   public GameReviewNotFoundException() { }
   public GameReviewNotFoundException(string message) : base(message) { }
   public GameReviewNotFoundException(string message, Exception inner) : base(message, inner) { }
   protected GameReviewNotFoundException(
      SerializationInfo info,
      StreamingContext context) : base(info, context) { }

   public Guid GameId { get; set; }
   public Guid ReviewerId { get; set; }

   internal static GameReviewNotFoundException WithGameReviewId(Guid gameId, Guid reviewerId) =>
      new GameReviewNotFoundException { GameId = gameId, ReviewerId = reviewerId };
}
