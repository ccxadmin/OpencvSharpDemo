using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVPoint = OpenCvSharp.Point;
using CVRect = OpenCvSharp.Rect;
using CVRRect = OpenCvSharp.RotatedRect;
using CVCircle = OpenCvSharp.CircleSegment;
using Rect = System.Drawing.RectangleF;
using Point = System.Drawing.PointF;
using System.Numerics;
using ParamDataLib;

namespace FuncToolLib
{
	/// <summary>
	/// 形状匹配
	/// </summary>
	public class ShapeMatchTool: ToolBase
	{
        public override Result Run<T>(Mat inputImg, T obj)
        {
			ShapeMatchData shapeMatchData = obj as ShapeMatchData;
			ShapeMatchResult shapeMatchResult = new ShapeMatchResult();
			if (shapeMatchData == null)
				shapeMatchData = new ShapeMatchData();
			Mat dst = new Mat();
			Cv2.CvtColor(inputImg, dst, ColorConversionCodes.GRAY2BGR);

			if (shapeMatchData.tpContour.Length <= 0)
            {
				shapeMatchResult.resultToShow = dst;
				shapeMatchResult.exceptionInfo += "模板轮廓不存在，请先创建模板轮廓！";
				shapeMatchResult.runStatus = false;
				return shapeMatchResult;
			}
			
			ShapeTemplateMatch(inputImg, shapeMatchData.tpContour, shapeMatchData.Segthreshold,
				shapeMatchData.MatchValue, shapeMatchData.MincoutourLen, shapeMatchData.MaxcoutourLen,
				 shapeMatchData.MinContourArea, shapeMatchData.MaxContourArea, ref shapeMatchResult, false);


			if (shapeMatchResult.positions.Count>0)
            {			
				shapeMatchResult.runStatus = true;
				return shapeMatchResult;
			}
			//匹配失败
            else
            {
				shapeMatchResult.exceptionInfo += "模板轮廓匹配失败！";
				shapeMatchResult.runStatus = false;
				return shapeMatchResult;
			}

		}

		/// <summary>
		/// 创建形状轮廓模板
		/// </summary>
		/// <param name="img_template">模板图像</param>
		///  <param name="Segthreshold">分割阈值</param>
		/// <param name="templateContour">模板轮廓</param>
		/// <param name="coutourLen">模板轮廓长度</param>
		/// <param name="contourArea">模板轮廓面积</param>
		/// <returns>返回绘制图</returns>
		public Mat CreateTemplateContours(Mat img_template,double Segthreshold,
			ref CVPoint[] templateContour, ref int coutourLen, ref double contourArea)
		{
			//灰度化
			//Mat gray_img_template = new Mat();
			//Cv2.CvtColor(img_template, gray_img_template, ColorConversionCodes.BGR2GRAY);

			//阈值分割
			Mat thresh_img_template = new Mat();
			Cv2.Threshold(img_template, thresh_img_template, Segthreshold, 255, ThresholdTypes.Binary);
            //开运算处理，提出白色噪点
            Mat ellipse = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(3, 3));
            Mat erode_img_template = new Mat();
        //    erode(thresh_img_template, erode_img_template, ellipse);
            Cv2.MorphologyEx(thresh_img_template, thresh_img_template, MorphTypes.Open, ellipse);

            //寻找边界
            CVPoint[][] contours_template;
			//Vector<Vector<CVPoint>> contours_template=new Vector<Vector<CVPoint>>();
			//Vector<Vec4i> hierarchy=new Vector<Vec4i>();
		//	HierarchyIndex[] hierarchy;
			Cv2.FindContours(thresh_img_template, out contours_template, out _, RetrievalModes.List,
				ContourApproximationModes.ApproxNone);

			CVPoint[][] ExceptContours = ContourOperate.ExceptBoundPoints(img_template.BoundingRect(), contours_template);
			
			int count = ExceptContours.ToList<CVPoint[]>().Count;
			List<CVPoint[]> ModelContours=new List<CVPoint[]>();
		
