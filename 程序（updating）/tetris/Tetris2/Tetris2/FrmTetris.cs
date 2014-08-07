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
        private Keys MoveLeftKey;   //左移键
        private Keys MoveRightKey;  //右移键
        private Keys DropKey;       //丢下键
        private Keys RotateKey;     //旋转变形键
        private int paletteWidth;   //画板宽度
        private int paletteHeight;  //画板高度
        private int rectPix;        //格子像素
        private Color paletteColor; //画板背景色

        private void FrmTetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (p!=null)    //只有游戏开始了才执行下列操作
            {
                if (e.KeyCode == MoveLeftKey)
                {
                    //执行使砖块左移一格的函数
                    p.Move(-1, 0);
                }
                else if (e.KeyCode == MoveRightKey)
                {
                    //执行使砖块右移一格的函数
                    p.Move(1, 0);
                }
                else if (e.KeyCode == DropKey)
                {
                    //执行使砖块丢下的函数
                    //p.Move(0, 1);
                    while (p.Move(0, 1));
                }
                else if (e.KeyCode == RotateKey)
                {
                    //执行使砖块旋转变形的函数
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
            //定制窗体样式
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
            if (p != null)  //当p不为空时，就把它关闭，以防连续多次点击开始按钮
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
            if (Pause_toolStrip.Text == "继续(&P)")
            {
                Pause_toolStrip.Text = "暂停(&P)";
            }
        }

        private void Pause_toolStrip_Click(object sender, EventArgs e)
        {
            if (Pause_toolStrip.Text == "暂停(&P)")
            {
                p.Pause();
                Pause_toolStrip.Text = "继续(&P)";
            }
            else
            {
                p.EndPause();
                Pause_toolStrip.Text = "暂停(&P)";
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
                //更新窗体样式
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