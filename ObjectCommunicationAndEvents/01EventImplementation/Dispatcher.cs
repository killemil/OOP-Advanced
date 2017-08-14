namespace _01EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs e);

    public class Dispatcher
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }

        public event NameChangeEventHandler NameChange;

        public void OnNameChange(NameChangeEventArgs args)
        {
            this.NameChange?.Invoke(this, args);
        }
    }
}
