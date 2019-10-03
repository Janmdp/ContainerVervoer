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
        private int spots;
        private List<Container> containers;
        private List<Container[][]> rows = new List<Container[][]>();
        
        //constructor
        public Ship(int width, int height, int length, int maxweight)
        {
            this.width = width;
            this.height = height;
            this.length = length;
            this.maxweight = maxweight;
            this.weight = weight;
            this.spots = width * height * length;
        }

        //properties
        public int Weight { get => weight; set => weight = value; }
        public List<Container> Containers { get => containers; set  => containers = value;}
        public List<Container[][]> Rows { get => rows; set => rows = value;}
        //methods
        public void initializeGrid()
        {
            for (int i = 0; i < width; i++)
            {
                Container[][] Row = new Container[length][];
                for (int j = 0; j < length; j++)
                {
                    Container[] stack = new Container[height];
                    Row[j] = stack;
                }
                rows.Add(Row);
            }
        }
    }
}
