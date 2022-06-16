using Maze_DFS_BFS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Maze_DFS_BFS.Views
{
    public partial class MatrixSizeForm : Form
    {
        private readonly ApplicationViewModel _viewModel;

        public MatrixSizeForm(ApplicationViewModel vm)
        {
            InitializeComponent();
            _viewModel = vm;
            bsModel.DataSource = _viewModel.Model;
        }
    }
}
