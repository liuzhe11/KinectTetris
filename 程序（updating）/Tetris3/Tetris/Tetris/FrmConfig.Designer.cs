namespace Tetris
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbEnvironmentSet = new System.Windows.Forms.GroupBox();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.txtRectPix = new System.Windows.Forms.TextBox();
            this.txtCoorHeight = new System.Windows.Forms.TextBox();
            this.txtCoorWidth = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbKeySet = new System.Windows.Forms.GroupBox();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.txtDown = new System.Windows.Forms.TextBox();
            this.txtDrop = new System.Windows.Forms.TextBox();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.txtDeasil = new System.Windows.Forms.TextBox();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lsvBlockSet = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbEnvironmentSet.SuspendLayout();
            this.gbKeySet.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(489, 407);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbEnvironmentSet);
            this.tabPage1.Controls.Add(this.gbKeySet);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(481, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "参数配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbEnvironmentSet
            // 
            this.gbEnvironmentSet.Controls.Add(this.lblBackColor);
            this.gbEnvironmentSet.Controls.Add(this.txtRectPix);
            this.gbEnvironmentSet.Controls.Add(this.txtCoorHeight);
            this.gbEnvironmentSet.Controls.Add(this.txtCoorWidth);
            this.gbEnvironmentSet.Controls.Add(this.label12);
            this.gbEnvironmentSet.Controls.Add(this.label11);
            this.gbEnvironmentSet.Controls.Add(this.label10);
            this.gbEnvironmentSet.Controls.Add(this.label8);
            this.gbEnvironmentSet.Location = new System.Drawing.Point(250, 6);
            this.gbEnvironmentSet.Name = "gbEnvironmentSet";
            this.gbEnvironmentSet.Size = new System.Drawing.Size(200, 373);
            this.gbEnvironmentSet.TabIndex = 1;
            this.gbEnvironmentSet.TabStop = false;
            this.gbEnvironmentSet.Text = "环境设置";
            // 
            // lblBackColor
            // 
            this.lblBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBackColor.Location = new System.Drawing.Point(81, 146);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(100, 28);
            this.lblBackColor.TabIndex = 8;
            this.lblBackColor.Click += new System.EventHandler(this.lblBackColor_Click);
            // 
            // txtRectPix
            // 
            this.txtRectPix.Location = new System.Drawing.Point(81, 108);
            this.txtRectPix.Name = "txtRectPix";
            this.txtRectPix.Size = new System.Drawing.Size(100, 21);
            this.txtRectPix.TabIndex = 7;
            // 
            // txtCoorHeight
            // 
            this.txtCoorHeight.Location = new System.Drawing.Point(81, 64);
            this.txtCoorHeight.Name = "txtCoorHeight";
            this.txtCoorHeight.Size = new System.Drawing.Size(100, 21);
            this.txtCoorHeight.TabIndex = 6;
            // 
            // txtCoorWidth
            // 
            this.txtCoorWidth.Location = new System.Drawing.Point(81, 20);
            this.txtCoorWidth.Name = "txtCoorWidth";
            this.txtCoorWidth.Size = new System.Drawing.Size(100, 21);
            this.txtCoorWidth.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "垂直格子数";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "格子像数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "背景颜色";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "水平格子数";
            // 
            // gbKeySet
            // 
            this.gbKeySet.Controls.Add(this.txtRight);
            this.gbKeySet.Controls.Add(this.txtDown);
            this.gbKeySet.Controls.Add(this.txtDrop);
            this.gbKeySet.Controls.Add(this.txtContra);
            this.gbKeySet.Controls.Add(this.txtDeasil);
            this.gbKeySet.Controls.Add(this.txtLeft);
            this.gbKeySet.Controls.Add(this.label7);
            this.gbKeySet.Controls.Add(this.label6);
            this.gbKeySet.Controls.Add(this.label5);
            this.gbKeySet.Controls.Add(this.label4);
            this.gbKeySet.Controls.Add(this.label3);
            this.gbKeySet.Controls.Add(this.label1);
            this.gbKeySet.Location = new System.Drawing.Point(8, 6);
            this.gbKeySet.Name = "gbKeySet";
            this.gbKeySet.Size = new System.Drawing.Size(200, 373);
            this.gbKeySet.TabIndex = 0;
            this.gbKeySet.TabStop = false;
            this.gbKeySet.Text = "键盘设置";
            // 
            // txtRight
            // 
            this.txtRight.Location = new System.Drawing.Point(80, 67);
            this.txtRight.Name = "txtRight";
            this.txtRight.ReadOnly = true;
            this.txtRight.Size = new System.Drawing.Size(100, 21);
            this.txtRight.TabIndex = 11;
            this.txtRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContra_KeyDown);
            // 
            // txtDown
            // 
            this.txtDown.Location = new System.Drawing.Point(80, 105);
            this.txtDown.Name = "txtDown";
            this.txtDown.ReadOnly = true;
            this.txtDown.Size = new System.Drawing.Size(100, 21);
            this.txtDown.TabIndex = 10;
            this.txtDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContra_KeyDown);
            // 
            // txtDrop
            // 
            this.txtDrop.Location = new System.Drawing.Point(80, 143);
            this.txtDrop.Name = "txtDrop";
            this.txtDrop.ReadOnly = true;
            this.txtDrop.Size = new System.Drawing.Size(100, 21);
            this.txtDrop.TabIndex = 9;
            this.txtDrop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContra_KeyDown);
            // 
            // txtContra
            // 
            this.txtContra.Location = new System.Drawing.Point(80, 219);
            this.txtContra.Name = "txtContra";
            this.txtContra.ReadOnly = true;
            this.txtContra.Size = new System.Drawing.Size(100, 21);
            this.txtContra.TabIndex = 8;
            this.txtContra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContra_KeyDown);
            // 
            // txtDeasil
            // 
            this.txtDeasil.Location = new System.Drawing.Point(80, 181);
            this.txtDeasil.Name = "txtDeasil";
            this.txtDeasil.ReadOnly = true;
            this.txtDeasil.Size = new System.Drawing.Size(100, 21);
            this.txtDeasil.TabIndex = 7;
            this.txtDeasil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContra_KeyDown);
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(80, 29);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.ReadOnly = true;
            this.txtLeft.Size = new System.Drawing.Size(100, 21);
            this.txtLeft.TabIndex = 6;
            this.txtLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContra_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "逆时针旋转";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "丢下";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "顺时针旋转";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "向下";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "向右";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "向左";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnUpdate);
            this.tabPage2.Controls.Add(this.btnClear);
            this.tabPage2.Controls.Add(this.btnDel);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.lsvBlockSet);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.lblColor);
            this.tabPage2.Controls.Add(this.lblMode);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(481, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "砖块样式配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(14, 276);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(70, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(89, 276);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(90, 237);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(14, 237);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lsvBlockSet
            // 
            this.lsvBlockSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvBlockSet.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvBlockSet.FullRowSelect = true;
            this.lsvBlockSet.GridLines = true;
            this.lsvBlockSet.Location = new System.Drawing.Point(171, 7);
            this.lsvBlockSet.MultiSelect = false;
            this.lsvBlockSet.Name = "lsvBlockSet";
            this.lsvBlockSet.Size = new System.Drawing.Size(302, 350);
            this.lsvBlockSet.TabIndex = 3;
            this.lsvBlockSet.UseCompatibleStateImageBehavior = false;
            this.lsvBlockSet.View = System.Windows.Forms.View.Details;
            this.lsvBlockSet.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lsvBlockSet_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "字符编码";
            this.columnHeader1.Width = 197;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "颜色编码";
            this.columnHeader2.Width = 239;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(11, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "颜  色";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblColor
            // 
            this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblColor.Location = new System.Drawing.Point(79, 187);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(86, 27);
            this.lblColor.TabIndex = 1;
            this.lblColor.Click += new System.EventHandler(this.lblColor_Click);
            // 
            // lblMode
            // 
            this.lblMode.BackColor = System.Drawing.Color.Black;
            this.lblMode.Location = new System.Drawing.Point(9, 7);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(156, 156);
            this.lblMode.TabIndex = 0;
            this.lblMode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblMode_MouseClick);
            this.lblMode.Paint += new System.Windows.Forms.PaintEventHandler(this.lblMode_Paint);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(131, 414);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(254, 414);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // btnRevert
            // 
            this.btnRevert.Location = new System.Drawing.Point(388, 413);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(75, 23);
            this.btnRevert.TabIndex = 3;
            this.btnRevert.Text = "还原";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 441);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmConfig";
            this.Text = "配置窗体";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbEnvironmentSet.ResumeLayout(false);
            this.gbEnvironmentSet.PerformLayout();
            this.gbKeySet.ResumeLayout(false);
            this.gbKeySet.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtRight;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCoorHeight;

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ListView lsvBlockSet;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox gbEnvironmentSet;
        private System.Windows.Forms.GroupBox gbKeySet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDown;
        private System.Windows.Forms.TextBox txtDrop;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.TextBox txtDeasil;
        private System.Windows.Forms.TextBox txtRectPix;
        private System.Windows.Forms.TextBox txtCoorWidth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBackColor;
        private System.Windows.Forms.Button btnRevert;
    }
}

