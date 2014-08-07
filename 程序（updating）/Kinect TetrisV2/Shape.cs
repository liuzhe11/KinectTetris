using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Kinect_TetrisV2
{
    /// <summary>
    /// 方块形状类
    /// </summary>
    public class Shape
    {
        public Shape()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public Shape(int index)
        {
            Create(index);
        }

        private Block[] blockList;
        private int indexDef;
        private Point ptPosition;
        private int blockCnt;

        private struct TETRIS
        {
            public int[,] def;
            public int size;
            public int block;
        }

        private static TETRIS[] tetrisDef;
        //设置所处位置的函数 相当于给所在坐标的位置赋值
        //tetrisDef[0].def[1,0] = 8;代表给坐标1，0处代表要填充 至于这个8则换成别的数也行
        //只要不是零均可
        public static void InitTetrisDefine()
        {
            tetrisDef = new TETRIS[7];
            /*
            for (int i=0; i<7; i++)
            {
                for (int m=0; m<4; m++)
                {
                    for (int n=0; n<4; n++)
                    {
                        tetrisDef[i].def[m,n] = 0;
                    }
                }
            }
            */
            tetrisDef[0].def = new int[2,2];
            tetrisDef[0].def[0, 0] = 1;	//	88
            tetrisDef[0].def[0, 1] = 1;	//	00
            tetrisDef[0].size = 2;
            tetrisDef[0].block = 2;

            tetrisDef[1].def = new int[3,3];
            tetrisDef[1].def[1, 0] = 8;	//	080
            tetrisDef[1].def[1, 1] = 8;	//	080
            tetrisDef[1].def[1, 2] = 8;	//	080
            tetrisDef[1].size = 3;
            tetrisDef[1].block = 3;

            tetrisDef[2].def = new int[2, 2];
            tetrisDef[2].def[0, 0] = 8;	//	80
            tetrisDef[2].def[1, 0] = 8;	//	88
            tetrisDef[2].def[1, 1] = 8;	//
            tetrisDef[2].size = 2;
            tetrisDef[2].block = 3;

            tetrisDef[3].def = new int[2, 2];
            tetrisDef[3].def[0, 0] = 8;	//	88
            tetrisDef[3].def[0, 1] = 8;	//	88
            tetrisDef[3].def[1, 0] = 8;
            tetrisDef[3].def[1, 1] = 8;
            tetrisDef[3].size = 2;
            tetrisDef[3].block = 4;

            tetrisDef[4].def = new int[3, 3];
            tetrisDef[4].def[0, 1] = 8;	//	080
            tetrisDef[4].def[1, 0] = 8;	//	888
            tetrisDef[4].def[1, 1] = 8;	//	000
            tetrisDef[4].def[1, 2] = 8;
            tetrisDef[4].size = 3;
            tetrisDef[4].block = 4;

            tetrisDef[5].def = new int[3, 3];
            tetrisDef[5].def[0, 0] = 8;	//	800
            tetrisDef[5].def[1, 0] = 8;	//	888
            tetrisDef[5].def[1, 1] = 8;	//	000
            tetrisDef[5].def[1, 2] = 8;
            tetrisDef[5].size = 3;
            tetrisDef[5].block = 4;

            tetrisDef[6].def = new int[3, 3];
            tetrisDef[6].def[0, 2] = 8;	//	008
            tetrisDef[6].def[1, 0] = 8;	//	888
            tetrisDef[6].def[1, 1] = 8;	//	000
            tetrisDef[6].def[1, 2] = 8;
            tetrisDef[6].size = 3;
            tetrisDef[6].block = 4;

        }

        //建立了一个块链表数组
        public void Create(int index)
        {
            indexDef  = index;
            blockList = new Block[tetrisDef[index].block];
            blockCnt  = tetrisDef[index].block;
            int count = 0;
            for (int i = 0; i < tetrisDef[index].size; i++)
            {
                for (int j = 0; j < tetrisDef[index].size; j++)
                {
                    if (tetrisDef[index].def[i, j] != 0)
                    {
                        blockList[count] = new Block(index, i, j);
                        count++;
                        if (count >= 4) return;
                    }
                }
            }
        }

        public void Copy(Shape s)
        {
            ptPosition = s.Position;
            for (int i = 0; i < blockList.GetLength(0); i++)
            {
                blockList[i].Position = s.GetBlock(i).Position;
            }
        }

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

        public int IndexDef
        {
            get
            {
                return indexDef;
            }
        }

        public int BlockCnt {
            get {
                return blockCnt;
            }
        }

        public void Draw(Graphics g)
        {
            Draw(g, false);
        }

        //绘制图形，先绘制图形所在坐标位置 在绘制整个图形
        public void Draw(Graphics g, Size sz)
        {
            Point pt = new Point((sz.Width - tetrisDef[indexDef].size * Block.Size) / 2,
                (sz.Height - tetrisDef[indexDef].size * Block.Size) / 2);

            for (int i = 0; i < blockList.GetLength(0); i++)
            {
                blockList[i].Draw(g, pt, false);
            }
        }

        public void Draw(Graphics g, bool clear)
        {
            for (int i = 0; i < blockList.GetLength(0); i++)
            {
                blockList[i].Draw(g, new Point(ptPosition.X * Block.Size, ptPosition.Y * Block.Size), clear);
            }
        }

        //旋转图形
        public void Rotate()
        {
            for (int i = 0; i < blockList.GetLength(0); i++)
            {
                Point pt = blockList[i].Position;
                int temp = pt.X;
                pt.X = tetrisDef[indexDef].size - pt.Y - 1;
                pt.Y = temp;
                blockList[i].Position = pt;
            }
        }

        public Block GetBlock(int index)
        {
            return blockList[index];
        }
    }
}
