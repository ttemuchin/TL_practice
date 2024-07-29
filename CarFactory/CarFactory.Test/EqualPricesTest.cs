using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.Gearboxes;
using CarFactory.Models.Shapes;

namespace CarFactory.Test
{
    [TestFixture]
    public class EqualPricesTest
    {
        [Test]
        public void EqualPrices()
        {
            //Arrange
            var BM = new BuildManager();

            //Act
            var car = BM.Build( new Models.Car( "model", new Pink(), new PG3090(), new SUV(), new CVT() ) );

            //Assert
            Assert.That( car.Price, Is.EqualTo( car.CalculatePrice()[ 1 ] ) );
        }

        [Test]
        public void SpeedCalcTest()
        {
            //Arrange
            var BM = new BuildManager();
            var suv = new Models.Car( "suv", new Black(), new PG3090(), new SUV(), new CVT() );
            var lightCar = new Models.Car( "light", new White(), new PG3090(), new Sedan(), new CVT() );

            //Act
            var speed1 = suv.CalculateSpeed();
            var speed2 = lightCar.CalculateSpeed();

            //Assert
            Assert.That( speed2, Is.GreaterThan( speed1 ) );
        }
    }
}
