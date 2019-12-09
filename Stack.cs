using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ContainerVervoer.CargoType.Cargo;

namespace ContainerVervoer
{
    public class Stack : List<Container>
    {
        //fields
        private int maxHeight;
        private int weight;
        private int id;
        private static int nextId = 1;

        //constructor
        public Stack(int maxHeight)
        {
            this.maxHeight = maxHeight;
            this.id = nextId;
            nextId++;
        }
        //properties
        public int MaxHeight { get => maxHeight; }
        public int Weight { get => weight; }
        public int Id { get => id; }
        //methods
        public void UpdateWeight()
        {
            this.weight = 0;
            foreach (Container container in this)
            {
                this.weight = this.weight + container.Weight;
            }
            
        }
        public bool AddContainer(Container container)
        {
            if (checkHeight() && checkValuable() && checkWeight(container))
            {
                this.Add(container);
                return true;
            }
            else if(checkHeight() && !checkValuable() && checkWeight(container))
            {
                
                return this.AddUnderValuable(container);
            }
            else
            {
                return false;
            }
        }

        private bool AddUnderValuable(Container container)
        {
            if (checkHeight())
            {
                int oldIndex = this.Count - 1;
                Container temp = this[oldIndex];
                this.RemoveAt(oldIndex);
                this.Insert(oldIndex, container);
                if (this.AddContainer(temp))
                {
                    return true;
                }
            }
            return false;
        }
        private bool checkHeight()
        {
            if (this.Count == this.maxHeight)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkWeight(Container container)
        {
            int weightonlowest = 0;
            for (int i = 1; i < this.Count; i++)
            {
                weightonlowest = weightonlowest + this[i].Weight;
            }

            if (weightonlowest + container.Weight >= 120000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkValuable()
        {
            if (this.Count != 0)
            {
                if (this[this.Count - 1].CargoType == Valuable)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            return $"Stack {id}";
        }
    }
}
