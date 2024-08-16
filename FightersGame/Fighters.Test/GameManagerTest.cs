using Fighters.Models.Armors;
using Fighters.Models.Classes;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Test
{
    [TestFixture]
    public class GameManagerTest
    {
        [Test]
        public void Game_VampireAndHuman_VampireWins()
        {
            // Arrange 
            var gameManager = new GameManager();
            var fighterA = new Fighter( "FighterA", new Vampire(), new Knight() );
            var fighterB = new Fighter( "FighterB", new Human(), new Knight() );

            // Act
            IFighter[] winner = gameManager.Game( fighterA, fighterB );

            // Asssert
            Assert.That( winner[ 0 ].Name, Is.EqualTo( fighterA.Name ) );
        }

        [Test]
        public void Game_StrengthOfWeapon_SecondFighterDies()
        {
            // Arrange 
            var gameManager = new GameManager();
            var fighterA = new Fighter( "FighterA", new Human(), new Knight(), new Hammer(), new LightArmor() );
            var fighterB = new Fighter( "FighterB", new Human(), new Knight(), new Spear(), new LightArmor() );

            // Act
            gameManager.Game( fighterA, fighterB );

            // Asssert
            Assert.That( fighterA.GetCurrentHealth(), Is.GreaterThan( 0 ) );
            Assert.That( fighterB.GetCurrentHealth(), Is.EqualTo( 0 ) );
        }

        [Test]
        public void Game_EqualFighters_IdkWhoDies()
        {
            // Arrange 
            var gameManager = new GameManager();
            var fighterA = new Fighter( "FighterA", new Human(), new Knight(), new Fists(), new LightArmor() );
            var fighterB = new Fighter( "FighterB", new Human(), new Knight(), new Fists(), new LightArmor() );

            // Act
            gameManager.Game( fighterA, fighterB );

            // Asssert
            Assert.That( fighterA.GetCurrentHealth(), Is.GreaterThan( 0 ) );
            Assert.That( fighterB.GetCurrentHealth(), Is.EqualTo( 0 ) );

            //this doesnt work because of lack of user activity in test
        }
    }
}
