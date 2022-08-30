using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Maze_DFS_BFS.Models
{
    public class CellEqualityComparer : IEqualityComparer<Cell>
    {
        public bool Equals(Cell x, Cell y)
        {
            return x.Row == y.Row && x.Column == y.Column;
        }

        public int GetHashCode(Cell obj)
        {
            return obj.Column ^ obj.Row;
        }
    }

    public class CellComparer : IComparer<Cell>
    {
        public int Compare(Cell x, Cell y)
        {
            return x.F - y.F;
        }
    }

    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public CellState State { get; set; }

        public int Prev_Col { get; set; }
        public int Prev_Row { get; set; }

        //pola dla algorytmu A*
        public int G { get; set; } = int.MaxValue;
        public int H { get; set; }   

        public int F { get; set; } = int.MaxValue;

        public Cell()
        {

        }

        public Cell(int x, int y, CellState state, int prev_r, int prev_c)
        {
            Row = x;
            Column = y;
            State = state;
            Prev_Col = prev_c;
            Prev_Row = prev_r;
        }
    }
}
