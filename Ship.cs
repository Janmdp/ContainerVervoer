using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer
{
    public class Ship
    {
        //fields
        private int width;
        private int height;
        private int length;
        private int maxweight;
        private int weight;
        
        
        //constructor
        public Ship(int width, int height, int length, int maxweight)
        {
            this.width = width;
            this.height = height;
            this.length = length;
            this.maxweight = maxweight;

        }

        //properties
        public int Weight { get => weight; set => weight = value; }
        
        //methods
       
    }
}
