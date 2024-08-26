namespace CarFactory.Models.Gearboxes
{
    public class AKPP : IGearbox
    {
        public string Gearbox => "AKPP";
        public float Price => 0.65f;
        public float RepairPrice => 0.25f;
        public int NumOfGears => 9;
    }
}
