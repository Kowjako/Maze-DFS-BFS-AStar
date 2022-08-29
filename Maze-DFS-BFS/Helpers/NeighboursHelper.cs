using Maze_DFS_BFS.Models;
using System.Collections.Generic;
using System.Drawing;

namespace Maze_DFS_BFS.Helpers
{
    public class NeighboursHelper
    {
        public static IEnumerable<Cell> GetPossibleNeighbours(Cell[,] grid, Cell p1)
        {
            var list = new List<Cell>();

            var possible = new List<Point>()
            {
                new Point(p1.Row, p1.Column - 1),
                new Point(p1.Row + 1, p1.Column),
                new Point(p1.Row, p1.Column + 1),
                new Point(p1.Row - 1, p1.Column)
            };

            possible.ForEach(p =>
            {
                if (IsValidPosition(p, grid.GetLength(0), grid.GetLength(1)) &&
                    grid[p.X, p.Y].State != CellState.Border)
                {
                    list.Add(new Cell { Row = p.X, Column = p.Y, State = CellState.Unassigned, 
                                        Prev_Col = p1.Column, Prev_Row = p1.Row});
                }
            });

            return list;
        }

        private static bool IsValidPosition(Point cell, int rows, int cols) => cell.X >= 0 && cell.X < rows &&
                                                                        cell.Y >= 0 && cell.Y < cols;
    }
}
