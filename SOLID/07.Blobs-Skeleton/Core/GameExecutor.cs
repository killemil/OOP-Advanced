namespace _02.Blobs.Core
{
    using System.Collections.Generic;
    using _02.Blobs.Entities;
    using _02.Blobs.Entities.Attacks.Factory;
    using _02.Blobs.Entities.Behaviors.Factory;
    using _02.Blobs.Interfaces;
    using _02.Blobs.Interfaces.IO;
    using System.Text;
    using System.Linq;

    public class GameExecutor
    {
        private IDictionary<string, Blob> blobs;
        private BehaviorFactory behaviorFactory;
        private AttackFactory attackFactory;

        public GameExecutor()
        {
            this.blobs = new Dictionary<string, Blob>();
            this.behaviorFactory = new BehaviorFactory();
            this.attackFactory = new AttackFactory();
        }

        private void CreateBlob(IList<string> tokens)
        {
            string name = tokens[0];
            int health = int.Parse(tokens[1]);
            int damage = int.Parse(tokens[2]);
            IBehavior behavior = this.behaviorFactory.CreateBehavior(tokens[3]);
            IAttack attack = this.attackFactory.CreateAttack(tokens[4]);

            this.blobs.Add(name, new Blob(name, health, damage, behavior, attack));
        }

        private void GetStatus (IWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Blob blob in this.blobs.Values)
            {
                sb.AppendLine(blob.ToString());
            }

            writer.WriteLine(sb.ToString().Trim());
        }

        private void ExecuteAttack(IList<string> tokens)
        {
            string attackerName = tokens[0];
            string targetName = tokens[1];

            this.blobs[attackerName].Attack(this.blobs[targetName]);
        }

        private void RollTurn()
        {
            foreach (Blob blob in this.blobs.Values)
            {
                blob.MoveToNextTurn();
            }
        }

        public void PlayAction(string action , IWriter writer)
        {
            IList<string> tokens = action.Split().ToList();
            string actionType = tokens[0];
            tokens.RemoveAt(0);

            switch (actionType)
            {
                case "create":
                    this.CreateBlob(tokens);
                    break;
                case "attack":
                    this.ExecuteAttack(tokens);
                    break;
                case "status":
                    this.GetStatus(writer);
                    break;
            }

            this.RollTurn();
        }
    }
}
