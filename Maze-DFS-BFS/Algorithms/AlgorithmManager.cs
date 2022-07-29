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

        protected virtual List<int> GetPossibleNextMoves(int actualIndexInMatrix)
        {
            //Sprawdzamy korzystajac z LayoutMatrix
            var neighbours = new List<int>();
            for (var i = -1; i <= 1; i++) 
            {
                for (var j = -1; j <= 1; j++)
                {
                    
                }
            }
            return new List<int>();
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
