using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rnet
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
            TreeNode test = new TreeNode("Test");
            tvStorage.Nodes.Add(test);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsoleHelper.WriteLine("Ayy", ConsoleColor.Magenta);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
