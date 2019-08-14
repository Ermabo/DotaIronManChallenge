using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaIronManChallenge.Models;
using DotaIronManChallenge.Services;
using Newtonsoft.Json.Linq;

namespace DotaIronManChallenge.Repositories
{
    public class ItemRepository : JsonFileRepository
    {
        private static ItemServices _itemServiceHandler;
        /// <summary>
        /// Gets a random item build with five unique items and upgraded boots.
        /// </summary>
        /// <returns>List of items</returns>
        public IEnumerable<Item> GetItemBuild(string projectRoot)
        {
            _itemServiceHandler = new ItemServices();
            JArray itemsArray = base.GetArrayFromJsonFile(projectRoot, "items.json");
            JArray bootsArray = base.GetArrayFromJsonFile(projectRoot, "boots.json");

            List<Item> allItems = _itemServiceHandler.ItemListFromJArray(itemsArray);
            List<Item> bootsList = _itemServiceHandler.ItemListFromJArray(bootsArray);

            var boots = _itemServiceHandler.GetRandomItemFromList(bootsList);
            var itemBuild = new List<Item>();

            itemBuild.Add(boots);
            itemBuild.AddRange(RandomItemBuildFromList(allItems));

            return itemBuild;
        }

        private IEnumerable<Item> RandomItemBuildFromList(List<Item> allItems)
        {
            var localAllItemsList = allItems.ToList();
            var itemBuild = new List<Item>();

            // An item build contains 5 items + a pair of boots
            for (int i = 0; i < 5; i++)
            {
                var randomItem = _itemServiceHandler.GetRandomItemFromList(localAllItemsList);
                itemBuild.Add(randomItem);

                localAllItemsList.RemoveAll(x => x.ID == randomItem.ID);
            }

            return itemBuild;
        }



    }
}
