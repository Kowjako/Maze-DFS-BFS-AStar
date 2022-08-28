using Maze_DFS_BFS.Helpers;
using Maze_DFS_BFS.Models;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Maze_DFS_BFS
{
    public partial class MainView : Form
    {
        private int rows, columns;
        private Mode Mode = Mode.None;
        private Cell[,] cellGrid;
        private float CELL_SIZE_X, CELL_SIZE_Y;
        private bool startWasAssigned, finishWasAssigned;
        private Point startPoint, endPoint;

        /// <summary>
        /// Rysowanie granic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainGrid_MouseDown(object sender, MouseEventArgs e)
        {
            var cell = FindCell(e.X, e.Y);
            if (cell.Row >= 0 && cell.Row < rows && cell.Column >= 0 && cell.Column < columns)
            {
                if (Mode == Mode.None)
                {
                    if (cellGrid[cell.Row, cell.Column].State == CellState.Border)
                    {
                        cellGrid[cell.Row, cell.Column].State = CellState.Unassigned;
                    }
                    else
                    {
                        cellGrid[cell.Row, cell.Column].State = CellState.Border;
                    }
                }
                else
                {
                    if(Mode == Mode.AssignStart)
                    {
                        cellGrid[cell.Row, cell.Column].State = CellState.Start;
                        startPoint = new Point(cell.Row, cell.Column);
                        startWasAssigned = true;
                    }
                    else
                    {
                        cellGrid[cell.Row, cell.Column].State = CellState.Finish;
                        endPoint = new Point(cell.Row, cell.Column);
                        finishWasAssigned = true;
                    }
                    Mode = Mode.None;
                }
            }
            mainGrid.Invalidate();
        }

        public MainView()
        {
            InitializeComponent();
        }

        private void btnGenerateLayout_Click(object sender, System.EventArgs e)
        {
            //rows = (int)rowNud.Value;
            //columns = (int)columnNud.Value;
            cellGrid = new Cell[rows, columns];
            CalculateCellSize();
            //mainGrid.Invalidate();
            
        }

        private void btnGenerateGrid_Click(object sender, EventArgs e)
        {
            PerformClearing();
            var sizeDialog = new SelectSize();
            if(sizeDialog.ShowDialog() == DialogResult.OK)
            {
                (rows, columns) = sizeDialog.Size;
                cellGrid = new Cell[rows, columns];
                CalculateCellSize();
                mainGrid.Invalidate();
            }   
        }

        private void mainGrid_Paint(object sender, PaintEventArgs e)
        {
            if (rows != 0 && columns != 0)
            {
                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        e.Graphics.FillPolygon(CellBrushMapper.GetBrush(cellGrid[j, i].State), CalculateSquare(j, i));
                    }
                }
            }
        }

        private Point[] CalculateSquare(int row, int column)
        {
            return new Point[] {
                new Point((int)(column * CELL_SIZE_X + 1), (int)(row * CELL_SIZE_Y + 1)),
                new Point((int)((column + 1)* CELL_SIZE_X - 1), (int)(row * CELL_SIZE_Y + 1)),
                new Point((int)((column + 1)* CELL_SIZE_X - 1), (int)((row + 1)* CELL_SIZE_Y - 1)),
                new Point((int)(column * CELL_SIZE_X + 1), (int)((row + 1)* CELL_SIZE_Y - 1))
            };
        }

        private void mainGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var cell = FindCell(e.X, e.Y);
                if (cell.Row >= 0 && cell.Row < rows && cell.Column >= 0 && cell.Column < columns)
                {
                    cellGrid[cell.Row, cell.Column].State = CellState.Border;
                }
                mainGrid.Invalidate();
            }
            
        }

        private void btnSelectStart_Click(object sender, EventArgs e)
        {
            if(!startWasAssigned) Mode = Mode.AssignStart;
        }

        private void btnSelectFinish_Click(object sender, EventArgs e)
        {
            if(!finishWasAssigned) Mode = Mode.AssignFinish;
        }

        private void btnGenerateMaze_Click(object sender, EventArgs e)
        {
            ClearCells();
            var maze = new MazeGenerator(rows, columns);
            var cells = maze.GenerateMaze();
            for (int r = 0; r<rows; r++)
            {
                for(int c = 0;c<columns; c++)
                {
                    if (!cells[r,c])
                    {
                        cellGrid[r, c].State = CellState.Border;
                    }
                }
            }
            mainGrid.Invalidate();
        }

        private void CalculateCellSize()
        {
            CELL_SIZE_X = (float)((double)700 / columns);
            CELL_SIZE_Y = (float)((double)700 / rows);

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    cellGrid[j, i] = new Cell(i, j, CellState.Unassigned);
                }
            }
        }

        private void dfsBtnSolve_Click(object sender, EventArgs e)
        {

        }

        private void bfsBtnSolve_Click(object sender, EventArgs e)
        {

        }

        private void astarBtnSolve_Click(object sender, EventArgs e)
        {

        }

        private Cell FindCell(int x, int y)
        {
            return new Cell(y: (int)Math.Floor(x / CELL_SIZE_X),
                            x: (int)Math.Floor(y / CELL_SIZE_Y),
                            state: CellState.Border);
        }

        private void PerformClearing()
        {
            rows = columns = 0;
            CELL_SIZE_X = CELL_SIZE_Y = 0;
            Mode = Mode.None;
            startWasAssigned = finishWasAssigned = false;
        }

        private void ClearCells()
        {
            for (var r = 0; r < rows; r++)
                for (var c = 0; c < columns; c++)
                    cellGrid[r, c].State = CellState.Unassigned;
        }

    }

    public struct Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public CellState State { get; set; }

        public Cell(int x, int y, CellState state)
        {
            Row = x;
            Column = y;
            State = state;
        }
    }

    public enum CellState
    {
        Border,
        Start,
        Finish,
        Unassigned,
        Solution
    }

    public enum Mode
    {
        AssignStart,
        AssignFinish,
        None
    }
}
