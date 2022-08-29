namespace Maze_DFS_BFS.Models
{
    public enum CellState
    {
        Border,
        Start,
        Finish,
        Unassigned,
        Solution,
        Visited,
        Current
    }

    public enum Mode
    {
        AssignStart,
        AssignFinish,
        None
    }

    public enum Algorithm
    {
        DFS, BFS, A_STAR
    }
}
