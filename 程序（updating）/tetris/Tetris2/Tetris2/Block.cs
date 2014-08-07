using System;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Tetris2
{
    class Block
    {
        private Point[] _cellArray;  //���ڴ��ש���������ֵ
        private Color _blockColor;  //ש�����ɫ
        private Color _disapperColor;   //������ɫ
        private int _xPos;          //ש�������ڻ����ϵ�x����
        private int _yPos;          //ש�������ڻ����ϵ�y����
        private int _rectPix;       //ÿ����Ԫ������ش�С

        #region ˽�г�Ա������Ӧ������
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
        {   //��ש����ԭ�����µ�����ת��Ϊ���»����µ�����
            return new Rectangle((_xPos + p.X) * _rectPix + 1, 
                (_yPos - p.Y) * _rectPix + 1, 
                _rectPix - 2,
                _rectPix - 2);
        }
        //��ָ�������ϻ���ש��
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
            int x1 = 10;//С��
            int x2 = -10;//���
            int y1 = 10;//С��
            int y2 = -10;//���
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
