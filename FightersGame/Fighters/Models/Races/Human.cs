namespace Fighters.Models.Races
{
    public class Human : IRace
    {
        public int Damage => 2;
        public int Health => 100;
        public int Armor => 1;
    }
}
