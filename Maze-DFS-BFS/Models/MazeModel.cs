using System;
using System.Collections.Generic;
using System.Text;

namespace Maze_DFS_BFS.Models
{
    public class MazeModel
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public MazeModel() : this(0, 0)
        {

        }

        public MazeModel(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }
    }
}
