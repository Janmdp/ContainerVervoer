using System;
using System.Collections.Generic;
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
        private bool cooled;

        //constructor
        public Stack(int maxHeight, bool cooled)
        {
            this.maxHeight = maxHeight;
            this.cooled = cooled;
        }
        //properties
        public int MaxHeight { get => maxHeight; }
        public bool Cooled { get => cooled; }

        //methods
        public bool checkHeight()
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

        public bool checkWeight(Container container)
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

        public bool checkValuable()
        {
            if (this[this.Count - 1].CargoType  == Valuable)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkCoolable(Container _container)
        {
            if (_container.CargoType == Coolable)
            {
                if (this.cooled)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
            
        }
    }
}
