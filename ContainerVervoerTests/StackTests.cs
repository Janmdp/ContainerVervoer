using ContainerVervoerClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ContainerVervoerClassLibrary.CargoType.Cargo;

namespace ContainerVervoerTests1
{
    [TestClass()]
    public class StackTests
    {
        
        [TestMethod()]
        //Adding the 3rd container does not violate any of the checks and therefore AddContainer should add the
        //3rd container and return true
        public void CheckHeightTestTrue()
        {

            //arrange
            Ship ship = new Ship(1, 1, 1, 100000000);
            ship.Rows.Clear();
            Row row = new Row(true);
            Stack stack = new Stack(3);
            Container container = new Container(1000, Coolable);
            Container container2 = new Container(2000, Normal);
            Container container3 = new Container(3000, Normal);
            //act
            stack.Add(container);
            stack.Add(container2);
            row.Add(stack);
            ship.Rows.Add(row);
            //assert
            Assert.IsTrue(stack.AddContainer(ship, row, container3));
            Assert.AreEqual(3, stack.Count);
        }

        //Adding the 3rd container will only fail the checkHeight check and therefore the container won't be
        //added and AddContainer will return false
        [TestMethod()]
        public void CheckHeightTestFalse()
        {
            //arrange
            Ship ship = new Ship(1,1,1,10000000);
            ship.Rows.Clear();
            Row row = new Row(true);
            Stack stack = new Stack(2);
            Container container = new Container(1000, Coolable);
            Container container2 = new Container(2000, Normal);
            Container container3 = new Container(3000, Normal);
            //act
            stack.Add(container);
            stack.Add(container2);
            row.Add(stack);
            ship.Rows.Add(row);
            //assert
            Assert.IsFalse(stack.AddContainer(ship, row, container3));
            Assert.AreEqual(2, stack.Count);
        }

        [TestMethod()]
        //The maximum weight on top of a container is 120000, this test adds 6000 on top of the already placed
        //6000 thousand and therefore should pass the weight test
        public void CheckWeightTestTrue()
        {
            //arrange
            Ship ship = new Ship(1,1,1,10000000);
            ship.Rows.Clear();
            Row row = new Row(false);
            Stack stack = new Stack(10);
            Container container = new Container(6000, Normal);
            Container container2 = new Container(6000, Normal);
            Container container3 = new Container(6000, Normal);
            //act
            stack.Add(container);
            stack.Add(container2);
            row.Add(stack);
            ship.Rows.Add(row);
            //assert
            Assert.IsTrue(stack.AddContainer(ship, row, container3));
        }

        [TestMethod()]
        //this test adds more than the allowed 120000 kg on top of a container and should therefore fail the
        //weight check.
        public void CheckWeightTestFalse()
        {
            //arrange
            Ship ship = new Ship(1,1,1,10000000);
            ship.Rows.Clear();
            Row row = new Row(false);
            Stack stack = new Stack(10);
            Container container = new Container(6000, Normal);
            Container container2 = new Container(100000, Normal);
            Container container3 = new Container(22000, Normal);
            //act
            stack.Add(container);
            stack.Add(container2);
            row.Add(stack);
            ship.Rows.Add(row);
            //assert
            Assert.IsFalse(stack.AddContainer(ship, row, container3));
        }

        [TestMethod()]
        public void CheckValuableTestTrue()
        {
            //arrange
            Ship ship = new Ship(1,1,1,10000);
            ship.Rows.Clear();
            Row row = new Row(false);
            Stack stack = new Stack(3);
            Container container = new Container(6000, Normal);
            //act
            row.Add(stack);
            ship.Rows.Add(row);
            //assert
            Assert.IsTrue(stack.AddContainer(ship, row, container));
        }

        [TestMethod()]
        //In this test a container will be added to a stack with a valuable container which will move the
        //container upwards and put the container beneath it
        public void CheckValuableTestTrue2()
        {
            //arrange
            Ship ship = new Ship(1,1,1,10000000);
            ship.Rows.Clear();
            Row row = new Row(false);
            Stack stack = new Stack(10);
            Container container = new Container(100, Valuable);
            Container container2 = new Container(100, Normal);
            //act
            row.Add(stack);
            ship.Rows.Add(row);
            stack.AddContainer(ship, row, container);
            int originalIndexValuable = stack.IndexOf(container);
            //assert
            Assert.IsTrue(stack.AddContainer(ship, row, container2));
            Assert.AreNotEqual(originalIndexValuable, stack.IndexOf(container));
            Assert.AreEqual(originalIndexValuable + 1, stack.IndexOf(container));
            Assert.AreEqual(originalIndexValuable, stack.IndexOf(container2));
        }

        [TestMethod()]
        //The valuable container cannot be moved up therefore AddContainer will return false and the
        //container can't be added
        public void CheckValuableTestFalse()
        {
            //arrange
            Ship ship = new Ship(1,1,1,1000000);
            ship.Rows.Clear();
            Row row = new Row(false);
            Stack stack = new Stack(1);
            Container container = new Container(100, Valuable);
            Container container2 = new Container(100, Normal);
            //act
            stack.Add(container);
            row.Add(stack);
            //assert
            Assert.IsFalse(stack.AddContainer(ship, row, container2));
        }

