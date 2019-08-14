using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotaIronManChallenge.Models
{
    public class Hero
    {
        public string Name { get; set; }

        public string InternalName { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public Hero(string internalName, string localizedName)
        {
            InternalName = internalName;
            var formattedInternalName = ParseHeroName(internalName);

            ImageUrl = $"http://cdn.dota2.com/apps/dota2/images/heroes/{formattedInternalName}_vert.jpg";
            Name = localizedName;
            VideoUrl = $"/videos/{internalName}.webm";
        }

        private string ParseHeroName(string heroName)
        {
            string pattern = @"^npc_dota_hero_(.*)";
            Match match = Regex.Match(heroName, pattern, RegexOptions.IgnoreCase);
            var res = match.Success ? match.Groups[1].Value : "";
            return res;
        }
    }
}
