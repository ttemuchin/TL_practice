using Fighters.Models.Classes;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Extensions
{
    public static class IFighterExtensions
    {
        public static bool IsAlive( this IFighter fighter ) => fighter.GetCurrentHealth() > 0;

/*        public Fighter Configuration( IRace race, IClass user_class, IWeapon weapon )
        {
            var fighter = new Fighter();
            return fighter;
        }*/
    }
}
