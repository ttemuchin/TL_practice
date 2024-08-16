using Fighters.Models.Armors;
using Fighters.Models.Classes;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Extensions
{
    public class Configuration
    {
        public Dictionary<string, string> AskUserData()
        {
            var userData = new Dictionary<string, string>();
            string name = Console.ReadLine();
            userData.Add( "name", name );
            Console.WriteLine( $"{name}, Choose your race: (human, dwarf, elf, undead, vampire)" );
            userData.Add( "race", Console.ReadLine() );
            Console.WriteLine( "Choose your class: (knight, mercenery, brigand)" );
            userData.Add( "class", Console.ReadLine() );
            Console.WriteLine( $"Choose armor: (light, heavy)" );
            userData.Add( "armor", Console.ReadLine() );
            Console.WriteLine( $"And finaly choose a weapon: (fists, sword, bow, spear, hammer)" );
            userData.Add( "weapon", Console.ReadLine() );
            Console.WriteLine( $"{name}, you are now equiped and good to go!" );

            return userData;
        }

        public Fighter SetPlayerConfig( Dictionary<string, string> userData )
        {
            IRace race = null;
            switch ( userData[ "race" ] )
            {
                case "dwarf":
                    race = new Dwarf();
                    break;
                case "elf":
                    race = new Elf();
                    break;
                case "undead":
                    race = new Undead();
                    break;
                case "vampire":
                    race = new Vampire();
                    break;
                default:
                    race = new Human();
                    break;
            }

            IClass userClass = null;
            switch ( userData[ "class" ] )
            {
                case "mercenery":
                    userClass = new Mercenary();
                    break;
                case "brigand":
                    userClass = new Brigand();
                    break;
                default:
                    userClass = new Knight();
                    break;
            }

            IWeapon weapon = null;
            switch ( userData[ "weapon" ] )
            {
                case "bow":
                    weapon = new Bow();
                    break;
                case "hammer":
                    weapon = new Hammer();
                    break;
                case "spear":
                    weapon = new Spear();
                    break;
                case "sword":
                    weapon = new Sword();
                    break;
                default:
                    weapon = new Fists();
                    break;
            }

            IArmor armor = null;
            switch ( userData[ "armor" ] )
            {
                case "light":
                    armor = new LightArmor();
                    break;
                case "heavy":
                    armor = new HeavyArmor();
                    break;
                default:
                    armor = new NoArmor();
                    break;
            }

            var fighter = new Fighter( userData[ "name" ], race, userClass, weapon, armor );

            return fighter;
        }
    }
}