        [TestMethod]
        //The weight of the stack should be equal to the weight of the containers within
        public void CheckUpdateWeightTest()
        {
            //arrange
            Stack stack = new Stack(10);
            Container container = new Container(100, Normal);
            Container container2 = new Container(100, Normal);
            //act
            stack.Add(container);
            stack.Add(container2);
            stack.UpdateWeight();
            //assert
            Assert.AreEqual(200, stack.Weight);
        }

        [TestMethod()]
        //If adding a container does not block in a valuable container or if the container is valuable itself and will not get locked in
        //AddContainer will add the container to a stack and return true
        public void CheckSurroundingsTestTrue()
        {
            //arrange
            Ship ship = new Ship(1, 3, 5, 1000000);
            Container container1 = new Container(100, Normal);
            Container container2 = new Container(100, Normal);
            Container container3 = new Container(100, Normal);
            Container container4 = new Container(100, Normal);
            Container container5 = new Container(100, Normal);
            Container container6 = new Container(100, Normal);
            Container container7 = new Container(100, Valuable);
            //act
            ship.Rows[0][0].Add(container1);
            ship.Rows[1][0].Add(container2);
            ship.Rows[1][0].Add(container3);
            ship.Rows[2][0].Add(container4);
            ship.Rows[3][0].Add(container5);
            ship.Rows[4][0].Add(container6);
            //assert
            Assert.IsTrue(ship.Rows[2][0].AddContainer(ship, ship.Rows[2], container7));
        }
        [TestMethod()]
        //Adding a valuable container to the middle stack will only block it from 1 side and won't block another valuable container
        //so AddContainer will return true
        public void CheckSurroundingsTestTrue2()
        {
            //arrange
            Ship ship = new Ship(1, 3, 5, 1000000);
            Container container1 = new Container(100, Normal);
            Container container2 = new Container(100, Normal);
            Container container3 = new Container(100, Normal);
            Container container4 = new Container(100, Normal);
            Container container5 = new Container(100, Normal);
            Container container6 = new Container(100, Normal);
            Container container7 = new Container(100, Normal);
            Container container8 = new Container(100, Valuable);
            //act
            ship.Rows[0][0].Add(container1);
            ship.Rows[0][0].Add(container2);
            ship.Rows[1][0].Add(container3);
            ship.Rows[1][0].Add(container4);
            ship.Rows[2][0].Add(container5);
            ship.Rows[3][0].Add(container6);
            ship.Rows[4][0].Add(container7);
            //assert
            Assert.IsTrue(ship.Rows[2][0].AddContainer(ship, ship.Rows[2], container8));
        }
        [TestMethod()]
        //Adding a valuable container to the middle stack will only block it from 1 side so AddContainer will return true
        public void CheckSurroundingsTestTrue3()
        {
            //arrange
            Ship ship = new Ship(1, 3, 5, 1000000);
            Container container1 = new Container(100, Normal);
            Container container2 = new Container(100, Normal);
            Container container3 = new Container(100, Normal);
            Container container4 = new Container(100, Normal);
            Container container5 = new Container(100, Normal);
            Container container6 = new Container(100, Normal);
            Container container7 = new Container(100, Valuable);
            //act
            ship.Rows[0][0].Add(container1);
            ship.Rows[1][0].Add(container2);
            ship.Rows[1][0].Add(container3);
            ship.Rows[2][0].Add(container4);
            ship.Rows[3][0].Add(container5);
            ship.Rows[4][0].Add(container6);
            //assert
            Assert.IsTrue(ship.Rows[2][0].AddContainer(ship, ship.Rows[2], container7));
        }


        [TestMethod()]
        //If a valuable container gets added to the middle stack it will be blocked so AddContainer should return false
        public void CheckSurroundingsTestFalse()
        {
            //arrange
            Ship ship = new Ship(1, 3, 3, 1000000);
            Container container1 = new Container(100, Normal);
            Container container2 = new Container(100, Normal);
            Container container3 = new Container(100, Normal);
            Container container4 = new Container(100, Normal);
            Container container5 = new Container(100, Normal);
            Container container6 = new Container(100, Valuable);
            //act
            ship.Rows[0][0].Add(container1);
            ship.Rows[0][0].Add(container2);
            ship.Rows[1][0].Add(container3);
            ship.Rows[2][0].Add(container4);
            ship.Rows[2][0].Add(container5);
            //assert
            Assert.IsFalse(ship.Rows[1][0].AddContainer(ship, ship.Rows[1], container6));
        }

        [TestMethod()]
        //Adding a container to the 3rd stack will block in a valuable container so AddContainer should return false
        public void CheckSurroundingsTestFalse2()
        {
            Ship ship = new Ship(1, 3, 3, 1000000);
            Container container1 = new Container(100, Normal);
            Container container2 = new Container(100, Normal);
            Container container3 = new Container(100, Normal);
            Container container4 = new Container(100, Valuable);
            Container container5 = new Container(100, Normal);
            Container container6 = new Container(100, Normal);
            ship.Rows[0][0].Add(container1);
            ship.Rows[0][0].Add(container2);
            ship.Rows[1][0].Add(container3);
            ship.Rows[1][0].Add(container4);
            ship.Rows[2][0].Add(container5);
            Assert.IsFalse(ship.Rows[2][0].AddContainer(ship, ship.Rows[2], container6));
        }
    }
}