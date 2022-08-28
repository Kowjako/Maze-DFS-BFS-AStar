
namespace Maze_DFS_BFS
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.konfiguracjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerateGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectStart = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectFinish = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerateMaze = new System.Windows.Forms.ToolStripMenuItem();
            this.rozwiążLabiryntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dfsBtnSolve = new System.Windows.Forms.ToolStripMenuItem();
            this.bfsBtnSolve = new System.Windows.Forms.ToolStripMenuItem();
            this.astarBtnSolve = new System.Windows.Forms.ToolStripMenuItem();
            this.mainGrid = new Maze_DFS_BFS.DXPanel();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.konfiguracjaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(700, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // konfiguracjaToolStripMenuItem
            // 
            this.konfiguracjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGenerateGrid,
            this.btnSelectStart,
            this.btnSelectFinish,
            this.btnGenerateMaze,
            this.rozwiążLabiryntToolStripMenuItem});
            this.konfiguracjaToolStripMenuItem.Name = "konfiguracjaToolStripMenuItem";
            this.konfiguracjaToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.konfiguracjaToolStripMenuItem.Text = "Konfiguracja";
            // 
            // btnGenerateGrid
            // 
            this.btnGenerateGrid.Name = "btnGenerateGrid";
            this.btnGenerateGrid.Size = new System.Drawing.Size(159, 22);
            this.btnGenerateGrid.Text = "Generuj macierz";
            this.btnGenerateGrid.Click += new System.EventHandler(this.btnGenerateGrid_Click);
            // 
            // btnSelectStart
            // 
            this.btnSelectStart.Name = "btnSelectStart";
            this.btnSelectStart.Size = new System.Drawing.Size(159, 22);
            this.btnSelectStart.Text = "Wskaż początek";
            this.btnSelectStart.Click += new System.EventHandler(this.btnSelectStart_Click);
            // 
            // btnSelectFinish
            // 
            this.btnSelectFinish.Name = "btnSelectFinish";
            this.btnSelectFinish.Size = new System.Drawing.Size(159, 22);
            this.btnSelectFinish.Text = "Wskaż koniec";
            this.btnSelectFinish.Click += new System.EventHandler(this.btnSelectFinish_Click);
            // 
            // btnGenerateMaze
            // 
            this.btnGenerateMaze.Name = "btnGenerateMaze";
            this.btnGenerateMaze.Size = new System.Drawing.Size(159, 22);
            this.btnGenerateMaze.Text = "Generuj labirynt";
            this.btnGenerateMaze.Click += new System.EventHandler(this.btnGenerateMaze_Click);
            // 
            // rozwiążLabiryntToolStripMenuItem
            // 
            this.rozwiążLabiryntToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dfsBtnSolve,
            this.bfsBtnSolve,
            this.astarBtnSolve});
            this.rozwiążLabiryntToolStripMenuItem.Name = "rozwiążLabiryntToolStripMenuItem";
            this.rozwiążLabiryntToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.rozwiążLabiryntToolStripMenuItem.Text = "Rozwiąż labirynt";
            // 
            // dfsBtnSolve
            // 
            this.dfsBtnSolve.Name = "dfsBtnSolve";
            this.dfsBtnSolve.Size = new System.Drawing.Size(94, 22);
            this.dfsBtnSolve.Text = "DFS";
            this.dfsBtnSolve.Click += new System.EventHandler(this.dfsBtnSolve_Click);
            // 
            // bfsBtnSolve
            // 
            this.bfsBtnSolve.Name = "bfsBtnSolve";
            this.bfsBtnSolve.Size = new System.Drawing.Size(94, 22);
            this.bfsBtnSolve.Text = "BFS";
            this.bfsBtnSolve.Click += new System.EventHandler(this.bfsBtnSolve_Click);
            // 
            // astarBtnSolve
            // 
            this.astarBtnSolve.Name = "astarBtnSolve";
            this.astarBtnSolve.Size = new System.Drawing.Size(94, 22);
            this.astarBtnSolve.Text = "A*";
            this.astarBtnSolve.Click += new System.EventHandler(this.astarBtnSolve_Click);
            // 
            // mainGrid
            // 
            this.mainGrid.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGrid.Location = new System.Drawing.Point(0, 24);
            this.mainGrid.Name = "mainGrid";
            this.mainGrid.Size = new System.Drawing.Size(700, 700);
            this.mainGrid.TabIndex = 1;
            this.mainGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.mainGrid_Paint);
            this.mainGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainGrid_MouseDown);
            this.mainGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainGrid_MouseMove);
            // 
            // animationTimer
            // 
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 724);
            this.Controls.Add(this.mainGrid);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainView";
            this.Text = "Maze - AI search";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem konfiguracjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnGenerateGrid;
        private DXPanel mainGrid;
        private System.Windows.Forms.ToolStripMenuItem btnSelectStart;
        private System.Windows.Forms.ToolStripMenuItem btnSelectFinish;
        private System.Windows.Forms.ToolStripMenuItem btnGenerateMaze;
        private System.Windows.Forms.ToolStripMenuItem rozwiążLabiryntToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dfsBtnSolve;
        private System.Windows.Forms.ToolStripMenuItem bfsBtnSolve;
        private System.Windows.Forms.ToolStripMenuItem astarBtnSolve;
        private System.Windows.Forms.Timer animationTimer;
    }
}

