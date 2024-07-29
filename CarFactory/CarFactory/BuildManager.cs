using CarFactory.Models;

namespace CarFactory
{
    public class BuildManager
    {
        public void Build( Car car )
        {
            Console.WriteLine( car.GetAllParams() );
            var prices = car.CalculatePrice();
            Console.WriteLine( $"The build of your model costs ${prices[ 0 ]} millions\nAnd in case of car accident you might pay us ${prices[ 1 ]}m. to repair it!" );
        }
    }
}
