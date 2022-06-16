using Maze_DFS_BFS.ViewModel;
using Maze_DFS_BFS.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void btnSelectMatrixSize_Click(object sender, EventArgs e)
        {
            if(_actualPanel != null)
            {
                Controls.Remove(_actualPanel);
            }

            _viewModel.ClientAreaSize = ClientSize;
            var form = new MatrixSizeForm(_viewModel);
            
            form.Owner = this;
            form.StartPosition = FormStartPosition.CenterParent;

            if(form.ShowDialog() == DialogResult.OK)
            {
                Controls.Add(_actualPanel = _viewModel.GenerateStartPanel());
            }
        }
    }
}
