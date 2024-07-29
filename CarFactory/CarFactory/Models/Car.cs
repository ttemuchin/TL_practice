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
        public float RepairPrice { get; }
        private float RepairConst = 0.5f;
        public Car( string name, IColor color, IEngine engine, IShape shape, IGearbox gearbox )
        {
            Name = name;
            _color = color;
            _engine = engine;
            _gearbox = gearbox;
            _shape = shape;

            Price = color.Price + engine.Price + shape.Price + gearbox.Price;
            RepairPrice = color.RepairPrice + engine.RepairPrice + shape.RepairPrice + gearbox.RepairPrice;
        }

        public string GetAllParams()
        {
            return $"Your uniqe model - '{Name}'\nEngine: {_engine.Engine}\nGearbox: {_gearbox.Gearbox} with {_gearbox.NumOfGears} gears\nShape: {_shape.Shape}\nColor: {_color.Color}";
        }
        public float[] CalculatePrice()
        {
            float repairPrice = RepairPrice + RepairConst;
            return [ Price, repairPrice ];
        }
        public int CalculateSpeed()
        {
            var speed = _engine.Power * 20 + 40 - _shape.Resistance * 4;
            return speed;
        }
    }
}
