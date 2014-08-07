using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace Tetris
{
    class InfoArr
    {
        private ArrayList info = new ArrayList();
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
                return (BlockInfo)info[index];
            }
        }
        public string this[string id]
        {
            set
            {
                if (value == "")
                {
                    return;
                }
                for (int i = 0; i < info.Count; i++)
                {
                    if(((BlockInfo)info[i]).GetIdStr() == id)
                    {
                        try
                        {
                            
                            ((BlockInfo)info[i]).BColor = Color.FromArgb(Convert.ToInt32(value));
                            
                        }
                        catch(System.FormatException)
                        {
                            MessageBox.Show("颜色信息错误！请删除BlockSet.xml文件，并重新启动程序1","错误信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private BitArray StrToBit(string id)
        {
            if (id.Length != 25)
            {
                throw new System.FormatException("砖块样式信息不合法！请删除BlockSet.xml文件，并重新启动程序2");
            }
            BitArray ba = new BitArray(25);
            for (int i = 0; i < 25; i++)
            {
                ba[i] = (id[i] == '0') ? false : true;
            }
            return ba;
        }
        public void Add(BitArray id, Color bColor)
        {
            if (id.Length != 25)
            {
                throw new System.FormatException("砖块样式信息不合法！请删除BlockSet.xml文件，并重新启动程序3");
            }
            info.Add(new BlockInfo(id, bColor));
            _length++;
        }
        public void Add(string id, string bColor)
        {
            Color temp;
            if (!(bColor == ""))
            {
                temp = Color.FromArgb(Convert.ToInt32(bColor));
            }
            else
            {
                temp = Color.Empty;
            }
            info.Add(new BlockInfo(StrToBit(id), temp));
            _length++;
        }
    }
}
