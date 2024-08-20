using Accommodations.Commands;
using Accommodations.Dto;

namespace Accommodations;

public static class AccommodationsProcessor
{
    private static BookingService _bookingService = new();
    private static Dictionary<int, ICommand> _executedCommands = new();
    private static int s_commandIndex = 0;

    public static void Run()
    {
        Console.WriteLine( "Booking Command Line Interface" );
        Console.WriteLine( "Commands:" );
        Console.WriteLine( "'book <UserId> <Category> <StartDate> <EndDate> <Currency>' - to book a room" );
        Console.WriteLine( "'cancel <BookingId>' - to cancel a booking" );
        Console.WriteLine( "'undo' - to undo the last command" );
        Console.WriteLine( "'find <BookingId>' - to find a booking by ID" );
        Console.WriteLine( "'search <StartDate> <EndDate> <CategoryName>' - to search bookings" );
        Console.WriteLine( "'exit' - to exit the application" );

        string input;
        while ( ( input = Console.ReadLine() ) != "exit" )
        {
            try
            {
                ProcessCommand( input );
            }
            catch ( ArgumentException ex )
            {
                Console.WriteLine( $"Error: {ex.Message}" );
            }
        }
    }

    private static void ProcessCommand( string input )
    {
        string[] parts = input.Split( ' ' );
        string commandName = parts[ 0 ];

        switch ( commandName )
        {
            case "book":
                if ( parts.Length != 6 )
                {
                    throw new ArgumentException( "Invalid number of arguments for booking." );
                }

                //Добавляем валидацию даты да и всё
                DateTime date1, date2;
                while ( true )
                {
                    if ( IsValidDate( parts[ 3 ], out date1 ) && IsValidDate( parts[ 4 ], out date2 ) )
                    {
                        //book 1 Standard 10/03/2024 12/04/2024 Rub
                        break;
                    }
                    else
                    {
                        Console.WriteLine( "DATE IS NOT CORRECT \nInput both dates again - MM/dd/yyyy" );
                        parts[ 3 ] = Console.ReadLine();
                        parts[ 4 ] = Console.ReadLine();
                    }
                }

                //С валютой выбрасываем обрабатываемое исключение, позволяем исправить ввод и подсказываем
                //метод TryParse позволяет сделать всё безопасно
                CurrencyDto currency = ( CurrencyDto )Enum.Parse( typeof( CurrencyDto ), "Usd", true );// наверно это костыль
                while ( true )
                {
                    try
                    {
                        if ( !Enum.TryParse( typeof( CurrencyDto ), parts[ 5 ], out var result ) )
                        {

                            throw new ArgumentException( $"{parts[ 5 ]} IS NOT AVAILABLE CURRENCY." );
                        }
                        else
                        {
                            currency = ( CurrencyDto )result;
                            break;
                        }
                    }
                    catch ( ArgumentException ex )
                    {
                        Console.WriteLine( ex.Message );
                        Console.WriteLine( "Please, try use such types of currency: Usd, Rub, Cny" );
                        parts[ 5 ] = Console.ReadLine();

                    }
                }

                BookingDto bookingDto = new()
                {
                    UserId = int.Parse( parts[ 1 ] ),
                    Category = parts[ 2 ],
                    StartDate = date1,
                    EndDate = date2,
                    Currency = currency,
                };

                BookCommand bookCommand = new( _bookingService, bookingDto );
                bookCommand.Execute();
                _executedCommands.Add( ++s_commandIndex, bookCommand );
                Console.WriteLine( "Booking command run is successful." );
                break;

            case "cancel":
                if ( parts.Length != 2 )
                {
                    throw new ArgumentException( "Invalid number of arguments for canceling." );
                }

                Guid bookingId = Guid.Parse( parts[ 1 ] );
                CancelBookingCommand cancelCommand = new( _bookingService, bookingId );
                cancelCommand.Execute();
                _executedCommands.Add( ++s_commandIndex, cancelCommand );
                Console.WriteLine( "Cancellation command run is successful." );
                break;

            case "undo":
                if ( s_commandIndex != 0 )//in case empty commands history
                {
                    _executedCommands[ s_commandIndex ].Undo();
                    ICommand lastCmd = _executedCommands[ s_commandIndex ];
                    //когда команда не отменяема, не удаляем из истории команд
                    if ( lastCmd is not FindBookingByIdCommand && lastCmd is not SearchBookingsCommand )
                    {
                        _executedCommands.Remove( s_commandIndex );
                        s_commandIndex--;
                        Console.WriteLine( "Last command undone." );
                    }
                }
                break;

            case "find":
                if ( parts.Length != 2 )
                {
                    throw new ArgumentException( "Invalid arguments for 'find'. Expected format: 'find <BookingId>'" );
                }
                Guid id = Guid.Parse( parts[ 1 ] );
                FindBookingByIdCommand findCommand = new( _bookingService, id );
                findCommand.Execute();
                break;

            case "search":
                if ( parts.Length != 4 )
                {
                    throw new ArgumentException( "Invalid arguments for 'search'. Expected format: 'search <StartDate> <EndDate> <CategoryName>'" );
                }
                DateTime startDate = DateTime.Parse( parts[ 1 ] );
                DateTime endDate = DateTime.Parse( parts[ 2 ] );
                string categoryName = parts[ 3 ];
                SearchBookingsCommand searchCommand = new( _bookingService, startDate, endDate, categoryName );
                searchCommand.Execute();
                break;

            default:
                Console.WriteLine( "Unknown command." );
                break;
        }
    }

    private static bool IsValidDate( string dateString, out DateTime date )
    {
        string[] formats = { "MM/dd/yyyy" };
        return DateTime.TryParseExact( dateString, formats, null, System.Globalization.DateTimeStyles.None, out date );
    }

}
