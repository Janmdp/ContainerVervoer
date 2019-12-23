using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ContainerVervoerClassLibrary.CargoType.Cargo;
using ContainerVervoerClassLibrary;

namespace ContainerVervoer.Tests
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
    }
}