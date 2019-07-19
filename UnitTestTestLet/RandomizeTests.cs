using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Testlet;

namespace Testlettest
{
    [TestClass]
    public class RandomizeTest
    {
        public static Testlet.Testlet SetupList()
        {
            return new Testlet.Testlet("First Test", new List<Item>(){
                new Item() {ItemId = "PreTest Item 1", ItemType = ItemTypeEnum.Pretest},
                new Item() {ItemId = "PreTest Item 2", ItemType = ItemTypeEnum.Pretest},
                new Item() {ItemId = "PreTest Item 3", ItemType = ItemTypeEnum.Pretest},
                new Item() {ItemId = "PreTest Item 4", ItemType = ItemTypeEnum.Pretest},

                new Item() {ItemId = "Operational Item 1", ItemType = ItemTypeEnum.Operational},
                new Item() {ItemId = "Operational Item 2", ItemType = ItemTypeEnum.Operational},
                new Item() {ItemId = "Operational Item 3", ItemType = ItemTypeEnum.Operational},
                new Item() {ItemId = "Operational Item 4", ItemType = ItemTypeEnum.Operational},
                new Item() {ItemId = "Operational Item 5", ItemType = ItemTypeEnum.Operational},
                new Item() {ItemId = "Operational Item 6", ItemType = ItemTypeEnum.Operational}
            });

        }

        [TestMethod]
        public void TestRandomize()
        {
            // First create a test set - to run/test this
            // per TDD 
            Testlet.Testlet tl = SetupList();

            var randomizedlist1 = tl.Randomize();
            var randomizedlist2 = tl.Randomize();

            //compare that in both lists (after being randomized - there is atleast one item with the same index that is different)
            Assert.IsNotNull(randomizedlist1.FirstOrDefault(s => randomizedlist2[randomizedlist1.IndexOf(s)].ItemId != s.ItemId));

        }

        /// <summary>
        /// This is a control test to ensure that a list that is copied to another list 
        /// </summary>
        [TestMethod]
        public void TestRandomizeControltest()
        {
            // First create a test set - to run/test this
            // per TDD
            Testlet.Testlet tl = SetupList();

            var randomizedlist1 = tl.Randomize();
            var randomizedlist2 = new List<Item>();
            randomizedlist2.AddRange(randomizedlist1);

            //compare that in both lists (copied from the same list - so no items should be different)
            Assert.IsNull(randomizedlist1.FirstOrDefault(s => randomizedlist2[randomizedlist1.IndexOf(s)].ItemId != s.ItemId));

        }
    }
}
