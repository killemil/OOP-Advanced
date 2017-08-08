namespace _02DatabaseExtended
{
    using _02DatabaseExtended.Intefaces;

    public class Person : IPerson
    {
        private long id;
        private string username;

        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                this.username = value;
            }
        }
    }
}
