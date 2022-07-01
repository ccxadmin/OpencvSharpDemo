using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncToolLib.Contour
{
    public  class CannyTool
    {

        /// <summary>
        ///  Canny边缘检测 
        /// </summary>
        /// <param name="Gray">输入图</param>
        /// <param name="canThddown">阈值下限</param>
        /// <param name="canThdup">阈值上限</param>
        /// <returns></returns>
        static public Mat Canny(Mat Gray,double canThddown, double canThdup)
        {

            Mat canny = new Mat(Gray.Size(), Gray.Type());
            Cv2.Canny(Gray, canny, canThddown, canThdup);
            //cannny。参数：1：src_img：8 bit 输入图像；2：dst输出边缘图像，一般是二值图像，背景是黑色；3：tkBarCannyMin.Value低阈值。值越大，找到的边缘越少；4：tkBarCannyMax.Value高阈值；5:hole表示应用Sobel算子的孔径大小，其有默认值3；6:rbBtnTrue.Checked计算图像梯度幅值的标识，有默认值false。
            //低于阈值1的像素点会被认为不是边缘；
            //高于阈值2的像素点会被认为是边缘；
            //在阈值1和阈值2之间的像素点,若与一阶偏导算子计算梯度得到的边缘像素点相邻，则被认为是边缘，否则被认为不是边缘。
            return canny;

        }
    }
}
