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
                Console.WriteLine( $"\nRound {round}" );
                Thread.Sleep( 1000 );

                int p1Damage = MakeTurn( player1, round );
                PrintCurrentHP( player2, p1Damage );
                if ( !player2.IsAlive() )
                {
                    return [ player1, player2 ];
                }

                int p2Damage = MakeTurn( player2, round );
                PrintCurrentHP( player1, p2Damage );
                if ( !player1.IsAlive() )
                {
                    return [ player2, player1 ];
                }
                round++;
            }
        }

        public int MakeTurn( IFighter player, int round )
        {
            var rand = new Random();
            bool initiate = false;
            float successfulInitChance = 0.88f;
            int increaseFactor = 2;

            Console.WriteLine( $"\n{player.Name}'s Turn" );
            if ( round >= 10 )
            {
                Console.Write( $"Would you like to try your fortune and overcome your enemy by attacking from the back?\n" +
                "In case of failure, you will not cause damage at all! Press 'y' or 'n'.." );
                if ( Console.ReadKey( true ).Key == ConsoleKey.Y )
                {
                    Console.WriteLine( "yes\n" );
                    initiate = true;
                }
                else { Console.WriteLine( "no\n" ); }
            }
            var playerDamage = player.CalculateDamage();

            if ( initiate )
            {
                if ( Math.Round( rand.NextDouble(), 2 ) >= successfulInitChance )
                {
                    Console.WriteLine( "Successful attack! Damage doubles" );
                    playerDamage = playerDamage * increaseFactor;
                }
                else
                {
                    playerDamage = 0;
                    Console.WriteLine( "Unluck! Damage = 0" );
                }
            }

            return playerDamage;
        }

        public void PrintCurrentHP( IFighter player, int damage )
        {
            int[] currentParams;

            currentParams = player.TakeDamage( damage );
            Console.WriteLine( $"{player.Name} takes {currentParams[ 0 ]} damage. HP: {currentParams[ 1 ]}" );
            if ( currentParams[ 2 ] == 1 )
            {
                Console.WriteLine( "Critical damage 200%! Nobody can't stand this" );
            }
        }
    }
}
