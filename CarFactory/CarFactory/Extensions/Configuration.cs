using System.Security.Cryptography;
using System;
using CarFactory.Models;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Gearboxes;
using CarFactory.Models.Shapes;
using System.Net.NetworkInformation;

namespace CarFactory.Extensions
{
    public class Configuration
    {
        public Dictionary<string, string> AskUserData()
        {
            var userData = new Dictionary<string, string>();
            Console.WriteLine( "Choose the type of car's engine: (ggko800 or pg3090)" );
            userData.Add( "engine", Console.ReadLine() );
            Console.WriteLine( "Choose the gearbox: (mkpp, akpp or cvt)" );
            userData.Add( "gearbox", Console.ReadLine() );
            Console.WriteLine( "Choose the shape of car's truck: (suv, sedan or hatchback)" );
            userData.Add( "shape", Console.ReadLine() );
            Console.WriteLine( "Choose a color: (black, white, pink are available)" );
            userData.Add( "color", Console.ReadLine() );
            Console.WriteLine( $"And finaly type name of the model:" );
            userData.Add( "model", Console.ReadLine() );
            Console.WriteLine( "Successful build!" );

            return userData;
        }

        public Car SetCarConfiguration( Dictionary<string, string> userData )
        {
            var engine = new Object();
            if ( userData[ "engine" ] == "ggko800" ) { engine = new GGKO800(); }
            else { engine = new PG3090(); }

            var color = new Object();
            if ( userData[ "color" ] == "pink" ) { color = new Pink(); }
            else if ( userData[ "color" ] == "black" ) { color = new Black(); }
            else { color = new White(); }

            var shape = new Object();
            if ( userData[ "shape" ] == "suv" ) { shape = new SUV(); }
            else if ( userData[ "shape" ] == "sedan" ) { shape = new Sedan(); }
            else { shape = new Hatchback(); }

            var gearbox = new Object();
            if ( userData[ "gearbox" ] == "akpp" ) { gearbox = new AKPP(); }
            else if ( userData[ "gearbox" ] == "cvt" ) { gearbox = new CVT(); }
            else { gearbox = new MKPP(); }

            var car = new Car( userData[ "model" ], ( IColor )color, ( IEngine )engine, ( IShape )shape, ( IGearbox )gearbox );
            return car;
        }
    }
}
