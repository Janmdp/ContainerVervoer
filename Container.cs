using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ContainerVervoer
{
    public class Container
    {
        //fields

        private int weight;

        private int weightOnTop;

        private int maxWeightOnTop;

        private CargoType.Cargo cargoType;

        public Container(int weight, CargoType.Cargo cargoType)
        {
            this.weight = weight + 4000;
            this.cargoType = cargoType;
            if ((int)cargoType == 3)
            {
                this.maxWeightOnTop = 0;
            }
            else
            {
                this.maxWeightOnTop = 120000;
            }
            
        }
       
        //constructor
        
        //properties
        
        public int Weight { get => weight; set => weight = value; }
        public int WeightOnTop { get => weightOnTop; set => weightOnTop = value; }
        public int MaxWeightOnTop { get => maxWeightOnTop;}
        public CargoType.Cargo CargoType { get => cargoType; set => cargoType = value; }
        //methods

    }
}
