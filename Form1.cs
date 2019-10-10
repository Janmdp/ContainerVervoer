using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerVervoer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Ship ship = new Ship(2,3,3,1000);
        
        private void Button1_Click(object sender, EventArgs e)
        {
            ship.Initialize();
            MessageBox.Show($"The ship contains {ship.Rows[0].Stacks[0].Containers.Count} rows");
        }
    }
}
