using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Gearboxes;
using CarFactory.Models.Shapes;

namespace CarFactory.Models
{
    public class Car : ICar
    {
        private readonly IColor _color;
        private readonly IEngine _engine;
        private readonly IGearbox _gearbox;
        private readonly IShape _shape;
        public string Name { get; private set; }
        public float Price { get; }
        public Car( string name, IColor color, IEngine engine, IShape shape, IGearbox gearbox )
        {
            Name = name;
            _color = color;
            _engine = engine;
            _gearbox = gearbox;
            _shape = shape;

            Price = CalculatePrice( _color, _engine, _shape, _gearbox );
        }

        public string GetAllParams() { return ""; }
        public float CalculatePrice( IColor color, IEngine engine, IShape shape, IGearbox gearbox )
        {
            float price = 0;

            return price;
        }
    }
}
