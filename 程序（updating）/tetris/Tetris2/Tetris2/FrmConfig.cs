using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris2
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private bool[,] bState = new bool[5, 5];    //bool�͵Ķ�ά���飬Ĭ��ֵ����False�����ڴ洢ÿһ�������״̬
        private Color BlockColor = Color.Red;  //����ש��ı���ɫ
        private Config config = new Config();

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            //tabConfig.SelectedIndex = 1;
            //����������Ϣ
            LoadConfig();
        }

        private void LoadConfig()
        {
            config.LoadFromXmlFile();
            InfoArr myArr = config.BlockArray;
            ListViewItem blockItem = new ListViewItem();
            for (int i = 0; i < myArr.Length; i++)
            {
                blockItem = lsvBlockInfo.Items.Add(myArr[i].GetIdStr());
                blockItem.SubItems.Add(myArr[i].GetColorStr());
            }
            //���ز�������
            txtMoveLeft.Text = config.MoveLeftKey.ToString();
            txtMoveLeft.Tag = config.MoveLeftKey;
            txtMoveRight.Text = config.MoveRightKey.ToString();
            txtMoveRight.Tag = config.MoveRightKey;
            txtDrop.Text = config.DropKey.ToString();
            txtDrop.Tag = config.DropKey;
            txtRotate.Text = config.RotateKey.ToString();
            txtRotate.Tag = config.RotateKey;
            txtHorizonNum.Text = config.HorizonNum.ToString();
            txtVerticalNum.Text = config.VerticalNum.ToString();
            txtRectPix.Text = config.RectPix.ToString();
            lblBackColor.BackColor = config.BackColor;
        }

        private void lblSetBlock_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            Pen p = new Pen(Color.White);
            for (int i = 31; i < 154; i = i + 31)
            {
                gp.DrawLine(p, 0, i, 154, i);
            }
            for (int j = 31; j < 154; j = j + 31)
            {
                gp.DrawLine(p, j, 0, j, 154);
            }
            //�ػ�ש��
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (bState[x, y])
                    {
                        gp.FillRectangle(new SolidBrush(BlockColor),
                            x * 31 + 1, y * 31 + 1,
                            30, 30);
                    }
                }
            }
        }

        private void lblSetBlock_MouseClick(object sender, MouseEventArgs e)
        {
            int xPos = e.X / 31;
            int yPos = e.Y / 31;
            bState[xPos, yPos] = !bState[xPos, yPos];
            Graphics gp = lblSetBlock.CreateGraphics();
            SolidBrush sb = new SolidBrush(bState[xPos, yPos] ? BlockColor : Color.Black);
            gp.FillRectangle(sb, xPos * 31 + 1, yPos * 31 + 1, 30, 30);
        }

        private void lblBlockColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            lblBlockColor.BackColor = colorDialog1.Color;
            BlockColor = lblBlockColor.BackColor;
            lblSetBlock.Invalidate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //���ͼ���Ƿ�Ϊ��
            bool IsEmpty = false;
            foreach (bool b in bState)
            {
                if (b)
                {
                    IsEmpty = true;
                    break;
                }
            }
            if (!IsEmpty)    //���ͼ��Ϊ��
            {
                MessageBox.Show("ͼ��Ϊ�գ������������ߵĴ��ڻ���ͼ����",
                    "��ʾ��Ϣ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            //���ַ�����ʾש����ʽ
            StringBuilder sb = new StringBuilder(25);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sb.Append(bState[i, j] ? "1" : "0");
                }
            }
            string strBlock = sb.ToString();
            //���ͼ���Ƿ����
            foreach (ListViewItem lvi in lsvBlockInfo.Items)
            {
                if (lvi.SubItems[0].Text == strBlock)
                {
                    MessageBox.Show("��ͼ���Ѿ����ڣ������»��ƣ�",
                        "��ʾ��Ϣ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
            }
            //��ͼ����Ϣ��ӵ�ListView��
            ListViewItem blockItem = new ListViewItem();
            blockItem = lsvBlockInfo.Items.Add(strBlock);
            blockItem.SubItems.Add(BlockColor.ToArgb().ToString());
        }

        private void lsvBlockInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //����ߴ�������ʾListView��ѡ�е�ש��ͼ��
            if (lsvBlockInfo.SelectedItems.Count>0)
            {
                //��ȡѡ������ַ�����Ϣ
                string strBlock = lsvBlockInfo.SelectedItems[0].SubItems[0].Text;
                string strColor = lsvBlockInfo.SelectedItems[0].SubItems[1].Text;
                //���ַ�����Ϣ��ԭ��ʵ��Ϣ
                for (int i = 0; i < strBlock.Length; i++)
                {
                    bState[i / 5, i % 5] = (strBlock[i] == '1') ? true : false;
                }
                BlockColor = Color.FromArgb(int.Parse(strColor));
                lblBlockColor.BackColor = BlockColor;
                //���ַ�����ԭΪͼ��
                lblSetBlock.Invalidate();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //�ж��Ƿ�����Ŀ��ѡ��
            if (lsvBlockInfo.SelectedItems.Count == 0)
            {
                MessageBox.Show("��ɾ��֮ǰ��ѡ��һ����Ҫɾ������Ŀ��",
                        "��ʾ��Ϣ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                return;
            }
            //ɾ��ѡ����
            if (DialogResult.OK == MessageBox.Show("ȷ��Ҫɾ����ש����ʽ��",
                        "ѯ��",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question))
            {
                lsvBlockInfo.Items.Remove(lsvBlockInfo.SelectedItems[0]);
                btnClear.PerformClick();
            }
            else
            {
                lsvBlockInfo.Select();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    bState[i, j] = false;
            lblSetBlock.Invalidate();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //�ж��Ƿ�����Ŀ��ѡ��
            if (lsvBlockInfo.SelectedItems.Count == 0)
            {
                MessageBox.Show("�����ұ�ѡ��һ�����޸ĵ���Ŀ��",
                        "��ʾ��Ϣ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                return;
            }
            //���޸ĺ��ͼ��ת�����ַ���
            StringBuilder sb = new StringBuilder(25);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sb.Append(bState[i, j] ? "1" : "0");
                }
            }
            string strBlock = sb.ToString();
            //�ж����޸ĺ��ͼ���Ƿ����
            foreach (ListViewItem lvi in lsvBlockInfo.Items)
            {
                if (lvi != lsvBlockInfo.SelectedItems[0])
                {
                    if (lvi.SubItems[0].Text == strBlock)
                    {
                        MessageBox.Show("��ͼ���Ѿ����ڣ������»��ƣ�",
                            "��ʾ��Ϣ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            //�����޸ĺ��ͼ��
            lsvBlockInfo.SelectedItems[0].SubItems[0].Text = strBlock;
            lsvBlockInfo.SelectedItems[0].SubItems[1].Text = BlockColor.ToArgb().ToString();
            MessageBox.Show("�޸ĳɹ���",
                        "��ʾ��Ϣ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            lsvBlockInfo.Select();
        }

        private void txtRotate_KeyDown(object sender, KeyEventArgs e)
        {
            //����һЩ����Ҫ�İ���
            if ((e.KeyValue >= 33 && e.KeyValue <= 40) ||
                (e.KeyValue >= 45 && e.KeyValue <= 46) ||
                (e.KeyValue >= 48 && e.KeyValue <= 57) ||
                (e.KeyValue >= 65 && e.KeyValue <= 90) ||
                (e.KeyValue >= 96 && e.KeyValue <= 107) ||
                (e.KeyValue >= 109 && e.KeyValue <= 111) ||
                (e.KeyValue >= 186 && e.KeyValue <= 192) ||
                (e.KeyValue >= 219 && e.KeyValue <= 222))
            {
                //�����ظ��İ���
                foreach (Control c in gbKeyBoard.Controls)
                {
                    Control temp = c as TextBox;
                    if (temp != null && ((TextBox)temp).Text != "")
                    {
                        if (((TextBox)temp).Text == e.KeyCode.ToString())
                        {
                            ((TextBox)temp).Text = "";
                        }                        
                    }
                }
                //���ı�������ʾ����
                ((TextBox)sender).Text = e.KeyCode.ToString();
                ((TextBox)sender).Tag = e.KeyCode;
            }
        }

        private void txtHorizonNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }

        }

        private void txtHorizonNum_Leave(object sender, EventArgs e)
        {
            if (int.Parse(txtHorizonNum.Text) < 10 || int.Parse(txtHorizonNum.Text) > 20)
            {
                MessageBox.Show("������ˮƽ��������10��20֮��", "��ʾ��Ϣ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtHorizonNum.SelectAll();
            }
        }

        private void lblBackColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            lblBackColor.BackColor = colorDialog1.Color;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //��������Ϣ������xml�ļ�
            InfoArr myArr = new InfoArr();
            foreach (ListViewItem lvi in lsvBlockInfo.Items)
            {
                myArr.Add(lvi.SubItems[0].Text, lvi.SubItems[1].Text);
            }
            config.BlockArray = myArr;

            config.MoveLeftKey = (Keys)txtMoveLeft.Tag;
            config.MoveRightKey = (Keys)txtMoveRight.Tag;
            config.DropKey = (Keys)txtDrop.Tag;
            config.RotateKey = (Keys)txtRotate.Tag;

            config.HorizonNum = int.Parse(txtHorizonNum.Text);
            config.VerticalNum = int.Parse(txtVerticalNum.Text);
            config.RectPix = int.Parse(txtRectPix.Text);
            config.BackColor = lblBackColor.BackColor;

            config.SaveToXmlFile();
            MessageBox.Show("�����ѱ��棡", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            //��ԭΪϵͳĬ������
            if (DialogResult.OK == MessageBox.Show("ȷ��Ҫ��ԭĬ�����ã�", "ѯ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                config.DefaultConfig();
                LoadConfig();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //�ر����ô���
            this.Close();
        }

    }
}