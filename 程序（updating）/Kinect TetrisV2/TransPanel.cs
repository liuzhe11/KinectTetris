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
        DrawBonesAndJoints(this.skeleton, e.Graphics);
      }
    }

    private void DrawBonesAndJoints(Skeleton skeleton, Graphics drawingContext)
    {
        // Render Torso
        this.DrawBone(skeleton, drawingContext, JointType.Head, JointType.ShoulderCenter);
        this.DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.ShoulderLeft);
        this.DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.ShoulderRight);
        this.DrawBone(skeleton, drawingContext, JointType.ShoulderCenter, JointType.Spine);
        this.DrawBone(skeleton, drawingContext, JointType.Spine, JointType.HipCenter);
        this.DrawBone(skeleton, drawingContext, JointType.HipCenter, JointType.HipLeft);
        this.DrawBone(skeleton, drawingContext, JointType.HipCenter, JointType.HipRight);

        // Left Arm
        this.DrawBone(skeleton, drawingContext, JointType.ShoulderLeft, JointType.ElbowLeft);
        this.DrawBone(skeleton, drawingContext, JointType.ElbowLeft, JointType.WristLeft);
        this.DrawBone(skeleton, drawingContext, JointType.WristLeft, JointType.HandLeft);

        // Right Arm
        this.DrawBone(skeleton, drawingContext, JointType.ShoulderRight, JointType.ElbowRight);
        this.DrawBone(skeleton, drawingContext, JointType.ElbowRight, JointType.WristRight);
        this.DrawBone(skeleton, drawingContext, JointType.WristRight, JointType.HandRight);

        // Left Leg
        this.DrawBone(skeleton, drawingContext, JointType.HipLeft, JointType.KneeLeft);
        this.DrawBone(skeleton, drawingContext, JointType.KneeLeft, JointType.AnkleLeft);
        this.DrawBone(skeleton, drawingContext, JointType.AnkleLeft, JointType.FootLeft);

        // Right Leg
        this.DrawBone(skeleton, drawingContext, JointType.HipRight, JointType.KneeRight);
        this.DrawBone(skeleton, drawingContext, JointType.KneeRight, JointType.AnkleRight);
        this.DrawBone(skeleton, drawingContext, JointType.AnkleRight, JointType.FootRight);

        // Render Joints
        foreach (Joint joint in skeleton.Joints)
        {
            Brush drawBrush = null;

            if (joint.TrackingState == JointTrackingState.Tracked)
            {
                drawBrush = this.trackedJointBrush;
            }
            else if (joint.TrackingState == JointTrackingState.Inferred)
            {
                drawBrush = this.inferredJointBrush;
            }

            if (drawBrush != null)
            {
                Pen jointPen = new Pen(Color.Cyan);
                drawingContext.DrawEllipse(jointPen, this.SkeletonPointToScreen(joint.Position).X, this.SkeletonPointToScreen(joint.Position).Y, (int)JointThickness, (int)JointThickness);
            }
        }
    }

    private void DrawBone(Skeleton skeleton, Graphics drawingContext, JointType jointType0, JointType jointType1)
    {
        Joint joint0 = skeleton.Joints[jointType0];
        Joint joint1 = skeleton.Joints[jointType1];

        // If we can't find either of these joints, exit
        if (joint0.TrackingState == JointTrackingState.NotTracked ||
            joint1.TrackingState == JointTrackingState.NotTracked)
        {
            return;
        }

        // Don't draw if both points are inferred
        if (joint0.TrackingState == JointTrackingState.Inferred &&
            joint1.TrackingState == JointTrackingState.Inferred)
        {
            return;
        }

        // We assume all drawn bones are inferred unless BOTH joints are tracked
        Pen drawPen = this.inferredBonePen;
        if (joint0.TrackingState == JointTrackingState.Tracked && joint1.TrackingState == JointTrackingState.Tracked)
        {
            drawPen = this.trackedBonePen;
        }

        drawingContext.DrawLine(drawPen, this.SkeletonPointToScreen(joint0.Position), this.SkeletonPointToScreen(joint1.Position));
    }

  }
}
