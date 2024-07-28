namespace CarFactory.Models.Shapes
{
    public class Sedan : IShape
    {
        public string Shape => "Sedan";
        public float Price => 1.4f;
        public float RepairPrice => 1.0f;
    }
}
