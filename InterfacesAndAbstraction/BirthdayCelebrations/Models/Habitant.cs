namespace BirthdayCelebrations
{
    public abstract class Habitant
    {
        private string id;

        public Habitant(string id)
        {
            this.Id = id;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            private set { this.id = value; }
        }
    }
}
