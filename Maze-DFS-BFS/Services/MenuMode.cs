using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maze_DFS_BFS.Services
{
    public enum SearchMode
    {
        BFS = 1,
        DFS = 2,
        A_STAR = 3
    }

    public enum ConfigType
    {
        AssigningStart = 1,
        AssigningFinish = 2,
        DrawingBorders = 3
    }

    public static class MenuMode
    {
        public static bool IsStartPointAssigned { get; set; }
        public static bool IsFinishPointAssigned { get; set; }
        public static SearchMode SearchMode { get; set; } = SearchMode.BFS;
        public static ConfigType ConfigType { get; set; }

        public static Color StartColor { get; set; } = Color.Maroon;
        public static Color FinishColor { get; set; } = Color.Lavender;
    }
}
