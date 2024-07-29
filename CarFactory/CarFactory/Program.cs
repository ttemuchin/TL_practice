//Фабрика позволяет собрать свою модель и узнать её стоимость.
//Сначала вывод конфигурации в консоль, потом считаем и показываем сумму сборки и полного ремонта
//Есть простенькое взаимодействие параметров в расчетах и NUnit тесты
using CarFactory;
using CarFactory.Extensions;

public class Program
{
    public static void Main( string[] args )
    {
        Console.WriteLine( "Welcome to CarFactory! Let's build something special for you" );
        while ( true )
        {
            Console.Write( "Press 's' to start or 'q' to quit.. " );

            if ( Console.ReadKey( true ).Key == ConsoleKey.S )
            {
                Console.WriteLine( "start" );
                var config = new Configuration();

                var userData = config.AskUserData();
                var car = config.SetCarConfiguration( userData );
                var BM = new BuildManager();
                BM.Build( car );

                Console.WriteLine( "\nWould you like to start New Build?" );
            }
            else
            {
                Console.WriteLine( "quit" );
                break;
            }
        }
    }
}
