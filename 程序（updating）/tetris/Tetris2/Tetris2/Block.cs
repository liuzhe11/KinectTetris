using System;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Tetris2
{
    class Block
    {
        private Point[] _cellArray;  //用于存放砖块组的坐标值
        private Color _blockColor;  //砖块的颜色
        private Color _disapperColor;   //擦除颜色
        private int _xPos;          //砖块中心在画板上的x坐标
        private int _yPos;          //砖块中心在画板上的y坐标
        private int _rectPix;       //每个单元格的像素大小

        #region 私有成员变量相应的属性
        public Point[] CellArray
        {
            get
            {
                return _cellArray;
            }
            set
            {
                _cellArray = value;
            }
        }
        public Color BlockColor
        {
            get
            {
                return _blockColor;
            }
            set
            {
                _blockColor = value;
            }
        }
        public Color DisapperColor
        {
            get
            {
                return _disapperColor;
            }
            set
            {
                _disapperColor = value;
            }
        }
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
        public int RectPix
        {
            get
            {
                return _rectPix;
            }
            set
            {
                _rectPix = value;
            }
        }
        #endregion

        public Point this[int index]
        {
            get
            {
                return _cellArray[index];
            }
        }
        public int Length
        {
            get
            {
                return _cellArray.Length;
            }
        }

        public Block(Point[] p,Color bcolor,Color dcolor,int pix)
        {
            _cellArray = p;
            _blockColor = bcolor;
            _disapperColor = dcolor;
            _rectPix = pix;
        }

        public Rectangle PointToRect(Point p)
        {   //把砖块在原画板下的坐标转换为在新画板下的坐标
            return new Rectangle((_xPos + p.X) * _rectPix + 1, 
                (_yPos - p.Y) * _rectPix + 1, 
                _rectPix - 2,
                _rectPix - 2);
        }
        //在指定画板上绘制砖块
        public void PaintBlockOn(Graphics gp)
        {
            SolidBrush s=new SolidBrush(_blockColor);
            
            foreach(Point p in _cellArray)
            {
                lock (gp)
                {
                    gp.FillRectangle(s, PointToRect(p));
                }
            }
        }

        public Rectangle MinRect()
        {
            int x1 = 10;//小的
            int x2 = -10;//大的
            int y1 = 10;//小的
            int y2 = -10;//大的
            for (int i = 0; i < _cellArray.Length; i++)
            {
                if (_cellArray[i].X < x1)
                {
                    x1 = _cellArray[i].X;
                }
                if (_cellArray[i].X > x2)
                {
                    x2 = _cellArray[i].X;
                }
                if (_cellArray[i].Y < y1)
                {
                    y1 = _cellArray[i].Y;
                }
                if (_cellArray[i].Y > y2)
                {
                    y2 = _cellArray[i].Y;
                }

            }
            return new Rectangle(x1, y2, x2, y1);
        }

        public void Rotate()
        {
            for (int i = 0; i < _cellArray.Length; i++)
            {
                int temp = _cellArray[i].X;
                _cellArray[i].X = _cellArray[i].Y;
                _cellArray[i].Y = -temp;
            }
        }

        public void Eraser(Graphics gp)
        {
            SolidBrush sb = new SolidBrush(_disapperColor);
            foreach (Point p in _cellArray)
            {
                lock (gp)
                {
                    gp.FillRectangle(sb, PointToRect(p));
                }
            }
        }
    }
}
