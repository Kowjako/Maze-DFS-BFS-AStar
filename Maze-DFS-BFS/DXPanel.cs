using System.Windows.Forms;

namespace Maze_DFS_BFS
{
    /// <summary>
    /// Standardowy WinForms Panel z włączonym podwójnym buforowaniem zeby uniknac freezow podczas animacji.
    /// </summary>
    public class DXPanel : Panel
    {
        public DXPanel()
        {
            DoubleBuffered = true;
        }
    }
}
