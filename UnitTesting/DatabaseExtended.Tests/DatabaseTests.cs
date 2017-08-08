namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using _02DatabaseExtended;
    using _02DatabaseExtended.Intefaces;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private const int MaxDatabaseCapacty = 16;

        private Database database;

        [SetUp]
        public void TestInitialization()
        {
            this.database = new Database();
        }

        [Test]
        public void DatabaseInitializationWithCollectionOfPeople()
        {
            //Arrange
            IPerson firstPerson = new Person(1, "firstUser");
            IPerson secondPerson = new Person(2, "secondUser");
            IPerson[] people = new IPerson[] { firstPerson, secondPerson };

            //Act
            this.database = new Database(people);

            //Assert
            Assert.AreEqual(2, this.database.Size);
        }

        [Test]
        public void DatabaseAddPerson()
        {
            //Arrange
            IPerson person = new Person(1, "testUser");

            //Act
            this.database.Add(person);

            //Assert
            Assert.AreEqual(1, this.database.Size);
        }

        [Test]
        [TestCase(1L, "username", 1L, "username")]
        [TestCase(2L, "username", 2L, "gosho")]
        [TestCase(1L, "username", 2L, "username")]
        public void CannotAddPersonWithExistingUsernamaOrId(long firstId, string firstUsername, long secondId , string secondUsername)
        {
            //Arrange
            IPerson firstPerson = new Person(firstId, firstUsername);
            IPerson secondPerson = new Person(secondId, secondUsername);

            //Act
            this.database.Add(firstPerson);

            //Assert
            Assert.Throws<InvalidOperationException>(()=> this.database.Add(secondPerson));
        }

        [Test]
        public void RemovePersonFromDatabase()
        {
            //Arrange
            IPerson firstPerson = new Person(1L, "pesho");
            IPerson secondPerson = new Person(2L, "gosho");
            this.database.Add(firstPerson);
            this.database.Add(secondPerson);

            //Act
            this.database.Remove(firstPerson);
            this.database.Remove(secondPerson);

            //Assert
            Assert.AreEqual(0, this.database.Size);
        }

        [Test]
        [TestCase(1L, "1L", 2L, "2L", 3L, "3L", "1L")]
        [TestCase(1L, "1L", 2L, "2L", 3L, "3L", "2L")]
        [TestCase(1L, "1L", 2L, "2L", 3L, "3L", "3L")]
        public void FindByUsername(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername, string keyUsername)
        {
            // Arrange
            this.database.Add(new Person(firstId, firstUsername));
            this.database.Add(new Person(secondId, secondUsername));
            this.database.Add(new Person(thirdId, thirdUsername));

            // Act
            var foundPerson = this.database.FindByUsername(keyUsername);

            // Assert
            Assert.AreEqual(keyUsername, foundPerson.Username, $"Found {typeof(IPerson)} by Username is not the desired one");
        }

        [Test]
        public void CannotFindUserByNegativeId()
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1));
        }

        [Test]
        public void DatabaseFindPersonById()
        {
            //Arrange
            IPerson firstPerson = new Person(1, "gosho");
            IPerson secondPerson = new Person(2, "Pesho");
            this.database.Add(firstPerson);
            this.database.Add(secondPerson);

            //Act
            IPerson foundPerson = this.database.FindById(secondPerson.Id);

            //Assert
            Assert.AreEqual(secondPerson, foundPerson);
        }

        [Test]
        public void CannotFindPersonWithUnexistedUsername()
        {
            //Arrange
            IPerson person = new Person(1, "gosho");
            this.database.Add(person);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("Gosho"));

        }

        [Test]
        public void CannotFindPersonWithNullUsername()
        {
            //Arraange
            IPerson person = new Person(1, "gosho");
            this.database.Add(person);

            //Assert
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));
        }
    }
}
