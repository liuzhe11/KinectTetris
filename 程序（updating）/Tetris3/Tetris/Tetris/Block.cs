using System;
using System.Collections;
using System.Drawing;
using System.Text;

namespace Tetris
{
    class Block
    {
        protected Point[] structArr;
        protected int _xPos;
        protected int _yPos;
        protected Color _blockColor;
        protected Color disapperColor;
        protected int rectPix;
        public Block()
        {

        }
        public Block(Point[] sa,Color bColor,Color dColor,int pix)
        {
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
        #region 成员变量相应的属性
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
        public void DeasilRotate()
        {
            int temp;
            for (int i = 0; i < structArr.Length; i++)
            {
                temp = structArr[i].X;
                structArr[i].X = structArr[i].Y;
                structArr[i].Y = -temp;
            }
        }
        public void ContraRotate()
        {
            int temp;
            for (int i = 0; i < structArr.Length; i++)
            {
                temp = structArr[i].X;
                structArr[i].X = -structArr[i].Y;
                structArr[i].Y = temp;
            }
        }
        private Rectangle PointToRect(Point p)
        {
            return new Rectangle((_xPos + p.X) * rectPix + 1,
                                 (_yPos - p.Y) * rectPix + 1,
                                  rectPix - 2,
                                  rectPix - 2);
        }
        public virtual void Paint(Graphics gp)
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
        public void erase(Graphics gp)
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
