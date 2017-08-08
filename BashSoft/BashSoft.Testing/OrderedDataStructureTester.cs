namespace BashSoft.Testing
{
    using BashSoft.Contracts;
    using BashSoft.DataStructures;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            //Arrange
            this.names = new SimpleSortedList<string>();

            //Assert
            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);

            Assert.AreEqual(20, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);

            Assert.AreEqual(30, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtroWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestAddIncreaseSize()
        {
            this.names.Add("pesho");

            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            string[] orderedNames = new string[3] { "Balkan", "Georgi", "Rosen" };

            CollectionAssert.AreEqual(orderedNames, this.names);
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                this.names.Add(i.ToString());
            }

            Assert.AreEqual(17, this.names.Size);
            Assert.AreNotEqual(16, this.names.Capacity);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            ICollection<string> list = new List<string>()
            {
                "pesho",
                "Gosho"
            };

            this.names.AddAll(list);

            Assert.AreEqual(2, this.names.Size);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            ICollection<string> unorderedList = new List<string>()
            {
                "Pesho",
                "Gosho",
                "Anton",
                "Balton"
            };
            this.names.AddAll(unorderedList);

            SortedSet<string> orderedCollection = new SortedSet<string>(unorderedList);

            CollectionAssert.AreEqual(orderedCollection, this.names);
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("Pesho");
            this.names.Add("Gosho");
            this.names.Add("Ivan");
            this.names.Remove("Pesho");
            this.names.Remove("Gosho");

            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("Gosho");
            this.names.Add("Pesho");

            Assert.IsTrue(this.names.Remove("Pesho"));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
        }

        [Test]
        public void TestJoinWithNull()
        {
            this.names.Add("Pesho");
            this.names.Add("Gosho");
            this.names.Add("Ivan");

            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            this.names.Add("Andres");
            this.names.Add("Ivan");

            Assert.AreEqual("Andres, Ivan", this.names.JoinWith(", "));
        }
    }
}