using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using CVPoint = OpenCvSharp.Point;
using CVRect = OpenCvSharp.Rect;
using CVRRect = OpenCvSharp.RotatedRect;
using CVCircle = OpenCvSharp.CircleSegment;
using Rect = System.Drawing.RectangleF;
using Point = System.Drawing.PointF;
using System.ComponentModel;
using System.IO;

namespace ParamDataLib
{
    /// <summary>
    /// 轮廓匹配参数
    /// </summary>
    [Serializable]
    public class ShapeMatchData : ParmasDataBase, IParmaData
    {
        public ShapeMatchData()
        {
            
        }
      
        /// <summary>
        /// 模板轮廓
        /// </summary>
        public CVPoint[] tpContour { get; set; }

        /// <summary>
        /// 分割阈值
        /// </summary>
        [DefaultValue(150)]       
        public double Segthreshold { get; set; }


        /// <summary>
        /// 匹配得分
        /// </summary>
        [DefaultValue(0.3)]
        public double MatchValue { get; set; }


        /// <summary>
        /// 最小轮廓长度
        /// </summary>
        [DefaultValue(100)]
        public int MincoutourLen { get; set; }


        /// <summary>
        /// 最大轮廓长度
        /// </summary>
        [DefaultValue(99999)]
        public int MaxcoutourLen { get; set; }


        /// <summary>
        /// 最小轮廓面积
        /// </summary>
        [DefaultValue(100)]
        public double MinContourArea { get; set; }


        /// <summary>
        /// 最大轮廓面积
        /// </summary>
        [DefaultValue(99999)]
        public double MaxContourArea { get; set; }

     
        /// <summary>
        /// 回去当前实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetData<T>() where T : class, IParmaData
        {
            return this as T;
        }


    }
}
