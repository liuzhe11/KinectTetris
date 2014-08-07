using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Timers;

namespace Tetris2
{
    class Palette
    {
        private int _width = 15;    //画板宽度，水平格子数
        private int _height = 20;   //画板高度，垂直格子数
        private Graphics gpRun;
        private Graphics gpReady;
        private Graphics gpScore;
        private int rectPix;    //格子像素
        private Color disapperColor;    //擦除色
        private Block runBlock; //正在活动的砖块
        private Block readyBlock;   //下一个准备的砖块
        private Color[,] FixedBlocks;    //固定砖块组
        private BlockGroup bGroup;
        private bool IsEnd; //标志游戏是否结束
        private int _score = 0;  //游戏总分
        private int nLevel = 1;  //关数，共10关

        public int Score
        {
            get
            {
                return _score;
            }
        }

        private System.Timers.Timer timerBlock; //定时器
        private int timeSpan = 500; //定时器的时间间隔

        public Palette(Graphics run,Graphics ready,Graphics ss,int x,int y,int pix,Color dcolor)    //构造函数
        {
            gpRun = run;
            gpReady = ready;
            gpScore = ss;
            _width = x;
            _height = y;
            rectPix = pix;
            disapperColor = dcolor;
            FixedBlocks = new Color[_width, _height];
            bGroup = new BlockGroup();
        }

        //游戏开始，
        public void Start()
        {
            //砖块生产机生产砖块
            runBlock = bGroup.GetABlock();
            runBlock.XPos = _width / 2;
            int y = 0;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (runBlock[i].Y > y)
                {
                    y = runBlock[i].Y;
                }
            }
            runBlock.YPos = y;
            gpRun.Clear(disapperColor);
            runBlock.PaintBlockOn(gpRun);  
           
            //准备下一下砖块
            Thread.Sleep(20);
            readyBlock = bGroup.GetABlock();
            readyBlock.XPos = 2;
            readyBlock.YPos = 2;
            gpReady.Clear(disapperColor);
            readyBlock.PaintBlockOn(gpReady);
            //初始化并使用定时器
            timerBlock = new System.Timers.Timer(timeSpan);
            timerBlock.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timerBlock.AutoReset = true;
            timerBlock.Start();

            IsEnd = false;
            DrawScore(gpScore);
        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            CheckAndOverBlock();
            Move(0, 1);
        }

