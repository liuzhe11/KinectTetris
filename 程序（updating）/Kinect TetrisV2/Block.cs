using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Kinect_TetrisV2
{
    public class Block
    {
        public Block()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index"></param>
        /// <param name="pt"></param>
        public Block(int index, Point pt)
        {
            colorIndex = index;
            ptPosition = pt;
        }
        public Block(int index, int x, int y)
        {
            colorIndex = index;
            ptPosition.X = x;
            ptPosition.Y = y;
        }
        //	颜色序号
        private int colorIndex;
        //	位置
        private Point ptPosition;

        //	方块大小
        private static int size = 30;
        private static int COLOR_CHANGE = 60;

        //System.Drawing.Color表示ARGB颜色从指定的8位颜色值（红色，绿色，蓝色）中创建结构
        //制定的默认alpha 默认为255 意为完全不透明
        private static Color[] clrDefine
            = new Color[] {
					Color.FromArgb(51, 204, 102),		// 绿	Default color, or extend block color
					Color.FromArgb(200, 200, 102),		// 黄
					Color.FromArgb(0, 143, 224),		// 蓝
					Color.FromArgb(153, 153, 204),		// 青
					Color.FromArgb(204, 204, 204),		// 灰
					Color.FromArgb(232, 123,  20),		// 橙
					Color.FromArgb(220,  39,  75)	 	// 红	sample block color
			};	//	颜色

        public int ColorIndex
        {
            get
            {
                return colorIndex;
            }
            set
            {
                colorIndex = value;
            }
        }

        /// <summary>
        /// 位置的set和get方法
        /// </summary>
        public Point Position
        {
            get
            {
                return ptPosition;
            }
            set
            {
                ptPosition = value;
            }
        }

        /// <summary>
        /// 验证是否要绘图 如果clear为真 则要清除产生的块 因为方块产生了
        /// 并且移动 必须把移动前一秒的块描成白色
        /// </summary>
        /// <param name="g"></param>
        /// <param name="ptStart"></param>
        /// <param name="clear"></param>
        public void Draw(Graphics g, Point ptStart, bool clear)
        {
            if (clear)
            {
                g.FillRectangle(new SolidBrush(Color.White), ptStart.X + (ptPosition.X * size),
                    ptStart.Y + (ptPosition.Y * size), size, size);
            }
            else
            {
                g.FillRectangle(new SolidBrush(clrDefine[colorIndex]), ptStart.X + (ptPosition.X * size), ptStart.Y + (ptPosition.Y * size), size, size);
                //绘制四条边 两条亮色的边 两条暗色的边 使块的形状更加突出
                g.DrawLine(new Pen(GetLightColor(colorIndex), 1), ptStart.X + (ptPosition.X * size), ptStart.Y + (ptPosition.Y * size), ptStart.X + (ptPosition.X * size) + size - 1, ptStart.Y + (ptPosition.Y * size));
                g.DrawLine(new Pen(GetLightColor(colorIndex), 1), ptStart.X + (ptPosition.X * size), ptStart.Y + (ptPosition.Y * size), ptStart.X + (ptPosition.X * size), ptStart.Y + (ptPosition.Y * size) + size - 1);
                g.DrawLine(new Pen(GetDarkColor(colorIndex), 1), ptStart.X + (ptPosition.X * size) + size - 1, ptStart.Y + (ptPosition.Y * size) + size - 1, ptStart.X + (ptPosition.X * size) + size - 1, ptStart.Y + (ptPosition.Y * size));
                g.DrawLine(new Pen(GetDarkColor(colorIndex), 1), ptStart.X + (ptPosition.X * size) + size - 1, ptStart.Y + (ptPosition.Y * size) + size - 1, ptStart.X + (ptPosition.X * size), ptStart.Y + (ptPosition.Y * size) + size - 1);

            }
            int cellSize = 30;
            int xCellCnt = 10;
            int yCellCnt = 20;
            Pen p = new Pen(Color.FromArgb(200,200,200), 1);
            for (int y = 0; y < yCellCnt; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, xCellCnt * cellSize, y * cellSize);
            }

            for (int x = 0; x < xCellCnt; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, yCellCnt * cellSize);
            }
        }

        public void Draw(Graphics g)
        {
            Draw(g, new Point(0, 0), false);
        }

        public static int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        public static Color GetColor(int index)
        {
            return clrDefine[index];
        }

        // GetDarkColor和GetLightColor的作用是添加亮边和暗边
        // 使产生的模块具有立体感
        Color GetDarkColor(int index)
        {
            int r = clrDefine[index].R;
            int g = clrDefine[index].G;
            int b = clrDefine[index].B;

            //将改变后的颜色alpha值与0做个比较 不能低于0 否则将超出界限
            //如果小于0 则选0 否则选r-COLOR_CHANGE
            r = r - COLOR_CHANGE < 0 ? 0 : r - COLOR_CHANGE;
            g = g - COLOR_CHANGE < 0 ? 0 : g - COLOR_CHANGE;
            b = b - COLOR_CHANGE < 0 ? 0 : b - COLOR_CHANGE;

            Color c = Color.FromArgb(r, g, b);
            return c;
        }

        Color GetLightColor(int index)
        {
            int r = clrDefine[index].R;
            int g = clrDefine[index].G;
            int b = clrDefine[index].B;

            //将改变后的颜色alpha值与255做个比较 不能高于255 否则将超出界限
            //如果大于255 则选255 否则选r+COLOR_CHANGE
            r = r + COLOR_CHANGE > 255 ? 255 : r + COLOR_CHANGE;
            g = g + COLOR_CHANGE > 255 ? 255 : g + COLOR_CHANGE;
            b = b + COLOR_CHANGE > 255 ? 255 : b + COLOR_CHANGE;

            Color c = Color.FromArgb(r, g, b);
            return c;
        }
    }
}
