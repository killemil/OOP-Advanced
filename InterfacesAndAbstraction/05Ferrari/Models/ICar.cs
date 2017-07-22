namespace _05Ferrari.Models
{
    public interface ICar
    {
        string Model { get; }
        string Driver { get; }

        string Brake();
        string Accelerate();
    }
}
