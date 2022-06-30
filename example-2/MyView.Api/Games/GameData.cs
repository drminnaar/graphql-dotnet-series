using System;
using System.Collections.Generic;
using System.Linq;

namespace MyView.Api.Games;

internal static class GameData
{
   static GameData()
   {
      Games = GenerateFakeData().ToList();
   }

   public static readonly List<GameDto> Games;

   private static IEnumerable<GameDto> GenerateFakeData()
   {
      yield return new GameDto
      {
         GameId = Guid.Parse("8f7e254f-a6ce-4f13-a44c-8f102a17f2f5"),
         Title = "Gears Of War",         
         Summary = "Do labore laborum minim ad. Occaecat sint culpa aliqua enim. Fugiat deserunt ut occaecat do elit do ut amet officia veniam enim sint reprehenderit elit.",
         ReleasedOn = DateTime.Parse("Sun Aug 29 2021"),
         Reviews = new List<GameReviewDto>()
         {
            new GameReviewDto
            {
               GameId = Guid.Parse("8f7e254f-a6ce-4f13-a44c-8f102a17f2f5"),
               ReviewerId = Guid.Parse("8b019864-4af2-4606-88b5-13e5eb62ff4f"),
               Rating = 95,
               Summary = "At quas voluptatem."
            },
            new GameReviewDto
            {
               GameId = Guid.Parse("8f7e254f-a6ce-4f13-a44c-8f102a17f2f5"),
               ReviewerId = Guid.Parse("0969af61-7e22-4b68-8246-b60b225b644a"),
               Rating = 98,
               Summary = "A ab illum asperiores. Deleniti sit quod sed autem similique eveniet."
            }
         }
      };

      yield return new GameDto
      {
         GameId = Guid.Parse("4edc4b67-a1bf-4031-9aa9-0933cb3ae14a"),
         Title = "Halo",
         Summary = "Magna aliqua minim voluptate eu. Pariatur ad incididunt elit ex elit amet Lorem ad tempor pariatur. Pariatur elit sunt tempor non. Excepteur magna dolore eiusmod duis qui elit cillum qui minim aliqua id.",
         ReleasedOn = DateTime.Parse("Sun Feb 20 2022"),
         Reviews = new List<GameReviewDto>()
         {
            new GameReviewDto
            {
               GameId = Guid.Parse("4edc4b67-a1bf-4031-9aa9-0933cb3ae14a"),
               ReviewerId = Guid.Parse("8b019864-4af2-4606-88b5-13e5eb62ff4f"),
               Rating = 90,
               Summary = "At quas voluptatem."
            },
            new GameReviewDto
            {
               GameId = Guid.Parse("4edc4b67-a1bf-4031-9aa9-0933cb3ae14a"),
               ReviewerId = Guid.Parse("0969af61-7e22-4b68-8246-b60b225b644a"),
               Rating = 85,
               Summary = "A ab illum asperiores. Deleniti sit quod sed autem similique eveniet."
            }
         }
      };

      yield return new GameDto
      {
         GameId = Guid.Parse("67b5e6e6-7811-4c01-8b82-eb6e733904bc"),
         Title = "Unchartered 4 : A Thiefs End",
         Summary = "Do amet commodo officia veniam exercitation fugiat deserunt dolor voluptate ullamco consequat proident sit. Aliquip culpa reprehenderit laborum amet aliquip amet deserunt velit. Nisi ad adipisicing aliqua et excepteur non labore sit ex deserunt ex aliqua ad. Dolor nostrud labore aute minim nulla ullamco qui. Dolor duis occaecat culpa duis anim aute cillum ut. Sint cillum reprehenderit laborum minim elit quis adipisicing proident consectetur enim aute. Eiusmod do duis do mollit commodo aliqua sint ad.",
         ReleasedOn = DateTime.Parse("Mon Feb 21 2022"),
         Reviews = new List<GameReviewDto>()
         {
            new GameReviewDto
            {
               GameId = Guid.Parse("67b5e6e6-7811-4c01-8b82-eb6e733904bc"),
               ReviewerId = Guid.Parse("8b019864-4af2-4606-88b5-13e5eb62ff4f"),
               Rating = 90,
               Summary = "At quas voluptatem."
            },
         }
      };

      yield return new GameDto
      {
         GameId = Guid.Parse("c7086716-a9f3-4a37-a1fa-95681b11e9e0"),
         Title = "Warcraft 3 : Reign Of Chaos ",
         Summary = "Dolore consectetur ipsum ipsum reprehenderit in deserunt ut. Culpa magna aliqua eu amet nulla officia aliquip eu nostrud est fugiat. Id labore culpa et consectetur Lorem. Elit laborum ullamco incididunt nisi cupidatat eiusmod.",
         ReleasedOn = DateTime.Parse("Thu Sep 23 2021"),
         Reviews = new List<GameReviewDto>()
         {
            new GameReviewDto
            {
               GameId = Guid.Parse("c7086716-a9f3-4a37-a1fa-95681b11e9e0"),
               ReviewerId = Guid.Parse("0969af61-7e22-4b68-8246-b60b225b644a"),
               Rating = 100,
               Summary = "A ab illum asperiores. Deleniti sit quod sed autem similique eveniet."
            }
         }
      };
   }
}
