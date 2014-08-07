using System;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Tetris2
{
    class BlockInfo
    {
        private BitArray _id;   //��0-1���δ���ʾש����ʽ
        private Color _bcolor=Color.Red;  //ש�����ɫ

        public BlockInfo(BitArray id, Color bcolor)  //���캯��
        {
            _id = id;
            _bcolor = bcolor;
        }
        #region ˽�г�Ա������Ӧ������
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

        //���ש����ַ�����ʽ
        public string GetIdStr()
        {
            StringBuilder sb = new StringBuilder();
            foreach (bool b in _id)
            {
                sb.Append(b ? "1" : "0");
            }
            return sb.ToString();
        }

        //��ȡש����ɫ�ַ���
        public string GetColorStr()
        {
            return _bcolor.ToArgb().ToString();
        }

        //��ָ�������ϻ���ש��
        public void PaintBlock(Graphics gp)
        {

        }
    }
}
