using System;
using System.Net;
using System.Xml.Linq;

Greetings();
string[] userData = DataRequest();
Console.WriteLine(Message( userData ));

static void Greetings()
{
    Console.WriteLine( "Morning, sir! I,m your shop assistant." );
    Thread.Sleep( 2000 );
}
static string[] DataRequest()
{
    string userName = "";
    int userQuantity = 0;
    string productName = "";
    string userAddress = "";
    bool isConfirmed = false;
    while ( !isConfirmed )
    {
        Console.Write( "Enter the product name: " );
        productName = ReadUserData();
        userQuantity = ReadQuantity();
        Console.Write( "Your name: " );
        userName = ReadUserData();
        Console.Write( "Delivery address: " );
        userAddress = ReadUserData();
        isConfirmed = Confirm( userName, userQuantity, productName, userAddress );
    }

    string[] userData = { userName, userQuantity.ToString(), productName, userAddress };
    return userData;
}
static string ReadUserData() 
{
    string item = Console.ReadLine();
    while ( string.IsNullOrEmpty( item ) )
    {
        item = Console.ReadLine();
    }
    return item;
}    
static int ReadQuantity()
{
    Console.Write( "Enter the quantity: " );
    int quantity;

    while ( !int.TryParse( Console.ReadLine(), out quantity ) )
    {
        Console.WriteLine( "Enter a number, please" );
    }
    return quantity;
}
static bool IsConfirmed( string name, int quantity, string product, string address )
{
    Console.WriteLine( $"{name}, you ordered {product} x {quantity} to deliver to the {address}. Is everything right?" );
    Console.Write( "Write yes/no.. " );
    if ( Console.ReadLine() == "yes" )
    {
        return true;
    }
    else
    {
        return false;
    }
}
static string Message( string[] data )
{
    Thread.Sleep( 2000 );
    DateTime date = DateTime.Today;
    date = date.AddDays( 4 );
    return $"{data[ 0 ]}! Your order #{data[ 2 ]} - {data[ 1 ]} pieces# has been placed successfully!\nIt will be delivered to {data[ 3 ]} by {date.ToString( "d" )}";
    //Console.WriteLine( $"{data[ 0 ]}! Your order #{data[ 2 ]} - {data[ 1 ]} pieces# has been placed successfully!" +
    //    $" It will be delivered to {data[ 3 ]} by {date.ToString( "d" )}" );
}
