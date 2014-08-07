namespace Tetris2
{
    partial class FrmTetris
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTetris));
            this.TetrisMenuStrip = new System.Windows.Forms.MenuStrip();
            this.Game_ToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.New_toolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.Pause_toolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.Config_toolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_toolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.About_ToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.pbRun = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblReady = new System.Windows.Forms.Label();
            this.TetrisMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TetrisMenuStrip
            // 
            this.TetrisMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Game_ToolStrip,
            this.About_ToolStrip});
            this.TetrisMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TetrisMenuStrip.Name = "TetrisMenuStrip";
            this.TetrisMenuStrip.Size = new System.Drawing.Size(426, 24);
            this.TetrisMenuStrip.TabIndex = 0;
            this.TetrisMenuStrip.Text = "menuStrip1";
            // 
            // Game_ToolStrip
            // 
            this.Game_ToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New_toolStrip,
            this.Pause_toolStrip,
            this.Config_toolStrip,
            this.Exit_toolStrip});
            this.Game_ToolStrip.Name = "Game_ToolStrip";
            this.Game_ToolStrip.Size = new System.Drawing.Size(59, 20);
            this.Game_ToolStrip.Text = "游戏(&G)";
            // 
            // New_toolStrip
            // 
            this.New_toolStrip.Name = "New_toolStrip";
            this.New_toolStrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.New_toolStrip.Size = new System.Drawing.Size(165, 22);
            this.New_toolStrip.Text = "新游戏(&N)";
            this.New_toolStrip.Click += new System.EventHandler(this.New_toolStrip_Click);
            // 
            // Pause_toolStrip
            // 
            this.Pause_toolStrip.Enabled = false;
            this.Pause_toolStrip.Name = "Pause_toolStrip";
            this.Pause_toolStrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.Pause_toolStrip.Size = new System.Drawing.Size(165, 22);
            this.Pause_toolStrip.Text = "暂停(&P)";
            this.Pause_toolStrip.Click += new System.EventHandler(this.Pause_toolStrip_Click);
            // 
            // Config_toolStrip
            // 
            this.Config_toolStrip.Name = "Config_toolStrip";
            this.Config_toolStrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.Config_toolStrip.Size = new System.Drawing.Size(165, 22);
            this.Config_toolStrip.Text = "设置(&C)";
            this.Config_toolStrip.Click += new System.EventHandler(this.Config_toolStrip_Click);
            // 
            // Exit_toolStrip
            // 
            this.Exit_toolStrip.Name = "Exit_toolStrip";
            this.Exit_toolStrip.Size = new System.Drawing.Size(165, 22);
            this.Exit_toolStrip.Text = "退出(&X)";
            this.Exit_toolStrip.Click += new System.EventHandler(this.Exit_toolStrip_Click);
            // 
            // About_ToolStrip
            // 
            this.About_ToolStrip.Name = "About_ToolStrip";
            this.About_ToolStrip.Size = new System.Drawing.Size(59, 20);
            this.About_ToolStrip.Text = "关于(&A)";
            this.About_ToolStrip.Click += new System.EventHandler(this.About_ToolStrip_Click);
            // 
            // pbRun
            // 
            this.pbRun.BackColor = System.Drawing.Color.Black;
            this.pbRun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRun.Location = new System.Drawing.Point(12, 40);
            this.pbRun.Name = "pbRun";
            this.pbRun.Size = new System.Drawing.Size(300, 400);
            this.pbRun.TabIndex = 1;
            this.pbRun.TabStop = false;
            this.pbRun.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRun_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Controls.Add(this.lblReady);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(310, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(116, 429);
            this.panel1.TabIndex = 2;
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.SystemColors.Control;
            this.lblScore.Location = new System.Drawing.Point(8, 139);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(100, 100);
            this.lblScore.TabIndex = 2;
            this.lblScore.Paint += new System.Windows.Forms.PaintEventHandler(this.lblScore_Paint);
            // 
            // lblReady
            // 
            this.lblReady.BackColor = System.Drawing.Color.Black;
            this.lblReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReady.Location = new System.Drawing.Point(10, 16);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(100, 100);
            this.lblReady.TabIndex = 0;
            this.lblReady.Paint += new System.Windows.Forms.PaintEventHandler(this.lblReady_Paint);
            // 
            // FrmTetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbRun);
            this.Controls.Add(this.TetrisMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.TetrisMenuStrip;
            this.MaximizeBox = false;
            this.Name = "FrmTetris";
            this.Text = "俄罗斯方块";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTetris_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTetris_KeyDown);
            this.Load += new System.EventHandler(this.FrmTetris_Load);
            this.TetrisMenuStrip.ResumeLayout(false);
            this.TetrisMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TetrisMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem Game_ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem About_ToolStrip;
        private System.Windows.Forms.PictureBox pbRun;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.ToolStripMenuItem New_toolStrip;
        private System.Windows.Forms.ToolStripMenuItem Pause_toolStrip;
        private System.Windows.Forms.ToolStripMenuItem Config_toolStrip;
        private System.Windows.Forms.ToolStripMenuItem Exit_toolStrip;
        private System.Windows.Forms.Label lblScore;
    }
}