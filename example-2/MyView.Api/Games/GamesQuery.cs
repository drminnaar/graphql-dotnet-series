using System;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;

namespace MyView.Api.Games;

[GraphQLDescription("Query games")]
public sealed class GamesQuery
{
   [GraphQLDescription("Get list of games")]
   public IEnumerable<GameDto> GetGames() => GameData.Games;

   [GraphQLDescription("Find game by id")]
   public GameDto? FindGameById(Guid gameId) =>
      GameData.Games.FirstOrDefault(game => game.GameId == gameId);
}
