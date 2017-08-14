namespace _05BaracksWarsReturnOfTheDependacies.Core.Factories
{
    using System;
    using _05BaracksWarsReturnOfTheDependacies.Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string UnitNameSpace = "_03BarracksFactory.Models.Units.";
        public IUnit CreateUnit(string unitType)
        {
            Type typeUnit = Type.GetType(UnitNameSpace + unitType);
            IUnit unitInstance = (IUnit)Activator.CreateInstance(typeUnit);
            return unitInstance;
        }
    }
}
