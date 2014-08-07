using System;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Tetris2
{
    class InfoArr
    {
        private ArrayList _info = new ArrayList();
        private int _length = 0;

        public int Length
        {
            get
            {
                return _length;
            }
        }

        public BlockInfo this[int index]
        {
            get
            {
                return (BlockInfo)_info[index];
            }
        }

        public string this[string id]
        {
            set
            {
                for (int i = 0; i < _info.Count; i++)
                {
                    if (((BlockInfo)_info[i]).GetIdStr() == id)
                    {
                        ((BlockInfo)_info[i]).BlockColor = Color.FromArgb(int.Parse(value));
                    }
                }
            }
        }

        //将指定砖块样式添加到ArrayList中
        public void Add(BitArray id,Color bcolor)
        {
            _info.Add(new BlockInfo(id, bcolor));
            _length++;
        }
        public void Add(string id,string bcolor)
        {
            Color temp = Color.Empty;
            if (bcolor != "")
            {
                temp =Color.FromArgb(int.Parse(bcolor));
            }
            _info.Add(new BlockInfo(StrToBit(id), temp));
            _length++;
        }

        //辅助函数，将固定格式的string类型字符串转换为BitArray类型
        private BitArray StrToBit(string id)
        {
            BitArray ba = new BitArray(25);
            for (int i = 0; i < id.Length; i++)
            {
                ba[i] = (id[i] == '1') ? true : false;
            }
            return ba;
        }
    }
}
