using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ContainerVervoerClassLibrary;

namespace ContainerVervoer
{
    public partial class Form1 : Form
    {
        private Ship _ship;

        public Form1()
        {
            InitializeComponent();
            tabControl1.Appearance = TabAppearance.FlatButtons; tabControl1.ItemSize = new Size(0, 1); tabControl1.SizeMode = TabSizeMode.Fixed;
            comboBoxCargoType.DataSource = Enum.GetValues(typeof(CargoType.Cargo));
        }

        private void UpdateInterfaces()
        {
            listBoxRows.Items.Clear();
            listBoxStacks.Items.Clear();
            listBoxContainers.Items.Clear();

            foreach (Row row in _ship.Rows)
            {
                listBoxRows.Items.Add(row.ToString());
            }

            if (_ship.CheckWeight())
            {
                labelWeight.ForeColor = Color.Green;
                labelWeight.Text = $"{_ship.GetUsedWeight()}% of the maximum weight of the ship is used";
            }
            else
            {
                labelWeight.ForeColor = Color.Red;
                labelWeight.Text = $"{_ship.GetUsedWeight()}% of the maximum weight of the ship is used";
            }
        }

        private void buttonCreateShip_Click(object sender, EventArgs e)
        {
            int height = (int)numericUpDownHeight.Value;
            int width = (int)numericUpDownWidth.Value;
            int length = (int)numericUpDownLength.Value;
            int maxWeight = (int)numericUpDownMaxWeight.Value;

            _ship = new Ship(width, height, length, maxWeight);
            UpdateInterfaces();
            tabControl1.SelectedIndex = 1;
        }

        private void buttonAddContainer_Click(object sender, EventArgs e)
        {
            Container container = new Container((int)numericUpDownWeight.Value, (CargoType.Cargo)comboBoxCargoType.SelectedItem);
            if (!_ship.AddContainer(container))
            {
                MessageBox.Show("Container couldn't be added'");
            }
            UpdateInterfaces();
        }

        private void listBoxRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Row row in _ship.Rows)
            {
                if (listBoxRows.SelectedItem != null)
                {
                    if (row.ToString() == listBoxRows.SelectedItem.ToString())
                    {
                        listBoxStacks.Items.Clear();
                        foreach (Stack stack in row)
                        {
                            listBoxStacks.Items.Add(stack.ToString());
                        }
                    }
                }
            }
        }

        private void listBoxStacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Row row in _ship.Rows)
            {
                if (row.ToString() == listBoxRows.SelectedItem.ToString())
                {
                    foreach (Stack stack in row)
                    {
                        if (listBoxStacks.SelectedItem != null)
                        {
                            if (stack.ToString() == listBoxStacks.SelectedItem.ToString())
                            {
                                listBoxContainers.Items.Clear();
                                foreach (Container container in stack)
                                {
                                    listBoxContainers.Items.Add(container.ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ship ship = new Ship(5, 1, 1, 10000000);
            //Container cont = new Container(100, CargoType.Cargo.Normal);
            //Container cont2 = new Container(100, CargoType.Cargo.Normal);
            //Container cont3 = new Container(100, CargoType.Cargo.Normal);
            //Container cont4 = new Container(100, CargoType.Cargo.Normal);
            //ship.AddContainer(cont);
            //ship.AddContainer(cont2);
            //ship.AddContainer(cont3);
            //ship.AddContainer(cont4);
            //foreach (Row row in ship.Rows)
            //{
            //    foreach (Stack stack in row)
            //    {
            //        foreach (Container container in stack)
            //        {
            //            MessageBox.Show($"{row.Id}, {stack.Id}, {container.Id}, {container.Weight}");
            //        }
            //    }
            //}

            //int left = 0;
            //int right = 0;
            //List<Stack> test = ship.Rows[0].ChooseSide();
            //foreach (Stack stack in test)
            //{
            //    MessageBox.Show($"{stack.Id}");
            //}
        }
    }
}