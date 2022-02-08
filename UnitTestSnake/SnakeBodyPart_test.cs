using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake;
using Xunit;
namespace UnitTestSnake
{
    public class SnakeBodyPart_test
    {
        GameWorld world;
        public SnakeBodyPart_test()
        {
         world = new GameWorld(20, 20);
        }

        [Fact]
        public void CreatingOneBodypart_y3()
        {
            //Arrange   
            Player p = new Player();
            //act - Snake should move Left

            p.Update(); //Simulate eating player.position (3,4)
            PlayerBodyPart Test = new PlayerBodyPart(p.Positions.Count()-1, p);
            p.points.AddPoints();
            Test.Update();
            //Assert
            Assert.Equal(3, Test.position.y);
            Assert.Equal(4, p.position.y);

        }

        [Fact]
        public void BodyPartAfter3SomeMoves_y5()
        {
            //Arrange   
            Player p = new Player();//player pos 3,3 Direction down
            world.gameObjects.Add(p);
            //act - Snake should move Left

            world.Update(); //player.position (3,4)
            PlayerBodyPart Test = new PlayerBodyPart(p.Positions.Count()-1, p);
            world.gameObjects.Add(Test);

            p.points.AddPoints();
            world.Update(); // p(3, 5)
            world.Update();

            //Assert
         
            Assert.Equal(5, Test.position.y);
            Assert.Equal(6, p.position.y);

        }
        [Fact]
        public void Testing3BodyParts()
        {
            //Arrange   
            Player p = new Player();//player pos 3,3 Direction down
            world.gameObjects.Add(p);
            //act - Snake should move Left

            world.Update(); //player.position (3,4)
            PlayerBodyPart Test = new PlayerBodyPart(p.Positions.Count()-1, p);
            world.gameObjects.Add(Test);
            p.points.AddPoints();
            world.Update(); // p(3, 5)
            PlayerBodyPart Test2 = new PlayerBodyPart(p.Positions.Count()-1, p);
            world.gameObjects.Add(Test2);
            p.points.AddPoints();
            world.Update();
            PlayerBodyPart Test3 = new PlayerBodyPart(p.Positions.Count()-1, p);
            world.gameObjects.Add(Test3);
            p.points.AddPoints();

            int resultat = 0;
            foreach(var part in world.gameObjects)
            {
                if (part is PlayerBodyPart)
                    resultat++;
            }
            //Assert

            Assert.Equal(3, resultat);
            Assert.Equal(5, Test.position.y);
            Assert.Equal(4, Test2.position.y);
            Assert.Equal(3, Test3.position.y);

        }
    }
}
