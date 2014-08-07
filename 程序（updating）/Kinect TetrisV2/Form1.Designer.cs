namespace Kinect_TetrisV2
{

    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为              /// false。</param>
        
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MainMenu(this.components);
            this.gameMenu = new System.Windows.Forms.MenuItem();
            this.startMenu = new System.Windows.Forms.MenuItem();
            this.stopMenu = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.exitMenu = new System.Windows.Forms.MenuItem();
            this.helpMenu = new System.Windows.Forms.MenuItem();
            this.aboutMenu = new System.Windows.Forms.MenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.linesLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nextPanel = new System.Windows.Forms.Panel();
            this.screenPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 300;
            this.timer.Tick += new System.EventHandler(this.OnTimer);
            // 
            // menuStrip
            // 
            this.menuStrip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.gameMenu,
            this.helpMenu});
            // 
            // gameMenu
            // 
            this.gameMenu.Index = 0;
            this.gameMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.startMenu,
            this.stopMenu,
            this.menuItem4,
            this.exitMenu});
            this.gameMenu.Text = "文件(&F)";
            // 
            // startMenu
            // 
            this.startMenu.Index = 0;
            this.startMenu.Text = "开始(&S)";
            this.startMenu.Click += new System.EventHandler(this.startMenu_Click);
            // 
            // stopMenu
            // 
            this.stopMenu.Enabled = false;
            this.stopMenu.Index = 1;
            this.stopMenu.Text = "停止(&T)";
            this.stopMenu.Click += new System.EventHandler(this.stopMenu_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // exitMenu
            // 
            this.exitMenu.Index = 3;
            this.exitMenu.Text = "退出(&X)";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.Index = 1;
            this.helpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.aboutMenu});
            this.helpMenu.Text = "帮助(&H)";
            // 
            // aboutMenu
            // 
            this.aboutMenu.Index = 0;
            this.aboutMenu.Text = "关于俄罗斯方块(&A)";
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox1.Location = new System.Drawing.Point(579, 256);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(76, 23);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.Text = "0";
            // 
            // linesLabel
            // 
            this.linesLabel.Location = new System.Drawing.Point(581, 229);
            this.linesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linesLabel.Name = "linesLabel";
            this.linesLabel.Size = new System.Drawing.Size(75, 20);
            this.linesLabel.TabIndex = 18;
            this.linesLabel.Text = "0";
            // 
            // scoreLabel
            // 
            this.scoreLabel.Location = new System.Drawing.Point(581, 199);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(75, 20);
            this.scoreLabel.TabIndex = 17;
            this.scoreLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(485, 259);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "速 度：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(485, 229);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "行 数：";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(485, 199);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "分 数：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(485, 541);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Kinect状态";
            // 
            // nextPanel
            // 
            this.nextPanel.BackColor = System.Drawing.Color.White;
            this.nextPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nextPanel.Location = new System.Drawing.Point(488, 0);
            this.nextPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nextPanel.Name = "nextPanel";
            this.nextPanel.Size = new System.Drawing.Size(207, 194);
            this.nextPanel.TabIndex = 12;
            // 
            // screenPanel
            // 
            this.screenPanel.BackColor = System.Drawing.Color.White;
            this.screenPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.screenPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.screenPanel.Location = new System.Drawing.Point(0, 0);
            this.screenPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.screenPanel.Name = "screenPanel";
            this.screenPanel.Size = new System.Drawing.Size(399, 719);
            this.screenPanel.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(488, 289);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 194);
            this.panel1.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(488, 570);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 255);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(616, 589);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "旋转方块";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(616, 645);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "左移方块";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(616, 712);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "右移方块";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(616, 771);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "加速下落";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(485, 499);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(213, 15);
            this.label9.TabIndex = 26;
            this.label9.Text = "Kinect举起手来 游戏帮助说明";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 719);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.linesLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nextPanel);
            this.Controls.Add(this.screenPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Menu = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Kinect举起手来";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.MainMenu menuStrip;
        private System.Windows.Forms.MenuItem gameMenu;
        private System.Windows.Forms.MenuItem startMenu;
        private System.Windows.Forms.MenuItem stopMenu;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem exitMenu;
        private System.Windows.Forms.MenuItem helpMenu;
        private System.Windows.Forms.MenuItem aboutMenu;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label linesLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel nextPanel;
        private System.Windows.Forms.Panel screenPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}