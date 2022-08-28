using System;
using System.Windows.Forms;

namespace Maze_DFS_BFS
{
    public partial class SelectSize : Form
    {
        public (int rows, int columns) Size;

        public SelectSize()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Size = ((int)nudCols.Value, (int)nudRows.Value);
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
