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

        //��ָ��ש����ʽ��ӵ�ArrayList��
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

        //�������������̶���ʽ��string�����ַ���ת��ΪBitArray����
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
