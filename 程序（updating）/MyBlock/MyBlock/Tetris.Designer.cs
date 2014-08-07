namespace MyBlock
{
    partial class Tetris
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
            this.pbRun = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.lblReady = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbRun
            // 
            this.pbRun.BackColor = System.Drawing.Color.Black;
            this.pbRun.Location = new System.Drawing.Point(12, 12);
            this.pbRun.Name = "pbRun";
            this.pbRun.Size = new System.Drawing.Size(296, 500);
            this.pbRun.TabIndex = 0;
            this.pbRun.TabStop = false;
            this.pbRun.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRun_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Controls.Add(this.lblLevel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btStart);
            this.panel1.Controls.Add(this.lblReady);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(325, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(136, 530);
            this.panel1.TabIndex = 1;
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.White;
            this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblScore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScore.Location = new System.Drawing.Point(62, 257);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(52, 28);
            this.lblScore.TabIndex = 6;
            this.lblScore.Paint += new System.Windows.Forms.PaintEventHandler(this.lblScore_Paint);
            // 
            // lblLevel
            // 
            this.lblLevel.BackColor = System.Drawing.Color.White;
            this.lblLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLevel.Location = new System.Drawing.Point(62, 214);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(52, 27);
            this.lblLevel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "分数：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "级别：";
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(18, 170);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(18, 141);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "开始";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // lblReady
            // 
            this.lblReady.BackColor = System.Drawing.Color.Black;
            this.lblReady.Location = new System.Drawing.Point(16, 12);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(80, 80);
            this.lblReady.TabIndex = 0;
            this.lblReady.Paint += new System.Windows.Forms.PaintEventHandler(this.lblReady_Paint);
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 530);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbRun);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Tetris";
            this.Text = "俄罗斯方块V1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tetris_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tetris_KeyDown);
            this.Load += new System.EventHandler(this.Tetris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRun;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblLevel;
    }
}

