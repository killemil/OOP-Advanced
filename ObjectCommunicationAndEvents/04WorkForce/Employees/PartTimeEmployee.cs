﻿namespace _04WorkForce.Employees
{
    public class PartTimeEmployee : BaseEmployee
    {
        private const int WorkHoursPerWeek = 20;

        public PartTimeEmployee(string name)
            : base(name, WorkHoursPerWeek)
        {
        }
    }
}
