namespace CarFactory.Models.Engines
{
    public interface IEngine
    {
        public float Price { get; }
        public float RepairPrice { get; }
        public int Power { get; }
    }
}