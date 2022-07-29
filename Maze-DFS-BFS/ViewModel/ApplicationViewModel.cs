using Maze_DFS_BFS.Algorithms;
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

        private readonly LayoutGenerator_v2 _layoutGenerator;
        private readonly IColorDialog ColorDialog;
        private TableLayoutPanel MainPanel;

        public event EventHandler SolutionDone;
        public List<int> MazeSolution { get; private set; }

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

            return MainPanel = _layoutGenerator.GeneratePanel();
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

        public void HandleSolve()
        {
            Model.LayoutMatrix = GetCompletedMatrixFromLayout();
            Model.MainMatrix = GetMainMatrixFromLayout();
            MazeSolution = Model.SolveMaze(MenuMode.SearchMode switch
            {
                SearchMode.BFS => new BFS(MenuMode.StartPointIndex, MenuMode.EndPointIndex),
                SearchMode.DFS => new DFS(MenuMode.StartPointIndex, MenuMode.EndPointIndex),
                SearchMode.A_STAR => new A_STAR(MenuMode.StartPointIndex, MenuMode.EndPointIndex),
                _ => throw new InvalidOperationException("Cannot find implementation for this algorithm")
            });

            SolutionDone(this, EventArgs.Empty);
        }

        private int[,] GetCompletedMatrixFromLayout()
        {
            var array = new int[MainPanel.RowCount, MainPanel.ColumnCount];

            for (var i = 0; i < MainPanel.RowCount; i++)
            {
                for (var j = 0; j < MainPanel.ColumnCount; j++)
                {
                    var cell = MainPanel.GetControlFromPosition(j,i) as Panel;
                    if (cell != null)
                    {
                        array[i, j] = Convert.ToInt32(cell.Tag);
                    }
                }
            }
            
            return array;
        }

        private int[,] GetMainMatrixFromLayout()
        {
            var array = new int[Model.Rows, Model.Columns];
            var counter = 0;

            for(var i=0;i<Model.Rows;i++)
            {
                for(var j=0;j<Model.Columns;j++)
                {
                    array[i, j] = ++counter;
                }
            }

            return array;
        }
    }
}
