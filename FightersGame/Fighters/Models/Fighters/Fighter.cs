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
        public Fighter( string name, IRace race, IClass user_class, IWeapon weapon, IArmor armor )
        {
            Name = name;
            _race = race;
            _class = user_class;
            _currentHealth = GetMaxHealth();
            SetArmor( armor );
            SetWeapon( weapon );
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
            var rand = new Random();
            float criticalDamageFactor = 0.19f;
            float deltaDamageFactor = 0.33f;

            if ( damage == 0 )
            {
                return [ 0, _currentHealth, 0 ];
            }
            var deltaDamage = Math.Round( rand.NextDouble(), 2 );
            if ( deltaDamage <= deltaDamageFactor )
            { damage -= 1; }
            else if ( deltaDamage >= deltaDamageFactor * 2 )
            { damage += 1; }

            var criticalDamage = Math.Round( rand.NextDouble(), 2 );
            if ( criticalDamage <= criticalDamageFactor )
            {
                damage = damage * 2;
                criticalDamage = 1;
            }
            else criticalDamage = 0;//to show is there crit or not 

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

            return [ delta, newHealth, ( int )criticalDamage ];
        }
    }
}
