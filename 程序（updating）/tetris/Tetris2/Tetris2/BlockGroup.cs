using System;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Tetris2
{
    class BlockGroup
    {
        private InfoArr info = new InfoArr();
        private Color _disapperColor;
        private int _rectPix;

        public BlockGroup()
        {
            Config config = new Config();
            config.LoadFromXmlFile();
            info = config.BlockArray;
            _disapperColor = config.BackColor;
            _rectPix = config.RectPix;
        }

        //从砖块组中随机产生一个砖块
        public Block GetABlock()
        {
            Random rnd = new Random();
            int key = rnd.Next(0, info.Length);
            BlockInfo theBlock = info[key];
            BitArray ba = theBlock.ID;
            int num = 0;
            foreach (bool b in ba)
            {
                if (b)
                {
                    num++;
                }
            }
            Point[] cell = new Point[num];
            int k=0;
            for (int i = 0; i < ba.Length; i++)
            {
                if (ba[i])
                {
                    cell[k].X = i / 5 - 2;
                    cell[k].Y = 2 - i % 5;
                    k++;
                }
            }
            return new Block(cell, theBlock.BlockColor, _disapperColor, _rectPix);
        }
    }
}
