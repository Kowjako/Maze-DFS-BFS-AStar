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

        public static int StartPointIndex { get; set; }
        public static int EndPointIndex { get; set; }

        public static Color StartColor { get; set; } = Color.Orchid;
        public static Color FinishColor { get; set; } = Color.DodgerBlue;
    }

    public static class Extensions
    {
        public static void PushMany<T>(this Stack<T> stack, IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                stack.Push(item);
            }
        }

        public static void EnqueueMany<T>(this Queue<T> queue, IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                queue.Enqueue(item);
            }
        }
    }
}
