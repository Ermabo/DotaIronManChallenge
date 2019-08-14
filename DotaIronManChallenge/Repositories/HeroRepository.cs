using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DotaIronManChallenge.Models;
using Newtonsoft.Json.Linq;
using System.Globalization;


namespace DotaIronManChallenge.Repositories
{
    public class HeroRepository : JsonFileRepository
    {
        public Hero GetRandomHero(string projectRoot)
        {
            JArray heroesArray = base.GetArrayFromJsonFile(projectRoot, "heroes.json");
            var randomIndex = new Random().Next(0, heroesArray.Count);

            var _randomHero = heroesArray
                .Where((x, i) => i == randomIndex)
                .Select(h => new Hero((string)h["name"], (string)h["localized_name"]))
                .First();

            return _randomHero;
        }
    }
}
