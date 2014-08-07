using System;
using System.Drawing;
using System.Text;
using System.Collections;

namespace MyBlock
{
    class Box 
    {
        protected Point[] structArr;    //存放砖块组成信息的坐标数组
        protected int _xPos;    //砖块中心点所在的X坐标
        protected int _yPos;    //砖块中心所在的y坐标
        protected Color _blockColor;    //砖块颜色
        protected Color disapperColor;  //擦除颜色
        protected int rectPix;          //每个单元格像素
        public Box()  //默认构造函数,声明此构造函数是为了子类能创建
        {
        }
        public Box(Point[] sa, Color bColor, Color dColor, int pix)
        {       //重载构造函数,给成员变量赋值
            _blockColor = bColor;
            disapperColor = dColor;
            rectPix = pix;
            structArr = sa;
        }
        public Point this[int index]
        {
            get
            {
                return structArr[index];
            }
        }
        public int Length
        {
            get
            {
                return structArr.Length;
            }
        }
        #region  变量有关属性
        public int XPos
        {
            get
            {
                return _xPos;
            }
            set
            {
                _xPos = value;
            }
        }
        public int YPos
        {
            get
            {
                return _yPos;
            }
            set
            {
                _yPos = value;
            }
        }
        public Color BlockColor
        {
            get
            {
                return _blockColor;
            }
        }
        #endregion
        public void DeasilRotate()//顺时针旋转
        {
            int temp;   //旋转公式:x1 = y     y1=-x
            for (int i = 0; i < structArr.Length; i++)
            {
                temp = structArr[i].X;
                structArr[i].X = structArr[i].Y;
                structArr[i].Y = -temp;
            }
        }
  /*      public void ContraRotate()//逆时针旋转
        {
            int temp;
            for (int i = 0; i < structArr.Length; i++)
            {
                temp = structArr[i].X;
                structArr[i].X = -structArr[i].Y;
                structArr[i].Y = temp;
            }
        }*/
        private Rectangle PointToRect(Point p)  //把一个坐标点转化为画布的坐标(相对转绝对)
        {
            return new Rectangle((_xPos + p.X) * rectPix + 1,
                                  (_yPos - p.Y) * rectPix + 1,
                                  rectPix - 2,
                                  rectPix - 2);
        }
        public virtual void Paint(Graphics gp)  //在指定画板绘制砖块;( 方块移动时,不停的重画 )
        {
            SolidBrush sb = new SolidBrush(_blockColor);
            foreach (Point p in structArr)
            {
                lock (gp)
                {
                    gp.FillRectangle(sb, PointToRect(p));
                }
            }
        }
        public void erase(Graphics gp)//擦出矩形 ( 方块移除时,重新显示背景色 )
        {
            SolidBrush sb = new SolidBrush(disapperColor);
            foreach (Point p in structArr)
            {
                lock (gp)
                {
                    gp.FillRectangle(sb, PointToRect(p));
                }
            }
        }
    }
}
