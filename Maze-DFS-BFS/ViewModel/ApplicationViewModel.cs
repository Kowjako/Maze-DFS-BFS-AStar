using Maze_DFS_BFS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Maze_DFS_BFS.ViewModel
{
    public class ApplicationViewModel
    {
        public MazeModel Model { get; private set; }

        public Size ClientAreaSize { get; set; }
        private TableLayoutPanel MainPanel;

        public ApplicationViewModel()
        {
            Model = new MazeModel();
        }

        public TableLayoutPanel GenerateStartPanel()
        {
            MainPanel = new TableLayoutPanel() { ColumnCount = Model.Columns, 
                                                 RowCount = Model.Rows, 
                                                 Dock = DockStyle.Fill, 
                                                 CellBorderStyle = TableLayoutPanelCellBorderStyle.Single};
            for(int i = 0;i < Model.Columns;i++)
            {
                MainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, ClientAreaSize.Width / (float)Model.Columns));
            }

            for (int i = 0; i < Model.Rows; i++)
            {
                MainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, ClientAreaSize.Height / (float)Model.Rows));
            }

            return MainPanel;
        }
    }
}
