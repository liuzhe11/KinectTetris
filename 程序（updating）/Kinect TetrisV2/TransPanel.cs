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
<<<<<<< HEAD

    /// <summary>
    /// Width of output drawing
    /// </summary>
    private const float RenderWidth = 640.0f;
    public KinectSensor kinect = null;//Point to Kinect object

    /// <summary>
    /// Height of our output drawing
    /// </summary>
    private const float RenderHeight = 480.0f;

    /// <summary>
    /// Thickness of drawn joint lines
    /// </summary>
    private const double JointThickness = 3;

    /// <summary>
    /// Thickness of body center ellipse
    /// </summary>
    private const double BodyCenterThickness = 10;

    /// <summary>
    /// Thickness of clip edge rectangles
    /// </summary>
    private const double ClipBoundsThickness = 10;

    /// <summary>
    /// Brush used to draw skeleton center point
    /// </summary>
    private readonly Brush centerPointBrush = Brushes.Blue;

    /// <summary>
    /// Brush used for drawing joints that are currently tracked
    /// </summary>
    private readonly Brush trackedJointBrush = Brushes.Orange;

    /// <summary>
    /// Brush used for drawing joints that are currently inferred
    /// </summary>
    private readonly Brush inferredJointBrush = Brushes.Yellow;

    /// <summary>
    /// Pen used for drawing bones that are currently tracked
    /// </summary>
    private readonly Pen trackedBonePen = new Pen(Brushes.Green, 6);

    /// <summary>
    /// Pen used for drawing bones that are currently inferred
    /// </summary>
    private readonly Pen inferredBonePen = new Pen(Brushes.Gray, 1);

    private Point SkeletonPointToScreen(SkeletonPoint skelpoint)
    {
        // Convert point to depth space.
        // We are not using depth directly, but we do want the points in our 640x480 output resolution.
        DepthImagePoint depthPoint = this.kinect.CoordinateMapper.MapSkeletonPointToDepthPoint(skelpoint, DepthImageFormat.Resolution640x480Fps30);
        return new Point(depthPoint.X/3 - 30, depthPoint.Y/3 - 20);
    }

=======
>>>>>>> origin/master
    private Skeleton skeleton;
    public TransPanel()
    {
      //
      // TODO: Add constructor logic here
      //
    }

    public void SetSkeleton(Skeleton newSkeleton) {
      this.skeleton = newSkeleton;
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
      if (this.skeleton != null) {
        Form form1 = this.FindForm();
        form1.DrawBonesAndJoints(this.skeleton, e.Graphics);
      }
    }



  }
}
