using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Maze_DFS_BFS.Services
{
    public interface IColorDialog
    {
        public Color SelectedColor { get; }
        public DialogResult ShowColorPicker();
    }

    public class ColorService : IColorDialog
    {
        private readonly ColorDialog _colorDialogBox;

        public Color SelectedColor => _colorDialogBox?.Color ?? Color.Black;

        public ColorService() => _colorDialogBox = new ColorDialog();

        public DialogResult ShowColorPicker() => _colorDialogBox.ShowDialog();
    }
}
