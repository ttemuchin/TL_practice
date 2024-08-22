namespace CarFactory.Models.Engines
{
    public class PG3090 : IEngine
    {
        public string Engine => "PG3090";
        public float Price => 0.6f;
        public float RepairPrice => 0.7f;
        public int Power => 8;

    }
}
