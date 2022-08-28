using System.Collections.Generic;
using System.Drawing;

namespace Maze_DFS_BFS.Helpers
{
    public class NeighboursHelper
    {
        public static IEnumerable<Cell> GetPossibleNeighbours(Cell[,] grid, Cell p)
        {
            var list = new List<Cell>();

            var possible = new List<Point>()
            {
                new Point(p.Row, p.Column - 1),                        
                new Point(p.Row + 1, p.Column),                      
                new Point(p.Row, p.Column + 1),                    
                new Point(p.Row - 1, p.Column)
            };

            possible.ForEach(p =>
            {
                if (IsValidPosition(p, grid.GetLength(0), grid.GetLength(1)) &&
                    grid[p.X,p.Y].State != CellState.Border)
                        list.Add(new Cell { Row = p.X, Column = p.Y, State = CellState.Unassigned });
            });

            return list;
        }

        private static bool IsValidPosition(Point cell, int rows, int cols) => cell.X >= 0 && cell.X < rows &&
                                                                        cell.Y >= 0 && cell.Y < cols;
    }
}
