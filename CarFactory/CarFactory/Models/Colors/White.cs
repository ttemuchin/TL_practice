using CarFactory.Models.Engines;

namespace CarFactory.Models.Colors
{
    public class White : IEngine
    {
        public string Color = "White";
        public float Price => 0.3f;
        public float RepairPrice => 0.45f;
    }
}
