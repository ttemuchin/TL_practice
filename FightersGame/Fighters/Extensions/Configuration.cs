using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Fighters;
using Fighters.Models.Classes;
using Fighters.Models.Weapons;
using Fighters.Models.Armors;

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
            var race = new Object();
            if ( userData[ "race" ] == "dwarf" ) { race = new Dwarf(); }
            else if ( userData[ "race" ] == "elf" ) { race = new Elf(); }
            else if ( userData[ "race" ] == "undead" ) { race = new Undead(); }
            else if ( userData[ "race" ] == "vampire" ) { race = new Vampire(); }
            else { race = new Human(); }

            var userClass = new Object();
            if ( userData[ "class" ] == "mercenery" ) { userClass = new Mercenary(); }
            else if ( userData[ "class" ] == "brigand" ) { userClass = new Brigand(); }
            else { userClass = new Knight(); }

            var weapon = new Object();
            if ( userData[ "weapon" ] == "bow" ) { weapon = new Bow(); }
            else if ( userData[ "weapon" ] == "hammer" ) { weapon = new Hammer(); }
            else if ( userData[ "weapon" ] == "spear" ) { weapon = new Spear(); }
            else if ( userData[ "weapon" ] == "sword" ) { weapon = new Sword(); }
            else { weapon = new Fists(); }

            var armor = new Object();
            if ( userData[ "armor" ] == "light" ) { armor = new LightArmor(); }
            else if ( userData[ "armor" ] == "heavy" ) { armor = new HeavyArmor(); }
            else { armor = new NoArmor(); }

            var fighter = new Fighter( userData[ "name" ], ( IRace )race, ( IClass )userClass, ( IWeapon )weapon, ( IArmor )armor );

            return fighter;
        }
    }
}
