/*### Требования
Реализовать фабрику машин, которая выпускает разные марки машин с разными конфигурациями

### Критерии минимума
* \>= 2 различных цветов машин
* \>= 2 различных форм кузовов
* \>= 2 различных двигателя
* \>= 2 различных коробок передач
* Должен быть вывод конфигурации в консоль
* Конфигурировать машину можно в коде, но лучше через какой-нибудь UI (использовать библиотеки для работы с вводом в консольное приложение можно)
* От выбранной конфигурации меняется максимальная скорость и количество передач*/
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
                Console.WriteLine( "Player1, what's your name?" );

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