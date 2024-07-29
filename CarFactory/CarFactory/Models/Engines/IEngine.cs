namespace CarFactory.Models.Engines
{
    public interface IEngine
    {
        string Engine { get; }
        public float Price { get; }
        public float RepairPrice { get; }
        public int Power { get; }
    }
}