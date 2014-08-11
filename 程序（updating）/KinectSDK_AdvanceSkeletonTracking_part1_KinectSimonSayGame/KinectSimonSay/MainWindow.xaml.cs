using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using System.Windows.Media.Animation;

namespace KinectSimonSay
{

    public enum GamePhase
    {
        GameOver = 0,
        SimonInstructing = 1,
        PlayerPerforming = 2
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KinectSensor kinectDevice;
        private Skeleton[] frameSkeletons;
        private GamePhase currentPhase;
        private UIElement[] instructionSequence;
        private int instructionPosition;
        private int currentLevel;
        private Random rnd = new Random();
        private IInputElement leftHandTarget;
        private IInputElement rightHandTarget;


        public KinectSensor KinectDevice
        {
            get { return this.kinectDevice; }
            set
            {
                if (this.kinectDevice != value)
                {
                    //Uninitialize
                    if (this.kinectDevice != null)
                    {
                        this.kinectDevice.Stop();
                        this.kinectDevice.SkeletonFrameReady -= KinectDevice_SkeletonFrameReady;
                        this.kinectDevice.SkeletonStream.Disable();
                        SkeletonViewerElement.KinectDevice = null;
                        this.frameSkeletons = null;
                    }

                    this.kinectDevice = value;

                    //Initialize
                    if (this.kinectDevice != null)
                    {
                        if (this.kinectDevice.Status == KinectStatus.Connected)
                        {
                            this.kinectDevice.SkeletonStream.Enable();
                            this.frameSkeletons = new Skeleton[this.kinectDevice.SkeletonStream.FrameSkeletonArrayLength];

                            this.kinectDevice.Start();

                            SkeletonViewerElement.KinectDevice = this.KinectDevice;
                            this.KinectDevice.SkeletonFrameReady += KinectDevice_SkeletonFrameReady;
                        }
                    }
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            KinectSensor.KinectSensors.StatusChanged += KinectSensors_StatusChanged;
            this.KinectDevice = KinectSensor.KinectSensors.FirstOrDefault(x => x.Status == KinectStatus.Connected);

            ChangePhase(GamePhase.GameOver);
            this.currentLevel = 0;
        }

        private void KinectSensors_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case KinectStatus.Initializing:
                case KinectStatus.Connected:
                case KinectStatus.NotPowered:
                case KinectStatus.NotReady:
                case KinectStatus.DeviceNotGenuine:
                    this.KinectDevice = e.Sensor;
                    break;
                case KinectStatus.Disconnected:
                    //TODO: Give the user feedback to plug-in a Kinect device.                    
                    this.KinectDevice = null;
                    break;
                default:
                    //TODO: Show an error state
                    break;
            }
        }

