using System;
using System.Collections;
using System.Drawing;
using System.Text;

namespace Tetris
{
    class BlockInfo
    {
        private BitArray _id;
        private Color _bColor;
        public BlockInfo(BitArray id, Color bColor)
        {
            _id = id;
            _bColor = bColor;
        }
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
        public Color BColor
        {
            get
            {
                return _bColor;
            }
            set
            {
                _bColor = value;
            }
        }

        public string GetIdStr()
        {
            StringBuilder s = new StringBuilder(25);
            foreach (bool b in _id)
            {
                s.Append(b ? "1" : "0");
            }
            return s.ToString();
        }

        public string GetColorStr()
        {
            return Convert.ToString(_bColor.ToArgb());
        }
    }
}
