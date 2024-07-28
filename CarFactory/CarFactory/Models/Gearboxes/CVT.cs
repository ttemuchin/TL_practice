namespace CarFactory.Models.Gearboxes
{
    public class CVT : IGearbox
    {
        public string Gearbox => "CVT";
        public float Price => 0.6f;
        public float RepairPrice => 0.2f;
        public int NumOfGears => 7;
    }
}
