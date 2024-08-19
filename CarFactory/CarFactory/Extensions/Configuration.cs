using CarFactory.Models;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Gearboxes;
using CarFactory.Models.Shapes;

namespace CarFactory.Extensions
{
    public class Configuration
    {
        private string _model;
        private string _color;
        private string _engine;
        private string _gearbox;
        private string _shape;

        public Configuration AskUserData()
        {
            var config = new Configuration();
            Console.WriteLine( "Choose the type of car's engine: (ggko800 or pg3090)" );
            config._engine = Console.ReadLine();
            Console.WriteLine( "Choose the gearbox: (mkpp, akpp or cvt)" );
            config._gearbox = Console.ReadLine();
            Console.WriteLine( "Choose the shape of car's truck: (suv, sedan or hatchback)" );
            config._shape = Console.ReadLine();
            Console.WriteLine( "Choose a color: (black, white, pink are available)" );
            config._color = Console.ReadLine();
            Console.WriteLine( $"And finaly type name of the model:" );
            config._model = Console.ReadLine();
            Console.WriteLine( "Successful build!" );

            return config;
        }

        public Car SetCarConfiguration( Configuration userData )
        {
            IEngine engine = null;
            switch ( userData._engine )
            {
                case "ggko800":
                    engine = new GGKO800();
                    break;
                default:
                    engine = new PG3090();
                    break;
            }

            IColor color = null;
            switch ( userData._color )
            {
                case "pink":
                    color = new Pink();
                    break;
                case "black":
                    color = new Black();
                    break;
                default:
                    color = new White();
                    break;
            }

            IShape shape = null;
            switch ( userData._shape )
            {
                case "suv":
                    shape = new SUV();
                    break;
                case "sedan":
                    shape = new Sedan();
                    break;
                default:
                    shape = new Hatchback();
                    break;
            }

            IGearbox gearbox = null;
            switch ( userData._gearbox )
            {
                case "akpp":
                    gearbox = new AKPP();
                    break;
                case "cvt":
                    gearbox = new CVT();
                    break;
                default:
                    gearbox = new MKPP();
                    break;
            }

            var car = new Car( userData._model, color, engine, shape, gearbox );
            return car;
        }
    }
}
