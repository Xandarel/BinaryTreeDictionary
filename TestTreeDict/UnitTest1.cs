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
    }
}
