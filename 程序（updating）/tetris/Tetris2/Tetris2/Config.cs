using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.IO;
using System.Reflection;

namespace Tetris2
{
    class Config
    {
        //������Ϣ��˽�г�Ա����
        private Keys _moveLeftKey;  //���Ƽ�
        private Keys _moveRightKey; //���Ƽ�
        private Keys _dropKey;      //���¼�
        private Keys _rotateKey;    //��ת�����Σ���
        private int _horizonNum;    //ˮƽ������
        private int _verticalNum;   //��ֱ������
        private int _rectPix;       //��������
        private Color _backColor;     //����ɫ
        private InfoArr _blockArray = new InfoArr();    //ש����

        #region  ˽�г�Ա��������Ӧ����
        public Keys MoveLeftKey
        {
            get
            {
                return _moveLeftKey;
            }
            set
            {
                _moveLeftKey = value;
            }
        }
        public Keys MoveRightKey
        {
            get
            {
                return _moveRightKey;
            }
            set
            {
                _moveRightKey = value;
            }
        }
        public Keys DropKey
        {
            get
            {
                return _dropKey;
            }
            set
            {
                _dropKey = value;
            }
        }
        public Keys RotateKey
        {
            get
            {
                return _rotateKey;
            }
            set
            {
                _rotateKey = value;
            }
        }
        public int HorizonNum
        {
            get
            {
                return _horizonNum;
            }
            set
            {
                _horizonNum = value;
            }
        }
        public int VerticalNum
        {
            get
            {
                return _verticalNum;
            }
            set
            {
                _verticalNum = value;
            }
        }
        public int RectPix
        {
            get
            {
                return _rectPix;
            }
            set
            {
                _rectPix = value;
            }
        }
        public Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }
        public InfoArr BlockArray
        {
            get
            {
                return _blockArray;
            }
            set
            {
                _blockArray = value;
            }
        }
#endregion

        //��������Ϣ������xml�ļ�
        public void SaveToXmlFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<BlockSet></BlockSet>");
            XmlNode root = doc.SelectSingleNode("BlockSet");

            for (int i = 0; i < _blockArray.Length; i++)
            {
                XmlElement xelType = doc.CreateElement("Type");
                XmlElement xelID = doc.CreateElement("ID");
                xelID.InnerText = _blockArray[i].GetIdStr();
                xelType.AppendChild(xelID);

                XmlElement xelColor = doc.CreateElement("Color");
                xelColor.InnerText = _blockArray[i].GetColorStr();
                xelType.AppendChild(xelColor);

                root.AppendChild(xelType);
            }

            XmlElement xelKey = doc.CreateElement("Key");
            XmlElement xelLeftKey = doc.CreateElement("MoveLeftKey");
            xelLeftKey.InnerText = Convert.ToInt32(_moveLeftKey).ToString();
            xelKey.AppendChild(xelLeftKey);

            XmlElement xelRightKey = doc.CreateElement("MoveRightKey");
            xelRightKey.InnerText = Convert.ToInt32(_moveRightKey).ToString();
            xelKey.AppendChild(xelRightKey);

            XmlElement xelDropKey = doc.CreateElement("DropKey");
            xelDropKey.InnerText = Convert.ToInt32(_dropKey).ToString();
            xelKey.AppendChild(xelDropKey);

            XmlElement xelRotateKey = doc.CreateElement("RotateKey");
            xelRotateKey.InnerText = Convert.ToInt32(_rotateKey).ToString();
            xelKey.AppendChild(xelRotateKey);

            root.AppendChild(xelKey);

            XmlElement xelSurface = doc.CreateElement("Surface");
            XmlElement xelCoorWidth = doc.CreateElement("HorizonNum");
            xelCoorWidth.InnerText = _horizonNum.ToString();
            xelSurface.AppendChild(xelCoorWidth);

            XmlElement xelCoorHeight = doc.CreateElement("VerticalNum");
            xelCoorHeight.InnerText = _verticalNum.ToString();
            xelSurface.AppendChild(xelCoorHeight);

            XmlElement xelRectPix = doc.CreateElement("RectPix");
            xelRectPix.InnerText = _rectPix.ToString();
            xelSurface.AppendChild(xelRectPix);

            XmlElement xelBackColor = doc.CreateElement("BackColor");
            xelBackColor.InnerText = _backColor.ToArgb().ToString();
            xelSurface.AppendChild(xelBackColor);

            root.AppendChild(xelSurface);

            doc.Save("BlockSet.xml");
        }

        //��xml�ļ��ж�ȡ������Ϣ
        public void LoadFromXmlFile()
        {
            //����xml�ļ�
            XmlTextReader reader;
            if (File.Exists("BlockSet.xml"))
            {
                reader = new XmlTextReader("BlockSet.xml");
            }
            else
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                Stream sm = asm.GetManifestResourceStream("Tetris2.BlockSet.xml");
                reader = new XmlTextReader(sm);
            }

            //��ȡש�����úͲ�������
            string key = "";
            try
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "ID")
                        {
                            key = reader.ReadElementString().Trim();
                            _blockArray.Add(key,"");
                        }
                        else if (reader.Name == "Color")
                        {
                            _blockArray[key] = reader.ReadElementString().Trim();
                        }
                        else if (reader.Name == "MoveLeftKey")
                        {
                            _moveLeftKey = (Keys)int.Parse(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "MoveRightKey")
                        {
                            _moveRightKey = (Keys)int.Parse(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "DropKey")
                        {
                            _dropKey = (Keys)int.Parse(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "RotateKey")
                        {
                            _rotateKey = (Keys)int.Parse(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "HorizonNum")
                        {
                            _horizonNum = int.Parse(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "VerticalNum")
                        {
                            _verticalNum = int.Parse(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "RectPix")
                        {
                            _rectPix = int.Parse(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "BackColor")
                        {
                            _backColor = Color.FromArgb(int.Parse(reader.ReadElementString().Trim()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        //��ԭΪϵͳĬ������
        public void DefaultConfig()
        {
            if (File.Exists("BlockSet.xml"))
            {
                File.Delete("BlockSet.xml");
            }
        }
    }
}
