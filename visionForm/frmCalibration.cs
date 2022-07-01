using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesRAW.Common;
using System.Net.Sockets;
using DeviceLib.Cam;
using System.IO;
using System.Runtime.InteropServices;
using OSLog;
using System.Reflection;
using System.Threading;
using UIDesign;
using System.Diagnostics;
using VisionShowLib;
using DeviceLib;
using FuncToolLib;
using ParamDataLib;
using FuncToolLib.Calibration;
using FuncToolLib.Location;
using ParamDataLib.Location;

using OpenCvSharp;
using OpenCvSharp.Extensions;
using CVPoint = OpenCvSharp.Point;
using CVRect = OpenCvSharp.Rect;
using CVRRect = OpenCvSharp.RotatedRect;
using CVCircle = OpenCvSharp.CircleSegment;
using Rect = System.Drawing.RectangleF;
using Point = System.Drawing.PointF;

namespace visionForm
{
    /// <summary>
    /// 手自动标定模式
    /// </summary>
    public partial class frmCalibration : Form
    {
        /// <summary>
        /// 将改代码放置在父界面即可重载父界面及其子界面的双缓冲机制
        /// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        /*--------------------------------------------------------------------------------*/     
        public EventHandler setCalCentreHandle;//参数保存返回事件,供外部订阅可获取旋转中心
        public EventHandler setUserPointHandle;//参数保存返回事件,供外部订阅可获取用户坐标
        public EventHandler setModelPointHandle;//模板匹配排序点位数据
        public EventHandler AutoFocusDataHandle;//自动对焦事件


        public EventHandler setProductAngleDataHandle;//产品倾斜弧度数据
        public EventHandler CamParmasChangeHandle;//参数保存返回事件,供外部订阅可获相机参数
        public EventHandler CamConnectStatusHandle;//相机链接状态时间
        public EventHandler RobotTeachDataHandle = null;//参数保存返回事件,供外部订阅可获工具示教相关参数
        public EventHandler SaveCaliParmaHandleOfNightPoint = null;//参数保存返回事件,供外部订阅可获取坐标系变换矩阵
        public EventHandler SaveMarkProductPointsHandle = null;//参数保存返回事件,供外部订阅可获取产品排序相关参数
        public EventHandler SaveTCPparmasHandle = null;//参数保存返回事件,供外部订阅可获取TCP连接相关参数
        public EventHandler SaveModelparmasHandle = null;//参数保存返回事件,供外部订阅可获取模板匹配相关参数

        //////////////////////////
        public delegate void CamContinueGrabHandle(bool isGrabing);
        public CamContinueGrabHandle camContinueGrabHandle;
        int i = 0, j = 0, k = 0, m = 0;
        int CheckBoxselectID = -1;

        // 双击获取像素坐标
        public OutPointGray DoubleClickGetMousePosHandle;
        /*------------------------------------标定数据--------------------------------*/
        pixelPointDataClass d_pixelPointDataClass = null;    
        robotPointDataClass d_robotPointDataClass = null;
        converCoorditionDataClass d_converCoorditionDataClass = null;
        RotatePointDataClass d_RotatePointDataClass = null;      
        RotateCentrePointDataClass d_RotateCentrePointDataClass = null;

        ////图像显示控件
        VisionShowControl currvisiontool = null;
        //当前采集图像
        Mat GrabImg = null;
        //日志
        Log log = new Log("视觉");
        string modelOrigion = "0,0,0"; //产品模板基准点
        MatchBaseInfo matchBaseInfo = null;//基准轮廓信息
        static object locker1 = new object();
        string CurrRecipeName = string.Empty;//当前配方名称
        /*-----------------------------------相机---------------------------------------------*/
        Icam CurrCam = null;  //相机接口
        CamType currCamType = CamType.NONE;    
        EunmcurrCamWorkStatus workstatus = EunmcurrCamWorkStatus.None;//当前相机工作状态
        //标定单点相机检测状态
        Dictionary<int, bool> NinePointStatusDic = new Dictionary<int, bool>();
        //标定单点相机检测状态
        Dictionary<int, bool> RotatoStatusDic = new Dictionary<int, bool>();
        /*-----------------------------------工具和参数--------------------------------------------*/
        IRunTool runTool = null;
        ParmasDataBase parmaData = null;
        Result ResultOfToolRun;
        Mat Hom_mat2d;
        List<Point2d> pixelList = new List<Point2d>();
        List<Point2d> robotList = new List<Point2d>();
        /*-----------------------------------工具结果--------------------------------------------*/
        //直线1
        StuLineResultData  StuLineResultData=new StuLineResultData(false) ;
        double line1AngleLx = 0, line2AngleLx = 0;
        //直线2
        StuLineResultData  StuLineResultData2 = new StuLineResultData(false);
        //模板
        StuModelMatchData stuModelMatchData=new StuModelMatchData(false);
        //圆
        StuCircleResultData stuCircleResultData = new StuCircleResultData(false);
        //Blob
        StuBlobResultData stuBlobResultData = new StuBlobResultData(false);
        //自动圆匹配
        OutPutDataOfCircleMatch outPutDataOfCircleMatch = new OutPutDataOfCircleMatch();

        /*-----------------------------------窗体---------------------------------------------*/
        Dictionary<string, TabPage> TabPages = new Dictionary<string, TabPage>();

        frmrecipe mp = null;
        static frmCalibration _frmCalibration2 = null;
        /*----------------------------------检测区域----------------------------------------------*/
        //矩形
        private CVRect RegionaRect ;//Blob使用
       //旋转矩形
        private CVRRect temBuffRegionRRect;
        private CVRRect RegionRRect ;//找直线使用
        private CVRRect RegionRRect2;//找直线2使用
        //圆形          
        private SectorF sectorF; //找圆使用
        //定位工具搜索区域
        public List<object> SearchROI1 = new List<object>();//模板P1
        public List<object> SearchROI2 = new List<object>();//模板P2
        public List<object> SearchROI3 = new List<object>();//模板胶水
        /*--------------------------------------------------------------------------------*/
        //工具集合
        List<string> toolList = new List<string>();
        //当前模板类型
        EumModelType currModelType;
        //模板
        Mat modeltp = new Mat();
        CVPoint[] templateContour = default; int coutourLen = 0; double contourArea = 0;
        //模板创建区域
        RectangleF setModelROIData;

        /*----以下文件需要随着模板文件保存，且需要一一对应---------*/
        string CirleMatchconfigPath = "圆匹配参数.ini";
        string Line1configPath = "直线1参数.ini";
        string Line2configPath = "直线2参数.ini";
        string CircleconfigPath = "圆参数.ini";
        string BlobconfigPath = "Blob参数.ini";
        string inspectToolPath = "附加检测工具.searchroi";
        /*----------------------------------------------------------------*/

        #region --------Construction-----------

        private frmCalibration()
        {

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Config"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Config");
       
            InitializeComponent();
          
            richTxb.ContextMenuHandle += new EventHandler(ContextMenuEvent);
        
            listViewPixel.Columns[1].Width = (listViewPixel.Width - 30) / 2;
            listViewPixel.Columns[2].Width = (listViewPixel.Width - 30) / 2;
            listViewRobot.Columns[1].Width = (listViewRobot.Width - 30) / 2;
            listViewRobot.Columns[2].Width = (listViewRobot.Width - 30) / 2;
            currvisiontool =new VisionShowControl();
            currvisiontool.Dock = DockStyle.Fill;         
            currvisiontool.Padding = new Padding(2);          
            currvisiontool.LoadedImageNoticeHandle += new EventHandler(LoadedImageNoticeEvent);   
            currvisiontool.显示中心十字坐标Handle += new EventHandler(显示中心十字坐标Event);
            currvisiontool.RoiChangedHandle += new EventHandler(RoiChangedEvent);
            currvisiontool.DoubleClickGetMousePosHandle2 += new OutPointGray(DoubleClickGetMousePosEvent2);
            this.uiPanel2.Controls.Clear();
            this.uiPanel2.Controls.Add(currvisiontool);

            listViewFlow.Columns[0].Width = 40;
            listViewFlow.Columns[1].Width = listViewFlow.Width - 40;

            foreach (var s in LinesIntersectPanel.Controls)
            {
                if (s is NumericUpDown)
                    (s as NumericUpDown).MouseWheel += new MouseEventHandler(Num_DiscountAmount_MouseWheel);
                if (s is ComboBox)
                    (s as ComboBox).MouseWheel += new MouseEventHandler(Num_DiscountAmount_MouseWheel);
            }
            foreach (var s in FindCirclePanel.Controls)
            {
                if (s is NumericUpDown)
                    (s as NumericUpDown).MouseWheel += new MouseEventHandler(Num_DiscountAmount_MouseWheel);
                if (s is ComboBox)
                    (s as ComboBox).MouseWheel += new MouseEventHandler(Num_DiscountAmount_MouseWheel);
            }
            foreach (var s in BlobCentrePanel.Controls)
            {
                if (s is NumericUpDown)
                    (s as NumericUpDown).MouseWheel += new MouseEventHandler(Num_DiscountAmount_MouseWheel);
            }
            foreach (var s in ModelMactPanel.Controls)
            {
                if (s is NumericUpDown)
                    (s as NumericUpDown).MouseWheel += new MouseEventHandler(Num_DiscountAmount_MouseWheel);
            }
           
            cobxModelType.MouseWheel += new MouseEventHandler(Num_DiscountAmount_MouseWheel);
         
          
            //-----------------DLL库
            virtualConnect = new VirtualConnect("虚拟连接A");
            BuiltConnect();
            setOperationAuthority();

            foreach (TabPage s in uiTabControl1.TabPages)
                TabPages.Add(s.Text,s);
            setStyle(false);
            uiTabControl1.TabBackColor = Color.FromArgb(255, 109, 60);
            uiTabControl1.TabSelectedColor = Color.White;
            uiTabControl1.FillColor = Color.FromArgb(255,255,255);
            uiTabControl1.TabSelectedForeColor = Color.FromArgb(255, 109, 60);
            uiTabControl1.TabSelectedHighColor = Color.White;
         
        } 
        public static frmCalibration CreateInstance()
        {
            if (_frmCalibration2 == null)
                _frmCalibration2 = new frmCalibration();
            return _frmCalibration2;
        }
      
        #endregion

        #region ---------Property--------------
        /// <summary>
        /// 相机是否在线状态
        /// </summary>
        public bool IsCamAlive
        {
            get
            {
                if (CurrCam == null)
                    return false;
                return this.CurrCam.IsAlive;
            }

        }

        /// <summary>
        /// 窗体样式
        /// </summary>
        [DefaultValue(FormBorderStyle.None)]
        public FormBorderStyle CalibFormBorderStyle
        {
            get;
            set;
        }
        /// <summary>
        /// 是否启用窗体隐藏
        /// </summary>
        [DefaultValue(false)]
        public bool shouldHide
        {
            get;
            set;

        }


        #endregion

        #region---------Menu菜单项------------
        private void listViewFlow_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            listViewFlow.FullRowSelect = true;


