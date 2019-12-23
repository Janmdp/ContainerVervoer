using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoerClassLibrary
{
    public class Row : List<Stack>
    {
        //fields
        private bool cooled;

        private int weight;
        private int id;
        private static int nextId = 1;

        //methods
        public Row(bool cooled)
        {
            this.cooled = cooled;
            this.id = nextId;
            nextId++;
        }

        //properties
        public bool Cooled { get => cooled; }

        public int Weight { get => weight; }
        public int Id { get => id; }

        //methods
        //Update the weight of the row
        public void UpdateWeight()
        {
            this.weight = 0;
            foreach (Stack stack in this)
            {
                this.weight = this.weight + stack.Weight;
            }
        }

        //Generate stacks based on the given parameters
        public void GenerateStacks(int amount, int height)
        {
            for (int i = 0; i < amount; i++)
            {
                Stack stack = new Stack(height);
                this.Add(stack);
            }
        }

        //Check if there are stacks the container can be added to and adds the container
        public bool CheckStacks(Container container, Ship ship)
        {
            //Loop through the stacks based on weight
            foreach (Stack stack in this.OrderBy(s => s.Weight))
            {
                //Try to add the container to a stack
                if (stack.AddContainer(ship, this, container))
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return $"Row {id}";
        }
    }
}