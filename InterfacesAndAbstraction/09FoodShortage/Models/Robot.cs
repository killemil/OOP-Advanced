namespace _09FoodShortage.Models
{
    using System;

    public class Robot : Habitant, IMachine
    {
        private string model;

        public Robot(string id, string model) 
            : base(id)
        {
            this.Model = model;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }
    }
}
