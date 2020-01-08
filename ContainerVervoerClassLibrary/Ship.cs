using System.Collections.Generic;
using System.Linq;
using static ContainerVervoerClassLibrary.CargoType.Cargo;

namespace ContainerVervoerClassLibrary
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

        public List<Row> Rows { get => rows; set => rows = value; }
        public int Length { get => length; }
        public int Width { get => width; }
        public int MaxWeight { get => maxweight; }

        //methods
        public void GenerateContents()
        {
            //Generate rows and stacks based on the ships measurements
            for (int i = 0; i < this.length; i++)
            {
                //makes the first container cooled
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

        //Returns the % of the maxweight is used
        public double GetUsedWeight()
        {
            double toReturn = ( (double) weight / (double) maxweight) * 100;
            return toReturn;
        }

        //Checks if 50% of the max weight is used
        public bool CheckWeight()
        {
            if ((double) weight / (double) maxweight * 100 >= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string CheckWeightSpread()
        {
            int left = 0;
            int right = 0;

            foreach (Row row in Rows)
            {
                for (int i = 0; i < (row.Count / 2); i++)
                {
                    left = left + row[i].Weight;
                }

                for (int i = (row.Count / 2); i < row.Count; i++)
                {
                    right = right + row[i].Weight;
                }
            }

            double leftPercentage = ((double)left / (double)weight) * 100;
            double rightPercentage = ((double)right / (double)weight) * 100;

            return $"{leftPercentage}% of the weight is on the left side, {rightPercentage}% of the weight is on the right side";
        }
        //Updates the weight of the ship
        public void UpdateWeight()
        {
            foreach (Row row in Rows)
            {
                foreach (Stack stack in row)
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

        
        //Adds a container to the ship
        public bool AddContainer(Container container)
        {
            //boolean to check if the container was succesfully added
            bool isAdded = false;
            if (Weight + container.Weight <= maxweight)
            {
                //Loop through all the rows on the ship based on weight
                foreach (Row row in Rows.OrderBy(r => r.Weight))
                {
                    //Check if a container and row aar cooled
                    if (container.CargoType is Coolable && row.Cooled)
                    {
                        if (row.CheckStacks(container, this))
                        {
                            UpdateWeight();
                            isAdded = true;
                            return true;
                        }
                    }
                    //all other cases
                    if (container.CargoType is Normal || container.CargoType is Valuable)
                    {
                        if (row.CheckStacks(container, this))
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