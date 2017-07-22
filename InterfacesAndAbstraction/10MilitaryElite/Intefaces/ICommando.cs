namespace _10MilitaryElite.Intefaces
{
    using _10MilitaryElite.Models;
    using System.Collections.Generic;

    public interface ICommando 
    {
        IList<IMission> Missions { get; }

        void CompleteMission();
    }
}
