namespace _05BaracksWarsReturnOfTheDependacies.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class InjectAttribute : Attribute
    {
    }
}
