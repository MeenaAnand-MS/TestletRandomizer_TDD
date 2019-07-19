using System;
using System.Collections.Generic;
using System.Linq;

namespace Testlet
{
    public class Testlet
    {

        public string TestletId;

        private List<Item> Items;

        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            Items = items;
        }
           

        public List<Item> Randomize()
        {
            var randomizedList = new List<Item>();
            //Items private collection has 6 Operational and 4 Pretest Items. Randomize the order of these items as per the requirement (with TDD)
            var pretestList = this.Items.Where(s=>s.ItemType == ItemTypeEnum.Pretest).OrderBy(a=>Guid.NewGuid().GetHashCode()).Take(2);
            randomizedList.AddRange(pretestList);

            //exclude items that we already picked
            randomizedList.AddRange(this.Items.Except(pretestList).OrderBy(a=>Guid.NewGuid().GetHashCode()).Take(8));

            return randomizedList;
        }

    }

 

    public class Item

    {
        public string ItemId;

        public ItemTypeEnum ItemType;
    }

 

    public enum ItemTypeEnum

    {
        Pretest = 0,

        Operational = 1
    }
}