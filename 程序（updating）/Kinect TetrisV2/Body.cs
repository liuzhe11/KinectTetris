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

        public enum MOVE_TYPE { MOVE_LEFT = 0, MOVE_RIGHT = 1, MOVE_DOWN = 2, MOVE_FALL = 3, MOVE_ROTATELEFT = 4, MOVE_ROTATERIGHT = 5 };

        private ArrayList blockList = new ArrayList();
        private Shape currentShape;
        private int maxWidth;
        private int maxHeight;
        private int filledLines;

        public bool SetCurrentShape(Shape s)
        {
            currentShape = s;
            currentShape.Position = new Point(4, 0);
            bool ret = false;
            //*
            while (!ShapeCanPlace(currentShape))
            {
                Point pt = currentShape.Position;
                pt.Y--;
                currentShape.Position = pt;
                ret = true;
            }
            //*/
            return ret;
        }

        public void Draw(Graphics g, bool drawCurrent)
        {
            if (drawCurrent) {
                DrawCurrentShape(g);
            }

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
            //g.FillRectangle(new SolidBrush(Color.FromArgb(200,200,200)), 0, 40*(maxHeight-filledLines), 40*maxWidth, 40*filledLines);

            // Create image.
            Image newImage =Properties.Resources.sample;

            // Create parallelogram for drawing image.
            Point ulCorner = new Point(0, 40*(maxHeight-filledLines));
            Point urCorner = new Point(40*maxWidth, 40*(maxHeight-filledLines));
            Point llCorner = new Point(0, 40*maxHeight);
            Point[] destPara = {ulCorner, urCorner, llCorner};

            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(0, 900 - filledLines*599 / maxWidth, 599, filledLines*599 / maxWidth);
            GraphicsUnit units = GraphicsUnit.Pixel;

            // Draw image to screen.
            g.DrawImage(newImage, destPara, srcRect, units);
        }

        /// <summary>
        /// 移动和旋转方块的方法
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="m">变换方位类型</param>
        /// <returns></returns>
        public bool MoveShape(Graphics g, MOVE_TYPE m)
        {
            Shape s = new Shape(currentShape.IndexDef);
            s.Copy(currentShape);
            Point pt = s.Position;
            //g.FillRectangle(new SolidBrush(Color.FromArgb(200,200,200)), 0, 40*(maxHeight-filledLines), 40*maxWidth, 40*filledLines);

            // Create image.
            Image newImage = Properties.Resources.sample;

            // Create parallelogram for drawing image.
            Point ulCorner = new Point(0, 40*(maxHeight-filledLines));
            Point urCorner = new Point(40*maxWidth, 40*(maxHeight-filledLines));
            Point llCorner = new Point(0, 40*maxHeight);
            Point[] destPara = {ulCorner, urCorner, llCorner};

            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(0, 900 - filledLines*599 / maxWidth, 599, filledLines*599 / maxWidth);
            GraphicsUnit units = GraphicsUnit.Pixel;

            // Draw image to screen.
            g.DrawImage(newImage, destPara, srcRect, units);
            switch (m)
            {
                case MOVE_TYPE.MOVE_FALL:
                    {
                        while (ShapeCanPlace(s))
                        {
                            pt.Y++;
                            s.Position = pt;
                        }

                        currentShape.Draw(g, true);
                        pt.Y--;
                        s.Position = pt;
                        currentShape.Copy(s);
                        currentShape.Draw(g);
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
                case MOVE_TYPE.MOVE_ROTATELEFT:
                    s.RotateLeft();
                    break;
                case MOVE_TYPE.MOVE_ROTATERIGHT:
                    s.RotateRight();
                    break;
                default:
                    break;
            }

            s.Position = pt;
            if (ShapeCanPlace(s))
            {
                currentShape.Draw(g, true);
                currentShape.Copy(s);
                currentShape.Draw(g);
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
            for (int i = 0; i < currentShape.BlockCnt; i++)
            {
                Point pt = currentShape.Position;
                Point ptOff = currentShape.GetBlock(i).Position;
                pt.Offset(ptOff.X, ptOff.Y);
                currentShape.GetBlock(i).Position = pt;
                blockList.Add(currentShape.GetBlock(i));
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
        /// 画当前出现的方块的方法
        /// </summary>
        /// <param name="g"></param>
        public void DrawCurrentShape(Graphics g)
        {
            currentShape.Draw(g);
        }


    }
}
