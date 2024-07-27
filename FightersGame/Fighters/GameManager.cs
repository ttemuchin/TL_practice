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
                var initiate = false; //gives user a choice
                var rand = new Random();

                Console.WriteLine( $"\nRound {round}" );
                //Thread.Sleep( 1000 );
                Console.WriteLine( $"{player1.Name}'s Turn" );
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
                var p1Damage = player1.CalculateDamage();

                if ( initiate )
                {
                    if ( Math.Round( rand.NextDouble(), 2 ) >= 0.88 )
                    {
                        Console.WriteLine( "Successful attack! Damage doubles" );
                        p1Damage = p1Damage * 2;
                    }
                    else
                    {
                        p1Damage = 0;
                        Console.WriteLine( "Unluck! Damage = 0" );
                    }
                    initiate = false;
                }

                currentParams = player2.TakeDamage( p1Damage );
                Console.WriteLine( $"{player2.Name} takes {currentParams[ 0 ]} damage. HP: {currentParams[ 1 ]}" );
                if ( currentParams[ 2 ] == 1 )
                {
                    Console.WriteLine( "Critical damage 200%! Nobody can't stand this" );
                }
                if ( !player2.IsAlive() )
                {
                    return [ player1, player2 ];
                }
                //Console.ReadKey( true );

                Console.WriteLine( $"\n{player2.Name}'s Turn" );
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
                var p2Damage = player2.CalculateDamage();

                if ( initiate )
                {
                    if ( Math.Round( rand.NextDouble(), 2 ) >= 0.88 )
                    {
                        Console.WriteLine( "Successful attack! Damage doubles" );
                        p2Damage = p2Damage * 2;
                    }
                    else
                    {
                        p2Damage = 0;
                        Console.WriteLine( "Unluck! Damage = 0" );
                    }
                }
                currentParams = player1.TakeDamage( p2Damage );
                Console.WriteLine( $"{player1.Name} takes {currentParams[ 0 ]} damage. HP: {currentParams[ 1 ]}" );
                if ( currentParams[ 2 ] == 1 )
                {
                    Console.WriteLine( "Critical damage 200%! Nobody can't stand this" );
                }
                if ( !player1.IsAlive() )
                {
                    return [ player2, player1 ];
                }
                // Console.ReadKey( true );
                round++;
            }
        }
    }
}
