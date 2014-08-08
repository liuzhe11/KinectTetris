using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace Kinect_TetrisV2
{
    public class Body
    {
        //建立body区域的长宽 初始化参数得
        public Body()
        {
            maxWidth = 12;
            maxHeight = 15;
            filledLines = 0;
        }

        public enum MOVE_TYPE { MOVE_LEFT = 0, MOVE_RIGHT = 1, MOVE_DOWN = 2, MOVE_FALL = 3, MOVE_ROTATE = 4 };

        private ArrayList blockList = new ArrayList();
        private Shape nextShape;
        private int maxWidth;
        private int maxHeight;
        private int filledLines;

        public bool SetNextShape(Shape s)
        {
            nextShape = s;
            nextShape.Position = new Point(4, 0);
            bool ret = false;
            //*
            while (!ShapeCanPlace(nextShape))
            {
                Point pt = nextShape.Position;
                pt.Y--;
                nextShape.Position = pt;
                ret = true;
            }
            //*/
            return ret;
        }

        public void Draw(Graphics g)
        {
            DrawNextShape(g);

            for (int i = 0; i < blockList.Count; i++)
            {
                ((Block)(blockList[i])).Draw(g);
            }

            int cellSize = 40;
            int xCellCnt = 12;
            int yCellCnt = 15;
            Pen p = new Pen(Color.FromArgb(200,200,200), 1);
            for (int y = 0; y < yCellCnt; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, xCellCnt * cellSize, y * cellSize);
            }

            for (int x = 0; x < xCellCnt; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, yCellCnt * cellSize);
            }
            g.FillRectangle(new SolidBrush(Color.FromArgb(200,200,200)), 0, 40*(maxHeight-filledLines), 50*maxWidth, 40*filledLines);
        }

        /// <summary>
        /// 移动和旋转方块的方法
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="m">变换方位类型</param>
        /// <returns></returns>
        public bool MoveShape(Graphics g, MOVE_TYPE m)
        {
            Shape s = new Shape(nextShape.IndexDef);
            s.Copy(nextShape);
            Point pt = s.Position;
            g.FillRectangle(new SolidBrush(Color.FromArgb(200,200,200)), 0, 40*(maxHeight-filledLines), 50*maxWidth, 40*filledLines);
            switch (m)
            {
                case MOVE_TYPE.MOVE_FALL:
                    {
                        while (ShapeCanPlace(s))
                        {
                            pt.Y++;
                            s.Position = pt;
                        }

                        nextShape.Draw(g, true);
                        pt.Y--;
                        s.Position = pt;
                        nextShape.Copy(s);
                        nextShape.Draw(g);
                        PlaceShape();
                        return true;
                        //break;
                    }
                case MOVE_TYPE.MOVE_DOWN:
                    pt.Y++;
                    break;
                case MOVE_TYPE.MOVE_LEFT:
                    pt.X--;
                    break;
                case MOVE_TYPE.MOVE_RIGHT:
                    pt.X++;
                    break;
                case MOVE_TYPE.MOVE_ROTATE:
                    s.Rotate();
                    break;
                default:
                    break;
            }

            s.Position = pt;
            if (ShapeCanPlace(s))
            {
                nextShape.Draw(g, true);
                nextShape.Copy(s);
                nextShape.Draw(g);
            }
            else
            {
                if (m == MOVE_TYPE.MOVE_DOWN)
                {
                    PlaceShape();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断位置是否到底
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ShapeCanPlace(Shape s)
        {
            for (int i = 0; i < s.BlockCnt; i++)
            {
                Point pt = s.Position;
                Point ptOff = s.GetBlock(i).Position;
                pt.Offset(ptOff.X, ptOff.Y);
                if (PositionHasBlock(pt))
                    return false;
            }
            return true;
        }

        public bool PositionHasBlock(Point pt)
        {
            if (pt.Y < 0) return false;
            Rectangle rc = new Rectangle(0, 0, maxWidth, maxHeight - filledLines);
            if (!rc.Contains(pt))
            {
                return true;
            }
            for (int i = 0; i < blockList.Count; i++)
            {
                if (((Block)(blockList[i])).Position == pt)
                {
                    return true;
                }
            }
            return false;
        }

        public void PlaceShape()
        {
            for (int i = 0; i < nextShape.BlockCnt; i++)
            {
                Point pt = nextShape.Position;
                Point ptOff = nextShape.GetBlock(i).Position;
                pt.Offset(ptOff.X, ptOff.Y);
                nextShape.GetBlock(i).Position = pt;
                blockList.Add(nextShape.GetBlock(i));
            }
        }

        public void Reset()
        {
            blockList.Clear();
            filledLines = 0;
        }

        /// <summary>
        /// 清行程序 把的填满的一行清除 首先判断是否存在一行中的空块
        /// 存在的话则不能清除 反之 则清除 如果第i行清除 那么就把比i行大
        /// 那些行自动浮下来一个
        /// </summary>
        /// <returns></returns>
        public int ClearLines()
        {
            int count = 0;
            for (int i = 0; i < maxHeight - filledLines; i++)
            {
                bool clear = true;
                for (int j = 0; j < maxWidth; j++)
                {
                    if (!PositionHasBlock(new Point(j, i)))
                    {
                        clear = false;
                        break;
                    }
                }
                if (clear)
                {
                    for (int n = blockList.Count - 1; n >= 0; n--)
                    {
                        //如果第i行满了 则清除i行
                        if (((Block)(blockList[n])).Position.Y == i)
                        {
                            blockList.RemoveAt(n);
                        }
                        //其他的比i行大的那些行则自动浮上来
                        else if (((Block)(blockList[n])).Position.Y > i)
                        {
                            Point pt = ((Block)(blockList[n])).Position;
                            pt.Y--;
                            ((Block)(blockList[n])).Position = pt;
                        }
                    }
                    count++;
                }
            }
            filledLines += count;
            return count;
        }

        /// <summary>
        /// 画下次出现的方块的方法
        /// </summary>
        /// <param name="g"></param>
        public void DrawNextShape(Graphics g)
        {
            nextShape.Draw(g);
        }


    }
}
