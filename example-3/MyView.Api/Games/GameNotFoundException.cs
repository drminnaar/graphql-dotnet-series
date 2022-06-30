using System;
using System.Runtime.Serialization;

namespace MyView.Api.Games;

[Serializable]
public class GameNotFoundException : Exception
{
   public GameNotFoundException() { }
   public GameNotFoundException(string message) : base(message) { }
   public GameNotFoundException(string message, Exception inner) : base(message, inner) { }
   protected GameNotFoundException(
      SerializationInfo info,
      StreamingContext context) : base(info, context) { }

   public Guid GameId { get; set; }

   public static GameNotFoundException WithGameId(Guid gameId)
      => new GameNotFoundException { GameId = gameId };
}
