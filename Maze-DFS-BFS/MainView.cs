using Maze_DFS_BFS.Services;
using Maze_DFS_BFS.ViewModel;
using Maze_DFS_BFS.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Maze_DFS_BFS
{
    public partial class MainView : Form
    {
        private readonly ApplicationViewModel _viewModel;
        private TableLayoutPanel _actualPanel;

        public MainView()
        {
            InitializeComponent();
            _viewModel = new ApplicationViewModel();
            _viewModel.SolutionDone += (e, args) => DrawSolution();
        }

        private void btnSelectMatrixSize_Click(object sender, EventArgs e)
        {
            if(_actualPanel != null)
            {
                Controls.Remove(_actualPanel);
            }

            var form = new MatrixSizeForm(_viewModel);
            
            form.Owner = this;
            form.StartPosition = FormStartPosition.CenterParent;

            if(form.ShowDialog() == DialogResult.OK)
            {
                _actualPanel = _viewModel.GenerateStartPanel(ClientSize);
                Controls.Add(_actualPanel); 
            }
            form.Dispose();

            _actualPanel.BringToFront();
        }

        private void btnSetStartColor_Click(object sender, EventArgs e)
        {
            _viewModel.HandleSetColor(0);
        }

        private void btnSetColorFinish_Click(object sender, EventArgs e)
        {
            _viewModel.HandleSetColor(1);
        }

        private void btnSelectStartPoint_Click(object sender, EventArgs e)
        {
            MenuMode.ConfigType = ConfigType.AssigningStart;
        }

        private void btnSelectEndPoint_Click(object sender, EventArgs e)
        {
            MenuMode.ConfigType = ConfigType.AssigningFinish;
        }

        private void btnDrawBorders_Click(object sender, EventArgs e)
        {
            MenuMode.ConfigType = ConfigType.DrawingBorders;
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            MenuMode.SearchMode = SearchMode.BFS;
            var menuItem = sender as ToolStripMenuItem;
            menuItem.Checked = true;
            btnDFS.Checked = false;
            btnAStar.Checked = false;
        }

        private void btnDFS_Click(object sender, EventArgs e)
        {
            MenuMode.SearchMode = SearchMode.DFS;
            var menuItem = sender as ToolStripMenuItem;
            menuItem.Checked = true;
            btnBFS.Checked = false;
            btnAStar.Checked = false;
        }

        private void btnAStar_Click(object sender, EventArgs e)
        {
            MenuMode.SearchMode = SearchMode.DFS;
            var menuItem = sender as ToolStripMenuItem;
            menuItem.Checked = true;
            btnBFS.Checked = false;
            btnDFS.Checked = false;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            _viewModel.HandleSolve();
        }

        private void DrawSolution()
        {
            var nodes = _viewModel.MazeSolution;
            foreach(var control in _actualPanel.Controls)
            {
                var panel = control as Panel;
                if(panel != null && nodes.Contains(Convert.ToInt32(panel.Tag)))
                {
                    panel.BackColor = Color.Silver;
                }
            }
        }
    }
}
