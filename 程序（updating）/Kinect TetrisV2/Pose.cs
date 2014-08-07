using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kinect_TetrisV2
{
    /// <summary>
    /// 姿势类型结构体
    /// </summary>
    public struct Pose
    {
        public string Title;//姿势名称
        public PoseAngle[] Angles;//PoseAngle数组
    }
}