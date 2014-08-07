namespace Tetris
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
            this.pbRun = new System.Windows.Forms.PictureBox();
            this.lblReady = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDengJi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFenShu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbRun
            // 
            this.pbRun.BackColor = System.Drawing.Color.Black;
            this.pbRun.Location = new System.Drawing.Point(6, 9);
            this.pbRun.Name = "pbRun";
            this.pbRun.Size = new System.Drawing.Size(300, 500);
            this.pbRun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRun.TabIndex = 0;
            this.pbRun.TabStop = false;
            this.pbRun.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRun_Paint);
            // 
            // lblReady
            // 
            this.lblReady.BackColor = System.Drawing.Color.Black;
            this.lblReady.Location = new System.Drawing.Point(12, 9);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(100, 100);
            this.lblReady.TabIndex = 1;
            this.lblReady.Paint += new System.Windows.Forms.PaintEventHandler(this.lblReady_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDengJi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblFenShu);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btnStar);
            this.panel1.Controls.Add(this.lblReady);
            this.panel1.Location = new System.Drawing.Point(312, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 514);
            this.panel1.TabIndex = 2;
            // 
            // lblDengJi
            // 
            this.lblDengJi.AutoSize = true;
            this.lblDengJi.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblDengJi.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDengJi.Location = new System.Drawing.Point(58, 248);
            this.lblDengJi.Name = "lblDengJi";
            this.lblDengJi.Size = new System.Drawing.Size(14, 14);
            this.lblDengJi.TabIndex = 9;
            this.lblDengJi.Text = "0";
            this.lblDengJi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "等级：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFenShu
            // 
            this.lblFenShu.AutoSize = true;
            this.lblFenShu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblFenShu.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFenShu.Location = new System.Drawing.Point(58, 215);
            this.lblFenShu.Name = "lblFenShu";
            this.lblFenShu.Size = new System.Drawing.Size(14, 14);
            this.lblFenShu.TabIndex = 7;
            this.lblFenShu.Text = "0";
            this.lblFenShu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "积分：";
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(25, 173);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConfig.TabIndex = 4;
            this.btnConfig.Text = "设置";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(25, 144);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStar
            // 
            this.btnStar.Location = new System.Drawing.Point(25, 115);
            this.btnStar.Name = "btnStar";
            this.btnStar.Size = new System.Drawing.Size(75, 23);
            this.btnStar.TabIndex = 2;
            this.btnStar.Text = "开始";
            this.btnStar.UseVisualStyleBackColor = true;
            this.btnStar.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // FrmTetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 518);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbRun);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmTetris";
            this.Text = "俄罗斯方块";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTetris_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTetris_KeyDown);
            this.Load += new System.EventHandler(this.FrmTetris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDengJi;

        #endregion

        private System.Windows.Forms.PictureBox pbRun;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStar;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Label lblFenShu;
        private System.Windows.Forms.Label label2;
    }
}