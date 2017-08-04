namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;
            this.Repository.RemoveUnit(this.Data[1]);

            return $"{this.Data[1]} retired!";
        }
    }
}
