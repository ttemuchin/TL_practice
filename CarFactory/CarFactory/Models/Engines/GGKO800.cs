namespace CarFactory.Models.Engines
{
    public class GGKO800 : IEngine
    {
        public string Engine => "GGKO800";
        public float Price => 0.8f;
        public float RepairPrice => 0.9f;
        public int Power => 10;
    }
}
