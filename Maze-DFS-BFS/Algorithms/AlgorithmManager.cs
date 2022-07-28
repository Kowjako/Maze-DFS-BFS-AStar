using System;
using System.Collections.Generic;
using System.Text;

namespace Maze_DFS_BFS.Algorithms
{
    public abstract class SearchAlgorithm
    {
        //Matrix to solve
        public int[,] Matrix { get; set; }

        //Matrix included borders
        public int[,] CompletedMatrix { get; set; }

        //Sorted nodes as solution
        public List<int> Solution { get; set; }

        public abstract void Solve();
    }

    public class DFS : SearchAlgorithm
    {
        public override void Solve()
        {
            //Implement DFS Algorithm
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
