using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaIronManChallenge.Models
{
    public class Item
    {
        public string InternalName { get; set; }
        public string LocalizedName { get; set; }
        public int ID { get; set; }
        public string ImageUrl { get; set; }

        public Item(string internalName, string localizedName, int id)
        {
            InternalName = internalName;
            LocalizedName = localizedName;
            ID = id;
            ImageUrl = "http://cdn.dota2.com/apps/dota2/images/items/" + internalName.Replace("item_", "") +"_lg.png";
        }


    }
}
