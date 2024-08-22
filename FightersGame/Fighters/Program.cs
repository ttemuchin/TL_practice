using Fighters.Models.Races;
using Fighters.Models.Fighters;
using Fighters.Models.Classes;
using Fighters.Extensions;

namespace Fighters
{
    public class Program
    {
        public static void Main( string[] args )
        {
            Console.WriteLine( "Welcome to BattleNetwork! Would you like to start New game?" );
            while ( true )
            {
                Console.Write( "Press 'y' to play or 'q' to quit.. " );

                if ( Console.ReadKey( true ).Key == ConsoleKey.Y )
                {
                    Console.WriteLine( "yes" );
                    Console.WriteLine( "Player1, what's your name?" );
                    var config = new Configuration();
                    var p1data = config.AskUserData();
                    Console.WriteLine( "\nPlayer2, what's your name?" );
                    var p2data = config.AskUserData();

                    var player1 = config.SetPlayerConfig( p1data );
                    var player2 = config.SetPlayerConfig( p2data );

                    var gameManager = new GameManager();
                    var result = gameManager.Game( player1, player2 );

                    Console.WriteLine( $"What a great sorrow - {result[ 1 ].Name} has fallen in battle..\n" +
                        $"{result[ 0 ].Name} stayed alive and won" );
                    Console.WriteLine( "\nWould you like to start New game?" );

                }
                else
                {
                    Console.WriteLine( "quit" );
                    break;
                }
            }
        }
    }
}
