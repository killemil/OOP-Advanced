namespace _10MilitaryElite.Intefaces
{
    using _10MilitaryElite.Models;
    using System.Collections.Generic;

    public interface ILeutenantGeneral
    {
        IList<ISoldier> Privates { get; }
    }
}
