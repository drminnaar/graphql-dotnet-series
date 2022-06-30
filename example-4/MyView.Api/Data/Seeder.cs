using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MyView.Api.Data;

internal static class Seeder
{
   public static async Task SeedDatabase(WebApplication app)
   {
      await using (var serviceScope = app.Services.CreateAsyncScope())
      {
         var context = serviceScope
            .ServiceProvider
            .GetRequiredService<AppDbContext>();

         await context.Database.EnsureCreatedAsync();

         if (!await context.Reviewers.AnyAsync())
         {
            var reviewers = JsonSerializer.Deserialize<IEnumerable<Reviewer>>(
               _reviewersText,
               new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

            context.AddRange(reviewers);
         }

         if (!await context.Games.AnyAsync())
         {
            var games = JsonSerializer.Deserialize<IEnumerable<Game>>(
               _gamesText,
               new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

            context.Games.AddRange(games);
         }

         await context.SaveChangesAsync();
      }
   }

   private static readonly string _gamesText = @"
      [
         {
            ""id"": ""0A675A8A-210E-41EC-BF61-6FEDAEACC955"",
            ""title"": ""Gears Of War"",
            ""summary"": ""Gears of War blends tactical action with survival horror and thrusts gamers into a deep and harrowing story of humankind's epic battle for survival against the Locust Horde, a nightmarish race of creatures that surface from the bowels of the planet. Lead war hero Marcus Fenix and his fire team as they face the onslaught of merciless warrior fiends. A revolutionary tactical combat system and breathtaking, high-definition visuals from the Unreal Engine 3 immerse you in a horrifying story of war and survival. A.I. teammates are indiscernable from human players. Voice recognition and real-time lip synching heighten the experience. The battlefield is a lethal place. To survive, suppress your enemy with blindfire, take cover in interactive environments, or use weapons and teammates to outwit your foes"",
            ""releasedOn"": ""2006-11-07T00:00:00""
         },
         {
            ""id"": ""32E615BF-C33D-410F-9F62-02012F595FDC"",
            ""title"": ""Halo 3"",
            ""summary"": ""Halo 3 is the third game in the Halo Trilogy and provides the thrilling conclusion to the events begun in 'Halo: Combat Evolved' Halo 3 picks up where 'Halo 2' left off. The Master Chief is returning to Earth to finish the fight. The Covenant occupation of Earth has uncovered a massive and ancient object beneath the African sands - an object who's secrets have yet to be revealed. Earth's forces are battered and beaten. The Master Chief's AI companion Cortana is still trapped in the clutches of the Gravemind - a horrifying Flood intelligence, and a civil war is raging in the heart of the Covenant. This is how the world ends."",
            ""releasedOn"": ""2007-09-25T00:00:00""
         },
         {
            ""id"": ""47BB1B40-7EC9-4E35-B359-1262484A93BC"",
            ""title"": ""Unchartered 4: A Thiefs End"",
            ""summary"": ""Set 3 years after the events of Uncharted 3, Nathan Drake has apparently left the world of fortune hunting behind. However, it doesn't take long for adventure to come calling when Drake's brother, Sam, re-emerges asking for his help to save his own life and offering an adventure Drake cannot resist. On the hunt for Captain Henry Avery's long-lost treasure, Sam and Drake embark on a journey to find Libertalia, the pirate utopia deep in the forests of Madagascar. Uncharted 4: A Thief's End takes players around the globe, through jungle isles, urban cities and snow-capped peaks on the search for Avery's fortune."",
            ""releasedOn"": ""2016-05-10T00:00:00""
         },
         {
            ""id"": ""492EC752-77C2-4487-AB5F-6D3AC6702BA6"",
            ""title"": ""Warcraft 3: Reign Of Chaos"",
            ""summary"": ""It has been nearly fifteen years since the war between the orcs and humans ended. An uneasy peace settled over the land while, for years, the drums of war were silent. Yet the kingdoms of men grew complacent in their victory - and slowly, the defeated orcish clans regrouped under the banner of a new visionary leader. Now a darker shadow has fallen over the world, threatening to extinguish all life - all hope. The drums of war play upon the winds once again - rising urgently towards the inevitable hour when the skies will rain fire - and the world will tremble before the coming of the Burning Legion. The Day of Judgment has come"",
            ""releasedOn"": ""2002-07-03T00:00:00""
         },
         {
            ""id"": ""A98C71E8-ABFF-4842-B4A1-608EB73BAE27"",
            ""title"": ""Starcraft 2: Wings Of Liberty"",
            ""summary"": ""StarCraft II continues the epic saga of the Protoss, Terran, and Zerg. These three distinct and powerful races clash once again in the fast-paced real-time strategy sequel to the legendary original, StarCraft. Legions of veteran, upgraded, and brand-new unit types do battle across the galaxy, as each faction struggles for survival. Featuring a unique single-player campaign that picks up where StarCraft: Brood War left off, StarCraft II presents a cast of new heroes and familiar faces in an edgy sci-fi story filled with adventure and intrigue. In addition, Blizzard again offers unparalleled online play through Battle.net, the company's world-renowned gaming service, with several enhancements and new features to make StarCraft II the ultimate competitive real-time strategy game. Features fast-paced, hard-hitting, tightly balanced competitive real-time strategy gameplay that recaptures and improves on the magic of the original game. New units and gameplay mechanics further distinguish each race. Vibrant new 3D-graphics engine with support for dazzling visual effects and massive unit and army sizes. Full map-making and scripting tools to give players incredible freedom in customizing and personalizing their gameplay experience"",
            ""releasedOn"": ""2010-07-27T00:00:00""
         }
      ]";

   private static readonly string _reviewersText = @"
      [
         {
            ""id"": ""01f783f1-1e7e-48c8-a400-e58611b9fd03"",
            ""picture"": ""http://placehold.it/32x32"",
            ""name"": ""Butler Burch"",
            ""email"": ""butlerburch@deminimum.com"",
            ""username"": ""martino""
         },
         {
            ""id"": ""0115465a-5984-4db5-a5d5-e4863493c258"",
            ""picture"": ""http://placehold.it/32x32"",
            ""name"": ""Nell Travis"",
            ""email"": ""nelltravis@deminimum.com"",
            ""username"": ""campbellb""
         },
         {
            ""id"": ""f6710a30-92c4-4cf3-8f63-b03e6bc6c579"",
            ""picture"": ""http://placehold.it/32x32"",
            ""name"": ""Wilcox Rivera"",
            ""email"": ""wilcoxrivera@deminimum.com"",
            ""username"": ""figueroag""
         },
         {
            ""id"": ""d37c0f73-28dd-4e98-90d9-0bbebd5ca02e"",
            ""picture"": ""http://placehold.it/32x32"",
            ""name"": ""Scott Mcintyre"",
            ""email"": ""scottmcintyre@deminimum.com"",
            ""username"": ""taylorl""
         },
         {
            ""id"": ""79bdb410-19c8-44ee-9d80-f062b004d119"",
            ""picture"": ""http://placehold.it/32x32"",
            ""name"": ""Carissa Phelps"",
            ""email"": ""carissaphelps@deminimum.com"",
            ""username"": ""bellt""
         }
      ]";
}
