using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace Tetris
{
	public partial class FrmTetris : Form
	{
		public FrmTetris()
		{
			InitializeComponent();
		}

		private Palette p;
		private Keys downKey;
		private Keys dropKey;
		private Keys moveLeftKey;
		private Keys moveRightKey;
		private Keys deasilRotateKey;
		private Keys contraRotateKey;
		private int paletteWidth;
		private int paletteHeight;
		private Color paletteColor;
		private int rectPix;

		

		private void btnStar_Click(object sender, EventArgs e)
		{
			if (p != null)
			{
				p.Close();
			}
			p = new Palette(paletteWidth, paletteHeight, rectPix, paletteColor,
			                Graphics.FromHwnd(pbRun.Handle),
			                Graphics.FromHwnd(lblReady.Handle));
			
			lblFenShu.Text = "0";
			lblDengJi.Text = "0";
			//下面这一句为新添加的代码：
			p.ScoreInc += new ScoreIncEventHandler(palette_ScoreInc);//订阅分数增加事件,其中palette_ScoreInc为第六步中所新增加的方法名称
			p.Start();

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

		private void FrmTetris_Load(object sender, EventArgs e)
		{
			Config config = new Config();
			config.LoadFromXmlFile();
			downKey = config.DownKey;
			dropKey = config.DropKey;
			moveLeftKey = config.MoveLeftKey;
			moveRightKey = config.MoveRightKey;
			deasilRotateKey = config.DeasilRotateKey;
			contraRotateKey = config.ContraRotateKey;
			paletteWidth = config.CoorWidth;
			paletteHeight = config.CoorHeight;
			paletteColor = config.BackColor;
            rectPix = config.RectPix;
            //this.Width = paletteWidth * rectPix + 134;
            //this.Height = paletteHeight * rectPix + 58;
            //pbRun.Width = paletteWidth * rectPix;
            //pbRun.Height = paletteHeight * rectPix;
        }

		private void FrmTetris_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 32)
			{
				e.Handled = true;
			}
			if (e.KeyCode == downKey)
			{
				p.Down();
			}
			else if (e.KeyCode == dropKey)
			{
				p.Drop();
			}
			else if (e.KeyCode == moveLeftKey)
			{
				p.MoveLeft();
			}
			else if (e.KeyCode == moveRightKey)
			{
				p.MoveRight();
			}
			else if (e.KeyCode == deasilRotateKey)
			{
				p.DeasilRotate();
			}
			else if (e.KeyCode == contraRotateKey)
			{
				p.ContraRotate();
			}
		}

		private void btnPause_Click(object sender, EventArgs e)
		{
			if (p == null)
			{
				return;
			}
			if (btnPause.Text == "暂停")
			{
				p.Pause();
				btnPause.Text = "继续";
			}
			else
			{
				p.EndPause();
				btnPause.Text = "暂停";
			}
		}

		private void btnConfig_Click(object sender, EventArgs e)
		{
			if (btnPause.Text == "暂停")
			{
				btnPause.PerformClick();
			}
			using (FrmConfig frmConfig = new FrmConfig())
			{
				frmConfig.ShowDialog();
			}
		}

		private void FrmTetris_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (p != null)
			{
				p.Close();
			}
		}

		private void palette_ScoreInc(object sender, ScoreEventArgs e) //分数增加事件处理代码
		{
			lblFenShu.Text = e.Score.ToString(); //label2为显示分数的控件，可以为其它控件，需在主界面添加
			int dj = e.Score / 100;
			if (dj == 5)
			{
				p.Pause();
				MessageBox.Show("恭喜！！你已经进入最高等级——五级，继续加油");
				p.EndPause();
			}
			
			if(dj >= 8)
			{
				MessageBox.Show("恭喜！你已经成功通过最高等级！！你可以学C#语言了");
				this.Close();
			}
			lblDengJi.Text = dj.ToString();
		}
	}
}
