using ContainerVervoerClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ContainerVervoerClassLibrary.CargoType.Cargo;

namespace ContainerVervoerTests1
{
    [TestClass()]
    public class RowTests
    {
        [TestMethod()]
        //The weight of the row should be equal to the weight of the stacks within the row
        public void UpdateWeightTestTrue()
        {
            //arrange
            Row row = new Row(false);
            Stack stack = new Stack(10);
            Container container = new Container(100, Normal);
            Container container2 = new Container(100, Normal);
            //act
            stack.Add(container);
            stack.Add(container2);
            stack.UpdateWeight();
            row.Add(stack);
            row.UpdateWeight();
            //assert
            Assert.AreEqual(200, row.Weight);
            Assert.AreEqual(stack.Weight, row.Weight);
        }

        [TestMethod]
        //Generates stacks within the row based on the specified amounts, the maxHeight of the stack is
        //determined by the height given in the parameter
        public void GenerateStacksTest()
        {
            //arrange
            Row row = new Row(false);
            int amount = 3;
            int height = 3;
            //act
            row.GenerateStacks(amount, height);
            //assert
            Assert.AreEqual(amount, row.Count);
            foreach (Stack stack in row)
            {
                Assert.AreEqual(height, stack.MaxHeight);
            }
        }

        [TestMethod]
        //the CheckStacks method checks the stacks and adds a container if possible
        public void CheckStacksTestTrue()
        {
            //arrange
            Ship ship = new Ship(1,1,1, 10000);
            ship.Rows.Clear();
            Row row = new Row(true);
            Stack stack = new Stack(2);
            Container container = new Container(100, Normal);
            Container container2 = new Container(100, Normal);
            //act
            stack.Add(container);
            row.Add(stack);
            ship.Rows.Add(row);
            //assert
            Assert.IsTrue(row.CheckStacks(container2, ship));
            Assert.AreEqual(2, row[0].Count);
        }

        [TestMethod]
        //The CheckStacks method is supposed to add the container to the lightest stack in the row
        public void CheckStacksTestTrue2()
        {
            //arrange
            Ship ship = new Ship(1,1,1,10000);
            ship.Rows.Clear();
            Row row = new Row(true);
            Stack stack = new Stack(2);
            Stack stack2 = new Stack(2);
            Container container = new Container(100, Normal);
            Container container2 = new Container(100, Normal);
            //act
            stack.Add(container);
            stack.UpdateWeight();
            row.Add(stack);
            row.UpdateWeight();
            row.Add(stack2);
            ship.Rows.Add(row);
            //assert
            Assert.IsTrue(row.CheckStacks(container2, ship));
            Assert.AreEqual(1, row[1].Count);
        }

        [TestMethod]
        //If the container cannot be added to any of the stacks in the row CheckStacks will return false
        public void CheckStacksTestFalse()
        {
            //arrange
            Ship ship = new Ship(1,1,1,1000000);
            ship.Rows.Clear();
            Row row = new Row(true);
            Stack stack = new Stack(1);
            Container container = new Container(100, Normal);
            Container container2 = new Container(100, Normal);
            //act
            stack.Add(container);
            row.Add(stack);
            ship.Rows.Add(row);
            //assert
            Assert.IsFalse(row.CheckStacks(container2, ship));
            Assert.AreEqual(1, row[0].Count);
        }

        [TestMethod]
        //The ship usually adds a container to the lightest stack which in this case is the empty stack 2 however when the ship
        //checks the weight of both sides of the ship it sees that the left side is heavier than the right side and will only 
        //attempt to add the container to the right side of the ship
        public void ChooseSideTestTrue()
        {
            Ship ship = new Ship(1, 1, 1, 1000000);
            ship.Rows.Clear();
            Row row = new Row(false);
            Stack stack1 = new Stack(3);
            Stack stack2 = new Stack(3);
            Stack stack3 = new Stack(3);
            Stack stack4 = new Stack(3);
            Container container1 = new Container(500, Normal);
            Container container2 = new Container(100, Normal);
            Container container3 = new Container(100, Normal);
            Container container4 = new Container(100, Normal);
            stack1.Add(container1);
            stack3.Add(container2);
            stack4.Add(container3);
            row.Add(stack1);
            row.Add(stack2);
            row.Add(stack3);
            row.Add(stack4);
            ship.Rows.Add(row);
            ship.UpdateWeight();
            Assert.AreEqual(0, ship.Rows[0][1].Count);
            Assert.AreEqual(1, ship.Rows[0][2].Count);
            Assert.IsTrue(ship.AddContainer(container3));
            Assert.AreEqual(0, ship.Rows[0][1].Count);
            Assert.AreEqual(2, ship.Rows[0][2].Count);
        }

        [TestMethod]
        //In this case the ship tries to add the container to the lightest side which is the already full right side
        //which means the container cannot be added
        public void ChooseSideTestFalse()
        {
            Ship ship = new Ship(1, 1, 1, 1000000);
            ship.Rows.Clear();
            Row row = new Row(false);
            Stack stack1 = new Stack(1);
            Stack stack2 = new Stack(1);
            Stack stack3 = new Stack(1);
            Stack stack4 = new Stack(1);
            Container container1 = new Container(500, Normal);
            Container container2 = new Container(100, Normal);
            Container container3 = new Container(100, Normal);
            Container container4 = new Container(100, Normal);
            stack1.Add(container1);
            stack3.Add(container2);
            stack4.Add(container3);
            row.Add(stack1);
            row.Add(stack2);
            row.Add(stack3);
            row.Add(stack4);
            ship.Rows.Add(row);
            ship.UpdateWeight();
            Assert.AreEqual(0, ship.Rows[0][1].Count);
            Assert.AreEqual(1, ship.Rows[0][2].Count);
            Assert.IsFalse(ship.AddContainer(container3));
            Assert.AreEqual(0, ship.Rows[0][1].Count);
            Assert.AreEqual(1, ship.Rows[0][2].Count);
        }
    }
}