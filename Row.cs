using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ContainerVervoer.CargoType.Cargo;

namespace ContainerVervoer
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
        //methods
        public void UpdateWeight()
        {
            this.weight = 0;
            foreach (Stack stack in this )
            {
                this.weight = this.weight + stack.Weight;
            }
        }
        public void GenerateStacks(int amount, int height)
        {
            for (int i = 0; i < amount; i++)
            {
               Stack stack = new Stack(height);
               this.Add(stack);

            }
        }

        public bool CheckStacks(Container container)
        {
            foreach (Stack stack in this.OrderBy(s => s.Weight))
            {
                if (stack.AddContainer(container))
                {
                    MessageBox.Show($"Container has been added to Stack {stack.Id}");
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
