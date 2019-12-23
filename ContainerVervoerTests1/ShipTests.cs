using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ContainerVervoerClassLibrary.CargoType.Cargo;
using ContainerVervoerClassLibrary;
namespace ContainerVervoer.Tests
{
    [TestClass()]
    public class ShipTests
    {
        [TestMethod()]
        //The generate contents is used in the constructor of the ship
        public void GenerateContentsTest()
        {
            //arrange
            int height = 10;
            int width = 10;
            int length = 10;
            int maxWeight = 1000;
            //arrange / act
            Ship ship = new Ship(width, height, length, maxWeight);
            //assert
            Assert.AreEqual(height, ship.Rows[0][0].MaxHeight);
            Assert.AreEqual(width, ship.Width);
            Assert.AreEqual(length, ship.Length);
            Assert.AreEqual(maxWeight, ship.MaxWeight);
        }

        [TestMethod]
        //The ships weight is equal to the weight of the rows on the ship, which is equal to the weight of
        //the stacks in the row which is equal to the weight of the containers in the stack
        public void UpdateWeightTest()
        {
            //arrange
            Ship ship = new Ship(1, 1, 1, 1000000000);
            Container container = new Container(1000, CargoType.Cargo.Normal);
            //act
            ship.Rows[0][0].AddContainer(ship, ship.Rows[0], container);
            ship.Rows[0][0].UpdateWeight();
            ship.Rows[0].UpdateWeight();
            ship.UpdateWeight();
            //assert
            Assert.AreEqual(1000, ship.Weight);
            Assert.AreEqual(container.Weight, ship.Weight);
        }

        [TestMethod]
        //By adding the container the weight of the ship will exceed the maximum allow weight
        public void AddContainerTestTrue()
        {
            //arrange
            Ship ship = new Ship(1, 1, 1, 1);
            Container container = new Container(1, Normal);
            //act / assert
            Assert.IsTrue(ship.AddContainer(container));
        }

        [TestMethod]
        //The container should be added to the lightest row
        public void AddContainerTestTrue2()
        {
            //arrange
            Ship ship = new Ship(1, 3, 2, 1000);
            Container container = new Container(10, Normal);
            Container container2 = new Container(10, Normal);
            Container container3 = new Container(30, Normal);
            Container container4 = new Container(5, Normal);
            //act
            ship.Rows[0][0].Add(container);
            ship.Rows[0][0].Add(container2);
            ship.Rows[1][0].Add(container3);
            //Assert
            Assert.IsTrue(ship.AddContainer(container4));
            Assert.AreEqual(3, ship.Rows[0][0].Count);
        }

        [TestMethod]
        //Cooled containers can only be added to cooled rows, which is always the first row of a ship
        public void AddContainerTestTrue3()
        {
            //arrange
            Ship ship = new Ship(1, 3, 2, 1000);
            Container container = new Container(20, Normal);
            Container container2 = new Container(20, Normal);
            Container container3 = new Container(30, Normal);
            Container container4 = new Container(5, Coolable);
            //act
            ship.Rows[0][0].Add(container);
            ship.Rows[0][0].Add(container2);
            ship.Rows[1][0].Add(container3);
            //Assert
            Assert.IsTrue(ship.AddContainer(container4));
            Assert.AreEqual(3, ship.Rows[0][0].Count);
        }

        [TestMethod]
        //A container can't be added to the ship if it causes the weight to go over the maximum
        public void AddContainerTestFalse()
        {
            //arrange
            Ship ship = new Ship(1, 1, 1, 1);
            Container container = new Container(2, Normal);
            //act / assert
            Assert.IsFalse(ship.AddContainer(container));
        }

        [TestMethod]
        //Cooled containers can only be added to cooled rows, which is always the first row of a ship
        public void AddContainerTestFalse2()
        {
            //arrange
            Ship ship = new Ship(1, 2, 2, 1000);
            Container container = new Container(20, Normal);
            Container container2 = new Container(20, Normal);
            Container container3 = new Container(30, Normal);
            Container container4 = new Container(5, Coolable);
            //act
            ship.Rows[0][0].Add(container);
            ship.Rows[0][0].Add(container2);
            ship.Rows[1][0].Add(container3);
            //Assert
            Assert.IsFalse(ship.AddContainer(container4));
            Assert.AreEqual(2, ship.Rows[0][0].Count);
            Assert.AreEqual(1, ship.Rows[1][0].Count);
        }
    }
}