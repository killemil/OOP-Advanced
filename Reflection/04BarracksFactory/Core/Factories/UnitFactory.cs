﻿namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string UnitNamespace = "_03BarracksFactory.Models.Units.";
        public IUnit CreateUnit(string unitType)
        {
            Type typeOfUnit = Type.GetType(UnitNamespace + unitType);
            IUnit unitInstance = (IUnit)Activator.CreateInstance(typeOfUnit);
            return unitInstance;
        }
    }
}
