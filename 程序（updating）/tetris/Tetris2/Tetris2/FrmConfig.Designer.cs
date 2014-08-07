namespace Tetris2
{
    partial class FrmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.lblSetBlock = new System.Windows.Forms.Label();
            this.lblBlockColor = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabConfig = new System.Windows.Forms.TabControl();
            this.tpgArgsConfig = new System.Windows.Forms.TabPage();
            this.gbEnvironment = new System.Windows.Forms.GroupBox();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.txtRectPix = new System.Windows.Forms.TextBox();
            this.txtVerticalNum = new System.Windows.Forms.TextBox();
            this.txtHorizonNum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbKeyBoard = new System.Windows.Forms.GroupBox();
            this.txtRotate = new System.Windows.Forms.TextBox();
            this.txtDrop = new System.Windows.Forms.TextBox();
            this.txtMoveRight = new System.Windows.Forms.TextBox();
            this.txtMoveLeft = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpgBlockConfig = new System.Windows.Forms.TabPage();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lsvBlockInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.tabConfig.SuspendLayout();
            this.tpgArgsConfig.SuspendLayout();
            this.gbEnvironment.SuspendLayout();
            this.gbKeyBoard.SuspendLayout();
            this.tpgBlockConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSetBlock
            // 
            this.lblSetBlock.BackColor = System.Drawing.Color.Black;
            this.lblSetBlock.Location = new System.Drawing.Point(20, 13);
            this.lblSetBlock.Name = "lblSetBlock";
            this.lblSetBlock.Size = new System.Drawing.Size(154, 154);
            this.lblSetBlock.TabIndex = 0;
            this.lblSetBlock.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblSetBlock_MouseClick);
            this.lblSetBlock.Paint += new System.Windows.Forms.PaintEventHandler(this.lblSetBlock_Paint);
            // 
            // lblBlockColor
            // 
            this.lblBlockColor.BackColor = System.Drawing.Color.Red;
            this.lblBlockColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBlockColor.Location = new System.Drawing.Point(20, 188);
            this.lblBlockColor.Name = "lblBlockColor";
            this.lblBlockColor.Size = new System.Drawing.Size(154, 20);
            this.lblBlockColor.TabIndex = 1;
            this.lblBlockColor.Click += new System.EventHandler(this.lblBlockColor_Click);
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.tpgArgsConfig);
            this.tabConfig.Controls.Add(this.tpgBlockConfig);
            this.tabConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabConfig.Location = new System.Drawing.Point(0, 0);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.SelectedIndex = 0;
            this.tabConfig.Size = new System.Drawing.Size(488, 333);
            this.tabConfig.TabIndex = 2;
            // 
            // tpgArgsConfig
            // 
            this.tpgArgsConfig.Controls.Add(this.gbEnvironment);
            this.tpgArgsConfig.Controls.Add(this.gbKeyBoard);
            this.tpgArgsConfig.Location = new System.Drawing.Point(4, 21);
            this.tpgArgsConfig.Name = "tpgArgsConfig";
            this.tpgArgsConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tpgArgsConfig.Size = new System.Drawing.Size(480, 308);
            this.tpgArgsConfig.TabIndex = 0;
            this.tpgArgsConfig.Text = "参数配置";
            this.tpgArgsConfig.UseVisualStyleBackColor = true;
            // 
            // gbEnvironment
            // 
            this.gbEnvironment.Controls.Add(this.lblBackColor);
            this.gbEnvironment.Controls.Add(this.txtRectPix);
            this.gbEnvironment.Controls.Add(this.txtVerticalNum);
            this.gbEnvironment.Controls.Add(this.txtHorizonNum);
            this.gbEnvironment.Controls.Add(this.label9);
            this.gbEnvironment.Controls.Add(this.label10);
            this.gbEnvironment.Controls.Add(this.label7);
            this.gbEnvironment.Controls.Add(this.label8);
            this.gbEnvironment.Location = new System.Drawing.Point(246, 18);
            this.gbEnvironment.Name = "gbEnvironment";
            this.gbEnvironment.Size = new System.Drawing.Size(185, 272);
            this.gbEnvironment.TabIndex = 1;
            this.gbEnvironment.TabStop = false;
            this.gbEnvironment.Text = "环境设置";
            // 
            // lblBackColor
            // 
            this.lblBackColor.BackColor = System.Drawing.SystemColors.Control;
            this.lblBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBackColor.Location = new System.Drawing.Point(99, 217);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(69, 21);
            this.lblBackColor.TabIndex = 10;
            this.lblBackColor.Click += new System.EventHandler(this.lblBackColor_Click);
            // 
            // txtRectPix
            // 
            this.txtRectPix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRectPix.Location = new System.Drawing.Point(99, 158);
            this.txtRectPix.Name = "txtRectPix";
            this.txtRectPix.Size = new System.Drawing.Size(69, 21);
            this.txtRectPix.TabIndex = 9;
            this.txtRectPix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorizonNum_KeyPress);
            // 
            // txtVerticalNum
            // 
            this.txtVerticalNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVerticalNum.Location = new System.Drawing.Point(99, 100);
            this.txtVerticalNum.Name = "txtVerticalNum";
            this.txtVerticalNum.Size = new System.Drawing.Size(69, 21);
            this.txtVerticalNum.TabIndex = 8;
            this.txtVerticalNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorizonNum_KeyPress);
            // 
            // txtHorizonNum
            // 
            this.txtHorizonNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHorizonNum.Location = new System.Drawing.Point(99, 42);
            this.txtHorizonNum.Name = "txtHorizonNum";
            this.txtHorizonNum.Size = new System.Drawing.Size(69, 21);
            this.txtHorizonNum.TabIndex = 7;
            this.txtHorizonNum.Leave += new System.EventHandler(this.txtHorizonNum_Leave);
            this.txtHorizonNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorizonNum_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "格子像素";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "背景色";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "水平格子数";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "垂直格子数";
            // 
            // gbKeyBoard
            // 
            this.gbKeyBoard.Controls.Add(this.txtRotate);
            this.gbKeyBoard.Controls.Add(this.txtDrop);
            this.gbKeyBoard.Controls.Add(this.txtMoveRight);
            this.gbKeyBoard.Controls.Add(this.txtMoveLeft);
            this.gbKeyBoard.Controls.Add(this.label3);
            this.gbKeyBoard.Controls.Add(this.label4);
            this.gbKeyBoard.Controls.Add(this.label2);
            this.gbKeyBoard.Controls.Add(this.label1);
            this.gbKeyBoard.Location = new System.Drawing.Point(18, 18);
            this.gbKeyBoard.Name = "gbKeyBoard";
            this.gbKeyBoard.Size = new System.Drawing.Size(185, 272);
            this.gbKeyBoard.TabIndex = 0;
            this.gbKeyBoard.TabStop = false;
            this.gbKeyBoard.Text = "键盘设置";
            // 
            // txtRotate
            // 
            this.txtRotate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRotate.Location = new System.Drawing.Point(70, 216);
            this.txtRotate.Name = "txtRotate";
            this.txtRotate.ReadOnly = true;
            this.txtRotate.Size = new System.Drawing.Size(69, 21);
            this.txtRotate.TabIndex = 9;
            this.txtRotate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRotate_KeyDown);
            // 
            // txtDrop
            // 
            this.txtDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrop.Location = new System.Drawing.Point(70, 158);
            this.txtDrop.Name = "txtDrop";
            this.txtDrop.ReadOnly = true;
            this.txtDrop.Size = new System.Drawing.Size(69, 21);
            this.txtDrop.TabIndex = 8;
            this.txtDrop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRotate_KeyDown);
            // 
            // txtMoveRight
            // 
            this.txtMoveRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoveRight.Location = new System.Drawing.Point(70, 100);
            this.txtMoveRight.Name = "txtMoveRight";
            this.txtMoveRight.ReadOnly = true;
            this.txtMoveRight.Size = new System.Drawing.Size(69, 21);
            this.txtMoveRight.TabIndex = 7;
            this.txtMoveRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRotate_KeyDown);
            // 
            // txtMoveLeft
            // 
            this.txtMoveLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoveLeft.Location = new System.Drawing.Point(70, 42);
            this.txtMoveLeft.Name = "txtMoveLeft";
            this.txtMoveLeft.ReadOnly = true;
            this.txtMoveLeft.Size = new System.Drawing.Size(69, 21);
            this.txtMoveLeft.TabIndex = 6;
            this.txtMoveLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRotate_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "向下";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "变形";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "向右";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "向左";
            // 
            // tpgBlockConfig
            // 
            this.tpgBlockConfig.Controls.Add(this.btnModify);
            this.tpgBlockConfig.Controls.Add(this.btnClear);
            this.tpgBlockConfig.Controls.Add(this.btnDel);
            this.tpgBlockConfig.Controls.Add(this.btnAdd);
            this.tpgBlockConfig.Controls.Add(this.lsvBlockInfo);
            this.tpgBlockConfig.Controls.Add(this.lblSetBlock);
            this.tpgBlockConfig.Controls.Add(this.lblBlockColor);
            this.tpgBlockConfig.Location = new System.Drawing.Point(4, 21);
            this.tpgBlockConfig.Name = "tpgBlockConfig";
            this.tpgBlockConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tpgBlockConfig.Size = new System.Drawing.Size(480, 308);
            this.tpgBlockConfig.TabIndex = 1;
            this.tpgBlockConfig.Text = "砖块样式配置";
            this.tpgBlockConfig.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(112, 269);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(61, 23);
            this.btnModify.TabIndex = 6;
            this.btnModify.Text = "修改(&M)";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(22, 269);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(64, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "清空(&C)";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(112, 228);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(62, 23);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "删除(&D)";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(22, 228);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lsvBlockInfo
            // 
            this.lsvBlockInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvBlockInfo.FullRowSelect = true;
            this.lsvBlockInfo.GridLines = true;
            this.lsvBlockInfo.Location = new System.Drawing.Point(193, 13);
            this.lsvBlockInfo.MultiSelect = false;
            this.lsvBlockInfo.Name = "lsvBlockInfo";
            this.lsvBlockInfo.Size = new System.Drawing.Size(284, 289);
            this.lsvBlockInfo.TabIndex = 2;
            this.lsvBlockInfo.UseCompatibleStateImageBehavior = false;
            this.lsvBlockInfo.View = System.Windows.Forms.View.Details;
            this.lsvBlockInfo.SelectedIndexChanged += new System.EventHandler(this.lsvBlockInfo_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编码";
            this.columnHeader1.Width = 177;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "颜色";
            this.columnHeader2.Width = 69;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(220, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(360, 346);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(22, 346);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(139, 23);
            this.btnDefault.TabIndex = 5;
            this.btnDefault.Text = "还原为默认配置(&D)";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 381);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmConfig";
            this.Text = "配置窗体";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.tabConfig.ResumeLayout(false);
            this.tpgArgsConfig.ResumeLayout(false);
            this.gbEnvironment.ResumeLayout(false);
            this.gbEnvironment.PerformLayout();
            this.gbKeyBoard.ResumeLayout(false);
            this.gbKeyBoard.PerformLayout();
            this.tpgBlockConfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSetBlock;
        private System.Windows.Forms.Label lblBlockColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TabControl tabConfig;
        private System.Windows.Forms.TabPage tpgArgsConfig;
        private System.Windows.Forms.TabPage tpgBlockConfig;
        private System.Windows.Forms.ListView lsvBlockInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.GroupBox gbKeyBoard;
        private System.Windows.Forms.GroupBox gbEnvironment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMoveLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRectPix;
        private System.Windows.Forms.TextBox txtVerticalNum;
        private System.Windows.Forms.TextBox txtHorizonNum;
        private System.Windows.Forms.TextBox txtRotate;
        private System.Windows.Forms.TextBox txtDrop;
        private System.Windows.Forms.TextBox txtMoveRight;
        private System.Windows.Forms.Label lblBackColor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDefault;
    }
}

