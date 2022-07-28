
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectMatrixSize = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectSearchType = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBFS = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDFS = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAStar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSolve = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfigurationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectStartPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectEndPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDrawBorders = new System.Windows.Forms.ToolStripMenuItem();
            this.btnColorsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetStartColor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetColorFinish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuItem,
            this.btnConfigurationItem,
            this.btnColorsItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainMenuItem
            // 
            this.mainMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSelectMatrixSize,
            this.btnSelectSearchType,
            this.btnSolve});
            this.mainMenuItem.Name = "mainMenuItem";
            this.mainMenuItem.Size = new System.Drawing.Size(92, 20);
            this.mainMenuItem.Text = "Menu główne";
            // 
            // btnSelectMatrixSize
            // 
            this.btnSelectMatrixSize.Name = "btnSelectMatrixSize";
            this.btnSelectMatrixSize.Size = new System.Drawing.Size(218, 22);
            this.btnSelectMatrixSize.Text = "Wskaż rozmiar macierzy";
            this.btnSelectMatrixSize.Click += new System.EventHandler(this.btnSelectMatrixSize_Click);
            // 
            // btnSelectSearchType
            // 
            this.btnSelectSearchType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBFS,
            this.btnDFS,
            this.btnAStar});
            this.btnSelectSearchType.Name = "btnSelectSearchType";
            this.btnSelectSearchType.Size = new System.Drawing.Size(218, 22);
            this.btnSelectSearchType.Text = "Wybierz typ przeszukiwania";
            // 
            // btnBFS
            // 
            this.btnBFS.Checked = true;
            this.btnBFS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnBFS.Name = "btnBFS";
            this.btnBFS.Size = new System.Drawing.Size(94, 22);
            this.btnBFS.Text = "BFS";
            this.btnBFS.Click += new System.EventHandler(this.btnBFS_Click);
            // 
            // btnDFS
            // 
            this.btnDFS.Name = "btnDFS";
            this.btnDFS.Size = new System.Drawing.Size(94, 22);
            this.btnDFS.Text = "DFS";
            this.btnDFS.Click += new System.EventHandler(this.btnDFS_Click);
            // 
            // btnAStar
            // 
            this.btnAStar.Name = "btnAStar";
            this.btnAStar.Size = new System.Drawing.Size(94, 22);
            this.btnAStar.Text = "A*";
            this.btnAStar.Click += new System.EventHandler(this.btnAStar_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(218, 22);
            this.btnSolve.Text = "Rozwiąż";
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnConfigurationItem
            // 
            this.btnConfigurationItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSelectStartPoint,
            this.btnSelectEndPoint,
            this.btnDrawBorders});
            this.btnConfigurationItem.Name = "btnConfigurationItem";
            this.btnConfigurationItem.Size = new System.Drawing.Size(86, 20);
            this.btnConfigurationItem.Text = "Konfiguracja";
            // 
            // btnSelectStartPoint
            // 
            this.btnSelectStartPoint.Name = "btnSelectStartPoint";
            this.btnSelectStartPoint.Size = new System.Drawing.Size(201, 22);
            this.btnSelectStartPoint.Text = "Zaznacz punkt startowy";
            this.btnSelectStartPoint.Click += new System.EventHandler(this.btnSelectStartPoint_Click);
            // 
            // btnSelectEndPoint
            // 
            this.btnSelectEndPoint.Name = "btnSelectEndPoint";
            this.btnSelectEndPoint.Size = new System.Drawing.Size(201, 22);
            this.btnSelectEndPoint.Text = "Zaznacz punkt końcowy";
            this.btnSelectEndPoint.Click += new System.EventHandler(this.btnSelectEndPoint_Click);
            // 
            // btnDrawBorders
            // 
            this.btnDrawBorders.Name = "btnDrawBorders";
            this.btnDrawBorders.Size = new System.Drawing.Size(201, 22);
            this.btnDrawBorders.Text = "Narysuj sciany";
            this.btnDrawBorders.Click += new System.EventHandler(this.btnDrawBorders_Click);
            // 
            // btnColorsItem
            // 
            this.btnColorsItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSetStartColor,
            this.btnSetColorFinish});
            this.btnColorsItem.Name = "btnColorsItem";
            this.btnColorsItem.Size = new System.Drawing.Size(79, 20);
            this.btnColorsItem.Text = "Koloryzacja";
            // 
            // btnSetStartColor
            // 
            this.btnSetStartColor.Name = "btnSetStartColor";
            this.btnSetStartColor.Size = new System.Drawing.Size(199, 22);
            this.btnSetStartColor.Text = "Kolor węzła startowego";
            this.btnSetStartColor.Click += new System.EventHandler(this.btnSetStartColor_Click);
            // 
            // btnSetColorFinish
            // 
            this.btnSetColorFinish.Name = "btnSetColorFinish";
            this.btnSetColorFinish.Size = new System.Drawing.Size(199, 22);
            this.btnSetColorFinish.Text = "Kolor węzła końcowego";
            this.btnSetColorFinish.Click += new System.EventHandler(this.btnSetColorFinish_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "Labirynt - Tree search";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSelectMatrixSize;
        private System.Windows.Forms.ToolStripMenuItem btnSelectSearchType;
        private System.Windows.Forms.ToolStripMenuItem btnBFS;
        private System.Windows.Forms.ToolStripMenuItem btnDFS;
        private System.Windows.Forms.ToolStripMenuItem btnConfigurationItem;
        private System.Windows.Forms.ToolStripMenuItem btnSelectStartPoint;
        private System.Windows.Forms.ToolStripMenuItem btnSelectEndPoint;
        private System.Windows.Forms.ToolStripMenuItem btnDrawBorders;
        private System.Windows.Forms.ToolStripMenuItem btnColorsItem;
        private System.Windows.Forms.ToolStripMenuItem btnSetStartColor;
        private System.Windows.Forms.ToolStripMenuItem btnSetColorFinish;
        private System.Windows.Forms.ToolStripMenuItem btnSolve;
        private System.Windows.Forms.ToolStripMenuItem btnAStar;
    }
}

