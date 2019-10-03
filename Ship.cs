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
        private List<Container> Stack = new List<Container>();
        private List<List<Container>> Row = new List<List<Container>>();
        private List<List<List<Container>>> cargoList = new List<List<List<Container>>>();
        
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
