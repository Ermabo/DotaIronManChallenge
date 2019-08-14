using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaIronManChallenge.Models;
using Newtonsoft.Json.Linq;

namespace DotaIronManChallenge.Services
{
    public class ItemServices
    {
        public Item GetRandomItemFromList(IEnumerable<Item> allItems)
        {
            var randomindex = new Random().Next(0, allItems.ToList().Count);

            var item = allItems?.Where((x, i) => i == randomindex)
                                .Select(z => new Item(z.InternalName, z.LocalizedName, z.ID))
                                .First();

            return item;
        }

        public List<Item> ItemListFromJArray(JArray itemsArray)
        {
            List<Item> itemsList = new List<Item>();

            foreach (var item in itemsArray)
            {
                itemsList.Add(new Item((string)item["name"], (string)item["localized_name"], (int)item["id"]));
            }

            return itemsList;
        }
    }
}
