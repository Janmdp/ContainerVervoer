using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer
{
    public class Row
    {
        //fields
        private List<Stack> stacks = new List<Stack>();
        private int length;

        //methods
        public Row(int length)
        {
            this.length = length;   
        }

        //properties
        public List<Stack> Stacks { get => stacks; set => stacks = value;}
        public int Length { get => length;}
    }
}
