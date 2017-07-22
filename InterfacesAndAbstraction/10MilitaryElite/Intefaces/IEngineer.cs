namespace _10MilitaryElite.Intefaces
{
    using _10MilitaryElite.Models;
    using System.Collections.Generic;

    public interface IEngineer 
    {
        IList<IRepair> Repairs { get; }
    }
}