			for (int i=0;i< count; i++)
            {
				if (ExceptContours[i].Length > 30)//至少30点有效
					ModelContours.Add(ExceptContours[i]);
			}

			//绘制边界
			Mat dst = new Mat();
			Cv2.CvtColor(img_template, dst, ColorConversionCodes.GRAY2BGR);
			if(ModelContours.Count>0)
            {
				Cv2.DrawContours(dst, ModelContours, 0, new Scalar(0, 0, 255));
				//获取重心点
				Moments M;
				M = Cv2.Moments(ModelContours[0]);
				double cX = (M.M10 / M.M00);
				double cY = (M.M01 / M.M00);
				//显示目标中心
				dst.drawCross(new CVPoint((int)cX, (int)cY),
					   new Scalar(0, 255, 0), 10, 2);

				//轮廓长度
				coutourLen = ModelContours[0].Length;
				contourArea = Cv2.ContourArea(ModelContours[0]);
				templateContour = ModelContours[0];
			}			
            return dst;
		}

		/// <summary>
		/// 形状匹配
		/// </summary>
		/// <param name="image">输入图像</param>
		/// <param name="imgTemplatecontours">模板轮廓</param>
		///  <param name="Segthreshold">分割阈值</param>
		/// <param name="MatchValue">匹配值</param>
		/// <param name="MincoutourLen">轮廓最小长度</param>
		/// <param name="MaxcoutourLen">轮廓最大长度</param>
		/// <param name="MinContourArea">轮廓最小面积</param>
		/// <param name="MaxContourArea">轮廓最大面积</param>
		/// <param name="shapeMatchResult">匹配结果</param>
		/// <param name="isMultipleTemplates">是否使用多模板</param>
		/// <returns>返回绘制图</returns>
		bool ShapeTemplateMatch(Mat image, CVPoint[] imgTemplatecontours, double Segthreshold,
			double MatchValue, int MincoutourLen, int MaxcoutourLen,
			 double MinContourArea, double MaxContourArea, ref ShapeMatchResult shapeMatchResult,
			 bool isMultipleTemplates=false)
		{
		
			//List<Point2d> image_coordinates = new List<Point2d>();
			//灰度化
			//Mat gray_img=new Mat();
			//Cv2.CvtColor(image, gray_img, ColorConversionCodes.BGR2GRAY);
			Mat dst = new Mat();
			Cv2.CvtColor(image, dst, ColorConversionCodes.GRAY2BGR);
			//阈值分割
			Mat thresh_img = new Mat();
			Cv2.Threshold(image, thresh_img, Segthreshold, 255, ThresholdTypes.Binary);

			//寻找边界
			CVPoint[][] contours_img;
			//HierarchyIndex[] hierarchy;
			Cv2.FindContours(thresh_img, out contours_img, out _, RetrievalModes.List,
				 ContourApproximationModes.ApproxNone);
			//根据形状模板进行匹配
			int min_pos = -1;
			double min_value = MatchValue;//匹配分值，小于该值则匹配成功
			List<CVPoint[]> points = contours_img.ToList<CVPoint[]>();

			for (int i = 0; i < points.Count; i++)
			{
				//计算轮廓面积，筛选掉一些没必要的小轮廓
				if (Cv2.ContourArea(contours_img[i]) < MinContourArea ||
							  Cv2.ContourArea(contours_img[i]) > MaxContourArea)
					continue;
				//轮廓长度不达标
				if (contours_img[i].Length < MincoutourLen || contours_img[i].Length > MaxcoutourLen)
					continue;

				
					//得到匹配分值 
					double value = Cv2.MatchShapes(contours_img[i], imgTemplatecontours,
														   ShapeMatchModes.I3, 0.0);
					//将匹配分值与设定分值进行比较 
					if (value < min_value)
					{
						min_pos = i;									
						//获取重心点
						Moments M;
						M = Cv2.Moments(contours_img[min_pos]);
						double cX = (M.M10 / M.M00);
						double cY = (M.M01 / M.M00);

						float a = (float)(M.M20 / M.M00 - cX * cX);
						float b = (float)(M.M11 / M.M00 - cX * cY);
						float c = (float)(M.M02 / M.M00 - cY * cY);
						//计算角度
						double tanAngle = Cv2.FastAtan2(2 * b, (a - c)) / 2;
						if (tanAngle > 90)
							tanAngle -= 180;
					
						//将目标的重心坐标都存在数组中 
						shapeMatchResult.positions.Add(new Point2d(cX, cY));//向数组中存放点的坐标
                       //将目标的角度都存在数组中 
						shapeMatchResult.rotations.Add(tanAngle);
						//将目标的得分都存在数组中 
						shapeMatchResult.scores.Add(value);
						//匹配到的轮廓
						shapeMatchResult.contours.Add(contours_img[min_pos]);
						/*----------------*/						
					}
					
				
			}
			/*----------------*/
			int count = shapeMatchResult.scores.Count;

			if (isMultipleTemplates)
			{
				for (int j = 0; j < count; j++)
				{
					//绘制目标边界
					Cv2.DrawContours(dst, shapeMatchResult.contours, j, new Scalar(0, 0, 255));
					//得分绘制
					Cv2.PutText(dst,
						string.Format("Score:{0};Angle:{1}", shapeMatchResult.scores[j].ToString("F3"),
						shapeMatchResult.rotations[j].ToString("F3")),
							 new CVPoint(shapeMatchResult.contours[j][0].X + 10, shapeMatchResult.contours[j][0].Y - 10),
										HersheyFonts.HersheyDuplex, 1, Scalar.Yellow);
					//显示目标中心并提取坐标点
					dst.drawCross(new CVPoint((int)shapeMatchResult.positions[j].X, (int)shapeMatchResult.positions[j].Y),
						   new Scalar(0, 255, 0), 10, 2);
					//当前轮廓旋转矩
					RotatedRect currrect = Cv2.MinAreaRect(shapeMatchResult.contours[j]);

					dst.DrawRotatedRect(currrect, Scalar.Lime);
				}
			}
			else
			{
			    double bestScore=     shapeMatchResult.scores.Min();
				int index = shapeMatchResult.scores.FindIndex(s=>s== bestScore);
				//绘制目标边界
				Cv2.DrawContours(dst, shapeMatchResult.contours, index, new Scalar(0, 0, 255));
				//得分绘制
				Cv2.PutText(dst,
					string.Format("Score:{0};Angle:{1}", shapeMatchResult.scores[index].ToString("F3"),
					shapeMatchResult.rotations[index].ToString("F3")),
						 new CVPoint(shapeMatchResult.contours[index][0].X + 10, shapeMatchResult.contours[index][0].Y - 10),
									HersheyFonts.HersheyDuplex, 1, Scalar.Yellow);
				//显示目标中心并提取坐标点
				dst.drawCross(new CVPoint((int)shapeMatchResult.positions[index].X, (int)shapeMatchResult.positions[index].Y),
					   new Scalar(0, 255, 0), 10, 2);
				//当前轮廓旋转矩
				RotatedRect currrect = Cv2.MinAreaRect(shapeMatchResult.contours[index]);

				dst.DrawRotatedRect(currrect, Scalar.Lime);
			}

			shapeMatchResult.resultToShow = dst;
			return true;
		}
	}
	/// <summary>
	/// 模板匹配结果
	/// </summary>
	public class ShapeMatchResult: Result
	{
		public ShapeMatchResult()
        {
			rotations = new List<double>();
			contours = new List<CVPoint[]>();
			scores = new List<double>();
			positions = new List<Point2d>();
		}
		public List<double> rotations;            // 旋转角度
		public List<CVPoint[]> contours;       // 匹配轮廓
		public List<double> scores;               // 匹配得分
		public List<Point2d> positions;         // 匹配位置
	}

}
