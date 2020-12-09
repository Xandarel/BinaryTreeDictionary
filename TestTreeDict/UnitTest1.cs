using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreeDIct;
using System.Collections.Generic;
using Moq;
using System.Collections;

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
            {
                Console.WriteLine(k);
                key.Add(k);
            }
            var assertList = new List<int>() { 0, 10, -1 };
            CollectionAssert.AreEqual(assertList, key);
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

        [TestMethod]
        public void EnumeratorDict()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            BTD.Add(3, 2);
            BTD.Add(new KeyValuePair<int, int>(5, 11));
            foreach (var btd in BTD)
            {
            }
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void ReadFile()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            var fileString = "11:22 14:19";
            var separator = ':';
            var FRL = new DataSerializer();
            FRL.LoadToDict(fileString, BTD, separator);

            Assert.AreEqual(22, BTD[11]);
            Assert.AreEqual(19, BTD[14]);
        }
        [TestMethod]
        public void LoadFile()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            BTD.Add(3, 2);
            BTD.Add(new KeyValuePair<int, int>(5, 11));
            var separator = ':';
            var FRL = new DataSerializer();
            var result = FRL.ReadDict(BTD, separator);

            Assert.AreEqual($"0:{BTD[0]} 3:{BTD[3]} 5:{BTD[5]} ", result);
        }

        [TestMethod]
        public void LoadDataToFileFromDict()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            BTD[0] = 1;
            BTD.Add(3, 2);
            BTD.Add(new KeyValuePair<int, int>(5, 11));
            var separator = ':';
            var FRL = new DataSerializer();
            var fakeFile = new Mock<IFileWorker>();
            fakeFile.Setup(x => x.ToFile(It.IsAny<string>(), It.IsAny<string>()));
            BTD.LoadToFile(FRL, fakeFile.Object, "aaa", ':');
            fakeFile.Verify(x => x.ToFile(It.IsAny<string>(), $"0:{BTD[0]} 3:{BTD[3]} 5:{BTD[5]} "));
            fakeFile.VerifyAll();
        }
        [TestMethod]
        public void ReadDataFromFileToDict()
        {
            var BTD = new BinaryTreeDictionary<int, int>();
            var FRL = new DataSerializer();
            var fakeFile = new Mock<IFileWorker>();
            fakeFile.Setup(x => x.FromFile(It.IsAny<string>())).Returns("11:22 14:19");
            var separator = ':';
            BTD.ReadFromFile(FRL, fakeFile.Object, "aaa", separator);
            Assert.AreEqual(22, BTD[11]);
            Assert.AreEqual(19, BTD[14]);
        }
    }
}