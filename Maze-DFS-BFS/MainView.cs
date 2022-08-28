﻿using Maze_DFS_BFS.Helpers;
using Maze_DFS_BFS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private Cell startPoint, endPoint;
        private List<Cell> _solutionCells, _visitedNodes;
        private List<Cell> closedSet = new List<Cell>();
        private Algorithm Algorithm;


        #region DFS vars

        private Stack<Cell> stack;

        #endregion

        #region BFS vars

        private Queue<Cell> queue;

        #endregion

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
                        startPoint = cell;
                        startWasAssigned = true;
                    }
                    else
                    {
                        cellGrid[cell.Row, cell.Column].State = CellState.Finish;
                        endPoint = cell;
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
                    cellGrid[j, i] = new Cell(i, j, CellState.Unassigned,0,0);
                }
            }
        }

        private void dfsBtnSolve_Click(object sender, EventArgs e)
        {
            Algorithm = Algorithm.DFS;
            _solutionCells = new List<Cell>();
            _visitedNodes = new List<Cell>();
            stack = new Stack<Cell>();

            var neighbours = NeighboursHelper.GetPossibleNeighbours(cellGrid, startPoint);

            foreach (var n in neighbours)
            {
                if (!stack.Contains(n)) stack.Push(n);
            }

            animationTimer.Start();
        }

        private void bfsBtnSolve_Click(object sender, EventArgs e)
        {
            Algorithm = Algorithm.BFS;
            _solutionCells = new List<Cell>();
            _visitedNodes = new List<Cell>();
            queue = new Queue<Cell>();

            var neighbours = NeighboursHelper.GetPossibleNeighbours(cellGrid, startPoint);
            neighbours.Reverse();

            foreach (var n in neighbours)
            {
                if (!queue.Contains(n)) queue.Enqueue(n);
            }

            animationTimer.Start();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            foreach(var n in _visitedNodes)
            {
                if ((n.Row == endPoint.Row && n.Column == endPoint.Column) ||
                    (n.Row == startPoint.Row && n.Column == startPoint.Column)) continue;
                        
                cellGrid[n.Row, n.Column].State = CellState.Visited;
            }

            if (Algorithm == Algorithm.DFS)
            {
                if (!stack.Any(p => p.Row == endPoint.Row && p.Column == endPoint.Column))
                {
                    var nextCell = stack.Pop();

                    _visitedNodes.Add(nextCell);

                    var moves = NeighboursHelper.GetPossibleNeighbours(cellGrid, nextCell);
                    moves = moves.Except(_visitedNodes);

                    foreach (var m in moves)
                    {
                        if (!stack.Contains(m)) stack.Push(m);
                    }
                }
                else
                {
                    var end = stack.First(p => p.Row == endPoint.Row && p.Column == endPoint.Column);
                    (endPoint.Prev_Row, endPoint.Prev_Col) = (end.Prev_Row, end.Prev_Col);
                    animationTimer.Stop();
                    ShowSolution();
                }
            }
            else if (Algorithm == Algorithm.BFS)
            {
                if (!queue.Any(p => p.Row == endPoint.Row && p.Column == endPoint.Column))
                {
                    var item = queue.Dequeue();

                    _visitedNodes.Add(item);

                    var moves = NeighboursHelper.GetPossibleNeighbours(cellGrid, item);
                    moves = moves.Except(_visitedNodes);

                    foreach (var m in moves)
                    {
                        if (!queue.Contains(m)) queue.Enqueue(m);
                    }
                }
                else
                {
                    var end = queue.First(p => p.Row == endPoint.Row && p.Column == endPoint.Column);
                    (endPoint.Prev_Row, endPoint.Prev_Col) = (end.Prev_Row, end.Prev_Col);
                    animationTimer.Stop();
                    ShowSolution();
                }
            }
            else if (Algorithm == Algorithm.A)
            {

            }
            
            mainGrid.Invalidate();
        }

        private void ShowSolution()
        {
            Cell curr = endPoint;
            do
            {
                curr = _visitedNodes.FirstOrDefault(p => p.Column == curr.Prev_Col && p.Row == curr.Prev_Row);
                cellGrid[curr.Row, curr.Column].State = CellState.Solution;
            }
            while (curr.Row != startPoint.Row || curr.Column != startPoint.Column);
            cellGrid[startPoint.Row, startPoint.Column].State = CellState.Start;
            mainGrid.Invalidate();
        }

        private void astarBtnSolve_Click(object sender, EventArgs e)
        {
            Algorithm = Algorithm.A;
            animationTimer.Start();
        }

        private Cell FindCell(int x, int y)
        {
            return new Cell(y: (int)Math.Floor(x / CELL_SIZE_X),
                            x: (int)Math.Floor(y / CELL_SIZE_Y),
                            state: CellState.Border, prev_r:0, prev_c:0);
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

        public int Prev_Col { get; set; }
        public int Prev_Row { get; set; }


        public Cell(int x, int y, CellState state, int prev_r, int prev_c)
        {
            Row = x;
            Column = y;
            State = state;
            Prev_Col = prev_c;
            Prev_Row = prev_r;
        }
    }

    public enum CellState
    {
        Border,
        Start,
        Finish,
        Unassigned,
        Solution,
        Visited
    }

    public enum Mode
    {
        AssignStart,
        AssignFinish,
        None
    }

    public enum Algorithm
    {
        DFS, BFS, A
    }
}
