namespace _03BlackBoxInteger
{
    public class BlackBoxInt
    {
        private int innerValue;

        private BlackBoxInt()
        {
           this.innerValue = 0;
        }

        private void Add(int number)
        {
            this.innerValue += number;
        }

        private void Subtract(int number)
        {
            this.innerValue -= number;
        }

        private void Multiply(int number)
        {
            this.innerValue *= number;
        }

        private void Divide(int number)
        {
             this.innerValue /= number;
        }

        private void LeftShift(int number)
        {
            this.innerValue <<= number;
        }

        private void RightShift(int number)
        {
            this.innerValue >>= number;
        }

    }
}
