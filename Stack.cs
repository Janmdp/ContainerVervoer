using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer
{
    public class Stack
    {
        //fields
        private List<Container> containers = new List<Container>();
        private int maxHeight;
        private int weight;

        //constructor
        public Stack(int maxHeight, int weight)
        {
            this.maxHeight = maxHeight;
            this.weight = weight;
        }
        //properties
        public List<Container> Containers { get => containers; set => containers = value;}
        public int MaxHeight { get => maxHeight;}
        public int Weight { get => weight; set => weight = value;}

        //methods
        public bool checkHeight()
        {
            if (this.containers.Count == this.maxHeight)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkWeight(Container container)
        {
            int weightonlowest = 0;
            foreach (Container _container in this.containers )
            {
                weightonlowest = weightonlowest + _container.Weight;
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

        public bool checkValuable(Container _container)
        {
            if (this.containers[containers.Count].CargoType == CargoType.Cargo.Valuable)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkCoolable(Row row)
        {
            if (row.Stacks[0] == this)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
