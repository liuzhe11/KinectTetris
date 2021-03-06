using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Kinect_TetrisV2
{
  /// <summary>
  /// Summary description for TransPanel.
  /// </summary>
  public delegate void DrawEventHandler(Graphics g);
  public class DrawablePanel : Panel
  {
    public event DrawEventHandler DrawFunc;
    public DrawablePanel()
    {
        // Set the value of the double-buffering style bits to true.
        //this.DoubleBuffered = true;
        //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                    //SetStyle(ControlStyles.Opaque, true);
        //this.BackColor = Color.Transparent;
      //
      // TODO: Add constructor logic here
      //
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      if (DrawFunc != null) {
        DrawFunc(e.Graphics);
      }
    }
  }
}
