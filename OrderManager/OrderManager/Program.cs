using System;
using System.Net;
using System.Xml.Linq;

Greetings();
string[] userData = DataRequest();
Message( userData );

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
    bool flag = false;
    while ( !flag )
    {
        productName = ReadProductName();
        userQuantity = ReadQuantity();
        userName = ReadUserName();
        userAddress = ReadAddress();
        flag = Confirm( userName, userQuantity, productName, userAddress );
    }

    string[] userData = { userName, userQuantity.ToString(), productName, userAddress };
    return userData;
}

static string ReadProductName()
{
    Console.Write( "Enter the product name: " );
    string product = Console.ReadLine();
    while ( string.IsNullOrEmpty( product ) )
    {
        product = Console.ReadLine();
    }
    return product;
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
static string ReadUserName()
{
    Console.Write( "Your name: " );
    string userName = Console.ReadLine();
    while ( string.IsNullOrEmpty( userName ) )
    {
        userName = Console.ReadLine();
    }
    return userName;
}
static string ReadAddress()
{
    Console.Write( "Delivery address: " );
    string address = Console.ReadLine();
    while ( string.IsNullOrEmpty( address ) )
    {
        address = Console.ReadLine();
    }
    return address;
}
static bool Confirm( string name, int quantity, string product, string address )
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
static void Message( string[] data )
{
    Thread.Sleep( 2000 );
    DateTime date = DateTime.Today;
    date = date.AddDays( 4 );
    Console.WriteLine( $"{data[ 0 ]}! Your order #{data[ 2 ]} - {data[ 1 ]} pieces# has been placed successfully!" +
        $" It will be delivered to {data[ 3 ]} by {date.ToString( "d" )}" );
}
