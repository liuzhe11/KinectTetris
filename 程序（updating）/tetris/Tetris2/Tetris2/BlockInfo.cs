using System;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Tetris2
{
    class BlockInfo
    {
        private BitArray _id;   //用0-1字任串表示砖块样式
        private Color _bcolor=Color.Red;  //砖块的颜色

        public BlockInfo(BitArray id, Color bcolor)  //构造函数
        {
            _id = id;
            _bcolor = bcolor;
        }
        #region 私有成员变量相应的属性
        public BitArray ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public Color BlockColor
        {
            get
            {
                return _bcolor;
            }
            set
            {
                _bcolor = value;
            }
        }
        #endregion

        //获得砖块的字符串形式
        public string GetIdStr()
        {
            StringBuilder sb = new StringBuilder();
            foreach (bool b in _id)
            {
                sb.Append(b ? "1" : "0");
            }
            return sb.ToString();
        }

        //获取砖块颜色字符串
        public string GetColorStr()
        {
            return _bcolor.ToArgb().ToString();
        }

        //在指定画板上绘制砖块
        public void PaintBlock(Graphics gp)
        {

        }
    }
}
