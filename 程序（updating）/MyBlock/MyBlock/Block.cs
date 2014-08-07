using System;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;

namespace MyBlock
{
    class Block
    {
        private Color disapperColor;//背景色
        private int rectPix;//单元格像素

        Block block;
        bool[,] boxes = new bool[4,4];
        List<bool> intcount = new List<bool>();
        public int[,] STYLES = {// 共28种状态
		    {0x0f00, 0x4444, 0x0f00, 0x4444}, // 长条型的四种状态
		    {0x4e00, 0x4640, 0x0e40, 0x4c40}, // 'T'型的四种状态
		    {0x4620, 0x6c00, 0x4620, 0x6c00}, // 反'Z'型的四种状态
		    {0x2640, 0xc600, 0x2640, 0xc600}, // 'Z'型的四种状态
		    {0x6220, 0x1700, 0x2230, 0x0740}, // '7'型的四种状态
		    {0x0e80, 0x4460, 0x2e00, 0xc440}, // 反'7'型的四种状态
		    {0x0660, 0x0660, 0x0660, 0x0660}, // 方块的四种状态
	    };
        public Block()
        {
            disapperColor = Color.Black;
            rectPix = 20;
        }
        public Block(int style)//构造函数,给成员变量赋值
        {


            int key = 0x8000;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    bool isColor = ((style & key) != 0);
                    boxes[i,j] = isColor;
                    key >>= 1;
                }
            }
        }
        public Box GetABlock()//从砖块组中随机抽取一个砖块样式并返回
        {
            Random rd = new Random();   //声明一个产生随机数的类
            int keyOrder1 = rd.Next(0, STYLES.GetLength(0));//产生一个随机数,
            int keyOrder2 = rd.Next(0, STYLES.GetLength(1));//产生一个随机数,
            block = new Block(STYLES[keyOrder1, keyOrder2]);
           


            int struNum = 0;        //确定这个砖块样式中被填充方块的个数
            foreach (bool b in block.boxes)//即需要确定Point数组的长度
            {
                if (b)
                {
                    struNum++;
                }
            }       //因为c#不允许动态改变数组长度,所以用之前先得到数组长度,然后再赋值;


            Point[] structArr = new Point[struNum]; //新建一个Point数组,并确定其长度,以创建新的Block
            int k = 0;
            bool[] ba = new bool[block.boxes.Length];
            for (int i = 0; i < 4;i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    intcount.Add(block.boxes[i,j]);
                }
            }


            intcount.CopyTo(ba);
            intcount.Clear();

            for (int j = 0; j < ba.Length; j++)//y用循环给Point 数组structArr赋坐标值
            {
                if (ba[j])
                {
                    structArr[k].X = j / 4 - 1;
                    structArr[k].Y = 1 - j % 4;
                    k++;
                }
            }
            return new Box(structArr, Color.Orange, Color.Black, rectPix);//创建一个新砖块并返回
        }
    }
}
