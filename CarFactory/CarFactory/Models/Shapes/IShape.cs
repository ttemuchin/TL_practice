namespace CarFactory.Models.Shapes
{
    public interface IShape
    {
        public string Shape { get; }
        public float Price { get; }
        public float RepairPrice { get; }
    }
}