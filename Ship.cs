using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ContainerVervoer.CargoType.Cargo;

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
        private List<Container> containers = new List<Container>();
        
        //constructor
        public Ship()
        {

        }
        public Ship(int width, int height, int length, int maxweight)
        {
            this.width = width;
            this.height = height;
            this.length = length;
            this.maxweight = maxweight;
            GenerateContents();
        }

        //properties
        public int Weight { get => weight; set => weight = value; }
        public List<Row> Rows { get => rows; set => rows = value;}
        public int Length { get => length;}
        public int Width { get => width;}
        public int MaxWeight { get=> maxweight; }
        //methods
        public void GenerateContents()
        {
            for (int i = 0; i < this.length; i++)
            {
                if (i == 0)
                {
                    Row row = new Row(true);
                    row.GenerateStacks(this.width, this.height);
                    Rows.Add(row);
                }
                else
                {
                    Row row = new Row(false);
                    row.GenerateStacks(this.width, this.height);
                    Rows.Add(row);
                }
                
            }
        }

        public void UpdateWeight()
        {
            foreach (Row row in Rows)
            {
                foreach (Stack stack in row )
                {
                    stack.UpdateWeight();
                }
                row.UpdateWeight();
            }
            this.weight = 0;
            foreach (Row shipRow in Rows)
            {
                this.weight = this.weight + shipRow.Weight;
            }
        }
        public bool AddContainer(Container container)
        {
            bool isAdded = false;
            if (Weight + container.Weight <= maxweight)
            {
                foreach (Row row in Rows.OrderBy(r => r.Weight))
                {
                    if (container.CargoType is Coolable && row.Cooled)
                    {
                        if (row.CheckStacks(container))
                        {
                            UpdateWeight();
                            isAdded = true;
                            return true;
                        }
                        
                    }

                    if (container.CargoType is Normal || container.CargoType is Valuable)
                    {
                        if (row.CheckStacks(container))
                        {
                            UpdateWeight();
                            isAdded = true;
                            return true;
                            
                        }
                        
                    }

                }

                if (!isAdded)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return false;
        }
    }
}