        private void KinectDevice_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame frame = e.OpenSkeletonFrame())
            {
                if (frame != null)
                {
                    frame.CopySkeletonDataTo(this.frameSkeletons);
                    Skeleton skeleton = GetPrimarySkeleton(this.frameSkeletons);

                    if (skeleton == null)
                    {
                        ChangePhase(GamePhase.GameOver);
                    }
                    else
                    {
                        if (this.currentPhase == GamePhase.SimonInstructing)
                        {
                            LeftHandElement.Visibility = Visibility.Collapsed;
                            RightHandElement.Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            TrackHand(skeleton.Joints[JointType.HandLeft], LeftHandElement, LayoutRoot);
                            TrackHand(skeleton.Joints[JointType.HandRight], RightHandElement, LayoutRoot);

                            switch (this.currentPhase)
                            {
                                case GamePhase.GameOver:
                                    ProcessGameOver(skeleton);
                                    break;

                                case GamePhase.PlayerPerforming:
                                    ProcessPlayerPerforming(skeleton);
                                    break;
                            }
                        }
                    }

                }
            }
        }

        private void TrackHand(Joint hand, FrameworkElement cursorElement, FrameworkElement container)
        {
            if (hand.TrackingState == JointTrackingState.NotTracked)
            {
                cursorElement.Visibility = Visibility.Collapsed;
            }
            else
            {
                cursorElement.Visibility = Visibility.Visible;
                Point jointPoint = GetJointPoint(this.KinectDevice, hand, container.RenderSize, new Point(cursorElement.ActualWidth / 2.0, cursorElement.ActualHeight / 2.0));
                Canvas.SetLeft(cursorElement, jointPoint.X);
                Canvas.SetTop(cursorElement, jointPoint.Y);
            }
        }

        private void ProcessGameOver(Skeleton skeleton)
        {
            //判断用户是否想开始新的游戏
            if (HitTest(skeleton.Joints[JointType.HandLeft], LeftHandStartElement) && HitTest(skeleton.Joints[JointType.HandRight], RightHandStartElement))
            {
                ChangePhase(GamePhase.SimonInstructing);
            }
        }

        private bool HitTest(Joint joint, UIElement target)
        {
            return (GetHitTarget(joint, target) != null);
        }

        private IInputElement GetHitTarget(Joint joint, UIElement target)
        {
            Point targetPoint = LayoutRoot.TranslatePoint(GetJointPoint(this.KinectDevice, joint, LayoutRoot.RenderSize, new Point()), target);
            return target.InputHitTest(targetPoint);
        }

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

        private static Point GetJointPoint(KinectSensor kinectDevice, Joint joint, Size containerSize, Point offset)
        {
            DepthImagePoint point = kinectDevice.MapSkeletonPointToDepth(joint.Position, kinectDevice.DepthStream.Format);
            point.X = (int)((point.X * containerSize.Width / kinectDevice.DepthStream.FrameWidth) - offset.X);
            point.Y = (int)((point.Y * containerSize.Height / kinectDevice.DepthStream.FrameHeight) - offset.Y);

            return new Point(point.X, point.Y);
        }

        private void ChangePhase(GamePhase newPhase)
        {
            if (newPhase != this.currentPhase)
            {
                this.currentPhase = newPhase;

                switch (this.currentPhase)
                {
                    case GamePhase.GameOver:
                        this.currentLevel = 0;
                        RedBlock.Opacity = 0.2;
                        BlueBlock.Opacity = 0.2;
                        GreenBlock.Opacity = 0.2;
                        YellowBlock.Opacity = 0.2;

                        GameStateElement.Text = "GAME OVER!";
                        ControlCanvas.Visibility = Visibility.Visible;
                        GameInstructionsElement.Text = "将手放在对象上开始新的游戏。";
                        break;

                    case GamePhase.SimonInstructing:
                        this.currentLevel++;
                        GameStateElement.Text = string.Format("Level {0}", this.currentLevel);
                        ControlCanvas.Visibility = Visibility.Collapsed;
                        GameInstructionsElement.Text = "注意观察Simon的指示。";
                        GenerateInstructions();
                        DisplayInstructions();
                        break;

                    case GamePhase.PlayerPerforming:
                        this.instructionPosition = 0;
                        GameInstructionsElement.Text = "请重复 Simon的指示";
                        break;
                }
            }
        }

        private void GenerateInstructions()
        {
            this.instructionSequence = new UIElement[this.currentLevel];

            for (int i = 0; i < this.currentLevel; i++)
            {
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        this.instructionSequence[i] = RedBlock;
                        break;

                    case 2:
                        this.instructionSequence[i] = BlueBlock;
                        break;

                    case 3:
                        this.instructionSequence[i] = GreenBlock;
                        break;

                    case 4:
                        this.instructionSequence[i] = YellowBlock;
                        break;
                }
            }
        }

        private void DisplayInstructions()
        {
            Storyboard instructionsSequence = new Storyboard();
            DoubleAnimationUsingKeyFrames animation;

            for (int i = 0; i < this.instructionSequence.Length; i++)
            {
                this.instructionSequence[i].ApplyAnimationClock(FrameworkElement.OpacityProperty, null);

                animation = new DoubleAnimationUsingKeyFrames();
                animation.FillBehavior = FillBehavior.Stop;
                animation.BeginTime = TimeSpan.FromMilliseconds(i * 1500);
                Storyboard.SetTarget(animation, this.instructionSequence[i]);
                Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
                instructionsSequence.Children.Add(animation);

                animation.KeyFrames.Add(new EasingDoubleKeyFrame(0.3, KeyTime.FromTimeSpan(TimeSpan.Zero)));
                animation.KeyFrames.Add(new EasingDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(500))));
                animation.KeyFrames.Add(new EasingDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(1000))));
                animation.KeyFrames.Add(new EasingDoubleKeyFrame(0.3, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(1300))));
            }


            instructionsSequence.Completed += (s, e) => { ChangePhase(GamePhase.PlayerPerforming); };
            instructionsSequence.Begin(LayoutRoot);
        }

        private void ProcessPlayerPerforming(Skeleton skeleton)
        {
            //判断用户是否手势是否在目标对象上面，且在指定中的正确顺序
            UIElement correctTarget = this.instructionSequence[this.instructionPosition];
            IInputElement leftTarget = GetHitTarget(skeleton.Joints[JointType.HandLeft], GameCanvas);
            IInputElement rightTarget = GetHitTarget(skeleton.Joints[JointType.HandRight], GameCanvas);
            bool hasTargetChange = (leftTarget != this.leftHandTarget) || (rightTarget != this.rightHandTarget);


            if (hasTargetChange)
            {
                if (leftTarget != null && rightTarget != null)
                {
                    ChangePhase(GamePhase.GameOver);
                }
                else if ((leftHandTarget == correctTarget && rightHandTarget == null) ||
                        (rightHandTarget == correctTarget && leftHandTarget == null))
                {
                    this.instructionPosition++;

                    if (this.instructionPosition >= this.instructionSequence.Length)
                    {
                        ChangePhase(GamePhase.SimonInstructing);
                    }
                }
                else if (leftTarget != null || rightTarget != null)
                {
                    //Do nothing - target found
                }
                else
                {
                    ChangePhase(GamePhase.GameOver);
                }


                if (leftTarget != this.leftHandTarget)
                {
                    if (this.leftHandTarget != null)
                    {
                        ((FrameworkElement)this.leftHandTarget).Opacity = 0.2;
                    }

                    if (leftTarget != null)
                    {
                        ((FrameworkElement)leftTarget).Opacity = 1;
                    }

                    this.leftHandTarget = leftTarget;
                }


                if (rightTarget != this.rightHandTarget)
                {
                    if (this.rightHandTarget != null)
                    {
                        ((FrameworkElement)this.rightHandTarget).Opacity = 0.2;
                    }

                    if (rightTarget != null)
                    {
                        ((FrameworkElement)rightTarget).Opacity = 1;
                    }

                    this.rightHandTarget = rightTarget;
                }
            }
        }
    }
}
