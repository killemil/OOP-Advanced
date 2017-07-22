using System;

namespace _05Ferrari.Models
{
    public class Ferrari : ICar
    {
        private string model;
        private string driver;

        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                this.model = value;
            }
        }

        public string Driver
        {
            get
            {
                return this.driver;
            }
            private set
            {
                this.driver = value;
            }
        }

        public string Accelerate()
        {
            return $"Zadu6avam sA!";
        }

        public string Brake()
        {
            return "Brakes!";
        }
    }
}
