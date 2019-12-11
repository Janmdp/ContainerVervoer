using System.Collections.Generic;
using System.Linq;
using static ContainerVervoer.CargoType.Cargo;

namespace ContainerVervoer
{
    public class Stack : List<Container>
    {
        //fields
        private int maxHeight;
        private int weight;
        private int id;
        private static int nextId = 1;

        //constructor
        public Stack(int maxHeight)
        {
            this.maxHeight = maxHeight;
            this.id = nextId;
            nextId++;
        }

        //properties
        public int MaxHeight { get => maxHeight; }

        public int Weight { get => weight; }
        public int Id { get => id; }

        //methods
        //Update the weight of the stack
        public void UpdateWeight()
        {
            this.weight = 0;
            foreach (Container container in this)
            {
                this.weight = this.weight + container.Weight;
            }
        }

        //Attempt to add a container to the stack
        public bool AddContainer(Ship ship, Row row, Container container)
        {
            //Runs checks on a stack and adds the container if the stack passes
            if (checkHeight() && checkValuable() && checkWeight(container) && CheckSurroundings(row, ship, container))
            {
                this.Add(container);
                return true;
            }
            //Different attempt of adding the container if the stack contains a valuable container
            else if (checkHeight() && !checkValuable() && checkWeight(container) && CheckSurroundings(row, ship, container) && container.CargoType != Valuable)
            {
                return this.AddUnderValuable(container);
            }
            else
            {
                return false;
            }
        }

        //Places the container underneath a valuable container in the stack
        private bool AddUnderValuable(Container container)
        {
            if (checkHeight())
            {
                int oldIndex = this.Count - 1;
                Container temp = this[oldIndex];
                this.RemoveAt(oldIndex);
                this.Insert(oldIndex, container);
                this.Add(temp);
                return true;
            }
            return false;
        }

        //Checks if there is room left in the stack
        private bool checkHeight()
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

        //Checks if the container can be added based on the weight
        private bool checkWeight(Container container)
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

        //Checks if there is a valuable container at the top of the stack
        private bool checkValuable()
        {
            if (this.Count != 0)
            {
                if (this[this.Count - 1].CargoType == Valuable)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private bool CheckSurroundings(Row row, Ship ship, Container container)
        {
            int stackIndexInRow = row.FindIndex(s => s.Id == Id);
            if (container.CargoType is Valuable)
            {
                return CheckSurroundingsValuable(row, ship, stackIndexInRow);
            }
            else
            {
                return CheckSurroundingsNormal(row, ship, stackIndexInRow);
            }
        }
        private bool CheckSurroundingsValuable(Row row, Ship ship, int stackIndexInRow)
        {
           
            if (row.Id > 1 && row.Id < ship.Rows.Count())
            {
                if (ship.Rows.Single(r => r.Id == row.Id)[stackIndexInRow].Count >= ship.Rows.Single(r => r.Id == row.Id + 1)[stackIndexInRow].Count || ship.Rows.Single(r => r.Id == Id)[stackIndexInRow].Count >= ship.Rows.Single(r => r.Id == Id - 1)[stackIndexInRow].Count)
                {
                    return CheckSurroundingsNormal(row, ship, stackIndexInRow);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return CheckSurroundingsNormal(row, ship, stackIndexInRow);
            }
        }
        private bool CheckSurroundingsNormal(Row row, Ship ship, int stackIndexInRow)
        {

            if (CheckStackInFront(ship, row, stackIndexInRow) && CheckStackBehind(ship, row, stackIndexInRow))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckStackInFront(Ship ship, Row row, int stackIndexInRow)
        {
            if (row.Id < ship.Rows.Count() - 1)
            {

                if (ship.Rows.Single(r => r.Id == row.Id)[stackIndexInRow].Count < ship.Rows.Single(r => r.Id == row.Id + 1)[stackIndexInRow].Count)
                {
                    if (ship.Rows.Single(r => r.Id == (row.Id + 1))[stackIndexInRow].Last().CargoType == Valuable && ship.Rows.Single(r => r.Id == (row.Id + 2))[stackIndexInRow].Count >= ship.Rows.Single(r => r.Id == (row.Id + 1))[stackIndexInRow].Count)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private bool CheckStackBehind(Ship ship, Row row, int stackIndexInRow)
        {
            if (row.Id > 2)
            {
                if (ship.Rows.Single(r => r.Id == row.Id)[stackIndexInRow].Count < ship.Rows.Single(r => r.Id == (row.Id - 1))[stackIndexInRow].Count)
                {
                    if (ship.Rows.Single(r => r.Id == (row.Id - 1))[stackIndexInRow].Last().CargoType == Valuable && ship.Rows.Single(r => r.Id == (row.Id - 2))[stackIndexInRow].Count >= ship.Rows.Single(r => r.Id == (row.Id - 1))[stackIndexInRow].Count)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            return $"Stack {id}";
        }
    }
}