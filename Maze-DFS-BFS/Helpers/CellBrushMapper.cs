using System.Collections.Generic;
using System.Drawing;

namespace Maze_DFS_BFS.Helpers
{
    public static class CellBrushMapper
    {
        private static Dictionary<CellState, SolidBrush> _stateBrushMap = new Dictionary<CellState, SolidBrush>()
        {
            { CellState.Unassigned, new SolidBrush(Color.White) },
            { CellState.Start, new SolidBrush(Color.Red) },
            { CellState.Border, new SolidBrush(Color.Black) },
            { CellState.Finish, new SolidBrush(Color.Blue) },
            { CellState.Solution, new SolidBrush(Color.Green) },
            { CellState.Visited, new SolidBrush(Color.Yellow) }
        };

        public static SolidBrush GetBrush(CellState state) => _stateBrushMap[state];
    }
}
