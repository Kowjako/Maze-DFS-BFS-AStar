using Maze_DFS_BFS.Models;
using Maze_DFS_BFS.Services;
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

        private readonly LayoutGenerator_v2 _layoutGenerator;
        private readonly IColorDialog ColorDialog;

        public ApplicationViewModel()
        {
            Model = new MazeModel();
            _layoutGenerator = new LayoutGenerator_v2();
            ColorDialog = new ColorService();
        }

        public TableLayoutPanel GenerateStartPanel(Size clientSize)
        {
            _layoutGenerator.RowNumber = Model.Rows;
            _layoutGenerator.ColumnNumber = Model.Columns;
            _layoutGenerator.ClientSize = clientSize;

            return _layoutGenerator.GeneratePanel();
        }

        /// <summary>
        /// Pozwala ustawić kolor węzła początkowego i końcowego
        /// </summary>
        /// <param name="nodeType">0 - start node, 1 - end node</param>
        public void HandleSetColor(int nodeType)
        {
            if (ColorDialog.ShowColorPicker() == DialogResult.OK)
            {
                if(nodeType == 0)
                {
                    MenuMode.StartColor = ColorDialog.SelectedColor;
                }
                else
                {
                    MenuMode.FinishColor = ColorDialog.SelectedColor;
                }
            }
        }
    }
}
