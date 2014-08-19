using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Kinect;

namespace Kinect_TetrisV2
{
  /// <summary>
  /// Summary description for TransPanel.
  /// </summary>
  public class TransPanel : Panel
  {
    public TransPanel()
    {
      //
      // TODO: Add constructor logic here
      //
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams cp=base.CreateParams;
        cp.ExStyle|=0x00000020; //WS_EX_TRANSPARENT
        return cp;
      }
    }

    public void InvalidateEx()
    {
      if(Parent==null)
        return;

      Rectangle rc=new Rectangle(this.Location,this.Size);
      Parent.Invalidate(rc,true);
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
      //do not allow the background to be painted
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
    }



  }
}
