using Maze_DFS_BFS.Algorithms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maze_DFS_BFS.Models
{
    public class MazeModel
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public int[,] LayoutMatrix { get; set; }
        public int[,] MainMatrix { get; set; }

        public MazeModel() : this(0, 0) { }

        public MazeModel(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        public List<int> SolveMaze(SearchAlgorithm algorithm)
        {
            (algorithm.Matrix, algorithm.CompletedMatrix) = (MainMatrix, LayoutMatrix);
            algorithm.Solve();
            return algorithm.Solution;
        }

        private int[,] TransformMatrixToDefault()
        {
            return new int[3, 3];
        }
    }
}
