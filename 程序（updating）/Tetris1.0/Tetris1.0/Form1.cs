using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tetris1._0
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 主函数入口
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        #region 定义砖块int[i,j,y,x] tricks:i为那块砖,j为状态,y为列,x为行
        /// <summary>
        /// 定义砖块int[i,j,y,x] 
        /// 4种类型方块，每种方块的4种方位，4*4的位置矩阵
        /// tricks:i为块砖类型,j为状态,x为行,y为列
        /// </summary>
        private int[, , ,] tricks = {{
                                      {
                                          {1,0,0,0},
                                          {1,0,0,0},
                                          {1,0,0,0},
                                          {1,0,0,0}
                                      },
                                      {
                                          {1,1,1,1},
                                          {0,0,0,0},
                                          {0,0,0,0},
                                          {0,0,0,0}
                                      },
                                      {
                                          {1,0,0,0},
                                          {1,0,0,0},
                                          {1,0,0,0},
                                          {1,0,0,0}
                                      },
                                      {
                                          {1,1,1,1},
                                          {0,0,0,0},
                                          {0,0,0,0},
                                          {0,0,0,0}
                                      }
                                  },
                                  {
                                       {
                                           {1,1,0,0},
                                           {1,1,0,0},
                                           {0,0,0,0},
                                           {0,0,0,0}
                                       },
                                       {
                                           {1,1,0,0},
                                           {1,1,0,0},
                                           {0,0,0,0},
                                           {0,0,0,0}
                                       },
                                       {
                                           {1,1,0,0},
                                           {1,1,0,0},
                                           {0,0,0,0},
                                           {0,0,0,0}
                                       },
                                       {
                                           {1,1,0,0},
                                           {1,1,0,0},
                                           {0,0,0,0},
                                           {0,0,0,0}
                                       }
                                   },
                                   {
                                       {
                                           {1,0,0,0},
                                           {1,1,0,0},
                                           {0,1,0,0},
                                           {0,0,0,0}
                                       },
                                       {
                                           {0,1,1,0},
                                           {1,1,0,0},
                                           {0,0,0,0},
                                           {0,0,0,0}
                                       },
                                       {
                                           {1,0,0,0},
                                           {1,1,0,0},
                                           {0,1,0,0},
                                           {0,0,0,0}
                                       },
                                       {
                                           {0,1,1,0},
                                           {1,1,0,0},
                                           {0,0,0,0},
                                           {0,0,0,0}
                                       }
                                   },
                                   {
                                       {
                                           {0,1,0,0},
                                           {1,1,0,0},
                                           {1,0,0,0},
                                           {0,0,0,0}
                                       },
                                       {
                                           {1,1,0,0},
                                           {0,1,1,0},
                                           {0,0,0,0},
                                           {0,0,0,0}
                                       },
                                       {
                                           {0,1,0,0},
                                           {1,1,0,0},
                                           {1,0,0,0},
                                           {0,0,0,0}
                                       },
                                       {
                                           {1,1,0,0},
                                           {0,1,1,0},
                                           {0,0,0,0},
                                           {0,0,0,0}
                                       }
                                   },
                                   {
                                       {
                                           {1,1,0,0},
                                           {0,1,0,0},
                                           {0,1,0,0},
                                           {0,0,0,0}
                                       },
                                       {
                                           {0,0,1,0},
                                           {1,1,1,0},
                                           {0,0,0,0},
                                           {0,0,0,0}
                                       },
                                       {
                                           {1,0,0,0},
                                           {1,0,0,0},
                                           {1,1,0,0},
                                           {0,0,0,0}
                                       },
                                       {
                                           {1,1,1,0},
                                           {1,0,0,0},
                                           {0,0,0,0},
                                           {0,0,0,0}
                                       }
                                   },{{
                                         {1,0,0,0},
                                         {1,1,1,0},
                                         {0,0,0,0},
                                         {0,0,0,0}
                                     },
                                     {
                                         {1,1,0,0},
                                         {1,0,0,0},
                                         {1,0,0,0},
                                         {0,0,0,0}
                                     },
                                     {
                                        {1,1,1,0},
                                        {0,0,1,0},
                                        {0,0,0,0},
                                        {0,0,0,0}

                                     },
                                     {
                                         {0,1,0,0},
                                         {0,1,0,0},
                                         {1,1,0,0},
                                         {0,0,0,0}
                                     }},
                                     {{
                                         {0,1,0,0},
                                         {1,1,1,0},
                                         {0,0,0,0},
                                         {0,0,0,0}
                                     },
                                     {
                                         {0,1,0,0},
                                         {0,1,1,0},
                                         {0,1,0,0},
                                         {0,0,0,0}
                                     },
                                     {
                                        {1,1,1,0},
                                        {0,1,0,0},
                                        {0,0,0,0},
                                        {0,0,0,0}

                                     },
                                     {
                                         {0,1,0,0},
                                         {1,1,0,0},
                                         {0,1,0,0},
                                         {0,0,0,0}
                                     }}
                                   };

        #endregion

        #region 定义背景
        /// <summary>
        /// 定义背景
        /// x：行,y：列,color：颜色
        /// </summary>
        private int[, ,] bgGraoud ={
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                     {{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                 };
        #endregion

        #region 定义颜色表
        /// <summary>
        /// 各个砖块对应的RGB信息
        /// </summary>
        private Color[,] tricksColor =  {
                                        {Color.FromArgb(0,0,255),Color.FromArgb(200,200,253),Color.FromArgb(98,98,140)},
                                        {Color.FromArgb(255,0,0),Color.FromArgb(253,200,200),Color.FromArgb(140,98,98)}, 
                                        {Color.FromArgb(0,255,20),Color.FromArgb(76,206,23),Color.FromArgb(65,206,45)},
                                        {Color.FromArgb(255,0,255),Color.FromArgb(253,200,255),Color.FromArgb(189,84,255)},
                                        {Color.FromArgb(255,255,0),Color.FromArgb(253,253,200),Color.FromArgb(189,189,84)},
                                        {Color.FromArgb(255,128,0),Color.FromArgb(253,148,41),Color.FromArgb(189,108,17)},
                                        {Color.FromArgb(128,64,64),Color.FromArgb(253,78,68),Color.FromArgb(189,68,68)}
                                        };
        #endregion

        //private Graphics g;//定义窗体画布
        private int[, ,] currentTrick = new int[4, 4, 2]; //当前的砖块
        private int currentTrickNum;//当前砖块的数目
        private int currentDirection = 0;// 当前砖块的方位
        private int currentX;//当前坐标x
        private int currentY;//当前坐标y
        private int score;//分数
        private int tricksNum = 7;//方块的数目
        private int statusNum = 4;//方块的方位
        private Image myImage, myImageBg, myImageTricks;//游戏面板背景
        private Random rand = new Random();//随机数
        private int step = 1;//关卡数
        private int lowY = 19; //初始化的时候为到最下面。然后随着lowY的增加，循环范围会原来越大

        /// <summary>
        /// 窗体默认加载方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化
            myImage = new Bitmap(panel1.Width, panel1.Height);
            myImageBg = new Bitmap(panel1.Width, panel1.Height);
            myImageTricks = new Bitmap(panel1.Width, panel1.Height);
            score = 0;
        }

        /// <summary>
        /// 重写窗体重绘的方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawTetris();
            base.OnPaint(e);
        }

       
        /// <summary>
        /// 随机生成方块和状态
        /// </summary>
        private void Begintricks()
        {
            //随机生成砖码和状态码
            int i = rand.Next(0, tricksNum);
            int j = rand.Next(0, statusNum);
            currentTrickNum = i;
            currentDirection = j;
            //分配数组
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    currentTrick[y, x, 0] = tricks[i, j, y, x];
                    currentTrick[y, x, 1] = i;
                }
            }
            currentX = 7;
            currentY = 0;
            timer1.Start();
        }


        /// <summary>  
        ///  旋转方块  
        /// </summary>  
        private void Changetricks()
        {
            //判断当前方块的方位
            if (currentDirection < 3)
            {
                //改变方块的方位
                currentDirection++;
            }
            else
            {
                //恢复到默认方位
                currentDirection = 0;
            }
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    currentTrick[y, x, 0] = tricks[currentTrickNum, currentDirection, y, x];
                }
            }
        }
        /// <summary>
        /// 下落方块
        /// </summary>
        private void Downtricks()
        {
            //判断是否可以下落
            if (CheckIsDown())
            {
                //下落时，方块所在行数加1
                currentY++;
            }
            else
            {
                if (currentY == 0)
                {
                    //计时停止，游戏结束
                    timer1.Stop();
                    MessageBox.Show("哈哈，你玩玩了");

                    return;
                }
                //下落完成，修改背景

                if (currentY < lowY)
                {
                    lowY = currentY;
                }
                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        if (currentTrick[y, x, 0] == 1)
                        {
                            bgGraoud[currentY + y, currentX + x, 0] = currentTrick[y, x, 0];
                            bgGraoud[currentY + y, currentX + x, 1] = currentTrick[y, x, 1];
                        }
                    }
                }

                CheckScore();
                Begintricks();

            }
            DrawTetris();
        }
        /// <summary>
        /// 检测是否可以向下了
        /// </summary>
        /// <returns></returns>
        private bool CheckIsDown()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (currentTrick[y, x, 0] == 1)
                    {
                        //超过了背景
                        if (y + currentY + 1 >= 20)
                        {
                            return false;
                        }
                        if (x + currentX >= 14)
                        {
                            currentX = 13 - x;
                        }
                        if (bgGraoud[y + currentY + 1, x + currentX, 0] == 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 检测是否可以左移
        /// </summary>
        /// <returns></returns>
        private bool CheckIsLeft()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (currentTrick[y, x, 0] == 1)
                    {
                        if (x + currentX - 1 < 0)
                        {
                            return false;
                        }
                        if (bgGraoud[y + currentY, x + currentX - 1, 0] == 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 检测是否可以右移
        /// </summary>
        /// <returns></returns>
        private bool CheckIsRight()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (currentTrick[y, x, 0] == 1)
                    {
                        if (x + currentX + 1 >= 14)
                        {
                            return false;
                        }
                        if (bgGraoud[y + currentY, x + currentX + 1, 0] == 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 绘制方块的方法
        /// </summary>
        private void DrawTetris()
        {

            Graphics g = Graphics.FromImage(myImage);
            g.Clear(panel1.BackColor);

            for (int bgy = 19; bgy > lowY - 1; bgy--)
            {
                for (int bgx = 0; bgx < 14; bgx++)
                {
                    if (bgGraoud[bgy, bgx, 0] == 1)
                    {
                        //首先绘制一个基本方块
                        g.FillRectangle(new SolidBrush(tricksColor[bgGraoud[bgy, bgx, 1], 0]), bgx * 20, bgy * 20, 20, 20);
                        //绘制上边
                        g.DrawRectangle(new Pen(panel1.BackColor), bgx * 20, bgy * 20, 20, 20);
                        Point[] myPoints1 = { new Point(bgx * 20 + 5, bgy * 20 - 5), new Point(bgx * 20 + 25, bgy * 20 - 5), new Point(bgx * 20 + 20, bgy * 20), new Point(bgx * 20, bgy * 20) };
                        g.FillPolygon(new SolidBrush(tricksColor[bgGraoud[bgy, bgx, 1], 1]), myPoints1);
                        g.DrawPolygon(new Pen(panel1.BackColor), myPoints1);
                        //绘制右边
                        Point[] myPoints2 = { new Point(bgx * 20 + 20, bgy * 20), new Point(bgx * 20 + 25, bgy * 20 - 5), new Point(bgx * 20 + 25, bgy * 20 + 15), new Point(bgx * 20 + 20, bgy * 20 + 20) };
                        g.FillPolygon(new SolidBrush(tricksColor[bgGraoud[bgy, bgx, 1], 2]), myPoints2);
                    }
                }
            }
            //绘制当前的图片
            for (int y = 3; y >= 0; y--)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (currentTrick[y, x, 0] == 1)
                    {
                        //绘制基本方块
                        g.FillRectangle(new SolidBrush(tricksColor[currentTrick[y, x, 1], 0]), (x + currentX) * 20, (y + currentY) * 20, 20, 20);
                        g.DrawRectangle(new Pen(panel1.BackColor), (x + currentX) * 20, (y + currentY) * 20, 20, 20);

                        //绘制周围区域，增强立体感
                        if (x + 1 + currentX < 14)
                        {
                            if (bgGraoud[y + currentY, x + 1 + currentX, 0] == 0)
                            {
                                //绘制上边
                                Point[] myPoints1 = { new Point((x + currentX) * 20 + 5, (y + currentY) * 20 - 5), new Point((x + currentX) * 20 + 25, (y + currentY) * 20 - 5), new Point((x + currentX) * 20 + 20, (y + currentY) * 20), new Point((x + currentX) * 20, (y + currentY) * 20) };
                                g.FillPolygon(new SolidBrush(tricksColor[currentTrick[y, x, 1], 1]), myPoints1);

                                //绘制右边
                                g.DrawPolygon(new Pen(panel1.BackColor), myPoints1);
                                Point[] myPoints2 = { new Point((x + currentX) * 20 + 20, (y + currentY) * 20), new Point((x + currentX) * 20 + 25, (y + currentY) * 20 - 5), new Point((x + currentX) * 20 + 25, (y + currentY) * 20 + 15), new Point((x + currentX) * 20 + 20, (y + currentY) * 20 + 20) };
                                g.FillPolygon(new SolidBrush(tricksColor[currentTrick[y, x, 1], 2]), myPoints2);
                            }
                            else
                            {
                                Point[] myPoints1 = { new Point((x + currentX) * 20 + 5, (y + currentY) * 20 - 5), new Point((x + currentX) * 20 + 20, (y + currentY) * 20 - 5), new Point((x + currentX) * 20 + 20, (y + currentY) * 20), new Point((x + currentX) * 20, (y + currentY) * 20) };
                                g.FillPolygon(new SolidBrush(tricksColor[currentTrick[y, x, 1], 1]), myPoints1);
                                g.DrawPolygon(new Pen(panel1.BackColor), myPoints1);
                            }
                        }
                        else
                        {
                            Point[] myPoints1 = { new Point((x + currentX) * 20 + 5, (y + currentY) * 20 - 5), new Point((x + currentX) * 20 + 20, (y + currentY) * 20 - 5), new Point((x + currentX) * 20 + 20, (y + currentY) * 20), new Point((x + currentX) * 20, (y + currentY) * 20) };
                            g.FillPolygon(new SolidBrush(tricksColor[currentTrick[y, x, 1], 1]), myPoints1);
                            g.DrawPolygon(new Pen(panel1.BackColor), myPoints1);
                        }
                    }
                }
            }
            Graphics gg = panel1.CreateGraphics();

            gg.DrawImage(myImage, 0, 0);
        }

        /// <summary>
        /// 计时器事件监听方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Downtricks();
        }

        /// <summary>
        /// 键盘按键按下事件监听器方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                Changetricks();
                DrawTetris();
            }
            else if (e.KeyCode == Keys.A)
            {
                if (CheckIsLeft())
                {
                    currentX--;
                }
                DrawTetris();
            }
            else if (e.KeyCode == Keys.D)
            {
                if (CheckIsRight())
                {
                    currentX++;
                }
                DrawTetris();
            }
            else if (e.KeyCode == Keys.S)
            {
                timer1.Stop();
                timer1.Interval = 10;
                timer1.Start();
            }
        }

        /// <summary>
        /// 键盘按键释放事件监听器方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                timer1.Stop();
                timer1.Interval = (11 - step) * 100;
                timer1.Start();
            }
        }

        /// <summary>
        /// 判断是否一行填满取得奖励得分，是否通关的方法
        /// </summary>
        private void CheckScore()
        {
            for (int y = 19; y > lowY; y--)
            {
                bool isFull = true;
                for (int x = 13; x > -1; x--)
                {
                    if (bgGraoud[y, x, 0] == 0)
                    {
                        isFull = false;
                        break;
                    }
                }
                if (isFull)
                {
                    //增加积分
                    lowY++; //减少了一行，循环就可以减少一行
                    score = score + 100;
                    step = score / 1000 + 1;
                    if (step == 11)
                    {
                        timer1.Stop();
                        MessageBox.Show("恭喜恭喜，你的游戏过通关了");

                    }
                    else
                    {
                        timer1.Interval = (11 - step) * 100;
                        for (int yy = y; yy > 0; yy--)
                        {
                            for (int xx = 0; xx < 14; xx++)
                            {
                                int temp = bgGraoud[yy - 1, xx, 0];
                                int temp2 = bgGraoud[yy - 1, xx, 1];
                                bgGraoud[yy, xx, 0] = temp;
                                bgGraoud[yy, xx, 1] = temp2;
                            }
                        }
                        y++;
                    }
                    label1.Text = "游戏得分：" + score.ToString();
                    label1.Text += "\r\n\r\n您现在在:";
                    label1.Text += step.ToString();
                    label1.Text += "关";
                    DrawTetris();
                }

            }
        }

        /// <summary>
        /// 按钮"启动游戏"的事件监听方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 14; x++)
                {
                    bgGraoud[y, x, 0] = 0;
                }
            }
            lowY = 19;
            timer1.Interval = (11 - step) * 100;
            Begintricks();
            this.Focus();
        }

        /// <summary>
        /// 按钮"暂停游戏"的事件监听方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "暂停游戏")
            {
                button2.Text = "开始游戏";
                timer1.Stop();
            }
            else
            {
                button2.Text = "暂停游戏";
                timer1.Start();
            }
        }
    }
}
