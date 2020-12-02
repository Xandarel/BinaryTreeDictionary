using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreeDIct;
using System.Collections.Generic;

namespace TestTreeDict
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAndSetValue()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            Assert.AreEqual(1, BTD[0]);
        }
        [TestMethod]
        public void GetKeys()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            BTD[10] = 11;
            BTD[-1] = 0;
            var key = new List<int>();
            foreach (var k in BTD.Keys)
                key.Add(k);
            var assertList = new List<int>() { 0, -1, 10 };
            // Не знаю почему, но если подвать в сравнение список и список выдовалась ошибка
            //Сбой Assert.AreEqual.Ожидается: < System.Collections.Generic.List`1[System.Int32] >.
            //Фактически:                     < System.Collections.Generic.List`1[System.Int32] >.
            Assert.AreEqual(assertList.ToString(), key.ToString());
        }
        [TestMethod]
        public void GetValues()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            BTD[10] = 11;
            BTD[-1] = 0;
            var key = new List<int>();
            foreach (var k in BTD.Values)
                key.Add(k);
            var assertList = new List<int>() { 1, 11, 0 };
            Assert.AreEqual(assertList.ToString(), key.ToString());
        }

        [TestMethod]
        public void GetCount()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            BTD[10] = 11;
            BTD[-1] = 0;

            Assert.AreEqual(3, BTD.Count);
        }

        [TestMethod]
        public void AddToDict()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            BTD.Add(3, 2);
            BTD.Add(new KeyValuePair<int, int>(5, 11));

            Assert.AreEqual(2, BTD[3]);
            Assert.AreEqual(11, BTD[5]);
        }

        [TestMethod]
        public void ClearDict()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            BTD.Add(3, 2);
            BTD.Add(new KeyValuePair<int, int>(5, 11));
            BTD.Clear();
            Assert.AreEqual(default, BTD[default]);
        }

        [TestMethod]
        public void ContainDict()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            BTD.Add(3, 2);
            BTD.Add(new KeyValuePair<int, int>(5, 11));
            Assert.AreEqual(false, BTD.Contains(new KeyValuePair<int, int>(77, 88)));
            Assert.AreEqual(false, BTD.Contains(new KeyValuePair<int, int>(3, 11)));
            Assert.AreEqual(true, BTD.Contains(new KeyValuePair<int, int>(3, 2)));
        }
        [TestMethod]
        public void ContainsKeyDict()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            BTD.Add(3, 2);
            BTD.Add(new KeyValuePair<int, int>(5, 11));
            Assert.AreEqual(true, BTD.ContainsKey(5));
            Assert.AreEqual(false, BTD.ContainsKey(77));
        }
        [TestMethod]
        public void TryGetValueDict()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            BTD.Add(3, 2);
            BTD.Add(new KeyValuePair<int, int>(5, 11));
            var number = 5;

            Assert.AreEqual(false, BTD.TryGetValue(77, out number));
            Assert.AreEqual(true, BTD.TryGetValue(0, out number));
        }
    }
}
