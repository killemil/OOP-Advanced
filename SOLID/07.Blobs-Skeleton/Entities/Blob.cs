namespace _02.Blobs.Entities
{
    using System;
    using _02.Blobs.Entities.Attacks;
    using _02.Blobs.Entities.Behaviors;
    using _02.Blobs.Interfaces;

    public class Blob
    {
        private int health;
        private IAttack attack;
        private IBehavior behavior;
        private int initialHealth;
        private bool behaviorTriggeredInThisTurn;

        public Blob(string name, int health, int damage, IBehavior behavior, IAttack attack)
        {
            this.behavior = behavior;
            this.attack = attack; 

            this.initialHealth = health;
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }

        public string Name { get;}

        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;

                if (this.health < 0)
                {
                    this.health = 0;
                }

                this.CheckForBehaviorTriggered();
            }
        }

        private void CheckForBehaviorTriggered()
        {
            if (this.health <= this.initialHealth / 2 && !this.behavior.IsTriggered)
            {
                this.TriggerBehavior();
            }
        }

        public int Damage { get; set; }

        public void TriggerBehavior()
        {
            if (this.behavior.IsTriggered)
            {
                throw new ArgumentException();
            }

            this.behavior.Trigger(this);
            this.behaviorTriggeredInThisTurn = true;
        }

        public bool IsAlive()
        {
            return this.Health > 0;
        }

        public void Attack(Blob target)
        {
            if (target.IsAlive() && this.IsAlive())
            {
                this.attack.Execute(this, target);
            }
        }

        public void MoveToNextTurn()
        {
            if (this.behavior.IsTriggered && !this.behaviorTriggeredInThisTurn)
            {
                this.behavior.ApplyPostTriggerEffect(this);
            }

            this.behaviorTriggeredInThisTurn = false;
        }



        public override string ToString()
        {
            if (this.Health <= 0)
            {
                return $"Blob {this.Name} KILLED";
            }

            return $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage";
        }
    }
}