using System;
using System.Collections.Generic;
using System.Text;

namespace Maze_DFS_BFS.Algorithms
{
    public abstract class SearchAlgorithm
    {
        public SearchAlgorithm()
        {
            Solution = new List<int>();
        }

        //Matrix to solve
        public int[,] Matrix { get; set; }

        //Matrix included borders
        public int[,] LayoutMatrix { get; set; }

        //Sorted nodes as solution
        public List<int> Solution { get; set; }

        public abstract void Solve();

        private int GetColumn(int actualIndexInMatrix)
        {
            return actualIndexInMatrix * 2 <= LayoutMatrix.GetLength(1) + 1 ? (actualIndexInMatrix - 1) * 2
                : 2* ((actualIndexInMatrix - 1) % Matrix.GetLength(1));
        }

        protected virtual List<int> GetPossibleNextMoves(int actualIndexInMatrix)
        {
            var neighbours = new List<int>();
            //1. Obliczanie indeksu w calkowitej macierzy
            var layoutRow = 2 * ((actualIndexInMatrix - 1) / Matrix.GetLength(1));
            var layoutColumn = GetColumn(actualIndexInMatrix);

            //2. Obliczanie sasiadow
            if (layoutRow != 0 && LayoutMatrix[layoutRow - 1, layoutColumn] != 0)
                neighbours.Add(LayoutMatrix[layoutRow - 2, layoutColumn]);
            if (layoutRow != LayoutMatrix.GetLength(0) - 1 && LayoutMatrix[layoutRow + 1, layoutColumn] != 0)
                neighbours.Add(LayoutMatrix[layoutRow + 2, layoutColumn]);
            if (layoutColumn != 0 && LayoutMatrix[layoutRow, layoutColumn - 1] != 0)
                neighbours.Add(LayoutMatrix[layoutRow, layoutColumn - 2]);
            if (layoutColumn != LayoutMatrix.GetLength(1) - 1 && LayoutMatrix[layoutRow, layoutColumn + 1] != 0)
                neighbours.Add(LayoutMatrix[layoutRow, layoutColumn + 2]);

            return neighbours;
        }
    }

    public class DFS : SearchAlgorithm
    {
        public override void Solve()
        {
            
        }
    }

    public class BFS : SearchAlgorithm
    {
        public override void Solve()
        {
            var x = GetPossibleNextMoves(1);
            var x1 = GetPossibleNextMoves(4);
            var x2 = GetPossibleNextMoves(5);
            var x3 = GetPossibleNextMoves(8);
            var x4 = GetPossibleNextMoves(13);
            var x5 = GetPossibleNextMoves(16);
            var x6 = GetPossibleNextMoves(2);
            var x7 = GetPossibleNextMoves(14);
            //Implement BFS Algorithm
        }
    }

    public class A_STAR : SearchAlgorithm
    {
        public override void Solve()
        {
            //Implement A* Algorithm
        }
    }
}
