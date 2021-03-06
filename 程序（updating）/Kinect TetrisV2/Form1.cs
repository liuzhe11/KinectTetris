﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using Kinect_TetrisV2;
using Microsoft.Kinect;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace Kinect_TetrisV2
{
    public partial class Form1 : Form
    {
        private Random rndShape = new Random();//define a new random number
        private Shape nextShape;//next shape appear
        private Body mainBody = new Body();
        private GAME_STATUS gameStatus;
        public int speed;
        private int score;
        private int lines;
        private int panelSelection;
        private KinectSensor kinect = null;//Point to Kinect object
        private Skeleton[] skeletonData;   //save the skeleton data got from Kinect Sensor
        private Pose[] poseLibrary;//user-defined pose library
        private Pose startPose;//user-defined pose
        private const int START = -1;
        private const int UP1 = 0;
        private const int UP2 = 1;
        private const int DOWN = 2;
        private const int LEFT = 3;
        private const int RIGHT = 4;
        private int count;
        private int lastPose;
        private bool startFalling;
        private const int FPS = 30;
        private const float poseThreshold = 0.5; // 1sec
        private int count2;
        private const float selThreshold = 1;
        private int lockFlag;
        private Skeleton skeleton = null;
        private Point savedPoint;

        enum GAME_STATUS { GAME_STOP, GAME_RUN, GAME_OVER };

        /// <summary>
        /// Width of output drawing
        /// </summary>
        private const float RenderWidth = 640.0f;

        /// <summary>
        /// Height of our output drawing
        /// </summary>
        private const float RenderHeight = 480.0f;

        /// <summary>
        /// Thickness of drawn joint lines
        /// </summary>
        private const double JointThickness = 8;

        /// <summary>
        /// Thickness of body center ellipse
        /// </summary>
        private const double BodyCenterThickness = 30;

        /// <summary>
        /// Thickness of clip edge rectangles
        /// </summary>
        private const double ClipBoundsThickness = 30;

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
        //private readonly Brush inferredJointBrush = Brushes.Yellow;

        /// <summary>
        /// Pen used for drawing bones that are currently tracked
        /// </summary>
        private readonly Pen trackedBonePen = new Pen(Brushes.Green, 12);

        /// <summary>
        /// Pen used for drawing bones that are currently inferred
        /// </summary>
        //private readonly Pen inferredBonePen = new Pen(Brushes.Gray, 1);

        public Form1()
        {
            InitializeComponent();

            Shape.InitTetrisDefine();
            //cite the user-define pose libarary
            PopulatePoseLibrary();
            StartKinectST();
            EnableDoubleBuffering();
            panel1.DrawFunc += new DrawHandler(this.DrawPanel1);
            screenPanel.DrawFunc += new DrawEventHandler(this.DrawScreen);
            nextPanel.DrawFunc += new DrawEventHandler(this.ReDrawNextShape);
            nextPanel2.DrawFunc += new DrawEventHandler(this.ReDrawNextShape2);
        }



        /// <summary>
        /// method to check and open Kinect Sensor
        /// </summary>
        private void StartKinectST()
        {
            //initialize Kinect
            count = 0;
            lastPose = 0;
            count2 = 0;
            lockFlag = 0;
            startFalling = false;
            savedPoint = new Point(0,0);
            // Get first Kinect Sensor
            kinect = KinectSensor.KinectSensors.FirstOrDefault(s => s.Status == KinectStatus.Connected);
            //Notice: this judgement doesn't work for MS
            if (null == kinect)
            {
                // this.ShowDialog();
            }
            try
            {
                //this.label1.Text = "The Kinect Sensor is being checked";
                // Allow tracking skeleton
                kinect.SkeletonStream.Enable();
                //Stop geting color and depth data
                kinect.ColorStream.Disable();
                kinect.DepthStream.Disable();
                skeletonData = new Skeleton[kinect.SkeletonStream.FrameSkeletonArrayLength];
                // Get Ready for Skeleton Ready Events
                kinect.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(kinect_SkeletonFrameReady);
                // Start Kinect sensor
                kinect.Start();
            }

            catch (Exception ex)
            {
                //this.label1.Text = "We cannot find any Kinect connected，Please check the USB or the power";
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private Point Point(int p1, int p2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// get data event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            try
            {

                //Tracked that defines whether a skeleton is 'tracked' or not.
                //The untracked skeletons only give their position.
                //if (SkeletonTrackingState.Tracked != data.TrackingState) continue;
                //this.label1.Text = "Kinect Sensor is successfully connected";

                using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame()) // Open the Skeleton frame
                {
                    // check that a frame is available
                    if (skeletonFrame != null && this.skeletonData != null)
                    {
                        // get the skeletal information in this frame
                        skeletonFrame.CopySkeletonDataTo(this.skeletonData);
                        this.skeleton = GetPrimarySkeleton(this.skeletonData);



                        //call the function for pose
                        if (this.skeleton != null)
                        {
                            Graphics jointg = panel1.CreateGraphics();
                            panel1.InvalidateEx();
                            this.ProcessPosePerforming(skeleton);
                            TrackHand(skeleton.Joints[JointType.HandLeft], 0);
                            TrackHand(skeleton.Joints[JointType.HandRight], 1);
                        }
                    }
                }


                foreach (Skeleton skeleton in this.skeletonData)
                {
                    if (null != skeleton)
                    {
                        if (skeleton.TrackingState == SkeletonTrackingState.Tracked)
                        {
                            //Console.WriteLine("KinectID: " + skeleton.TrackingId);
                            //only deal with the movement data
                            //DrawTrackedSkeletonJoints(skeleton.Joints);
                        }
                        else if (skeleton.TrackingState == SkeletonTrackingState.PositionOnly)
                        {

                            //temDrawSkeletonPosition(skeleton.Position);
                        }
                    }
                    else
                    {
                        Console.WriteLine("null Skeleton");
                    }
                }
            }
            catch (Exception ex)
            {
                //this.label1.Text = "We cannot find any Kinect connected，Please check the USB or the power";
            }

        }

        private void TrackHand(Joint hand, int handFlag)
        {
            // hand: 0 for left, 1 for right
            if (startFalling) return;
            if (handFlag == 0)
            {
                if (hand.TrackingState == JointTrackingState.Tracked)
                {

                    Point jointPoint = GetJointPoint(this.kinect, hand, new Point(0,0));

                    if (panelSelection == handFlag && lockFlag == 0)
                    {
                        savedPoint = new Point(jointPoint.X - nextPanel2.Location.X, jointPoint.Y - nextPanel2.Location.Y)
                        if(within(jointPoint, nextPanel2))
                        {
                            count2++;
                        }
                        else count2 = 0;
                        if(count2 > int(selThreshold*FPS))
                        {
                            lockFlag = 1;
                            count2 = 0;
                        }
                    }
                    if (panelSelection == handFlag && lockFlag == 1)
                    {
                        this.nextPanel2.Location = new Point(jointPoint.X - savedPoint.X, jointPoint.Y - savedPoint.Y);
                        if (within(jointPoint, screenPanel))
                        {
                            lockFlag = 0;
                            savedPoint = new Point(0,0);
                            startFalling = true;

                            if (GetNextShape())
                            {
                                GameOver();
                            }
                            this.nextPanel2.Location = new System.Drawing.Point(81, 32);
                        }
                    }
                }

            }
            else
            {
                if (hand.TrackingState == JointTrackingState.Tracked)
                {

                    Point jointPoint = GetJointPoint(this.kinect, hand, new Point(0,0));

                    if (panelSelection == handFlag && lockFlag == 0)
                    {
                        savedPoint = new Point(jointPoint.X - nextPanel.Location.X, jointPoint.Y - nextPanel.Location.Y)
                        if (within(jointPoint, nextPanel))
                        {
                            count2++;
                        }
                        else count2 = 0;
                        if (count2 > int(selThreshold * FPS))
                        {
                            lockFlag = 1;
                            count2 = 0;
                        }
                    }
                    if (panelSelection == handFlag && lockFlag == 1)
                    {
                        this.nextPanel.Location = new Point(jointPoint.X - savedPoint.X, jointPoint.Y - savedPoint.Y);
                        if (within(jointPoint, screenPanel))
                        {
                            lockFlag = 0;
                            savedPoint = new Point(0,0);
                            startFalling = true;

                            if (GetNextShape())
                            {
                                GameOver();
                            }
                            this.nextPanel.Location = new System.Drawing.Point(993, 32);
                        }
                    }
                }
            }
        }

        private bool within(Point Point, Panel Panel)
        {
            if (Point.X > Panel.Location.X &&
               Point.X < Panel.Location.X + Panel.Width &&
               Point.Y > Panel.Location.Y &&
               Point.Y < Panel.Location.Y + Panel.Height)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// get the nearest skeleton object
        /// </summary>
        /// <param name="skeletons"></param>
        /// <returns></returns>
        private static Skeleton GetPrimarySkeleton(Skeleton[] skeletons)
        {
            Skeleton skeleton = null;

            if (skeletons != null)
            {
                //Find the closest skeleton
                for (int i = 0; i < skeletons.Length; i++)
                {
                    if (skeletons[i].TrackingState == SkeletonTrackingState.Tracked)
                    {
                        if (skeleton == null)
                        {
                            skeleton = skeletons[i];
                        }
                        else
                        {
                            if (skeleton.Position.Z > skeletons[i].Position.Z)
                            {
                                skeleton = skeletons[i];
                            }
                        }
                    }
                }
            }

            return skeleton;
        }

        /// <summary>
        /// Method of getting coordinate of every dot in the main UI space
        /// </summary>
        /// <param name="kinectDevice"></param>
        /// <param name="joint"></param>
        /// <param name="containerSize"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private Point GetJointPoint(KinectSensor kinectDevice, Joint joint, Point offset)
        {
            //get coordinate of every dot in the main UI space
            //DepthImagePoint point = kinectDevice.MapSkeletonPointToDepth(joint.Position, kinectDevice.DepthStream.Format);
            DepthImagePoint point = kinectDevice.CoordinateMapper.MapSkeletonPointToDepthPoint(joint.Position, kinectDevice.DepthStream.Format);
            point.X = (int)((point.X - offset.X)*screenPanel.Size.Width/kinectDevice.DepthStream.FrameWidth);
            point.Y = (int)((point.Y  - offset.Y)*screenPanel.Size.Height/kinectDevice.DepthStream.FrameHeight);


            return new Point(point.X, point.Y);
        }

        /// <summary>
        /// Compute the angle between two joint
        /// </summary>
        /// <param name="centerJoint"></param>
        /// <param name="angleJoint"></param>
        /// <returns></returns>
        private double GetJointAngle(Joint centerJoint, Joint angleJoint)
        {

            Point primaryPoint = GetJointPoint(this.kinect, centerJoint, new Point());
            Point anglePoint = GetJointPoint(this.kinect, angleJoint, new Point());
            Point x = new Point(primaryPoint.X + anglePoint.X, primaryPoint.Y);

            double a;
            double b;
            double c;

            a = Math.Sqrt(Math.Pow(primaryPoint.X - anglePoint.X, 2) + Math.Pow(primaryPoint.Y - anglePoint.Y, 2));
            b = anglePoint.X;
            c = Math.Sqrt(Math.Pow(anglePoint.X - x.X, 2) + Math.Pow(anglePoint.Y - x.Y, 2));

            double angleRad = Math.Acos((a * a + b * b - c * c) / (2 * a * b));
            double angleDeg = angleRad * 180 / Math.PI;

            //if the angle is larger than 180, transfer it into (0,180)
            if (primaryPoint.Y < anglePoint.Y)
            {
                angleDeg = 360 - angleDeg;
            }

            return angleDeg;
        }

        /// <summary>
        /// user-define Pose library
        /// </summary>
        private void PopulatePoseLibrary()
        {
            this.poseLibrary = new Pose[5];

            //Game start Pose - Arms Extended
            this.startPose = new Pose();
            this.startPose.Title = "Start Pose";
            this.startPose.Angles = new PoseAngle[4];
            this.startPose.Angles[0] = new PoseAngle(JointType.ShoulderLeft, JointType.ElbowLeft, 180, 10);
            this.startPose.Angles[1] = new PoseAngle(JointType.ElbowLeft, JointType.WristLeft, 180, 10);
            this.startPose.Angles[2] = new PoseAngle(JointType.ShoulderRight, JointType.ElbowRight, 0, 10);
            this.startPose.Angles[3] = new PoseAngle(JointType.ElbowRight, JointType.WristRight, 0, 10);


            //Pose 1 - Both Hands Up
            this.poseLibrary[0] = new Pose();
            this.poseLibrary[0].Title = "Arms Left - RotateLeft";
            this.poseLibrary[0].Angles = new PoseAngle[4];
            this.poseLibrary[0].Angles[0] = new PoseAngle(JointType.ShoulderLeft, JointType.ElbowLeft, 180, 30);
            this.poseLibrary[0].Angles[1] = new PoseAngle(JointType.ElbowLeft, JointType.WristLeft, 180, 30);
            this.poseLibrary[0].Angles[2] = new PoseAngle(JointType.ShoulderRight, JointType.ElbowRight, 90, 30);
            this.poseLibrary[0].Angles[3] = new PoseAngle(JointType.ElbowRight, JointType.WristRight, 90, 30);

            this.poseLibrary[4] = new Pose();
            this.poseLibrary[4].Title = "Arms Up - RotateRight";
            this.poseLibrary[4].Angles = new PoseAngle[4];
            this.poseLibrary[4].Angles[0] = new PoseAngle(JointType.ShoulderLeft, JointType.ElbowLeft, 90, 30);
            this.poseLibrary[4].Angles[1] = new PoseAngle(JointType.ElbowLeft, JointType.WristLeft, 90, 30);
            this.poseLibrary[4].Angles[2] = new PoseAngle(JointType.ShoulderRight, JointType.ElbowRight, 0, 30);
            this.poseLibrary[4].Angles[3] = new PoseAngle(JointType.ElbowRight, JointType.WristRight, 0, 30);

            //Pose 2 - Both Hands Cross
            this.poseLibrary[1] = new Pose();
            this.poseLibrary[1].Title = "把手交叉（Hands Cross）";
            this.poseLibrary[1].Angles = new PoseAngle[4];
            this.poseLibrary[1].Angles[0] = new PoseAngle(JointType.ShoulderLeft, JointType.ElbowLeft, 245, 8);
            this.poseLibrary[1].Angles[1] = new PoseAngle(JointType.ElbowLeft, JointType.WristLeft, 0, 8);
            this.poseLibrary[1].Angles[2] = new PoseAngle(JointType.ShoulderRight, JointType.ElbowRight, 285, 8);
            this.poseLibrary[1].Angles[3] = new PoseAngle(JointType.ElbowRight, JointType.WristRight, 180, 8);

            //Pose 3 - Left Up and Right Down
            this.poseLibrary[2] = new Pose();
            this.poseLibrary[2].Title = "Left Up and Right Down";
            this.poseLibrary[2].Angles = new PoseAngle[4];
            this.poseLibrary[2].Angles[0] = new PoseAngle(JointType.ShoulderLeft, JointType.ElbowLeft, 180, 30);
            this.poseLibrary[2].Angles[1] = new PoseAngle(JointType.ElbowLeft, JointType.WristLeft, 180, 30);
            this.poseLibrary[2].Angles[2] = new PoseAngle(JointType.ShoulderRight, JointType.ElbowRight, 270, 30);
            this.poseLibrary[2].Angles[3] = new PoseAngle(JointType.ElbowRight, JointType.WristRight, 270, 30);


            //Pose 4 - Right Up and Left Down
            this.poseLibrary[3] = new Pose();
            this.poseLibrary[3].Title = "（举起右手）Right Up and Left Down";
            this.poseLibrary[3].Angles = new PoseAngle[4];
            this.poseLibrary[3].Angles[0] = new PoseAngle(JointType.ShoulderLeft, JointType.ElbowLeft, 270, 30);
            this.poseLibrary[3].Angles[1] = new PoseAngle(JointType.ElbowLeft, JointType.WristLeft, 270, 30);
            this.poseLibrary[3].Angles[2] = new PoseAngle(JointType.ShoulderRight, JointType.ElbowRight, 0, 30);
            this.poseLibrary[3].Angles[3] = new PoseAngle(JointType.ElbowRight, JointType.WristRight, 0, 30);
        }

        /// <summary>
        /// Judge whether same with the defined pose
        /// </summary>
        /// <param name="skeleton"></param>
        /// <param name="pose"></param>
        /// <returns></returns>
        private bool IsPose(Skeleton skeleton, Pose pose)
        {
            bool isPose = true;
            double angle;
            double poseAngle;
            double poseThreshold;
            double loAngle;
            double hiAngle;

            //Check all the pose angle of a pose, judge whether right or not
            for (int i = 0; i < pose.Angles.Length && isPose; i++)
            {
                poseAngle = pose.Angles[i].Angle;
                poseThreshold = pose.Angles[i].Threshold;
                //callthe function GetJointAngle to compute the angle between two joint
                angle = GetJointAngle(skeleton.Joints[pose.Angles[i].CenterJoint], skeleton.Joints[pose.Angles[i].AngleJoint]);

                hiAngle = poseAngle + poseThreshold;
                loAngle = poseAngle - poseThreshold;

                //judge whether the angle is within 360, if not, transfer it into (0,360)
                if (hiAngle >= 360 || loAngle < 0)
                {
                    loAngle = (loAngle < 0) ? 360 + loAngle : loAngle;
                    hiAngle = hiAngle % 360;

                    isPose = !(loAngle > angle && angle > hiAngle);
                }
                else
                {
                    isPose = (loAngle <= angle && hiAngle >= angle);
                }
            }
            //if consistent, return true
            return isPose;
        }

        /// <summary>
        ///  deal with user pose
        /// </summary>
        /// <param name="skeleton"></param>
        private void ProcessPosePerforming(Skeleton skeleton)
        {
            bool ret;
            Graphics grMain = screenPanel.CreateGraphics();
            int value = 10;
            if (IsPose(skeleton, this.poseLibrary[0]))
            {
                Console.WriteLine("Two hands right");
                value = UP1;
            }
            if (IsPose(skeleton, this.poseLibrary[4]))
            {
                Console.WriteLine("Two hands left");
                value = UP2;
            }
            else if (IsPose(skeleton, this.poseLibrary[1]))
            {
                Console.WriteLine("Two hands cross, right");//	fall down
                value = DOWN;
            }
            else if (IsPose(skeleton, this.poseLibrary[2]))
            {
                Console.WriteLine("Left hand up, right");//	left
                value = LEFT;
            }
            else if (IsPose(skeleton, this.poseLibrary[3]))
            {
                Console.WriteLine("Right hand up, right");	//	right
                value = RIGHT;
            }
            if (value == lastPose && count < int(poseThreshold * FPS))
            {
                count++;
            }
            else if (value != lastPose)
            {
                count = 0;
                lastPose = value;
            }
            else
            {
                count = 0;
                switch (value)
                {
                    case UP1:
                        ret = mainBody.MoveShape(grMain, Body.MOVE_TYPE.MOVE_ROTATELEFT);
                        break;
                    case UP2:
                        ret = mainBody.MoveShape(grMain, Body.MOVE_TYPE.MOVE_ROTATERIGHT);
                        break;
                    case LEFT:	//	left
                        ret = mainBody.MoveShape(grMain, Body.MOVE_TYPE.MOVE_LEFT);
                        break;
                    case RIGHT:	//	right
                        ret = mainBody.MoveShape(grMain, Body.MOVE_TYPE.MOVE_RIGHT);
                        break;
                    case DOWN:	//	fall down
                        ret = mainBody.MoveShape(grMain, Body.MOVE_TYPE.MOVE_FALL);
                        break;
                    default:
                        ret = false;
                        break;
                }
                if (ret && value == DOWN)
                {
                    DisposeShapeDown();
                }
            }
        }
        private void DrawPanel1(Graphics drawingContext)
        {
            if (skeleton != null)
            {
                DrawBonesAndJoints(drawingContext);
            }
        }
        /// <summary>
        /// Draws a skeleton's bones and joints
        /// </summary>
        /// <param name="skeleton">skeleton to draw</param>
        /// <param name="drawingContext">drawing context to draw to</param>
        private void DrawBonesAndJoints(Graphics drawingContext)
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
                    drawBrush = this.trackedJointBrush;
                }

                if (drawBrush != null)
                {
                    Brush jointbrush = new SolidBrush(Color.Green);
                    if (joint.JointType == JointType.Head)
                    {
                        drawingContext.FillEllipse(jointbrush, this.SkeletonPointToScreen(joint.Position).X-45, this.SkeletonPointToScreen(joint.Position).Y-45, (int)JointThickness * 10, (int)JointThickness * 10);

                    }
                    else if(joint.JointType == JointType.HandLeft || joint.JointType == JointType.HandRight)
                    {
                        drawingContext.FillEllipse(jointbrush, this.SkeletonPointToScreen(joint.Position).X-18, this.SkeletonPointToScreen(joint.Position).Y-18, (int)JointThickness * 4, (int)JointThickness * 4);

                    }
                    else
                    {
                        drawingContext.FillEllipse(jointbrush, this.SkeletonPointToScreen(joint.Position).X-9, this.SkeletonPointToScreen(joint.Position).Y-9, (int)JointThickness*2, (int)JointThickness*2);

                    }
                }
            }
        }

        /// <summary>
        /// Maps a SkeletonPoint to lie within our render space and converts to Point
        /// </summary>
        /// <param name="skelpoint">point to map</param>
        /// <returns>mapped point</returns>
        private Point SkeletonPointToScreen(SkeletonPoint skelpoint)
        {
            // Convert point to depth space.
            // We are not using depth directly, but we do want the points in our 640x480 output resolution.
            DepthImagePoint depthPoint = this.kinect.CoordinateMapper.MapSkeletonPointToDepthPoint(skelpoint, DepthImageFormat.Resolution640x480Fps30);
            return new Point(depthPoint.X * screenPanel.Size.Width / 640, depthPoint.Y * screenPanel.Size.Height / 480); //改大小？？
        }

        /// <summary>
        /// Draws a bone line between two joints
        /// </summary>
        /// <param name="skeleton">skeleton to draw bones from</param>
        /// <param name="drawingContext">drawing context to draw to</param>
        /// <param name="jointType0">joint to start drawing from</param>
        /// <param name="jointType1">joint to end drawing at</param>
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
            Pen drawPen = this.trackedBonePen;
            if (joint0.TrackingState == JointTrackingState.Tracked && joint1.TrackingState == JointTrackingState.Tracked)
            {
                drawPen = this.trackedBonePen;
            }

            drawingContext.DrawLine(drawPen, this.SkeletonPointToScreen(joint0.Position), this.SkeletonPointToScreen(joint1.Position)); //改大小？
        }


        /// <summary>
        /// Drawing the window
        /// </summary>
        public void DrawScreen(Graphics grMain)
        {
            //Judge the game status
            if (gameStatus == GAME_STATUS.GAME_RUN || gameStatus == GAME_STATUS.GAME_OVER)
            {
                grMain.FillRectangle(new SolidBrush(Color.White), 0, 0, screenPanel.Width, screenPanel.Height);
                mainBody.Draw(grMain, startFalling);
            }
            if (gameStatus == GAME_STATUS.GAME_STOP || gameStatus == GAME_STATUS.GAME_OVER)
            {
                string logo = "Kinect Tetris";

                DrawText(logo, grMain, new Point(10, (int)(screenPanel.Height * 0.28)), 20);
            }
            if (gameStatus == GAME_STATUS.GAME_OVER)
            {
                string logo = "Game over";

                DrawText(logo, grMain, new Point(20, (int)(screenPanel.Height * 0.42)), 15);
            }
        }

        /// <summary>
        /// Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimer(object sender, System.EventArgs e)
        {
            if (gameStatus == GAME_STATUS.GAME_RUN && startFalling)
            {
                Graphics grMain = screenPanel.CreateGraphics();
                if (mainBody.MoveShape(grMain, Body.MOVE_TYPE.MOVE_DOWN))
                {
                    DisposeShapeDown();
                }
            }
        }

        /// <summary>
        /// Timer start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startMenu_Click(object sender, System.EventArgs e)
        {
            StartGame();
        }

        /// <summary>
        /// Timer stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopMenu_Click(object sender, System.EventArgs e)
        {
            GameOver();
        }

        /// <summary>
        /// Log out and close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitMenu_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Game start
        /// </summary>
        public void StartGame()
        {

            comboBox1.Enabled = false;
            score = 0;
            speed = 0;
            lines = 0;

            ChangeLines(0);
            timer.Interval = SpeedToTime(speed);
            timer.Enabled = true;
            startMenu.Enabled = false;
            stopMenu.Enabled = true;
            gameStatus = GAME_STATUS.GAME_RUN;
            mainBody.Reset();
            int indexShape = rndShape.Next(7);
            nextShape = new Shape(indexShape);
            ReDraw();
        }

        /// <summary>
        /// Get the new shape
        /// </summary>
        /// <returns></returns>
        public bool GetNextShape()
        {
            return GetNextShape(false);
        }


        /// <summary>
        /// Add keyboard monitor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            var key = e.KeyCode;
            bool ret;
            Graphics grMain = screenPanel.CreateGraphics();
            if (gameStatus == GAME_STATUS.GAME_RUN)
            {
                switch (key)
                {
                    case Keys.Q:
                    case Keys.PageUp:
                        ret = mainBody.MoveShape(grMain, Body.MOVE_TYPE.MOVE_ROTATELEFT);
                        break;
                    case Keys.E:
                    case Keys.PageDown:
                        ret = mainBody.MoveShape(grMain, Body.MOVE_TYPE.MOVE_ROTATERIGHT);
                        break;
                    case Keys.Left:
                        ret = mainBody.MoveShape(grMain, Body.MOVE_TYPE.MOVE_LEFT);
                        break;
                    case Keys.Right:
                        ret = mainBody.MoveShape(grMain, Body.MOVE_TYPE.MOVE_RIGHT);
                        break;
                    case Keys.Down:
                        ret = mainBody.MoveShape(grMain, Body.MOVE_TYPE.MOVE_FALL);
                        break;
                    case Keys.Tab:
                        if (!startFalling)
                        {
                            startFalling = true;
                            if (GetNextShape())
                            {
                                GameOver();
                            }
                        }
                        ret = false;
                        break;

                    default:
                        ret = false;
                        break;
                }
                if (ret && key == Keys.Down)
                {
                    DisposeShapeDown();
                }
            }
        }

        /// <summary>
        /// Get next shape
        /// </summary>
        /// <param name="initGame"></param>
        /// <returns></returns>
        public bool GetNextShape(bool initGame)
        {
            int shapeCount = 7;
            panelSelection = rndShape.Next(2);
            bool ret = mainBody.SetCurrentShape(nextShape);
            int indNextShape = rndShape.Next(shapeCount);
            nextShape = new Shape(indNextShape);
            return ret;
        }

        /// <summary>
        /// Shape fall down
        /// </summary>
        public void DisposeShapeDown()
        {
            int count = mainBody.ClearLines();
            startFalling = false;

            if (count > 0)
            {
                ChangeLines(count);
                ReDraw();
            }
            else
            {
                nextPanel.Refresh();
                nextPanel2.Refresh();
            }
        }

        /// <summary>
        /// Re-draw the falling Interface
        /// </summary>
        public void ReDrawNextShape(Graphics grNext)
        {
            if (panelSelection == 1 && nextShape != null)
            {
                nextShape.Draw(grNext, nextPanel.Size);
            }
        }

        public void ReDrawNextShape2(Graphics grNext2)
        {
            if (panelSelection != 1 && nextShape != null)
            {
                nextShape.Draw(grNext2, nextPanel2.Size);
            }
        }

        /// <summary>
        /// Game Over
        /// </summary>
        public void GameOver()
        {
            gameStatus = GAME_STATUS.GAME_OVER;
            timer.Enabled = false;
            startMenu.Enabled = true;
            stopMenu.Enabled = false;
            comboBox1.Enabled = true;
            ReDraw();
        }

        /// <summary>
        /// Write in the window
        /// </summary>
        /// <param name="text"></param>
        /// <param name="g"></param>
        /// <param name="pt"></param>
        /// <param name="font"></param>
        public void DrawText(string text, Graphics g, Point pt, int font)
        {
            Font drawFont = new Font("Courier new", font, FontStyle.Bold);

            for (int i = 0; i < text.Length; i++)
            {
                int corIndex = i;
                if (i >= 7)
                    corIndex = i % 7;
                SolidBrush drawBrush = new SolidBrush(Block.GetColor(corIndex));
                string drawText = new String(' ', i);
                drawText += text.Substring(i, 1);
                g.DrawString(drawText, drawFont, drawBrush, pt);
            }
        }

        public void ChangeLines(int count)
        {
            switch (count)
            {
                case 1:
                    score += 100;
                    break;
                case 2:
                    score += 300;
                    break;
                case 3:
                    score += 500;
                    break;
                case 4:
                    score += 1000;
                    break;
                default:
                    break;
            }
            //if ((lines+count) / 3 > lines / 3)
            //{
            lines += count;
            speed = Convert.ToInt32(comboBox1.Text);
            //speed++;
            timer.Interval = SpeedToTime(speed);
            //}

            scoreLabel.Text = score.ToString();
            //speedLabel.Text = speed.ToString();
            linesLabel.Text = lines.ToString();
        }

        /// <summary>
        /// Control the speed shape fall
        /// </summary>
        /// <param name="nSpeed"></param>
        /// <returns></returns>
        public int SpeedToTime(int nSpeed)
        {
            switch (nSpeed)
            {
                case 0:
                    return (1000);
                case 1:
                    return (900);
                case 2:
                    return (800);
                case 3:
                    return (700);
                case 4:
                    return (600);
                case 5:
                    return (500);
                case 6:
                    return (400);
                case 7:
                    return (300);
                case 8:
                    return (200);
                case 9:
                    return (150);
                default:
                    return (150);
            }
        }

        public void EnableDoubleBuffering()
        {
           // Set the value of the double-buffering style bits to true.
           this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.ResizeRedraw |
              ControlStyles.AllPaintingInWmPaint,
              true);
           this.UpdateStyles();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //ReDraw();
            try
            {
                //pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\image\\instruction.bmp");
            }
            catch (FileNotFoundException ef)
            {
                Console.WriteLine("File Cannot Found："+ef.StackTrace);

            }
        }

        private void ReDraw()
        {
            //scoreLabel.Refresh();
            //comboBox1.Refresh();
            //linesLabel.Refresh();
            //label2.Refresh();
            //label3.Refresh();
            //label4.Refresh();
            //label8.Refresh();
            this.Refresh();
        }

    }
}
