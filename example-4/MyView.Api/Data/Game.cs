using System;
using System.Collections.Generic;
using HotChocolate.Data;

namespace MyView.Api.Data;

public class Game
{
   public Guid Id { get; set; }
   public string Title { get; set; } = string.Empty;
   public string Summary { get; set; } = string.Empty;
   public DateTime ReleasedOn { get; set; }

   [UseFiltering]
   [UseSorting]
   public ICollection<GameReview> Reviews { get; set; } = new HashSet<GameReview>();
}
