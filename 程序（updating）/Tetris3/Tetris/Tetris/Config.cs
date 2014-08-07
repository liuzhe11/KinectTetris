using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.IO;
using System.Reflection;

namespace Tetris
{
    class Config
    {
        private Keys _downKey;
        private Keys _dropKey;
        private Keys _moveLeftKey;
        private Keys _moveRightKey;
        private Keys _deasilRotateKey;
        private Keys _contraRotateKey;
        private int _coorWidth;
        private int _coorHeight;
        private int _rectPix;
        private Color _backColor;
        private InfoArr info = new InfoArr();
        #region 私有变量相应的属性
        public Keys DownKey
        {
            get
            {
                return _downKey;
            }
            set
            {
                _downKey = value;
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
        public Keys DeasilRotateKey
        {
            get
            {
                return _deasilRotateKey;
            }
            set
            {
                _deasilRotateKey = value;
            }
        }
        public Keys ContraRotateKey
        {
            get
            {
                return _contraRotateKey;
            }
            set
            {
                _contraRotateKey = value;
            }
        }
        public int CoorWidth
        {
            get
            {
                return _coorWidth;
            }
            set
            {
                if (value >= 10 && value <= 50)
                    _coorWidth = value;
            }
        }
        public int CoorHeight
        {
            get
            {
                return _coorHeight;
            }
            set
            {
                if (value >= 15 && value <= 50)
                    _coorHeight = value;
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
                if (value >= 10 && value <= 30)
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
        public InfoArr Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }
        #endregion
        public void LoadFromXmlFile()
        {
            XmlTextReader reader;
            if (File.Exists("BlockSet.xml"))
            {
                reader = new XmlTextReader("BlockSet.xml");
            }
            else
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                Stream sm = asm.GetManifestResourceStream("Tetris.BlockSet.xml");
                reader = new XmlTextReader(sm);
            }
            revertFromXmlFile(reader);
        }

        public void revertFromXmlFile(XmlTextReader reader)
        {
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
                            info.Add(key, "");
                        }
                        else if (reader.Name == "Color")
                        {
                            info[key] = reader.ReadElementString().Trim();
                        }
                        else if (reader.Name == "DownKey")
                        {
                            _downKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "DropKey")
                        {
                            _dropKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "MoveLeftKey")
                        {
                            _moveLeftKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "MoveRightKey")
                        {
                            _moveRightKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "DeasilRotateKey")
                        {
                            _deasilRotateKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "ContraRotateKey")
                        {
                            _contraRotateKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "CoorWidth")
                        {
                            _coorWidth = Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "CoorHeight")
                        {
                            _coorHeight = Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "RectPix")
                        {
                            _rectPix = Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "BackColor")
                        {
                            _backColor = Color.FromArgb(Convert.ToInt32(reader.ReadElementString().Trim()));
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

        public void SaveToXmlFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<BlockSet></BlockSet>");
            XmlNode root = doc.SelectSingleNode("BlockSet");

            for (int i = 0; i < info.Length; i++)
            {
                XmlElement xelType = doc.CreateElement("Type");
                XmlElement xelID = doc.CreateElement("ID");
                xelID.InnerText = ((BlockInfo)Info[i]).GetIdStr();
                xelType.AppendChild(xelID);
                XmlElement xelColor = doc.CreateElement("Color");
                xelColor.InnerText = ((BlockInfo)Info[i]).GetColorStr();
                xelType.AppendChild(xelColor);
                root.AppendChild(xelType);
            }

            XmlElement xelKey = doc.CreateElement("Key");

            XmlElement xelDownKey = doc.CreateElement("DownKey");
            xelDownKey.InnerText = Convert.ToInt32(_downKey).ToString();
            xelKey.AppendChild(xelDownKey);

            XmlElement xelDropKey = doc.CreateElement("DropKey");
            xelDropKey.InnerText = Convert.ToInt32(_dropKey).ToString();
            xelKey.AppendChild(xelDropKey);

            XmlElement xelMoveLeftKey = doc.CreateElement("MoveLeftKey");
            xelMoveLeftKey.InnerText = Convert.ToInt32(_moveLeftKey).ToString();
            xelKey.AppendChild(xelMoveLeftKey);

            XmlElement xelMoveRightKey = doc.CreateElement("MoveRightKey");
            xelMoveRightKey.InnerText = Convert.ToInt32(_moveRightKey).ToString();
            xelKey.AppendChild(xelMoveRightKey);

            XmlElement xelDeasilRotateKey = doc.CreateElement("DeasilRotateKey");
            xelDeasilRotateKey.InnerText = Convert.ToInt32(_deasilRotateKey).ToString();
            xelKey.AppendChild(xelDeasilRotateKey);

            XmlElement xelContraRotateKey = doc.CreateElement("ContraRotateKey");
            xelContraRotateKey.InnerText = Convert.ToInt32(_contraRotateKey).ToString();
            xelKey.AppendChild(xelContraRotateKey);

            root.AppendChild(xelKey);

            XmlElement xelSurface = doc.CreateElement("Surface");

            XmlElement xelCoorWidth = doc.CreateElement("CoorWidth");
            xelCoorWidth.InnerText = _coorWidth.ToString();
            xelSurface.AppendChild(xelCoorWidth);

            XmlElement xelCoorHeight = doc.CreateElement("CoorHeight");
            xelCoorHeight.InnerText = _coorHeight.ToString();
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
    }
}
