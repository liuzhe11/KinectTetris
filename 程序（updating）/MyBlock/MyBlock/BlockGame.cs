using System;
using System.Collections;
using System.Drawing;
using System.Threading;
using System.Timers;

namespace MyBlock
{
    class BlockGame
    {
        private int _width = 15; //画板宽度
        private int _height = 25;//画板高度
        private Color[,] coorArr;//固定砖块数组
        private Color disapperColor; //背景颜色
        private Graphics gpPalette; //砖块活动画板
        private Graphics gpReady; //下一个砖块样式画板
        private Block bGroup;//砖块生产机
        private Box runBlock; //正在活动的砖块
        private Box readyBlock;   //下一个砖块
        private int rectPix;//单元格像素
        private System.Timers.Timer timerBlock;
        private int timeSpan = 200;//定时器时间间隔
        private int timeSpan2 ;
        private Graphics _gpScore;
        private Graphics _bpLevel;
        private int score=0;
        private int level=1;

        public BlockGame(int x,int y,int pix,Color dColor,Graphics gp,Graphics gr)
        {
            _width = x;
            _height = y;
            coorArr = new Color[_width, _height];
            disapperColor = dColor;
            gpPalette = gp;
            gpReady = gr;
            rectPix = pix;
        }
        public int TimeSpan
        {
            get { return timeSpan; }
            set { timeSpan = value; }
        }
        public int TimeSpan2
        {
            get { return timeSpan2; }
            set { timeSpan2 = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public Graphics GpScore
        {
            get { return _gpScore; }
            set { _gpScore = value; }
        }
        public Graphics BpLevel
        {
            get { return _bpLevel; }
            set { _bpLevel = value; }
        }
        public void Start() //游戏开始
        {
            ShowScore(_gpScore);
            ShowLevel(_bpLevel);
            bGroup = new Block();//新建砖块生产机
            runBlock = bGroup.GetABlock();//取一个砖块
            runBlock.XPos = _width / 2;//新出砖块的水平位置
            int y = 0; //垂直位置
            for (int i = 0; i < runBlock.Length; i++)//遍历方块,寻找y最大值
            {
                if (runBlock[i].Y > y)
                {
                    y = runBlock[i].Y;
                }
            }
            runBlock.YPos = y;
            gpPalette.Clear(disapperColor);//清空画板
            runBlock.Paint(gpPalette);//画运行砖块
            Thread.Sleep(20);   //两次调用取随机数,间隔时间太短的话,导致相同,这里是让线程挂起一段时间
            //解决这个问题也可以定义两个对象

            readyBlock = bGroup.GetABlock(); //再取一个砖块,赋给readyBlock
            readyBlock.XPos = 1;//显示readyBlock的砖块是5*5的lbl,中心是2,2
            readyBlock.YPos = 1;
            gpReady.Clear(disapperColor);
            readyBlock.Paint(gpReady);//在lblReady上画出下次出现的砖块
            //初始化并启动定时器
            timerBlock = new System.Timers.Timer(timeSpan);
            timerBlock.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);//使用委托,执行OnTimedEvent
            timerBlock.AutoReset = true;  //每隔timeSpan,都执行OnTimedEvent,如果等于false,只执行一次,
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
            int yPox = runBlock.YPos + 1;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (yPox - runBlock[i].Y > _height - 1)//如果下面过界,
                    return false;
                if (!coorArr[xPos + runBlock[i].X, yPox - runBlock[i].Y].IsEmpty)//如果下面有东西挡住,
                    return false;
            }
            runBlock.erase(gpPalette);//擦除原来位置的砖块
            runBlock.YPos++;
            runBlock.Paint(gpPalette);//在新位置上画砖块
            return true;
        }
        public void Drop()  //丢下砖块
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
        public void MoveRight()     //向右旋转
        {
            int xPos = runBlock.XPos + 1;
            int yPos = runBlock.YPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (xPos + runBlock[i].X > _width - 1)  //如果超出左右边界则旋转失败
                    return;
                if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)
                    return;
            }
            runBlock.erase(gpPalette);
            runBlock.XPos++;
            runBlock.Paint(gpPalette);
        }

        public void DeasilRotate()//顺时针旋转
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos + runBlock[i].Y;
                int y = runBlock.YPos + runBlock[i].X;
                if (x < 0 || x > _width - 1)//如果超出左右边界则旋转失败(不旋转)
                    return;
                if (y < 0 || y > _height - 1)//如果超出上下边界则旋转失败
                    return;
                if (!coorArr[x, y].IsEmpty)//如果旋转后的位置有砖块则旋转失败;
                    return;
            }
            runBlock.erase(gpPalette);
            runBlock.DeasilRotate();
            runBlock.Paint(gpPalette);
        }

  /*      public void ContraRotate()  //顺时针旋转
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
   * */
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
            if (over)//如果确定当前砖块已结束
            {
                for (int i = 0; i < runBlock.Length; i++)  //把当前砖块归入coordinateArr固定
                {
                    coorArr[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y] = runBlock.BlockColor;
                }
                //检查是否有满行情况,如果有则删除
                CheckAndDelFullRow();
                //产生新的砖块
                
                runBlock = readyBlock; //新的砖块为准备好的砖块
                runBlock.XPos = _width / 2;    //
                int y = 0;
                for (int i = 0; i < runBlock.Length; i++)
                {
                    if (runBlock[i].Y > y)
                    {
                        y = runBlock[i].Y;
                    }
                }
                runBlock.YPos = y;
                //下面是检查新出的砖块所占用的地方是否已有其他的砖块,如果有则游戏结束,
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
                        timerBlock.Stop();//游戏结束,关闭定时器
                        return;
                    }
                }
                runBlock.Paint(gpPalette);
                //获取新的准备砖块
                readyBlock = bGroup.GetABlock();
                readyBlock.XPos = 1;
                readyBlock.YPos = 1;
                gpReady.Clear(Color.Black);
                readyBlock.Paint(gpReady);
            }
        }
        private void CheckAndDelFullRow()  //检查并消除满行
        {
            //找出当前砖块所在行范围
            int lowRow = runBlock.YPos - runBlock[0].Y;//lowRow代表当前砖块的y的最小值
            int highRow = lowRow;      //highRow代表当前砖块的y轴的最大值
            for (int i = 1; i < runBlock.Length; i++)  //找出当前砖块所占行的范围,放入low/high变量内
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
            bool repaint = false;//被删行的重画标志
            for (int i = lowRow; i <= highRow; i++)    //检查满行,如果有,则删之,
            {
                bool rowFull = true;
                for (int j = 0; j < _width; j++)   //判断是否满行
                {
                    if (coorArr[j, i].IsEmpty) //如果有一个单元格空,则说明不满,
                    {
                        rowFull = false;
                        break;
                    }
                }
                if (rowFull)   //if满,则删之
                {
                    score +=100;
                    if (score % 1000 == 0)
                    {
                        level++;
                        TimeSpan2 = TimeSpan;
                        TimeSpan2 -= 20;
                        if(TimeSpan2<TimeSpan)
                        {
                            TimeSpan = TimeSpan2;
                            timerBlock.Close();
                            timerBlock = new System.Timers.Timer(timeSpan);
                            timerBlock.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);//使用委托,执行OnTimedEvent
                            timerBlock.AutoReset = true;  //每隔timeSpan,都执行OnTimedEvent,如果等于false,只执行一次,
                            timerBlock.Start();
                        }


                    }
                    repaint = true;    //删除的话.标记上,重绘,
                    for (int k = i; k > 0; k--)    //把第n行的值用n-1来代替,(下沉一行)
                    {
                        for (int j = 0; j < _width; j++)
                        {
                            coorArr[j, k] = coorArr[j, k - 1];
                        }

                    }
                    for (int j = 0; j < _width; j++)   //清空第0行
                    {
                        coorArr[j, 0] = Color.Empty;
                    }
                    //下面这两句为新添加的触发事件代码
                    //  sea.Score += 100; //给事件参数类里的Score字段增加100分
                    //  OnScoreInc(); //触发分数增加事件
                    // timeeblock();
                }

            }
            if (repaint)   //重绘标志true.则^绘之(把之前的清除,把改后的显出!)
            {
                PaintBackground(gpPalette);
                ShowScore(_gpScore);
                ShowLevel(_bpLevel);
            }
        }
        private void PaintBackground(Graphics gp)//重画画板的背景
        {
            gp.Clear(Color.Black);//首先清空画板
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
        public void PaintPalette(Graphics gp)   //重画整个画板
        {
            PaintBackground(gp);    //先画背景

            if (runBlock != null)   //再画活动的砖块
            {
                runBlock.Paint(gp);
            }
        }

        public void PaintReady(Graphics gp)//在lblReady重画下一个砖块
        {
            if (readyBlock != null)
            {
                readyBlock.Paint(gp);
            }
        }
        public void Pause()//暂停,
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
        public void ShowScore(Graphics gp)
        {
            gp.Clear(Color.White);

            gp.DrawString(score.ToString(), new Font("Arial Black", 10f), new SolidBrush(Color.Black), new Point(0, 0));
        }
        public void ShowLevel(Graphics bp)
        {
            bp.Clear(Color.White);

            bp.DrawString(level.ToString(), new Font("Arial Black", 10f), new SolidBrush(Color.Black), new Point(0, 0));
        }

        public void Close()//关闭
        {
            timerBlock.Close();//关闭定时器
            gpPalette.Dispose();//释放画布
            gpReady.Dispose();
        }


    }
}
