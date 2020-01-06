﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoerClassLibrary
{
    public class Row : List<Stack>
    {
        //fields
        private bool cooled;

        private int weight;
        private int id;
        private static int nextId = 1;

        //methods
        public Row(bool cooled)
        {
            this.cooled = cooled;
            this.id = nextId;
            nextId++;
        }

        //properties
        public bool Cooled { get => cooled; }

        public int Weight { get => weight; }
        public int Id { get => id; }

        //methods
        //Update the weight of the row
        public void UpdateWeight()
        {
            this.weight = 0;
            foreach (Stack stack in this)
            {
                this.weight = this.weight + stack.Weight;
            }
        }

        //Generate stacks based on the given parameters
        public void GenerateStacks(int amount, int height)
        {
            for (int i = 0; i < amount; i++)
            {
                Stack stack = new Stack(height);
                this.Add(stack);
            }
        }

        private List<Stack> ChooseSide(Ship ship)
        {
            if (this.Count % 2 == 0)
            {
                //even
                return ChooseSideEven(ship);
            }
            else
            {
                //odd
                //Math.Round(test, MidpointRounding.AwayFromZero)
                decimal middle = this.Count / (decimal) 2;
                return ChooseSideOdd(ship,Math.Round(middle, MidpointRounding.AwayFromZero));
            }
            
        }

        private List<Stack> ChooseSideOdd(Ship ship, decimal middle)
        {
            List<Stack> side = new List<Stack>();
            int left = 0;
            int right = 0;
            foreach (Row row in ship.Rows)
            {
                for (int i = 0; i < (middle - 1); i++)
                {
                    left = left + row[i].Weight;
                }
                
                for (int i = (int)middle; i < row.Count; i++)
                {
                    right = right + row[i].Weight;
                }
            }
            

            if (left < right)
            {
                for (int i = 0; i < (middle - 1); i++)
                {
                    side.Add(this[i]);
                }

                return side;
            }
            else if (left > right)
            {
                for (int i = (int) middle; i < this.Count; i++)
                {
                    side.Add(this[i]);
                }

                return side;
            }
            else
            {
                return this;
            }
        }
        private List<Stack> ChooseSideEven(Ship ship)
        {
            List<Stack> side = new List<Stack>();
            int left = 0;
            int right = 0;

            foreach (Row row in ship.Rows)
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
            
            

            if (left < right)
            {
                for (int i = 0; i < (this.Count / 2); i++)
                {
                    side.Add(this[i]);
                }

                return side;
            }
            else if (left > right)
            {
                for (int i = (this.Count / 2); i < this.Count; i++)
                {
                   side.Add(this[i]);
                }

                return side;
            }
            else
            {
                return this;
            }

        }

        //Check if there are stacks the container can be added to and adds the container
            public bool CheckStacks(Container container, Ship ship) {
            //Loop through the stacks based on weight
            foreach (Stack stack in this.OrderBy(s => s.Weight))
            {
                foreach (Stack stacks in this.ChooseSide(ship) )
                {
                    if (stack.Id == stacks.Id)
                    {
                        //Try to add the container to a stack
                        if (stack.AddContainer(ship, this, container))
                        {
                            return true;
                        }
                    }
                }
                
                
            }

            return false;
        }

        public override string ToString()
        {
            return $"Row {id}";
        }
    }
}