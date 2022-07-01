using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
using ParamDataLib;
using CVPoint = OpenCvSharp.Point;
using CVRect = OpenCvSharp.Rect;
using CVSize = OpenCvSharp.Size;
using Point = System.Windows.Point;

namespace FuncToolLib
{
   public  class TemplateMatch2Tool
    {


        /// <summary>
        /// 多角度模板匹配方法
        /// </summary>
        /// <param name="srcImage">待匹配图像</param>
        /// <param name="modelImage">模板图像</param>
        /// <param name="angleStart">起始角度</param>
        /// <param name="angleRange">角度范围</param>
        /// <param name="angleStep">角度步长</param>
        /// <param name="numLevels">金字塔层级</param>
        /// <param name="thresScore">得分阈值</param>
        /// <returns></returns>
        public TemplateMatch2Result CircleMatchNcc(Mat srcImage, Mat modelImage, 
                      double angleStart, double angleRange, double angleStep,
                           int numLevels, double thresScore, int nccMethod)
        {
            double step = angleRange / ((angleRange / angleStep) / 100);
            double start = angleStart;
            double range = angleRange;

            //定义图片匹配所需要的参数
            int resultCols = srcImage.Cols - modelImage.Cols + 1;
            int resultRows = srcImage.Rows - modelImage.Cols + 1;
            Mat result = new Mat(resultCols, resultRows, MatType.CV_8U);
            Mat src = new Mat();
            Mat model = new Mat();
            srcImage.CopyTo(src);
            modelImage.CopyTo(model);

            //对模板图像和待检测图像分别进行图像金字塔下采样
            for (int i = 0; i < numLevels; i++)
            {
                Cv2.PyrDown(src, src, new Size(src.Cols / 2, src.Rows / 2));
                Cv2.PyrDown(model, model, new Size(model.Cols / 2, model.Rows / 2));
            }

            TemplateMatchModes matchMode = TemplateMatchModes.CCoeffNormed;
            switch (nccMethod)
            {
                case 0:
                    matchMode = TemplateMatchModes.SqDiff;
                    break;
                case 1:
                    matchMode = TemplateMatchModes.SqDiffNormed;
                    break;
                case 2:
                    matchMode = TemplateMatchModes.CCorr;
                    break;
                case 3:
                    matchMode = TemplateMatchModes.CCorrNormed;
                    break;
                case 4:
                    matchMode = TemplateMatchModes.CCoeff;
                    break;
                case 5:
                    matchMode = TemplateMatchModes.CCoeffNormed;
                    break;
            }

            //在没有旋转的情况下进行第一次匹配
            Cv2.MatchTemplate(src, model, result, matchMode);
            Cv2.MinMaxLoc(result, out double minVal, out double maxVal, out CVPoint minLoc, out CVPoint maxLoc, new Mat());

            CVPoint location = maxLoc;
            double temp = maxVal;
            //CVPoint location=new CVPoint(0,0);
            //double temp=0 ;
            double angle = 0;

            Mat newtemplate;
            //Mat newSrc;
            //以最佳匹配点左右十倍角度步长进行循环匹配，直到角度步长小于参数角度步长
            if (nccMethod == 0 || nccMethod == 1)
            {
                do
                {
                    for (int i = 0; i <= (int)range / step; i++)
                    {
                        newtemplate = ImageRotate(model, start + step * i);
                       // newSrc = ImageRotate(src, start + step * i);
                        Cv2.MatchTemplate(src, newtemplate, result, matchMode);
                        Cv2.MinMaxLoc(result, out double minval, out double maxval, out CVPoint minloc, out CVPoint maxloc, new Mat());
                        if (maxval < temp)
                        {
                            location = maxloc;
                            temp = maxval;
                            angle = start + step * i;
                        }
                    }
                    range = step * 2;
                    start = angle - step;
                    step = step / 10;
                } while (step > angleStep);
                return new TemplateMatch2Result(location.X * Math.Pow(2, numLevels) + modelImage.Width / 2, location.Y * Math.Pow(2, numLevels) + modelImage.Height / 2, -angle, temp);
            }
            else
            {
                do
                {
                    for (int i = 0; i <= (int)range / step; i++)
                    {
                        newtemplate = ImageRotate(model, start + step * i);
                     //   newSrc = ImageRotate(src, start + step * i);
                        Cv2.MatchTemplate(src, newtemplate, result, matchMode);
                        Cv2.MinMaxLoc(result, out double minval, out double maxval, out CVPoint minloc, out CVPoint maxloc, new Mat());
                        if (maxval > temp)
                        {
                            location = maxloc;
                            temp = maxval;
                            angle = start + step * i;
                        }
                    }
                    range = step * 2;
                    start = angle - step;
                    step = step / 10;
                } while (step > angleStep);
                if (temp > thresScore)
                {
                    return new TemplateMatch2Result(location.X * Math.Pow(2, numLevels), location.Y * Math.Pow(2, numLevels), -angle, temp);
                   // return new ResultPoint(location.X , location.Y , -angle, temp);
                }
            }
            return new TemplateMatch2Result();
        }

        /*----------------------------*/
     
        /// <summary>
        /// 图像旋转
        /// </summary>
        /// <param name="image">输入图像</param>
        /// <param name="angle">旋转的角度</param>
        /// <returns>旋转后图像</returns>
        static Mat ImageRotate(Mat image, double angle)
        {
            Mat newImg = new Mat();
            Point2f pt = new Point2f((float)image.Cols / 2, (float)image.Rows / 2);
            Mat r = Cv2.GetRotationMatrix2D(pt, angle, 1.0);
            Cv2.WarpAffine(image, newImg, r, image.Size());

            return newImg;
        }   
    }

    public  class TemplateMatch2Result : Result
    {
        public TemplateMatch2Result()
        {
            X = 0;
            Y = 0;
            T = 0;
            Score = 0;
        }
      
        public TemplateMatch2Result(double x, double y, double t, double score)
        {
            X = (int)x;
            Y = (int)y;
            T = t;
            Score = score;
        }
        public double X;
        public double Y;
        public double T;
        public double Score;
    }
}
