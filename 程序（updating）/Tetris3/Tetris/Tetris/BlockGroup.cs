using System;
using System.Collections;
using System.Drawing;

namespace Tetris
{
    class BlockGroup
    {
        private InfoArr info;
        private Color disapperColor;
        private int rectPix;
        public BlockGroup()
        {
            Config config = new Config();
            config.LoadFromXmlFile();
            info = new InfoArr();
            info = config.Info;
            disapperColor = config.BackColor;
            rectPix = config.RectPix;
        }
        public Block GetABlock()
        {
            Random rd = new Random();
            int keyOrder = rd.Next(0, info.Length);
            BitArray ba = info[keyOrder].ID;
            int struNum = 0;
            foreach (bool b in ba)
            {
                if (b)
                {
                    struNum++;
                }
            }
            Point[] structArr = new Point[struNum];
            int k = 0;
            for (int j = 0; j < ba.Length; j++)
            {
                if (ba[j])
                {
                    structArr[k].X = j / 5 - 2;
                    structArr[k].Y = 2 - j % 5;
                    k++;
                }
            }
            return new Block(structArr, info[keyOrder].BColor, disapperColor, rectPix);
        }
    }
}
