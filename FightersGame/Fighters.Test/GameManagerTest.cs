using Fighters.Models.Fighters;
using Fighters.Models.Races;

namespace Fighters.Test
{
    [TestFixture]
    public class GameManagerTest
    {
        [Test]
        public void Play_TwoEqualFighters_FirstFighterWins()
        {
            // Arrange 
            var gameManager = new GameManager();
            var fighterA = new Fighter( "FighterA", new Human() );
            var fighterB = new Fighter( "FighterB", new Human() );

            // Act
            var winner = gameManager.Game( fighterA, fighterB );

            // Asssert
            Assert.That( winner[ 0 ].Name, Is.EqualTo( fighterA.Name ) );
        }

        [Test]
        public void Play_TwoEqualFighters_SecondFighterDies()
        {
            // Arrange 
            var gameManager = new GameManager();
            var fighterA = new Fighter( "FighterA", new Human() );
            var fighterB = new Fighter( "FighterB", new Human() );

            // Act
            gameManager.Game( fighterA, fighterB );

            // Asssert
            Assert.That( fighterA.GetCurrentHealth(), Is.GreaterThan( 0 ) );
            Assert.That( fighterB.GetCurrentHealth(), Is.EqualTo( 0 ) );
        }
    }
}
