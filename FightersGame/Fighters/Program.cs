using Fighters.Models.Races;
using Fighters.Models.Fighters;
using Fighters.Models.Classes;

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


                    var gameManager = new GameManager();
                    var result = gameManager.Game(
                        new Fighter( "name1", new Human(), new Knight() ),
                        new Fighter( "name2", new Human(), new Knight() ) );
                    Console.WriteLine( $"What a great sorrow - {result[ 1 ].Name} has fallen in battle..\n" +
                        $"{result[ 0 ].Name} stayed alive and won" );
                    Console.WriteLine( "Would you like to start New game?" );


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
