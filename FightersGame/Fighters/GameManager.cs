using Fighters.Extensions;
using Fighters.Models.Fighters;

namespace Fighters
{
    public class GameManager
    {
        public IFighter[] Game( IFighter player1, IFighter player2 )
        {
            int round = 1;
            while ( true )
            {
                int[] currentParams;
                Console.WriteLine( $"Round {round}" );

                var p1Damage = player1.CalculateDamage();
                currentParams = player2.TakeDamage( p1Damage );
                Console.WriteLine( $"{player2.Name} takes {currentParams[ 0 ]} damage. HP: {currentParams[ 1 ]}" );
                if ( !player2.IsAlive() )
                {
                    return [ player1, player2 ];
                }

                var p2Damage = player2.CalculateDamage();
                currentParams = player1.TakeDamage( p2Damage );
                Console.WriteLine( $"{player1.Name} takes {currentParams[ 0 ]} damage. HP: {currentParams[ 1 ]}" );
                if ( !player1.IsAlive() )
                {
                    return [ player2, player1 ];
                }
                round++;
            }
        }
    }
}
