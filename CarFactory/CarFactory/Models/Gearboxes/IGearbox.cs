namespace CarFactory.Models.Gearboxes
{
    public interface IGearbox
    {
        public string Gearbox { get; }
        public float Price { get; }
        public float RepairPrice { get; }
        public int NumOfGears { get; }
    }
}