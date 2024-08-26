namespace CarFactory.Models.Colors
{
    public interface IColor
    {
        public string Color { get; }
        public float Price { get; }
        public float RepairPrice { get; }
    }
}