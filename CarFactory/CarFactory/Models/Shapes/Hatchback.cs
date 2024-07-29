namespace CarFactory.Models.Shapes
{
    public class Hatchback : IShape
    {
        public string Shape => "Hatchback";
        public float Price => 1.15f;
        public float RepairPrice => 0.9f;
        public int Resistance => 4;
    }
}
