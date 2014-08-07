using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris2
{
    
    public partial class FrmTetris : Form
    {
        public FrmTetris()
        {
            InitializeComponent();
        }

        private Palette p;
        private Keys MoveLeftKey;   //���Ƽ�
        private Keys MoveRightKey;  //���Ƽ�
        private Keys DropKey;       //���¼�
        private Keys RotateKey;     //��ת���μ�
        private int paletteWidth;   //������
        private int paletteHeight;  //����߶�
        private int rectPix;        //��������
        private Color paletteColor; //���屳��ɫ

        private void FrmTetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (p!=null)    //ֻ����Ϸ��ʼ�˲�ִ�����в���
            {
                if (e.KeyCode == MoveLeftKey)
                {
                    //ִ��ʹש������һ��ĺ���
                    p.Move(-1, 0);
                }
                else if (e.KeyCode == MoveRightKey)
                {
                    //ִ��ʹש������һ��ĺ���
                    p.Move(1, 0);
                }
                else if (e.KeyCode == DropKey)
                {
                    //ִ��ʹש�鶪�µĺ���
                    //p.Move(0, 1);
                    while (p.Move(0, 1));
                }
                else if (e.KeyCode == RotateKey)
                {
                    //ִ��ʹש����ת���εĺ���
                    p.RotateBlock();
                }
            }
        }

        private void FrmTetris_Load(object sender, EventArgs e)
        {
            Config config = new Config();
            config.LoadFromXmlFile();

            MoveLeftKey = config.MoveLeftKey;
            MoveRightKey = config.MoveRightKey;
            DropKey = config.DropKey;
            RotateKey = config.RotateKey;
            paletteWidth = config.HorizonNum;
            paletteHeight = config.VerticalNum;
            paletteColor = config.BackColor;
            rectPix = config.RectPix;

            pbRun.BackColor = paletteColor;
            lblReady.BackColor = paletteColor;
            //���ƴ�����ʽ
            pbRun.Width = paletteWidth * rectPix;
            pbRun.Height = paletteHeight * rectPix;
            lblReady.Width = 5 * rectPix;
            lblReady.Height = 5 * rectPix;
            this.Width = paletteWidth * rectPix + 5 * rectPix + 34;
            this.Height = paletteHeight * rectPix + 80;

        }

        private void pbRun_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.PaintPalette(e.Graphics);
            }
        }

        private void lblReady_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.PaintReady(e.Graphics);
            }
        }

        private void FrmTetris_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (p != null)
            {
                p.Close();
            }
        }

        private void New_toolStrip_Click(object sender, EventArgs e)
        {
            if (p != null)  //��p��Ϊ��ʱ���Ͱ����رգ��Է�������ε����ʼ��ť
            {
                p.Close();
            }
            p = new Palette(pbRun.CreateGraphics(),
                lblReady.CreateGraphics(),
                lblScore.CreateGraphics(),
                paletteWidth,
                paletteHeight,
                rectPix,
                paletteColor);
            p.Start();
            Pause_toolStrip.Enabled = true;
            if (Pause_toolStrip.Text == "����(&P)")
            {
                Pause_toolStrip.Text = "��ͣ(&P)";
            }
        }

        private void Pause_toolStrip_Click(object sender, EventArgs e)
        {
            if (Pause_toolStrip.Text == "��ͣ(&P)")
            {
                p.Pause();
                Pause_toolStrip.Text = "����(&P)";
            }
            else
            {
                p.EndPause();
                Pause_toolStrip.Text = "��ͣ(&P)";
            }
        }

        private void Config_toolStrip_Click(object sender, EventArgs e)
        {
            FrmConfig myconfig = new FrmConfig();
            if (myconfig.ShowDialog() == DialogResult.OK)
            {
                Config config = new Config();
                config.LoadFromXmlFile();

                MoveLeftKey = config.MoveLeftKey;
                MoveRightKey = config.MoveRightKey;
                DropKey = config.DropKey;
                RotateKey = config.RotateKey;
                paletteWidth = config.HorizonNum;
                paletteHeight = config.VerticalNum;
                paletteColor = config.BackColor;
                rectPix = config.RectPix;

                pbRun.BackColor = paletteColor;
                lblReady.BackColor = paletteColor;
                //���´�����ʽ
                pbRun.Width = paletteWidth * rectPix;
                pbRun.Height = paletteHeight * rectPix;
                lblReady.Width = 5 * rectPix;
                lblReady.Height = 5 * rectPix;
                this.Width = paletteWidth * rectPix + 5 * rectPix + 34;
                this.Height = paletteHeight * rectPix + 80;
            }
        }

        private void Exit_toolStrip_Click(object sender, EventArgs e)
        {
            if (p != null)
            {
                p.Close();
            }
            Application.Exit();
        }

        private void About_ToolStrip_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }

        private void lblScore_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.DrawScore(e.Graphics);
            }
        }
    }
}