        //砖块移动的动作
        public bool Move(int x,int y)
        {
            int xPos = runBlock.XPos + x;
            int yPos = runBlock.YPos + y;
            //检果砖块是否超出边界

            Rectangle min = runBlock.MinRect();
            int x1 = min.X;
            int y1 = min.Y;
            int x2 = min.Width;
            int y2 = min.Height;
            if (yPos - y2 > _height - 1 || xPos + x1 < 0 || xPos + x2 > _width - 1)
                return false;
            for (int i = 0; i < runBlock.Length;i++ )
            {
                if (!FixedBlocks[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)
                {
                    return false;
                }
            }
            runBlock.Eraser(gpRun);
            runBlock.XPos += x;
            runBlock.YPos += y;
            runBlock.PaintBlockOn(gpRun);
            return true;
        }

        //按旋转（变形）键，砖块旋转90度
        public void RotateBlock()
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos + runBlock[i].Y;
                int y = runBlock.YPos + runBlock[i].X;
                if (x < 0 || x > _width - 1)
                    return;
                if (y < 0 || y > _height - 1)
                    return;
                if (!FixedBlocks[x, y].IsEmpty)
                    return;
            }
            runBlock.Eraser(gpRun);
            runBlock.Rotate();
            runBlock.PaintBlockOn(gpRun);
        }

        //重画背景
        public void PaintBackground(Graphics gp)
        {
            gp.Clear(disapperColor);
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    if (!FixedBlocks[i, j].IsEmpty)
                    {
                        SolidBrush sb = new SolidBrush(FixedBlocks[i, j]);
                        gp.FillRectangle(sb, i * rectPix + 1, j * rectPix + 1, rectPix-2, rectPix-2);
                    }
                }
            }
            if (IsEnd)
            {
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                gp.DrawString("GAME OVER",
                    new Font("Arial Black", 25f),
                    new SolidBrush(Color.White),
                    new RectangleF(0, _height * rectPix / 2 - 100, _width * rectPix, 100),
                    drawFormat);
            }
        }

        //重画游戏界面
        public void PaintPalette(Graphics gp)
        {
            PaintBackground(gp);
            if (runBlock != null)
            {
                runBlock.PaintBlockOn(gp);
            }
        }
        //重画下一个画板
        public void PaintReady(Graphics gp)
        {
            if (readyBlock != null)
            {
                readyBlock.PaintBlockOn(gp);
            }
        }
        //检查是否到底
        public void CheckAndOverBlock()
        {
            bool over = false;  //用于标志活动砖块是否到底
            //确定砖块是否已经到底
            Rectangle min = runBlock.MinRect();
            if (runBlock.YPos - min.Height == _height - 1)
            {
                over = true;
            }
            else
            {
                for (int i = 0; i < runBlock.Length; i++)
                {
                    int x = runBlock.XPos + runBlock[i].X;
                    int y = runBlock.YPos - runBlock[i].Y;
                    if (!FixedBlocks[x, y + 1].IsEmpty)
                    {
                        over = true;
                        break;
                    }
                }
            }
            //如果到底则归入FixedBlocks
            if (over)
            {
                for (int i = 0; i < runBlock.Length; i++)
                {
                    FixedBlocks[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y] = runBlock.BlockColor;
                }
                //检查是否满行,有则删除满行
                int lowRow = runBlock.YPos - min.Y;
                int highRow = runBlock.YPos - min.Height;
                bool repaint = false;
                int FullRows = 0;   //满行的数量
                for (int i = lowRow; i <= highRow; i++)
                {
                    bool IsFull = true;
                    for (int j = 0; j < _width; j++)
                    {
                        if (FixedBlocks[j, i].IsEmpty)
                        {
                            IsFull = false;
                            break;
                        }
                    }
                    if (IsFull)
                    {
                        FullRows++; //满行的数量
                        repaint = true;
                        for (int k = i; k >= 0; k--)
                        {
                            for (int j = 0; j < _width; j++)
                            {
                                if (k == 0)
                                {
                                    FixedBlocks[j, k] = Color.Empty;
                                }
                                else
                                {
                                    FixedBlocks[j, k] = FixedBlocks[j, k - 1];
                                }
                            }
                        }
                    }
                }
                //计算积分
                if (FullRows > 0)
                {
                    _score += 50 * (FullRows * FullRows + 1);
                }
                DrawScore(gpScore);//更新积分
                if (_score >= 10000 * nLevel)
                {
                    nLevel++;//关数加1
                    timeSpan -= 80; //速度减80
                    StringFormat drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;
                    gpRun.DrawString("第 "+nLevel.ToString()+" 关",
                        new Font("Arial Black", 25f,FontStyle.Bold),
                        new SolidBrush(Color.White),
                        new RectangleF(0, _height * rectPix / 2 - 100, _width * rectPix, 100),
                        drawFormat);
                    drawFormat.Dispose();
                    timerBlock.Enabled = false;
                    Thread.Sleep(2000);
                    timerBlock.Enabled = true;
                }
                PaintBackground(gpRun);
                //产生新的砖块及准备砖块
                runBlock = readyBlock;
                runBlock.XPos = _width / 2;
                int y = 0;  //确定砖的Ypos，确保刚出生的砖块顶上没有空行
                for (int i = 0; i < runBlock.Length; i++)
                {
                    if (runBlock[i].Y > y)
                    {
                        y = runBlock[i].Y;
                    }
                }
                runBlock.YPos = y;
                //检查新产生的砖块所占用的地方是否有其他砖块，如果有则游结束
                for (int i = 0; i < runBlock.Length; i++)
                {
                    if (!FixedBlocks[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y].IsEmpty)
                    {
                        IsEnd = true;
                        StringFormat drawFormat = new StringFormat();
                        drawFormat.Alignment = StringAlignment.Center;
                        gpRun.DrawString("GAME OVER",
                            new Font("Arial Black", 25f),
                            new SolidBrush(Color.White),
                            new RectangleF(0, _height * rectPix / 2 - 100, _width * rectPix, 100),
                            drawFormat);
                        drawFormat.Dispose();
                        Close();//游戏结束关闭定时器以及画板
                        return;
                    }
                }
                runBlock.Eraser(gpRun);
                runBlock.PaintBlockOn(gpRun);

                //产生新的准备砖块
                readyBlock = bGroup.GetABlock();
                gpReady.Clear(disapperColor);
                readyBlock.XPos = 2;
                readyBlock.YPos = 2;
                readyBlock.PaintBlockOn(gpReady);
            }
        }

        public void Close()
        {
            timerBlock.Close();
            gpRun.Dispose();
            gpReady.Dispose();
            gpScore.Dispose();
        }

        public void Pause()
        {
            if (timerBlock.Enabled == true)
            {
                timerBlock.Enabled = false;
            }
        }

        public void EndPause()
        {
            if (timerBlock.Enabled == false)
            {
                timerBlock.Enabled = true;
            }
        }

        public void DrawScore(Graphics gp)
        {
            gp.Clear(Color.Black);
            SolidBrush sb = new SolidBrush(Color.White);
            gp.FillRectangle(sb, 0, 25, 100, 25);
            gp.FillRectangle(sb, 0, 75, 100, 25);
            StringFormat drawScore = new StringFormat();
            drawScore.Alignment = StringAlignment.Center;
            gp.DrawString("积分",
                new Font("Arial Black", 10f, FontStyle.Bold),
                new SolidBrush(Color.White),
                new Rectangle(0,0,100,25),
                drawScore);
            
            gp.DrawString(_score.ToString(),
                new Font("Arial Black", 10f),
                new SolidBrush(Color.Chocolate),
                new Rectangle(0, 25, 100, 25),
                drawScore);
            gp.DrawString("第",
                new Font("Arial Black", 10f, FontStyle.Bold),
                new SolidBrush(Color.White),
                new Rectangle(20, 50, 20, 25),
                drawScore);
            gp.DrawString(nLevel.ToString(),
                new Font("Arial Black", 15f,FontStyle.Underline),
                new SolidBrush(Color.SlateBlue),
                new Rectangle(40, 50, 20, 25),
                drawScore);
            gp.DrawString("关",
                new Font("Arial Black", 10f, FontStyle.Bold),
                new SolidBrush(Color.White),
                new Rectangle(60, 50, 20, 25),
                drawScore);
            int goal = 10000 * nLevel;
            gp.DrawString(goal.ToString(),
                new Font("Arial Black", 10f),
                new SolidBrush(Color.Violet),
                new Rectangle(0, 75, 100, 25),
                drawScore);
            drawScore.Dispose();
        }
    }
}
