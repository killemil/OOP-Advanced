namespace Database.Tests
{
    using NUnit.Framework;
    using _01Database;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private const int DatabaseMaxCapacity = 16;

        private Database database;

        [SetUp]
        public void TestInit()
        {
            this.database = new Database();
        }

        [Test]
        public void AddElementWhenDatabaseIsFull()
        {
            //Act
            this.AddNumbers(DatabaseMaxCapacity);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(2));
        }

        [Test]
        public void CannotRemoveElementWhenDatabaseIsEmpty()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        [TestCase(3)]
        [TestCase(8)]
        [TestCase(16)]
        public void AddElementIncreaseCount(int numberOfCommands)
        {
            //Act
            this.AddNumbers(numberOfCommands);

            //Assert
            Assert.AreEqual(numberOfCommands, this.database.Size, "Add method don't increase size.");
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(8, 4)]
        [TestCase(16, 15)]
        [TestCase(16, 16)]
        public void RemoveFromDatabaseDecreaseCount(int numberOfAddCommands, int numberOfRemoveCommands)
        {
            //Act
            this.AddNumbers(numberOfAddCommands);
            this.RemoveNumbers(numberOfRemoveCommands);

            //Assert
            int expectedOutput = numberOfAddCommands - numberOfRemoveCommands;
            Assert.AreEqual(expectedOutput, this.database.Size, "Remove method dont decrease size.");
        }

        [Test]
        [TestCase(5)]
        [TestCase(1)]
        [TestCase(16)]
        public void FetchReturnsCorrectNumberOfElements(int numberOfAddCommands)
        {
            //Act
            this.AddNumbers(numberOfAddCommands);
            int[] databaseContent = this.database.Fetch();

            //Assert
            Assert.AreEqual(numberOfAddCommands, databaseContent.Length);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(6)]
        [TestCase(16)]
        public void FetchRetrunsCorrectElementsFromDatabase(int numberOfAddCommands)
        {
            //Act
            this.AddNumbers(numberOfAddCommands);
            int[] databaseContent = this.database.Fetch();

            //Assert
            for (int i = 0; i < numberOfAddCommands; i++)
            {
                Assert.AreEqual(i, databaseContent[i]);
            }
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(16, 5)]
        [TestCase(1, 1)]
        public void FetchReturnsCorrectNumberOfElementsAfterRemove(int addCommands, int removeCommands)
        {
            //Act
            this.AddNumbers(addCommands);
            this.RemoveNumbers(removeCommands);
            int[] databaseContent = this.database.Fetch();

            //Assert
            int expectedNumberOfElements = addCommands - removeCommands;
            Assert.AreEqual(expectedNumberOfElements, databaseContent.Length);
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(16, 5)]
        [TestCase(10, 5)]
        public void FetchReturnsCorrectElementsAfterRemove(int addCommands, int removeCommands)
        {
            //Act
            this.AddNumbers(addCommands);
            this.RemoveNumbers(removeCommands);
            int[] databaseContent = this.database.Fetch();

            //Assert
            for (int i = 0; i < addCommands - removeCommands; i++)
            {
                Assert.AreEqual(i, databaseContent[i]);
            }
        }

        [Test]
        [TestCase(2)]
        [TestCase(2, 3)]
        [TestCase(2, 3, 4, 5)]
        [TestCase(2, 3, 4, 5, 6, 7)]
        [TestCase(2, 3, 4, 5, 6, 7, 8, 9)]
        public void DatabasInitializationConstructorWithCollectionOfNumber(params int[] numbers)
        {
            //Arrange
            this.database = new Database(numbers);

            //Act
            this.database.Add(int.MaxValue);
            this.database.Remove();
            int[] databaseContent = this.database.Fetch();

            //Assert
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.AreEqual(databaseContent[i], numbers[i]);
            }
        }

        [Test]
        [TestCase(1, 2)]
        [TestCase(int.MinValue, int.MaxValue)]
        public void DirectDatabaseInitializationConstructorWithVariousNumberOfNumbersWorksCorrectly(int firstNumber, int secondNumber)
        {
            //Arrange
            this.database = new Database(firstNumber, secondNumber);

            //Act
            int[] databaseContent = this.database.Fetch();

            //Assert
            Assert.AreEqual(firstNumber, databaseContent[0]);
            Assert.AreEqual(secondNumber, databaseContent[1]);
        }

        [Test]
        public void CannotInitializeDatabaseWithCollectionMoreThanCapacity()
        {
            //Arrange
            int[] testCollection = new int[DatabaseMaxCapacity + 1];

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database = new Database(testCollection));
        }

            private void RemoveNumbers(int numberOfRemoveComands)
        {
            for (int i = 0; i < numberOfRemoveComands; i++)
            {
                this.database.Remove();
            }
        }

        private void AddNumbers(int numberOfAddCommands)
        {
            for (int i = 0; i < numberOfAddCommands; i++)
            {
                this.database.Add(i);
            }
        }
    }
}
