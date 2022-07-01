
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace VisionShowLib
{
    public delegate void OutPointGray(int x, int y);
    public partial class VisionShowControl : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #region 私有变量
        public EventHandler MouseMove;       
        /// <summary>
        /// 鼠标处像素坐标
        /// </summary>
        private float mouseX, mouseY;   
        /// <summary>
        /// 图像缩放比例
        /// </summary>
        private float sizeratio = 1;

        /// <summary>
        /// 形状集合（可再编辑）
        /// </summary>
        private List<object> shapelist = new List<object>();
        /// <summary>
        /// 区域集合（不可再编辑）
        /// </summary>
        public List<RegionEx> regionExlist = new List<RegionEx>();
        /// <summary>
        /// 文本集合
        /// </summary>
        public List<TextEx> textExlist = new List<TextEx>();

        /// <summary>
        /// 选中的图案
        /// </summary>
        private dynamic selectshape = null;

        /// <summary>
        /// 创建图案是鼠标的实际位置
        /// </summary>
        // private float drawX, drawY;
        /// <summary>
        /// 正在创建中的图案
        /// </summary>
        // private dynamic drawshape;
        /// <summary>
        /// 画圆
        /// </summary>
        //private bool drawcircle = false;
        /// <summary>
        /// 画矩形
        /// </summary>
        //private bool drawrectangle1 = false;
     
        int mx = 0;
        int my = 0;
        /// <summary>
        /// 使用的画笔
        /// </summary>
        private Pen Penused;

        private float drawimgX, drawimgY, drawimgW, drawimgH;
        
        private Bitmap image;

        int imageWidth,imageHeight;
        #endregion
        #region 缩放因子属性
        private double scalestep = 0.2;
        [Description("缩放步长"), Browsable(true)]
        public double FactorStep
        {
            get => scalestep;
            set => scalestep = value;
        }
        #endregion
        #region 显示图像
        /// <summary>
        /// 图像
        /// </summary>
        public Bitmap Image
        {
            get => image;
            set
            {
                image = value;
                updateImage();
            }
        }

        #endregion

        //双击获取像素坐标
        public OutPointGray DoubleClickGetMousePosHandle2;
        public VisionShowControl()
        {
            InitializeComponent();
            MyPens.Select.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Penused = MyPens.Default;
            PicBox.Width = PanelBox.Width - 100;
            PicBox.Height = PanelBox.Height - 100;
            int centreX = (PanelBox.Location.X + PanelBox.Width) / 2;
            int centreY = (PanelBox.Location.Y + PanelBox.Height) / 2;
            int newX = centreX - PicBox.Width / 2;
            int newY = centreY - PicBox.Height / 2- toolStrip1.Height/2;
            PicBox.Location = new Point(newX, newY);
       
        }
        public Point mouseDownPoint;//存储鼠标焦点的全局变量
        public bool isSelected = false;//平移状态      
        public int selectindex;// 选择的shape索引
        public EventHandler RoiChangedHandle;//ROI更新通知事件
        /*/////////////////////////////////////////////*/

        private void VisionShowControl_Load(object sender, EventArgs e)
        {
            PicBox.Dock = DockStyle.None;
            //Width = image.Width;
            //Height = image.Height;
            //computeWratio();
            //sizeratio = winratio;
            //这个事件是鼠标滑轮滚动的触发事件，可以在Designer.cs中注册。
            this.PicBox.MouseWheel += new MouseEventHandler(this.PicBox_MouseWheel);
            this.PicBox.MouseDown += new MouseEventHandler(this.PicBox_MouseDown);
            this.PicBox.MouseMove += new MouseEventHandler(this.PicBox_MouseMove);
            this.PicBox.MouseUp += new MouseEventHandler(this.PicBox_MouseUp);

        }
        /// <summary>
        /// 滚轮缩放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBox_MouseWheel(object sender, MouseEventArgs e)
        {
            double scale = FactorStep;
            int width = PicBox.Width;
            int height = PicBox.Height;

            int sign = Math.Sign(e.Delta);

            PicBox.Width += (int)(sign * scale * width);
            PicBox.Height += (int)(sign * scale * height);
            this.PicBox.Left -= (int)(sign * scale * e.X);
            this.PicBox.Top -= (int)(sign * scale * e.Y);           
            computePicratio();

        }
        //在MouseDown处获知鼠标是否按下，并记录下此时的鼠标坐标值；
        private void PicBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                mouseDownPoint.X = Cursor.Position.X;  //注：全局变量mouseDownPoint前面已定义为Point类型  
                mouseDownPoint.Y = Cursor.Position.Y;
                isSelected = true;
            }       
        }

        //在MouseUp处获知鼠标是否松开，终止拖动操作；
        private void PicBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                isSelected = false;
            }
            updateImage();
        }
             
        //图片平移,在MouseMove处添加拖动函数操作
        private void PicBox_MouseMove(object sender, MouseEventArgs e)
        {
            //窗口移动
            if (isSelected && IsMouseInPanel())//确定已经激发MouseDown事件，和鼠标在picturebox的范围内
            {

                this.PicBox.Left = this.PicBox.Left + (Cursor.Position.X - mouseDownPoint.X);
                this.PicBox.Top = this.PicBox.Top + (Cursor.Position.Y - mouseDownPoint.Y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                computedrawsize();
            }

            mouseX = (float)(e.X * sizeratio);
            mouseY = (float)(e.Y * sizeratio);
            Color pixelcolor = Color.FromArgb(0, 0, 0);
            if (this.image!=null&& this.image.Width>0)
                try
                {

                    pixelcolor = this.image.GetPixel((int)mouseX, (int)mouseY);
                }
                catch { }
            if (MouseMove != null)
            {
                MouseMove(this, new MouseEventArgs(e.Button, e.Clicks, (int)mouseX, (int)mouseY, e.Delta));
            }
           
            string positionxy = $"X:{(int)mouseX}|Y:{(int)mouseY}" +
                $"|C:{(int)pixelcolor.R},{(int)pixelcolor.G},{(int)pixelcolor.B}";
            toolStripStatusLabel1.Text = positionxy;

            //选中
            if (e.Button != MouseButtons.Left || selectshape == null )
            {

                for (int i = 0; i < shapelist.Count; i++)
                {
                    bool select = true;
                    if (shapelist[i] is RectangleF)
                    {
                        RectangleF mouserect = (RectangleF)shapelist[i];
                        bool left = Math.Abs(mouseX - mouserect.X) < 10 * sizeratio;
                        bool top = Math.Abs(mouseY - mouserect.Y) < 10 * sizeratio;
                        bool right = Math.Abs(mouseX - mouserect.X - mouserect.Width) < 10 * sizeratio;
                        bool Bottom = Math.Abs(mouseY - mouserect.Y - mouserect.Height) < 10 * sizeratio;

                        RectangleF centerrect = new RectangleF(mouserect.X + mouserect.Width / 2 - 10,
                            mouserect.Y + mouserect.Height / 2 - 10, 20, 20);
                        RectangleF topleft = new RectangleF(mouserect.X - 20, mouserect.Y - 20, 40, 40);
                        RectangleF topright = new RectangleF(mouserect.X + mouserect.Width - 20, mouserect.Y - 20, 40, 40);
                        RectangleF bottomleft = new RectangleF(mouserect.X - 20, mouserect.Y + mouserect.Height - 20, 40, 40);
                        RectangleF bottomright = new RectangleF(mouserect.X + mouserect.Width - 20, mouserect.Y + mouserect.Height - 20, 40, 40);
                        if (centerrect.Contains(mouseX, mouseY))//中心点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.SizeAll;
                        }
                        else if (topleft.Contains(mouseX, mouseY))//左上点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanNW;
                        }
                        else if (topright.Contains(mouseX, mouseY))//右上点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanNE;
                        }
                        else if (bottomleft.Contains(mouseX, mouseY))//左下点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanSW;
                        }
                        else if (bottomright.Contains(mouseX, mouseY))//右下点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanSE;
                        }
                        else if (left && Math.Abs(mouseY - mouserect.Y - mouserect.Height / 2.0) < mouserect.Height / 2)
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanWest;

                        }
                        else if (right && Math.Abs(mouseY - mouserect.Y - mouserect.Height / 2.0) < mouserect.Height / 2)
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanEast;
                        }
                        else if (top && Math.Abs(mouseX - mouserect.X - mouserect.Width / 2) < mouserect.Width / 2)
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanNorth;
                        }
                        else if (Bottom && Math.Abs(mouseX - mouserect.X - mouserect.Width / 2) < mouserect.Width / 2)
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanSouth;
                        }
                        else
                        {
                            select = false;
                            selectshape = null;
                        }
                        ////
                        if (select)
                        {
                            selectshape = mouserect;
                            selectindex = i;
                            break;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            Penused = MyPens.Default;
                        }
                    }
                    else if (shapelist[i] is RotatedRectF)
                    {
                        RotatedRectF mouserect = (RotatedRectF)shapelist[i];
                        bool left = Math.Abs(mouseX - (mouserect.getPointF()[0].X+ mouserect.getPointF()[3].X)/2) < 10 * sizeratio;
                        bool top = Math.Abs(mouseY - (mouserect.getPointF()[0].Y + mouserect.getPointF()[1].Y) / 2) < 10 * sizeratio;
                        bool right = Math.Abs(mouseX - (mouserect.getPointF()[1].X + mouserect.getPointF()[2].X) / 2) < 10 * sizeratio;
                        bool Bottom = Math.Abs(mouseY - (mouserect.getPointF()[2].Y + mouserect.getPointF()[3].Y) / 2) < 10 * sizeratio;

                        RectangleF centerrect = new RectangleF(mouserect.cx - 10, mouserect.cy - 10, 20, 20);
                        RectangleF topleft = new RectangleF(mouserect.getPointF()[0].X - 20, mouserect.getPointF()[0].Y - 20, 40, 40);
                        RectangleF topright = new RectangleF(mouserect.getPointF()[1].X  - 20, mouserect.getPointF()[1].Y - 20, 40, 40);
                        RectangleF bottomleft = new RectangleF(mouserect.getPointF()[3].X - 20, mouserect.getPointF()[3].Y - 20, 40, 40);
                        RectangleF bottomright = new RectangleF(mouserect.getPointF()[2].X - 20, mouserect.getPointF()[2].Y - 20, 40, 40);
                        RectangleF angleSign = new RectangleF(mouserect.getPointF()[5].X - 20, mouserect.getPointF()[5].Y - 20, 40, 40);
                        if (centerrect.Contains(mouseX, mouseY))//中心点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.SizeAll;
                        }
                       else if (angleSign.Contains(mouseX, mouseY))//角度标点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.Hand;
                        }
                        else if (topleft.Contains(mouseX, mouseY))//左上点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanNW;
                        }
                        else if (topright.Contains(mouseX, mouseY))//右上点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanNE;
                        }
                        else if (bottomleft.Contains(mouseX, mouseY))//左下点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanSW;
                        }
                        else if (bottomright.Contains(mouseX, mouseY))//右下点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanSE;
                        }
                        else if (left && Math.Abs(mouseY - (mouserect.getPointF()[0].Y + mouserect.getPointF()[3].Y) / 2) < mouserect.Height / 4)
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanWest;

                        }
                        else if (right && Math.Abs(mouseY - (mouserect.getPointF()[1].Y + mouserect.getPointF()[2].Y) / 2) < mouserect.Height / 4)
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanEast;
                        }
                        else if (top && Math.Abs(mouseX - (mouserect.getPointF()[0].X + mouserect.getPointF()[1].X) / 2) < mouserect.Width / 4)
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanNorth;
                        }
                        else if (Bottom && Math.Abs(mouseX - (mouserect.getPointF()[2].X + mouserect.getPointF()[3].X) / 2) < mouserect.Width / 4)
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanSouth;
                        }
                        else
                        {
                            select = false;
                            selectshape = null;
                       
                        }
                        ////
                        if (select)
                        {
                            selectshape = mouserect;
                            selectindex = i;
                            break;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            Penused = MyPens.Default;
                        }
                    }
                    else if (shapelist[i] is CircleF)
                    {
                        CircleF circle = (CircleF)shapelist[i];
                        float radiu = (float)Math.Sqrt(Math.Pow(mouseX - circle.centerx, 2) +
                                                        Math.Pow(mouseY - circle.centery, 2));
                        if (Math.Abs(circle.Radius - radiu) < 10)
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.Cross;

                        }
                        else if (radiu < 20)
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.SizeAll;

                        }
                        else
                        {
                            select = false;
                            selectshape = null;
                        }
                        /////////////
                        if (select)
                        {
                            //(shapelist[i] as CircleF).isSelected = true;
                            selectshape = circle;
                            selectindex = i;
                            break;
                        }
                        else
                        {

                            this.Cursor = Cursors.Default;
                            Penused = MyPens.Default;
                            //(shapelist[i] as CircleF).isSelected = false;
                            selectshape = null;
                        }
                    }
                    else if (shapelist[i] is SectorF)
                    {
                        SectorF sectorF = (SectorF)shapelist[i];

                        RectangleF rect_startp = new RectangleF(sectorF.getEndpoint(sectorF.startAngle).X - 20,
                            sectorF.getEndpoint(sectorF.startAngle).Y - 20, 40, 40);

                        RectangleF rect_endp = new RectangleF(sectorF.getEndpoint(sectorF.getEndAngle).X - 20,
                          sectorF.getEndpoint(sectorF.getEndAngle).Y - 20, 40, 40);


                        float radiu = (float)Math.Sqrt(Math.Pow(mouseX - sectorF.centreP.X, 2) +
                                                        Math.Pow(mouseY - sectorF.centreP.Y, 2));

                        if (Math.Abs(sectorF.getRadius - radiu) < 10 &&
                           !rect_startp.Contains(mouseX, mouseY) && !rect_endp.Contains(mouseX, mouseY))
                        //半径缩放
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.Cross;

                        }
                        //圆心平移
                        else if (radiu < 20)
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.SizeAll;

                        }
                        else if (rect_startp.Contains(mouseX, mouseY))//起始点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanEast;
                        }
                        else if (rect_endp.Contains(mouseX, mouseY))//终止点位
                        {
                            Penused = MyPens.Select;
                            this.Cursor = Cursors.PanWest;
                        }

                        else
                        {
                            select = false;
                            selectshape = null;
                        }
                        /////////////
                        if (select)
                        {
                            //(shapelist[i] as CircleF).isSelected = true;
                            selectshape = sectorF;
                            selectindex = i;
                            break;
                        }
                        else
                        {

                            this.Cursor = Cursors.Default;
                            Penused = MyPens.Default;
                            //(shapelist[i] as CircleF).isSelected = false;
                            selectshape = null;
                        }
                    }
                }
            }
            //拖拽
            if (selectshape != null)
            {
                if (e.Button == MouseButtons.Left )
                {
                    if (selectshape is RectangleF)
                    {
                        float drawW = selectshape.Width;
                        float drawH = selectshape.Height;
                        float drawX = selectshape.X;
                        float drawY = selectshape.Y;
                        float x = drawX, y = drawY, width = drawW, height = drawH;
                        if (this.Cursor == Cursors.SizeAll)
                        {
                            float centerx = drawX + width / 2;
                            float centery = drawY + height / 2;

                            x += mouseX - centerx;
                            y += mouseY - centery;
                        }
                        else if (this.Cursor == Cursors.PanNW)
                        {
                            width += drawX - mouseX;
                            height += drawY - mouseY;
                            x = mouseX;
                            y = mouseY;
                        }
                        else if (this.Cursor == Cursors.PanNE)
                        {
                            width = mouseX - drawX;
                            height += drawY - mouseY;
                            y = mouseY;
                        }
                        else if (this.Cursor == Cursors.PanSW)
                        {
                            width -= mouseX - drawX;
                            height = mouseY - drawY;
                            x = mouseX;
                        }
                        else if (this.Cursor == Cursors.PanSE)
                        {
                            width = mouseX - drawX;
                            height = mouseY - drawY;

                        }
                        else if (this.Cursor == Cursors.PanWest)//左
                        {

                            width = (float)drawW + (drawX - mouseX);
                            x = mouseX;
                        }
                        else if (this.Cursor == Cursors.PanEast)
                        {
                            width = mouseX - drawX;
                        }
                        else if (this.Cursor == Cursors.PanNorth)
                        {
                            y = mouseY;
                            height = drawH + drawY - mouseY;
                        }
                        else if (this.Cursor == Cursors.PanSouth)
                        {
                            height = mouseY - drawY;
                        }
                        selectshape = new RectangleF(x, y, width, height);

                    }
                    else if (selectshape is RotatedRectF)
                    {
                        float angle = selectshape.angle;                     
                        float drawW = selectshape.Width;
                        float drawH = selectshape.Height;
                        float drawX = selectshape.cx;
                        float drawY = selectshape.cy;
                        float x = drawX, y = drawY, width = drawW, height = drawH;
                        if (this.Cursor == Cursors.SizeAll)
                        {
                            float centerx = drawX;
                            float centery = drawY ;

                            x += mouseX - centerx;
                            y += mouseY - centery;
                        }
                        else if(this.Cursor == Cursors.Hand)//角度旋转标志
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                mx = e.X;
                                my = e.Y;
                                angle = (float)(Math.Atan2(mouseY - selectshape.cy, mouseX - selectshape.cx)*180/Math.PI);
                                selectshape.angle = angle;
                            }

                        }
                        else if (this.Cursor == Cursors.PanNW)
                        {
                            width = (drawX-mouseX ) * 2;
                            height = (drawY-mouseY) * 2;

                        }
                        else if (this.Cursor == Cursors.PanNE)
                        {
                            width = (mouseX - drawX) * 2;
                            height = (drawY - mouseY) * 2;
                        }
                        else if (this.Cursor == Cursors.PanSW)
                        {
                            width = (drawX - mouseX) * 2;
                            height = (mouseY - drawY) * 2;
                        }
                        else if (this.Cursor == Cursors.PanSE)
                        {
                            width =( mouseX - drawX)*2;
                            height =( mouseY - drawY)*2;

                        }
                        else if (this.Cursor == Cursors.PanWest)//左
                        {

                            //     width = (float)drawW + (drawX - mouseX);
                            //     x = mouseX;
                            width = (drawX- mouseX) * 2;

                        }
                        else if (this.Cursor == Cursors.PanEast)
                        {
                            width = (mouseX - drawX) * 2;
                        }
                        else if (this.Cursor == Cursors.PanNorth)
                        {
                            //    y = mouseY;
                            //       height = drawH + drawY - mouseY;
                            height = ( drawY - mouseY) * 2;
                        }
                        else if (this.Cursor == Cursors.PanSouth)
                        {
                            height = (mouseY - drawY)*2;
                        }

                        selectshape = new RotatedRectF(x, y, width, height, angle);
                      
                    }
                    else if (selectshape is CircleF)
                    {
                        if (this.Cursor == Cursors.Cross)//缩放
                        {
                            selectshape.x2 = mouseX;
                            selectshape.y2 = mouseY;
                            selectshape.Radius = (float)Math.Sqrt(Math.Pow(selectshape.x1 - selectshape.x2, 2)
                                 + Math.Pow(selectshape.y1 - selectshape.y2, 2));
                        }
                        else if (this.Cursor == Cursors.SizeAll)//平移
                        {
                            selectshape.x2 += mouseX - selectshape.x1;
                            selectshape.y2 += mouseY - selectshape.y1;
                            selectshape.x1 = mouseX;
                            selectshape.y1 = mouseY;

                        }

                    }
                    else if (selectshape is SectorF)
                    {
                        float centreX = ((SectorF)selectshape).centreP.X;
                        float centreY = ((SectorF)selectshape).centreP.Y;
                        double R = ((SectorF)selectshape).getRadius;
                        float width = ((SectorF)selectshape).width;
                        float height = ((SectorF)selectshape).height;
                        float startA = ((SectorF)selectshape).startAngle;
                        float sweepA = ((SectorF)selectshape).sweepAngle;
                        float endA= ((SectorF)selectshape).getEndAngle;


                        if (this.Cursor == Cursors.Cross)//缩放
                        {
                            R = Math.Sqrt(Math.Pow(mouseX - centreX, 2)
                                 + Math.Pow(mouseY - centreY, 2));

                            width = height= (float)R * 2;


                        
                        }
                        else if (this.Cursor == Cursors.SizeAll)//平移
                        {
                            centreX = mouseX;
                            centreY = mouseY;
                        }
                        else if (this.Cursor == Cursors.PanEast)
                        {

                            if (mouseX >= centreX && mouseX <= centreX + R)
                                if (mouseY >= centreY)
                                {
                                    double offsetX = mouseX - centreX;
                                    double offsetY = mouseY - centreY;
                                    double angle = Math.Atan(offsetY / offsetX) * 180 / Math.PI;
                                    startA = (float)angle;
                                }
                                else {
                                    double offsetX = mouseX - centreX;
                                    double offsetY = centreY - mouseY;
                                    double angle = Math.Atan(offsetY / offsetX) * 180 / Math.PI;
                                    startA = 360-(float)angle;
                                }
                            else if (mouseX <= centreX && mouseX >= centreX - R)
                                if (mouseY >= centreY)
                                {
                                    double offsetX = centreX - mouseX;
                                    double offsetY = mouseY - centreY;
                                    double angle = Math.Atan(offsetY / offsetX) * 180 / Math.PI;
                                    startA =180- (float)angle;
                                }
                                else
                                {
                                    double offsetX = centreX - mouseX;
                                    double offsetY = centreY - mouseY;
                                    double angle = Math.Atan(offsetY / offsetX) * 180 / Math.PI;
                                    startA = (float)angle+180;
                                }
                        }
                        else if (this.Cursor == Cursors.PanWest)
                        {

                            if (mouseX >= centreX && mouseX <= centreX + R)
                                if (mouseY >= centreY)
                                {
                                    double offsetX = mouseX - centreX;
                                    double offsetY = mouseY - centreY;
                                    double angle = Math.Atan(offsetY / offsetX) * 180 / Math.PI;
                                    endA = (float)angle;
                                }
                                else
                                {
                                    double offsetX = mouseX - centreX;
                                    double offsetY = centreY - mouseY;
                                    double angle = Math.Atan(offsetY / offsetX) * 180 / Math.PI;
                                    endA =360 - (float)angle;
                                }
                            else if (mouseX <= centreX && mouseX >= centreX - R)
                                if (mouseY >= centreY)
                                {
                                    double offsetX = centreX - mouseX;
                                    double offsetY = mouseY - centreY;
                                    double angle = Math.Atan(offsetY / offsetX) * 180 / Math.PI;
                                    endA = 180 - (float)angle;
                                }
                                else
                                {
                                    double offsetX = centreX - mouseX;
                                    double offsetY = centreY - mouseY;
                                    double angle = Math.Atan(offsetY / offsetX) * 180 / Math.PI;
                                    endA = (float)angle+180;
                                }
                            sweepA = endA - startA;
                        }
                        selectshape = new SectorF(new PointF(centreX, centreY), (float)R, startA, sweepA);
                    }

                    shapelist.RemoveAt(selectindex);
                    shapelist.Insert(selectindex, selectshape);//更新
                    updateImage();
                }
            }
        }

        //图像重新绘制
        private void PicBox_Paint(object sender, PaintEventArgs e)
        {
            if (image == null) return;
            e.Graphics.Clear(Color.White);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(image, drawimgrect, drawsrcrect, GraphicsUnit.Pixel);
          
            foreach (var r in regionExlist)
                e.Graphics.drawRegion(r, sizeratio);
            foreach (var t in textExlist)
                e.Graphics.drawText(t, sizeratio);

            for (int i = 0; i < shapelist?.Count; i++)
            {
                if (shapelist[i] is RectangleF)
                {
                    RectangleF rect = (RectangleF)shapelist[i];
                    //if (!rect.isSelected)
                        e.Graphics.DrawRectangle(MyPens.Default, rect.X / sizeratio, rect.Y / sizeratio, rect.Width / sizeratio, rect.Height / sizeratio);
                   
                }
                else if (shapelist[i] is RotatedRectF)
                {
                    RotatedRectF rrect = (RotatedRectF)shapelist[i];
                    using (var graph = new GraphicsPath())
                    {
                        PointF Center = new PointF(rrect.cx / sizeratio, rrect.cy / sizeratio);
                      
                        graph.AddRectangle(new RectangleF(rrect.getrectofangleEqualZero().X / sizeratio,
                              rrect.getrectofangleEqualZero().Y / sizeratio,
                                rrect.getrectofangleEqualZero().Width / sizeratio,
                                   rrect.getrectofangleEqualZero().Height / sizeratio));
                        graph.AddLine(new PointF(rrect.cx / sizeratio, rrect.cy / sizeratio),
                         new PointF((rrect.cx + rrect.Width) / sizeratio, rrect.cy / sizeratio));

                        graph.AddString(rrect.angle.ToString("F3"),
                            new Font("宋体", 12f).FontFamily,
                            (int)FontStyle.Regular,
                            26,
                            new PointF((rrect.cx + rrect.Width+20) / sizeratio,
                            rrect.cy / sizeratio),
                            StringFormat.GenericDefault);

                        var a = rrect.angle * (Math.PI / 180);
                        var n1 = (float)Math.Cos(a);
                        var n2 = (float)Math.Sin(a);
                        var n3 = -(float)Math.Sin(a);
                        var n4 = (float)Math.Cos(a);
                        var n5 = (float)(Center.X * (1 - Math.Cos(a)) + Center.Y * Math.Sin(a));
                        var n6 = (float)(Center.Y * (1 - Math.Cos(a)) - Center.X * Math.Sin(a));
                        graph.Transform(new Matrix(n1, n2, n3, n4, n5, n6));
                        e.Graphics.DrawPath(MyPens.Default, graph);                  

                    }                
                }
                else if (shapelist[i] is CircleF)
                {
                    CircleF circle = (CircleF)shapelist[i];
                    //if (circle.isSelected)
                        e.Graphics.DrawEllipse(MyPens.Default, (circle.centerx - circle.Radius) / sizeratio,
                            (circle.centery - circle.Radius) / sizeratio, 2 * circle.Radius / sizeratio, 2 * circle.Radius / sizeratio);
                  
                }
                else if (shapelist[i] is SectorF)
                {
                    SectorF sectorF = (SectorF)shapelist[i];
                    //if (circle.isSelected)
                    e.Graphics.DrawEllipse(MyPens.assist, sectorF.x / sizeratio, sectorF.y / sizeratio,
                       sectorF.width / sizeratio, sectorF.height / sizeratio);

                    e.Graphics.DrawPie(MyPens.Default, sectorF.x / sizeratio, sectorF.y / sizeratio, 
                        sectorF.width / sizeratio, sectorF.height / sizeratio,
                    sectorF.startAngle, sectorF.sweepAngle);

                    /*-----*/
                    double centreX = sectorF.centreP.X;
                    double centreY = sectorF.centreP.Y;
                    double r = sectorF.getRadius;
                    double startA = sectorF.startAngle;
                    double sweepA = sectorF.sweepAngle;

                    //外径环
                    e.Graphics.DrawPie(MyPens.Default, sectorF.getOuterSector().x / sizeratio, sectorF.getOuterSector().y/ sizeratio,
                                     sectorF.getOuterSector().width / sizeratio, sectorF.getOuterSector().height / sizeratio,
                                sectorF.getOuterSector().startAngle, sectorF.getOuterSector().sweepAngle);
                    //内径环
                    e.Graphics.DrawPie(MyPens.Default, sectorF.getInnerSector().x / sizeratio, sectorF.getInnerSector().y / sizeratio,
                                     sectorF.getInnerSector().width / sizeratio, sectorF.getInnerSector().height / sizeratio,
                                sectorF.getInnerSector().startAngle, sectorF.getInnerSector().sweepAngle);

                }



            }
            if (selectshape != null)
            {
                if (selectshape is RectangleF)
                {

                    float centerx = selectshape.X + selectshape.Width / 2;
                    float centerY = selectshape.Y + selectshape.Height / 2;
                    e.Graphics.DrawLine(Penused, centerx / sizeratio - 20, centerY / sizeratio, centerx / sizeratio + 20,
                        centerY / sizeratio);
                    e.Graphics.DrawLine(Penused, centerx / sizeratio, centerY / sizeratio - 20, centerx / sizeratio,
                        centerY / sizeratio + 20);
                    e.Graphics.DrawRectangle(MyPens.Select, selectshape.X / sizeratio, selectshape.Y / sizeratio, selectshape.Width / sizeratio, selectshape.Height / sizeratio);
                   
                }
                else if (selectshape is RotatedRectF)
                {
                    RotatedRectF rrect = (RotatedRectF)selectshape;
                    PointF Center = new PointF(rrect.cx / sizeratio, rrect.cy / sizeratio);

                    using (var graph = new GraphicsPath())
                    {
                      
                        graph.AddRectangle(new RectangleF(rrect.getrectofangleEqualZero().X / sizeratio,
                            rrect.getrectofangleEqualZero().Y / sizeratio, rrect.getrectofangleEqualZero().Width / sizeratio,
                            rrect.getrectofangleEqualZero().Height / sizeratio));
                        graph.AddLine(new PointF(rrect.cx / sizeratio, rrect.cy / sizeratio),
                         new PointF((rrect.cx + rrect.Width) / sizeratio, rrect.cy / sizeratio));

                        graph.AddString(rrect.angle.ToString("F3"),
                      new Font("宋体", 12f).FontFamily,
                      (int)FontStyle.Regular,
                      26,
                      new PointF((rrect.cx + rrect.Width + 20) / sizeratio,
                      rrect.cy / sizeratio),
                      StringFormat.GenericDefault);

                        var a = rrect.angle * (Math.PI / 180);
                        var n1 = (float)Math.Cos(a);
                        var n2 = (float)Math.Sin(a);
                        var n3 = -(float)Math.Sin(a);
                        var n4 = (float)Math.Cos(a);
                        var n5 = (float)(Center.X * (1 - Math.Cos(a)) + Center.Y * Math.Sin(a));
                        var n6 = (float)(Center.Y * (1 - Math.Cos(a)) - Center.X * Math.Sin(a));
                        graph.Transform(new Matrix(n1, n2, n3, n4, n5, n6));
                        e.Graphics.DrawPath(MyPens.Select, graph);

                    }
                    e.Graphics.DrawLine(Penused, Center.X - 20, Center.Y , Center .X + 20,
                Center .Y);
                    e.Graphics.DrawLine(Penused, Center.X, Center.Y  - 20, Center.X ,
                        Center.Y  + 20);
                }
                else if (selectshape is CircleF)
                {

                    e.Graphics.DrawLine(Penused, selectshape.centerx / sizeratio - 20, selectshape.centery / sizeratio, selectshape.centerx / sizeratio + 20,
                   selectshape.centery / sizeratio);
                    e.Graphics.DrawLine(Penused, selectshape.centerx / sizeratio, selectshape.centery / sizeratio - 20, selectshape.centerx / sizeratio,
                        selectshape.centery / sizeratio + 20);
                    e.Graphics.DrawEllipse(MyPens.Select, (selectshape.centerx - selectshape.Radius) / sizeratio,
                       (selectshape.centery - selectshape.Radius) / sizeratio, 2 * selectshape.Radius / sizeratio, 2 * selectshape.Radius / sizeratio);

                }
                else if (selectshape is SectorF)
                {

                    e.Graphics.DrawLine(Penused, selectshape.centreP.X / sizeratio - 20, selectshape.centreP.Y / sizeratio, selectshape.centreP.X / sizeratio + 20,
                   selectshape.centreP.Y / sizeratio);
                    e.Graphics.DrawLine(Penused, selectshape.centreP.X / sizeratio, selectshape.centreP.Y / sizeratio - 20, selectshape.centreP.X / sizeratio,
                        selectshape.centreP.Y / sizeratio + 20);

                    e.Graphics.DrawEllipse(MyPens.assist, selectshape.x / sizeratio, selectshape.y / sizeratio,
                     selectshape.width / sizeratio, selectshape.height / sizeratio);

                    e.Graphics.DrawPie(MyPens.Default, selectshape.x / sizeratio, selectshape.y / sizeratio,
                        selectshape.width / sizeratio, selectshape.height / sizeratio,
                    selectshape.startAngle, selectshape.sweepAngle);

                    e.Graphics.DrawRectangle(MyPens.Default, (selectshape.getEndpoint(selectshape.startAngle).X - 10) / sizeratio,
                                  (selectshape.getEndpoint(selectshape.startAngle).Y - 10) / sizeratio,
                                               20 / sizeratio, 20 / sizeratio);
                    e.Graphics.DrawString("1",new Font("宋体",12),new SolidBrush(Color.Red),
                        new PointF((selectshape.getEndpoint(selectshape.startAngle).X +20) / sizeratio,
                        (selectshape.getEndpoint(selectshape.startAngle).Y) / sizeratio));

                    e.Graphics.DrawRectangle(MyPens.Default, (selectshape.getEndpoint(selectshape.getEndAngle).X - 10) / sizeratio,
                                 (selectshape.getEndpoint(selectshape.getEndAngle).Y - 10) / sizeratio,
                                              20 / sizeratio, 20 / sizeratio);
                    e.Graphics.DrawString("2", new Font("宋体", 12), new SolidBrush(Color.Red),
                     new PointF((selectshape.getEndpoint(selectshape.getEndAngle).X + 20) / sizeratio,
                     (selectshape.getEndpoint(selectshape.getEndAngle).Y) / sizeratio));


                    /*--------------*/
                    //外径环
                    e.Graphics.DrawPie(MyPens.Default, selectshape.getOuterSector().x / sizeratio, selectshape.getOuterSector().y / sizeratio,
                                     selectshape.getOuterSector().width / sizeratio, selectshape.getOuterSector().height / sizeratio,
                                selectshape.getOuterSector().startAngle, selectshape.getOuterSector().sweepAngle);
                    //内径环
                    e.Graphics.DrawPie(MyPens.Default, selectshape.getInnerSector().x / sizeratio, selectshape.getInnerSector().y / sizeratio,
                                     selectshape.getInnerSector().width / sizeratio, selectshape.getInnerSector().height / sizeratio,
                                selectshape.getInnerSector().startAngle, selectshape.getInnerSector().sweepAngle);

                }
            }
            RoiChangedHandle?.Invoke(selectshape,e);
        }

      
       //控件尺寸变更
        private void VisionShowControl_SizeChanged(object sender, EventArgs e)
        {
            fitSize();
        }
        /// <summary>
        /// 窗口大小的固定比例
        /// </summary>
        private float winratio;

        private void computeWratio()
        {
            if (image == null) return;
            float windowWH = (float)PanelBox.Width / PanelBox.Height;
            float imgWH = (float)image.Width / image.Height;

            if (windowWH > imgWH)
            {
                PicBox.Height = PanelBox.Height;
                PicBox.Width = (int)(PanelBox.Height * imgWH);
                //Canvas.Height = PanelBox.Height;
                //Canvas.Width = (int)(PanelBox.Height * imgWH);
            }
            else
            {
                PicBox.Width = PanelBox.Width;
                PicBox.Height = (int)(PanelBox.Width / imgWH);
                //Canvas.Width = PanelBox.Width;
                //Canvas.Height = (int)(PanelBox.Width / imgWH);
            }

            this.PicBox.Left = (int)(PanelBox.Width - PicBox.Width) / 2;
            this.PicBox.Top = (int)(PanelBox.Height - PicBox.Height) / 2;

            //this.Canvas.X = (int)(PanelBox.Width - Canvas.Width) / 2;
            //this.Canvas.Y = (int)(PanelBox.Height - Canvas.Height) / 2;

            winratio = (float)image.Width / PanelBox.Width;
            sizeratio = (float)image.Width / PicBox.Width;
            //sizeratio = (float)image.Width / Canvas.Width;
        }
        /// <summary>
        /// 绘制图像的位置和大小
        /// </summary>
        private RectangleF drawimgrect;
        /// <summary>
        /// image对象中要绘制的部分
        /// </summary>
        private RectangleF drawsrcrect;
        /// <summary>
        /// 图像的真实缩放比例
        /// </summary>
        private void computePicratio()
        {
            if (image == null) return;
            sizeratio = (float)image.Width / PicBox.Width;
            //sizeratio = (float)image.Width / Canvas.Width;
            computedrawsize();
        }

        private void computedrawsize()
        {
            if (PicBox.Left < 0)
            {
                //drawimgX = -1 * PicBox.Left;
                drawimgX = -1 * PicBox.Left;
            }
            else
            {
                drawimgX = 0;
            }
            if (PicBox.Top < 0)
            {
                //drawimgY = -1 * PicBox.Top;
                drawimgY = -1 * PicBox.Top;
            }
            else
            {
                drawimgY = 0;
            }
            if (PicBox.Right > PanelBox.Width)
            {
                //float x2 = (PicBox.Right - PanelBox.Width);
                //drawimgW = PanelBox.Width - x2;
                drawimgW = PanelBox.Width;
            }
            else
            {
                drawimgW = PicBox.Right;
            }
            if (PicBox.Bottom > PanelBox.Height)
            {
                //float y2 = (PicBox.Bottom - PanelBox.Height);
                //drawimgH = PanelBox.Height - y2;
                drawimgH = PanelBox.Height;
            }
            else
            {
                drawimgH = PicBox.Bottom;
            }

            drawimgrect = new RectangleF(drawimgX, drawimgY, drawimgW, drawimgH);
            drawsrcrect = new RectangleF(drawimgX * sizeratio, drawimgY * sizeratio, drawimgW * sizeratio,
                drawimgH * sizeratio);
        }

        /// <summary>
        /// 判断鼠标是否在父窗口内移动
        /// </summary>
        /// <returns></returns>
        private bool IsMouseInPanel()
        {

            if (this.PanelBox.Left < PointToClient(Cursor.Position).X
                    && PointToClient(Cursor.Position).X < this.PanelBox.Left
                    + this.PanelBox.Width && this.PanelBox.Top
                    < PointToClient(Cursor.Position).Y && PointToClient(Cursor.Position).Y
                    < this.PanelBox.Top + this.PanelBox.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 绘制圆形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawCircle_Click(object sender, EventArgs e)
        {
            if (this.image == null) return;
            float scaleFactor = this.image.Width / 1000f;         
            shapelist.Add(new CircleF(110 * scaleFactor, 110 * scaleFactor, 100 * scaleFactor));
            updateImage();
        }
    
        private void 自适应toolStripButton_Click(object sender, EventArgs e)
        {
            computeWratio();
            computePicratio();
        }

        public EventHandler 显示中心十字坐标Handle;
        public bool IsShowCenterCross { get; set; }
        private void 十字光标toolStripButton_Click(object sender, EventArgs e)
        {
            if (this.image == null) return;
            if(!IsShowCenterCross)
            {
                int cx = this.image.Width / 2;
                int cy = this.image.Height / 2;
                int width = this.image.Width;
                int height = this.image.Height;
                RegionEx regionEx = new RegionEx(new CrossF(cx, cy, width, height, 50), Color.Red, 2);
                DrawRegion(regionEx);
                AddRegionBuffer(regionEx);
                IsShowCenterCross = true;
                显示中心十字坐标Handle?.Invoke(null, null);
            }
            else
            {
                this.regionExlist.Clear();              
                IsShowCenterCross = false;         
                updateImage();
            }
           
           
        }
        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawRectangle1_Click(object sender, EventArgs e)
        {
            if (this.image == null) return;
            float scaleFactor = this.image.Width/1000f;
            shapelist.Add(new RectangleF(10* scaleFactor, 10 * scaleFactor, 
                          110 * scaleFactor, 110 * scaleFactor));
            updateImage();
        }


        #region 右键菜单   
        public EventHandler LoadedImageNoticeHandle;
        private void 加载图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog m_OpenFileDialog = new OpenFileDialog();
            m_OpenFileDialog.Multiselect = true;
            m_OpenFileDialog.Filter = "JPEG文件,BMP文件|*.jpg*;*.bmp*|所有文件(*.*)|*.*";
            if (m_OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                clearAll();            
                image = new Bitmap(m_OpenFileDialog.FileName);             
                computeWratio();
                computePicratio();
                updateImage();
                LoadedImageNoticeHandle?.Invoke(null,null);
            }
        }
        private void 保存图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image == null) return;

            SaveFileDialog m_SaveFileDialog = new SaveFileDialog();
            m_SaveFileDialog.Filter = "JPEG文件|*.jpg*|BMP文件|*.bmp*";
            m_SaveFileDialog.DereferenceLinks = true;

            if (m_SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string tembuf = m_SaveFileDialog.FilterIndex == 0 ? ".jpg" : ".bmp";
                string name = m_SaveFileDialog.FileName;
                string tempath = string.Concat(name, tembuf);
                ThreadPool.QueueUserWorkItem((s) => image.Save(tempath));
            }        
        }
        private void 清除overlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.shapelist.Clear();
            this.regionExlist.Clear();
            this.textExlist.Clear();
            IsShowCenterCross = false;
            selectshape = null;
            updateImage();
        }
        #endregion

        # region public method
        /// <summary>
        /// 获取绘制ROI集合
        /// </summary>
        /// <returns></returns>
        public List<object> getRoiList()
        {
            return this.shapelist;
        }
        /// <summary>
        /// 获取T类型区域集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> getRoiList<T>()
        {
            List<T> temlist = new List<T>();
            foreach (var s in shapelist)
                if (s is T)
                    temlist.Add((T)s);
            return temlist;        
        }
        /// <summary>
        /// 窗体自适应
        /// </summary>
        public void fitSize()
        {
            computeWratio();
            computePicratio();
        }
        /// <summary>
        /// 图像刷新
        /// </summary>
        public void updateImage()
        {
            if (PicBox.InvokeRequired)
                this.PicBox.Invoke(new Action(updateImage));
            else
                PicBox.Refresh(); 
        }
        /// <summary>
        /// 窗体清除
        /// </summary>
        public void clearAll()
        {        
            if (this.image != null)
            {
                this.image.Dispose();
                this.image = null;
            }              
            this.shapelist.Clear();
            this.regionExlist.Clear();
            this.textExlist.Clear();
            selectshape = null;
            updateImage();
        }

        /// <summary>
        /// 清除图像覆盖
        /// </summary>
        public void clearOverlay()
        {
            this.shapelist.Clear();
            this.regionExlist.Clear();
            this.textExlist.Clear();
            IsShowCenterCross = false;
            selectshape = null;
            updateImage();
        }


       /// <summary>
       /// 显示图像
       /// </summary>
       /// <param name="img"></param>
        public void dispImage(Mat img)
        {
            if (this.image != null)
                this.image.Dispose();
            
            if (img == null || img.Empty() || img.Rows <= 0)
                return;
            Mat imgbuff = new Mat();
            img.CopyTo(imgbuff);
            this.image = BitmapConverter.ToBitmap(imgbuff);  
            if(imageWidth!= img.Width|| imageHeight!= img.Height)
                fitSize();
            updateImage();
            imageWidth = img.Width;
            imageHeight = img.Height;
        }
        /// <summary>
        /// 显示图像
        /// </summary>
        /// <param name="img"></param>
        public void dispImage(Bitmap img)
        {
            if (this.image != null)
                this.image.Dispose();

            if (img == null ||  img.Width <= 0)
                return;

            this.image = img.Clone(new Rectangle(0,0,img.Width, img.Height), img.PixelFormat);
          //  this.image = img;
            if (imageWidth != img.Width || imageHeight != img.Height)
                fitSize();
            updateImage();
            imageWidth = img.Width;
            imageHeight = img.Height;
        }

        private void 旋转矩形toolStripButton_Click(object sender, EventArgs e)
        {
            if (this.image == null) return;
            float scaleFactor = this.image.Width / 1000f;
            shapelist.Add(new RotatedRectF(100 * scaleFactor, 100 * scaleFactor,
                          100 * scaleFactor, 100 * scaleFactor,0));
            updateImage();
        }
        /*// ////////////双击主动获取事件// ////////////*/
        bool isOdd = true;
        DateTime t1, t2;

        private void 扇形toolStripButton_Click(object sender, EventArgs e)
        {
            if (this.image == null) return;
            float scaleFactor = this.image.Width / 1000f;
            shapelist.Add(new SectorF( new PointF(110 * scaleFactor, 110 * scaleFactor) ,100 * scaleFactor, 0,90));
            updateImage();
        }

        private void PicBox_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (isOdd)
            {
                t1 = DateTime.Now;
            }
            else
            {
                t2 = DateTime.Now;
            }
            isOdd = !isOdd;
            if (Math.Abs((t1 - t2).TotalMilliseconds) < 500)
            {
                int _mouseX = (int)(e.X * sizeratio);
                int _mouseY = (int)(e.Y * sizeratio);

                DoubleClickGetMousePosHandle2?.Invoke(_mouseX, _mouseY);
            }
        }
    

    /// <summary>
    /// 绘制区域
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="regionEx"></param>
    public void DrawRegion(RegionEx regionEx)
        {
            if (this.image == null || this.image.Width <= 0 || this.image.Height <= 0)
                return;

            Graphics g = PicBox.CreateGraphics();
            g.drawRegion(regionEx, sizeratio);
            //regionExlist.Add(regionEx);
            //updateImage();
        }
        /// <summary>
        /// 添加到缓存集合
        /// </summary>
        /// <param name="regionEx"></param>
        public void AddRegionBuffer(RegionEx regionEx)
        {
            regionExlist.Add(regionEx);
        }
        /// <summary>
        /// 绘制文本
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="textEx"></param>
        public void DrawText(TextEx textEx)
        {
            if (this.image == null|| this.image.Width<=0|| this.image.Height<=0)
                return;
           
            Graphics g = PicBox.CreateGraphics();
            g.drawText(textEx, sizeratio);
            //textExlist.Add(textEx);
            //updateImage();
        }
        /// <summary>
        /// 添加到缓存集合
        /// </summary>
        /// <param name="textEx"></param>
        public void AddTextBuffer(TextEx textEx)
        {
            textExlist.Add(textEx);

        }

        #endregion

       
    }
    /// <summary>
    /// 画笔
    /// </summary>
    public static class MyPens
    {
        public static Pen Default = new Pen(Color.Red, 1);
        public static Pen Select = new Pen(Color.Blue, 1);

        public static Pen assist = new Pen(Color.Green, 1) { DashStyle= DashStyle.Dash};

    }

  

 
  

   
}
