using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Maze_DFS_BFS.Services
{
    public class LayoutGenerator_v2
    {
        public Size ClientSize { get; set; }
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }

        private const int WALL_SELECTED = 0;
        private const int UNASSIGNED_CELL = -1;
        private const int WALL_UNSELECTED = -2;

        /// <summary>
        /// Metoda tworzy calkowity panel dla algorytmu
        /// </summary>
        /// <returns></returns>
        public TableLayoutPanel GeneratePanel()
        {
            //Tworzymy dodatkowe kolumny na zaznaczanie scian
            var panel = new DoubleBufferedTable()
            {
                ColumnCount = ColumnNumber * 2 - 1,
                RowCount = RowNumber * 2 - 1,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Padding = new Padding(0)
            };        

            //Tworzymy rozmiary scian
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                if (i % 2 == 1)
                {
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10));
                }
                else
                {
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f / ColumnNumber));
                }            
            }

            for (int i = 0; i < panel.RowCount; i++)
            {
                if(i % 2 == 1)
                {
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
                }
                else
                {
                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f / RowNumber));
                }     
            }

            GenerateInsideControls(panel);
            GenerateBorders(panel);

            return panel;
        }

        /// <summary>
        /// Metoda generuje panele nie bedace granicami
        /// </summary>
        /// <param name="tpl">Grid</param>
        private void GenerateInsideControls(TableLayoutPanel tpl)
        {
            for (int i = 0; i < tpl.RowCount; i+= 2) 
            {
                for (int j = 0; j < tpl.ColumnCount; j += 2)
                {
                    var panel = CreatePanelAndAssign(tpl, i, j);
                    panel.Tag = (i / 2 * ((tpl.ColumnCount + 1) / 2) + j / 2 + 1).ToString();

                    panel.Click += Panel_Click;

                    var label = new Label();
                    label.Margin = new Padding(0);
                    label.Font = new Font("Arial", 13);
                    label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    label.AutoSize = false;
                    label.TextAlign = ContentAlignment.MiddleCenter;

                    int x = (panel.Size.Width - label.Size.Width) / 2;
                    int y = (panel.Size.Height - label.Size.Height) / 2;

                    label.Location = new Point(x, y);
                    label.Text = (i / 2 * ((tpl.ColumnCount + 1) / 2) + j / 2 + 1).ToString();
                    panel.SuspendLayout();
                    panel.Controls.Add(label);
                    panel.ResumeLayout();
                }
            }
        }

        /// <summary>
        /// Metoda ustawiajaca kolory i wezly poczatkowe i koncowe
        /// </summary>
        /// <param name="sender">Wywołujący zdarzenie</param>
        /// <param name="e">Parametry zdarzenia</param>
        private void Panel_Click(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            if (MenuMode.IsStartPointAssigned && MenuMode.IsFinishPointAssigned) return;
            if (!MenuMode.IsStartPointAssigned && MenuMode.ConfigType == ConfigType.AssigningStart)
            {
                panel.BackColor = MenuMode.StartColor;
                MenuMode.IsStartPointAssigned = true;
            }
            if (!MenuMode.IsFinishPointAssigned && MenuMode.ConfigType == ConfigType.AssigningFinish)
            {
                panel.BackColor = MenuMode.FinishColor;
                MenuMode.IsFinishPointAssigned = true;
            }
        }

        /// <summary>
        /// Metoda generuje panele jakie beda granicami
        /// </summary>
        /// <param name="tpl">Grid</param>
        private void GenerateBorders(TableLayoutPanel tpl)
        {
            for (int i = 0; i < tpl.RowCount; i += 1) 
            {
                for (int j = 0; j < tpl.ColumnCount; j += 1) 
                {
                    if (j % 2 == 1 || i % 2 == 1)
                    { 
                        var panel = CreatePanelAndAssign(tpl, i, j);
                        if(j % 2 == 1 && i % 2 == 1)
                        {
                            panel.BackColor = Color.Black;
                            panel.Tag = UNASSIGNED_CELL; 
                        }
                        else
                        {
                            panel.Tag = WALL_UNSELECTED;
                            panel.Click += delegate (object sender, EventArgs e)
                            {
                                if (MenuMode.ConfigType == ConfigType.DrawingBorders)
                                {
                                    panel.BackColor = Color.Black;
                                    panel.Tag = WALL_SELECTED;
                                }
                            };
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Metoda generujaca panel i umieszczajaca ja w grid
        /// </summary>
        /// <param name="tpl">Grid gdzie trzeba umiescic panel</param>
        /// <param name="row">Nr. wiersza</param>
        /// <param name="column">Nr. columny</param>
        /// <returns></returns>
        private Panel CreatePanelAndAssign(TableLayoutPanel tpl, int row, int column)
        {
            var panel = new Panel();
            panel.Margin = new Padding(0);
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.White;

            tpl.SetColumn(panel, column);
            tpl.SetRow(panel, row);
            tpl.Controls.Add(panel);

            return panel;
        }
    }

    public class DoubleBufferedTable : TableLayoutPanel
    {
        public DoubleBufferedTable()
        {
            DoubleBuffered = true;
        }
    }
}
