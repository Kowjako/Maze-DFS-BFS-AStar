using Maze_DFS_BFS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Maze_DFS_BFS.Helpers
{
    public static class CalculationHelper
    {
        public static Cell FindCell(int x, int y, float sizeX, float sizeY) => new Cell(y: (int)Math.Floor(x / sizeX),
                                                                                        x: (int)Math.Floor(y / sizeY),
                                                                                        state: CellState.Border, prev_r: 0, prev_c: 0);

        public static Point[] CalculateSquare(int row, int column, float CELL_SIZE_X, float CELL_SIZE_Y) =>
            new Point[] {
                new Point((int)(column * CELL_SIZE_X + 1), (int)(row * CELL_SIZE_Y + 1)),
                new Point((int)((column + 1)* CELL_SIZE_X - 1), (int)(row * CELL_SIZE_Y + 1)),
                new Point((int)((column + 1)* CELL_SIZE_X - 1), (int)((row + 1)* CELL_SIZE_Y - 1)),
                new Point((int)(column * CELL_SIZE_X + 1), (int)((row + 1)* CELL_SIZE_Y - 1))
            };

        public static int HeuristicDistance(Cell current, Cell destination) =>
            Math.Abs(current.Row - destination.Row) + Math.Abs(current.Column - destination.Column);

        public static void CalculateHeursticForPoints(IEnumerable<Cell> points, Cell startCell, Cell finishCell)
        {
            foreach (var item in points)
            {
                item.G = HeuristicDistance(item, startCell);
                item.H = HeuristicDistance(item, finishCell);
                item.F = item.G + item.H;
            }
        }

    }
}
