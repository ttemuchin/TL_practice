using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.Models.Classes;

namespace Fighters.Models.Fighters
{
    public class Fighter : IFighter
    {
        private readonly IRace _race;
        private readonly IClass _class;
        private IArmor _armor = new NoArmor();
        private IWeapon _weapon = new Fists();

        private int _currentHealth;

        public string Name { get; private set; }

        public Fighter( string name, IRace race, IClass user_class )
        {
            Name = name;
            _race = race;
            _class = user_class;
            _currentHealth = GetMaxHealth();
        }

        public int GetMaxHealth() => _race.Health + _class.Health;
        public int GetCurrentHealth() => _currentHealth;
        public int CalculateArmor() => _armor.Armor + _race.Armor;
        public int CalculateDamage() => _weapon.Damage + _race.Damage + _class.Damage;

        public void SetArmor( IArmor armor )
        {
            _armor = armor;
        }
        public void SetWeapon( IWeapon weapon )
        {
            _weapon = weapon;
        }

        public int[] TakeDamage( int damage )
        {
            int newHealth;
            if ( damage > CalculateArmor() )
            {
                newHealth = _currentHealth - ( damage - CalculateArmor() );
            }
            else { newHealth = _currentHealth; }
            if ( newHealth < 0 )
            {
                newHealth = 0;
            }
            int delta = _currentHealth - newHealth;
            _currentHealth = newHealth;
            return [ delta, newHealth ];
        }
    }
}
