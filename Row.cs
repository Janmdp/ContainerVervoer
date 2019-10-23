using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer
{
    public class Row : List<Stack>
    {
        //fields
        private int length;

        //methods
        public Row(int length)
        {
            this.length = length;   
        }

        //properties
        public int Length { get => length;}
    }
}
