using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;



namespace Tetris
{
    public delegate void ScoreIncEventHandler(object sender, ScoreEventArgs e);


    class ScoreEventArgs : System.EventArgs //分数增加事件使用参数的封装类
    {
        private int _score = 0;
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }
    }

    class Palette
    {
        private int _width = 15;
        private int _height = 25;
        private Color[,] coorArr;
        private Color disapperColor;
        private Graphics gpPalette;
        private Graphics gpReady;
        private BlockGroup bGroup;
        private Block runBlock;
        private Block readyBlock;
        private int rectPix;

        private ScoreEventArgs sea = new ScoreEventArgs();//初始化分数增加事件参数
        public event ScoreIncEventHandler ScoreInc; //声明分数增加事件

        private void OnScoreInc()
        {
            ScoreIncEventHandler handler = ScoreInc;
            if (handler != null)
            {
                if (handler.Target is System.ComponentModel.ISynchronizeInvoke)
                {
                    System.ComponentModel.ISynchronizeInvoke aSynch = handler.Target as System.ComponentModel.ISynchronizeInvoke;
                    if (aSynch.InvokeRequired)
                    {
                        object[] args = new object[] { this, sea }; //包装参数
                        aSynch.Invoke(handler, args); //调用事件
                    }
                    else
                    {
                        handler(this, sea);
                    }
                }
                else
                {
                    handler(this, sea);
                }
            }
        }


        private System.Timers.Timer timerBlock;
        private int timeSpan = 800;

        public Palette(int x,int y,int pix,Color dColor,Graphics gp,Graphics gr)
        {
            _width = x;
            _height = y;
            coorArr = new Color[_width, _height];
            disapperColor = dColor;
            gpPalette = gp;
            gpReady = gr;
            rectPix = pix;
        }
        public void Start()
        {
            bGroup = new BlockGroup();
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
            gpPalette.Clear(disapperColor);
            runBlock.Paint(gpPalette);

            Thread.Sleep(20);
            readyBlock = bGroup.GetABlock();
            readyBlock.XPos = 2;
            readyBlock.YPos = 2;
            gpReady.Clear(disapperColor);
            readyBlock.Paint(gpReady);

            timeeblock();
        }

        private void timeeblock()
        {
        	timeSpan = 800 - sea.Score / 100 * 100;
        	timerBlock = new System.Timers.Timer(timeSpan);
            timerBlock.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            timerBlock.AutoReset = true;
            timerBlock.Start();
        }
        
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            CheckAndOverBlock();
            Down();
        }

        public bool Down()
        {
            int xPos = runBlock.XPos;
            int yPos = runBlock.YPos + 1;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (yPos - runBlock[i].Y > _height - 1)
                    return false;
                if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)
                    return false;
            }

            runBlock.erase(gpPalette);
            runBlock.YPos++;
            runBlock.Paint(gpPalette);
            return true;
        }

        public void Drop()
        {
            timerBlock.Stop();
            while (Down()) ;
            timerBlock.Start();
        }

        public void MoveLeft()
        {
            int xPos = runBlock.XPos - 1;
            int yPos = runBlock.YPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (xPos + runBlock[i].X < 0)
                    return;
                if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)
                    return;
            }
            runBlock.erase(gpPalette);
            runBlock.XPos--;
            runBlock.Paint(gpPalette);
        }

        public void MoveRight()
        {
            int xPos = runBlock.XPos + 1;
            int yPos = runBlock.YPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (xPos + runBlock[i].X > _width - 1)
                    return;
                if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)
                    return;
            }
            runBlock.erase(gpPalette);
            runBlock.XPos++;
            runBlock.Paint(gpPalette);
        }

        public void DeasilRotate()
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos + runBlock[i].Y;
                int y = runBlock.YPos + runBlock[i].X;
                if (x < 0 || x > _width - 1)
                    return;
                if (y < 0 || y > _height - 1)
                    return;
                if (!coorArr[x, y].IsEmpty)
                    return;
            }
            runBlock.erase(gpPalette);
            runBlock.DeasilRotate();
            runBlock.Paint(gpPalette);
        }

        public void ContraRotate()
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos - runBlock[i].Y;
                int y = runBlock.YPos - runBlock[i].X;
                if (x < 0 || x > _width - 1)
                    return;
                if (y < 0 || y > _height - 1)
                    return;
                if (!coorArr[x, y].IsEmpty)
                    return;
            }
            runBlock.erase(gpPalette);
            runBlock.ContraRotate();
            runBlock.Paint(gpPalette);
        }

        private void PaintBackground(Graphics gp)
        {
            gp.Clear(Color.Black);
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (!coorArr[j, i].IsEmpty)
                    {
                        SolidBrush sb = new SolidBrush(coorArr[j, i]);
                        gp.FillRectangle(sb, j * rectPix + 1,
                            i * rectPix + 1,
                            rectPix - 2,
                            rectPix - 2);
                    }
                }
            }
        }

        public void PaintPalette(Graphics gp)
        {
            PaintBackground(gp);

            if (runBlock != null)
            {
                runBlock.Paint(gp);
            }
        }

        public void PaintReady(Graphics gp)
        {
            if (readyBlock != null)
            {
                readyBlock.Paint(gp);
            }
        }

        public void CheckAndOverBlock()
        {
            bool over = false;
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos + runBlock[i].X;
                int y = runBlock.YPos - runBlock[i].Y;
                if (y == _height - 1)
                {
                    over = true;
                    break;
                }
                if (!coorArr[x, y + 1].IsEmpty)
                {
                    over = true;
                    break;
                }
            }
            if (over)
            {
                for (int i = 0; i < runBlock.Length; i++)
                {
                    coorArr[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y] = runBlock.BlockColor;
                }

                CheckAndDelFullRow();

                runBlock = readyBlock;
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
                for (int i = 0; i < runBlock.Length; i++)
                {
                    if (!coorArr[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y].IsEmpty)
                    {
                        StringFormat drawFormat = new StringFormat();
                        drawFormat.Alignment = StringAlignment.Center;
                        gpPalette.DrawString("GAME OVER",
                            new Font("Arial Black", 25f),
                            new SolidBrush(Color.White),
                            new RectangleF(0, _height * rectPix / 2 - 100, _width * rectPix, 100),
                            drawFormat);
                        timerBlock.Stop();
                        return;
                    }
                }
                runBlock.Paint(gpPalette);

                readyBlock = bGroup.GetABlock();
                readyBlock.XPos = 2;
                readyBlock.YPos = 2;
                gpReady.Clear(Color.Black);
                readyBlock.Paint(gpReady);
            }
        }

        private void CheckAndDelFullRow()
        {
            int lowRow = runBlock.YPos - runBlock[0].Y;
            int highRow = lowRow;
            for (int i = 1; i < runBlock.Length; i++)
            {
                int y = runBlock.YPos - runBlock[i].Y;
                if (y < lowRow)
                {
                    lowRow = y;
                }
                if (y > highRow)
                {
                    highRow = y;
                }
            }
            bool repaint = false;
            for (int i = lowRow; i <= highRow; i++)
            {
                bool rowFull = true;
                for (int j = 0; j < _width; j++)
                {
                    if (coorArr[j, i].IsEmpty)
                    {
                        rowFull = false;
                        break;
                    }
                }
                if (rowFull)
                {
                    repaint = true;
                    for (int k = i; k > 0; k--)
                    {
                        for (int j = 0; j < _width; j++)
                        {
                            coorArr[j, k] = coorArr[j, k - 1];
                        }
                       
                    }
                    for (int j = 0; j < _width; j++)
                    {
                        coorArr[j, 0] = Color.Empty;
                    }                    
                    //下面这两句为新添加的触发事件代码
                    sea.Score += 100; //给事件参数类里的Score字段增加100分
                    OnScoreInc(); //触发分数增加事件
					timeeblock();                    
                }

            }
            if (repaint)
            {
                PaintBackground(gpPalette);
            }
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

        public void Close()
        {
            timerBlock.Close();
            gpPalette.Dispose();
            gpReady.Dispose();
        }

    }
}
