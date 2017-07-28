namespace _06StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class PersonNameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.Length != y.Name.Length)
            {
                return x.Name.Length.CompareTo(y.Name.Length);
            }

            if (x.Name[0].ToString().ToLower() != y.Name[0].ToString().ToLower())
            {
                return x.Name[0].ToString().ToLower().CompareTo(y.Name[0].ToString().ToLower());
            }

            return 0;
        }
    }
}
