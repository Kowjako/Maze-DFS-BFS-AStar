using System.Windows.Forms;

namespace Maze_DFS_BFS
{
    /// <summary>
    /// Standardowy WinForms Panel z włączonym podwójnym buforowaniem
    /// </summary>
    public class DXPanel : Panel
    {
        public DXPanel()
        {
            DoubleBuffered = true;
        }
    }
}
