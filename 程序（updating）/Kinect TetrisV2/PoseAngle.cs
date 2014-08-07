using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;

namespace Kinect_TetrisV2
{
    /// <summary>
    /// 姿势的角度
    /// </summary>
    public class PoseAngle
    {
        /// <summary>
        /// PoseAngle 类构造器
        /// </summary>
        /// <param name="centerJoint">关节点</param>
        /// <param name="angleJoint">关节点</param>
        /// <param name="angle">期望角度</param>
        /// <param name="threshold">阈值</param>
        public PoseAngle(JointType centerJoint, JointType angleJoint, double angle, double threshold)
        {
            CenterJoint = centerJoint;//关节点
            AngleJoint = angleJoint;//关节点
            Angle = angle;//期望角度
            Threshold = threshold;//阈值
        }


        public JointType CenterJoint { get; private set; }
        public JointType AngleJoint { get; private set; }
        public double Angle { get; private set; }
        public double Threshold { get; private set; }
    }
}
