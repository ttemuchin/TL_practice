namespace CarFactory.Models.Gearboxes
{
    public class MKPP : IGearbox
    {
        public string Gearbox => "MKPP";
        public float Price => 0.5f;
        public float RepairPrice => 0.1f;
        public int NumOfGears => 5;
    }
}
