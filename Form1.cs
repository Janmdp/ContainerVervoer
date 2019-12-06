using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;

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

            foreach (Row row in _ship.Rows )
            {
                listBoxRows.Items.Add(row.ToString());
            }
        }
        private void buttonCreateShip_Click(object sender, EventArgs e)
        {
            int height = (int) numericUpDownHeight.Value;
            int width = (int) numericUpDownWidth.Value;
            int length = (int) numericUpDownLength.Value;
            int maxWeight = (int) numericUpDownMaxWeight.Value;
            
            _ship = new Ship(width, height, length, maxWeight);
            UpdateInterfaces();
            tabControl1.SelectedIndex = 1;
        }

        private void buttonAddContainer_Click(object sender, EventArgs e)
        {
            Container container = new Container( (int) numericUpDownWeight.Value, (CargoType.Cargo) comboBoxCargoType.SelectedItem);
            _ship.AddContainer(container);
            UpdateInterfaces();
        }

        private void listBoxRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Row row in _ship.Rows )
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

        private void listBoxStacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Row row in _ship.Rows)
            {
                if (row.ToString() == listBoxRows.SelectedItem.ToString())
                {
                    foreach(Stack stack in row )
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
}
