using Maze_DFS_BFS.Helpers;
using Maze_DFS_BFS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Maze_DFS_BFS
{
    public partial class MainView : Form
    {
        #region Common

        private int rows, columns;
        private Mode Mode = Mode.None;
        private Cell[,] cellGrid;
        private float CELL_SIZE_X, CELL_SIZE_Y;
        private bool startWasAssigned, finishWasAssigned;
        private Cell startPoint, endPoint;
        private List<Cell> _visitedNodes;
        private Algorithm Algorithm;
        private CellEqualityComparer _comparer;

        #endregion

        #region DFS vars

        private Stack<Cell> stack;

        #endregion

        #region BFS vars

        private Queue<Cell> queue;

        #endregion

        #region Drawing

        /// <summary>
        /// Reczne rysowanie granic przed animacja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainGrid_MouseDown(object sender, MouseEventArgs e)
        {
            var cell = CalculationHelper.FindCell(e.X, e.Y, CELL_SIZE_X, CELL_SIZE_Y);
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
                    if (Mode == Mode.AssignStart)
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

        /// <summary>
        /// Rysowanie kazdego kadru animacji w zaleznosci od stanu komorki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainGrid_Paint(object sender, PaintEventArgs e)
        {
            if (rows != 0 && columns != 0)
            {
                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        e.Graphics.FillPolygon(CellBrushMapper.GetBrush(cellGrid[j, i].State),
                                               CalculationHelper.CalculateSquare(j, i, CELL_SIZE_X, CELL_SIZE_Y));
                    }
                }
            }
        }

        /// <summary>
        /// Rysowanie granic z wcisnietym lewym przyciskiem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var cell = CalculationHelper.FindCell(e.X, e.Y, CELL_SIZE_X, CELL_SIZE_Y);
                if (cell.Row >= 0 && cell.Row < rows && cell.Column >= 0 && cell.Column < columns)
                {
                    cellGrid[cell.Row, cell.Column].State = CellState.Border;
                }
                mainGrid.Invalidate();
            }
        }

        /// <summary>
        /// Oblicza rozmiar generowanej komorki na podstawie ilosci kolumn i wierszy
        /// </summary>
        private void CalculateCellSize()
        {
            CELL_SIZE_X = (float)((double)700 / columns);
            CELL_SIZE_Y = (float)((double)700 / rows);

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    cellGrid[j, i] = new Cell(i, j, CellState.Unassigned, 0, 0);
                }
            }
        }

        #endregion

        #region View behavior

        public MainView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pokazuje okno wpisywania rozmiarow, nastepnie generuje grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateGrid_Click(object sender, EventArgs e)
        {
            PerformClearing();
            var sizeDialog = new SelectSize();
            if (sizeDialog.ShowDialog() == DialogResult.OK)
            {
                (rows, columns) = sizeDialog.Size;
                cellGrid = new Cell[rows, columns];
                CalculateCellSize();
                mainGrid.Invalidate();
            }
        }

        /// <summary>
        /// Ustawia punkt startowy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectStart_Click(object sender, EventArgs e)
        {
            if (!startWasAssigned) Mode = Mode.AssignStart;
        }

        /// <summary>
        /// Ustawia punkt koncowy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFinish_Click(object sender, EventArgs e)
        {
            if (!finishWasAssigned) Mode = Mode.AssignFinish;
        }

        /// <summary>
        /// Generuje randomowy labirynt za pomoca algorytmu Prima
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateMaze_Click(object sender, EventArgs e)
        {
            ClearCells();
            var maze = new MazeGenerator(rows, columns);
            var cells = maze.GenerateMaze();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (!cells[r, c])
                    {
                        cellGrid[r, c].State = CellState.Border;
                    }
                }
            }
            mainGrid.Invalidate();
        }

        /// <summary>
        /// Rysuje koncowa sciezke od punkt start -> finish
        /// </summary>
        private void ShowSolution()
        {
            Cell curr = endPoint;
            do
            {
                curr = _visitedNodes.FirstOrDefault(p => p.Column == curr.Prev_Col && p.Row == curr.Prev_Row);
                if (curr.Row == 0 || curr.Column == 0) break;
                cellGrid[curr.Row, curr.Column].State = CellState.Solution;
            }
            while (curr.Row != startPoint.Row || curr.Column != startPoint.Column);
            cellGrid[startPoint.Row, startPoint.Column].State = CellState.Start;
            mainGrid.Invalidate();
        }

        #endregion

        #region Animation Timer

        private void dfsBtnSolve_Click(object sender, EventArgs e)
        {
            Algorithm = Algorithm.DFS;
            _visitedNodes = new List<Cell>();
            stack = new Stack<Cell>();
            _comparer = new CellEqualityComparer();

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
            _visitedNodes = new List<Cell>();
            queue = new Queue<Cell>();
            _comparer = new CellEqualityComparer();

            var neighbours = NeighboursHelper.GetPossibleNeighbours(cellGrid, startPoint);
            neighbours.Reverse();

            foreach (var n in neighbours)
            {
                if (!queue.Contains(n)) queue.Enqueue(n);
            }

            animationTimer.Start();
        }

        private void astartBtnSolve_Click(object sender, EventArgs e)
        {

        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            foreach (var n in _visitedNodes)
            {
                if ((n.Row == endPoint.Row && n.Column == endPoint.Column) ||
                    (n.Row == startPoint.Row && n.Column == startPoint.Column)) continue;

                cellGrid[n.Row, n.Column].State = CellState.Visited;
            }

            // Kazdy krok poszczegolnych algorytmow
            if (Algorithm == Algorithm.DFS)
            {
                if (!stack.Any(p => p.Row == endPoint.Row && p.Column == endPoint.Column))
                {
                    var nextCell = stack.Pop();
                    cellGrid[nextCell.Row, nextCell.Column].State = CellState.Current;

                    _visitedNodes.Add(nextCell);

                    var moves = NeighboursHelper.GetPossibleNeighbours(cellGrid, nextCell);
                    moves = moves.Except(_visitedNodes, _comparer);

                    foreach (var m in moves)
                    {
                        if (!stack.Contains(m, _comparer)) stack.Push(m);
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
                    cellGrid[item.Row, item.Column].State = CellState.Current;

                    _visitedNodes.Add(item);

                    var moves = NeighboursHelper.GetPossibleNeighbours(cellGrid, item);
                    moves = moves.Except(_visitedNodes, _comparer);

                    foreach (var m in moves)
                    {
                        if (!queue.Contains(m, _comparer)) queue.Enqueue(m);
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
            else if (Algorithm == Algorithm.A_STAR)
            {

            }

            mainGrid.Invalidate();
        }

        #endregion

        #region Clearing

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

        #endregion

    }
}
