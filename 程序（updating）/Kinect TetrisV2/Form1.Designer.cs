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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.nextPanel = new System.Windows.Forms.Panel();
            this.screenPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.gameMenu.Text = "File(&F)";
            // 
            // startMenu
            // 
            this.startMenu.Index = 0;
            this.startMenu.Text = "Start(&S)";
            this.startMenu.Click += new System.EventHandler(this.startMenu_Click);
            // 
            // stopMenu
            // 
            this.stopMenu.Enabled = false;
            this.stopMenu.Index = 1;
            this.stopMenu.Text = "Stop(&T)";
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
            this.exitMenu.Text = "Exit(&X)";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.Index = 1;
            this.helpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.aboutMenu});
            this.helpMenu.Text = "Help(&H)";
            // 
            // aboutMenu
            // 
            this.aboutMenu.Index = 0;
            this.aboutMenu.Text = "About Tetris(&A)";
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
            this.comboBox1.Location = new System.Drawing.Point(1063, 296);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(76, 23);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.Text = "0";
            // 
            // linesLabel
            // 
            this.linesLabel.Location = new System.Drawing.Point(1064, 272);
            this.linesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linesLabel.Name = "linesLabel";
            this.linesLabel.Size = new System.Drawing.Size(75, 20);
            this.linesLabel.TabIndex = 18;
            this.linesLabel.Text = "0";
            // 
            // scoreLabel
            // 
            this.scoreLabel.Location = new System.Drawing.Point(1064, 243);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(75, 20);
            this.scoreLabel.TabIndex = 17;
            this.scoreLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(990, 302);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Speed：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(990, 272);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Line：";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(990, 243);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Score：";
            // 
            // nextPanel
            // 
            this.nextPanel.BackColor = System.Drawing.Color.White;
            this.nextPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nextPanel.Location = new System.Drawing.Point(993, 32);
            this.nextPanel.Margin = new System.Windows.Forms.Padding(4);
            this.nextPanel.Name = "nextPanel";
            this.nextPanel.Size = new System.Drawing.Size(207, 194);
            this.nextPanel.TabIndex = 12;
            // 
            // screenPanel
            // 
            this.screenPanel.BackColor = System.Drawing.Color.White;
            this.screenPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.screenPanel.Location = new System.Drawing.Point(409, 32);
            this.screenPanel.Margin = new System.Windows.Forms.Padding(4);
            this.screenPanel.Name = "screenPanel";
            this.screenPanel.Size = new System.Drawing.Size(480, 600);
            this.screenPanel.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(993, 344);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 194);
            this.panel1.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(616, 771);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Fall fast";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(81, 32);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(207, 194);
            this.panel2.TabIndex = 26;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(81, 291);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 236);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 649);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.linesLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nextPanel);
            this.Controls.Add(this.screenPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Menu = this.menuStrip;
            this.Name = "Form1";
            this.Text = "KinectTetris";
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
        private System.Windows.Forms.Panel nextPanel;
        private System.Windows.Forms.Panel screenPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
