using System.Collections.Generic;

namespace Maze_DFS_BFS.Algorithms
{
    public abstract class SearchAlgorithm
    {
        private const int WALL = 0;
        protected readonly int StartIndex, EndIndex;

        public SearchAlgorithm(int startIndex, int endIndex)
        {
            Solution = new List<int>();
            StartIndex = startIndex;
            EndIndex = endIndex;
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

        //Find accesible neighbours
        protected virtual List<int> GetPossibleNextMoves(int actualIndexInMatrix)
        {
            var neighbours = new List<int>();

            //1. Calculate index for layout matrix
            var layoutRow = 2 * ((actualIndexInMatrix - 1) / Matrix.GetLength(1));
            var layoutColumn = GetColumn(actualIndexInMatrix);

            //2. Find neighbours index
            if (layoutRow != 0 && LayoutMatrix[layoutRow - 1, layoutColumn] != WALL)
                neighbours.Add(LayoutMatrix[layoutRow - 2, layoutColumn]);
            if (layoutRow != LayoutMatrix.GetLength(0) - 1 && LayoutMatrix[layoutRow + 1, layoutColumn] != WALL)
                neighbours.Add(LayoutMatrix[layoutRow + 2, layoutColumn]);
            if (layoutColumn != 0 && LayoutMatrix[layoutRow, layoutColumn - 1] != WALL)
                neighbours.Add(LayoutMatrix[layoutRow, layoutColumn - 2]);
            if (layoutColumn != LayoutMatrix.GetLength(1) - 1 && LayoutMatrix[layoutRow, layoutColumn + 1] != WALL)
                neighbours.Add(LayoutMatrix[layoutRow, layoutColumn + 2]);

            return neighbours;
        }
    }

    public class DFS : SearchAlgorithm
    {
        private Stack<int> _stack;

        public DFS(int sIndex, int eIndex) : base(sIndex, eIndex) { }

        public override void Solve()
        {
            
        }
    }

    public class BFS : SearchAlgorithm
    {
        public BFS(int sIndex, int eIndex) : base(sIndex, eIndex) { }

        public override void Solve()
        {

        }
    }

    public class A_STAR : SearchAlgorithm
    {
        public A_STAR(int sIndex, int eIndex) : base(sIndex, eIndex) { }

        public override void Solve()
        {

        }
    }
}
