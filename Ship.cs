﻿using System;
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
        private List<Row> rows = new List<Row>();
        
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
        public List<Row> Rows { get => rows; set => rows = value;}
        //methods

        public void Initialize()
        {
            for (int i = 0; i < width; i++)
            {
                Row row = new Row(this.length);
                for (int j = 0; j < length; j++)
                {
                    Stack stack = new Stack(this.height, 0);
                    row.Stacks.Add(stack);
                    
                }

                for (int j = 0; j < 5; j++)
                {
                    Container cont = new Container(10, CargoType.Cargo.Normal);
                    row.Stacks[0].Containers.Add(cont);
                }
                Rows.Add(row);
                
            }
        }
    }
}
