using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.IO;

namespace Tetris
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private bool[,] struArr = new bool[5, 5];
        private Color blockColor = Color.Red;
        private Config config = new Config();

        private void lblMode_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            gp.Clear(Color.Black);
            Pen p = new Pen(Color.White);
            for (int i = 30; i < 156; i = i + 31)
                gp.DrawLine(p, 1, i, 155, i);
            for (int i = 30; i < 156; i = i + 31)
                gp.DrawLine(p, i, 1, i, 155);

            SolidBrush s = new SolidBrush(blockColor);
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (struArr[x, y])
                    {
                        gp.FillRectangle(s, 31 * x + 1, 31 * y + 1, 30, 30);
                    }
                }
            }
        }

        private void lblMode_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            int xPos, yPos;
            xPos = e.X / 31;
            yPos = e.Y / 31;
            struArr[xPos, yPos] =! struArr[xPos, yPos];
            bool b = struArr[xPos, yPos];
            Graphics gp = lblMode.CreateGraphics();
            SolidBrush s = new SolidBrush(b ? blockColor : Color.Black);
            gp.FillRectangle(s,31*xPos+1,31*yPos+1,30,30);
            gp.Dispose();
        }

        private void lblColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            blockColor = colorDialog1.Color;
            lblColor.BackColor = colorDialog1.Color;
            lblMode.Invalidate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool isEmpty = false;
            foreach (bool i in struArr)
            {
                if (i)
                {
                    isEmpty = true;
                    break;
                }
            }
            if (!isEmpty)
            {
                MessageBox.Show("图案为空,请先用鼠标点击坐上交窗口,绘制图案", "提示窗口",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            StringBuilder sb = new StringBuilder(25);
            foreach (bool i in struArr)
            {
                sb.Append(i ? "1" : "0");
            }
            string blockString = sb.ToString();

            foreach (ListViewItem item in lsvBlockSet.Items)
            {
                if (item.SubItems[0].Text == blockString)
                {
                    MessageBox.Show("图案已存在,无法添加!", "提示窗口",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    return;
                }
            }

            ListViewItem myItem = new ListViewItem();
            myItem = lsvBlockSet.Items.Add(blockString);
            myItem.SubItems.Add(Convert.ToString(blockColor.ToArgb()));
        }

        private void lsvBlockSet_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                blockColor = Color.FromArgb(int.Parse(e.Item.SubItems[1].Text));
                lblColor.BackColor = blockColor;
                string s = e.Item.SubItems[0].Text;
                for (int i = 0; i < s.Length; i++)
                {
                    struArr[i / 5, i % 5] = (s[i] == '1') ? true : false;
                }
                lblMode.Invalidate();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lsvBlockSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("请在右边窗口中选择一个条目进行删除!", "提示窗口",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                return;
            }
            lsvBlockSet.Items.Remove(lsvBlockSet.SelectedItems[0]);
            btnClear.PerformClick();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 5;i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    struArr[i, j] = false;
                }
            }
            lblMode.Invalidate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lsvBlockSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("请在右边窗口中选择一个条目进行修改!", "提示窗口",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                return;
            }
            bool isEmpty = false;
            foreach (bool i in struArr)
            {
                if (i)
                {
                    isEmpty = true;
                    break;
                }
            }
            if (!isEmpty)
            {
                MessageBox.Show("图案为空,请先用鼠标点击坐上交窗口,绘制图案", "提示窗口",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            StringBuilder sb = new StringBuilder(25);
            foreach (bool i in struArr)
            {
                sb.Append(i ? "1" : "0");
            }
            string blockString = sb.ToString();

            foreach (ListViewItem item in lsvBlockSet.Items)
            {
                if (item.SubItems[0].Text == blockString)
                {
                    MessageBox.Show("图案已存在,修改后无法添加!", "提示窗口",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    return;
                }
            }
            lsvBlockSet.SelectedItems[0].SubItems[0].Text = blockString;
            lsvBlockSet.SelectedItems[0].SubItems[1].Text = Convert.ToString(blockColor.ToArgb());
        }


        private void txtContra_KeyDown(object sender, KeyEventArgs e)
        {
            if (                
                    (e.KeyValue >= 33 && e.KeyValue <= 36) || (e.KeyValue >= 45 && e.KeyValue <= 46) ||
                    (e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 65 && e.KeyValue <= 90) ||
                    (e.KeyValue >= 96 && e.KeyValue <= 107) || (e.KeyValue >= 109 && e.KeyValue <= 111) ||
                    (e.KeyValue >= 186 && e.KeyValue <= 192) || (e.KeyValue >= 219 && e.KeyValue <= 222)
               )
            {
                foreach (Control c in gbKeySet.Controls)
                {
                    Control TempC = c as TextBox;
                    if (TempC != null && ((TextBox)TempC).Text != "")
                    {
                        if (((int)((TextBox)TempC).Tag) == e.KeyValue)
                        {
                            ((TextBox)TempC).Text = "";
                            ((TextBox)TempC).Tag = Keys.None;
                        }
                    }
                }
                ((TextBox)sender).Text =e.KeyCode.ToString();
                ((TextBox)sender).Tag = (Keys)e.KeyValue;
            }
        }

        private void lblBackColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            lblBackColor.BackColor = colorDialog1.Color;
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            config.LoadFromXmlFile();
            InfoArr info = config.Info;

            ListViewItem myItem = new ListViewItem();
            for (int i = 0; i < info.Length; i++)
            {
                myItem = lsvBlockSet.Items.Add(info[i].GetIdStr());
                myItem.SubItems.Add(info[i].GetColorStr());
            }
            
            txtDown.Text=((Keys)config.DownKey).ToString();
            txtDown.Tag=config.DownKey;
            txtDrop.Text=((Keys)config.DropKey).ToString();
            txtDrop.Tag=config.DropKey;
            txtLeft.Text=((Keys)config.MoveLeftKey).ToString();
            txtLeft.Tag=config.MoveLeftKey;
            txtRight.Text=((Keys)config.MoveRightKey).ToString();
            txtRight.Tag=config.MoveRightKey;
            txtDeasil.Text=((Keys)config.DeasilRotateKey).ToString();
            txtDeasil.Tag=config.DeasilRotateKey;
            txtContra.Text=((Keys)config.ContraRotateKey).ToString();
            txtContra.Tag=config.ContraRotateKey;
            
            txtCoorWidth.Text=config.CoorWidth.ToString();
            txtCoorHeight.Text=config.CoorHeight.ToString();
            txtRectPix.Text=config.RectPix.ToString();
            lblBackColor.BackColor=config.BackColor;
        }
        
        void BtnSaveClick(object sender, EventArgs e)
        {
        	InfoArr info=new InfoArr();
        	foreach(ListViewItem item in lsvBlockSet.Items)
        	{
        		info.Add(item.SubItems[0].Text,item.SubItems[1].Text);
        	}
        	config.Info=info;
        	config.DownKey= (Keys)txtDown.Tag;
        	config.DropKey= (Keys)txtDrop.Tag;
        	config.MoveLeftKey= (Keys)txtLeft.Tag;
        	config.MoveRightKey= (Keys)txtRight.Tag;
        	config.DeasilRotateKey= (Keys)txtDeasil.Tag;
        	config.ContraRotateKey= (Keys)txtContra.Tag;
        	config.CoorWidth= int.Parse(txtCoorWidth.Text);
        	config.CoorHeight= int.Parse(txtCoorHeight.Text);
        	config.RectPix= int.Parse(txtRectPix.Text);
        	config.BackColor=lblBackColor.BackColor;
        	config.SaveToXmlFile();
            MessageBox.Show("设置保存成功！", "设置保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        
        void BtnCloseClick(object sender, EventArgs e)
        {
        	this.Close();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            XmlTextReader reader;
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream sm = asm.GetManifestResourceStream("Tetris.BlockSet.xml");
            reader = new XmlTextReader(sm);

            config.revertFromXmlFile(reader);
            InfoArr info = config.Info;

            ListViewItem myItem = new ListViewItem();
            for (int i = 0; i < info.Length; i++)
            {
                myItem = lsvBlockSet.Items.Add(info[i].GetIdStr());
                myItem.SubItems.Add(info[i].GetColorStr());
            }

            txtDown.Text = ((Keys)config.DownKey).ToString();
            txtDown.Tag = config.DownKey;
            txtDrop.Text = ((Keys)config.DropKey).ToString();
            txtDrop.Tag = config.DropKey;
            txtLeft.Text = ((Keys)config.MoveLeftKey).ToString();
            txtLeft.Tag = config.MoveLeftKey;
            txtRight.Text = ((Keys)config.MoveRightKey).ToString();
            txtRight.Tag = config.MoveRightKey;
            txtDeasil.Text = ((Keys)config.DeasilRotateKey).ToString();
            txtDeasil.Tag = config.DeasilRotateKey;
            txtContra.Text = ((Keys)config.ContraRotateKey).ToString();
            txtContra.Tag = config.ContraRotateKey;

            txtCoorWidth.Text = config.CoorWidth.ToString();
            txtCoorHeight.Text = config.CoorHeight.ToString();
            txtRectPix.Text = config.RectPix.ToString();
            lblBackColor.BackColor = config.BackColor;

            BtnSaveClick(sender, e);
        }
    }
}
