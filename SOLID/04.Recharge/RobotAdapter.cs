namespace _04.Recharge
{
    using System;

    public class RobotAdapter : IRechargeable
    {
        private Robot robot;

        public RobotAdapter(string id, int capacity)
        {
            this.robot = new Robot(id, capacity);
        }

        public void Recharge()
        {
            throw new NotImplementedException();
        }
    }
}