            if (this.listViewFlow.SelectedItems.Count > 0)
            {

                //listViewFlow.SelectedItems[0].SubItems[0].ForeColor = Color.Blue;

                //先清除原有格式

                foreach (ListViewItem item in listViewFlow.Items)
                {
                    item.ForeColor = Color.Black;
                }
                foreach (ListViewItem item in listViewFlow.Items)
                {
                    //item.BackColor = System.Drawing.SystemColors.ControlLight; 
                    item.BackColor = Color.White;
                    Font f = new Font(Control.DefaultFont, FontStyle.Regular);
                    item.Font = f;
                }

                //加粗字体
                Font f2 = new Font(Control.DefaultFont, FontStyle.Bold);
                listViewFlow.SelectedItems[0].SubItems[0].Font = f2;
                //设置选中行背景颜色
                listViewFlow.SelectedItems[0].BackColor = Color.FromArgb(255, 109, 60);
                //listViewFlow.SelectedItems[0].Selected = false;
            }

        }

        private void 清除ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.richTxb.ClearText();
        }
        //日志清除
        void ContextMenuEvent(object sender, EventArgs e)
        {
            this.richTxb.ClearText();
        }        
        void 显示中心十字坐标Event(object sender, EventArgs e)
        {
          

        }
        void LoadedImageNoticeEvent(object sender, EventArgs e)
        {    
            if(GrabImg!=null)   
               GrabImg.Dispose();
            GrabImg = MatExtension.BitmapToGrayMat( currvisiontool.Image);            
            RunToolStep = 0;         
        }
        private void frmCalibration3_Load(object sender, EventArgs e)
        {
             //配方加载             
            RecipeSaveEvent(null, null);
            //加载相机参数      
            loadCamParmas();

            isAutoAutoCoorSys = bool.Parse(GeneralUse.ReadValue("坐标系", "同步", "config", "True"));
            chxbAutoCoorSys.Checked = isAutoAutoCoorSys;
            
            //isUsePixelCoordinate = bool.Parse(GeneralUse.ReadValue("圆心计算", "像素坐标", "config", "false"));
                
            SetParametersHide(false);
             //单例模式
            mp = frmrecipe.CreateInstance();
            mp.RecipeSaveHandle = new EventHandler(RecipeSaveEvent);
            //  mp.Owner = this;        
            mp.TopMost = true;
            mp.WindowState = FormWindowState.Normal;
            mp.StartPosition = FormStartPosition.CenterScreen;
            mp.Show();
            mp.Hide();
            
        }
        public void frmCalibration3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (shouldHide)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
                Release();
        }

        /// <summary>
        /// 窗体关闭前资源释放
        /// </summary>
        public void Release()
        {
            FreeConsole();//释放控制台
          
            currvisiontool.Dispose();
          
            if (CurrCam != null)
            {
                CurrCam.CloseCam();
                CurrCam.setImgGetHandle -= getImageDelegate;

            }
            if (GrabImg != null) GrabImg.Dispose();      
            Disconnect();
            //this.Dispose();
            _frmCalibration2 = null;
        }
        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selecttablename = (sender as TabControl).SelectedTab.Name;
            if (selecttablename == "tabPage1")
            {
                listViewPixel.Columns[1].Width = (listViewPixel.Width - 30) / 2;
                listViewPixel.Columns[2].Width = (listViewPixel.Width - 30) / 2;
            }
            else if (selecttablename == "tabPage2")
            {

                listViewRobot.Columns[1].Width = (listViewRobot.Width - 30) / 2;
                listViewRobot.Columns[2].Width = (listViewRobot.Width - 30) / 2;
            }
        }

        #endregion

        #region--------Common Method----------

        /// <summary>
        /// OpenCv旋转矩形转矩形
        /// </summary>
        /// <param name="cVRRect"></param>
        /// <param name="cVRect"></param>
        public void shapeConvert( CVRRect cVRRect,out  CVRect cVRect)
        {
            double cx = cVRRect.Center.X;
            double cy = cVRRect.Center.Y;
            double angle = cVRRect.Angle;
            double width = cVRRect.Size.Width;
            double height = cVRRect.Size.Height;

            Point2f[] vertexPs = cVRRect.Points();
            Point2f[] NewvertexPs = new Point2f[4];
            
            for(int i=0;i<4;i++)
            {
                NewvertexPs[i]= AxisCoorditionRotation.get_after_RotatePoint(vertexPs[i],
                new Point2f((float)cx, (float)cy), -angle);
            }

            double topx=9999, topy = 9999;
            for (int j = 0; j < 4; j++)
            {
                if ((NewvertexPs[j].X<= topx-10&& NewvertexPs[j].X >0)||
                    ( NewvertexPs[j].Y<= topy-10&& NewvertexPs[j].Y>=0))
                {
                    topx = NewvertexPs[j].X;
                    topy = NewvertexPs[j].Y;
                }
            }

            cVRect = new CVRect((int)topx, (int)topy, (int)width, (int)height);
        }

        /// <summary>
        /// OpenCv矩形转旋转矩形
        /// </summary>
        /// <param name="cVRect"></param>
        /// <param name="cVRRect"></param>
        /// <param name="angle"></param>
        public void shapeConvert(CVRect cVRect, out CVRRect cVRRect,float angle = 0)
        {
            cVRRect = new CVRRect( new Point2f(cVRect.X+ cVRect.Width/2, cVRect.Y+ cVRect.Height/2),
           new Size2f ( cVRect.Width, cVRect.Height), angle);
        }
        /// <summary>
        /// OpenCv旋转矩形转自定义旋转矩形
        /// </summary>
        /// <param name="cVRRect"></param>
        /// <param name="rotatedRectF"></param>
        public void shapeConvert(CVRRect  cVRRect, out RotatedRectF rotatedRectF)
        {
            rotatedRectF = new RotatedRectF(cVRRect.Center.X, cVRRect.Center.Y,
                cVRRect.Size.Width, cVRRect.Size.Height, cVRRect.Angle);
        }
        /// <summary>
        /// 自定义旋转矩形转OpenCv旋转矩形
        /// </summary>
        /// <param name="rotatedRectF"></param>
        /// <param name="cVRRect"></param>
        public void shapeConvert(RotatedRectF rotatedRectF, out CVRRect cVRRect)
        {
            cVRRect = new CVRRect(new Point2f(rotatedRectF.cx, rotatedRectF.cy),
                new Size2f(rotatedRectF.Width, rotatedRectF.Height), rotatedRectF.angle);
        }
        /// <summary>
        /// OpenCv矩形转自定义矩形
        /// </summary>
        /// <param name="cVRect"></param>
        /// <param name="rectangleF"></param>
        public void shapeConvert(CVRect  cVRect, out RectangleF  rectangleF)
        {
            rectangleF = new RectangleF(cVRect.X, cVRect.Y, cVRect.Width, cVRect.Height);
        }
        /// <summary>
        /// 自定义矩形转OpenCv矩形
        /// </summary>
        /// <param name="rectangleF"></param>
        /// <param name="cVRect"></param>
        public void shapeConvert( RectangleF rectangleF,out CVRect cVRect)
        {
            cVRect = new CVRect((int)rectangleF.X, (int)rectangleF.Y, (int)rectangleF.Width, (int)rectangleF.Height);
        }


        /// <summary>
        /// 像素坐标转物理坐标
        /// </summary>
        /// <param name="pixelX"></param>
        /// <param name="pixelY"></param>
        /// <param name="convertPosX"></param>
        /// <param name="convertPosY"></param>
        public void PixelToPoint(double pixelX, double pixelY,
                             ref double convertPosX, ref double convertPosY)
        {
            Point2d robotP = CalibrationTool.AffineTransPoint2d(Hom_mat2d, 
                new Point2d(pixelX, pixelY));

            convertPosX = Math.Round(robotP.X, 3);
            convertPosY = Math.Round(robotP.Y, 3);
        }
        /// <summary>
        /// 双击获取
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DoubleClickGetMousePosEvent2(int x, int y)
        {
            DoubleClickGetMousePosHandle?.Invoke(x, y);

        }
        void checkedControl(string dirFileName)
        {

            if (currModelType == EumModelType.ProductModel_1)
            {
                //附加工具
                CheckBoxselectID = int.Parse(GeneralUse.ReadValue("附加工具", "工具编号",
                  "附加工具类型", "-1", dirFileName + "\\" +
                  "modelfile\\ProductModel_1"));
                ExchangeSelect(CheckBoxselectID);
            }
            else if (currModelType == EumModelType.ProductModel_2)
            {
                //附加工具
                CheckBoxselectID = int.Parse(GeneralUse.ReadValue("附加工具", "工具编号",
                 "附加工具类型", "-1", dirFileName + "\\" +
                 "modelfile\\ProductModel_2"));
                ExchangeSelect(CheckBoxselectID);
            }
            else if (currModelType == EumModelType.CalibModel)
            {
                //附加工具
                CheckBoxselectID = -1;
                ExchangeSelect(CheckBoxselectID);
            }
            else
            {
                //附加工具
                CheckBoxselectID = int.Parse(GeneralUse.ReadValue("附加工具", "工具编号",
                  "附加工具类型", "-1", dirFileName + "\\" +
                  "modelfile\\GlueTapModel"));
                ExchangeSelect(CheckBoxselectID);
            }
        }

        /// <summary>
        /// 复制文件夹及文件
        /// </summary>
        /// <param name="sourceFolder">原文件路径</param>
        /// <param name="destFolder">目标文件路径</param>
        /// <returns></returns>
        bool CopyFolder(string sourceFolder, string destFolder)
        {
            try
            {
                //如果目标路径不存在,则创建目标路径
                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);
                //得到原文件根目录下的所有文件
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(destFolder, name);
                    File.Copy(file, dest, true);//复制文件
                }
                //得到原文件根目录下的所有文件夹
                string[] folders = Directory.GetDirectories(sourceFolder);
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);
                    CopyFolder(folder, dest);//构建目标路径,递归复制文件
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }
        /// <summary>
        /// 添加测试文本及日志
        /// </summary>
        /// <param name="txt"></param>
        void Appentxt(string info)
        {
            if (richTxb.InvokeRequired)
            {
                richTxb.Invoke(new Action<string>(Appentxt), info);
            }
            else
            {
                string dConvertString = "";
                if (!richTxb.Disposing)
                {
                    if (richTxb.TextLength > 2000)
                        richTxb.ClearText();
                    dConvertString = string.Format("{0}  {1}\r",
                           DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), info);
                    richTxb.AppendText(dConvertString);
                    richTxb.ScrollToCaret();
                }
                log.Info("测试信息", info);
            }
        }
        /// <summary>
        /// 参数设置画面
        /// </summary>
        /// <param name="isOpenAllFunctions">是否启用功能简化</param>
        public  void setStyle(bool isOpenAllFunctions)
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            txbMarkPixelX.RectColor = Color.FromArgb(255,109,60);
            txbMarkPixelY.RectColor = Color.FromArgb(255, 109, 60);
            txbMarkRobotX.RectColor = Color.FromArgb(255, 109, 60);
            txbMarkRobotY.RectColor = Color.FromArgb(255, 109, 60);
            CamExposureBar.RectColor = Color.FromArgb(255, 109, 60);
            CamGainBar.RectColor = Color.FromArgb(255, 109, 60);
          

            this.uiTabControl1.SuspendLayout();       
            this.SuspendLayout();
            // 
            this.uiTabControl1.FillColor = Color.White;
            //this.uiTabControl1.TabPages.Clear();
             if (isOpenAllFunctions)
            {
                TabPages["相机设置"].Parent = this.uiTabControl1;
                TabPages["定位检测"].Parent = this.uiTabControl1;
               
                TabPages["像素坐标"].Parent = this.uiTabControl1;
                TabPages["物理坐标"].Parent = this.uiTabControl1;
                TabPages["坐标变换"].Parent = this.uiTabControl1;
                TabPages["旋转中心"].Parent = this.uiTabControl1;
              
            }
             else
            {
                TabPages["相机设置"].Parent = this.uiTabControl1;
                TabPages["定位检测"].Parent = this.uiTabControl1;
             
                TabPages["像素坐标"].Parent = null;
                TabPages["物理坐标"].Parent = null;
                TabPages["坐标变换"].Parent = null;
                TabPages["旋转中心"].Parent = null;
              
            }
            this.uiTabControl1.ResumeLayout(false);
            this.uiTabControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        ///  相机曝光设置
        ///  默认值为5000
        /// </summary>
        /// <param name="dValue">设置曝光参数</param>
        /// <returns>返回设置是否成功标志</returns>
        public bool SetExposure(long dValue)
        {
            if(CurrCam==null)
            {
                Appentxt("相机未实例化！");
                return false;
            }
            if (CurrCam.IsAlive)
            {
                Appentxt("相机未链接！");
                return false;
            }
            if(dValue<1000|| dValue>200000)
            {
                Appentxt("请设置1000~200000之间合适的整数！");
                return false;
            }
            return CurrCam.SetExposureTime(dValue);          
        }
        /// <summary>
        /// 相机增益设置
        /// 默认值为0
        /// </summary>
        /// <param name="dValue">设置增益参数</param>
        /// <returns>返回设置是否成功标志</returns>
        public bool SetGain(long dValue)
        {
            if (CurrCam == null)
            {
                Appentxt("相机未实例化！");
                return false;
            }
            if (CurrCam.IsAlive)
            {
                Appentxt("相机未链接！");
                return false;
            }
            if (dValue < 0 || dValue > 10)
            {
                Appentxt("请设置0~10之间合适的整数！");
                return false;
            }
            return CurrCam.SetGain(dValue);
        }
        /// <summary>
        /// 设置图像采集自由模式
        /// </summary>
        public void SetCameraFreeStyle()
        {
            workstatus = EunmcurrCamWorkStatus.freestyle;
        }

        EumOperationAuthority currOperationAuthority = EumOperationAuthority.None;
        /// <summary>
        /// 设置操作权限
        /// </summary>
        /// <param name="eumOperationAuthority">操作人员类型</param>
        public  void setOperationAuthority(EumOperationAuthority eumOperationAuthority=
              EumOperationAuthority.None)
        {      
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<EumOperationAuthority>(setOperationAuthority), eumOperationAuthority);
            }
            else
            {
                currOperationAuthority = eumOperationAuthority;
                Appentxt(string.Format("当前操作人员类型：{0}", Enum.GetName(typeof(EumOperationAuthority),
                                currOperationAuthority)));
                switch (eumOperationAuthority)
                {
                    case EumOperationAuthority.Operator:
                        setOperator();
                        break;
                    case EumOperationAuthority.Programmer:
                        setProgrammer();
                        break;
                    case EumOperationAuthority.Administrators:
                        setAdministrators();
                        break;
                    default:
                        setNone();
                        break;
                }

            }
        }
        /// <summary>
        /// 无任何权限
        /// </summary>
        void setNone()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(setNone));
            }
            else
            {
                CamTypeSetBox.Enabled = false;
                CamParmasSetBox.Enabled = false;
                ImageGrabToolBox.Enabled = false;
              
                LogShowBox.Enabled = false;
              
                LocationDectionSetBox.Enabled = false;
                NinePointsOfPixelGetBox.Enabled = false;
                NinePointsOfPixelDatBox.Enabled = false;
                NinePointsOfRobotGetBox.Enabled = false;
                NinePointsOfRobotDatBox.Enabled = false;
                CoordinateTransBox.Enabled = false;
                RotatePixelGetBox.Enabled = false;
                RotateCalBox.Enabled = false;
                RotateOfPixelDatBox.Enabled = false;
              
            }          
        }
        /// <summary>
        /// 设置为操作员
        /// </summary>
        void setOperator()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(setOperator));
            }
            else
            {
                CamTypeSetBox.Enabled = true;
                CamParmasSetBox.Enabled = false;
                ImageGrabToolBox.Enabled = false;
               
                LogShowBox.Enabled = false;
              
                LocationDectionSetBox.Enabled = false;
                NinePointsOfPixelGetBox.Enabled = false;
                NinePointsOfPixelDatBox.Enabled = false;
                NinePointsOfRobotGetBox.Enabled = false;
                NinePointsOfRobotDatBox.Enabled = false;
                CoordinateTransBox.Enabled = false;
                RotatePixelGetBox.Enabled = false;
                RotateCalBox.Enabled = false;
                RotateOfPixelDatBox.Enabled = false;
               
                if (CurrCam != null)
                    EnableCam(CurrCam.IsAlive);
            }         
        }
        /// <summary>
        /// 设置为程序员
        /// </summary>
        void setProgrammer()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(setProgrammer));
            }
            else
            {
                CamTypeSetBox.Enabled = true;
                CamParmasSetBox.Enabled = true;
                ImageGrabToolBox.Enabled = true;
              
                LogShowBox.Enabled = true;
            
                LocationDectionSetBox.Enabled = true;
                NinePointsOfPixelGetBox.Enabled = true;
                NinePointsOfPixelDatBox.Enabled = true;
                NinePointsOfRobotGetBox.Enabled = true;
                NinePointsOfRobotDatBox.Enabled = true;
                CoordinateTransBox.Enabled = true;
                RotatePixelGetBox.Enabled = true;
                RotateCalBox.Enabled = true;
                RotateOfPixelDatBox.Enabled = true;
               
                if (CurrCam != null)
                    EnableCam(CurrCam.IsAlive);
                EnableDetectionControl();
            }        
        }
        /// <summary>
        /// 设置为管理员
        /// </summary>
        void setAdministrators()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(setAdministrators));
            }
            else
            {
                CamTypeSetBox.Enabled = true;
                CamParmasSetBox.Enabled = true;
                ImageGrabToolBox.Enabled = true;
              
                LogShowBox.Enabled = true;
             
                LocationDectionSetBox.Enabled = true;
                NinePointsOfPixelGetBox.Enabled = true;
                NinePointsOfPixelDatBox.Enabled = true;
                NinePointsOfRobotGetBox.Enabled = true;
                NinePointsOfRobotDatBox.Enabled = true;
                CoordinateTransBox.Enabled = true;
                RotatePixelGetBox.Enabled = true;
                RotateCalBox.Enabled = true;
                RotateOfPixelDatBox.Enabled = true;
            
                if (CurrCam != null)
                    EnableCam(CurrCam.IsAlive);
                EnableDetectionControl();
            }          
        }
        /// <summary>
        /// 创建配方
        /// ecipeName=配方名称
        /// </summary>
        /// <param name="recipeName"></param>
        public void createRecipe(string recipeName)
        {
            mp.CreateRecipe(recipeName);

        }

        /// <summary>
        /// 删除配方
        ///recipeName=配方名称
        /// </summary>
        /// <param name="recipeName"></param>
        public void DeleteRecipe(string recipeName)
        {
            mp.DeleteRecipe(recipeName);
        }

        /// <summary>
        /// 保存配方
        /// return:true表示保存成功，false表示保存失败
        /// </summary>
        public bool SaveRecipe()
        {
            return mp.SaveRecipe();
        }
        /// <summary>
        /// 配方切换
        /// recipeName=配方名称
        /// </summary>
        /// <param name="recipeName">配方名称</param>
        public void RecipeSwitching(string recipeName)
        {
            if (CurrRecipeName == recipeName)
            {
                Appentxt("当前使用配方与需要切换的同名！");
                return;
            }

            mp.SwitchRecipe(recipeName);
            //string temvalue = GeneralUse.ReadValue("配方", "使用路径", "config");
            //RecipeSaveEvent(temvalue, null);
        }

        /// <summary>
        /// 获取当前使用配方名称
        /// return返回当前使用配方名称
        /// </summary>
        /// <returns>当前使用配方名称</returns>
        public string getCurrRecipeName()
        {
            return CurrRecipeName;
        }

        /// <summary>
        /// 获取配方名
        /// return:配方名集合
        /// </summary>
        /// <returns>配方名集合</returns>
        public List<string> GetRecipeName()
        {
            return mp.GetRecipeName();
        }

        /// <summary>
        /// 加载配方文件,附带文件自主校验
        /// path：需要加载得配方文件完整路径
        /// recipeName:重命名为recipeName;
        /// IsUse：加载后是否直接启用，默认启用
        /// </summary>
        /// <param name="path">需要加载得配方文件完整路径</param>
        /// <param name="recipeName">重命名为recipeName</param>
        /// <param name="IsUse">加载后是否直接启用，默认启用</param>
        /// <returns></returns>
        public bool AddRecipeFile(string path, string recipeName, bool IsUse = true)
        {
            return mp.AddRecipeFile(path, recipeName, IsUse);
        }

        /// <summary>
        /// 将配方文件recipeName导出到特定文件路径path
        /// path:文件路径
        /// recipeName:配方文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="recipeName">配方文件</param>
        /// <returns></returns>
        public bool ExportRecipe(string path, string recipeName)
        {
            return mp.ExportRecipe(path, recipeName);
        }
      
        /// <summary>
        /// 折叠参数界面
        /// </summary>
        /// <param name="value">true:折叠/false:取消折叠</param>
        public void SetParametersHide(bool value)
        {
            uiPanel1.Visible = !value;
          
        }

        void ExchangeSelect(int selectvalue)
        {
            switch (selectvalue)
            {
                case -1:
                    chxbLinesIntersect.Checked = false;
                    chxbFindCircle.Checked = false;
                    chxbBlobCentre.Checked = false;
                  
                    break;
                case 1:          
                    
                    chxbLinesIntersect.Checked = true;
                    chxbFindCircle.Checked = false;
                    chxbBlobCentre.Checked = false;
                  
                    break;
                case 2:
                    chxbLinesIntersect.Checked = false;
                    chxbFindCircle.Checked = true;
                    chxbBlobCentre.Checked = false;
                   
                    break;
                case 3:
                    chxbLinesIntersect.Checked = false;
                    chxbFindCircle.Checked = false;
                    chxbBlobCentre.Checked = true;
                   
                    break;           
            }


        }

        static string getDescription(Enum obj)
        {
            string objName = obj.ToString();
            Type t = obj.GetType();
            FieldInfo fi = t.GetField(objName);

            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return arrDesc[0].Description;
        }
        //校验字符串是否为有效数值
        bool checkValueNumber(string txt)
        {
            float temvalue = 0f;
            return float.TryParse(txt, out temvalue);
        }
        //给控件Listview赋值
        void SetValueToListItem(ListView lv, string[] temvalueArray)
        {
            ListViewItem lvi = new ListViewItem(temvalueArray);
            lv.Items.Add(lvi);
        }

        /// <summary>
        /// 连续采集
        /// </summary>
        /// <returns></returns>
        public bool ContinueGrab()
        {
            workstatus = EunmcurrCamWorkStatus.freestyle;
            if (CurrCam == null) return false;
            if (!CurrCam.IsAlive) return false;
            if (CurrCam.IsGrabing)
                CurrCam.StopGrab();  //如果已在采集中则先停止采集
            Thread.Sleep(5);
            bool flag=  CurrCam.ContinueGrab();
            this.Invoke(new Action(() => {
                if (flag)
                {
                    btnContinueGrab.Enabled = false;
                    btnOneShot.Enabled = false;
                    btnStopGrab.Enabled = true;
                    btnGetPixelPoint.Enabled = false;
                    btnGetRotataPixel.Enabled = false;
                }
                else
                {
                    btnContinueGrab.Enabled = true;
                    btnOneShot.Enabled = true;
                    btnStopGrab.Enabled = false;
                    btnGetPixelPoint.Enabled = true;
                    btnGetRotataPixel.Enabled = true;
                }

            }));          
            return flag;
        }
        /// <summary>
        /// 停止采集
        /// </summary>
        /// <returns></returns>
        public bool StopGrab()
        {
            if (CurrCam == null) return true;
            if (!CurrCam.IsAlive) return true;         
            CurrCam.StopGrab();
            this.Invoke(new Action(() => {
                btnContinueGrab.Enabled = true;
                btnOneShot.Enabled = true;
                btnStopGrab.Enabled = false;
                btnGetPixelPoint.Enabled = true;
                btnGetRotataPixel.Enabled = true;

            }));         
            return CurrCam.IsGrabing;
        }
        /// <summary>
        /// 单帧采集
        /// </summary>
        /// <returns></returns>
        public bool OneShot()
        {
            if (CurrCam == null) return false;
            if (!CurrCam.IsAlive) return false;
            return CurrCam.OneShot();
        }
        #endregion

        #region------------CAM----------------
   
        public void Run()
        {
            if (CurrCam == null || !CurrCam.IsAlive) return;
            this.Invoke(new Action(() =>
            {
                cobxModelType.SelectedIndex = 0;
            }));
            workstatus = EunmcurrCamWorkStatus.NormalTest_T1;
            CurrCam.OneShot();    //单次采集
            Appentxt("开始自动检测,使用模板为产品1模板！");

        }

        delegate void SaveImgHandle(string path);
       
        void CamConnectEvent(object sender, EventArgs e)
        {
            CamConnectStatusHandle?.Invoke(sender, e);
        }

        //相机单帧采集
        private void btnOneShot_Click(object sender, EventArgs e)
        {
            workstatus = EunmcurrCamWorkStatus.freestyle;
            CurrCam.OneShot();
        }
        //相机连续采集
        private void btnContinueGrab_Click(object sender, EventArgs e)
        {
            workstatus = EunmcurrCamWorkStatus.freestyle;
            CurrCam.ContinueGrab();
            btnContinueGrab.Enabled = false;
            btnOneShot.Enabled = false;
            btnStopGrab.Enabled = true;
            btnGetPixelPoint.Enabled = false;
            btnGetRotataPixel.Enabled = false;
            camContinueGrabHandle?.Invoke(true);
        }
        //相机停止采集
        private void btnStopGrab_Click(object sender, EventArgs e)
        {
            CurrCam.StopGrab();
            btnContinueGrab.Enabled = true;
            btnOneShot.Enabled = true;
            btnStopGrab.Enabled = false;
            btnGetPixelPoint.Enabled = true;
            btnGetRotataPixel.Enabled = true;
            camContinueGrabHandle?.Invoke(false);
        }
        //相机参数保存事件
        private void btnSaveCamParma_Click(object sender, EventArgs e)
        {

            GeneralUse.WriteValue("相机", "型号", cobxCamType.SelectedItem.ToString(), "config");
            GeneralUse.WriteValue("相机", "索引", CamIndex.ToString(), "config");
            GeneralUse.WriteValue("相机", "曝光", ((int)numCamExposure.Value).ToString(), "config", "配方\\" + CurrRecipeName);
            GeneralUse.WriteValue("相机", "增益", ((int)numCamGain.Value).ToString(), "config", "配方\\" + CurrRecipeName);      
            // CamParmasChangeHandle?.Invoke(CurrCam, null);
            MessageBox.Show("相机参数保存成功");
        }

        int CamExposure = 0, CamGain = 0, CamIndex = 0;
        private void loadCamParmas()
        {
            //---------------相机       
            currCamType = (CamType)Enum.Parse(typeof(CamType),
                     GeneralUse.ReadValue("相机", "型号", "config", "海康"));

            if (CurrCam != null)
            {
                if (CurrCam.IsAlive)
                    CurrCam.CloseCam();
                CurrCam.Dispose();
                CurrCam.setImgGetHandle -= getImageDelegate;//先关闭再注销掉             
                CurrCam.CamConnectHnadle -= CamConnectEvent;
                CurrCam.Dispose();
                CurrCam = null;
            }

            switch (currCamType)
            {
                case CamType.海康:
                    CurrCam = new HKCam("cam1");
                    this.currCamType = CamType.海康;
                    break;
                case CamType.大华:
                    CurrCam = new CCD_DaHua("cam1");
                    this.currCamType = CamType.大华;
                    break;
                case CamType.巴斯勒:
                    try
                    {
                        CurrCam = new CCD_BaslerGIGE("cam1");
                    }
                    catch (Exception er)
                    {
                        Appentxt(er.Message);
                    };
                    this.currCamType = CamType.巴斯勒;
                    break;
            }

            cobxCamType.SelectedItem = Enum.GetName(typeof(CamType), currCamType);

            CamIndex = int.Parse(GeneralUse.ReadValue("相机", "索引", "config", "0"));


            if (CurrCam == null)
            {
                Appentxt("相机实例化对象为空！");
                return;
            }
            for (int i = 0; i < CurrCam.CamNum; i++)
            {
                cobxCamIndex.Items.Add(i);
            }
            if (CamIndex < CurrCam.CamNum)
                cobxCamIndex.SelectedIndex = CamIndex;
            //注册相机图像采集事件
            CurrCam.setImgGetHandle += new ImgGetHandle(getImageDelegate);
            CurrCam.CamConnectHnadle += new EventHandler(CamConnectEvent);

            btnOpenCam_Click(null, null); //自动打开相机

        }

        //打开相机
        private void btnOpenCam_Click(object sender, EventArgs e)
        {
            if (CurrCam == null)
            {
                MessageBox.Show("相机初始化失败，无法打开！", "Information",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /////
            if (CurrCam.IsAlive)
                CurrCam.CloseCam();
            string msg = string.Empty;
            bool initFlag = CurrCam.OpenCam(CamIndex, ref msg);//先关闭再打开          
            /////////
            if (initFlag)
            {

                //相机曝光设置 
                if (CamExposureBar.Value != CamExposure)
                    CamExposureBar.Value = CamExposure;
                else
                {
                    bool flag = CurrCam.SetExposureTime(CamExposure);
                    if (!flag)
                    {
                        if (CurrCam.IsAlive)
                            CurrCam.CloseCam();
                        EnableCam(false);
                        Appentxt("相机曝光设置失败！");
                        MessageBox.Show("相机曝光设置失败！");
                        return;
                    }
                }
                //相机增益设置
                if (CamGainBar.Value != CamGain)
                    CamGainBar.Value = CamGain;
                else
                {
                    bool flag = CurrCam.SetGain(CamGain);
                    if (!flag)
                    {
                        if (CurrCam.IsAlive)
                            CurrCam.CloseCam();
                        EnableCam(false);
                        Appentxt("相机增益设置失败！");
                        MessageBox.Show("相机增益设置失败！");
                        return;
                    }
                }
                EnableCam(true); 
                 workstatus = EunmcurrCamWorkStatus.freestyle;
            }
            else
            {
                EnableCam(false);
                MessageBox.Show("相机打开失败：" + msg);
                Appentxt("相机打开失败：" + msg);
            }
        }

        void EnableCam(bool isEnable)
        {
            if (isEnable)
            {
                btnOpenCam.Enabled = false;
                cobxCamType.Enabled = false;
                cobxCamIndex.Enabled = false;
                btnCloseCam.Enabled = true;

                ImageGrabToolBox.Enabled = true;
                btnOneShot.Enabled = true;
                btnContinueGrab.Enabled = true;
                btnStopGrab.Enabled = false;

              
                CamParmasSetBox.Enabled = true;

                btnGetPixelPoint.Enabled = true;
                btnGetRotataPixel.Enabled = true;
            }
            else
            {
                btnOpenCam.Enabled = true;
                cobxCamType.Enabled = true;
                cobxCamIndex.Enabled = true;
                btnCloseCam.Enabled = false;

              ImageGrabToolBox.Enabled = false;
               
                CamParmasSetBox.Enabled = false;

                btnGetPixelPoint.Enabled = false;
                btnGetRotataPixel.Enabled = false;

                cobxCamType.Enabled = true;
                cobxCamIndex.Enabled = true;

            }
        }
        //关闭相机
        private void btnCloseCam_Click(object sender, EventArgs e)
        {
            CurrCam.CloseCam();
            EnableCam(false);
        }
        //相机曝光调整
        private void txbCamExposure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkValueNumber(numCamExposure.Text))
                {
                    int temvalue = (int)numCamExposure.Value;
                    if (temvalue >= 1000 && temvalue <= 200000)
                        CamExposureBar.Value = temvalue;
                    else
                    {
                        MessageBox.Show("相机曝光设置超范围！");
                        return;
                    }
                    //bool flag = CurrCam.SetExposureTime(long.Parse(txbCamExposure.Text));
                    //if (!flag)
                    //{
                    //    MessageBox.Show("相机曝光设置失败！");
                    //    return;
                    //}                     
                    //CamExposure = int.Parse(txbCamExposure.Text);
                }
            }
        }
        //相机增益调整
        private void txbCamGain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkValueNumber(numCamGain.Text))
                {
                    int temvalue = int.Parse(numCamGain.Text);
                    if (temvalue >= 0 && temvalue <= 10)
                        CamGainBar.Value = (int)numCamGain.Value;
                    else
                    {
                        MessageBox.Show("相机增益设置超范围！");
                        return;
                    }
                    //bool flag = CurrCam.SetGain(long.Parse(txbCamGain.Text));
                    //if (!flag)
                    //{
                    //    MessageBox.Show("相机增益设置失败！");
                    //    return;
                    //}
                    //CamGain = int.Parse(txbCamGain.Text);
                }
            }
        }
        //相机曝光设置
        private void CamExposureBar_ValueChanged(object sender, EventArgs e)
        {
            int tem_CamExposure = this.CamExposureBar.Value;
            bool flag = CurrCam.SetExposureTime(tem_CamExposure);
            if (!flag)
            {
                MessageBox.Show("相机曝光设置失败！");
                return;
            }
            CamExposure = tem_CamExposure;
           numCamExposure.Value = CamExposure;
        }
        //相机增益设置
        private void CamGainBar_ValueChanged(object sender, EventArgs e)
        {
            int tem_CamGain = this.CamGainBar.Value;
            bool flag = CurrCam.SetGain(tem_CamGain);
            if (!flag)
            {
                MessageBox.Show("相机增益设置失败！");
                return;
            }
            CamGain = tem_CamGain;
            numCamGain.Value = CamGain;

        }
        //相机类型切换
        private void cobxCamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Enum.GetName(typeof(CamType), this.currCamType) == cobxCamType.SelectedItem.ToString())
                return;
            if (CurrCam != null)
            {
                if (CurrCam.IsAlive)
                    CurrCam.CloseCam();
                CurrCam.setImgGetHandle -= getImageDelegate;//先关闭再注销掉             
                CurrCam.CamConnectHnadle -= CamConnectEvent;
                CurrCam.Dispose();
                CurrCam = null;

            }
            switch (cobxCamType.SelectedItem.ToString())
            {
                case "海康":
                    CurrCam = new HKCam("cam1");
                    this.currCamType = CamType.海康;
                    break;
                case "大华":
                    CurrCam = new CCD_DaHua("cam1");
                    this.currCamType = CamType.大华;
                    break;
                case "巴斯勒":
                    try
                    {
                        CurrCam = new CCD_BaslerGIGE("cam1");
                    }
                    catch (Exception er)
                    {
                        Appentxt(er.Message);
                    };
                    this.currCamType = CamType.巴斯勒;
                    break;
            }
            if (CurrCam == null)
            {
                Appentxt("相机实例化对象为空！");
                return;
            }

            //注册相机图像采集事件
            CurrCam.setImgGetHandle += getImageDelegate;

            for (int i = 0; i < CurrCam.CamNum; i++)
            {
                cobxCamIndex.Items.Add(i);
            }
            if (CamIndex < CurrCam.CamNum)
                cobxCamIndex.SelectedIndex = CamIndex;
            CamParmasChangeHandle?.Invoke(CurrCam, null);
        }
        //相机索引选择
        private void cobxCamIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            CamIndex = (int)cobxCamIndex.SelectedItem;
        }
        //图像获取委托事件
        void getImageDelegate(Bitmap img)
        {
            this.Invoke(new Action(() =>
            {
                currvisiontool.dispImage(img);
            }));

            GrabImg = MatExtension.BitmapToGrayMat(img);
       
            RunToolStep = 0;
            if (workstatus != EunmcurrCamWorkStatus.freestyle)
                Appentxt(string.Format("相机当前工作状态：{0}",
                          Enum.GetName(typeof(EunmcurrCamWorkStatus), workstatus)));
            if (workstatus == EunmcurrCamWorkStatus.freestyle) //自由模式只采图不做检测
            {
                return;
            }
            else if (workstatus == EunmcurrCamWorkStatus.NinePointcLocation)  //9点标定定位模式
            {             
                if (isUsingModelMatch)
                {
                    TestModelMatch();
                    this.Invoke(new Action(() =>
                    {
                        if (!stuModelMatchData.runFlag)
                        {
                            txbpixelX.Text = "NaN";
                            txbpixelY.Text = "NaN";
                            i++;
                            string[] temarray = new string[3] { i.ToString(), "0.000", "0.000" };
                            SetValueToListItem(listViewPixel, temarray);//像素点位保存到listView
                            NinePointStatusDic.Add(i, false);
                            //sendToRobCmdMsg(string.Format("{0},{1},{2}", "NP", i.ToString(), "NG"));//发送模板匹配NG
                            virtualConnect.WriteData(string.Format("{0},{1},{2}", "NP", i.ToString(), "NG"));//发送模板匹配NG
                            Appentxt(string.Format("模板匹配失败，当期模板类型：{0}，9点标定无法获取像素坐标点",
                                    Enum.GetName(typeof(EumModelType), currModelType)));
                            //MessageBox.Show("模板匹配失败，9点标定无法获取像素坐标点");
                            return;
                        }
                        else
                        {
                            txbpixelX.Text = stuModelMatchData.matchPoint.X.ToString("f3");
                            txbpixelY.Text = stuModelMatchData.matchPoint.Y.ToString("f3");
                            i++;
                            string[] temarray = new string[3] { i.ToString(), 
                                stuModelMatchData.matchPoint.X.ToString("f3"),
                                 stuModelMatchData.matchPoint.Y.ToString("f3") };
                            SetValueToListItem(listViewPixel, temarray);//像素点位保存到listView
                            NinePointStatusDic.Add(i, true);
                            // sendToRobCmdMsg(string.Format("{0},{1},{2}", "NP", i.ToString(), "OK"));//发送模板匹配OK
                            virtualConnect.WriteData(string.Format("{0},{1},{2}", "NP", i.ToString(), "OK"));//发送模板匹配OK
                        }

                    }));
                }
                else
                {
                    MatchCircleRun();
                    Mat dst = new Mat();
                    Cv2.CvtColor(GrabImg, dst, ColorConversionCodes.GRAY2BGR);
                    int count = outPutDataOfCircleMatch.stuCircleResultDatas.Count;
                    for (int i = 0; i < count; i++)
                    {
                        StuCircleResultData sd = outPutDataOfCircleMatch.stuCircleResultDatas[i];
                        dst.Circle((int)(sd.centreP.X), (int)(sd.centreP.Y), (int)sd.Radius,Scalar.Green);
                    }
                    currvisiontool.dispImage(dst);

                    this.Invoke(new Action(() =>
                    {
                        StuCircleResultData sd = outPutDataOfCircleMatch.stuCircleResultDatas[0];
                        if (!sd.runFlag)
                        {
                            txbpixelX.Text = "NaN";
                            txbpixelY.Text = "NaN";
                            i++;
                            string[] temarray = new string[3] { i.ToString(), "0.000", "0.000" };
                            SetValueToListItem(listViewPixel, temarray);//像素点位保存到listView
                            NinePointStatusDic.Add(i, false);
                            //sendToRobCmdMsg(string.Format("{0},{1},{2}", "NP", i.ToString(), "NG"));//发送圆模板匹配NG
                            virtualConnect.WriteData(string.Format("{0},{1},{2}", "NP", i.ToString(), "NG"));//发送圆模板匹配NG
                            Appentxt("圆模板匹配失败,9点标定无法获取像素坐标点");

                            //MessageBox.Show("模板匹配失败，9点标定无法获取像素坐标点");
                            return;
                        }
                        else
                        {
                            txbpixelX.Text = sd.centreP.X.ToString("f3");
                            txbpixelY.Text = sd.centreP.Y.ToString("f3");
                            i++;
                            string[] temarray = new string[3] { i.ToString(), sd.centreP.X.ToString("f3"),
                                        sd.centreP.Y.ToString("f3") };
                            SetValueToListItem(listViewPixel, temarray);//像素点位保存到listView
                            NinePointStatusDic.Add(i, true);
                            // sendToRobCmdMsg(string.Format("{0},{1},{2}", "NP", i.ToString(), "OK"));//发送模板匹配OK
                            virtualConnect.WriteData(string.Format("{0},{1},{2}", "NP", i.ToString(), "OK"));//发送圆模板匹配OK
                        }

                    }));
                }
              
            }
            else if (workstatus == EunmcurrCamWorkStatus.RotatoLocation)  //旋转中心计定位模式
            {
              
                if (isUsingModelMatch)
                {
                    TestModelMatch();
                    this.Invoke(new Action(() =>
                    {
                        if (!stuModelMatchData.runFlag)
                        {

                            txbRotataPixelX.Text = "NaN";
                            txbRotataPixelY.Text = "NaN";
                            k++;
                            string[] temarray = new string[3] { k.ToString(), "0.000", "0.000" };
                            SetValueToListItem(RoratepointListview, temarray); ;//像素点位保存到listView
                            RotatoStatusDic.Add(k, false);
                            //sendToRobCmdMsg(string.Format("{0},{1},{2}", "C", k.ToString(), "NG"));//发送模板匹配NG
                            virtualConnect.WriteData(string.Format("{0},{1},{2}", "C", k.ToString(), "NG"));//发送模板匹配NG
                                                                                                            // MessageBox.Show("定位失败，无法获取像素坐标点");
                            Appentxt("定位失败，无法获取像素坐标点");
                            return;
                        }
                        else
                        {
                            txbRotataPixelX.Text = stuModelMatchData.matchPoint.X.ToString("f3");
                            txbRotataPixelY.Text = stuModelMatchData.matchPoint.Y.ToString("f3");
                            k++;
                            string[] temarray = new string[3] { k.ToString(),
                                 stuModelMatchData.matchPoint.X.ToString("f3"),
                                 stuModelMatchData.matchPoint.Y.ToString("f3") };
                            SetValueToListItem(RoratepointListview, temarray); ;//像素点位保存到listView
                            RotatoStatusDic.Add(k, true);
                            //sendToRobCmdMsg(string.Format("{0},{1},{2}", "C", k.ToString(), "OK"));//发送模板匹配OK
                            virtualConnect.WriteData(string.Format("{0},{1},{2}", "C", k.ToString(), "OK"));//发送模板匹配OK

                        }

                    }));
                }
                else
                {
                    MatchCircleRun();
                    Mat dst = new Mat();
                    Cv2.CvtColor(GrabImg, dst, ColorConversionCodes.GRAY2BGR);
                    int count = outPutDataOfCircleMatch.stuCircleResultDatas.Count;
                    for (int i = 0; i < count; i++)
                    {
                        StuCircleResultData sd = outPutDataOfCircleMatch.stuCircleResultDatas[i];
                        dst.Circle((int)(sd.centreP.X), (int)(sd.centreP.Y), (int)sd.Radius, Scalar.Green);
                    }
                    currvisiontool.dispImage(dst);

                    this.Invoke(new Action(() =>
                    {
                        StuCircleResultData sd = outPutDataOfCircleMatch.stuCircleResultDatas[0];
                        if (!sd.runFlag)
                        {

                            txbRotataPixelX.Text = "NaN";
                            txbRotataPixelY.Text = "NaN";
                            k++;
                            string[] temarray = new string[3] { k.ToString(), "0.000", "0.000" };
                            SetValueToListItem(RoratepointListview, temarray); ;//像素点位保存到listView
                            RotatoStatusDic.Add(k, false);
                            //sendToRobCmdMsg(string.Format("{0},{1},{2}", "C", k.ToString(), "NG"));//发送模板匹配NG
                            virtualConnect.WriteData(string.Format("{0},{1},{2}", "C", k.ToString(), "NG"));//发送圆模板匹配NG
                                                                                                            // MessageBox.Show("定位失败，无法获取像素坐标点");
                            Appentxt("定位失败，无法获取像素坐标点");
                            return;
                        }
                        else
                        {
                            txbRotataPixelX.Text = sd.centreP.X.ToString("f3");
                            txbRotataPixelY.Text = sd.centreP.Y.ToString("f3");
                            k++;
                            string[] temarray = new string[3] { k.ToString(), sd.centreP.X.ToString("f3"),
                                 sd.centreP.Y.ToString("f3") };
                            SetValueToListItem(RoratepointListview, temarray); ;//像素点位保存到listView
                            RotatoStatusDic.Add(k, true);
                            //sendToRobCmdMsg(string.Format("{0},{1},{2}", "C", k.ToString(), "OK"));//发送模板匹配OK
                            virtualConnect.WriteData(string.Format("{0},{1},{2}", "C", k.ToString(), "OK"));//发送圆模板匹配OK

                        }

                    }));
                }
                  
            }
            else if (workstatus == EunmcurrCamWorkStatus.NormalTest_T1)  //正常定位测试(产品1)
            {
                PositionData dstPois;
                EumOutAngleMode eumOutAngleMode = EumOutAngleMode.Relative;
             
                if (isUsingModelMatch)
                {
                    TestModelMatch();
                    if (!stuModelMatchData.runFlag)
                    {
                        //用户坐标事件
                        setModelPointHandle?.Invoke("x:0,y:0,r:0;", null);
                        Appentxt("自动检测模板(产品1)匹配定位失败，无法获取坐标点");

                        return;
                    }
                    else
                    {
                        dstPois = new PositionData
                        {
                            pointXY = stuModelMatchData.matchPoint,                     
                            angle = stuModelMatchData.matchAngle
                        };
                    }
                }
                else if (isUsingAutoCircleMatch)
                {
                    MatchCircleRun();
                    dstPois = new PositionData
                    {
                        pointXY = stuModelMatchData.matchPoint,
                     
                        angle = stuModelMatchData.matchAngle
                    };
                }
                else
                    dstPois = new PositionData { pointXY = new Point2d(0, 0), angle = 0 };
                /*-------------------------------------*/

                if (CheckBoxselectID == 1 || CheckBoxselectID == 2 || CheckBoxselectID == 3)
                  
                {
                    Point2d crossP = new Point2d(0, 0);
                    float x0 = float.Parse(modelOrigion.Split(',')[0]);
                    float y0 = float.Parse(modelOrigion.Split(',')[1]);
                    float a0 = float.Parse(modelOrigion.Split(',')[2]);

                    float x1 = (float)stuModelMatchData.matchPoint.X;
                    float y1 = (float)stuModelMatchData.matchPoint.Y;
                    float a1 = (float)stuModelMatchData.matchAngle;
                    Mat mat2d = new Mat();
                    float offsetAngle = a1 - a0;
                    if (isUsingModelMatch)
                        mat2d = MatExtension.getMat(new Point2f(x0, y0), new Point2f(x1, y1), offsetAngle);

                    else
                        mat2d = MatExtension.getMat(new Point2f(0, 0), new Point2f(0, 0), 0);
                                                        
                        switch (CheckBoxselectID)
                        {
                            case 1:
                                if (SearchROI1 == null || SearchROI1.Count < 2 ||
                                      SearchROI1[0] == null || SearchROI1[1] == null)
                                {
                                    Appentxt("直线检测区域为空，请确认是否需要设置？");
                                    break;
                                }
                                Linedetection(mat2d, offsetAngle,SearchROI1, ref crossP);
                                dstPois.angle = line1AngleLx;
                         
                            eumOutAngleMode = EumOutAngleMode.Absolute;
                                break;
                            case 2:
                                if (SearchROI1 == null || SearchROI1.Count < 1 ||
                                    SearchROI1[0] == null)
                                {
                                    Appentxt("圆检测区域为空，请确认是否需要设置？");
                                    break;
                                }

                                Circledetection(mat2d,offsetAngle,  SearchROI1, ref crossP);
                                break;
                            case 3:
                                if (SearchROI1 == null || SearchROI1.Count < 1 ||
                                   SearchROI1[0] == null)
                                {
                                    Appentxt("Blob检测区域为空，请确认是否需要设置？");
                                    break;
                                }

                                Blobdetection(mat2d, offsetAngle,  SearchROI1, ref crossP);
                                break;                         
                        }
                    dstPois.pointXY = crossP;
                }
                

                /*----------------------------------*/
                Point2d robotP = CalibrationTool.AffineTransPoint2d(Hom_mat2d, dstPois.pointXY);

                string buff = "[检测点位数据]";
                buff += string.Format("x:{0:f3},y:{1:f3},a:{2:f3},m:{3};",
                                 robotP.X, robotP.Y, dstPois.angle, Enum.GetName(typeof(EumOutAngleMode), eumOutAngleMode));

                Appentxt(buff);
                //用户坐标事件
                setModelPointHandle?.Invoke(buff.Replace("[发送特征点位数据]", ""), null);

                currvisiontool.DrawText(new TextEx(string.Format("{0},{1},{2}",
                        robotP.X.ToString("f3"),
                         robotP.Y.ToString("f3"),
                         dstPois.angle.ToString("f3")), new Font("宋体", 12), new SolidBrush(Color.Green),
                         dstPois.pointXY.X, dstPois.pointXY.Y));

                currvisiontool.AddTextBuffer(new TextEx(string.Format("{0},{1},{2}",
                        robotP.X.ToString("f3"),
                         robotP.Y.ToString("f3"),
                         dstPois.angle.ToString("f3")), new Font("宋体", 12), new SolidBrush(Color.Green),
                         dstPois.pointXY.X, dstPois.pointXY.Y));         

           }
            else if (workstatus == EunmcurrCamWorkStatus.NormalTest_T2)  //正常定位测试(产品2)
            {
                PositionData dstPois;
                EumOutAngleMode eumOutAngleMode = EumOutAngleMode.Relative;

          
                if (isUsingModelMatch)
                {
                    TestModelMatch();
                    if (!stuModelMatchData.runFlag)
                    {
                        //用户坐标事件
                        setModelPointHandle?.Invoke("x:0,y:0,r:0;", null);
                        Appentxt("自动检测模板(产品2)匹配定位失败，无法获取坐标点");
                        return;
                    }
                    else
                    {
                        dstPois = new PositionData
                        {
                            pointXY = stuModelMatchData.matchPoint,
                       
                            angle = stuModelMatchData.matchAngle
                        };
                    }
                }
                else if (isUsingAutoCircleMatch)
                {
                    dstPois = new PositionData
                    {
                        pointXY = stuModelMatchData.matchPoint,
                     
                        angle = stuModelMatchData.matchAngle
                    };
                }
                else
                    dstPois = new PositionData { pointXY = new Point2d(0, 0), angle = 0 };
                /*-------------------------------------*/

                if (CheckBoxselectID == 1 || CheckBoxselectID == 2 || CheckBoxselectID == 3)
                     
                {
                    Point2d crossP = new Point2d(0, 0);
                    float x0 = float.Parse(modelOrigion.Split(',')[0]);
                    float y0 = float.Parse(modelOrigion.Split(',')[1]);
                    float a0 = float.Parse(modelOrigion.Split(',')[2]);

                    float x1 = (float)stuModelMatchData.matchPoint.X;
                    float y1 = (float)stuModelMatchData.matchPoint.Y;
                    float a1 = (float)stuModelMatchData.matchAngle;
                    Mat mat2d = new Mat();
                    float offsetAngle = a1 - a0;
                    if (isUsingModelMatch)
                        mat2d = MatExtension.getMat(new Point2f(x0, y0), new Point2f(x1, y1), offsetAngle);

                    else
                        mat2d = MatExtension.getMat(new Point2f(0, 0), new Point2f(0, 0), 0);
                                      
                        switch (CheckBoxselectID)
                        {
                            case 1:
                                if (SearchROI2 == null || SearchROI2.Count < 2 ||
                                        SearchROI2[0] == null || SearchROI2[1] == null)
                                {
                                    Appentxt("直线检测区域为空，请确认是否需要设置？");
                                    break;
                                }
                                Linedetection(mat2d, offsetAngle, SearchROI2, ref crossP);
                               dstPois.angle = line1AngleLx;
                                eumOutAngleMode = EumOutAngleMode.Absolute;
                                break;
                            case 2:
                                if (SearchROI2 == null || SearchROI2.Count < 1 ||
                                    SearchROI2[0] == null)
                                {
                                    Appentxt("圆检测区域为空，请确认是否需要设置？");
                                    break;
                                }

                                Circledetection(mat2d,offsetAngle, SearchROI2, ref crossP);
                                break;
                            case 3:
                                if (SearchROI2 == null || SearchROI2.Count < 1 ||
                                   SearchROI2[0] == null)
                                {
                                    Appentxt("Blob检测区域为空，请确认是否需要设置？");
                                    break;
                                }

                                Blobdetection(mat2d, offsetAngle,SearchROI2, ref crossP);
                                break;
                      
                        }
                  
                }

                /*-------------------------------------*/
                Point2d robotP = CalibrationTool.AffineTransPoint2d(Hom_mat2d, dstPois.pointXY);

                string buff = "[检测点位数据]";
                buff += string.Format("x:{0:f3},y:{1:f3},a:{2:f3},m:{3};",
                                 robotP.X, robotP.Y, dstPois.angle, Enum.GetName(typeof(EumOutAngleMode), eumOutAngleMode));

                Appentxt(buff);
                //用户坐标事件
                setModelPointHandle?.Invoke(buff.Replace("[发送特征点位数据]", ""), null);

                currvisiontool.DrawText(new TextEx(string.Format("{0},{1},{2}",
                        robotP.X.ToString("f3"),
                         robotP.Y.ToString("f3"),
                         dstPois.angle.ToString("f3")), new Font("宋体", 12), new SolidBrush(Color.Green),
                         dstPois.pointXY.X, dstPois.pointXY.Y));

                currvisiontool.AddTextBuffer(new TextEx(string.Format("{0},{1},{2}",
                        robotP.X.ToString("f3"),
                         robotP.Y.ToString("f3"),
                         dstPois.angle.ToString("f3")), new Font("宋体", 12), new SolidBrush(Color.Green),
                         dstPois.pointXY.X, dstPois.pointXY.Y));

            }
            else if (workstatus == EunmcurrCamWorkStatus.NormalTest_G)  //正常定位测试(点胶阀)
            {
                PositionData dstPois;
                EumOutAngleMode eumOutAngleMode = EumOutAngleMode.Relative;
                if (isUsingModelMatch)
                {
                    TestModelMatch();//不进行前处理
                    if (!stuModelMatchData.runFlag)
                    {
                        //用户坐标事件
                        setModelPointHandle?.Invoke("x:0,y:0,a:0;", null);
                        Appentxt("自动检测模板(点胶阀)匹配定位失败，无法获取坐标点");
                        return;
                    }
                    else
                    {
                        dstPois = new PositionData
                        {
                            pointXY = stuModelMatchData.matchPoint,
                  
                            angle = stuModelMatchData.matchAngle
                        };
                    }
                }
                else if (isUsingAutoCircleMatch)
                {
                    dstPois = new PositionData
                    {
                        pointXY = stuModelMatchData.matchPoint,
                    
                        angle = stuModelMatchData.matchAngle
                    };
                }
                else
                    dstPois = new PositionData { pointXY = new Point2d(0, 0), angle = 0 };
                //只给预留Blob检测工具
                if (CheckBoxselectID == 3)
                {
                    Point2d crossP = new Point2d(0, 0);
                    float x0 = float.Parse(modelOrigion.Split(',')[0]);
                    float y0 = float.Parse(modelOrigion.Split(',')[1]);
                    float a0 = float.Parse(modelOrigion.Split(',')[2]);

                    float x1 = (float)stuModelMatchData.matchPoint.X;
                    float y1 = (float)stuModelMatchData.matchPoint.Y;
                    float a1 = (float)stuModelMatchData.matchAngle;
                    Mat mat2d = new Mat();
                    float offsetAngle = a1 - a0;
                    if (isUsingModelMatch)
                        mat2d = MatExtension.getMat(new Point2f(x0, y0), new Point2f(x1, y1), offsetAngle);

                    else
                        mat2d = MatExtension.getMat(new Point2f(0, 0), new Point2f(0, 0), 0);

                    if (SearchROI3 == null || SearchROI3.Count < 1 ||
                                 SearchROI3[0] == null)
                        Appentxt("Blob检测区域为空，请确认是否需要设置？");
                    else
                       Blobdetection(mat2d, offsetAngle, SearchROI3, ref crossP);

                }

                /*-------------------------------------*/
                Point2d robotP = CalibrationTool.AffineTransPoint2d(Hom_mat2d, dstPois.pointXY);

                string buff = "[检测点位数据]";
                buff += string.Format("x:{0:f3},y:{1:f3},a:{2:f3},m:{3};",
                                 robotP.X, robotP.Y, dstPois.angle, Enum.GetName(typeof(EumOutAngleMode), eumOutAngleMode));

                Appentxt(buff);
                //用户坐标事件
                setModelPointHandle?.Invoke(buff.Replace("[发送特征点位数据]", ""), null);

                currvisiontool.DrawText(new TextEx(string.Format("{0},{1},{2}",
                        robotP.X.ToString("f3"),
                         robotP.Y.ToString("f3"),
                         dstPois.angle.ToString("f3")), new Font("宋体", 12), new SolidBrush(Color.Green),
                         dstPois.pointXY.X, dstPois.pointXY.Y));

                currvisiontool.AddTextBuffer(new TextEx(string.Format("{0},{1},{2}",
                        robotP.X.ToString("f3"),
                         robotP.Y.ToString("f3"),
                         dstPois.angle.ToString("f3")), new Font("宋体", 12), new SolidBrush(Color.Green),
                         dstPois.pointXY.X, dstPois.pointXY.Y));

            }

        }


        /// <summary>
        ///  直线检测
        /// </summary>
        /// <param name="homMat2d"></param>
        /// <param name="offsetangle"></param>
        /// <param name="SearchROI"></param>
        /// <param name="lineP"></param>
        /// <returns></returns>
        bool Linedetection(Mat homMat2d, float offsetangle, List<object> SearchROI, ref Point2d lineP)
        {
            RotatedRectF rotatedRectF = (RotatedRectF)SearchROI[0];
            RotatedRectF rotatedRectF2 = (RotatedRectF)SearchROI[1];
            //bool runFlag = false; bool runFlag2 = false;
            Point2f temP, temP2;
            Point2d p1 = new Point2d(0, 0);
            Point2d p2 = new Point2d(0, 0);
            Point2d p12 = new Point2d(0, 0);
            Point2d p22 = new Point2d(0, 0);
            var A = homMat2d.Get<double>(0, 0);
            var B = homMat2d.Get<double>(0, 1);
            var C = homMat2d.Get<double>(0, 2);    //Tx
            var D = homMat2d.Get<double>(1, 0);
            var E = homMat2d.Get<double>(1, 1);
            var F = homMat2d.Get<double>(1, 2);    //Ty

            temP.X = (float)((A * rotatedRectF.cx) + (B * rotatedRectF.cy) + C);
            temP.Y = (float)((D * rotatedRectF.cx) + (E * rotatedRectF.cy) + F);

            CVRRect rotatedRect = new CVRRect(new Point2f(temP.X, temP.Y),
              new Size2f(rotatedRectF.Width, rotatedRectF.Height),
                        (float)(rotatedRectF.angle + offsetangle));
            ////////////////////////////
            temP2.X = (float)((A * rotatedRectF2.cx) + (B * rotatedRectF2.cy) + C);
            temP2.Y = (float)((D * rotatedRectF2.cx) + (E * rotatedRectF2.cy) + F);

            CVRRect rotatedRect2 = new CVRRect(new Point2f(temP2.X, temP2.Y),
              new Size2f(rotatedRectF2.Width, rotatedRectF2.Height),
                        (float)(rotatedRectF2.angle + offsetangle));

            //直线1
            //霍夫直线参数
            this.Invoke(new Action(() =>
            {
                parmaData = new HoughLinesPData
                {
                    canThddown = (double)NumcanThddown.Value,
                    canThdup = (double)NumcanThdup.Value,
                    ThresholdP = (int)NumThresholdP.Value,
                    MinLineLenght = (double)NumMinLineLenght.Value,
                    MaxLineGap = (double)NumMaxLineGap.Value
                };
            }));
            runTool = new HoughLinesPTool();
            parmaData.ROI = rotatedRect;
            ResultOfToolRun = runTool.Run<HoughLinesPData>(GrabImg,
               parmaData as HoughLinesPData);
            //currvisiontool.clearAll();
            //currvisiontool.dispImage(stuResultOfToolRun.resultToShow);
            currvisiontool.clearOverlay();
            if ((ResultOfToolRun as HoughLinesPResult).positionData.Count < 2)
            {
                StuLineResultData.runFlag = false;
                Appentxt("直线1拟合失败！");
            }               
            else
            {
                p1 = (ResultOfToolRun as HoughLinesPResult).positionData[0];
                p2 = (ResultOfToolRun as HoughLinesPResult).positionData[1];
   
                StuLineResultData = new StuLineResultData((float)p1.X, (float)p1.Y, (float)p2.X, (float)p2.Y);
                if (Hom_mat2d != null && Hom_mat2d.Width > 0)
                {
                    Point2d r1 = CalibrationTool.AffineTransPoint2d(Hom_mat2d, p1);
                    Point2d r2 = CalibrationTool.AffineTransPoint2d(Hom_mat2d, p2);
                  
                    line1AngleLx = new StuLineResultData((float)r1.X, (float)r1.Y, (float)r2.X, (float)r2.Y).GetAngle();

                    currvisiontool.DrawText(new TextEx(string.Format("直线1的角度angle：{0}", line1AngleLx.ToString("f3")),
                        new Font("宋体", 12f), new SolidBrush(Color.Green), 10, 10));

                    Appentxt(string.Format("直线1的角度angle：{0}", line1AngleLx.ToString("f3")));
                }
            }


            //temobj.Dispose();
            //直线2
            //霍夫直线参数
            this.Invoke(new Action(() =>
            {
                parmaData = new HoughLinesPData
                {
                    canThddown = (double)NumcanThddown2.Value,
                    canThdup = (double)NumcanThdup2.Value,
                    ThresholdP = (int)NumThresholdP2.Value,
                    MinLineLenght = (double)NumMinLineLenght2.Value,
                    MaxLineGap = (double)NumMaxLineGap2.Value
                };
            }));
            runTool = new HoughLinesPTool();
            parmaData.ROI = rotatedRect2;
            ResultOfToolRun = runTool.Run<HoughLinesPData>(GrabImg,
               parmaData as HoughLinesPData);
            //currvisiontool.clearAll();
            //currvisiontool.dispImage(ResultOfToolRun.resultToShow);

            if ((ResultOfToolRun as HoughLinesPResult).positionData.Count < 2)
            {
                StuLineResultData2.runFlag = false;
                Appentxt("直线2拟合失败！");
            }               
            else
            {
                p12 = (ResultOfToolRun as HoughLinesPResult).positionData[0];
                p22 = (ResultOfToolRun as HoughLinesPResult).positionData[1];
                StuLineResultData2 = new StuLineResultData((float)p12.X, (float)p12.Y, (float)p22.X, (float)p22.Y);
                if (Hom_mat2d != null && Hom_mat2d.Width > 0)
                {
                    Point2d r12 = CalibrationTool.AffineTransPoint2d(Hom_mat2d, p12);
                    Point2d r22 = CalibrationTool.AffineTransPoint2d(Hom_mat2d, p22);
      
                    line2AngleLx = new StuLineResultData((float)r12.X, (float)r12.Y, (float)r22.X, (float)r22.Y).GetAngle();

                    currvisiontool.DrawText(new TextEx(string.Format("直线2的角度angle：{0}", line2AngleLx.ToString("f3")),
                       new Font("宋体", 12f), new SolidBrush(Color.Green), 10, 20));

                    Appentxt(string.Format("直线2的角度angle：{0}", line2AngleLx.ToString("f3")));
                }
            }

            ////////////////////////////////////////////////////////////////////////
            Mat dst = new Mat();
            Cv2.CvtColor(GrabImg, dst, ColorConversionCodes.GRAY2BGR);
            //直线检测区域1
            dst.DrawRotatedRect(rotatedRect);
            //直线检测区域2
            dst.DrawRotatedRect(rotatedRect2);

            Point2d crossP = new Point2d(0, 0);
            if (StuLineResultData.runFlag && StuLineResultData2.runFlag)
            {
                MatExtension.IntersectionPoint(
                 MatExtension.LineSegmentPoint2Line2D(new LineSegmentPoint(
                     new CVPoint(p1.X, p1.Y)
                     , new CVPoint(p2.X, p2.Y))
                 ),
                  MatExtension.LineSegmentPoint2Line2D(new LineSegmentPoint(
                     new CVPoint(p12.X, p12.Y)
                     , new CVPoint(p22.X, p22.Y)))
                , out crossP);


                dst.Line(new CVPoint(p1.X, p1.Y)
                     , new CVPoint(p2.X, p2.Y), Scalar.LimeGreen);
                dst.Line(new CVPoint(p12.X, p12.Y)
                     , new CVPoint(p22.X, p22.Y), Scalar.LimeGreen);
                dst.drawCross(new CVPoint(crossP.X, crossP.Y), Scalar.Red, 20, 2);
                currvisiontool.dispImage(dst);
            }
            else
            {
                MessageBox.Show("直线未拟合，无法进行交点计算！");
                lineP = new Point2d(0, 0);

                currvisiontool.DrawText(new TextEx("直线未拟合，无法进行交点计算！", 
                     new Font("宋体", 12), new SolidBrush(Color.Red),
                       10, 10));

                currvisiontool.AddTextBuffer(new TextEx("直线未拟合，无法进行交点计算！",
                     new Font("宋体", 12), new SolidBrush(Color.Red),
                       10, 10));

                return false;
            }
            lineP = new Point2d(crossP.X, crossP.Y);

            return true;

        }
        /// <summary>
        /// 圆检测
        /// </summary>
        /// <param name="homMat2d"></param>
        /// <param name="SearchROI"></param>
        /// <param name="centreP"></param>
        /// <returns></returns>
        bool Circledetection(Mat homMat2d, float offsetangle, List<object> SearchROI, ref Point2d centreP)
        {
            sectorF = (SectorF)SearchROI[0];
            Point2f temP;
            var A = homMat2d.Get<double>(0, 0);
            var B = homMat2d.Get<double>(0, 1);
            var C = homMat2d.Get<double>(0, 2);    //Tx
            var D = homMat2d.Get<double>(1, 0);
            var E = homMat2d.Get<double>(1, 1);
            var F = homMat2d.Get<double>(1, 2);    //Ty

            temP.X = (float)((A * sectorF.centreP.X) + (B * sectorF.centreP.Y) + C);
            temP.Y = (float)((D * sectorF.centreP.X) + (E * sectorF.centreP.Y) + F);
            //变换后的扇形区域
            SectorF affineSectorF = new SectorF(new PointF(temP.X, temP.Y),
                                     (float)sectorF.getRadius,
                                         (float)(sectorF.startAngle + offsetangle),
                                                 (float)(sectorF.sweepAngle + offsetangle));

            CVPoint[] RegionSectorF = MatExtension.GetSectorF(affineSectorF.getInnerSector(), affineSectorF.getOuterSector());

            runTool = new FitCircleTool();
            parmaData = new FitCircleData();
            this.Invoke(new Action(() =>
            {
                (parmaData as FitCircleData).maxRadius = (double)NummaxRadius.Value;
                (parmaData as FitCircleData).minRadius = (double)NumminRadius.Value;
                (parmaData as FitCircleData).EdgeThreshold = (int)NumEdgeThreshold.Value;
                (parmaData as FitCircleData).sectorF = affineSectorF;
            }));

            parmaData.ROI = RegionSectorF;
            ResultOfToolRun = runTool.Run<FitCircleData>(GrabImg,
                           parmaData as FitCircleData);
            currvisiontool.dispImage(ResultOfToolRun.resultToShow);

            if ((ResultOfToolRun as FitCircleResult).positionData.Count > 0)

                stuCircleResultData = new StuCircleResultData((float)(ResultOfToolRun as FitCircleResult).positionData[0].X,
                           (float)(ResultOfToolRun as FitCircleResult).positionData[0].Y,
                                  (float)(ResultOfToolRun as FitCircleResult).radiusArray[0]);

            else
            {
                stuCircleResultData.runFlag = false;
                Appentxt("圆查找失败！");
            }
            currvisiontool.clearOverlay();
            if (stuCircleResultData.runFlag)
            {
                centreP = (ResultOfToolRun as FitCircleResult).positionData[0];
                return true;
            }
            else
            {
                currvisiontool.DrawText(new TextEx("圆查找失败！",
                     new Font("宋体", 12), new SolidBrush(Color.Red),
                       10, 10));

                currvisiontool.AddTextBuffer(new TextEx("圆查找失败！",
                     new Font("宋体", 12), new SolidBrush(Color.Red),
                       10, 10));
                centreP = new Point2d(0, 0);
                return false;
            }
        }
        /// <summary>
        ///  Blob检测
        /// </summary>
        /// <param name="homMat2d"></param>
        /// <param name="offsetangle"></param>
        /// <param name="SearchROI"></param>
        /// <param name="centreP"></param>
        /// <returns></returns>
        bool Blobdetection(Mat homMat2d, float offsetangle, List<object> SearchROI, ref Point2d centreP)
        {
            RectangleF rectangleF = (RectangleF)SearchROI[0];
            
            shapeConvert(new CVRect((int)rectangleF.X, (int)rectangleF.Y,
                 (int)rectangleF.Width, (int)rectangleF.Height),out CVRRect cVRRect, 0);

            Point2f temP;
            var A = homMat2d.Get<double>(0, 0);
            var B = homMat2d.Get<double>(0, 1);
            var C = homMat2d.Get<double>(0, 2);    //Tx
            var D = homMat2d.Get<double>(1, 0);
            var E = homMat2d.Get<double>(1, 1);
            var F = homMat2d.Get<double>(1, 2);    //Ty


            temP.X = (float)((A * cVRRect.Center.X) + (B * cVRRect.Center.Y) + C);
            temP.Y = (float)((D * cVRRect.Center.X) + (E * cVRRect.Center.Y) + F);

            CVRRect rotatedRect = new CVRRect(new Point2f(temP.X, temP.Y),
              new Size2f(cVRRect.Size.Width, cVRRect.Size.Height),
                        (float)(cVRRect.Angle + offsetangle));

            shapeConvert(rotatedRect, out CVRect temCVRect);
     
         
            runTool = new Blob3Tool();
            //Blob3检测参数
            parmaData = new Blob3Data
            {
                edgeThreshold = (double)Numminthd.Value,
                minArea = (int)NumareaLow.Value,
                maxArea = (int)NumareaHigh.Value,
                eumWhiteOrBlack = (EumWhiteOrBlack)Enum.Parse(typeof(EumWhiteOrBlack), cobxPolarity.Text)          
            };
            parmaData.ROI = temCVRect;  
            ResultOfToolRun = runTool.Run<Blob3Data>(GrabImg,
               parmaData as Blob3Data);
          
            currvisiontool.dispImage(ResultOfToolRun.resultToShow);
            if ((ResultOfToolRun as Blob3Result).positionData.Count > 0)
                stuBlobResultData = new StuBlobResultData((float)(ResultOfToolRun as Blob3Result).positionData[0].X,
                            (float)(ResultOfToolRun as Blob3Result).positionData[0].Y);
            else
            {
                stuBlobResultData.runFlag = false;
                Appentxt("Blob检测失败！");
            }

            currvisiontool.clearOverlay();
            if (stuBlobResultData.runFlag)
            {
                centreP = (ResultOfToolRun as Blob3Result).positionData[0];
                return true;
            }
            else
            {
                currvisiontool.DrawText(new TextEx("Blob检测失败！",
                       new Font("宋体", 12), new SolidBrush(Color.Red),
                         10, 10));

                currvisiontool.AddTextBuffer(new TextEx("Blob检测失败！",
                     new Font("宋体", 12), new SolidBrush(Color.Red),
                       10, 10));
                centreP = new Point2d(0, 0);
                return false;
            }

        }

        #endregion

        #region-----------DLL库连接-----------
        VirtualConnect virtualConnect = null;
        public delegate void GetDataHandle(string data);
        public event GetDataHandle GetDataOfCaliHandle = null;

        /// <summary>
        /// 外部数据写入DLL库
        /// </summary>
        /// <param name="data"></param>
        public void ExternWriteData(string data)
        {
            if (virtualConnect != null)
            {
                if (virtualConnect.IsRunning)
                {
                    virtualConnect.ReadData(data);
                }
            }
        }
        /// <summary>
        /// 建立虚拟连接
        /// </summary>
        /// <returns></returns>
        public bool BuiltConnect()
        {
            if (virtualConnect == null) return false;
            else if (virtualConnect.IsRunning) return true;
            virtualConnect.GetDataHandle += new EventHandler(GetDataEvent);
            virtualConnect.sendDataHandle += new VirtualConnect.SendDataHandle(sendDataEvent);
            return virtualConnect.StartConnect();

        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <returns></returns>
        public bool Disconnect()
        {
            if (virtualConnect == null) return false;
            else if (!virtualConnect.IsRunning) return true;
            virtualConnect.GetDataHandle -= GetDataEvent;
            return virtualConnect.Disconnnect();

        }
        /// <summary>
        /// 数据交互段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GetDataEvent(object sender, EventArgs e)
        {
            string strData = sender.ToString();
            Appentxt(string.Format("控制端接收信息：{0}", strData));
            if (strData.Contains("NP") || strData.Contains("C") || strData.Contains("T1")
                        || strData.Contains("T2") || strData.Contains("G"))   //视觉自动标定
            {
                // ModelMatchLoadParma(EumModelType.CalibModel);           
                if (strData.Contains("NP")) //9点标定流程
                {
                    this.Invoke(new Action(() =>
                    {
                        cobxModelType.SelectedIndex = 2; //标定模板
                    }));
                    string[] tempdataArray = strData.Split(',');
                    #region---//9点标定流程----------
                    switch (tempdataArray[1])
                    {
                        case "S":

                            //检测当前是否已经做好模板
                            //检查当前是否相机正常连接
                            //清除历史标记点位
                            //发送准备好信号，等待9点标记
                            this.Invoke(new Action(() =>
                            {
                                listViewPixel.Items.Clear();
                                i = 0;
                                listViewRobot.Items.Clear();
                                j = 0;
                            }));
                            NinePointStatusDic.Clear();
                            if ((Hom_mat2d != null) &&(Hom_mat2d.Width>0) &&
                                    (CurrCam.IsAlive))
                            {
                                virtualConnect.WriteData("NP,S,OK");   //准备OK
                                Appentxt("9点标定准备好，开始标定");
                            }
                            else
                                virtualConnect.WriteData("NP,S,NG");  //未准备好
                            break;
                        case "E":
                            //校验9次模板匹配是否OK
                            //检测当前标定关系转换是否正常                     
                            //发送标定结果信号

                            bool flag = true;
                            foreach (var s in NinePointStatusDic)
                                flag &= s.Value;
                            Task.Factory.StartNew(new Action(() =>
                            {
                                coorditionConvert(); //9点标定关系转换
                                this.Invoke(new Action(() =>
                                {
                                    BtnSaveParmasOfNightPoints_click(null, null);//9点标定相关参数保存
                                }));
                            })).ContinueWith(t =>
                            {
                                virtualConnect.WriteData(string.Format("{0},{1}", "NP,E", flag ? "OK" : "NG"));
                                Appentxt("9点标定结束，标定结果" + (flag ? "OK" : "NG"));
                            });
                            break;
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                        case "5":
                        case "6":
                        case "7":
                        case "8":
                        case "9":
                            //记录xy机械坐标点
                            //相机采集，模板匹配
                            //发送匹配结果信号
                            int key = int.Parse(tempdataArray[1]);
                            if (NinePointStatusDic.ContainsKey(key))
                            {
                                //TCPInfoAddText(string.Format("当前已经标记过第{0}点位", key));
                                virtualConnect.WriteData(string.Format("{0},{1},{2}", tempdataArray[0],
                                    tempdataArray[1], "NG"));
                            }
                            else
                            {
                                j++;
                                string[] temarray = new string[3] { tempdataArray[1], tempdataArray[2], tempdataArray[3] };
                                this.BeginInvoke(new Action(() =>
                                {
                                    SetValueToListItem(listViewRobot, temarray);//保存机器人点位到listview
                                }));
                                workstatus = EunmcurrCamWorkStatus.NinePointcLocation;
                                CurrCam.OneShot();

                            }
                            break;

                    }
                    #endregion
                }
                else if (strData.Contains("C"))//旋转中心标定流程
                {
                    this.Invoke(new Action(() =>
                    {
                        cobxModelType.SelectedIndex = 2;  //标定模板
                    }));

                    string[] tempdataArray = strData.Split(',');
                    #region---//旋转中心标定流程---------
                    switch (tempdataArray[1])
                    {
                        case "S":

                            //检测当前是否已经做好模板
                            //检查当前是否相机正常连接
                            //清除历史标记点位
                            //发送准备好信号，等待旋转中心标定
                            this.Invoke(new Action(() =>
                            {
                                RoratepointListview.Items.Clear();
                                k = 0;
                            }));
                            RotatoStatusDic.Clear();
                            if ((Hom_mat2d != null) &&(Hom_mat2d.Width>0) &&
                                    (CurrCam.IsAlive))
                            {
                                virtualConnect.WriteData("C,S,OK");   //准备OK
                                Appentxt("旋转中心标定准备好,开始标定");
                            }

                            else
                                virtualConnect.WriteData("C,S,NG");  //未准备好

                            break;
                        case "E":
                            //校验5次模板匹配是否OK
                            //计算旋转中心                
                            //发送旋转中心标定结果信号

                            bool flag = true;
                            foreach (var s in RotatoStatusDic)
                                flag &= s.Value;

                            Task.Factory.StartNew(new Action(() =>
                            {
                                CaculateMultorRorateCenter(); //旋转中心计算
                                this.Invoke(new Action(() =>
                                {
                                    btnRatitoCaliDataSave_Click(null, null);  //旋转中心相关参数保存
                                }));

                            })).ContinueWith(t =>
                            {
                                virtualConnect.WriteData(string.Format("{0},{1}", "C,E", flag ? "OK" : "NG"));
                                Appentxt("旋转中心标定结束，标定结果" + (flag ? "OK" : "NG"));
                            });
                            break;
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                        case "5":
                            //相机采集，模板匹配
                            //发送匹配结果信号
                            int key = int.Parse(tempdataArray[1]);
                            if (RotatoStatusDic.ContainsKey(key))
                            {
                                //CPInfoAddText(string.Format("当前旋转已经标记过第{0}点位", key));
                                virtualConnect.WriteData(string.Format("{0},{1},{2}", tempdataArray[0],
                                    tempdataArray[1], "NG"));
                            }
                            else
                            {
                                workstatus = EunmcurrCamWorkStatus.RotatoLocation; //旋转中心计算状态
                                CurrCam.OneShot();

                            }
                            break;

                    }
                    #endregion
                }
                else if (strData.Contains("T1"))
                {
                    // ModelMatchLoadParma(EumModelType.ProductModel_1);
                    this.Invoke(new Action(() =>
                    {
                        cobxModelType.SelectedIndex = 0;
                    }));
                    stopwatch.Restart();
                    workstatus = EunmcurrCamWorkStatus.NormalTest_T1;
                    CurrCam.OneShot();    //单次采集
                    Appentxt("开始自动检测,使用模板为产品1模板！");
                }
                else if (strData.Contains("T2"))
                {
                    //ModelMatchLoadParma(EumModelType.ProductModel_2);
                    this.Invoke(new Action(() =>
                    {
                        cobxModelType.SelectedIndex = 1;
                    }));
                    stopwatch.Restart();
                    workstatus = EunmcurrCamWorkStatus.NormalTest_T2;
                    CurrCam.OneShot();    //单次采集
                    Appentxt("开始自动检测,使用模板为产品2模板！");
                }
                else if (strData.Contains("G"))
                {
                    // ModelMatchLoadParma(EumModelType.GluetapModel);
                    this.Invoke(new Action(() =>
                    {
                        cobxModelType.SelectedIndex = 3;
                    }));
                    stopwatch.Restart();
                    workstatus = EunmcurrCamWorkStatus.NormalTest_G;
                    CurrCam.OneShot();    //单次采集
                    Appentxt("开始点胶阀示教检测");
                }        
                else
                    return;
            }
        }

        void sendDataEvent(string data)
        {
            GetDataOfCaliHandle?.Invoke(data);
        }
        #endregion

        #region------------定位检测-----------

        //创建模板
        private void btncreateModel_Click(object sender, EventArgs e)
        {
            if (GrabImg == null || GrabImg.Width <= 0)
            {
                MessageBox.Show("未获取图像");
                return;
            }

            List<RectangleF> roiList = currvisiontool.getRoiList<RectangleF>();
            if (roiList.Count <= 0)
            {
                MessageBox.Show("请设置模板创建区域{矩形}");
                return;

            }
            if (MessageBox.Show("确认创建新模板？", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                  == DialogResult.Yes)
            {
                CVRect cVRect = new CVRect((int)roiList[0].X, (int)roiList[0].Y, (int)roiList[0].Width, (int)roiList[0].Height);
                Mat tp = MatExtension.Crop_Mask_Mat(GrabImg, cVRect);

                templateContour = null;
                coutourLen = 0; 
                contourArea = 0;
                double modelx=0, modely=0, modelangle=0;


                runTool = new ShapeMatchTool();
                parmaData = new ShapeMatchData();
                (parmaData as ShapeMatchData).Segthreshold = (double)NumSegthreshold.Value;
            
                modeltp = (runTool as ShapeMatchTool).CreateTemplateContours(tp,
                     (parmaData as ShapeMatchData).Segthreshold,
                    ref templateContour,
                    ref coutourLen, ref contourArea,ref modelx,ref modely,ref modelangle);

                picTemplate.Image = BitmapConverter.ToBitmap(modeltp);
                if (templateContour == null)
                {
                    MessageBox.Show("模板创建失败！");
                    return;
                }
                modelx += cVRect.X;
                modely += cVRect.Y;
                lIstModelInfo.Items.Clear();
                lIstModelInfo.Items.Add(new ListViewItem(
                    new string[] { "BaseX", modelx.ToString("f3")}));
                lIstModelInfo.Items.Add(new ListViewItem(
                  new string[] {"BaseY", modely.ToString("f3") }));
                lIstModelInfo.Items.Add(new ListViewItem(
                  new string[] {"BaseAngle", modelangle.ToString("f3") }));
                lIstModelInfo.Items.Add(new ListViewItem(
                 new string[] { "ContourLength", coutourLen.ToString("f3") }));
                lIstModelInfo.Items.Add(new ListViewItem(
                 new string[] { "ContourArea", contourArea.ToString("f3") }));

                modelOrigion = string.Format("{0},{1},{2}",
                      modelx.ToString("f3"),
                          modely.ToString("f3"),
                              modelangle.ToString("f3"));

                MessageBox.Show("模板创建完成！");
            }

        }
      
        //模板匹配测试
        private void btnTest_modelMatch_Click(object sender, EventArgs e)
        {
            TestModelMatch();

        }
        private void picTemplate_MouseHover(object sender, EventArgs e)
        {
            if (this.modeltp.Empty() || this.modeltp.Width <= 0) return;
            frmTemplateShow f= frmTemplateShow.createInstance();
            f.ImageShow = BitmapConverter.ToBitmap(this.modeltp);
            f.Owner = this;
            f.StartPosition = FormStartPosition.CenterParent;
            f.Show();
            f.UpdateShow();
        }
        private void picTemplate_MouseLeave(object sender, EventArgs e)
        {
            if (this.modeltp.Empty() || this.modeltp.Width <= 0) return;
            frmTemplateShow f = frmTemplateShow.createInstance(BitmapConverter.ToBitmap(this.modeltp));
            f.Hide();
        }


        //模板参数保存
        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            SaveModelMatchParma();
        }
        /*---------------------------------------------------------------------*/
        //自动圆匹配
        private void btnTestAutoCircleMatch_Click(object sender, EventArgs e)
        {
            if (GrabImg == null || GrabImg.Width <= 0)
            {
                MessageBox.Show("未获取图像");

            }
            List<RectangleF> roiList = currvisiontool.getRoiList<RectangleF>();
            if (roiList.Count <= 0)
            {
                MessageBox.Show("请设置自动圆匹配区域{矩形}");
                return;

            }

            MatchCircleRun();
            int count = outPutDataOfCircleMatch.stuCircleResultDatas.Count;
            //Mat dst = new Mat();
            //Cv2.CvtColor(GrabImg,dst, ColorConversionCodes.GRAY2BGR);
            for (int i = 0; i < count; i++)
            {
                StuCircleResultData ss = outPutDataOfCircleMatch.stuCircleResultDatas[i];
                currvisiontool.DrawText(new TextEx(
                    string.Format("X：{0}\nY：{1}\nR：{2}",
                       ss.centreP.X.ToString("f3"), ss.centreP.Y.ToString("f3"), ss.Radius.ToString("f3")),
                     new Font("宋体", 12f), new SolidBrush(Color.Green), ss.centreP.X, ss.centreP.Y));

                currvisiontool.AddTextBuffer(new TextEx(
                    string.Format("X：{0}\nY：{1}\nR：{2}",
                       ss.centreP.X.ToString("f3"), ss.centreP.Y.ToString("f3"), ss.Radius.ToString("f3")),
                     new Font("宋体", 12f), new SolidBrush(Color.Green), ss.centreP.X, ss.centreP.Y));
            }
        }
        /*---------------------------------------------------------------------*/
        //获取直线1
        private void btnGetLine1_Click(object sender, EventArgs e)
        {
            #region-----直线1------
            if (GrabImg == null ||
                  GrabImg.Width <= 0 || GrabImg.Height <= 0)
            {
                MessageBox.Show("未获取图像");
                return;
            }
            List<RotatedRectF> roiList = currvisiontool.getRoiList<RotatedRectF>();
            if (roiList.Count <= 0)
            {
                MessageBox.Show("请设置直线查找区域{旋转矩形}");
                return;

            }
                 
            currvisiontool.dispImage(GrabImg);
            //霍夫直线参数
            parmaData = new HoughLinesPData
            {
                canThddown = (double)NumcanThddown.Value,
                canThdup = (double)NumcanThdup.Value,
                ThresholdP = (int)NumThresholdP.Value,
                MinLineLenght = (double)NumMinLineLenght.Value,
                MaxLineGap = (double)NumMaxLineGap.Value
            };
          
            parmaData.ROI = RegionRRect= temBuffRegionRRect;
            runTool = new HoughLinesPTool();
            ResultOfToolRun = runTool.Run<HoughLinesPData>(GrabImg,
               parmaData as HoughLinesPData);
       
            currvisiontool.dispImage(ResultOfToolRun.resultToShow);
          
            if ((ResultOfToolRun as HoughLinesPResult).positionData.Count < 2)
                Appentxt("直线1拟合失败！");
            else
            {
                Point2d p1 = (ResultOfToolRun as HoughLinesPResult).positionData[0];
                Point2d p2 = (ResultOfToolRun as HoughLinesPResult).positionData[1];
                StuLineResultData = new StuLineResultData((float)p1.X, (float)p1.Y, (float)p2.X, (float)p2.Y);
                if (Hom_mat2d != null && Hom_mat2d.Width > 0)
                {
                    Point2d r1 = CalibrationTool.AffineTransPoint2d(Hom_mat2d, p1);
                    Point2d r2 = CalibrationTool.AffineTransPoint2d(Hom_mat2d, p2);
                
                    line1AngleLx = new StuLineResultData((float)r1.X, (float)r1.Y, (float)r2.X, (float)r2.Y).GetAngle();

                    currvisiontool.DrawText(new TextEx(string.Format("直线1的角度angle：{0}", line1AngleLx.ToString("f3")),
                        new Font("宋体", 12f), new SolidBrush(Color.Green), 100, 100));

                    Appentxt(string.Format("直线1的角度angle：{0}", line1AngleLx.ToString("f3")));
                }
            }         
              
            EnableDetectionControl();
            #endregion
        }
        //获取直线2
        private void btnGetLine2_Click(object sender, EventArgs e)
        {
            #region---直线2-----
            if (GrabImg == null ||
                  GrabImg.Width <= 0 || GrabImg.Height <= 0)
            {
                MessageBox.Show("未获取图像");
                return;
            }
            List<RotatedRectF> roiList2 = currvisiontool.getRoiList<RotatedRectF>();
            
            if (roiList2.Count <= 0)
            {
                MessageBox.Show("请设置直线2查找区域{旋转矩形}");
                return;

            }
              
            currvisiontool.dispImage(GrabImg);
            //霍夫直线参数
            parmaData = new HoughLinesPData
            {
                canThddown = (double)NumcanThddown2.Value,
                canThdup = (double)NumcanThdup2.Value,
                ThresholdP = (int)NumThresholdP2.Value,
                MinLineLenght = (double)NumMinLineLenght2.Value,
                MaxLineGap = (double)NumMaxLineGap2.Value
            };
           
            parmaData.ROI = RegionRRect2= temBuffRegionRRect;
            runTool = new HoughLinesPTool();
            ResultOfToolRun = runTool.Run<HoughLinesPData>(GrabImg,
               parmaData as HoughLinesPData);
       
            currvisiontool.dispImage(ResultOfToolRun.resultToShow);
          

            if ((ResultOfToolRun as HoughLinesPResult).positionData.Count < 2)
                Appentxt("直线2拟合失败！");
            else
            {
                Point2d p12 = (ResultOfToolRun as HoughLinesPResult).positionData[0];
                Point2d p22 = (ResultOfToolRun as HoughLinesPResult).positionData[1];
                StuLineResultData2 = new StuLineResultData((float)p12.X, (float)p12.Y, (float)p22.X, (float)p22.Y);

                if (Hom_mat2d!=null&& Hom_mat2d.Width>0)
                {
                    Point2d r12 = CalibrationTool.AffineTransPoint2d(Hom_mat2d, p12);
                    Point2d r22 = CalibrationTool.AffineTransPoint2d(Hom_mat2d, p22);
                    
                    line2AngleLx = new StuLineResultData((float)r12.X, (float)r12.Y, (float)r22.X, (float)r22.Y).GetAngle();

                    currvisiontool.DrawText(new TextEx(string.Format("直线2的角度angle：{0}", line2AngleLx.ToString("f3")),
                       new Font("宋体", 12f), new SolidBrush(Color.Green), 100, 100));

                    Appentxt(string.Format("直线2的角度angle：{0}", line2AngleLx.ToString("f3")));
                }

            }          
            EnableDetectionControl();
            #endregion
        }
        //直线交点
        private void btnIntersectLines_Click(object sender, EventArgs e)
        {
            Point2d crossP = new Point2d(0, 0);
            if (StuLineResultData.runFlag && StuLineResultData2.runFlag)
            {
                MatExtension.IntersectionPoint(
                 MatExtension.LineSegmentPoint2Line2D(new LineSegmentPoint(
                     new CVPoint(StuLineResultData.P1.X, StuLineResultData.P1.Y)
                     , new CVPoint(StuLineResultData.P2.X, StuLineResultData.P2.Y))
                 ),
                  MatExtension.LineSegmentPoint2Line2D(new LineSegmentPoint(
                     new CVPoint(StuLineResultData2.P1.X, StuLineResultData2.P1.Y)
                     , new CVPoint(StuLineResultData2.P2.X, StuLineResultData2.P2.Y)))
                , out crossP);

                Mat dst = new Mat();
                Cv2.CvtColor(GrabImg, dst, ColorConversionCodes.GRAY2BGR);
                dst.Line(new CVPoint(StuLineResultData.P1.X, StuLineResultData.P1.Y)
                     , new CVPoint(StuLineResultData.P2.X, StuLineResultData.P2.Y), Scalar.LimeGreen);
                dst.Line(new CVPoint(StuLineResultData2.P1.X, StuLineResultData2.P1.Y)
                     , new CVPoint(StuLineResultData2.P2.X, StuLineResultData2.P2.Y), Scalar.LimeGreen);
                dst.drawCross(new CVPoint(crossP.X, crossP.Y), Scalar.Red, 20, 2);

                currvisiontool.dispImage(dst);
            }
            else
            {
                MessageBox.Show("直线未拟合，无法进行交点计算！");
                return;
            }

            if (Hom_mat2d == null || Hom_mat2d.Width <= 0)
            {
                Appentxt("标定矩阵为空，当前不可转换坐标！");
                return;
            }

            Point2d robotP = CalibrationTool.AffineTransPoint2d(Hom_mat2d, new Point2d(crossP.X, crossP.Y));

            //用户坐标事件
            setUserPointHandle?.Invoke(new string[] { robotP.X.ToString("f3"),
                   robotP.Y.ToString("f3")}, null);
            currvisiontool.DrawText(new TextEx(
                string.Format("直线交点X：{0},Y：{1}", robotP.X.ToString("f3"),
                           robotP.Y.ToString("f3")), new Font("宋体", 12f),
                new SolidBrush(Color.Green), 100, 100));
        }

        /*---------------------------------------------------------------------*/

        //获取圆
        private void btnGetCircle_Click(object sender, EventArgs e)
        {
            if (GrabImg == null ||
                   GrabImg.Width <= 0)
            {
                MessageBox.Show("未获取图像");
                return;
            }
            //控件使能
            {
                LinesIntersectPanel.Enabled = false;
                BlobCentrePanel.Enabled = false;
                ModelMactPanel.Enabled = false;
                btnGetCircle.Enabled = false;
            }
            List<SectorF> roiList = currvisiontool.getRoiList<SectorF>();
            if (roiList.Count <= 0)
            {
                MessageBox.Show("请设置圆检测区域{扇形}");
                return;

            }
            currvisiontool.clearAll();
            currvisiontool.dispImage(GrabImg);

            parmaData = new FitCircleData();
            (parmaData as FitCircleData).maxRadius = (double)NummaxRadius.Value;
            (parmaData as FitCircleData).minRadius = (double)NumminRadius.Value;
            (parmaData as FitCircleData).EdgeThreshold = (int)NumEdgeThreshold.Value;
            (parmaData as FitCircleData).sectorF = sectorF;

            CVPoint[] RegionSectorF = MatExtension.GetSectorF(sectorF.getInnerSector(), sectorF.getOuterSector());
            parmaData.ROI = RegionSectorF;
            runTool = new FitCircleTool();
            Result stuResultOfToolRun = runTool.Run<FitCircleData>(GrabImg,
                           parmaData as FitCircleData);
            currvisiontool.clearAll();
            currvisiontool.dispImage(stuResultOfToolRun.resultToShow);
            //控件使能
            {
                LinesIntersectPanel.Enabled = true;
                BlobCentrePanel.Enabled = true;
                ModelMactPanel.Enabled = true;

                btnGetCircle.Enabled = true;
            }

            EnableDetectionControl();
        }
        /*---------------------------------------------------------------------*/
        //Blob检测
        private void btnGetBlobArea_Click(object sender, EventArgs e)
        {
            if (GrabImg == null ||
                     GrabImg.Width < 0)
            {
                MessageBox.Show("未获取图像");
                return;
            }
           
            List<RectangleF> roiList = currvisiontool.getRoiList<RectangleF>();
            if (roiList.Count <= 0)
            {
                MessageBox.Show("请设置Blob检测区域{矩形}");
                return;

            }
            currvisiontool.clearAll();
            currvisiontool.dispImage(GrabImg);
            //Blob3检测参数
            parmaData = new Blob3Data
            {
                edgeThreshold = (double)Numminthd.Value,
                minArea = (int)NumareaLow.Value,
                maxArea = (int)NumareaHigh.Value,
                eumWhiteOrBlack = (EumWhiteOrBlack)Enum.Parse(typeof(EumWhiteOrBlack), cobxPolarity.Text)              
            };            
              parmaData.ROI = RegionaRect;
            runTool = new Blob3Tool();
            ResultOfToolRun = runTool.Run<Blob3Data>(GrabImg,
               parmaData as Blob3Data);
            currvisiontool.clearAll();
            currvisiontool.dispImage(ResultOfToolRun.resultToShow);
         
            EnableDetectionControl();
        }

        /*---------------------------------------------------------------------*/

        /// <summary>
        /// ROI绘制完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RoiChangedEvent(object sender, EventArgs e)
        {
            if (sender is RectangleF)
            {
                RegionaRect = new CVRect((int)((RectangleF)sender).X, (int)((RectangleF)sender).Y,
                    (int)((RectangleF)sender).Width, (int)((RectangleF)sender).Height);

            }
            else if (sender is RotatedRectF)
            {
                temBuffRegionRRect = new CVRRect(
                    new Point2f(((RotatedRectF)sender).centerP.X, ((RotatedRectF)sender).centerP.Y),
                               new Size2f(((RotatedRectF)sender).size.Width, ((RotatedRectF)sender).size.Height),
                            ((RotatedRectF)sender).angle);
            }
            else if (sender is SectorF)
            {
                sectorF = (SectorF)sender;

                CVPoint[] RegionSectorF = MatExtension.GetSectorF(sectorF.getInnerSector(), sectorF.getOuterSector());
            }
        }
        private void checkBox1_CheckedChanged(object sender, bool value)
        {
            if (!chxbLinesIntersect.Checked && !chxbFindCircle.Checked && !chxbBlobCentre.Checked)
            {
                ExchangeSelect(-1);
                CheckBoxselectID = -1;
            }

            if ((sender as UICheckBox).Checked)
                switch ((sender as UICheckBox).Name)
                {
                    case "chxbLinesIntersect":
                        ExchangeSelect(1);
                        CheckBoxselectID = 1;

                        break;
                    case "chxbFindCircle":
                        ExchangeSelect(2);
                        CheckBoxselectID = 2;
                        break;
                    case "chxbBlobCentre":
                        ExchangeSelect(3);
                        CheckBoxselectID = 3;
                        break;

                }
        }

        /// <summary>
        /// 是否启用模板匹配
        /// </summary>
        bool isUsingModelMatch = true;
        private void chxbModelMatch_ValueChanged(object sender, bool value)
        {
            isUsingModelMatch = chxbModelMatch.Checked;
            if (isUsingModelMatch)
            {
                chxbAutoCircleMatch.Checked = false;
                chxbAutoCircleMatch.Enabled = false;
                CircleMatchPanel.Enabled = false;

                checkedControl("配方\\" + CurrRecipeName);
                EnableDetectionControl();
            }
            else
            {
                chxbAutoCircleMatch.Enabled = true;
                CircleMatchPanel.Enabled = true;

                checkedControl("配方\\" + CurrRecipeName);
                EnableDetectionControl();

            }
        }

        /// <summary>
        /// 自动圆匹配工具
        /// </summary>
        bool isUsingAutoCircleMatch = false;
        private void chxbAutoCircleMatch_ValueChanged(object sender, bool value)
        {
            isUsingAutoCircleMatch = chxbAutoCircleMatch.Checked;

            if (isUsingAutoCircleMatch)
            {
                chxbModelMatch.Checked = false;
                chxbModelMatch.Enabled = false;
                ModelMactPanel.Enabled = false;

                checkedControl("配方\\" + CurrRecipeName);
                EnableDetectionControl();
            }
            else
            {
                chxbModelMatch.Enabled = true;
                ModelMactPanel.Enabled = true;
                checkedControl("配方\\" + CurrRecipeName);
                EnableDetectionControl();

            }
        }

        private void btnTest_modelMatch_MouseHover(object sender, EventArgs e)
        {
            switch ((sender as UIButton).Name)
            {
                case "btnTest_modelMatch":
                    this.toolTip1.SetToolTip(this.btnTest_modelMatch, "计算后的坐标为像素坐标");
                    break;
                case "btnLntersectLine":
                    this.toolTip1.SetToolTip(this.btnLntersectLine, "计算后的坐标为物理坐标");
                    break;
                case "btnfircircle":
                    this.toolTip1.SetToolTip(this.btnGetCircle, "计算后的坐标为物理坐标");
                    break;
                case "btnBlobCentre":
                    this.toolTip1.SetToolTip(this.btnGetBlobArea, "计算后的坐标为物理坐标");
                    break;

            }
        }
        /*---------------------------------------------------------------------*/
        static int RunToolStep = 0;

        //运行工具
        private void btnRunTool_Click(object sender, EventArgs e)
        {
            if (listViewFlow.SelectedItems.Count <= 0) return;
            int index = listViewFlow.SelectedIndices[0];
            if (index < 0) return;
                     
            if (toolList[index] == "模板匹配")
            {             
                if (RunToolStep == 1)
                {
                    MessageBox.Show("模板匹配工具已运行，无需重复！");
                    return;
                }
                else
                {
                    btnTest_modelMatch_Click(null, null);
                    RunToolStep = 1;
                }

            }
            else if (toolList[index] == "自动圆匹配")
            {              
                if (RunToolStep == 1)
                {
                    MessageBox.Show("自动圆匹配工具已运行，无需重复！");
                    return;
                }
                else
                {
                    btnTestAutoCircleMatch_Click(null, null);
                    RunToolStep = 1;
                }

            }
            else if (toolList[index] == "直线定位")
            {             
                if (RunToolStep == 2)
                {
                    MessageBox.Show("直线相交工具已运行，无需重复！");
                    return;
                }
                else
                {
                    btnintersectlines();
                    RunToolStep = 2;
                }

            }
            else if (toolList[index] == "找圆定位")
            {
               
                if (RunToolStep == 2)
                {
                    MessageBox.Show("查找圆心工具已运行，无需重复！");
                    return;
                }
                else
                {
                    btnfitcircle();
                    RunToolStep = 2;
                }

            }
            else if (toolList[index] == "Blob定位")
            {
               
                if (RunToolStep == 2)
                {
                    MessageBox.Show("Blob中心工具已运行，无需重复！");
                    return;
                }
                else
                {
                    btncalblobcentre();
                    RunToolStep = 2;
                }

            }   
        }

        //运行流程
        static object locker = new object();
        Stopwatch stopwatch = new Stopwatch();
        private void btnRunFlow_Click(object sender, EventArgs e)
        {
            stopwatch.Restart();

            lock (locker)
            {
                #region
                PositionData dstPois; 
                
                EumOutAngleMode eumOutAngleMode = EumOutAngleMode.Relative;

                if (GrabImg == null || GrabImg.Width <= 0)
                {
                    MessageBox.Show("未获取图像");
                    return;
                }

                if (isUsingModelMatch)
                {
                    TestModelMatch();
                    dstPois = new PositionData
                    {
                        pointXY = stuModelMatchData.matchPoint,
                   
                        angle = stuModelMatchData.matchAngle
                    };
                }
                    
                else if (isUsingAutoCircleMatch)
                {
                    MatchCircleRun();
                    dstPois = new PositionData
                    {
                        pointXY = stuModelMatchData.matchPoint,
                     
                        angle = stuModelMatchData.matchAngle
                    };
                }                  
                else
                    dstPois = new PositionData { pointXY = new Point2d(0, 0), angle = 0 };
                /*-----------------------------*/
                if (CheckBoxselectID == 1 || CheckBoxselectID == 2 || CheckBoxselectID == 3)
                     
                {
               
                    float x0 = float.Parse(modelOrigion.Split(',')[0]);
                    float y0 = float.Parse(modelOrigion.Split(',')[1]);
                    float a0 = float.Parse(modelOrigion.Split(',')[2]);

                    float x1 = (float)stuModelMatchData.matchPoint.X;
                    float y1 = (float)stuModelMatchData.matchPoint.Y;
                    float a1 = (float)stuModelMatchData.matchAngle;
                    Mat mat2d = new Mat();
                  
                    float offsetAngle = a1 - a0;
                    if (isUsingModelMatch)
                        mat2d = MatExtension.getMat(new Point2f(x0, y0), new Point2f(x1, y1), offsetAngle);
                    else
                        mat2d = MatExtension.getMat(new Point2f(0, 0), new Point2f(0, 0), 0);
                                  
                    switch (CheckBoxselectID)
                    {
                        case 1:
                            if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
                == EumModelType.ProductModel_1)
                            {
                                if (SearchROI1 == null || SearchROI1.Count < 2 ||
                                   SearchROI1[0] == null && SearchROI1[1] == null)
                                {
                                    Appentxt("直线检测区域为空，请确认是否需要设置？");
                                    break;
                                }
                                Linedetection(mat2d, offsetAngle, SearchROI1, ref dstPois.pointXY);
                                dstPois.angle = line1AngleLx;                             
                                eumOutAngleMode = EumOutAngleMode.Absolute;
                            }
                            else
                            {
                                if (SearchROI2 == null || SearchROI2.Count < 2 ||
                                  SearchROI2[0] == null || SearchROI2[1] == null)
                                {
                                    Appentxt("直线检测区域为空，请确认是否需要设置？");
                                    break;
                                }
                                Linedetection(mat2d, offsetAngle, SearchROI2, ref dstPois.pointXY);
                                dstPois.angle = line1AngleLx;
                                eumOutAngleMode = EumOutAngleMode.Absolute;
                            }

                            break;
                        case 2:
                            if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
              == EumModelType.ProductModel_1)
                            {
                                if (SearchROI1 == null || SearchROI1.Count < 1 ||
                                                                   SearchROI1[0] == null)
                                {
                                    Appentxt("圆检测区域为空，请确认是否需要设置？");
                                    break;
                                }
                                Circledetection(mat2d, offsetAngle, SearchROI1, ref dstPois.pointXY);
                            }
                            else
                            {
                                if (SearchROI2 == null || SearchROI2.Count < 1 ||
                                                                   SearchROI2[0] == null)
                                {
                                    Appentxt("圆检测区域为空，请确认是否需要设置？");
                                    break;
                                }
                                Circledetection(mat2d, offsetAngle, SearchROI2, ref dstPois.pointXY);
                            }
                            break;
                        case 3:
                            if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
            == EumModelType.ProductModel_1)
                            {
                                if (SearchROI1 == null || SearchROI1.Count < 1 ||
                                                                   SearchROI1[0] == null)
                                {
                                    Appentxt("Blob检测区域为空，请确认是否需要设置？");
                                    break;
                                }
                                Blobdetection(mat2d, offsetAngle, SearchROI1, ref dstPois.pointXY);
                            }
                            else if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
           == EumModelType.ProductModel_2)
                            {
                                if (SearchROI2 == null || SearchROI2.Count < 1 ||
                                                             SearchROI2[0] == null)

                                {
                                    Appentxt("Blob检测区域为空，请确认是否需要设置？");
                                    break;
                                }
                                Blobdetection(mat2d, offsetAngle, SearchROI2, ref dstPois.pointXY);
                            }
                            else if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
           == EumModelType.GluetapModel)
                            {
                                if (SearchROI3 == null || SearchROI3.Count < 1 ||
                                                             SearchROI3[0] == null)

                                {
                                    Appentxt("Blob检测区域为空，请确认是否需要设置？");
                                    break;
                                }
                                Blobdetection(mat2d, offsetAngle, SearchROI3, ref dstPois.pointXY);
                            }
                            break;
                                            
                    }

                }

                /*------------------机械坐标点位转换----------------*/
                Point2d robotP = new Point2d(0,0);
                if (Hom_mat2d == null || Hom_mat2d.Width <= 0)
                    Appentxt("当前标定矩阵关系为空，请确认！");
                else
                    robotP = CalibrationTool.AffineTransPoint2d(Hom_mat2d, dstPois.pointXY);



                string buff = "[检测点位数据]";
                buff += string.Format("x:{0:f3},y:{1:f3},a:{2:f3},m:{3};",
                                 robotP.X, robotP.Y, dstPois.angle, Enum.GetName(typeof(EumOutAngleMode), eumOutAngleMode));
                               
                Appentxt(buff);

              
                currvisiontool.DrawText(new TextEx(string.Format("{0},{1},{2}",
                        robotP.X.ToString("f3"),
                         robotP.Y.ToString("f3"),
                         dstPois.angle.ToString("f3")), new Font("宋体", 16), new SolidBrush(Color.LimeGreen),
                         dstPois.pointXY.X, dstPois.pointXY.Y));

                currvisiontool.AddTextBuffer(new TextEx(string.Format("{0},{1},{2}",
                        robotP.X.ToString("f3"),
                         robotP.Y.ToString("f3"),
                         dstPois.angle.ToString("f3")), new Font("宋体", 16), new SolidBrush(Color.LimeGreen),
                         dstPois.pointXY.X, dstPois.pointXY.Y));

                #endregion
            }
            stopwatch.Stop();
           int spend=  (int)stopwatch.ElapsedMilliseconds;
         
        }

        /*---------------------------------------------------------------------*/
        //模板匹配
        void TestModelMatch( )
        {
            if (GrabImg == null || GrabImg.Width <= 0)
            {
                MessageBox.Show("未获取图像");
                return;
            }

            if (templateContour==null)
            {
                MessageBox.Show("模板不存在，请先创建模板！");
                return;
            }
            runTool = new ShapeMatchTool();
            parmaData = new ShapeMatchData();
            (parmaData as ShapeMatchData).tpContour = templateContour;
           (parmaData as ShapeMatchData).Segthreshold = (double)NumSegthreshold.Value;
            (parmaData as ShapeMatchData).MatchValue = (double)NumMatchValue.Value;
            (parmaData as ShapeMatchData).MincoutourLen = (int)NumMincoutourLen.Value;
            (parmaData as ShapeMatchData).MaxcoutourLen = (int)NumMaxcoutourLen.Value;
            (parmaData as ShapeMatchData).MinContourArea = (int)NumMinContourArea.Value;
            (parmaData as ShapeMatchData).MaxContourArea = (int)NumMaxContourArea.Value;

            ResultOfToolRun = runTool.Run<ShapeMatchData>(GrabImg, parmaData as ShapeMatchData);

            currvisiontool.clearAll();
            currvisiontool.dispImage(ResultOfToolRun.resultToShow);

            ShapeMatchResult shapeMatchResult = ResultOfToolRun as ShapeMatchResult;

            if(shapeMatchResult.scores.Count<=0)
            {
                currvisiontool.DrawText(new TextEx("模板匹配失败！") { brush = new SolidBrush(Color.Red) });
            
                currvisiontool.AddTextBuffer(new TextEx("模板匹配失败！") { brush = new SolidBrush(Color.Red) });
                return;
            }
            currvisiontool.DrawText(new TextEx("得分:" + shapeMatchResult.scores[0].ToString("f3")));
            currvisiontool.AddTextBuffer(new TextEx("得分:" + shapeMatchResult.scores[0].ToString("f3")));

            currvisiontool.DrawText(new TextEx("角度:" + shapeMatchResult.rotations[0].ToString("f3")) { x = 10, y = 100 });
            currvisiontool.AddTextBuffer(new TextEx("角度:" + shapeMatchResult.rotations[0].ToString("f3")) { x = 10, y = 100 });

            currvisiontool.DrawText(new TextEx( string.Format("X:{0},Y:{1}", shapeMatchResult.positions[0].X.ToString("f3"),
                shapeMatchResult.positions[0].Y.ToString("f3"))) 
            { x = 10, y = 200 });
            currvisiontool.AddTextBuffer(new TextEx(string.Format("X:{0},Y:{1}", shapeMatchResult.positions[0].X.ToString("f3"),
                shapeMatchResult.positions[0].Y.ToString("f3")))
            { x = 10, y = 200 });

            stuModelMatchData.matchPoint = shapeMatchResult.positions[0];
            stuModelMatchData.matchAngle = shapeMatchResult.rotations[0];
            stuModelMatchData.matchScore = shapeMatchResult.scores[0];
      
        }

        //自动圆匹配,圆拟合
         void MatchCircleRun()
       {       
            runTool = new HoughCircleTool();
            parmaData = new HoughCircleData();
            (parmaData as HoughCircleData).MinDist =(double)NumMinDist.Value;
            (parmaData as HoughCircleData).Param1 = (double)NumParam1.Value;
            (parmaData as HoughCircleData).Param2 = (double)NumParam2.Value;
            (parmaData as HoughCircleData).MinRadius = (int)numberMinRadius.Value;
            (parmaData as HoughCircleData).MaxRadius = (int)numberMaxRadius.Value;         
            Result stuResultOfToolRun = runTool.Run<HoughCircleData>(GrabImg,
                          parmaData as HoughCircleData);
            currvisiontool.clearAll();
            currvisiontool.dispImage(stuResultOfToolRun.resultToShow);

            int cn = (stuResultOfToolRun as HoughCircleResult).positionData.Count;
            for (int i = 0; i < cn; i++)
                outPutDataOfCircleMatch.stuCircleResultDatas.Add(
                    new StuCircleResultData((stuResultOfToolRun as HoughCircleResult).positionData[i].X,
                  (stuResultOfToolRun as HoughCircleResult).positionData[i].Y,
                        (float)(stuResultOfToolRun as HoughCircleResult).radiusArray[i]));
         
        }
     
        //直线相交
        void btnintersectlines()
        {

            Point2d crossP = new Point2d(0,0);
      
            float x0 = float.Parse(modelOrigion.Split(',')[0]);
            float y0 = float.Parse(modelOrigion.Split(',')[1]);
            float a0 = float.Parse(modelOrigion.Split(',')[2]);

            float x1 = (float)stuModelMatchData.matchPoint.X;
            float y1 = (float)stuModelMatchData.matchPoint.Y;
            float a1 = (float)stuModelMatchData.matchAngle;
            Mat mat2d = new Mat();
            float offsetAngle = a1 - a0;
            if (isUsingModelMatch)
                mat2d = MatExtension.getMat(new Point2f(x0, y0), new Point2f(x1, y1), offsetAngle);

            else
                mat2d = MatExtension.getMat(new Point2f(0, 0), new Point2f(0, 0), 0);
  
                if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
                     == EumModelType.ProductModel_1)
                {
                    if (SearchROI1 == null || SearchROI1.Count < 2 ||
                                      SearchROI1[0] == null || SearchROI1[1] == null)
                    {
                        Appentxt("直线检测区域为空，请确认是否需要设置？");
                      
                    }
                    Linedetection(mat2d, offsetAngle, SearchROI1, ref crossP);
                }
                else
                {
                    if (SearchROI2 == null || SearchROI2.Count < 2 ||
                                                      SearchROI2[0] == null || SearchROI2[1] == null)
                    {
                        Appentxt("直线检测区域为空，请确认是否需要设置？");
                       
                    }
                    Linedetection(mat2d, offsetAngle, SearchROI2, ref crossP);
                }

            
        }

        void btnfitcircle()
        {
            Point2d crossP = new Point2d(0, 0);
            float x0 = float.Parse(modelOrigion.Split(',')[0]);
            float y0 = float.Parse(modelOrigion.Split(',')[1]);
            float a0 = float.Parse(modelOrigion.Split(',')[2]);

            float x1 = (float)stuModelMatchData.matchPoint.X;
            float y1 = (float)stuModelMatchData.matchPoint.Y;
            float a1 = (float)stuModelMatchData.matchAngle;

            Mat Hom_mat2d = MatExtension.getMat(new Point2f(x0, y0), new Point2f(x1, y1), a1 - a0);
         

                if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
                        == EumModelType.ProductModel_1)
                {
                    if (SearchROI1 == null || SearchROI1.Count < 1 ||
                                    SearchROI1[0] == null)
                    {
                        Appentxt("圆检测区域为空，请确认是否需要设置？");
                      
                    }
                    Circledetection(Hom_mat2d, a1 - a0, SearchROI1, ref crossP);
                }
                else
                {
                    if (SearchROI2 == null || SearchROI2.Count < 1 ||
                                SearchROI2[0] == null)
                    {
                        Appentxt("圆检测区域为空，请确认是否需要设置？");
                       
                    }
                    Circledetection(Hom_mat2d, a1 - a0, SearchROI2, ref crossP);
                }

        }

        void btncalblobcentre()
        {
            Point2d crossP = new Point2d(0, 0);
            float x0 = float.Parse(modelOrigion.Split(',')[0]);
            float y0 = float.Parse(modelOrigion.Split(',')[1]);
            float a0 = float.Parse(modelOrigion.Split(',')[2]);

            float x1 = (float)stuModelMatchData.matchPoint.X;
            float y1 = (float)stuModelMatchData.matchPoint.Y;
            float a1 = (float)stuModelMatchData.matchAngle;

             float  offsetAngle = a1 - a0;

            Mat Hom_mat2d = MatExtension.getMat(new Point2f(x0, y0), new Point2f(x1, y1), a1 - a0);


            if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
                      == EumModelType.ProductModel_1)
                {
                    if (SearchROI1 == null || SearchROI1.Count < 1 ||
                            SearchROI1[0] == null)
                    {
                        Appentxt("Blob检测区域为空，请确认是否需要设置？");
                     
                    }
                    Blobdetection(Hom_mat2d, offsetAngle, SearchROI1, ref crossP);
                }
                else if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
                      == EumModelType.ProductModel_2)
                {
                    if (SearchROI2 == null || SearchROI2.Count < 1 ||
                           SearchROI2[0] == null)
                    {
                        Appentxt("Blob检测区域为空，请确认是否需要设置？");
                       
                    }
                    Blobdetection(Hom_mat2d, offsetAngle, SearchROI2, ref crossP);
                }
                else if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
                      == EumModelType.GluetapModel)
                {
                    if (SearchROI3 == null || SearchROI3.Count < 1 ||
                           SearchROI3[0] == null)
                    {
                        Appentxt("Blob检测区域为空，请确认是否需要设置？");
                       
                    }
                    Blobdetection(Hom_mat2d, offsetAngle,SearchROI3, ref crossP);
                }

          
        }

        /*----------------------------------------------------------------*/
        /// <summary>
        ///  模板切换
        /// </summary>
        /// <param name="eumModelType">模板切换类型参数</param>
        /// <returns>模板切换是否成功标志</returns>
        public bool SwitchModelType(EumModelType eumModelType)
        {
            if (eumModelType == EumModelType.None) return false;
            if (currModelType == eumModelType)//如果无切换则不重载
                return true;
            if (cobxModelType.InvokeRequired)
            {
                this.cobxModelType.Invoke(new Action(() =>
                {
                    cobxModelType.SelectedIndex = (int)eumModelType;
                }));
            }
            else
                cobxModelType.SelectedIndex = (int)eumModelType;

            return true;
        }
        private void cobxModelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            EumModelType _currModelType = (EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text);
            if (currModelType == _currModelType)//如果无切换则不重载
                return;
         
            RunToolStep = 0;
            toolList.Clear();
          
            ModelMatchLoadParma("配方\\" + CurrRecipeName, _currModelType);
            LoadTestingTools("配方\\" + CurrRecipeName, _currModelType);

            listViewFlow.Items.Clear();
            for (int i = 0; i < toolList.Count; i++)
                listViewFlow.Items.Add(new ListViewItem(new string[] { i.ToString(), toolList[i] }));

            EnableDetectionControl();

            currvisiontool.clearAll();
            currvisiontool.dispImage(GrabImg);
            currModelType = _currModelType;
        }
     
        private void btnSendDataToControl_Click(object sender, EventArgs e)
        {
            string buff = "[发送产品角度数据]";
            buff += string.Format("R1:{0},R2:{1}", line1AngleLx.ToString("f3"), line2AngleLx.ToString("f3"));
            Appentxt(buff);
            //产品倾斜弧度数据
            setProductAngleDataHandle?.Invoke(buff.Replace("[发送产品角度数据]", ""), null);
        }

        //禁用numericUpDown控件鼠标中键滚轮消息响应
        private void Num_DiscountAmount_MouseWheel(object sender, MouseEventArgs e)
        {

            HandledMouseEventArgs h = e as HandledMouseEventArgs;
            if (h != null)
            {
                h.Handled = true;
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAgreement fa = new frmAgreement();
            //fa.Owner = this;
            fa.Show();
        }
                               
        //定位检测相关参数保存，包含模板参数
        private void btnSaveRunParmas_Click(object sender, EventArgs e)
        {
            SaveInspectionParma();

        }
        /// <summary>
        /// 检测相关参数保存，包含模板相关参数
        /// </summary>
        void SaveInspectionParma()
        {

            try
            {
                toolList.Clear();           
                SaveModelMatchParma();
                SaveTestingTools();
                listViewFlow.Items.Clear();
                for (int i = 0; i < toolList.Count; i++)
                    listViewFlow.Items.Add(new ListViewItem(new string[] { i.ToString(), toolList[i] }));
                MessageBox.Show("检测相关参数保存成功！");

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }

        /*----------------------------------------------------------------*/
        //保存检测工具
        void SaveTestingTools()
        {
            if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
                  == EumModelType.ProductModel_1)
            {
                SaveLineParmas("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_1\\");
                SaveBlobParms("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_1\\");
                SaveCircleParmas("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_1\\");

                GeneralUse.WriteValue("附加工具", "工具编号",
                      CheckBoxselectID.ToString(), "附加工具类型", "配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_1");

                switch (CheckBoxselectID)
                {
                    case 1:
                        if ((RegionRRect == null || RegionRRect2 == null ||
                            RegionRRect.Size.Width <= 0 || RegionRRect2.Size.Width <= 0)
                            && SearchROI1.Count <= 0)
                            MessageBox.Show("直线检测区域未设置，请确认！");
                        else 
                        {
                            if (RegionRRect != null && RegionRRect != null &&
                                RegionRRect.Size.Width > 0 && RegionRRect2.Size.Width > 0)
                            {
                                SearchROI1.Clear();
                                shapeConvert(RegionRRect, out RotatedRectF rotatedRectF);
                                shapeConvert(RegionRRect2, out RotatedRectF rotatedRectF2);
                                SearchROI1.Add(rotatedRectF);
                                SearchROI1.Add(rotatedRectF2);

                            }
                            GeneralUse.WriteSerializationFile<List<Object>>("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_1\\" + inspectToolPath, SearchROI1);
                        }
                        toolList.Add("直线定位");
                        break;
                    case 3:
                        if ((RegionaRect == null ||
                            RegionaRect.Width <= 0) && SearchROI1.Count <= 0)
                            MessageBox.Show("Blob检测区域未设置，请确认！");
                        else
                        {
                            if (RegionaRect != null && RegionaRect.Width > 0)
                            {
                                SearchROI1.Clear();
                                shapeConvert(RegionaRect, out RectangleF rectangleF);
                                SearchROI1.Add(rectangleF);
                            }
                            GeneralUse.WriteSerializationFile<List<Object>>("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_1\\" + inspectToolPath, SearchROI1);

                        }
                        toolList.Add("Blob定位");
                        break;
                    case 2:
                        if ((sectorF == null|| sectorF.getRadius<=0) && SearchROI1.Count <= 0)
                            MessageBox.Show("圆检测区域未设置，请确认！");
                        else
                        {
                            if (sectorF != null&& sectorF.getRadius>0)
                            {
                                SearchROI1.Clear();
                                SearchROI1.Add(sectorF);
                            }

                            GeneralUse.WriteSerializationFile<List<Object>>("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_1\\" + inspectToolPath, SearchROI1);

                        }
                        toolList.Add("找圆定位");
                        break;                
                }
            }
            else if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
                    == EumModelType.ProductModel_2)
            {
                SaveLineParmas("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_2\\");
                SaveBlobParms("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_2\\");
                SaveCircleParmas("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_2\\");
            
                GeneralUse.WriteValue("附加工具", "工具编号",
                    CheckBoxselectID.ToString(), "附加工具类型", "配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_2");

                switch (CheckBoxselectID)
                {
                    case 1:
                        if ((RegionRRect == null || RegionRRect2 == null ||
                            RegionRRect.Size.Width <= 0 || RegionRRect2.Size.Width <= 0) 
                            && SearchROI2.Count <= 0)
                            MessageBox.Show("直线检测区域未设置，请确认！");
                        else
                        {
                            if (RegionRRect != null && RegionRRect2 != null &&
                                 RegionRRect.Size.Width > 0 && RegionRRect2.Size.Width > 0)

                            {
                                SearchROI2.Clear();
                                shapeConvert(RegionRRect, out RotatedRectF rotatedRectF);
                                shapeConvert(RegionRRect2, out RotatedRectF rotatedRectF2);
                                SearchROI2.Add(rotatedRectF);
                                SearchROI2.Add(rotatedRectF2);
                            }

                            GeneralUse.WriteSerializationFile<List<Object>>("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_2\\" + inspectToolPath, SearchROI2);
                        }
                        toolList.Add("直线定位");
                        break;
                    case 3:
                        if ((RegionaRect == null ||
                            RegionaRect.Width <= 0) && SearchROI1.Count <= 0)
                            MessageBox.Show("Blob检测区域未设置，请确认！");
                        else
                        {
                            if (RegionaRect != null && RegionaRect.Width > 0)
                            {
                                SearchROI2.Clear();
                                shapeConvert(RegionaRect, out RectangleF  rectangleF);                        
                                SearchROI2.Add(rectangleF);
                            }
                            GeneralUse.WriteSerializationFile<List<Object>>("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_2\\" + inspectToolPath, SearchROI2);
                        }
                        toolList.Add("Blob定位");
                        break;
                    case 2:
                        if ((sectorF == null || sectorF.getRadius <= 0) && SearchROI1.Count <= 0)
                            MessageBox.Show("圆检测区域未设置，请确认！");
                        else
                        {
                            if (sectorF != null && sectorF.getRadius > 0)
                            {
                                SearchROI2.Clear();
                                SearchROI2.Add(sectorF);
                            }
                            GeneralUse.WriteSerializationFile<List<Object>>("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_2\\" + inspectToolPath, SearchROI2);
                        }
                        toolList.Add("找圆定位");
                        break;                  

                }

            }
            else if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
                     == EumModelType.CalibModel)
            {

                SaveLineParmas("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\CaliBoardModel\\");
                SaveBlobParms("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\CaliBoardModel\\");
                SaveCircleParmas("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\CaliBoardModel\\");           
            }
            else
            {
                SaveLineParmas("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\GlueTapModel\\");
                SaveBlobParms("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\GlueTapModel\\");
                SaveCircleParmas("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\GlueTapModel\\");
             
                GeneralUse.WriteValue("附加工具", "工具编号",
               CheckBoxselectID.ToString(), "附加工具类型", "配方\\" + CurrRecipeName +
             "\\" + "modelfile\\GlueTapModel");

                if(CheckBoxselectID==3)
                {
                    ///只给开放Blob中心
                    if ((RegionaRect == null ||
                              RegionaRect.Width <= 0) && SearchROI3.Count <= 0)
                        MessageBox.Show("Blob检测区域未设置，请确认！");                 
                    else
                    {
                        if (RegionaRect != null && RegionaRect.Width > 0)
                        {
                            SearchROI3.Clear();
                            shapeConvert(RegionaRect, out RectangleF rectangleF);
                            SearchROI3.Add(rectangleF);
                        }
                        GeneralUse.WriteSerializationFile<List<Object>>("配方\\" + CurrRecipeName +
              "\\" + "modelfile\\GlueTapModel\\" + inspectToolPath, SearchROI3);
                    }
                    toolList.Add("Blob定位");
                }              
            }
        }

        //模板相关参数保存
        void SaveModelMatchParma()
        {
            try
            {
             
                 parmaData = new ShapeMatchData();              
                (parmaData as ShapeMatchData).tpContour = templateContour;
                (parmaData as ShapeMatchData).Segthreshold = (double)NumSegthreshold.Value;
                (parmaData as ShapeMatchData).MatchValue = (double)NumMatchValue.Value;
                (parmaData as ShapeMatchData).MincoutourLen = (int)NumMincoutourLen.Value;
                (parmaData as ShapeMatchData).MaxcoutourLen = (int)NumMaxcoutourLen.Value;
                (parmaData as ShapeMatchData).MinContourArea = (int)NumMinContourArea.Value;
                (parmaData as ShapeMatchData).MaxContourArea = (int)NumMaxContourArea.Value;

                if (matchBaseInfo == null)
                    matchBaseInfo = new MatchBaseInfo();
                matchBaseInfo.BaseX =double.Parse( lIstModelInfo.Items[0].SubItems[1].Text);
                matchBaseInfo.BaseY = double.Parse(lIstModelInfo.Items[1].SubItems[1].Text);
                matchBaseInfo.BaseAngle = double.Parse(lIstModelInfo.Items[2].SubItems[1].Text);
                matchBaseInfo.ContourLength = double.Parse(lIstModelInfo.Items[3].SubItems[1].Text);
                matchBaseInfo.ContourArea = double.Parse(lIstModelInfo.Items[4].SubItems[1].Text);

                if (!Directory.Exists("配方\\" + CurrRecipeName +
                      "\\Config"))
                    Directory.CreateDirectory("配方\\" + CurrRecipeName +
                      "\\Config");
                GeneralUse.WriteValue("当前模板", "类型",
                       cobxModelType.Text, "模板匹配类型", "配方\\" + CurrRecipeName + "\\Config");
                
             
                if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
                        == EumModelType.ProductModel_1)
                {
                    GeneralUse.WriteValue("模板", "模板匹配", isUsingModelMatch.ToString(), "config",
                      "配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_1\\Config");
                    GeneralUse.WriteValue("模板", "自动圆匹配", isUsingAutoCircleMatch.ToString(), "config",
                             "配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_1\\Config");
                    GeneralUse.WriteValue("模板", "模板基准点", modelOrigion.ToString(), "config",
                             "配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_1\\Config");

                    GeneralUse.WriteSerializationFile<MatchBaseInfo>("配方\\" + CurrRecipeName + 
                        "\\modelfile\\ProductModel_1\\Config\\基准轮廓信息.ini"
                                          , matchBaseInfo);
                    

                    if (isUsingModelMatch)
                        toolList.Add("模板匹配");
                    else if (isUsingAutoCircleMatch)
                        toolList.Add("自动圆匹配");

                    //模板保存
                    if (!this.modeltp.Empty())
                        MatDataWriteRead.WriteImage("配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_1" +
                                 "\\模板.png", modeltp);
                    GeneralUse.WriteSerializationFile<ShapeMatchData>("配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_1"
                                  + "\\形状匹配.ini"    , parmaData as ShapeMatchData);
                  
                    SaveCircleMatchParma("配方\\" + CurrRecipeName +
                                                  "\\" + "modelfile\\ProductModel_1\\"); SaveModelparmasHandle?.Invoke("配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_1", null);
                    GeneralUse.WriteSerializationFile<RectangleF>("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\ProductModel_1\\模板创建区域.rectf", setModelROIData);
              
                    Appentxt(string.Format("当前模板：{0}",
                       Enum.GetName(typeof(EumModelType), currModelType)) +

                       ((currModelType == EumModelType.ProductModel_1) ? "，模板基准点:" + modelOrigion : "")
                       );
                }
                else if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
                        == EumModelType.ProductModel_2)
                {
                    GeneralUse.WriteValue("模板", "模板匹配", isUsingModelMatch.ToString(), "config",
                       "配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_2\\Config");
                    GeneralUse.WriteValue("模板", "自动圆匹配", isUsingAutoCircleMatch.ToString(), "config",
                             "配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_2\\Config");

                    GeneralUse.WriteValue("模板", "模板基准点", modelOrigion.ToString(), "config",
                           "配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_2\\Config");

                    GeneralUse.WriteSerializationFile<MatchBaseInfo>("配方\\" + CurrRecipeName +
                        "\\modelfile\\ProductModel_2\\Config\\基准轮廓信息.ini"
                                          , matchBaseInfo);
                    if (isUsingModelMatch)
                        toolList.Add("模板匹配");
                    else if (isUsingAutoCircleMatch)
                        toolList.Add("自动圆匹配");

                    //模板保存
                    if (!this.modeltp.Empty())
                        MatDataWriteRead.WriteImage("配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_2" +
                                 "\\模板.png", modeltp);
                    GeneralUse.WriteSerializationFile<ShapeMatchData>("配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_2"
                             + "\\形状匹配.ini", parmaData as ShapeMatchData);
                 

                    SaveCircleMatchParma("配方\\" + CurrRecipeName +
                "\\" + "modelfile\\ProductModel_2\\");

                    SaveModelparmasHandle?.Invoke("配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_2", null);
                    GeneralUse.WriteSerializationFile<RectangleF>("配方\\" + CurrRecipeName +
                 "\\" + "modelfile\\ProductModel_2\\模板创建区域.rectf", setModelROIData);

                   
                    Appentxt(string.Format("当前模板：{0}",
                       Enum.GetName(typeof(EumModelType), currModelType)) +

                       ((currModelType == EumModelType.ProductModel_2) ? "，模板基准点:" + modelOrigion : "")
                       );

                }
                else if ((EumModelType)Enum.Parse(typeof(EumModelType), cobxModelType.Text)
                         == EumModelType.CalibModel)
                {
                    GeneralUse.WriteValue("模板", "模板匹配", isUsingModelMatch.ToString(), "config",
                    "配方\\" + CurrRecipeName + "\\modelfile\\CaliBoardModel\\Config");
                    GeneralUse.WriteValue("模板", "自动圆匹配", isUsingAutoCircleMatch.ToString(), "config",
                             "配方\\" + CurrRecipeName + "\\modelfile\\CaliBoardModel\\Config");

                    GeneralUse.WriteSerializationFile<MatchBaseInfo>("配方\\" + CurrRecipeName +
                     "\\modelfile\\CaliBoardModel\\Config\\基准轮廓信息.ini"
                                       , matchBaseInfo);

                    if (isUsingModelMatch)
                        toolList.Add("模板匹配");
                    else if (isUsingAutoCircleMatch)
                        toolList.Add("自动圆匹配");

                    //模板保存
                    if (!this.modeltp.Empty())
                        MatDataWriteRead.WriteImage("配方\\" + CurrRecipeName + "\\modelfile\\CaliBoardModel" +
                                 "\\模板.png", modeltp);
                    GeneralUse.WriteSerializationFile<ShapeMatchData>("配方\\" + CurrRecipeName + "\\modelfile\\CaliBoardModel"
                              + "\\形状匹配.ini", parmaData as ShapeMatchData);
                  
                    SaveCircleMatchParma("配方\\" + CurrRecipeName +
              "\\" + "modelfile\\CaliBoardModel\\");

                    // SaveModelparmasHandle?.Invoke(CaliconfigPath, null);   自动检测不需要知道标定板更新
                    GeneralUse.WriteSerializationFile<RectangleF>("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\CaliBoardModel\\模板创建区域.rectf", setModelROIData);
                }
                else
                {
                    GeneralUse.WriteValue("模板", "模板匹配", isUsingModelMatch.ToString(), "config",
                  "配方\\" + CurrRecipeName + "\\modelfile\\GlueTapModel\\Config");
                    GeneralUse.WriteValue("模板", "自动圆匹配", isUsingAutoCircleMatch.ToString(), "config",
                             "配方\\" + CurrRecipeName + "\\modelfile\\GlueTapModel\\Config");
                    GeneralUse.WriteValue("模板", "模板基准点", modelOrigion.ToString(), "config",
                           "配方\\" + CurrRecipeName + "\\modelfile\\GlueTapModel\\Config");
                    GeneralUse.WriteSerializationFile<MatchBaseInfo>("配方\\" + CurrRecipeName +
                 "\\modelfile\\GlueTapModel\\Config\\基准轮廓信息.ini"
                                   , matchBaseInfo);

                    if (isUsingModelMatch)
                        toolList.Add("模板匹配");
                    else if (isUsingAutoCircleMatch)
                        toolList.Add("自动圆匹配");

                    //模板保存
                    if (!this.modeltp.Empty())
                        MatDataWriteRead.WriteImage("配方\\" + CurrRecipeName + "\\modelfile\\GlueTapModel" +
                                 "\\模板.png", modeltp);
                    GeneralUse.WriteSerializationFile<ShapeMatchData>("配方\\" + CurrRecipeName + "\\modelfile\\GlueTapModel"
                                + "\\形状匹配.ini", parmaData as ShapeMatchData);                

                    SaveCircleMatchParma("配方\\" + CurrRecipeName +
                  "\\" + "modelfile\\GlueTapModel\\");

                    GeneralUse.WriteSerializationFile<RectangleF>("配方\\" + CurrRecipeName +
                "\\" + "modelfile\\GlueTapModel\\模板创建区域.rectf", setModelROIData);

                   
                    Appentxt(string.Format("当前模板：{0}",
                       Enum.GetName(typeof(EumModelType), currModelType)) +

                       ((currModelType == EumModelType.GluetapModel) ? "，模板基准点:" + modelOrigion : "")
                       );
                }
               // MessageBox.Show("模板相关参数保存成功！");


            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        //保存圆匹配参数
        void SaveCircleMatchParma(string direFilePath)
        {
            parmaData = new HoughCircleData();
            (parmaData as HoughCircleData).MinDist = (double)NumMinDist.Value;
            (parmaData as HoughCircleData).Param1 = (double)NumParam1.Value;
            (parmaData as HoughCircleData).Param2 = (double)NumParam2.Value;
            (parmaData as HoughCircleData).MinRadius = (int)numberMinRadius.Value;
            (parmaData as HoughCircleData).MaxRadius = (int)numberMaxRadius.Value;          
            GeneralUse.WriteSerializationFile<HoughCircleData>(direFilePath + CirleMatchconfigPath,
                      parmaData as HoughCircleData);

        } 
        //保存直线检测参数
        void SaveLineParmas(string direFilePath)
        {
            //霍夫直线参数
            parmaData = new HoughLinesPData
            {
                canThddown = (double)NumcanThddown.Value,
                canThdup = (double)NumcanThdup.Value,
                ThresholdP = (int)NumThresholdP.Value,
                MinLineLenght = (double)NumMinLineLenght.Value,
                MaxLineGap = (double)NumMaxLineGap.Value
            };
            //parmaData.ROI = new RotatedRectF( RegionRRect.Center.X, RegionRRect.Center.Y,
            //    RegionRRect.Size.Width, RegionRRect.Size.Height, RegionRRect.Angle);


            GeneralUse.WriteSerializationFile<HoughLinesPData>(direFilePath + Line1configPath,
                                                parmaData as HoughLinesPData);

            //霍夫直线2参数
            parmaData = new HoughLinesPData
            {
                canThddown = (double)NumcanThddown2.Value,
                canThdup = (double)NumcanThdup2.Value,
                ThresholdP = (int)NumThresholdP2.Value,
                MinLineLenght = (double)NumMinLineLenght2.Value,
                MaxLineGap = (double)NumMaxLineGap2.Value
            };
            //parmaData.ROI = new RotatedRectF(RegionRRect.Center.X, RegionRRect.Center.Y,
            //   RegionRRect.Size.Width, RegionRRect.Size.Height, RegionRRect.Angle);

            GeneralUse.WriteSerializationFile<HoughLinesPData>(direFilePath + Line2configPath,
                                        parmaData as HoughLinesPData);

        }
        //保存圆检测参数
        void SaveCircleParmas(string direFilePath)
        {
            parmaData = new FitCircleData();
            (parmaData as FitCircleData).maxRadius = (double)NummaxRadius.Value;
            (parmaData as FitCircleData).minRadius = (double)NumminRadius.Value;
            (parmaData as FitCircleData).EdgeThreshold = (int)NumEdgeThreshold.Value;
            (parmaData as FitCircleData).sectorF = sectorF;

            GeneralUse.WriteSerializationFile<FitCircleData>(direFilePath + CircleconfigPath,
           parmaData as FitCircleData);

        }
        //保存Blob检测参数
        void SaveBlobParms(string direFilePath)
        { 
            //Blob3检测参数
            parmaData = new Blob3Data
            {
                edgeThreshold = (double)Numminthd.Value,
                minArea = (int)NumareaLow.Value,
                maxArea = (int)NumareaHigh.Value,
                eumWhiteOrBlack = (EumWhiteOrBlack)Enum.Parse(typeof(EumWhiteOrBlack), cobxPolarity.Text)

            };
            //parmaData.ROI = RegionaRect;

            GeneralUse.WriteSerializationFile<Blob3Data>(direFilePath + BlobconfigPath, parmaData as Blob3Data);
        }

        /*----------------------------------------------------------------*/
        //加载模板参数
        void ModelMatchLoadParma(string dirFileName, EumModelType _currModelType = EumModelType.None)
        {
            if (!Directory.Exists(dirFileName))
                Directory.CreateDirectory(dirFileName);

            if (_currModelType == EumModelType.None)
                currModelType = (EumModelType)Enum.Parse(typeof(EumModelType),
                    GeneralUse.ReadValue("当前模板", "类型", "模板匹配类型", "ProductModel_1", dirFileName + "\\Config"));
            else
                currModelType = _currModelType;
          
            try
            {
                picTemplate.Image = null;

                if (currModelType == EumModelType.ProductModel_1)
                {
                    //模板加载
                    string templatePath = dirFileName + "\\modelfile\\ProductModel_1" + "\\模板.png";
                    if (File.Exists(templatePath))
                        this.modeltp = MatDataWriteRead.ReadImage(templatePath);                 

                    parmaData = GeneralUse.ReadSerializationFile<ShapeMatchData>(dirFileName + "\\modelfile\\ProductModel_1" + "\\形状匹配.ini");

                }                       
                else if (currModelType == EumModelType.ProductModel_2)
                { 
                    //模板加载
                    string templatePath = dirFileName + "\\modelfile\\ProductModel_2" + "\\模板.png";
                    if (File.Exists(templatePath))
                        this.modeltp = MatDataWriteRead.ReadImage(templatePath);

                    parmaData = GeneralUse.ReadSerializationFile<ShapeMatchData>(dirFileName + "\\modelfile\\ProductModel_2" + "\\形状匹配.ini");

                }
                                 
                else if (currModelType == EumModelType.CalibModel)
                {
                    //模板加载
                    string templatePath = dirFileName + "\\modelfile\\CaliBoardModel" + "\\模板.png";
                    if (File.Exists(templatePath))
                        this.modeltp = MatDataWriteRead.ReadImage(templatePath);

                    parmaData = GeneralUse.ReadSerializationFile<ShapeMatchData>(dirFileName + "\\modelfile\\CaliBoardModel" + "\\形状匹配.ini");

                }

                else
                {
                    //模板加载
                    string templatePath = dirFileName + "\\modelfile\\GlueTapModel" + "\\模板.png";
                    if (File.Exists(templatePath))
                        this.modeltp = MatDataWriteRead.ReadImage(templatePath);

                    parmaData = GeneralUse.ReadSerializationFile<ShapeMatchData>(dirFileName + "\\modelfile\\GlueTapModel" + "\\形状匹配.ini");

                }

               templateContour = (parmaData as ShapeMatchData).tpContour;
               NumSegthreshold.Value = (decimal)(parmaData as ShapeMatchData).Segthreshold;
                NumMatchValue.Value = (decimal)(parmaData as ShapeMatchData).MatchValue;
                NumMincoutourLen.Value = (decimal)(parmaData as ShapeMatchData).MincoutourLen;
                NumMaxcoutourLen.Value = (decimal)(parmaData as ShapeMatchData).MaxcoutourLen;
                NumMinContourArea.Value = (decimal)(parmaData as ShapeMatchData).MinContourArea;
                NumMaxContourArea.Value = (decimal)(parmaData as ShapeMatchData).MaxContourArea;

             
                if (!this.modeltp.Empty() && this.modeltp.Width >0)
                    picTemplate.Image = BitmapConverter.ToBitmap(this.modeltp);

                string errmsg = string.Empty;
                if (currModelType == EumModelType.ProductModel_1)
                {                  
                    setModelROIData= GeneralUse.ReadSerializationFile<RectangleF>("配方\\" + CurrRecipeName +
                                   "\\" + "modelfile\\ProductModel_1\\模板创建区域.rectf");

                    LoadCircleMatchParmas(dirFileName + "\\" + "modelfile\\ProductModel_1\\");

                    chxbModelMatch.Checked = isUsingModelMatch = bool.Parse(GeneralUse.ReadValue("模板", "模板匹配", "config",
                                   "true", dirFileName + "\\modelfile\\ProductModel_1\\Config"));
                    chxbAutoCircleMatch.Checked = isUsingAutoCircleMatch = bool.Parse(GeneralUse.ReadValue("模板", "自动圆匹配", "config",
                                    "false", dirFileName + "\\modelfile\\ProductModel_1\\Config"));

                    modelOrigion= GeneralUse.ReadValue("模板", "模板基准点", "config","0,0,0",
                         "配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_1\\Config");

                    matchBaseInfo =GeneralUse.ReadSerializationFile<MatchBaseInfo>("配方\\" + CurrRecipeName +
             "\\modelfile\\ProductModel_1\\Config\\基准轮廓信息.ini");
                             
                    if (isUsingModelMatch)
                        toolList.Add("模板匹配");
                    else if (isUsingAutoCircleMatch)
                        toolList.Add("自动圆匹配");

                }
                else if (currModelType == EumModelType.ProductModel_2)
                {
                    setModelROIData = GeneralUse.ReadSerializationFile<RectangleF>("配方\\" + CurrRecipeName +
                                     "\\" + "modelfile\\ProductModel_2\\模板创建区域.rectf");

                    LoadCircleMatchParmas(dirFileName + "\\" + "modelfile\\ProductModel_2\\");

                    chxbModelMatch.Checked = isUsingModelMatch = bool.Parse(GeneralUse.ReadValue("模板", "模板匹配", "config",
                                        "true", dirFileName + "\\modelfile\\ProductModel_2\\Config"));
                    chxbAutoCircleMatch.Checked = isUsingAutoCircleMatch = bool.Parse(GeneralUse.ReadValue("模板", "自动圆匹配", "config",
                                      "false", dirFileName + "\\modelfile\\ProductModel_2\\Config"));
                    modelOrigion = GeneralUse.ReadValue("模板", "模板基准点", "config", "0,0,0",
                        "配方\\" + CurrRecipeName + "\\modelfile\\ProductModel_2\\Config");

                    matchBaseInfo = GeneralUse.ReadSerializationFile<MatchBaseInfo>("配方\\" + CurrRecipeName +
            "\\modelfile\\ProductModel_2\\Config\\基准轮廓信息.ini");

                    if (isUsingModelMatch)
                        toolList.Add("模板匹配");
                    else if (isUsingAutoCircleMatch)
                        toolList.Add("自动圆匹配");

                }
                else if (currModelType == EumModelType.CalibModel)
                {
                    setModelROIData = GeneralUse.ReadSerializationFile<RectangleF>("配方\\" + CurrRecipeName +
                                        "\\" + "modelfile\\CaliBoardModel\\模板创建区域.rectf");
                
                    LoadCircleMatchParmas(dirFileName + "\\" + "modelfile\\CaliBoardModel\\");

                    chxbModelMatch.Checked = isUsingModelMatch = bool.Parse(GeneralUse.ReadValue("模板", "模板匹配", "config",
                                           "true", dirFileName + "\\modelfile\\CaliBoardModel\\Config"));
                    chxbAutoCircleMatch.Checked = isUsingAutoCircleMatch = bool.Parse(GeneralUse.ReadValue("模板", "自动圆匹配", "config",
                                             "false", dirFileName + "\\modelfile\\CaliBoardModel\\Config"));
                    matchBaseInfo = GeneralUse.ReadSerializationFile<MatchBaseInfo>("配方\\" + CurrRecipeName +
             "\\modelfile\\CaliBoardModel\\Config\\基准轮廓信息.ini");

                    if (isUsingModelMatch)
                        toolList.Add("模板匹配");
                    else if (isUsingAutoCircleMatch)
                        toolList.Add("自动圆匹配");
                }
                else
                {
                    setModelROIData = GeneralUse.ReadSerializationFile<RectangleF>("配方\\" + CurrRecipeName +
                                             "\\" + "modelfile\\GlueTapModel\\模板创建区域.rectf");
                 
                    LoadCircleMatchParmas(dirFileName + "\\" + "modelfile\\GlueTapModel\\");

                    chxbModelMatch.Checked = isUsingModelMatch = bool.Parse(GeneralUse.ReadValue("模板", "模板匹配", "config",
                                        "true", dirFileName + "\\modelfile\\GlueTapModel\\Config"));
                    chxbAutoCircleMatch.Checked = isUsingAutoCircleMatch = bool.Parse(GeneralUse.ReadValue("模板", "自动圆匹配", "config",
                                                "false", dirFileName + "\\modelfile\\GlueTapModel\\Config"));
                    modelOrigion = GeneralUse.ReadValue("模板", "模板基准点", "config", "0,0,0",
                        "配方\\" + CurrRecipeName + "\\modelfile\\GlueTapModel\\Config");
                    matchBaseInfo = GeneralUse.ReadSerializationFile<MatchBaseInfo>("配方\\" + CurrRecipeName +
            "\\modelfile\\GlueTapModel\\Config\\基准轮廓信息.ini");

                    if (isUsingModelMatch)
                        toolList.Add("模板匹配");
                    else if (isUsingAutoCircleMatch)
                        toolList.Add("自动圆匹配");

                }
                if (matchBaseInfo == null)
                    matchBaseInfo = new MatchBaseInfo();
                lIstModelInfo.Items.Clear();
                lIstModelInfo.Items.Add(new ListViewItem(
                    new string[] { "BaseX", matchBaseInfo.BaseX.ToString("f3") }));
                lIstModelInfo.Items.Add(new ListViewItem(
                  new string[] { "BaseY", matchBaseInfo.BaseY.ToString("f3") }));
                lIstModelInfo.Items.Add(new ListViewItem(
                  new string[] { "BaseAngle", matchBaseInfo.BaseAngle.ToString("f3") }));
                lIstModelInfo.Items.Add(new ListViewItem(
                 new string[] { "ContourLength", matchBaseInfo.ContourLength.ToString("f3") }));
                lIstModelInfo.Items.Add(new ListViewItem(
                 new string[] { "ContourArea", matchBaseInfo.ContourArea.ToString("f3") }));

           
                if (templateContour == null || templateContour.Length < 1)
                {
                    //MessageBox.Show("参数加载失败");
                    Appentxt("参数加载失败:模板为空！");
                }

            }
            catch (Exception er)
            { //MessageBox.Show("参数加载失败");
                Appentxt("参数加载失败:" + er.Message);
            }

            Appentxt(string.Format("当前加载模板：{0}",
                        Enum.GetName(typeof(EumModelType), currModelType)) +

                        ((currModelType == EumModelType.ProductModel_1 ||
                           currModelType == EumModelType.ProductModel_2 ||
                               currModelType == EumModelType.GluetapModel) ? "，模板基准点:" + modelOrigion : "")
                        );

        }
        //加载圆匹配参数
        void LoadCircleMatchParmas(string direFilePath)
        {
            parmaData = GeneralUse.ReadSerializationFile<HoughCircleData>(direFilePath + CirleMatchconfigPath);
            if (parmaData == null)
                parmaData = new HoughCircleData();
            else
            {
                NumMinDist.Value = (decimal)(parmaData as HoughCircleData).MinDist;
                NumParam1.Value = (decimal)(parmaData as HoughCircleData).Param1;
                NumParam2.Value = (decimal)(parmaData as HoughCircleData).Param2;
                numberMinRadius.Value = (decimal)(parmaData as HoughCircleData).MinRadius;
                numberMaxRadius.Value = (decimal)(parmaData as HoughCircleData).MaxRadius;

            }
        }
        //加载直线检测参数
        void LoadLineParmas(string direFilePath)
        {
            //直线1
            parmaData= GeneralUse.ReadSerializationFile<HoughLinesPData>(direFilePath + Line1configPath);
            if (parmaData == null)
                parmaData = new HoughLinesPData();
            NumcanThddown.Value =(decimal)(parmaData as HoughLinesPData).canThddown;
            NumcanThdup.Value = (decimal)(parmaData as HoughLinesPData).canThdup;
            NumThresholdP.Value = (decimal)(parmaData as HoughLinesPData).ThresholdP;
            NumMinLineLenght.Value = (decimal)(parmaData as HoughLinesPData).MinLineLenght;
            NumMaxLineGap.Value = (decimal)(parmaData as HoughLinesPData).MaxLineGap;
            //直线2
            parmaData = GeneralUse.ReadSerializationFile<HoughLinesPData>(direFilePath + Line2configPath);
            if (parmaData == null)
                parmaData = new HoughLinesPData();
            NumcanThddown2.Value = (decimal)(parmaData as HoughLinesPData).canThddown;
            NumcanThdup2.Value = (decimal)(parmaData as HoughLinesPData).canThdup;
            NumThresholdP2.Value = (decimal)(parmaData as HoughLinesPData).ThresholdP;
            NumMinLineLenght2.Value = (decimal)(parmaData as HoughLinesPData).MinLineLenght;
            NumMaxLineGap2.Value = (decimal)(parmaData as HoughLinesPData).MaxLineGap;
        
        }
        //加载圆检测参数
        void LoadCirlceParmas(string direFilePath)
        {
            parmaData = GeneralUse.ReadSerializationFile<FitCircleData>(direFilePath + CircleconfigPath);
            if (parmaData == null)
                parmaData = new FitCircleData();
            NummaxRadius.Value=(decimal)(parmaData as FitCircleData).maxRadius ;
            NumminRadius.Value = (decimal)(parmaData as FitCircleData).minRadius ;

            NumEdgeThreshold.Value= (decimal)(parmaData as FitCircleData).EdgeThreshold ;
            sectorF=(parmaData as FitCircleData).sectorF;        
        
        }
        //加载Blob检测参数
        void LoadBlobParmas(string direFilePath)
        {
                   
          parmaData =  GeneralUse.ReadSerializationFile<Blob3Data>(direFilePath + BlobconfigPath);
            if (parmaData == null)
                parmaData = new Blob3Data();
            //Blob3检测参数
            Numminthd.Value = (decimal)(parmaData as Blob3Data).edgeThreshold;
            NumareaLow.Value= (decimal)(parmaData as Blob3Data).minArea;
            NumareaHigh.Value= (decimal)(parmaData as Blob3Data).maxArea;
            cobxPolarity.Text = Enum.GetName(typeof(EumWhiteOrBlack), (parmaData as Blob3Data).eumWhiteOrBlack);          
            
        }
       // 加载测试工具
        void LoadTestingTools(string dirFileName, EumModelType _currModelType = EumModelType.None)
        {
            if (!Directory.Exists(dirFileName))
                Directory.CreateDirectory(dirFileName);

            if (_currModelType == EumModelType.None)
                currModelType = (EumModelType)Enum.Parse(typeof(EumModelType),
                    GeneralUse.ReadValue("当前模板", "类型", "模板匹配类型", "ProductModel_1", dirFileName + "\\Config"));
            else
                currModelType = _currModelType;

            if (currModelType == EumModelType.ProductModel_1)
            {
                //定位检测工具
                LoadLineParmas(dirFileName + "\\" +
                    "modelfile\\ProductModel_1\\");
                LoadCirlceParmas(dirFileName + "\\" +
                    "modelfile\\ProductModel_1\\");
                LoadBlobParmas(dirFileName + "\\" +
                    "modelfile\\ProductModel_1\\");
             
                //附加工具
                CheckBoxselectID = int.Parse(GeneralUse.ReadValue("附加工具", "工具编号",
                  "附加工具类型", "-1", dirFileName + "\\" +
                  "modelfile\\ProductModel_1"));
                ExchangeSelect(CheckBoxselectID);
                if (CheckBoxselectID == 1)
                    toolList.Add("直线定位");
                else if (CheckBoxselectID == 2)
                    toolList.Add("找圆定位");
                else if (CheckBoxselectID == 3)
                    toolList.Add("Blob定位");
               
                //附加工具检测区域
                SearchROI1 = GeneralUse.ReadSerializationFile<List<Object>>(dirFileName + "\\" +
                      "modelfile\\ProductModel_1\\" + inspectToolPath);
                if (SearchROI1 == null)
                {
                    SearchROI1 = new List<Object>();
                    Appentxt("当前定位只使用模板(产品模板1)定位，未使用其它附件检测工具!");
                }
            }
            else if (currModelType == EumModelType.ProductModel_2)
            {

                //定位检测工具
                LoadLineParmas(dirFileName + "\\" +
                    "modelfile\\ProductModel_2\\");
                LoadCirlceParmas(dirFileName + "\\" +
                    "modelfile\\ProductModel_2\\");
                LoadBlobParmas(dirFileName + "\\" +
                    "modelfile\\ProductModel_2\\");
               
                //附加工具
                CheckBoxselectID = int.Parse(GeneralUse.ReadValue("附加工具", "工具编号",
                 "附加工具类型", "-1", dirFileName + "\\" +
                 "modelfile\\ProductModel_2"));
                ExchangeSelect(CheckBoxselectID);
                if (CheckBoxselectID == 1)
                    toolList.Add("直线定位");
                else if (CheckBoxselectID == 2)
                    toolList.Add("找圆定位");
                else if (CheckBoxselectID == 3)
                    toolList.Add("Blob定位");
             
                //附加工具检测区域
                SearchROI2 = GeneralUse.ReadSerializationFile<List<Object>>(dirFileName + "\\" +
                    "modelfile\\ProductModel_2\\" + inspectToolPath);
                if (SearchROI2 == null)
                {
                    SearchROI2 = new List<Object>();
                    Appentxt("当前定位只使用模板(产品模板2)定位，未使用其它附件检测工具!");
                }
            }
            else if (currModelType == EumModelType.CalibModel)
            {
                //附加工具
                CheckBoxselectID = -1;
                ExchangeSelect(CheckBoxselectID);
                //定位检测工具
                LoadLineParmas(dirFileName + "\\" + "modelfile\\CaliBoardModel\\");
                LoadCirlceParmas(dirFileName + "\\" + "modelfile\\CaliBoardModel\\");
                LoadBlobParmas(dirFileName + "\\" + "modelfile\\CaliBoardModel\\");
              
            }
            else
            {
                //定位检测工具
                LoadLineParmas(dirFileName + "\\" + "modelfile\\GlueTapModel\\");
                LoadCirlceParmas(dirFileName + "\\" + "modelfile\\GlueTapModel\\");
                LoadBlobParmas(dirFileName + "\\" + "modelfile\\GlueTapModel\\");
            
                //附加工具
                CheckBoxselectID = int.Parse(GeneralUse.ReadValue("附加工具", "工具编号",
                  "附加工具类型", "-1", dirFileName + "\\" +
                  "modelfile\\GlueTapModel"));
                ExchangeSelect(CheckBoxselectID);
                if (CheckBoxselectID == 1)
                    toolList.Add("直线定位");
                else if (CheckBoxselectID == 2)
                    toolList.Add("找圆定位");
                else if (CheckBoxselectID == 3)
                    toolList.Add("Blob定位");             
                //附加工具检测区域
                SearchROI3 = GeneralUse.ReadSerializationFile<List<Object>>(dirFileName + "\\" +
                  "modelfile\\GlueTapModel\\" + inspectToolPath);
                if (SearchROI3 == null)
                {
                    SearchROI3 = new List<Object>();
                    Appentxt("当前定位只使用模板(胶水模板)定位，未使用其它附件检测工具!");
                }
            }
        }
        
        #endregion

        #region------------九点标定-----------
        private void btnConvert_Click(object sender, EventArgs e)
        {
            coorditionConvert();
        }
        /// <summary>
        /// 坐标系配方设置画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCoordiRecipe_Click(object sender, EventArgs e)
        {
            mp.Show();
        }

        string saveToUsePath = AppDomain.CurrentDomain.BaseDirectory + "配方\\default";
       
        //配方重载
        void RecipeSaveEvent(object sender, EventArgs e)
        {
            if (sender != null)
                saveToUsePath = sender.ToString();
            else
                saveToUsePath = AppDomain.CurrentDomain.BaseDirectory +
                              GeneralUse.ReadValue("配方", "使用路径", "config", "");
            string[] temarray = saveToUsePath.Split('\\');
            string recipeName = temarray[temarray.Length - 1];
            if (recipeName == "")
                recipeName = "default";
            if (!Directory.Exists("配方\\" + recipeName))
            {
                Directory.CreateDirectory("配方\\" + recipeName);
                Appentxt(string.Format("配方文件加载失败，当前配方:{0}不存在，请确认！", recipeName));
                MessageBox.Show(string.Format("配方文件加载失败，当前配方:{0}不存在，请确认！", recipeName));
                return;
            }
            Appentxt(string.Format("当前使用配方为：{0}", recipeName));
            CurrRecipeName = recipeName;
            CamExposure = (int)float.Parse(GeneralUse.ReadValue("相机", "曝光", "config", "10000", "配方\\" + recipeName));
            numCamExposure.Value = CamExposure;
            CamGain = (int)float.Parse(GeneralUse.ReadValue("相机", "增益", "config", "0", "配方\\" + recipeName));
            numCamGain.Value = CamGain;
          
            //9点标定文件
            LoadConfigOfNightPCali("配方\\" + recipeName);
            //旋转中心文件
            LoadConfigOfRorateParma("配方\\" + recipeName);
            //检测文件文件
            toolList.Clear();
         
            ModelMatchLoadParma("配方\\" + recipeName);
            LoadTestingTools("配方\\" + recipeName);
           
            EnableDetectionControl();
            cobxModelType.Text = Enum.GetName(typeof(EumModelType), currModelType);

            listViewFlow.Items.Clear();
            for (int i = 0; i < toolList.Count; i++)
                listViewFlow.Items.Add(new ListViewItem(new string[] { i.ToString(), toolList[i] }));

            currvisiontool.clearAll();
            currvisiontool.dispImage(GrabImg);
                
        }
       
        //检测相关控件使能
        void EnableDetectionControl()
        {
            lock(locker1)
            {
                if (currModelType == EumModelType.ProductModel_1
               || currModelType == EumModelType.ProductModel_2)
                {
                 //   chxbPretreatmentTool.Enabled = true;
                    chxbLinesIntersect.Enabled = true;
                    LinesIntersectPanel.Enabled = true;
                    chxbFindCircle.Enabled = true;
                    FindCirclePanel.Enabled = true;
                    chxbBlobCentre.Enabled = true;
                    BlobCentrePanel.Enabled = true;         
                }
                else if (currModelType == EumModelType.GluetapModel)
                {
                    //chxbPretreatmentTool.Enabled = false;
                    //chxbPretreatmentTool.Checked = false;
                    //PretreatmentToolPanel.Enabled = false;
                    chxbLinesIntersect.Enabled = false;
                    chxbLinesIntersect.Checked = false;
                    LinesIntersectPanel.Enabled = false;                
                    chxbFindCircle.Enabled = false;
                    chxbFindCircle.Checked = false;
                    FindCirclePanel.Enabled = false;
                    chxbBlobCentre.Enabled = true;
                    BlobCentrePanel.Enabled = true;                
                }
                else
                {
                    //chxbPretreatmentTool.Enabled = false;
                    //chxbPretreatmentTool.Checked = false;
                    //PretreatmentToolPanel.Enabled = false;
                    chxbLinesIntersect.Enabled = false;
                    chxbLinesIntersect.Checked = false;
                    LinesIntersectPanel.Enabled = false;          
                    chxbFindCircle.Enabled = false;
                    chxbFindCircle.Checked = false;
                    FindCirclePanel.Enabled = false;
                    chxbBlobCentre.Enabled = false;
                    chxbBlobCentre.Checked = false;
                    BlobCentrePanel.Enabled = false;
 
                }
                if (isUsingAutoCircleMatch)
                {
                    //chxbPretreatmentTool.Enabled = true;
                    //PretreatmentToolPanel.Enabled = true;

                    chxbLinesIntersect.Enabled = false;
                    chxbLinesIntersect.Checked = false;
                    LinesIntersectPanel.Enabled = false;

                    chxbFindCircle.Enabled = false;
                    chxbFindCircle.Checked = false;
                    FindCirclePanel.Enabled = false;

                    chxbBlobCentre.Enabled = false;
                    chxbBlobCentre.Checked = false;
                    BlobCentrePanel.Enabled = false;

                }

            }
        }
        //9点标定，Mark点像素坐标获取
        private void btnGetPixelPoint_Click(object sender, EventArgs e)
        {
            if (!CurrCam.IsAlive)
            {
                MessageBox.Show("相机未连接!");
                return;
            }
            workstatus = EunmcurrCamWorkStatus.NinePointcLocation;
            CurrCam.OneShot();
        }
        //新增像素坐标
        private void btnNewPixelPoint_Click(object sender, EventArgs e)
        {
            i++;
            string[] temarray = new string[3] { i.ToString(), txbpixelX.Text, txbpixelY.Text };
            SetValueToListItem(listViewPixel, temarray);
            txbpixelX.Clear();
            txbpixelY.Clear();
        }
        //修改像素坐标点
        private void btnModifyPixelPoint_Click(object sender, EventArgs e)
        {
            if (listViewPixel.Items.Count <= 0 || listViewPixel.SelectedItems == null)
                return;
            if (MessageBox.Show("确认修改？", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                int index = listViewPixel.SelectedIndices[0];
                listViewPixel.Items[index].SubItems[1].Text = txbpixelX.Text.Trim();
                listViewPixel.Items[index].SubItems[2].Text = txbpixelY.Text.Trim();
            }
        }
        //删除像素坐标点
        private void btnDeletePixelPoint_Click(object sender, EventArgs e)
        {
            if (listViewPixel.Items.Count <= 0 || listViewPixel.SelectedItems.Count == 0)
                return;
            if (MessageBox.Show("确认删除？", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                int index = listViewPixel.SelectedIndices[0];
                listViewPixel.Items.RemoveAt(index);

            }
        }
        //新增机器人坐标点
        private void BtnNewRobotPoint_Click(object sender, EventArgs e)
        {
            j++;
            string[] temarray2 = new string[3] { j.ToString(), txbrobotX.Text, txbrobotY.Text };
            SetValueToListItem(listViewRobot, temarray2);
            txbrobotX.Clear();
            txbrobotY.Clear();
        }
        //修改机器人坐标点
        private void btnModifyRobotPoint_Click(object sender, EventArgs e)
        {
            if (listViewRobot.Items.Count <= 0 || listViewRobot.SelectedItems == null)
                return;
            if (MessageBox.Show("确认修改？", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                int index = listViewRobot.SelectedIndices[0];
                listViewRobot.Items[index].SubItems[1].Text = txbrobotX.Text.Trim();
                listViewRobot.Items[index].SubItems[2].Text = txbrobotY.Text.Trim();
            }
        }
        //删除机器人坐标点
        private void btnDeleteRobotPoint_Click(object sender, EventArgs e)
        {
            if (listViewRobot.Items.Count <= 0 || listViewRobot.SelectedItems.Count == 0)
                return;
            if (MessageBox.Show("确认删除？", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                int index = listViewRobot.SelectedIndices[0];
                listViewRobot.Items.RemoveAt(index);

            }
        }
        //坐标系转换，矩阵计算
        void coorditionConvert()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(coorditionConvert));
            }
            else
            {
                if (listViewPixel.Items.Count != 9 || listViewRobot.Items.Count != 9)
                {
                    MessageBox.Show("点位坐标数据不足9条，请确认!");
                    return;
                }
                pixelList.Clear();
                for (int i = 0; i < 9; i++)
                {
                    pixelList.Add(new Point2d(
                                 double.Parse(listViewPixel.Items[i].SubItems[1].Text),
                               double.Parse(listViewPixel.Items[i].SubItems[2].Text)
                                 ));
                }
                robotList.Clear();
                for (int i = 0; i < 9; i++)
                {
                    robotList.Add(new Point2d(
                                 double.Parse(listViewRobot.Items[i].SubItems[1].Text),
                               double.Parse(listViewRobot.Items[i].SubItems[2].Text)
                                 ));
                }
                Hom_mat2d = CalibrationTool.VectorToHomMat2d(pixelList, robotList);
                double[] Coefficient = CalibrationTool.GetMatrixCoefficient(Hom_mat2d);
                label1.Text = Coefficient[0].ToString("f3");
                label2.Text = Coefficient[1].ToString("f3");
                label3.Text = Coefficient[2].ToString("f3");
                label4.Text = Coefficient[3].ToString("f3");
                label5.Text = Coefficient[4].ToString("f3");
                label6.Text = Coefficient[5].ToString("f3");

                txbSx.Text = Coefficient[0].ToString("f3");
                txbSy.Text = Coefficient[1].ToString("f3");
                txbPhi.Text = Coefficient[3].ToString("f3");
                txbTheta.Text = Coefficient[4].ToString("f3");
                txbTx.Text = Coefficient[2].ToString("f3");
                txbTy.Text = Coefficient[5].ToString("f3");
                double[] rms = CalibrationTool.calRMS(Hom_mat2d, pixelList, robotList);
                txbXRms.Text= rms[0].ToString("f3");
                txbYRms.Text = rms[1].ToString("f3");

            }
        }

        //根据标定矩阵关系，由像素坐标点转换成机器人坐标点
        private void picConvertPixelToRobot_Click(object sender, EventArgs e)
        {
            Point2d robotP= CalibrationTool.AffineTransPoint2d(Hom_mat2d,
                new Point2d(double.Parse(txbMarkPixelX.Text),
                double.Parse(txbMarkPixelY.Text)));
          
            txbMarkRobotX.Text = robotP.X.ToString("f3");
            txbMarkRobotY.Text = robotP.Y.ToString("f3");
        }
    
        //根据标定矩阵关系，由机器人坐标点转换成像素坐标点
        private void picConvertRobotToPixel_Click(object sender, EventArgs e)
        {
            Point2d pixelP = CalibrationTool.AffineTransPoint2dINV(Hom_mat2d,
              new Point2d(double.Parse(txbMarkRobotX.Text),
              double.Parse(txbMarkRobotY.Text)));           
            txbMarkPixelX.Text = pixelP.X.ToString("f3");
            txbMarkPixelY.Text = pixelP.Y.ToString("f3");

        }

        //control数据显示
        void showData(pixelPointDataClass pixeld1, robotPointDataClass robotd2,
                     converCoorditionDataClass converd3)
        {
            listViewPixel.Items.Clear();
            listViewRobot.Items.Clear();
            i = 0; j = 0;
            if (pixeld1 != null)
                foreach (var s in pixeld1.ListPoint)
                {
                    i++;
                    ListViewItem tem = new ListViewItem(new string[3] { i.ToString(), s.X.ToString(), s.Y.ToString() });
                    listViewPixel.Items.Add(tem);
                }

            if (robotd2 != null)
                foreach (var s in robotd2.ListPoint)
                {
                    j++;
                    ListViewItem tem = new ListViewItem(new string[3] { j.ToString(), s.X.ToString(), s.Y.ToString() });
                    listViewRobot.Items.Add(tem);
                }


            txbSx.Text = converd3.Sx.ToString();

            txbSy.Text = converd3.Sy.ToString();

            txbPhi.Text = converd3.Phi.ToString();

            txbTheta.Text = converd3.Theta.ToString();

            txbTx.Text = converd3.Tx.ToString();

            txbTy.Text = converd3.Ty.ToString();

            txbXRms.Text= converd3.XRms.ToString();

            txbYRms.Text = converd3.YRms.ToString();
        }
        //control数据保存
        void setData(ref pixelPointDataClass pixeld1, ref robotPointDataClass robotd2, ref converCoorditionDataClass converd3)

        {
            if (listViewPixel.Items.Count != 9 || listViewRobot.Items.Count != 9)
            {
                MessageBox.Show("点位坐标数据不足9条，请确认!");
                return;
            }
            pixeld1.ListPoint.Clear();
            foreach (ListViewItem s in listViewPixel.Items)
                pixeld1.ListPoint.Add(new PointF(float.Parse(s.SubItems[1].Text),
                    float.Parse(s.SubItems[2].Text)));

            robotd2.ListPoint.Clear();
            foreach (ListViewItem s in listViewRobot.Items)
                robotd2.ListPoint.Add(new PointF(float.Parse(s.SubItems[1].Text),
                     float.Parse(s.SubItems[2].Text)));

            if (!string.IsNullOrEmpty(txbSx.Text))
            {
                if (checkValueNumber(txbSx.Text))
                    converd3.Sx = double.Parse(txbSx.Text);
                if (checkValueNumber(txbSy.Text))
                    converd3.Sy = double.Parse(txbSy.Text);
                if (checkValueNumber(txbPhi.Text))
                    converd3.Phi = double.Parse(txbPhi.Text);
                if (checkValueNumber(txbTheta.Text))
                    converd3.Theta = double.Parse(txbTheta.Text);
                if (checkValueNumber(txbTx.Text))
                    converd3.Tx = double.Parse(txbTx.Text);
                if (checkValueNumber(txbTx.Text))
                    converd3.Ty = double.Parse(txbTy.Text);
                if (checkValueNumber(txbXRms.Text))
                    converd3.XRms = double.Parse(txbXRms.Text);
                if (checkValueNumber(txbYRms.Text))
                    converd3.YRms = double.Parse(txbYRms.Text);
            }

        }

        //9点标定配置文件保存
        public void SaveCofig(string dircFileName)
        {
            try
            {
                GeneralUse.WriteSerializationFile<pixelPointDataClass>(dircFileName + "\\Calib\\pixelPointData", d_pixelPointDataClass);
                GeneralUse.WriteSerializationFile<robotPointDataClass>(dircFileName + "\\Calib\\robotPointData", d_robotPointDataClass);
                GeneralUse.WriteSerializationFile<converCoorditionDataClass>(dircFileName + "\\Calib\\converCoorditionData", d_converCoorditionDataClass);

                if (Hom_mat2d != null&& Hom_mat2d.Width>0)
                {
                    string templatePath = dircFileName + "\\cv_HomMat2D";
                    MatDataWriteRead.WriteMatri(Hom_mat2d, templatePath,"mainNode");
                }                            
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);

            }
        }
        public void LoadConfigOfNightPCali(string dirFileName)
        {
            if (!Directory.Exists(dirFileName))
                Directory.CreateDirectory(dirFileName);
            try
            {

                d_pixelPointDataClass = GeneralUse.ReadSerializationFile<pixelPointDataClass>(dirFileName + "\\Calib\\pixelPointData");
                if (d_pixelPointDataClass == null)
                    d_pixelPointDataClass = new pixelPointDataClass();

                d_robotPointDataClass = GeneralUse.ReadSerializationFile<robotPointDataClass>(dirFileName + "\\Calib\\robotPointData");
                if (d_robotPointDataClass == null)
                    d_robotPointDataClass = new robotPointDataClass();

                d_converCoorditionDataClass = GeneralUse.ReadSerializationFile<converCoorditionDataClass>(dirFileName + "\\Calib\\converCoorditionData");
                if (d_converCoorditionDataClass == null)
                    d_converCoorditionDataClass = new converCoorditionDataClass();

               
                if (File.Exists(dirFileName + "\\" + "cv_HomMat2D"))
                    Hom_mat2d= MatDataWriteRead.ReadMatri(dirFileName + "\\" + "cv_HomMat2D", "mainNode");               
                else
                    MessageBox.Show("坐标系文件不存在，请确认！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception er)
            { MessageBox.Show(er.Message); }
            finally
            {
                showData(d_pixelPointDataClass, d_robotPointDataClass,
              d_converCoorditionDataClass);
            }

        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewPixel.Items.Clear();
            i = 0;
        }
        private void 清空ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listViewRobot.Items.Clear();
            j = 0;
        }
        //自动同步坐标系文件
        bool isAutoAutoCoorSys = false;
        private void chxbAutoCoorSys_CheckedChanged(object sender, EventArgs e)
        {
            isAutoAutoCoorSys = chxbAutoCoorSys.Checked;
            GeneralUse.WriteValue("坐标系", "同步", isAutoAutoCoorSys.ToString(), "config");
        }

        /// <summary>
        /// 自动同步更新9点+旋转中心标定文件
        /// </summary>
        void AutoUpdateCalibFile()
        {
            string _path = AppDomain.CurrentDomain.BaseDirectory + "配方";
            DirectoryInfo di = new DirectoryInfo(_path);
            //查找除去当前配方名称之外剩余的配方名称
            List<DirectoryInfo> directoryInfos1 = di.GetDirectories().ToList()
                              .FindAll(t => t.Name != CurrRecipeName);
            foreach (var s in directoryInfos1)
            {
                CopyFolder(_path + "\\" + CurrRecipeName + "\\Calib", s.FullName + "\\Calib");
                if (File.Exists(_path + "\\" + CurrRecipeName + "\\cv_HomMat2D"))
                    File.Copy(_path + "\\" + CurrRecipeName + "\\cv_HomMat2D",
                         s.FullName + "\\cv_HomMat2D", true);//复制文件
            }
        }
        /// <summary>
        /// 9点标定数据保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnSaveParmasOfNightPoints_click(object sender, EventArgs e)
        {
            try
            {  //九点标定关系参数保存
                setData(ref d_pixelPointDataClass, ref d_robotPointDataClass,
                          ref d_converCoorditionDataClass);
                SaveCofig("配方\\" + CurrRecipeName);
                SaveCaliParmaHandleOfNightPoint?.Invoke("配方\\" + CurrRecipeName + "\\cv_HomMat2D", null);
                if (isAutoAutoCoorSys)
                    AutoUpdateCalibFile();
            }
            catch (Exception er)
            {
                MessageBox.Show("参数保存失败！" + er.Message);
            }

        }

        #endregion

        #region------------旋转中心-----------
        private void chxbAutoCoorSys_CheckedChanged(object sender, bool value)
        {
            isAutoAutoCoorSys = chxbAutoCoorSys.Checked;
            GeneralUse.WriteValue("坐标系", "同步", isAutoAutoCoorSys.ToString(), "config");
        }
        //旋转标定，Mark点像素坐标获取
        private void btnGetRotataPixel_Click(object sender, EventArgs e)
        {
            if (!CurrCam.IsAlive)
            {
                MessageBox.Show("相机未连接!");
                return;
            }
            workstatus = EunmcurrCamWorkStatus.RotatoLocation;
            CurrCam.OneShot();

        }
        //计算旋转中心
        private void btnCaculateRorateCenter_Click(object sender, EventArgs e)
        {
            CaculateMultorRorateCenter();
        }

        private void btnSaveRotataPixel_Click(object sender, EventArgs e)
        {
            k++;
            string[] temarray = new string[3] { k.ToString(), txbRotataPixelX.Text, txbRotataPixelY.Text };
            SetValueToListItem(RoratepointListview, temarray);
            txbRotataPixelX.Clear();
            txbRotataPixelY.Clear();
        }
        //修改旋转像素坐标点
        private void btnModifyRotataPixel_Click(object sender, EventArgs e)
        {
            if (RoratepointListview.Items.Count <= 0 || RoratepointListview.SelectedItems == null)
                return;
            if (MessageBox.Show("确认修改？", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                int index = RoratepointListview.SelectedIndices[0];
                RoratepointListview.Items[index].SubItems[1].Text = txbRotataPixelX.Text.Trim();
                RoratepointListview.Items[index].SubItems[2].Text = txbRotataPixelY.Text.Trim();
            }
        }

        private void btnDeleteRotataPixel_Click(object sender, EventArgs e)
        {
            if (RoratepointListview.Items.Count <= 0 || RoratepointListview.SelectedItems.Count == 0)
                return;
            if (MessageBox.Show("确认删除？", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                int index = RoratepointListview.SelectedIndices[0];
                RoratepointListview.Items.RemoveAt(index);

            }
        }

       

        //多点计算旋转中心
        void CaculateMultorRorateCenter()
        {
            this.Invoke(new Action(() =>
            {
                if (RoratepointListview.Items.Count < 5)
                {
                    MessageBox.Show("点位坐标数据不足5条，请确认!");
                    return;
                }
              
                List<CVPoint> pointlist = new List<CVPoint>();
                currvisiontool.clearAll();
                currvisiontool.dispImage(GrabImg);
                Mat dst = new Mat();
                Cv2.CvtColor(GrabImg, dst, ColorConversionCodes.GRAY2BGR);
               
               
                foreach (ListViewItem s in RoratepointListview.Items)
                {
                    pixelList.Add(new Point2d(
                                double.Parse(s.SubItems[1].Text),
                              double.Parse(s.SubItems[2].Text)));
                 dst.drawCross(new CVPoint(double.Parse(s.SubItems[1].Text), 
                                    double.Parse(s.SubItems[2].Text)),Scalar.Green,20,2);
                   
                }
                Point2d centreP=new Point2d(0,0); double radius=0;
                AxisCoorditionRotation.FitCircle(pointlist,ref centreP,ref radius);

                dst.Circle((int)centreP.X,(int)centreP.Y,(int)radius,Scalar.Green,2);

                Point2d robotP= CalibrationTool.AffineTransPoint2d(Hom_mat2d,new Point2d(centreP.X, centreP.Y));
                
                setCalCentreHandle?.Invoke(new string[] { robotP.X.ToString("f3"),
                  robotP.Y.ToString("f3")}, null);

                txbCurrRorateCenterX.Text = robotP.X.ToString("f3");
                txbCurrRorateCenterY.Text = robotP.Y.ToString("f3");

                currvisiontool.clearAll();
                currvisiontool.dispImage(dst);
              
            }));

        }

        void setData(ref RotatePointDataClass RotateP)
        {
            RotateP.ListPoint.Clear();
            foreach (ListViewItem s in RoratepointListview.Items)
                RotateP.ListPoint.Add(new PointF(float.Parse(s.SubItems[1].Text),
                     float.Parse(s.SubItems[2].Text)));
        }

        void showData(RotatePointDataClass RotateP)
        {
            k = 0;
            RoratepointListview.Items.Clear();
            if (RotateP != null)
                foreach (var s in RotateP.ListPoint)
                {
                    k++;
                    ListViewItem tem = new ListViewItem(new string[3] { k.ToString(), s.X.ToString(), s.Y.ToString() });
                    RoratepointListview.Items.Add(tem);
                }
        }

        void LoadConfigOfRorateParma(string dirFileName)
        {
            if (!Directory.Exists(dirFileName))
                Directory.CreateDirectory(dirFileName);
            d_RotatePointDataClass = GeneralUse.ReadSerializationFile<RotatePointDataClass>(dirFileName + "\\Calib\\RotatePointData");
            if (d_RotatePointDataClass == null)
                d_RotatePointDataClass = new RotatePointDataClass();

            d_RotateCentrePointDataClass = GeneralUse.ReadSerializationFile<RotateCentrePointDataClass>(dirFileName + "\\Calib\\RotateCentrePointData");
            if (d_RotateCentrePointDataClass == null)
                d_RotateCentrePointDataClass = new RotateCentrePointDataClass();

            txbCurrRorateCenterX.Text = d_RotateCentrePointDataClass.Rx.ToString("f3");
            //RotatoX = double.Parse(txbCurrRorateCenterX.Text);
            txbCurrRorateCenterY.Text = d_RotateCentrePointDataClass.Ry.ToString("f3");
            //RotatoY = double.Parse(txbCurrRorateCenterY.Text);

            showData(d_RotatePointDataClass);

        }
        //旋转中心计算有关参数保存
        private void btnRatitoCaliDataSave_Click(object sender, EventArgs e)
        {
            try
            {
                setData(ref d_RotatePointDataClass);

                GeneralUse.WriteSerializationFile<RotatePointDataClass>("配方\\" + CurrRecipeName + "\\Calib\\RotatePointData", d_RotatePointDataClass);
                double  RotatoX = double.Parse(txbCurrRorateCenterX.Text);
                double RotatoY = double.Parse(txbCurrRorateCenterY.Text);
                d_RotateCentrePointDataClass.Rx = RotatoX;
                d_RotateCentrePointDataClass.Ry = RotatoY;
                GeneralUse.WriteSerializationFile<RotateCentrePointDataClass>("配方\\" + CurrRecipeName + "\\Calib\\RotateCentrePointData", d_RotateCentrePointDataClass);

                setCalCentreHandle?.Invoke(new string[] { RotatoX.ToString("f3"),
                  RotatoY.ToString("f3")}, null);
                AutoUpdateCalibFile();
                // MessageBox.Show("参数保存成功！");
            }
            catch (Exception er)
            {
                MessageBox.Show("参数保存失败！" + er.Message);
            }

        }

        private void 清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoratepointListview.Items.Clear();
            k = 0;
        }
        #endregion     
    }
    /// <summary>
    /// 角度输出方式
    /// </summary>
    public enum EumOutAngleMode
    {
        [Description("绝对的")]
        Absolute,
        [Description("相对的")]
        Relative
    }

    /// <summary>
    /// 员工操作权限
    /// </summary>
    public enum EumOperationAuthority
    {
        [Description("无")]
        None =0,
        [Description("操作员")]
        Operator=1,
        [Description("程序员")]
        Programmer,
        [Description("管理员")]
        Administrators
    }

    /// <summary>
    /// 当前相机工作方式
    /// </summary>
    enum EunmcurrCamWorkStatus
    {
        /// <summary>
        /// 自由模式
        /// </summary>
        freestyle,
        /// <summary>
        /// 9点标定
        /// </summary>
        NinePointcLocation,
        /// <summary>
        /// 旋转标定
        /// </summary>
        RotatoLocation,
        /// <summary>
        /// 产品点位1测试
        /// </summary>
        NormalTest_T1,
        /// <summary>
        /// 产品点位2测试
        /// </summary>
        NormalTest_T2,
        /// <summary>
        /// 胶水测试
        /// </summary>
        NormalTest_G,    
        /// <summary>
        /// 无
        /// </summary>
        None
    }

    public enum EumModelType
    {

        None = -1,

        ProductModel_1,  //当前为产品1模板 ,default

        ProductModel_2,  //当前为产品1模板 ,default

        CalibModel, //当前为标定板模板

        GluetapModel   //点胶阀
    }

    /// <summary>
    /// 九点标定像素坐标数据集合
    /// </summary>
    [Serializable]
    public class pixelPointDataClass
    {
        public pixelPointDataClass()
        {
            ListPoint = new List<PointF>(capacity);
        }
        ~pixelPointDataClass()
        {
            ListPoint.Clear();
        }
        const int capacity = 9;
        public List<PointF> ListPoint { get; set; }

    }
    /// <summary>
    /// 九点标定机械坐标数据集合
    /// </summary>
    [Serializable]
    public class robotPointDataClass
    {
        public robotPointDataClass()
        {
            ListPoint = new List<PointF>(capacity);
        }
        ~robotPointDataClass()
        {
            ListPoint.Clear();
        }
        const int capacity = 9;
        public List<PointF> ListPoint { get; set; }
    }
    /// <summary>
    /// 旋转中心计算数据集合
    /// </summary>
    [Serializable]
    public class RotatePointDataClass
    {
        public RotatePointDataClass()
        {
            ListPoint = new List<PointF>(capacity);
        }
        ~RotatePointDataClass()
        {
            ListPoint.Clear();
        }
        const int capacity = 6;
        public List<PointF> ListPoint { get; set; }

    }
    /// <summary>
    /// 旋转中心
    /// </summary>
    [Serializable]
    public class RotateCentrePointDataClass
    {
        public double Rx { get; set; } = 0;
        public double Ry { get; set; } = 0;
    }
    /// <summary>
    /// 坐标系转换数据
    /// </summary>
    [Serializable]
    public class converCoorditionDataClass
    {
        public converCoorditionDataClass()
        {
          
        }
        //X缩放
        public double Sx { get; set; }
        //Y缩放
        public double Sy { get; set; }
        //旋转角(弧度)
        public double Phi { get; set; }
        //倾斜角(弧度)
        public double Theta { get; set; }
        //X偏移量
        public double Tx { get; set; }
        //Y偏移量
        public double Ty { get; set; }

        //X偏差
        public double XRms { get; set; }
        //Y偏差
        public double YRms { get; set; }

    }

    [Serializable]
    public class MatchBaseInfo
    {
        /// <summary>
        /// 基准点X
        /// </summary>
        public double BaseX { get; set; } = 0;
        /// <summary>
        /// 基准点Y
        /// </summary>
        public double BaseY{ get; set; } = 0;
        /// <summary>
        /// 基准角度
        /// </summary>
        public double BaseAngle { get; set; } = 0;
        /// <summary>
        /// 基准轮廓长度
        /// </summary>
        public double ContourLength { get; set; } = 0;
        /// <summary>
        /// 基准轮廓面积
        /// </summary>
        public double ContourArea { get; set; } = 0;

    }


}