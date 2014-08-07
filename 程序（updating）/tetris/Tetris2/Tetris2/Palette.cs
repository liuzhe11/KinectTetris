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
        private int _width = 15;    //�����ȣ�ˮƽ������
        private int _height = 20;   //����߶ȣ���ֱ������
        private Graphics gpRun;
        private Graphics gpReady;
        private Graphics gpScore;
        private int rectPix;    //��������
        private Color disapperColor;    //����ɫ
        private Block runBlock; //���ڻ��ש��
        private Block readyBlock;   //��һ��׼����ש��
        private Color[,] FixedBlocks;    //�̶�ש����
        private BlockGroup bGroup;
        private bool IsEnd; //��־��Ϸ�Ƿ����
        private int _score = 0;  //��Ϸ�ܷ�
        private int nLevel = 1;  //��������10��

        public int Score
        {
            get
            {
                return _score;
            }
        }

        private System.Timers.Timer timerBlock; //��ʱ��
        private int timeSpan = 500; //��ʱ����ʱ����

        public Palette(Graphics run,Graphics ready,Graphics ss,int x,int y,int pix,Color dcolor)    //���캯��
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

        //��Ϸ��ʼ��
        public void Start()
        {
            //ש������������ש��
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
           
            //׼����һ��ש��
            Thread.Sleep(20);
            readyBlock = bGroup.GetABlock();
            readyBlock.XPos = 2;
            readyBlock.YPos = 2;
            gpReady.Clear(disapperColor);
            readyBlock.PaintBlockOn(gpReady);
            //��ʼ����ʹ�ö�ʱ��
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

        //ש���ƶ��Ķ���
        public bool Move(int x,int y)
        {
            int xPos = runBlock.XPos + x;
            int yPos = runBlock.YPos + y;
            //���ש���Ƿ񳬳��߽�

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

        //����ת�����Σ�����ש����ת90��
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

        //�ػ�����
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

        //�ػ���Ϸ����
        public void PaintPalette(Graphics gp)
        {
            PaintBackground(gp);
            if (runBlock != null)
            {
                runBlock.PaintBlockOn(gp);
            }
        }
        //�ػ���һ������
        public void PaintReady(Graphics gp)
        {
            if (readyBlock != null)
            {
                readyBlock.PaintBlockOn(gp);
            }
        }
        //����Ƿ񵽵�
        public void CheckAndOverBlock()
        {
            bool over = false;  //���ڱ�־�ש���Ƿ񵽵�
            //ȷ��ש���Ƿ��Ѿ�����
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
            //������������FixedBlocks
            if (over)
            {
                for (int i = 0; i < runBlock.Length; i++)
                {
                    FixedBlocks[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y] = runBlock.BlockColor;
                }
                //����Ƿ�����,����ɾ������
                int lowRow = runBlock.YPos - min.Y;
                int highRow = runBlock.YPos - min.Height;
                bool repaint = false;
                int FullRows = 0;   //���е�����
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
                        FullRows++; //���е�����
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
                //�������
                if (FullRows > 0)
                {
                    _score += 50 * (FullRows * FullRows + 1);
                }
                DrawScore(gpScore);//���»���
                if (_score >= 10000 * nLevel)
                {
                    nLevel++;//������1
                    timeSpan -= 80; //�ٶȼ�80
                    StringFormat drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;
                    gpRun.DrawString("�� "+nLevel.ToString()+" ��",
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
                //�����µ�ש�鼰׼��ש��
                runBlock = readyBlock;
                runBlock.XPos = _width / 2;
                int y = 0;  //ȷ��ש��Ypos��ȷ���ճ�����ש�鶥��û�п���
                for (int i = 0; i < runBlock.Length; i++)
                {
                    if (runBlock[i].Y > y)
                    {
                        y = runBlock[i].Y;
                    }
                }
                runBlock.YPos = y;
                //����²�����ש����ռ�õĵط��Ƿ�������ש�飬��������ν���
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
                        Close();//��Ϸ�����رն�ʱ���Լ�����
                        return;
                    }
                }
                runBlock.Eraser(gpRun);
                runBlock.PaintBlockOn(gpRun);

                //�����µ�׼��ש��
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
            gp.DrawString("����",
                new Font("Arial Black", 10f, FontStyle.Bold),
                new SolidBrush(Color.White),
                new Rectangle(0,0,100,25),
                drawScore);
            
            gp.DrawString(_score.ToString(),
                new Font("Arial Black", 10f),
                new SolidBrush(Color.Chocolate),
                new Rectangle(0, 25, 100, 25),
                drawScore);
            gp.DrawString("��",
                new Font("Arial Black", 10f, FontStyle.Bold),
                new SolidBrush(Color.White),
                new Rectangle(20, 50, 20, 25),
                drawScore);
            gp.DrawString(nLevel.ToString(),
                new Font("Arial Black", 15f,FontStyle.Underline),
                new SolidBrush(Color.SlateBlue),
                new Rectangle(40, 50, 20, 25),
                drawScore);
            gp.DrawString("��",
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
