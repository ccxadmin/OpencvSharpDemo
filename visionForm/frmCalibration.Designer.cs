namespace visionForm
{
    partial class frmCalibration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "BaseX",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "BaseY",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "BaseAngle",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "ContourLength",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "ContourArea",
            "0"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalibration));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.richTxb = new UIDesign.UIRichTextBox();
            this.btnCloseCam = new UIDesign.UIButton();
            this.cobxCamIndex = new UIDesign.UIComboBox();
            this.btnOpenCam = new UIDesign.UIButton();
            this.cobxCamType = new UIDesign.UIComboBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.btnStopGrab = new UIDesign.UIButton();
            this.btnSaveCamParm = new UIDesign.UIButton();
            this.btnOneShot = new UIDesign.UIButton();
            this.btnContinueGrab = new UIDesign.UIButton();
            this.CamGainBar = new UIDesign.UITrackBar();
            this.CamExposureBar = new UIDesign.UITrackBar();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.LocationDectionSetBox = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CircleMatchPanel = new UIDesign.UIPanel();
            this.NumParam1 = new UCLib.NumericUpDownEx();
            this.label54 = new System.Windows.Forms.Label();
            this.numberMinRadius = new UCLib.NumericUpDownEx();
            this.numberMaxRadius = new UCLib.NumericUpDownEx();
            this.btnTestAutoCircleMatch = new UIDesign.UIButton();
            this.NumParam2 = new UCLib.NumericUpDownEx();
            this.NumMinDist = new UCLib.NumericUpDownEx();
            this.label29 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.chxbAutoCircleMatch = new UIDesign.UICheckBox();
            this.chxbModelMatch = new UIDesign.UICheckBox();
            this.BlobCentrePanel = new UIDesign.UIPanel();
            this.cobxPolarity = new UCLib.ComboBoxEx();
            this.NumareaHigh = new UCLib.NumericUpDownEx();
            this.label16 = new System.Windows.Forms.Label();
            this.NumareaLow = new UCLib.NumericUpDownEx();
            this.label36 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnGetBlobArea = new UIDesign.UIButton();
            this.Numminthd = new UCLib.NumericUpDownEx();
            this.label17 = new System.Windows.Forms.Label();
            this.FindCirclePanel = new UIDesign.UIPanel();
            this.NummaxRadius = new UCLib.NumericUpDownEx();
            this.NumEdgeThreshold = new UCLib.NumericUpDownEx();
            this.NumminRadius = new UCLib.NumericUpDownEx();
            this.label44 = new System.Windows.Forms.Label();
            this.btnGetCircle = new UIDesign.UIButton();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.LinesIntersectPanel = new UIDesign.UIPanel();
            this.NumcanThdup2 = new UCLib.NumericUpDownEx();
            this.NumcanThdup = new UCLib.NumericUpDownEx();
            this.label27 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.NumMaxLineGap2 = new UCLib.NumericUpDownEx();
            this.NumMinLineLenght2 = new UCLib.NumericUpDownEx();
            this.NumThresholdP2 = new UCLib.NumericUpDownEx();
            this.label19 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.NumMaxLineGap = new UCLib.NumericUpDownEx();
            this.NumcanThddown2 = new UCLib.NumericUpDownEx();
            this.NumcanThddown = new UCLib.NumericUpDownEx();
            this.NumMinLineLenght = new UCLib.NumericUpDownEx();
            this.NumThresholdP = new UCLib.NumericUpDownEx();
            this.label12 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.btnLntersectLine = new UIDesign.UIButton();
            this.btnSendDataToControl = new UIDesign.UIButton();
            this.btnGetLine2 = new UIDesign.UIButton();
            this.btnGetLine1 = new UIDesign.UIButton();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.ModelMactPanel = new UIDesign.UIPanel();
            this.lIstModelInfo = new UCLib.ListViewEx();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumMinContourArea = new UCLib.NumericUpDownEx();
            this.NumMaxContourArea = new UCLib.NumericUpDownEx();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.NumMincoutourLen = new UCLib.NumericUpDownEx();
            this.NumMaxcoutourLen = new UCLib.NumericUpDownEx();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnTest_modelMatch = new UIDesign.UIButton();
            this.picTemplate = new UCLib.PictureBoxEx();
            this.NumSegthreshold = new UCLib.NumericUpDownEx();
            this.NumMatchValue = new UCLib.NumericUpDownEx();
            this.label25 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.btnSaveModel = new UIDesign.UIButton();
            this.btncreateModel = new UIDesign.UIButton();
            this.panel16 = new UIDesign.UIPanel();
            this.listViewFlow = new UCLib.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRunTool = new UIDesign.UIButton();
            this.btnRunFlow = new UIDesign.UIButton();
            this.chxbLinesIntersect = new UIDesign.UICheckBox();
            this.chxbFindCircle = new UIDesign.UICheckBox();
            this.chxbBlobCentre = new UIDesign.UICheckBox();
            this.cobxModelType = new UIDesign.UIComboBox();
            this.btnSaveModelParmas = new UIDesign.UIButton();
            this.btnCoordiRecipe = new UIDesign.UIButton();
            this.uiLine2 = new UIDesign.UILine();
            this.uiLine3 = new UIDesign.UILine();
            this.label66 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.NinePointsOfPixelDatBox = new UIDesign.UITitlePanel();
            this.listViewPixel = new UCLib.ListViewEx();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NinePointsOfPixelGetBox = new UIDesign.UIPanel();
            this.btnModifyPixelPoint = new UIDesign.UIButton();
            this.groupBox8 = new UIDesign.UITitlePanel();
            this.txbpixelY = new UIDesign.UITextBox();
            this.txbpixelX = new UIDesign.UITextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeletePixelPoint = new UIDesign.UIButton();
            this.btnGetPixelPoint = new UIDesign.UIButton();
            this.btnNewPixelPoint = new UIDesign.UIButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.NinePointsOfRobotGetBox = new UIDesign.UIPanel();
            this.btnModifyRobotPoint = new UIDesign.UIButton();
            this.btnDeleteRobotPoint = new UIDesign.UIButton();
            this.uiTitlePanel1 = new UIDesign.UITitlePanel();
            this.label6 = new System.Windows.Forms.Label();
            this.txbrobotX = new UIDesign.UITextBox();
            this.txbrobotR = new UIDesign.UITextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbrobotY = new UIDesign.UITextBox();
            this.BtnNewRobotPoint = new UIDesign.UIButton();
            this.btnGetRobotPoint = new UIDesign.UIButton();
            this.NinePointsOfRobotDatBox = new UIDesign.UITitlePanel();
            this.listViewRobot = new UCLib.ListViewEx();
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chxbAutoCoorSys = new UIDesign.UICheckBox();
            this.btnSaveParma = new UIDesign.UIButton();
            this.btnConvert = new UIDesign.UIButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txbXRms = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.txbYRms = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbSx = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbTy = new System.Windows.Forms.TextBox();
            this.txbSy = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbPhi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txbTheta = new System.Windows.Forms.TextBox();
            this.txbTx = new System.Windows.Forms.TextBox();
            this.uiPanel4 = new UIDesign.UIPanel();
            this.txbMarkRobotY = new UIDesign.UITextBox();
            this.txbMarkRobotX = new UIDesign.UITextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.uiPanel3 = new UIDesign.UIPanel();
            this.txbMarkPixelY = new UIDesign.UITextBox();
            this.txbMarkPixelX = new UIDesign.UITextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RotateCalBox = new UIDesign.UIPanel();
            this.btnRatitoCaliDataSave = new UIDesign.UIButton();
            this.txbCurrRorateCenterY = new UIDesign.UITextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.btnCaculateRorateCenter = new UIDesign.UIButton();
            this.label34 = new System.Windows.Forms.Label();
            this.txbCurrRorateCenterX = new UIDesign.UITextBox();
            this.RotateOfPixelDatBox = new UIDesign.UITitlePanel();
            this.RoratepointListview = new UCLib.ListViewEx();
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RotatePixelGetBox = new UIDesign.UIPanel();
            this.btnModifyRotataPixel = new UIDesign.UIButton();
            this.uiTitlePanel3 = new UIDesign.UITitlePanel();
            this.txbRotataPixelY = new UIDesign.UITextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txbRotataPixelX = new UIDesign.UITextBox();
            this.btnGetRotataPixel = new UIDesign.UIButton();
            this.btnDeleteRotataPixel = new UIDesign.UIButton();
            this.btnSaveRotataPixel = new UIDesign.UIButton();
            this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清除ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picConvertRobotToPixel = new System.Windows.Forms.PictureBox();
            this.picConvertPixelToRobot = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uiPanel1 = new UIDesign.UIPanel();
            this.uiTabControl1 = new UIDesign.UITabControl();
            this.相机设置 = new System.Windows.Forms.TabPage();
            this.LogShowBox = new UIDesign.UITitlePanel();
            this.uiPanel6 = new UIDesign.UIPanel();
            this.ImageGrabToolBox = new UIDesign.UITitlePanel();
            this.CamParmasSetBox = new UIDesign.UITitlePanel();
            this.numCamGain = new UCLib.NumericUpDownEx();
            this.numCamExposure = new UCLib.NumericUpDownEx();
            this.CamTypeSetBox = new UIDesign.UITitlePanel();
            this.定位检测 = new System.Windows.Forms.TabPage();
            this.像素坐标 = new System.Windows.Forms.TabPage();
            this.物理坐标 = new System.Windows.Forms.TabPage();
            this.坐标变换 = new System.Windows.Forms.TabPage();
            this.CoordinateTransBox = new UIDesign.UITitlePanel();
            this.groupBox6 = new UIDesign.UIPanel();
            this.groupBox17 = new UIDesign.UIPanel();
            this.旋转中心 = new System.Windows.Forms.TabPage();
            this.uiPanel2 = new UIDesign.UIPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip4.SuspendLayout();
            this.LocationDectionSetBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.CircleMatchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumParam1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberMinRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberMaxRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumParam2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinDist)).BeginInit();
            this.BlobCentrePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumareaHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumareaLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Numminthd)).BeginInit();
            this.FindCirclePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NummaxRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumEdgeThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumminRadius)).BeginInit();
            this.LinesIntersectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumcanThdup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumcanThdup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxLineGap2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinLineLenght2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumThresholdP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxLineGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumcanThddown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumcanThddown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinLineLenght)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumThresholdP)).BeginInit();
            this.ModelMactPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinContourArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxContourArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMincoutourLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxcoutourLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSegthreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMatchValue)).BeginInit();
            this.panel16.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.NinePointsOfPixelDatBox.SuspendLayout();
            this.NinePointsOfPixelGetBox.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.NinePointsOfRobotGetBox.SuspendLayout();
            this.uiTitlePanel1.SuspendLayout();
            this.NinePointsOfRobotDatBox.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.uiPanel4.SuspendLayout();
            this.uiPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.RotateCalBox.SuspendLayout();
            this.RotateOfPixelDatBox.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.RotatePixelGetBox.SuspendLayout();
            this.uiTitlePanel3.SuspendLayout();
            this.contextMenuStrip5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConvertRobotToPixel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConvertPixelToRobot)).BeginInit();
            this.uiPanel1.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.相机设置.SuspendLayout();
            this.LogShowBox.SuspendLayout();
            this.uiPanel6.SuspendLayout();
            this.ImageGrabToolBox.SuspendLayout();
            this.CamParmasSetBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCamGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCamExposure)).BeginInit();
            this.CamTypeSetBox.SuspendLayout();
            this.定位检测.SuspendLayout();
            this.像素坐标.SuspendLayout();
            this.物理坐标.SuspendLayout();
            this.坐标变换.SuspendLayout();
            this.CoordinateTransBox.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.旋转中心.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 28);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空ToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(109, 28);
            // 
            // 清空ToolStripMenuItem1
            // 
            this.清空ToolStripMenuItem1.Name = "清空ToolStripMenuItem1";
            this.清空ToolStripMenuItem1.Size = new System.Drawing.Size(108, 24);
            this.清空ToolStripMenuItem1.Text = "清空";
            this.清空ToolStripMenuItem1.Click += new System.EventHandler(this.清空ToolStripMenuItem1_Click);
            // 
            // richTxb
            // 
            this.richTxb.AutoWordSelection = true;
            this.richTxb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTxb.FillColor = System.Drawing.Color.White;
            this.richTxb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTxb.Location = new System.Drawing.Point(0, 20);
            this.richTxb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTxb.Name = "richTxb";
            this.richTxb.Padding = new System.Windows.Forms.Padding(2);
            this.richTxb.ReadOnly = true;
            this.richTxb.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.richTxb.Size = new System.Drawing.Size(394, 257);
            this.richTxb.Style = UIDesign.UIStyle.LightOrange;
            this.richTxb.TabIndex = 0;
            // 
            // btnCloseCam
            // 
            this.btnCloseCam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseCam.FillColor = System.Drawing.Color.White;
            this.btnCloseCam.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCloseCam.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCloseCam.Font = new System.Drawing.Font("宋体", 9F);
            this.btnCloseCam.ForeColor = System.Drawing.Color.Black;
            this.btnCloseCam.Location = new System.Drawing.Point(272, 73);
            this.btnCloseCam.Name = "btnCloseCam";
            this.btnCloseCam.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnCloseCam.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCloseCam.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCloseCam.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCloseCam.Size = new System.Drawing.Size(100, 30);
            this.btnCloseCam.Style = UIDesign.UIStyle.LightOrange;
            this.btnCloseCam.TabIndex = 1;
            this.btnCloseCam.Text = "关闭相机";
            this.btnCloseCam.Click += new System.EventHandler(this.btnCloseCam_Click);
            // 
            // cobxCamIndex
            // 
            this.cobxCamIndex.FillColor = System.Drawing.Color.White;
            this.cobxCamIndex.Font = new System.Drawing.Font("宋体", 9F);
            this.cobxCamIndex.Location = new System.Drawing.Point(98, 76);
            this.cobxCamIndex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cobxCamIndex.MinimumSize = new System.Drawing.Size(63, 0);
            this.cobxCamIndex.Name = "cobxCamIndex";
            this.cobxCamIndex.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cobxCamIndex.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.cobxCamIndex.Size = new System.Drawing.Size(160, 25);
            this.cobxCamIndex.Style = UIDesign.UIStyle.LightOrange;
            this.cobxCamIndex.TabIndex = 0;
            this.cobxCamIndex.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cobxCamIndex.SelectedIndexChanged += new System.EventHandler(this.cobxCamIndex_SelectedIndexChanged);
            // 
            // btnOpenCam
            // 
            this.btnOpenCam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenCam.FillColor = System.Drawing.Color.White;
            this.btnOpenCam.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnOpenCam.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnOpenCam.Font = new System.Drawing.Font("宋体", 9F);
            this.btnOpenCam.ForeColor = System.Drawing.Color.Black;
            this.btnOpenCam.Location = new System.Drawing.Point(272, 30);
            this.btnOpenCam.Name = "btnOpenCam";
            this.btnOpenCam.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnOpenCam.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnOpenCam.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnOpenCam.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnOpenCam.Size = new System.Drawing.Size(100, 30);
            this.btnOpenCam.Style = UIDesign.UIStyle.LightOrange;
            this.btnOpenCam.TabIndex = 0;
            this.btnOpenCam.Text = "打开相机";
            this.btnOpenCam.Click += new System.EventHandler(this.btnOpenCam_Click);
            // 
            // cobxCamType
            // 
            this.cobxCamType.FillColor = System.Drawing.Color.White;
            this.cobxCamType.Font = new System.Drawing.Font("宋体", 9F);
            this.cobxCamType.Items.AddRange(new object[] {
            "海康",
            "大华",
            "巴斯勒"});
            this.cobxCamType.Location = new System.Drawing.Point(98, 33);
            this.cobxCamType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cobxCamType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cobxCamType.Name = "cobxCamType";
            this.cobxCamType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cobxCamType.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.cobxCamType.Size = new System.Drawing.Size(160, 25);
            this.cobxCamType.Style = UIDesign.UIStyle.LightOrange;
            this.cobxCamType.TabIndex = 0;
            this.cobxCamType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cobxCamType.SelectedIndexChanged += new System.EventHandler(this.cobxCamType_SelectedIndexChanged);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.BackColor = System.Drawing.Color.White;
            this.label65.Location = new System.Drawing.Point(12, 82);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(82, 15);
            this.label65.TabIndex = 2;
            this.label65.Text = "相机索引：";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.BackColor = System.Drawing.Color.White;
            this.label62.Location = new System.Drawing.Point(12, 39);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(82, 15);
            this.label62.TabIndex = 0;
            this.label62.Text = "相机型号：";
            // 
            // btnStopGrab
            // 
            this.btnStopGrab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopGrab.FillColor = System.Drawing.Color.White;
            this.btnStopGrab.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnStopGrab.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnStopGrab.Font = new System.Drawing.Font("宋体", 9F);
            this.btnStopGrab.ForeColor = System.Drawing.Color.Black;
            this.btnStopGrab.Location = new System.Drawing.Point(268, 80);
            this.btnStopGrab.Name = "btnStopGrab";
            this.btnStopGrab.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnStopGrab.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnStopGrab.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnStopGrab.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnStopGrab.Size = new System.Drawing.Size(100, 30);
            this.btnStopGrab.Style = UIDesign.UIStyle.LightOrange;
            this.btnStopGrab.TabIndex = 4;
            this.btnStopGrab.Text = "停止采集";
            this.btnStopGrab.Click += new System.EventHandler(this.btnStopGrab_Click);
            // 
            // btnSaveCamParm
            // 
            this.btnSaveCamParm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveCamParm.FillColor = System.Drawing.Color.White;
            this.btnSaveCamParm.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveCamParm.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveCamParm.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSaveCamParm.ForeColor = System.Drawing.Color.Black;
            this.btnSaveCamParm.Location = new System.Drawing.Point(14, 80);
            this.btnSaveCamParm.Name = "btnSaveCamParm";
            this.btnSaveCamParm.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnSaveCamParm.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveCamParm.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveCamParm.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveCamParm.Size = new System.Drawing.Size(100, 30);
            this.btnSaveCamParm.Style = UIDesign.UIStyle.LightOrange;
            this.btnSaveCamParm.TabIndex = 3;
            this.btnSaveCamParm.Text = "参数保存";
            this.btnSaveCamParm.Click += new System.EventHandler(this.btnSaveCamParma_Click);
            // 
            // btnOneShot
            // 
            this.btnOneShot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOneShot.FillColor = System.Drawing.Color.White;
            this.btnOneShot.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnOneShot.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnOneShot.Font = new System.Drawing.Font("宋体", 9F);
            this.btnOneShot.ForeColor = System.Drawing.Color.Black;
            this.btnOneShot.Location = new System.Drawing.Point(14, 37);
            this.btnOneShot.Name = "btnOneShot";
            this.btnOneShot.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnOneShot.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnOneShot.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnOneShot.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnOneShot.Size = new System.Drawing.Size(100, 30);
            this.btnOneShot.Style = UIDesign.UIStyle.LightOrange;
            this.btnOneShot.TabIndex = 1;
            this.btnOneShot.Text = "单帧采集";
            this.btnOneShot.Click += new System.EventHandler(this.btnOneShot_Click);
            // 
            // btnContinueGrab
            // 
            this.btnContinueGrab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinueGrab.FillColor = System.Drawing.Color.White;
            this.btnContinueGrab.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnContinueGrab.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnContinueGrab.Font = new System.Drawing.Font("宋体", 9F);
            this.btnContinueGrab.ForeColor = System.Drawing.Color.Black;
            this.btnContinueGrab.Location = new System.Drawing.Point(268, 37);
            this.btnContinueGrab.Name = "btnContinueGrab";
            this.btnContinueGrab.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnContinueGrab.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnContinueGrab.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnContinueGrab.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnContinueGrab.Size = new System.Drawing.Size(100, 30);
            this.btnContinueGrab.Style = UIDesign.UIStyle.LightOrange;
            this.btnContinueGrab.TabIndex = 2;
            this.btnContinueGrab.Text = "连续采集";
            this.btnContinueGrab.Click += new System.EventHandler(this.btnContinueGrab_Click);
            // 
            // CamGainBar
            // 
            this.CamGainBar.DisableColor = System.Drawing.Color.Silver;
            this.CamGainBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CamGainBar.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CamGainBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.CamGainBar.Location = new System.Drawing.Point(95, 75);
            this.CamGainBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CamGainBar.Maximum = 10;
            this.CamGainBar.Name = "CamGainBar";
            this.CamGainBar.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.CamGainBar.Size = new System.Drawing.Size(160, 29);
            this.CamGainBar.Style = UIDesign.UIStyle.LightOrange;
            this.CamGainBar.TabIndex = 12;
            this.CamGainBar.Text = "uiTrackBar2";
            this.CamGainBar.ValueChanged += new System.EventHandler(this.CamGainBar_ValueChanged);
            // 
            // CamExposureBar
            // 
            this.CamExposureBar.DisableColor = System.Drawing.Color.Silver;
            this.CamExposureBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CamExposureBar.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CamExposureBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.CamExposureBar.Location = new System.Drawing.Point(95, 32);
            this.CamExposureBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CamExposureBar.Maximum = 200000;
            this.CamExposureBar.Minimum = 1000;
            this.CamExposureBar.Name = "CamExposureBar";
            this.CamExposureBar.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.CamExposureBar.Size = new System.Drawing.Size(160, 29);
            this.CamExposureBar.Style = UIDesign.UIStyle.LightOrange;
            this.CamExposureBar.TabIndex = 11;
            this.CamExposureBar.Text = "uiTrackBar1";
            this.CamExposureBar.Value = 10000;
            this.CamExposureBar.ValueChanged += new System.EventHandler(this.CamExposureBar_ValueChanged);
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.BackColor = System.Drawing.Color.White;
            this.label64.Location = new System.Drawing.Point(12, 82);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(77, 15);
            this.label64.TabIndex = 1;
            this.label64.Text = "增益(db):";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.BackColor = System.Drawing.Color.White;
            this.label63.Location = new System.Drawing.Point(12, 39);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(77, 15);
            this.label63.TabIndex = 0;
            this.label63.Text = "曝光(us):";
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除ToolStripMenuItem1});
            this.contextMenuStrip4.Name = "contextMenuStrip4";
            this.contextMenuStrip4.Size = new System.Drawing.Size(109, 28);
            // 
            // 清除ToolStripMenuItem1
            // 
            this.清除ToolStripMenuItem1.Name = "清除ToolStripMenuItem1";
            this.清除ToolStripMenuItem1.Size = new System.Drawing.Size(108, 24);
            this.清除ToolStripMenuItem1.Text = "清除";
            // 
            // LocationDectionSetBox
            // 
            this.LocationDectionSetBox.AutoScroll = true;
            this.LocationDectionSetBox.Controls.Add(this.groupBox4);
            this.LocationDectionSetBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocationDectionSetBox.Location = new System.Drawing.Point(0, 0);
            this.LocationDectionSetBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LocationDectionSetBox.Name = "LocationDectionSetBox";
            this.LocationDectionSetBox.Size = new System.Drawing.Size(394, 642);
            this.LocationDectionSetBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.CircleMatchPanel);
            this.groupBox4.Controls.Add(this.chxbAutoCircleMatch);
            this.groupBox4.Controls.Add(this.chxbModelMatch);
            this.groupBox4.Controls.Add(this.BlobCentrePanel);
            this.groupBox4.Controls.Add(this.FindCirclePanel);
            this.groupBox4.Controls.Add(this.LinesIntersectPanel);
            this.groupBox4.Controls.Add(this.ModelMactPanel);
            this.groupBox4.Controls.Add(this.panel16);
            this.groupBox4.Controls.Add(this.chxbLinesIntersect);
            this.groupBox4.Controls.Add(this.chxbFindCircle);
            this.groupBox4.Controls.Add(this.chxbBlobCentre);
            this.groupBox4.Controls.Add(this.cobxModelType);
            this.groupBox4.Controls.Add(this.btnSaveModelParmas);
            this.groupBox4.Controls.Add(this.btnCoordiRecipe);
            this.groupBox4.Controls.Add(this.uiLine2);
            this.groupBox4.Controls.Add(this.uiLine3);
            this.groupBox4.Controls.Add(this.label66);
            this.groupBox4.Controls.Add(this.linkLabel3);
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(373, 1586);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // CircleMatchPanel
            // 
            this.CircleMatchPanel.Controls.Add(this.NumParam1);
            this.CircleMatchPanel.Controls.Add(this.label54);
            this.CircleMatchPanel.Controls.Add(this.numberMinRadius);
            this.CircleMatchPanel.Controls.Add(this.numberMaxRadius);
            this.CircleMatchPanel.Controls.Add(this.btnTestAutoCircleMatch);
            this.CircleMatchPanel.Controls.Add(this.NumParam2);
            this.CircleMatchPanel.Controls.Add(this.NumMinDist);
            this.CircleMatchPanel.Controls.Add(this.label29);
            this.CircleMatchPanel.Controls.Add(this.label14);
            this.CircleMatchPanel.Controls.Add(this.label31);
            this.CircleMatchPanel.Controls.Add(this.label45);
            this.CircleMatchPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CircleMatchPanel.Font = new System.Drawing.Font("宋体", 9F);
            this.CircleMatchPanel.Location = new System.Drawing.Point(6, 723);
            this.CircleMatchPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CircleMatchPanel.Name = "CircleMatchPanel";
            this.CircleMatchPanel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.CircleMatchPanel.Size = new System.Drawing.Size(342, 128);
            this.CircleMatchPanel.Style = UIDesign.UIStyle.LightOrange;
            this.CircleMatchPanel.TabIndex = 0;
            this.CircleMatchPanel.Text = null;
            // 
            // NumParam1
            // 
            this.NumParam1.DecimalPlaces = 1;
            this.NumParam1.Font = new System.Drawing.Font("宋体", 9F);
            this.NumParam1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumParam1.Location = new System.Drawing.Point(260, 10);
            this.NumParam1.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NumParam1.Name = "NumParam1";
            this.NumParam1.Size = new System.Drawing.Size(73, 25);
            this.NumParam1.TabIndex = 104;
            this.NumParam1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(180, 15);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(70, 15);
            this.label54.TabIndex = 105;
            this.label54.Text = "Param1：";
            // 
            // numberMinRadius
            // 
            this.numberMinRadius.Font = new System.Drawing.Font("宋体", 9F);
            this.numberMinRadius.Location = new System.Drawing.Point(260, 49);
            this.numberMinRadius.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numberMinRadius.Name = "numberMinRadius";
            this.numberMinRadius.Size = new System.Drawing.Size(73, 25);
            this.numberMinRadius.TabIndex = 10;
            this.numberMinRadius.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // numberMaxRadius
            // 
            this.numberMaxRadius.DecimalPlaces = 1;
            this.numberMaxRadius.Font = new System.Drawing.Font("宋体", 9F);
            this.numberMaxRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numberMaxRadius.Location = new System.Drawing.Point(88, 89);
            this.numberMaxRadius.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numberMaxRadius.Name = "numberMaxRadius";
            this.numberMaxRadius.Size = new System.Drawing.Size(74, 25);
            this.numberMaxRadius.TabIndex = 10;
            this.numberMaxRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnTestAutoCircleMatch
            // 
            this.btnTestAutoCircleMatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestAutoCircleMatch.FillColor = System.Drawing.Color.White;
            this.btnTestAutoCircleMatch.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnTestAutoCircleMatch.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnTestAutoCircleMatch.Font = new System.Drawing.Font("宋体", 9F);
            this.btnTestAutoCircleMatch.ForeColor = System.Drawing.Color.Black;
            this.btnTestAutoCircleMatch.Location = new System.Drawing.Point(185, 85);
            this.btnTestAutoCircleMatch.Name = "btnTestAutoCircleMatch";
            this.btnTestAutoCircleMatch.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnTestAutoCircleMatch.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnTestAutoCircleMatch.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnTestAutoCircleMatch.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnTestAutoCircleMatch.Size = new System.Drawing.Size(148, 31);
            this.btnTestAutoCircleMatch.Style = UIDesign.UIStyle.LightOrange;
            this.btnTestAutoCircleMatch.TabIndex = 103;
            this.btnTestAutoCircleMatch.Text = "测试";
            this.btnTestAutoCircleMatch.TipsText = "计算后的坐标为像素坐标";
            this.btnTestAutoCircleMatch.Click += new System.EventHandler(this.btnTestAutoCircleMatch_Click);
            // 
            // NumParam2
            // 
            this.NumParam2.Font = new System.Drawing.Font("宋体", 9F);
            this.NumParam2.Location = new System.Drawing.Point(88, 49);
            this.NumParam2.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NumParam2.Name = "NumParam2";
            this.NumParam2.Size = new System.Drawing.Size(73, 25);
            this.NumParam2.TabIndex = 9;
            this.NumParam2.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // NumMinDist
            // 
            this.NumMinDist.DecimalPlaces = 1;
            this.NumMinDist.Font = new System.Drawing.Font("宋体", 9F);
            this.NumMinDist.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumMinDist.Location = new System.Drawing.Point(88, 10);
            this.NumMinDist.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NumMinDist.Name = "NumMinDist";
            this.NumMinDist.Size = new System.Drawing.Size(73, 25);
            this.NumMinDist.TabIndex = 8;
            this.NumMinDist.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 93);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(75, 15);
            this.label29.TabIndex = 100;
            this.label29.Text = "最大半径:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 15);
            this.label14.TabIndex = 98;
            this.label14.Text = "最小圆距：";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(182, 54);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(75, 15);
            this.label31.TabIndex = 96;
            this.label31.Text = "最小半径:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(8, 54);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(70, 15);
            this.label45.TabIndex = 94;
            this.label45.Text = "Param2：";
            // 
            // chxbAutoCircleMatch
            // 
            this.chxbAutoCircleMatch.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.chxbAutoCircleMatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chxbAutoCircleMatch.Font = new System.Drawing.Font("宋体", 9F);
            this.chxbAutoCircleMatch.Location = new System.Drawing.Point(7, 696);
            this.chxbAutoCircleMatch.Name = "chxbAutoCircleMatch";
            this.chxbAutoCircleMatch.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chxbAutoCircleMatch.Size = new System.Drawing.Size(148, 20);
            this.chxbAutoCircleMatch.Style = UIDesign.UIStyle.LightOrange;
            this.chxbAutoCircleMatch.TabIndex = 98;
            this.chxbAutoCircleMatch.Text = "2.2 自动圆匹配：";
            this.chxbAutoCircleMatch.ValueChanged += new UIDesign.UICheckBox.OnValueChanged(this.chxbAutoCircleMatch_ValueChanged);
            // 
            // chxbModelMatch
            // 
            this.chxbModelMatch.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.chxbModelMatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chxbModelMatch.Font = new System.Drawing.Font("宋体", 9F);
            this.chxbModelMatch.Location = new System.Drawing.Point(7, 260);
            this.chxbModelMatch.Name = "chxbModelMatch";
            this.chxbModelMatch.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chxbModelMatch.Size = new System.Drawing.Size(135, 20);
            this.chxbModelMatch.Style = UIDesign.UIStyle.LightOrange;
            this.chxbModelMatch.TabIndex = 0;
            this.chxbModelMatch.Text = "1.1 模板匹配：";
            this.chxbModelMatch.ValueChanged += new UIDesign.UICheckBox.OnValueChanged(this.chxbModelMatch_ValueChanged);
            // 
            // BlobCentrePanel
            // 
            this.BlobCentrePanel.Controls.Add(this.cobxPolarity);
            this.BlobCentrePanel.Controls.Add(this.NumareaHigh);
            this.BlobCentrePanel.Controls.Add(this.label16);
            this.BlobCentrePanel.Controls.Add(this.NumareaLow);
            this.BlobCentrePanel.Controls.Add(this.label36);
            this.BlobCentrePanel.Controls.Add(this.label15);
            this.BlobCentrePanel.Controls.Add(this.btnGetBlobArea);
            this.BlobCentrePanel.Controls.Add(this.Numminthd);
            this.BlobCentrePanel.Controls.Add(this.label17);
            this.BlobCentrePanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BlobCentrePanel.Font = new System.Drawing.Font("宋体", 9F);
            this.BlobCentrePanel.Location = new System.Drawing.Point(5, 1331);
            this.BlobCentrePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BlobCentrePanel.Name = "BlobCentrePanel";
            this.BlobCentrePanel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.BlobCentrePanel.Size = new System.Drawing.Size(341, 129);
            this.BlobCentrePanel.Style = UIDesign.UIStyle.LightOrange;
            this.BlobCentrePanel.TabIndex = 3;
            this.BlobCentrePanel.Text = null;
            // 
            // cobxPolarity
            // 
            this.cobxPolarity.FormattingEnabled = true;
            this.cobxPolarity.Items.AddRange(new object[] {
            "White",
            "Black"});
            this.cobxPolarity.Location = new System.Drawing.Point(263, 14);
            this.cobxPolarity.Name = "cobxPolarity";
            this.cobxPolarity.Size = new System.Drawing.Size(68, 23);
            this.cobxPolarity.TabIndex = 118;
            this.cobxPolarity.Text = "White";
            // 
            // NumareaHigh
            // 
            this.NumareaHigh.Font = new System.Drawing.Font("宋体", 9F);
            this.NumareaHigh.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumareaHigh.Location = new System.Drawing.Point(263, 52);
            this.NumareaHigh.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NumareaHigh.Name = "NumareaHigh";
            this.NumareaHigh.Size = new System.Drawing.Size(68, 25);
            this.NumareaHigh.TabIndex = 108;
            this.NumareaHigh.Value = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(180, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 15);
            this.label16.TabIndex = 109;
            this.label16.Text = "面积上限:";
            // 
            // NumareaLow
            // 
            this.NumareaLow.Font = new System.Drawing.Font("宋体", 9F);
            this.NumareaLow.Location = new System.Drawing.Point(102, 52);
            this.NumareaLow.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NumareaLow.Name = "NumareaLow";
            this.NumareaLow.Size = new System.Drawing.Size(68, 25);
            this.NumareaLow.TabIndex = 106;
            this.NumareaLow.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(9, 57);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(75, 15);
            this.label36.TabIndex = 107;
            this.label36.Text = "面积下限:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(180, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 15);
            this.label15.TabIndex = 105;
            this.label15.Text = "粒子极性:";
            // 
            // btnGetBlobArea
            // 
            this.btnGetBlobArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetBlobArea.FillColor = System.Drawing.Color.White;
            this.btnGetBlobArea.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetBlobArea.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetBlobArea.Font = new System.Drawing.Font("宋体", 9F);
            this.btnGetBlobArea.ForeColor = System.Drawing.Color.Black;
            this.btnGetBlobArea.Location = new System.Drawing.Point(188, 89);
            this.btnGetBlobArea.Name = "btnGetBlobArea";
            this.btnGetBlobArea.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnGetBlobArea.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetBlobArea.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetBlobArea.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetBlobArea.Size = new System.Drawing.Size(143, 31);
            this.btnGetBlobArea.Style = UIDesign.UIStyle.LightOrange;
            this.btnGetBlobArea.TabIndex = 103;
            this.btnGetBlobArea.Text = "Blob检测";
            this.btnGetBlobArea.Click += new System.EventHandler(this.btnGetBlobArea_Click);
            // 
            // Numminthd
            // 
            this.Numminthd.Font = new System.Drawing.Font("宋体", 9F);
            this.Numminthd.Location = new System.Drawing.Point(102, 13);
            this.Numminthd.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Numminthd.Name = "Numminthd";
            this.Numminthd.Size = new System.Drawing.Size(68, 25);
            this.Numminthd.TabIndex = 0;
            this.Numminthd.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 15);
            this.label17.TabIndex = 1;
            this.label17.Text = "边缘阈值:";
            // 
            // FindCirclePanel
            // 
            this.FindCirclePanel.Controls.Add(this.NummaxRadius);
            this.FindCirclePanel.Controls.Add(this.NumEdgeThreshold);
            this.FindCirclePanel.Controls.Add(this.NumminRadius);
            this.FindCirclePanel.Controls.Add(this.label44);
            this.FindCirclePanel.Controls.Add(this.btnGetCircle);
            this.FindCirclePanel.Controls.Add(this.label49);
            this.FindCirclePanel.Controls.Add(this.label48);
            this.FindCirclePanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FindCirclePanel.Font = new System.Drawing.Font("宋体", 9F);
            this.FindCirclePanel.Location = new System.Drawing.Point(6, 1199);
            this.FindCirclePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FindCirclePanel.Name = "FindCirclePanel";
            this.FindCirclePanel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.FindCirclePanel.Size = new System.Drawing.Size(341, 97);
            this.FindCirclePanel.Style = UIDesign.UIStyle.LightOrange;
            this.FindCirclePanel.TabIndex = 3;
            this.FindCirclePanel.Text = null;
            // 
            // NummaxRadius
            // 
            this.NummaxRadius.Font = new System.Drawing.Font("宋体", 9F);
            this.NummaxRadius.Location = new System.Drawing.Point(262, 16);
            this.NummaxRadius.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NummaxRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NummaxRadius.Name = "NummaxRadius";
            this.NummaxRadius.Size = new System.Drawing.Size(68, 25);
            this.NummaxRadius.TabIndex = 11;
            this.NummaxRadius.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // NumEdgeThreshold
            // 
            this.NumEdgeThreshold.Font = new System.Drawing.Font("宋体", 9F);
            this.NumEdgeThreshold.Location = new System.Drawing.Point(104, 58);
            this.NumEdgeThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumEdgeThreshold.Name = "NumEdgeThreshold";
            this.NumEdgeThreshold.Size = new System.Drawing.Size(68, 25);
            this.NumEdgeThreshold.TabIndex = 6;
            this.NumEdgeThreshold.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // NumminRadius
            // 
            this.NumminRadius.Font = new System.Drawing.Font("宋体", 9F);
            this.NumminRadius.Location = new System.Drawing.Point(104, 15);
            this.NumminRadius.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NumminRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumminRadius.Name = "NumminRadius";
            this.NumminRadius.Size = new System.Drawing.Size(68, 25);
            this.NumminRadius.TabIndex = 10;
            this.NumminRadius.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(16, 63);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(75, 15);
            this.label44.TabIndex = 12;
            this.label44.Text = "边缘阈值:";
            // 
            // btnGetCircle
            // 
            this.btnGetCircle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetCircle.FillColor = System.Drawing.Color.White;
            this.btnGetCircle.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetCircle.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetCircle.Font = new System.Drawing.Font("宋体", 9F);
            this.btnGetCircle.ForeColor = System.Drawing.Color.Black;
            this.btnGetCircle.Location = new System.Drawing.Point(187, 54);
            this.btnGetCircle.Name = "btnGetCircle";
            this.btnGetCircle.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnGetCircle.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetCircle.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetCircle.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetCircle.Size = new System.Drawing.Size(143, 31);
            this.btnGetCircle.Style = UIDesign.UIStyle.LightOrange;
            this.btnGetCircle.TabIndex = 103;
            this.btnGetCircle.Text = "圆心计算";
            this.btnGetCircle.TipsText = "计算后的坐标为物理坐标";
            this.btnGetCircle.Click += new System.EventHandler(this.btnGetCircle_Click);
            this.btnGetCircle.MouseHover += new System.EventHandler(this.btnTest_modelMatch_MouseHover);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(182, 21);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(75, 15);
            this.label49.TabIndex = 28;
            this.label49.Text = "最大半径:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(16, 19);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(75, 15);
            this.label48.TabIndex = 26;
            this.label48.Text = "最小半径:";
            // 
            // LinesIntersectPanel
            // 
            this.LinesIntersectPanel.Controls.Add(this.NumcanThdup2);
            this.LinesIntersectPanel.Controls.Add(this.NumcanThdup);
            this.LinesIntersectPanel.Controls.Add(this.label27);
            this.LinesIntersectPanel.Controls.Add(this.label18);
            this.LinesIntersectPanel.Controls.Add(this.NumMaxLineGap2);
            this.LinesIntersectPanel.Controls.Add(this.NumMinLineLenght2);
            this.LinesIntersectPanel.Controls.Add(this.NumThresholdP2);
            this.LinesIntersectPanel.Controls.Add(this.label19);
            this.LinesIntersectPanel.Controls.Add(this.label30);
            this.LinesIntersectPanel.Controls.Add(this.label38);
            this.LinesIntersectPanel.Controls.Add(this.label13);
            this.LinesIntersectPanel.Controls.Add(this.NumMaxLineGap);
            this.LinesIntersectPanel.Controls.Add(this.NumcanThddown2);
            this.LinesIntersectPanel.Controls.Add(this.NumcanThddown);
            this.LinesIntersectPanel.Controls.Add(this.NumMinLineLenght);
            this.LinesIntersectPanel.Controls.Add(this.NumThresholdP);
            this.LinesIntersectPanel.Controls.Add(this.label12);
            this.LinesIntersectPanel.Controls.Add(this.label37);
            this.LinesIntersectPanel.Controls.Add(this.btnLntersectLine);
            this.LinesIntersectPanel.Controls.Add(this.btnSendDataToControl);
            this.LinesIntersectPanel.Controls.Add(this.btnGetLine2);
            this.LinesIntersectPanel.Controls.Add(this.btnGetLine1);
            this.LinesIntersectPanel.Controls.Add(this.label50);
            this.LinesIntersectPanel.Controls.Add(this.label51);
            this.LinesIntersectPanel.Controls.Add(this.label52);
            this.LinesIntersectPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LinesIntersectPanel.Font = new System.Drawing.Font("宋体", 9F);
            this.LinesIntersectPanel.Location = new System.Drawing.Point(7, 889);
            this.LinesIntersectPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LinesIntersectPanel.Name = "LinesIntersectPanel";
            this.LinesIntersectPanel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.LinesIntersectPanel.Size = new System.Drawing.Size(341, 275);
            this.LinesIntersectPanel.Style = UIDesign.UIStyle.LightOrange;
            this.LinesIntersectPanel.TabIndex = 3;
            this.LinesIntersectPanel.Text = null;
            // 
            // NumcanThdup2
            // 
            this.NumcanThdup2.Font = new System.Drawing.Font("宋体", 9F);
            this.NumcanThdup2.Location = new System.Drawing.Point(264, 43);
            this.NumcanThdup2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumcanThdup2.Name = "NumcanThdup2";
            this.NumcanThdup2.Size = new System.Drawing.Size(68, 25);
            this.NumcanThdup2.TabIndex = 112;
            this.NumcanThdup2.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // NumcanThdup
            // 
            this.NumcanThdup.Font = new System.Drawing.Font("宋体", 9F);
            this.NumcanThdup.Location = new System.Drawing.Point(100, 43);
            this.NumcanThdup.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumcanThdup.Name = "NumcanThdup";
            this.NumcanThdup.Size = new System.Drawing.Size(68, 25);
            this.NumcanThdup.TabIndex = 104;
            this.NumcanThdup.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(175, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(85, 15);
            this.label27.TabIndex = 114;
            this.label27.Text = "Canny阈值:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(174, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 15);
            this.label18.TabIndex = 113;
            this.label18.Text = "Canny阈值2:";
            // 
            // NumMaxLineGap2
            // 
            this.NumMaxLineGap2.Font = new System.Drawing.Font("宋体", 9F);
            this.NumMaxLineGap2.Location = new System.Drawing.Point(264, 144);
            this.NumMaxLineGap2.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NumMaxLineGap2.Name = "NumMaxLineGap2";
            this.NumMaxLineGap2.Size = new System.Drawing.Size(68, 25);
            this.NumMaxLineGap2.TabIndex = 108;
            this.NumMaxLineGap2.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // NumMinLineLenght2
            // 
            this.NumMinLineLenght2.Font = new System.Drawing.Font("宋体", 9F);
            this.NumMinLineLenght2.Location = new System.Drawing.Point(264, 110);
            this.NumMinLineLenght2.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NumMinLineLenght2.Name = "NumMinLineLenght2";
            this.NumMinLineLenght2.Size = new System.Drawing.Size(68, 25);
            this.NumMinLineLenght2.TabIndex = 107;
            this.NumMinLineLenght2.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // NumThresholdP2
            // 
            this.NumThresholdP2.Font = new System.Drawing.Font("宋体", 9F);
            this.NumThresholdP2.Location = new System.Drawing.Point(264, 76);
            this.NumThresholdP2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumThresholdP2.Name = "NumThresholdP2";
            this.NumThresholdP2.Size = new System.Drawing.Size(68, 25);
            this.NumThresholdP2.TabIndex = 106;
            this.NumThresholdP2.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(174, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 15);
            this.label19.TabIndex = 109;
            this.label19.Text = "累加器阈值2:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(174, 113);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(83, 15);
            this.label30.TabIndex = 110;
            this.label30.Text = "最小长度2:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(174, 147);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(83, 15);
            this.label38.TabIndex = 111;
            this.label38.Text = "最大断线2:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 15);
            this.label13.TabIndex = 105;
            this.label13.Text = "Canny阈值2:";
            // 
            // NumMaxLineGap
            // 
            this.NumMaxLineGap.Font = new System.Drawing.Font("宋体", 9F);
            this.NumMaxLineGap.Location = new System.Drawing.Point(100, 144);
            this.NumMaxLineGap.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NumMaxLineGap.Name = "NumMaxLineGap";
            this.NumMaxLineGap.Size = new System.Drawing.Size(68, 25);
            this.NumMaxLineGap.TabIndex = 5;
            this.NumMaxLineGap.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // NumcanThddown2
            // 
            this.NumcanThddown2.Font = new System.Drawing.Font("宋体", 9F);
            this.NumcanThddown2.Location = new System.Drawing.Point(264, 12);
            this.NumcanThddown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumcanThddown2.Name = "NumcanThddown2";
            this.NumcanThddown2.Size = new System.Drawing.Size(68, 25);
            this.NumcanThddown2.TabIndex = 6;
            this.NumcanThddown2.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // NumcanThddown
            // 
            this.NumcanThddown.Font = new System.Drawing.Font("宋体", 9F);
            this.NumcanThddown.Location = new System.Drawing.Point(100, 9);
            this.NumcanThddown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumcanThddown.Name = "NumcanThddown";
            this.NumcanThddown.Size = new System.Drawing.Size(68, 25);
            this.NumcanThddown.TabIndex = 0;
            this.NumcanThddown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // NumMinLineLenght
            // 
            this.NumMinLineLenght.Font = new System.Drawing.Font("宋体", 9F);
            this.NumMinLineLenght.Location = new System.Drawing.Point(100, 110);
            this.NumMinLineLenght.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NumMinLineLenght.Name = "NumMinLineLenght";
            this.NumMinLineLenght.Size = new System.Drawing.Size(68, 25);
            this.NumMinLineLenght.TabIndex = 4;
            this.NumMinLineLenght.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // NumThresholdP
            // 
            this.NumThresholdP.Font = new System.Drawing.Font("宋体", 9F);
            this.NumThresholdP.Location = new System.Drawing.Point(100, 76);
            this.NumThresholdP.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumThresholdP.Name = "NumThresholdP";
            this.NumThresholdP.Size = new System.Drawing.Size(68, 25);
            this.NumThresholdP.TabIndex = 1;
            this.NumThresholdP.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Canny阈值:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(175, 114);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(83, 15);
            this.label37.TabIndex = 6;
            this.label37.Text = "边缘阈值1:";
            // 
            // btnLntersectLine
            // 
            this.btnLntersectLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLntersectLine.FillColor = System.Drawing.Color.White;
            this.btnLntersectLine.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnLntersectLine.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnLntersectLine.Font = new System.Drawing.Font("宋体", 9F);
            this.btnLntersectLine.ForeColor = System.Drawing.Color.Black;
            this.btnLntersectLine.Location = new System.Drawing.Point(20, 232);
            this.btnLntersectLine.Name = "btnLntersectLine";
            this.btnLntersectLine.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnLntersectLine.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnLntersectLine.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnLntersectLine.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnLntersectLine.Size = new System.Drawing.Size(148, 31);
            this.btnLntersectLine.Style = UIDesign.UIStyle.LightOrange;
            this.btnLntersectLine.TabIndex = 101;
            this.btnLntersectLine.Text = "交点计算";
            this.btnLntersectLine.TipsText = "计算后的坐标为物理坐标";
            this.btnLntersectLine.Click += new System.EventHandler(this.btnIntersectLines_Click);
            this.btnLntersectLine.MouseHover += new System.EventHandler(this.btnTest_modelMatch_MouseHover);
            // 
            // btnSendDataToControl
            // 
            this.btnSendDataToControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendDataToControl.FillColor = System.Drawing.Color.White;
            this.btnSendDataToControl.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSendDataToControl.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSendDataToControl.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSendDataToControl.ForeColor = System.Drawing.Color.Black;
            this.btnSendDataToControl.Location = new System.Drawing.Point(181, 232);
            this.btnSendDataToControl.Name = "btnSendDataToControl";
            this.btnSendDataToControl.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnSendDataToControl.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSendDataToControl.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSendDataToControl.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSendDataToControl.Size = new System.Drawing.Size(148, 31);
            this.btnSendDataToControl.Style = UIDesign.UIStyle.LightOrange;
            this.btnSendDataToControl.TabIndex = 103;
            this.btnSendDataToControl.Text = "数据发送";
            this.btnSendDataToControl.Click += new System.EventHandler(this.btnSendDataToControl_Click);
            // 
            // btnGetLine2
            // 
            this.btnGetLine2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetLine2.FillColor = System.Drawing.Color.White;
            this.btnGetLine2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetLine2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetLine2.Font = new System.Drawing.Font("宋体", 9F);
            this.btnGetLine2.ForeColor = System.Drawing.Color.Black;
            this.btnGetLine2.Location = new System.Drawing.Point(181, 185);
            this.btnGetLine2.Name = "btnGetLine2";
            this.btnGetLine2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnGetLine2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetLine2.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetLine2.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetLine2.Size = new System.Drawing.Size(148, 31);
            this.btnGetLine2.Style = UIDesign.UIStyle.LightOrange;
            this.btnGetLine2.TabIndex = 102;
            this.btnGetLine2.Text = "查找直线2";
            this.btnGetLine2.Click += new System.EventHandler(this.btnGetLine2_Click);
            // 
            // btnGetLine1
            // 
            this.btnGetLine1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetLine1.FillColor = System.Drawing.Color.White;
            this.btnGetLine1.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetLine1.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetLine1.Font = new System.Drawing.Font("宋体", 9F);
            this.btnGetLine1.ForeColor = System.Drawing.Color.Black;
            this.btnGetLine1.Location = new System.Drawing.Point(20, 185);
            this.btnGetLine1.Name = "btnGetLine1";
            this.btnGetLine1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnGetLine1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetLine1.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetLine1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetLine1.Size = new System.Drawing.Size(148, 31);
            this.btnGetLine1.Style = UIDesign.UIStyle.LightOrange;
            this.btnGetLine1.TabIndex = 100;
            this.btnGetLine1.Text = "查找直线1";
            this.btnGetLine1.Click += new System.EventHandler(this.btnGetLine1_Click);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(10, 80);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(90, 15);
            this.label50.TabIndex = 16;
            this.label50.Text = "累加器阈值:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(10, 113);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(75, 15);
            this.label51.TabIndex = 18;
            this.label51.Text = "最小长度:";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(10, 147);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(75, 15);
            this.label52.TabIndex = 20;
            this.label52.Text = "最大断线:";
            // 
            // ModelMactPanel
            // 
            this.ModelMactPanel.Controls.Add(this.lIstModelInfo);
            this.ModelMactPanel.Controls.Add(this.NumMinContourArea);
            this.ModelMactPanel.Controls.Add(this.NumMaxContourArea);
            this.ModelMactPanel.Controls.Add(this.label24);
            this.ModelMactPanel.Controls.Add(this.label26);
            this.ModelMactPanel.Controls.Add(this.NumMincoutourLen);
            this.ModelMactPanel.Controls.Add(this.NumMaxcoutourLen);
            this.ModelMactPanel.Controls.Add(this.label22);
            this.ModelMactPanel.Controls.Add(this.label23);
            this.ModelMactPanel.Controls.Add(this.btnTest_modelMatch);
            this.ModelMactPanel.Controls.Add(this.picTemplate);
            this.ModelMactPanel.Controls.Add(this.NumSegthreshold);
            this.ModelMactPanel.Controls.Add(this.NumMatchValue);
            this.ModelMactPanel.Controls.Add(this.label25);
            this.ModelMactPanel.Controls.Add(this.label28);
            this.ModelMactPanel.Controls.Add(this.btnSaveModel);
            this.ModelMactPanel.Controls.Add(this.btncreateModel);
            this.ModelMactPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ModelMactPanel.Font = new System.Drawing.Font("宋体", 9F);
            this.ModelMactPanel.Location = new System.Drawing.Point(7, 286);
            this.ModelMactPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ModelMactPanel.Name = "ModelMactPanel";
            this.ModelMactPanel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.ModelMactPanel.Size = new System.Drawing.Size(341, 397);
            this.ModelMactPanel.Style = UIDesign.UIStyle.LightOrange;
            this.ModelMactPanel.TabIndex = 2;
            this.ModelMactPanel.Text = null;
            // 
            // lIstModelInfo
            // 
            this.lIstModelInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.lIstModelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lIstModelInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lIstModelInfo.FullRowSelect = true;
            this.lIstModelInfo.GridLines = true;
            this.lIstModelInfo.HeaderBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.lIstModelInfo.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lIstModelInfo.HideSelection = false;
            this.lIstModelInfo.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lIstModelInfo.Location = new System.Drawing.Point(10, 254);
            this.lIstModelInfo.Name = "lIstModelInfo";
            this.lIstModelInfo.RowBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.lIstModelInfo.RowBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.lIstModelInfo.SelectedBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.lIstModelInfo.SelectedEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(225)))), ((int)(((byte)(253)))));
            this.lIstModelInfo.Size = new System.Drawing.Size(322, 140);
            this.lIstModelInfo.TabIndex = 113;
            this.lIstModelInfo.UseCompatibleStateImageBehavior = false;
            this.lIstModelInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Info";
            this.columnHeader4.Width = 150;
            // 
            // NumMinContourArea
            // 
            this.NumMinContourArea.Font = new System.Drawing.Font("宋体", 9F);
            this.NumMinContourArea.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumMinContourArea.Location = new System.Drawing.Point(89, 85);
            this.NumMinContourArea.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NumMinContourArea.Name = "NumMinContourArea";
            this.NumMinContourArea.Size = new System.Drawing.Size(74, 25);
            this.NumMinContourArea.TabIndex = 109;
            this.NumMinContourArea.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // NumMaxContourArea
            // 
            this.NumMaxContourArea.Font = new System.Drawing.Font("宋体", 9F);
            this.NumMaxContourArea.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumMaxContourArea.Location = new System.Drawing.Point(258, 87);
            this.NumMaxContourArea.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NumMaxContourArea.Name = "NumMaxContourArea";
            this.NumMaxContourArea.Size = new System.Drawing.Size(74, 25);
            this.NumMaxContourArea.TabIndex = 110;
            this.NumMaxContourArea.Value = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 89);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(82, 15);
            this.label24.TabIndex = 112;
            this.label24.Text = "最小面积：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(177, 92);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(82, 15);
            this.label26.TabIndex = 111;
            this.label26.Text = "最大面积：";
            // 
            // NumMincoutourLen
            // 
            this.NumMincoutourLen.Font = new System.Drawing.Font("宋体", 9F);
            this.NumMincoutourLen.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumMincoutourLen.Location = new System.Drawing.Point(89, 48);
            this.NumMincoutourLen.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NumMincoutourLen.Name = "NumMincoutourLen";
            this.NumMincoutourLen.Size = new System.Drawing.Size(74, 25);
            this.NumMincoutourLen.TabIndex = 105;
            this.NumMincoutourLen.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // NumMaxcoutourLen
            // 
            this.NumMaxcoutourLen.Font = new System.Drawing.Font("宋体", 9F);
            this.NumMaxcoutourLen.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumMaxcoutourLen.Location = new System.Drawing.Point(258, 50);
            this.NumMaxcoutourLen.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumMaxcoutourLen.Name = "NumMaxcoutourLen";
            this.NumMaxcoutourLen.Size = new System.Drawing.Size(74, 25);
            this.NumMaxcoutourLen.TabIndex = 106;
            this.NumMaxcoutourLen.Value = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 52);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(82, 15);
            this.label22.TabIndex = 108;
            this.label22.Text = "最小长度：";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(177, 55);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(82, 15);
            this.label23.TabIndex = 107;
            this.label23.Text = "最大长度：";
            // 
            // btnTest_modelMatch
            // 
            this.btnTest_modelMatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest_modelMatch.FillColor = System.Drawing.Color.White;
            this.btnTest_modelMatch.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnTest_modelMatch.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnTest_modelMatch.Font = new System.Drawing.Font("宋体", 9F);
            this.btnTest_modelMatch.ForeColor = System.Drawing.Color.Black;
            this.btnTest_modelMatch.Location = new System.Drawing.Point(11, 173);
            this.btnTest_modelMatch.Name = "btnTest_modelMatch";
            this.btnTest_modelMatch.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnTest_modelMatch.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnTest_modelMatch.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnTest_modelMatch.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnTest_modelMatch.Size = new System.Drawing.Size(153, 31);
            this.btnTest_modelMatch.Style = UIDesign.UIStyle.LightOrange;
            this.btnTest_modelMatch.TabIndex = 99;
            this.btnTest_modelMatch.Text = "模板测试";
            this.btnTest_modelMatch.TipsText = "计算后的坐标为像素坐标";
            this.btnTest_modelMatch.Click += new System.EventHandler(this.btnTest_modelMatch_Click);
            this.btnTest_modelMatch.MouseHover += new System.EventHandler(this.btnTest_modelMatch_MouseHover);
            // 
            // picTemplate
            // 
            this.picTemplate.Font = new System.Drawing.Font("宋体", 9F);
            this.picTemplate.Location = new System.Drawing.Point(180, 128);
            this.picTemplate.Name = "picTemplate";
            this.picTemplate.Padding = new System.Windows.Forms.Padding(2);
            this.picTemplate.Size = new System.Drawing.Size(153, 120);
            this.picTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTemplate.TabIndex = 104;
            this.picTemplate.TabStop = false;
            this.picTemplate.MouseLeave += new System.EventHandler(this.picTemplate_MouseLeave);
            this.picTemplate.MouseHover += new System.EventHandler(this.picTemplate_MouseHover);
            // 
            // NumSegthreshold
            // 
            this.NumSegthreshold.Font = new System.Drawing.Font("宋体", 9F);
            this.NumSegthreshold.Location = new System.Drawing.Point(89, 11);
            this.NumSegthreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NumSegthreshold.Name = "NumSegthreshold";
            this.NumSegthreshold.Size = new System.Drawing.Size(74, 25);
            this.NumSegthreshold.TabIndex = 3;
            this.NumSegthreshold.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // NumMatchValue
            // 
            this.NumMatchValue.DecimalPlaces = 1;
            this.NumMatchValue.Font = new System.Drawing.Font("宋体", 9F);
            this.NumMatchValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumMatchValue.Location = new System.Drawing.Point(258, 13);
            this.NumMatchValue.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.NumMatchValue.Name = "NumMatchValue";
            this.NumMatchValue.Size = new System.Drawing.Size(74, 25);
            this.NumMatchValue.TabIndex = 5;
            this.NumMatchValue.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(8, 15);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(82, 15);
            this.label25.TabIndex = 73;
            this.label25.Text = "分割阈值：";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(177, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(82, 15);
            this.label28.TabIndex = 66;
            this.label28.Text = "匹配得分：";
            // 
            // btnSaveModel
            // 
            this.btnSaveModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveModel.FillColor = System.Drawing.Color.White;
            this.btnSaveModel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveModel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveModel.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSaveModel.ForeColor = System.Drawing.Color.Black;
            this.btnSaveModel.Location = new System.Drawing.Point(11, 217);
            this.btnSaveModel.Name = "btnSaveModel";
            this.btnSaveModel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnSaveModel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveModel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveModel.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveModel.Size = new System.Drawing.Size(153, 31);
            this.btnSaveModel.Style = UIDesign.UIStyle.LightOrange;
            this.btnSaveModel.TabIndex = 102;
            this.btnSaveModel.Text = "模板保存";
            this.btnSaveModel.Click += new System.EventHandler(this.btnSaveModel_Click);
            // 
            // btncreateModel
            // 
            this.btncreateModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncreateModel.FillColor = System.Drawing.Color.White;
            this.btncreateModel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btncreateModel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btncreateModel.Font = new System.Drawing.Font("宋体", 9F);
            this.btncreateModel.ForeColor = System.Drawing.Color.Black;
            this.btncreateModel.Location = new System.Drawing.Point(11, 128);
            this.btncreateModel.Name = "btncreateModel";
            this.btncreateModel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btncreateModel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btncreateModel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btncreateModel.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btncreateModel.Size = new System.Drawing.Size(153, 31);
            this.btncreateModel.Style = UIDesign.UIStyle.LightOrange;
            this.btncreateModel.TabIndex = 100;
            this.btncreateModel.Text = "创建模板";
            this.btncreateModel.Click += new System.EventHandler(this.btncreateModel_Click);
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.listViewFlow);
            this.panel16.Controls.Add(this.btnRunTool);
            this.panel16.Controls.Add(this.btnRunFlow);
            this.panel16.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel16.Font = new System.Drawing.Font("宋体", 9F);
            this.panel16.Location = new System.Drawing.Point(5, 94);
            this.panel16.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel16.Name = "panel16";
            this.panel16.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.panel16.Size = new System.Drawing.Size(341, 128);
            this.panel16.Style = UIDesign.UIStyle.LightOrange;
            this.panel16.TabIndex = 1;
            this.panel16.Text = null;
            // 
            // listViewFlow
            // 
            this.listViewFlow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.listViewFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewFlow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewFlow.GridLines = true;
            this.listViewFlow.HeaderBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.listViewFlow.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.listViewFlow.HideSelection = false;
            this.listViewFlow.Location = new System.Drawing.Point(5, 6);
            this.listViewFlow.Name = "listViewFlow";
            this.listViewFlow.RowBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.listViewFlow.RowBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.listViewFlow.SelectedBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.listViewFlow.SelectedEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(225)))), ((int)(((byte)(253)))));
            this.listViewFlow.Size = new System.Drawing.Size(198, 116);
            this.listViewFlow.TabIndex = 4;
            this.listViewFlow.UseCompatibleStateImageBehavior = false;
            this.listViewFlow.View = System.Windows.Forms.View.Details;
            this.listViewFlow.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewFlow_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "工具名称";
            // 
            // btnRunTool
            // 
            this.btnRunTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunTool.FillColor = System.Drawing.Color.White;
            this.btnRunTool.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRunTool.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRunTool.Font = new System.Drawing.Font("宋体", 9F);
            this.btnRunTool.ForeColor = System.Drawing.Color.Black;
            this.btnRunTool.Location = new System.Drawing.Point(215, 39);
            this.btnRunTool.Name = "btnRunTool";
            this.btnRunTool.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnRunTool.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRunTool.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRunTool.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRunTool.Size = new System.Drawing.Size(120, 35);
            this.btnRunTool.Style = UIDesign.UIStyle.LightOrange;
            this.btnRunTool.TabIndex = 100;
            this.btnRunTool.Text = "工具运行";
            this.btnRunTool.Click += new System.EventHandler(this.btnRunTool_Click);
            // 
            // btnRunFlow
            // 
            this.btnRunFlow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunFlow.FillColor = System.Drawing.Color.White;
            this.btnRunFlow.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRunFlow.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRunFlow.Font = new System.Drawing.Font("宋体", 9F);
            this.btnRunFlow.ForeColor = System.Drawing.Color.Black;
            this.btnRunFlow.Location = new System.Drawing.Point(215, 82);
            this.btnRunFlow.Name = "btnRunFlow";
            this.btnRunFlow.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnRunFlow.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRunFlow.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRunFlow.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRunFlow.Size = new System.Drawing.Size(120, 35);
            this.btnRunFlow.Style = UIDesign.UIStyle.LightOrange;
            this.btnRunFlow.TabIndex = 99;
            this.btnRunFlow.Text = "流程运行";
            this.btnRunFlow.Click += new System.EventHandler(this.btnRunFlow_Click);
            // 
            // chxbLinesIntersect
            // 
            this.chxbLinesIntersect.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.chxbLinesIntersect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chxbLinesIntersect.Font = new System.Drawing.Font("宋体", 9F);
            this.chxbLinesIntersect.Location = new System.Drawing.Point(8, 862);
            this.chxbLinesIntersect.Name = "chxbLinesIntersect";
            this.chxbLinesIntersect.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chxbLinesIntersect.Size = new System.Drawing.Size(142, 20);
            this.chxbLinesIntersect.Style = UIDesign.UIStyle.LightOrange;
            this.chxbLinesIntersect.TabIndex = 2;
            this.chxbLinesIntersect.Text = "3.1 直线定位：";
            this.chxbLinesIntersect.ValueChanged += new UIDesign.UICheckBox.OnValueChanged(this.checkBox1_CheckedChanged);
            // 
            // chxbFindCircle
            // 
            this.chxbFindCircle.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.chxbFindCircle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chxbFindCircle.Font = new System.Drawing.Font("宋体", 9F);
            this.chxbFindCircle.Location = new System.Drawing.Point(7, 1173);
            this.chxbFindCircle.Name = "chxbFindCircle";
            this.chxbFindCircle.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chxbFindCircle.Size = new System.Drawing.Size(142, 20);
            this.chxbFindCircle.Style = UIDesign.UIStyle.LightOrange;
            this.chxbFindCircle.TabIndex = 1;
            this.chxbFindCircle.Text = "3.2 找圆定位：";
            this.chxbFindCircle.ValueChanged += new UIDesign.UICheckBox.OnValueChanged(this.checkBox1_CheckedChanged);
            // 
            // chxbBlobCentre
            // 
            this.chxbBlobCentre.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.chxbBlobCentre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chxbBlobCentre.Font = new System.Drawing.Font("宋体", 9F);
            this.chxbBlobCentre.Location = new System.Drawing.Point(7, 1304);
            this.chxbBlobCentre.Name = "chxbBlobCentre";
            this.chxbBlobCentre.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chxbBlobCentre.Size = new System.Drawing.Size(142, 20);
            this.chxbBlobCentre.Style = UIDesign.UIStyle.LightOrange;
            this.chxbBlobCentre.TabIndex = 0;
            this.chxbBlobCentre.Text = "3.3 Blob定位：";
            this.chxbBlobCentre.ValueChanged += new UIDesign.UICheckBox.OnValueChanged(this.checkBox1_CheckedChanged);
            // 
            // cobxModelType
            // 
            this.cobxModelType.FillColor = System.Drawing.Color.White;
            this.cobxModelType.Font = new System.Drawing.Font("宋体", 9F);
            this.cobxModelType.Items.AddRange(new object[] {
            "ProductModel_1",
            "ProductModel_2",
            "CalibModel",
            "GluetapModel"});
            this.cobxModelType.Location = new System.Drawing.Point(150, 256);
            this.cobxModelType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cobxModelType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cobxModelType.Name = "cobxModelType";
            this.cobxModelType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.cobxModelType.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.cobxModelType.Size = new System.Drawing.Size(160, 25);
            this.cobxModelType.Style = UIDesign.UIStyle.LightOrange;
            this.cobxModelType.TabIndex = 1;
            this.cobxModelType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cobxModelType.SelectedIndexChanged += new System.EventHandler(this.cobxModelType_SelectedIndexChanged);
            // 
            // btnSaveModelParmas
            // 
            this.btnSaveModelParmas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveModelParmas.FillColor = System.Drawing.Color.White;
            this.btnSaveModelParmas.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveModelParmas.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveModelParmas.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSaveModelParmas.ForeColor = System.Drawing.Color.Black;
            this.btnSaveModelParmas.Location = new System.Drawing.Point(190, 17);
            this.btnSaveModelParmas.Name = "btnSaveModelParmas";
            this.btnSaveModelParmas.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnSaveModelParmas.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveModelParmas.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveModelParmas.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveModelParmas.Size = new System.Drawing.Size(150, 40);
            this.btnSaveModelParmas.Style = UIDesign.UIStyle.LightOrange;
            this.btnSaveModelParmas.TabIndex = 1;
            this.btnSaveModelParmas.Text = "参数保存";
            this.btnSaveModelParmas.Click += new System.EventHandler(this.btnSaveRunParmas_Click);
            // 
            // btnCoordiRecipe
            // 
            this.btnCoordiRecipe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCoordiRecipe.FillColor = System.Drawing.Color.White;
            this.btnCoordiRecipe.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCoordiRecipe.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCoordiRecipe.Font = new System.Drawing.Font("宋体", 9F);
            this.btnCoordiRecipe.ForeColor = System.Drawing.Color.Black;
            this.btnCoordiRecipe.Location = new System.Drawing.Point(17, 17);
            this.btnCoordiRecipe.Name = "btnCoordiRecipe";
            this.btnCoordiRecipe.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnCoordiRecipe.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCoordiRecipe.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCoordiRecipe.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCoordiRecipe.Size = new System.Drawing.Size(150, 40);
            this.btnCoordiRecipe.Style = UIDesign.UIStyle.LightOrange;
            this.btnCoordiRecipe.TabIndex = 0;
            this.btnCoordiRecipe.Text = "配方设置";
            this.btnCoordiRecipe.Click += new System.EventHandler(this.btnCoordiRecipe_Click);
            // 
            // uiLine2
            // 
            this.uiLine2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiLine2.Font = new System.Drawing.Font("宋体", 9F);
            this.uiLine2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.uiLine2.Location = new System.Drawing.Point(6, 229);
            this.uiLine2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uiLine2.MinimumSize = new System.Drawing.Size(3, 2);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(339, 23);
            this.uiLine2.Style = UIDesign.UIStyle.LightOrange;
            this.uiLine2.TabIndex = 96;
            this.uiLine2.Text = "检测流程编辑";
            // 
            // uiLine3
            // 
            this.uiLine3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiLine3.Font = new System.Drawing.Font("宋体", 9F);
            this.uiLine3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.uiLine3.Location = new System.Drawing.Point(7, 64);
            this.uiLine3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uiLine3.MinimumSize = new System.Drawing.Size(3, 2);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(339, 23);
            this.uiLine3.Style = UIDesign.UIStyle.LightOrange;
            this.uiLine3.TabIndex = 97;
            this.uiLine3.Text = "流程显示";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(7, 1476);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(349, 60);
            this.label66.TabIndex = 26;
            this.label66.Text = "备注：以上工具(1/2/3/4)随便选取一种来获取需要\r\n\r\n的特征点即可。\r\n\r\n";
            // 
            // linkLabel3
            // 
            this.linkLabel3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.linkLabel3.Location = new System.Drawing.Point(3, 1546);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(107, 20);
            this.linkLabel3.TabIndex = 1;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "自动标定协议";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(8, 902);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 15);
            this.linkLabel1.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.NinePointsOfPixelDatBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.NinePointsOfPixelGetBox, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 642);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // NinePointsOfPixelDatBox
            // 
            this.NinePointsOfPixelDatBox.Controls.Add(this.listViewPixel);
            this.NinePointsOfPixelDatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NinePointsOfPixelDatBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NinePointsOfPixelDatBox.Font = new System.Drawing.Font("宋体", 9F);
            this.NinePointsOfPixelDatBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.NinePointsOfPixelDatBox.Location = new System.Drawing.Point(4, 156);
            this.NinePointsOfPixelDatBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NinePointsOfPixelDatBox.Name = "NinePointsOfPixelDatBox";
            this.NinePointsOfPixelDatBox.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.NinePointsOfPixelDatBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.NinePointsOfPixelDatBox.Size = new System.Drawing.Size(386, 481);
            this.NinePointsOfPixelDatBox.Style = UIDesign.UIStyle.LightOrange;
            this.NinePointsOfPixelDatBox.TabIndex = 25;
            this.NinePointsOfPixelDatBox.Text = "像素坐标";
            this.NinePointsOfPixelDatBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.NinePointsOfPixelDatBox.TitleColor = System.Drawing.Color.Silver;
            this.NinePointsOfPixelDatBox.TitleHeight = 20;
            // 
            // listViewPixel
            // 
            this.listViewPixel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.listViewPixel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewPixel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listViewPixel.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewPixel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPixel.GridLines = true;
            this.listViewPixel.HeaderBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.listViewPixel.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.listViewPixel.HideSelection = false;
            this.listViewPixel.Location = new System.Drawing.Point(0, 20);
            this.listViewPixel.Name = "listViewPixel";
            this.listViewPixel.RowBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.listViewPixel.RowBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.listViewPixel.SelectedBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.listViewPixel.SelectedEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(225)))), ((int)(((byte)(253)))));
            this.listViewPixel.Size = new System.Drawing.Size(386, 461);
            this.listViewPixel.TabIndex = 1;
            this.listViewPixel.UseCompatibleStateImageBehavior = false;
            this.listViewPixel.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "ID";
            this.columnHeader10.Width = 30;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "X";
            this.columnHeader11.Width = 140;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Y";
            this.columnHeader12.Width = 140;
            // 
            // NinePointsOfPixelGetBox
            // 
            this.NinePointsOfPixelGetBox.Controls.Add(this.btnModifyPixelPoint);
            this.NinePointsOfPixelGetBox.Controls.Add(this.groupBox8);
            this.NinePointsOfPixelGetBox.Controls.Add(this.btnDeletePixelPoint);
            this.NinePointsOfPixelGetBox.Controls.Add(this.btnGetPixelPoint);
            this.NinePointsOfPixelGetBox.Controls.Add(this.btnNewPixelPoint);
            this.NinePointsOfPixelGetBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NinePointsOfPixelGetBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NinePointsOfPixelGetBox.Font = new System.Drawing.Font("宋体", 9F);
            this.NinePointsOfPixelGetBox.Location = new System.Drawing.Point(4, 5);
            this.NinePointsOfPixelGetBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NinePointsOfPixelGetBox.Name = "NinePointsOfPixelGetBox";
            this.NinePointsOfPixelGetBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.NinePointsOfPixelGetBox.Size = new System.Drawing.Size(386, 141);
            this.NinePointsOfPixelGetBox.Style = UIDesign.UIStyle.LightOrange;
            this.NinePointsOfPixelGetBox.TabIndex = 0;
            this.NinePointsOfPixelGetBox.Text = null;
            // 
            // btnModifyPixelPoint
            // 
            this.btnModifyPixelPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModifyPixelPoint.FillColor = System.Drawing.Color.White;
            this.btnModifyPixelPoint.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyPixelPoint.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyPixelPoint.Font = new System.Drawing.Font("宋体", 9F);
            this.btnModifyPixelPoint.ForeColor = System.Drawing.Color.Black;
            this.btnModifyPixelPoint.Location = new System.Drawing.Point(220, 107);
            this.btnModifyPixelPoint.Name = "btnModifyPixelPoint";
            this.btnModifyPixelPoint.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnModifyPixelPoint.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyPixelPoint.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyPixelPoint.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyPixelPoint.Size = new System.Drawing.Size(152, 27);
            this.btnModifyPixelPoint.Style = UIDesign.UIStyle.LightOrange;
            this.btnModifyPixelPoint.TabIndex = 4;
            this.btnModifyPixelPoint.Text = "Mark点修改";
            this.btnModifyPixelPoint.Click += new System.EventHandler(this.btnModifyPixelPoint_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txbpixelY);
            this.groupBox8.Controls.Add(this.txbpixelX);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox8.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.groupBox8.Location = new System.Drawing.Point(13, 8);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.groupBox8.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.groupBox8.Size = new System.Drawing.Size(176, 126);
            this.groupBox8.Style = UIDesign.UIStyle.LightOrange;
            this.groupBox8.TabIndex = 1;
            this.groupBox8.Text = "像素坐标";
            this.groupBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.groupBox8.TitleColor = System.Drawing.Color.Silver;
            this.groupBox8.TitleHeight = 20;
            // 
            // txbpixelY
            // 
            this.txbpixelY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbpixelY.FillColor = System.Drawing.Color.White;
            this.txbpixelY.Font = new System.Drawing.Font("宋体", 9F);
            this.txbpixelY.Location = new System.Drawing.Point(61, 82);
            this.txbpixelY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbpixelY.Maximum = 2147483647D;
            this.txbpixelY.Minimum = -2147483648D;
            this.txbpixelY.Name = "txbpixelY";
            this.txbpixelY.Padding = new System.Windows.Forms.Padding(5);
            this.txbpixelY.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbpixelY.Size = new System.Drawing.Size(77, 25);
            this.txbpixelY.Style = UIDesign.UIStyle.LightOrange;
            this.txbpixelY.TabIndex = 1;
            // 
            // txbpixelX
            // 
            this.txbpixelX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbpixelX.FillColor = System.Drawing.Color.White;
            this.txbpixelX.Font = new System.Drawing.Font("宋体", 9F);
            this.txbpixelX.Location = new System.Drawing.Point(61, 36);
            this.txbpixelX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbpixelX.Maximum = 2147483647D;
            this.txbpixelX.Minimum = -2147483648D;
            this.txbpixelX.Name = "txbpixelX";
            this.txbpixelX.Padding = new System.Windows.Forms.Padding(5);
            this.txbpixelX.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbpixelX.Size = new System.Drawing.Size(77, 25);
            this.txbpixelX.Style = UIDesign.UIStyle.LightOrange;
            this.txbpixelX.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(32, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(32, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "X:";
            // 
            // btnDeletePixelPoint
            // 
            this.btnDeletePixelPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletePixelPoint.FillColor = System.Drawing.Color.White;
            this.btnDeletePixelPoint.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeletePixelPoint.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeletePixelPoint.Font = new System.Drawing.Font("宋体", 9F);
            this.btnDeletePixelPoint.ForeColor = System.Drawing.Color.Black;
            this.btnDeletePixelPoint.Location = new System.Drawing.Point(220, 74);
            this.btnDeletePixelPoint.Name = "btnDeletePixelPoint";
            this.btnDeletePixelPoint.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnDeletePixelPoint.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeletePixelPoint.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeletePixelPoint.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeletePixelPoint.Size = new System.Drawing.Size(152, 27);
            this.btnDeletePixelPoint.Style = UIDesign.UIStyle.LightOrange;
            this.btnDeletePixelPoint.TabIndex = 3;
            this.btnDeletePixelPoint.Text = "Mark点删除";
            this.btnDeletePixelPoint.Click += new System.EventHandler(this.btnDeletePixelPoint_Click);
            // 
            // btnGetPixelPoint
            // 
            this.btnGetPixelPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetPixelPoint.FillColor = System.Drawing.Color.White;
            this.btnGetPixelPoint.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetPixelPoint.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetPixelPoint.Font = new System.Drawing.Font("宋体", 9F);
            this.btnGetPixelPoint.ForeColor = System.Drawing.Color.Black;
            this.btnGetPixelPoint.Location = new System.Drawing.Point(220, 8);
            this.btnGetPixelPoint.Name = "btnGetPixelPoint";
            this.btnGetPixelPoint.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnGetPixelPoint.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetPixelPoint.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetPixelPoint.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetPixelPoint.Size = new System.Drawing.Size(152, 27);
            this.btnGetPixelPoint.Style = UIDesign.UIStyle.LightOrange;
            this.btnGetPixelPoint.TabIndex = 1;
            this.btnGetPixelPoint.Text = "Mark点获取";
            this.btnGetPixelPoint.Click += new System.EventHandler(this.btnGetPixelPoint_Click);
            // 
            // btnNewPixelPoint
            // 
            this.btnNewPixelPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewPixelPoint.FillColor = System.Drawing.Color.White;
            this.btnNewPixelPoint.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnNewPixelPoint.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnNewPixelPoint.Font = new System.Drawing.Font("宋体", 9F);
            this.btnNewPixelPoint.ForeColor = System.Drawing.Color.Black;
            this.btnNewPixelPoint.Location = new System.Drawing.Point(220, 41);
            this.btnNewPixelPoint.Name = "btnNewPixelPoint";
            this.btnNewPixelPoint.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnNewPixelPoint.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnNewPixelPoint.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnNewPixelPoint.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnNewPixelPoint.Size = new System.Drawing.Size(152, 27);
            this.btnNewPixelPoint.Style = UIDesign.UIStyle.LightOrange;
            this.btnNewPixelPoint.TabIndex = 2;
            this.btnNewPixelPoint.Text = "Mark点新增";
            this.btnNewPixelPoint.Click += new System.EventHandler(this.btnNewPixelPoint_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.NinePointsOfRobotGetBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.NinePointsOfRobotDatBox, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(394, 642);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // NinePointsOfRobotGetBox
            // 
            this.NinePointsOfRobotGetBox.Controls.Add(this.btnModifyRobotPoint);
            this.NinePointsOfRobotGetBox.Controls.Add(this.btnDeleteRobotPoint);
            this.NinePointsOfRobotGetBox.Controls.Add(this.uiTitlePanel1);
            this.NinePointsOfRobotGetBox.Controls.Add(this.BtnNewRobotPoint);
            this.NinePointsOfRobotGetBox.Controls.Add(this.btnGetRobotPoint);
            this.NinePointsOfRobotGetBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NinePointsOfRobotGetBox.Font = new System.Drawing.Font("宋体", 9F);
            this.NinePointsOfRobotGetBox.Location = new System.Drawing.Point(4, 5);
            this.NinePointsOfRobotGetBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NinePointsOfRobotGetBox.Name = "NinePointsOfRobotGetBox";
            this.NinePointsOfRobotGetBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.NinePointsOfRobotGetBox.Size = new System.Drawing.Size(386, 141);
            this.NinePointsOfRobotGetBox.Style = UIDesign.UIStyle.LightOrange;
            this.NinePointsOfRobotGetBox.TabIndex = 1;
            this.NinePointsOfRobotGetBox.Text = null;
            // 
            // btnModifyRobotPoint
            // 
            this.btnModifyRobotPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModifyRobotPoint.FillColor = System.Drawing.Color.White;
            this.btnModifyRobotPoint.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyRobotPoint.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyRobotPoint.Font = new System.Drawing.Font("宋体", 9F);
            this.btnModifyRobotPoint.ForeColor = System.Drawing.Color.Black;
            this.btnModifyRobotPoint.Location = new System.Drawing.Point(224, 107);
            this.btnModifyRobotPoint.Name = "btnModifyRobotPoint";
            this.btnModifyRobotPoint.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnModifyRobotPoint.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyRobotPoint.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyRobotPoint.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyRobotPoint.Size = new System.Drawing.Size(152, 27);
            this.btnModifyRobotPoint.Style = UIDesign.UIStyle.LightOrange;
            this.btnModifyRobotPoint.TabIndex = 3;
            this.btnModifyRobotPoint.Text = "机器人点位修改";
            this.btnModifyRobotPoint.Click += new System.EventHandler(this.btnModifyRobotPoint_Click);
            // 
            // btnDeleteRobotPoint
            // 
            this.btnDeleteRobotPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteRobotPoint.FillColor = System.Drawing.Color.White;
            this.btnDeleteRobotPoint.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeleteRobotPoint.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeleteRobotPoint.Font = new System.Drawing.Font("宋体", 9F);
            this.btnDeleteRobotPoint.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteRobotPoint.Location = new System.Drawing.Point(224, 74);
            this.btnDeleteRobotPoint.Name = "btnDeleteRobotPoint";
            this.btnDeleteRobotPoint.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnDeleteRobotPoint.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeleteRobotPoint.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeleteRobotPoint.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeleteRobotPoint.Size = new System.Drawing.Size(152, 27);
            this.btnDeleteRobotPoint.Style = UIDesign.UIStyle.LightOrange;
            this.btnDeleteRobotPoint.TabIndex = 4;
            this.btnDeleteRobotPoint.Text = "机器人点位删除";
            this.btnDeleteRobotPoint.Click += new System.EventHandler(this.btnDeleteRobotPoint_Click);
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.label6);
            this.uiTitlePanel1.Controls.Add(this.txbrobotX);
            this.uiTitlePanel1.Controls.Add(this.txbrobotR);
            this.uiTitlePanel1.Controls.Add(this.label1);
            this.uiTitlePanel1.Controls.Add(this.label2);
            this.uiTitlePanel1.Controls.Add(this.txbrobotY);
            this.uiTitlePanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiTitlePanel1.Font = new System.Drawing.Font("宋体", 9F);
            this.uiTitlePanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.uiTitlePanel1.Location = new System.Drawing.Point(13, 8);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.uiTitlePanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.uiTitlePanel1.Size = new System.Drawing.Size(176, 126);
            this.uiTitlePanel1.Style = UIDesign.UIStyle.LightOrange;
            this.uiTitlePanel1.TabIndex = 1;
            this.uiTitlePanel1.Text = "物理坐标";
            this.uiTitlePanel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel1.TitleColor = System.Drawing.Color.Silver;
            this.uiTitlePanel1.TitleHeight = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(40, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "X:";
            // 
            // txbrobotX
            // 
            this.txbrobotX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbrobotX.FillColor = System.Drawing.Color.White;
            this.txbrobotX.Font = new System.Drawing.Font("宋体", 9F);
            this.txbrobotX.Location = new System.Drawing.Point(63, 31);
            this.txbrobotX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbrobotX.Maximum = 2147483647D;
            this.txbrobotX.Minimum = -2147483648D;
            this.txbrobotX.Name = "txbrobotX";
            this.txbrobotX.Padding = new System.Windows.Forms.Padding(5);
            this.txbrobotX.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbrobotX.Size = new System.Drawing.Size(77, 25);
            this.txbrobotX.Style = UIDesign.UIStyle.LightOrange;
            this.txbrobotX.TabIndex = 1;
            // 
            // txbrobotR
            // 
            this.txbrobotR.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbrobotR.FillColor = System.Drawing.Color.White;
            this.txbrobotR.Font = new System.Drawing.Font("宋体", 9F);
            this.txbrobotR.Location = new System.Drawing.Point(63, 91);
            this.txbrobotR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbrobotR.Maximum = 2147483647D;
            this.txbrobotR.Minimum = -2147483648D;
            this.txbrobotR.Name = "txbrobotR";
            this.txbrobotR.Padding = new System.Windows.Forms.Padding(5);
            this.txbrobotR.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbrobotR.Size = new System.Drawing.Size(77, 25);
            this.txbrobotR.Style = UIDesign.UIStyle.LightOrange;
            this.txbrobotR.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 15);
            this.label1.TabIndex = 32;
            this.label1.Text = "R:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Y:";
            // 
            // txbrobotY
            // 
            this.txbrobotY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbrobotY.FillColor = System.Drawing.Color.White;
            this.txbrobotY.Font = new System.Drawing.Font("宋体", 9F);
            this.txbrobotY.Location = new System.Drawing.Point(63, 60);
            this.txbrobotY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbrobotY.Maximum = 2147483647D;
            this.txbrobotY.Minimum = -2147483648D;
            this.txbrobotY.Name = "txbrobotY";
            this.txbrobotY.Padding = new System.Windows.Forms.Padding(5);
            this.txbrobotY.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbrobotY.Size = new System.Drawing.Size(77, 25);
            this.txbrobotY.Style = UIDesign.UIStyle.LightOrange;
            this.txbrobotY.TabIndex = 2;
            // 
            // BtnNewRobotPoint
            // 
            this.BtnNewRobotPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNewRobotPoint.FillColor = System.Drawing.Color.White;
            this.BtnNewRobotPoint.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.BtnNewRobotPoint.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.BtnNewRobotPoint.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnNewRobotPoint.ForeColor = System.Drawing.Color.Black;
            this.BtnNewRobotPoint.Location = new System.Drawing.Point(224, 41);
            this.BtnNewRobotPoint.Name = "BtnNewRobotPoint";
            this.BtnNewRobotPoint.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.BtnNewRobotPoint.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.BtnNewRobotPoint.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.BtnNewRobotPoint.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.BtnNewRobotPoint.Size = new System.Drawing.Size(152, 27);
            this.BtnNewRobotPoint.Style = UIDesign.UIStyle.LightOrange;
            this.BtnNewRobotPoint.TabIndex = 6;
            this.BtnNewRobotPoint.Text = "机器人点位新增";
            this.BtnNewRobotPoint.Click += new System.EventHandler(this.BtnNewRobotPoint_Click);
            // 
            // btnGetRobotPoint
            // 
            this.btnGetRobotPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetRobotPoint.Enabled = false;
            this.btnGetRobotPoint.FillColor = System.Drawing.Color.White;
            this.btnGetRobotPoint.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetRobotPoint.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetRobotPoint.Font = new System.Drawing.Font("宋体", 9F);
            this.btnGetRobotPoint.ForeColor = System.Drawing.Color.Black;
            this.btnGetRobotPoint.Location = new System.Drawing.Point(224, 8);
            this.btnGetRobotPoint.Name = "btnGetRobotPoint";
            this.btnGetRobotPoint.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnGetRobotPoint.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetRobotPoint.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetRobotPoint.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetRobotPoint.Size = new System.Drawing.Size(152, 27);
            this.btnGetRobotPoint.Style = UIDesign.UIStyle.LightOrange;
            this.btnGetRobotPoint.TabIndex = 5;
            this.btnGetRobotPoint.Text = "机器人点位获取";
            // 
            // NinePointsOfRobotDatBox
            // 
            this.NinePointsOfRobotDatBox.Controls.Add(this.listViewRobot);
            this.NinePointsOfRobotDatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NinePointsOfRobotDatBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NinePointsOfRobotDatBox.Font = new System.Drawing.Font("宋体", 9F);
            this.NinePointsOfRobotDatBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.NinePointsOfRobotDatBox.Location = new System.Drawing.Point(4, 157);
            this.NinePointsOfRobotDatBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NinePointsOfRobotDatBox.Name = "NinePointsOfRobotDatBox";
            this.NinePointsOfRobotDatBox.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.NinePointsOfRobotDatBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.NinePointsOfRobotDatBox.Size = new System.Drawing.Size(386, 480);
            this.NinePointsOfRobotDatBox.Style = UIDesign.UIStyle.LightOrange;
            this.NinePointsOfRobotDatBox.TabIndex = 26;
            this.NinePointsOfRobotDatBox.Text = "物理坐标";
            this.NinePointsOfRobotDatBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.NinePointsOfRobotDatBox.TitleColor = System.Drawing.Color.Silver;
            this.NinePointsOfRobotDatBox.TitleHeight = 20;
            // 
            // listViewRobot
            // 
            this.listViewRobot.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.listViewRobot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewRobot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22});
            this.listViewRobot.ContextMenuStrip = this.contextMenuStrip2;
            this.listViewRobot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRobot.GridLines = true;
            this.listViewRobot.HeaderBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.listViewRobot.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.listViewRobot.HideSelection = false;
            this.listViewRobot.Location = new System.Drawing.Point(0, 20);
            this.listViewRobot.Name = "listViewRobot";
            this.listViewRobot.RowBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.listViewRobot.RowBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.listViewRobot.SelectedBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.listViewRobot.SelectedEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(225)))), ((int)(((byte)(253)))));
            this.listViewRobot.Size = new System.Drawing.Size(386, 460);
            this.listViewRobot.TabIndex = 2;
            this.listViewRobot.UseCompatibleStateImageBehavior = false;
            this.listViewRobot.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "ID";
            this.columnHeader20.Width = 30;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "X";
            this.columnHeader21.Width = 140;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Y";
            this.columnHeader22.Width = 140;
            // 
            // chxbAutoCoorSys
            // 
            this.chxbAutoCoorSys.BackColor = System.Drawing.Color.White;
            this.chxbAutoCoorSys.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.chxbAutoCoorSys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chxbAutoCoorSys.Font = new System.Drawing.Font("宋体", 9F);
            this.chxbAutoCoorSys.Location = new System.Drawing.Point(5, 19);
            this.chxbAutoCoorSys.Name = "chxbAutoCoorSys";
            this.chxbAutoCoorSys.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chxbAutoCoorSys.Size = new System.Drawing.Size(142, 20);
            this.chxbAutoCoorSys.Style = UIDesign.UIStyle.LightOrange;
            this.chxbAutoCoorSys.TabIndex = 4;
            this.chxbAutoCoorSys.Text = "自动同步坐标系";
            this.chxbAutoCoorSys.ValueChanged += new UIDesign.UICheckBox.OnValueChanged(this.chxbAutoCoorSys_CheckedChanged);
            // 
            // btnSaveParma
            // 
            this.btnSaveParma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveParma.FillColor = System.Drawing.Color.White;
            this.btnSaveParma.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveParma.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveParma.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSaveParma.ForeColor = System.Drawing.Color.Black;
            this.btnSaveParma.Location = new System.Drawing.Point(214, 52);
            this.btnSaveParma.Name = "btnSaveParma";
            this.btnSaveParma.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnSaveParma.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveParma.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveParma.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveParma.Size = new System.Drawing.Size(151, 40);
            this.btnSaveParma.Style = UIDesign.UIStyle.LightOrange;
            this.btnSaveParma.TabIndex = 4;
            this.btnSaveParma.Text = "参数保存";
            this.btnSaveParma.Click += new System.EventHandler(this.BtnSaveParmasOfNightPoints_click);
            // 
            // btnConvert
            // 
            this.btnConvert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvert.FillColor = System.Drawing.Color.White;
            this.btnConvert.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnConvert.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnConvert.Font = new System.Drawing.Font("宋体", 9F);
            this.btnConvert.ForeColor = System.Drawing.Color.Black;
            this.btnConvert.Location = new System.Drawing.Point(5, 52);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnConvert.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnConvert.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnConvert.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnConvert.Size = new System.Drawing.Size(151, 40);
            this.btnConvert.Style = UIDesign.UIStyle.LightOrange;
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "转换";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.txbXRms, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label43, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label53, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.txbYRms, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txbSx, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txbTy, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.txbSy, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label11, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txbPhi, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label9, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.txbTheta, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.txbTx, 1, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(11, 29);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(372, 127);
            this.tableLayoutPanel4.TabIndex = 38;
            // 
            // txbXRms
            // 
            this.txbXRms.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbXRms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbXRms.Location = new System.Drawing.Point(100, 101);
            this.txbXRms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbXRms.Name = "txbXRms";
            this.txbXRms.ReadOnly = true;
            this.txbXRms.Size = new System.Drawing.Size(76, 18);
            this.txbXRms.TabIndex = 37;
            // 
            // label43
            // 
            this.label43.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(23, 102);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(47, 15);
            this.label43.TabIndex = 36;
            this.label43.Text = "XRMS:";
            // 
            // label53
            // 
            this.label53.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(207, 102);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(47, 15);
            this.label53.TabIndex = 34;
            this.label53.Text = "YRMS:";
            // 
            // txbYRms
            // 
            this.txbYRms.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbYRms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbYRms.Location = new System.Drawing.Point(286, 101);
            this.txbYRms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbYRms.Name = "txbYRms";
            this.txbYRms.ReadOnly = true;
            this.txbYRms.Size = new System.Drawing.Size(76, 18);
            this.txbYRms.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "X缩放:";
            // 
            // txbSx
            // 
            this.txbSx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbSx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbSx.Location = new System.Drawing.Point(100, 7);
            this.txbSx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbSx.Name = "txbSx";
            this.txbSx.ReadOnly = true;
            this.txbSx.Size = new System.Drawing.Size(76, 18);
            this.txbSx.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "Y缩放:";
            // 
            // txbTy
            // 
            this.txbTy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbTy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTy.Location = new System.Drawing.Point(286, 69);
            this.txbTy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbTy.Name = "txbTy";
            this.txbTy.ReadOnly = true;
            this.txbTy.Size = new System.Drawing.Size(76, 18);
            this.txbTy.TabIndex = 33;
            // 
            // txbSy
            // 
            this.txbSy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbSy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbSy.Location = new System.Drawing.Point(286, 7);
            this.txbSy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbSy.Name = "txbSy";
            this.txbSy.ReadOnly = true;
            this.txbSy.Size = new System.Drawing.Size(76, 18);
            this.txbSy.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(196, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 15);
            this.label11.TabIndex = 32;
            this.label11.Text = "Y偏移量:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "旋转弧:";
            // 
            // txbPhi
            // 
            this.txbPhi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbPhi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPhi.Location = new System.Drawing.Point(100, 38);
            this.txbPhi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbPhi.Name = "txbPhi";
            this.txbPhi.ReadOnly = true;
            this.txbPhi.Size = new System.Drawing.Size(76, 18);
            this.txbPhi.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "X偏移量:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(200, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "倾斜弧:";
            // 
            // txbTheta
            // 
            this.txbTheta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbTheta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTheta.Location = new System.Drawing.Point(286, 38);
            this.txbTheta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbTheta.Name = "txbTheta";
            this.txbTheta.ReadOnly = true;
            this.txbTheta.Size = new System.Drawing.Size(76, 18);
            this.txbTheta.TabIndex = 29;
            // 
            // txbTx
            // 
            this.txbTx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbTx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTx.Location = new System.Drawing.Point(100, 69);
            this.txbTx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbTx.Name = "txbTx";
            this.txbTx.ReadOnly = true;
            this.txbTx.Size = new System.Drawing.Size(76, 18);
            this.txbTx.TabIndex = 31;
            // 
            // uiPanel4
            // 
            this.uiPanel4.Controls.Add(this.txbMarkRobotY);
            this.uiPanel4.Controls.Add(this.txbMarkRobotX);
            this.uiPanel4.Controls.Add(this.label20);
            this.uiPanel4.Controls.Add(this.label21);
            this.uiPanel4.Controls.Add(this.label57);
            this.uiPanel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiPanel4.Font = new System.Drawing.Font("宋体", 9F);
            this.uiPanel4.Location = new System.Drawing.Point(213, 22);
            this.uiPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel4.Name = "uiPanel4";
            this.uiPanel4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.uiPanel4.Size = new System.Drawing.Size(153, 114);
            this.uiPanel4.Style = UIDesign.UIStyle.LightOrange;
            this.uiPanel4.TabIndex = 1;
            this.uiPanel4.Text = null;
            // 
            // txbMarkRobotY
            // 
            this.txbMarkRobotY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMarkRobotY.FillColor = System.Drawing.Color.White;
            this.txbMarkRobotY.Font = new System.Drawing.Font("宋体", 9F);
            this.txbMarkRobotY.Location = new System.Drawing.Point(70, 76);
            this.txbMarkRobotY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbMarkRobotY.Maximum = 2147483647D;
            this.txbMarkRobotY.Minimum = -2147483648D;
            this.txbMarkRobotY.Name = "txbMarkRobotY";
            this.txbMarkRobotY.Padding = new System.Windows.Forms.Padding(5);
            this.txbMarkRobotY.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbMarkRobotY.Size = new System.Drawing.Size(77, 25);
            this.txbMarkRobotY.Style = UIDesign.UIStyle.LightOrange;
            this.txbMarkRobotY.TabIndex = 4;
            this.txbMarkRobotY.Text = "0";
            // 
            // txbMarkRobotX
            // 
            this.txbMarkRobotX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMarkRobotX.FillColor = System.Drawing.Color.White;
            this.txbMarkRobotX.Font = new System.Drawing.Font("宋体", 9F);
            this.txbMarkRobotX.Location = new System.Drawing.Point(70, 40);
            this.txbMarkRobotX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbMarkRobotX.Maximum = 2147483647D;
            this.txbMarkRobotX.Minimum = -2147483648D;
            this.txbMarkRobotX.Name = "txbMarkRobotX";
            this.txbMarkRobotX.Padding = new System.Windows.Forms.Padding(5);
            this.txbMarkRobotX.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbMarkRobotX.Size = new System.Drawing.Size(77, 25);
            this.txbMarkRobotX.Style = UIDesign.UIStyle.LightOrange;
            this.txbMarkRobotX.TabIndex = 4;
            this.txbMarkRobotX.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(50, 83);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 15);
            this.label20.TabIndex = 3;
            this.label20.Text = "Y";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(51, 45);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(15, 15);
            this.label21.TabIndex = 1;
            this.label21.Text = "X";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.Color.White;
            this.label57.Location = new System.Drawing.Point(12, 13);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(82, 15);
            this.label57.TabIndex = 1;
            this.label57.Text = "物理坐标：";
            // 
            // uiPanel3
            // 
            this.uiPanel3.Controls.Add(this.txbMarkPixelY);
            this.uiPanel3.Controls.Add(this.txbMarkPixelX);
            this.uiPanel3.Controls.Add(this.label56);
            this.uiPanel3.Controls.Add(this.label59);
            this.uiPanel3.Controls.Add(this.label58);
            this.uiPanel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiPanel3.Font = new System.Drawing.Font("宋体", 9F);
            this.uiPanel3.Location = new System.Drawing.Point(7, 22);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.uiPanel3.Size = new System.Drawing.Size(153, 114);
            this.uiPanel3.Style = UIDesign.UIStyle.LightOrange;
            this.uiPanel3.TabIndex = 0;
            this.uiPanel3.Text = null;
            // 
            // txbMarkPixelY
            // 
            this.txbMarkPixelY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMarkPixelY.FillColor = System.Drawing.Color.White;
            this.txbMarkPixelY.Font = new System.Drawing.Font("宋体", 9F);
            this.txbMarkPixelY.Location = new System.Drawing.Point(70, 76);
            this.txbMarkPixelY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbMarkPixelY.Maximum = 2147483647D;
            this.txbMarkPixelY.Minimum = -2147483648D;
            this.txbMarkPixelY.Name = "txbMarkPixelY";
            this.txbMarkPixelY.Padding = new System.Windows.Forms.Padding(5);
            this.txbMarkPixelY.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbMarkPixelY.Size = new System.Drawing.Size(77, 25);
            this.txbMarkPixelY.Style = UIDesign.UIStyle.LightOrange;
            this.txbMarkPixelY.TabIndex = 4;
            this.txbMarkPixelY.Text = "0";
            // 
            // txbMarkPixelX
            // 
            this.txbMarkPixelX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMarkPixelX.FillColor = System.Drawing.Color.White;
            this.txbMarkPixelX.Font = new System.Drawing.Font("宋体", 9F);
            this.txbMarkPixelX.Location = new System.Drawing.Point(70, 40);
            this.txbMarkPixelX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbMarkPixelX.Maximum = 2147483647D;
            this.txbMarkPixelX.Minimum = -2147483648D;
            this.txbMarkPixelX.Name = "txbMarkPixelX";
            this.txbMarkPixelX.Padding = new System.Windows.Forms.Padding(5);
            this.txbMarkPixelX.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbMarkPixelX.Size = new System.Drawing.Size(77, 25);
            this.txbMarkPixelX.Style = UIDesign.UIStyle.LightOrange;
            this.txbMarkPixelX.TabIndex = 2;
            this.txbMarkPixelX.Text = "0";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.BackColor = System.Drawing.Color.White;
            this.label56.Location = new System.Drawing.Point(5, 13);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(82, 15);
            this.label56.TabIndex = 0;
            this.label56.Text = "像素坐标：";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.Color.White;
            this.label59.Location = new System.Drawing.Point(50, 83);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(15, 15);
            this.label59.TabIndex = 3;
            this.label59.Text = "Y";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.White;
            this.label58.Location = new System.Drawing.Point(51, 45);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(15, 15);
            this.label58.TabIndex = 1;
            this.label58.Text = "X";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.RotateCalBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.RotateOfPixelDatBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.RotatePixelGetBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 642);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // RotateCalBox
            // 
            this.RotateCalBox.Controls.Add(this.btnRatitoCaliDataSave);
            this.RotateCalBox.Controls.Add(this.txbCurrRorateCenterY);
            this.RotateCalBox.Controls.Add(this.label35);
            this.RotateCalBox.Controls.Add(this.btnCaculateRorateCenter);
            this.RotateCalBox.Controls.Add(this.label34);
            this.RotateCalBox.Controls.Add(this.txbCurrRorateCenterX);
            this.RotateCalBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RotateCalBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RotateCalBox.Font = new System.Drawing.Font("宋体", 9F);
            this.RotateCalBox.Location = new System.Drawing.Point(4, 155);
            this.RotateCalBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RotateCalBox.Name = "RotateCalBox";
            this.RotateCalBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.RotateCalBox.Size = new System.Drawing.Size(386, 90);
            this.RotateCalBox.Style = UIDesign.UIStyle.LightOrange;
            this.RotateCalBox.TabIndex = 29;
            this.RotateCalBox.Text = null;
            // 
            // btnRatitoCaliDataSave
            // 
            this.btnRatitoCaliDataSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRatitoCaliDataSave.FillColor = System.Drawing.Color.White;
            this.btnRatitoCaliDataSave.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRatitoCaliDataSave.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRatitoCaliDataSave.Font = new System.Drawing.Font("宋体", 9F);
            this.btnRatitoCaliDataSave.ForeColor = System.Drawing.Color.Black;
            this.btnRatitoCaliDataSave.Location = new System.Drawing.Point(28, 54);
            this.btnRatitoCaliDataSave.Name = "btnRatitoCaliDataSave";
            this.btnRatitoCaliDataSave.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnRatitoCaliDataSave.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRatitoCaliDataSave.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRatitoCaliDataSave.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnRatitoCaliDataSave.Size = new System.Drawing.Size(152, 31);
            this.btnRatitoCaliDataSave.Style = UIDesign.UIStyle.LightOrange;
            this.btnRatitoCaliDataSave.TabIndex = 10;
            this.btnRatitoCaliDataSave.Text = "参数保存";
            this.btnRatitoCaliDataSave.Click += new System.EventHandler(this.btnRatitoCaliDataSave_Click);
            // 
            // txbCurrRorateCenterY
            // 
            this.txbCurrRorateCenterY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbCurrRorateCenterY.FillColor = System.Drawing.Color.White;
            this.txbCurrRorateCenterY.Font = new System.Drawing.Font("宋体", 9F);
            this.txbCurrRorateCenterY.Location = new System.Drawing.Point(262, 57);
            this.txbCurrRorateCenterY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbCurrRorateCenterY.Maximum = 2147483647D;
            this.txbCurrRorateCenterY.Minimum = -2147483648D;
            this.txbCurrRorateCenterY.Name = "txbCurrRorateCenterY";
            this.txbCurrRorateCenterY.Padding = new System.Windows.Forms.Padding(5);
            this.txbCurrRorateCenterY.ReadOnly = true;
            this.txbCurrRorateCenterY.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbCurrRorateCenterY.Size = new System.Drawing.Size(103, 25);
            this.txbCurrRorateCenterY.Style = UIDesign.UIStyle.LightOrange;
            this.txbCurrRorateCenterY.TabIndex = 5;
            this.txbCurrRorateCenterY.Text = "0";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(226, 19);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(30, 15);
            this.label35.TabIndex = 29;
            this.label35.Text = "X：";
            // 
            // btnCaculateRorateCenter
            // 
            this.btnCaculateRorateCenter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaculateRorateCenter.FillColor = System.Drawing.Color.White;
            this.btnCaculateRorateCenter.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCaculateRorateCenter.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCaculateRorateCenter.Font = new System.Drawing.Font("宋体", 9F);
            this.btnCaculateRorateCenter.ForeColor = System.Drawing.Color.Black;
            this.btnCaculateRorateCenter.Location = new System.Drawing.Point(28, 12);
            this.btnCaculateRorateCenter.Name = "btnCaculateRorateCenter";
            this.btnCaculateRorateCenter.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnCaculateRorateCenter.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCaculateRorateCenter.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCaculateRorateCenter.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnCaculateRorateCenter.Size = new System.Drawing.Size(152, 31);
            this.btnCaculateRorateCenter.Style = UIDesign.UIStyle.LightOrange;
            this.btnCaculateRorateCenter.TabIndex = 9;
            this.btnCaculateRorateCenter.Text = "计算旋转中心";
            this.btnCaculateRorateCenter.TipsText = "计算后的坐标为实际的物理坐标";
            this.btnCaculateRorateCenter.Click += new System.EventHandler(this.btnCaculateRorateCenter_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(226, 62);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(30, 15);
            this.label34.TabIndex = 31;
            this.label34.Text = "Y：";
            // 
            // txbCurrRorateCenterX
            // 
            this.txbCurrRorateCenterX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbCurrRorateCenterX.FillColor = System.Drawing.Color.White;
            this.txbCurrRorateCenterX.Font = new System.Drawing.Font("宋体", 9F);
            this.txbCurrRorateCenterX.Location = new System.Drawing.Point(262, 15);
            this.txbCurrRorateCenterX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbCurrRorateCenterX.Maximum = 2147483647D;
            this.txbCurrRorateCenterX.Minimum = -2147483648D;
            this.txbCurrRorateCenterX.Name = "txbCurrRorateCenterX";
            this.txbCurrRorateCenterX.Padding = new System.Windows.Forms.Padding(5);
            this.txbCurrRorateCenterX.ReadOnly = true;
            this.txbCurrRorateCenterX.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbCurrRorateCenterX.Size = new System.Drawing.Size(103, 25);
            this.txbCurrRorateCenterX.Style = UIDesign.UIStyle.LightOrange;
            this.txbCurrRorateCenterX.TabIndex = 4;
            this.txbCurrRorateCenterX.Text = "0";
            // 
            // RotateOfPixelDatBox
            // 
            this.RotateOfPixelDatBox.Controls.Add(this.RoratepointListview);
            this.RotateOfPixelDatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RotateOfPixelDatBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RotateOfPixelDatBox.Font = new System.Drawing.Font("宋体", 9F);
            this.RotateOfPixelDatBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.RotateOfPixelDatBox.Location = new System.Drawing.Point(4, 255);
            this.RotateOfPixelDatBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RotateOfPixelDatBox.Name = "RotateOfPixelDatBox";
            this.RotateOfPixelDatBox.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.RotateOfPixelDatBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.RotateOfPixelDatBox.Size = new System.Drawing.Size(386, 382);
            this.RotateOfPixelDatBox.Style = UIDesign.UIStyle.LightOrange;
            this.RotateOfPixelDatBox.TabIndex = 27;
            this.RotateOfPixelDatBox.Text = "像素坐标";
            this.RotateOfPixelDatBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.RotateOfPixelDatBox.TitleColor = System.Drawing.Color.Silver;
            this.RotateOfPixelDatBox.TitleHeight = 20;
            // 
            // RoratepointListview
            // 
            this.RoratepointListview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.RoratepointListview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RoratepointListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25});
            this.RoratepointListview.ContextMenuStrip = this.contextMenuStrip3;
            this.RoratepointListview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoratepointListview.GridLines = true;
            this.RoratepointListview.HeaderBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.RoratepointListview.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.RoratepointListview.HideSelection = false;
            this.RoratepointListview.Location = new System.Drawing.Point(0, 20);
            this.RoratepointListview.Name = "RoratepointListview";
            this.RoratepointListview.RowBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.RoratepointListview.RowBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.RoratepointListview.SelectedBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.RoratepointListview.SelectedEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(225)))), ((int)(((byte)(253)))));
            this.RoratepointListview.Size = new System.Drawing.Size(386, 362);
            this.RoratepointListview.TabIndex = 3;
            this.RoratepointListview.UseCompatibleStateImageBehavior = false;
            this.RoratepointListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "ID";
            this.columnHeader23.Width = 30;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "X";
            this.columnHeader24.Width = 140;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Y";
            this.columnHeader25.Width = 140;
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除ToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(109, 28);
            // 
            // 清除ToolStripMenuItem
            // 
            this.清除ToolStripMenuItem.Name = "清除ToolStripMenuItem";
            this.清除ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.清除ToolStripMenuItem.Text = "清除";
            this.清除ToolStripMenuItem.Click += new System.EventHandler(this.清除ToolStripMenuItem_Click);
            // 
            // RotatePixelGetBox
            // 
            this.RotatePixelGetBox.Controls.Add(this.btnModifyRotataPixel);
            this.RotatePixelGetBox.Controls.Add(this.uiTitlePanel3);
            this.RotatePixelGetBox.Controls.Add(this.btnGetRotataPixel);
            this.RotatePixelGetBox.Controls.Add(this.btnDeleteRotataPixel);
            this.RotatePixelGetBox.Controls.Add(this.btnSaveRotataPixel);
            this.RotatePixelGetBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RotatePixelGetBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RotatePixelGetBox.Font = new System.Drawing.Font("宋体", 9F);
            this.RotatePixelGetBox.Location = new System.Drawing.Point(4, 5);
            this.RotatePixelGetBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RotatePixelGetBox.Name = "RotatePixelGetBox";
            this.RotatePixelGetBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.RotatePixelGetBox.Size = new System.Drawing.Size(386, 140);
            this.RotatePixelGetBox.Style = UIDesign.UIStyle.LightOrange;
            this.RotatePixelGetBox.TabIndex = 7;
            this.RotatePixelGetBox.Text = null;
            // 
            // btnModifyRotataPixel
            // 
            this.btnModifyRotataPixel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModifyRotataPixel.FillColor = System.Drawing.Color.White;
            this.btnModifyRotataPixel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyRotataPixel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyRotataPixel.Font = new System.Drawing.Font("宋体", 9F);
            this.btnModifyRotataPixel.ForeColor = System.Drawing.Color.Black;
            this.btnModifyRotataPixel.Location = new System.Drawing.Point(220, 107);
            this.btnModifyRotataPixel.Name = "btnModifyRotataPixel";
            this.btnModifyRotataPixel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnModifyRotataPixel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyRotataPixel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyRotataPixel.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnModifyRotataPixel.Size = new System.Drawing.Size(152, 27);
            this.btnModifyRotataPixel.Style = UIDesign.UIStyle.LightOrange;
            this.btnModifyRotataPixel.TabIndex = 8;
            this.btnModifyRotataPixel.Text = "Mark点修改";
            this.btnModifyRotataPixel.Click += new System.EventHandler(this.btnModifyRotataPixel_Click);
            // 
            // uiTitlePanel3
            // 
            this.uiTitlePanel3.Controls.Add(this.txbRotataPixelY);
            this.uiTitlePanel3.Controls.Add(this.label32);
            this.uiTitlePanel3.Controls.Add(this.label33);
            this.uiTitlePanel3.Controls.Add(this.txbRotataPixelX);
            this.uiTitlePanel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiTitlePanel3.Font = new System.Drawing.Font("宋体", 9F);
            this.uiTitlePanel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.uiTitlePanel3.Location = new System.Drawing.Point(13, 8);
            this.uiTitlePanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel3.Name = "uiTitlePanel3";
            this.uiTitlePanel3.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.uiTitlePanel3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.uiTitlePanel3.Size = new System.Drawing.Size(176, 126);
            this.uiTitlePanel3.Style = UIDesign.UIStyle.LightOrange;
            this.uiTitlePanel3.TabIndex = 1;
            this.uiTitlePanel3.Text = "像素坐标";
            this.uiTitlePanel3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel3.TitleColor = System.Drawing.Color.Silver;
            this.uiTitlePanel3.TitleHeight = 20;
            // 
            // txbRotataPixelY
            // 
            this.txbRotataPixelY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbRotataPixelY.FillColor = System.Drawing.Color.White;
            this.txbRotataPixelY.Font = new System.Drawing.Font("宋体", 9F);
            this.txbRotataPixelY.Location = new System.Drawing.Point(62, 82);
            this.txbRotataPixelY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbRotataPixelY.Maximum = 2147483647D;
            this.txbRotataPixelY.Minimum = -2147483648D;
            this.txbRotataPixelY.Name = "txbRotataPixelY";
            this.txbRotataPixelY.Padding = new System.Windows.Forms.Padding(5);
            this.txbRotataPixelY.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbRotataPixelY.Size = new System.Drawing.Size(77, 25);
            this.txbRotataPixelY.Style = UIDesign.UIStyle.LightOrange;
            this.txbRotataPixelY.TabIndex = 4;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(36, 44);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(23, 15);
            this.label32.TabIndex = 22;
            this.label32.Text = "X:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(36, 87);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(23, 15);
            this.label33.TabIndex = 24;
            this.label33.Text = "Y:";
            // 
            // txbRotataPixelX
            // 
            this.txbRotataPixelX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbRotataPixelX.FillColor = System.Drawing.Color.White;
            this.txbRotataPixelX.Font = new System.Drawing.Font("宋体", 9F);
            this.txbRotataPixelX.Location = new System.Drawing.Point(62, 39);
            this.txbRotataPixelX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbRotataPixelX.Maximum = 2147483647D;
            this.txbRotataPixelX.Minimum = -2147483648D;
            this.txbRotataPixelX.Name = "txbRotataPixelX";
            this.txbRotataPixelX.Padding = new System.Windows.Forms.Padding(5);
            this.txbRotataPixelX.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.txbRotataPixelX.Size = new System.Drawing.Size(77, 25);
            this.txbRotataPixelX.Style = UIDesign.UIStyle.LightOrange;
            this.txbRotataPixelX.TabIndex = 3;
            // 
            // btnGetRotataPixel
            // 
            this.btnGetRotataPixel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetRotataPixel.FillColor = System.Drawing.Color.White;
            this.btnGetRotataPixel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetRotataPixel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetRotataPixel.Font = new System.Drawing.Font("宋体", 9F);
            this.btnGetRotataPixel.ForeColor = System.Drawing.Color.Black;
            this.btnGetRotataPixel.Location = new System.Drawing.Point(220, 8);
            this.btnGetRotataPixel.Name = "btnGetRotataPixel";
            this.btnGetRotataPixel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnGetRotataPixel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetRotataPixel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetRotataPixel.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnGetRotataPixel.Size = new System.Drawing.Size(152, 27);
            this.btnGetRotataPixel.Style = UIDesign.UIStyle.LightOrange;
            this.btnGetRotataPixel.TabIndex = 5;
            this.btnGetRotataPixel.Text = "Mark点获取";
            this.btnGetRotataPixel.Click += new System.EventHandler(this.btnGetRotataPixel_Click);
            // 
            // btnDeleteRotataPixel
            // 
            this.btnDeleteRotataPixel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteRotataPixel.FillColor = System.Drawing.Color.White;
            this.btnDeleteRotataPixel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeleteRotataPixel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeleteRotataPixel.Font = new System.Drawing.Font("宋体", 9F);
            this.btnDeleteRotataPixel.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteRotataPixel.Location = new System.Drawing.Point(220, 74);
            this.btnDeleteRotataPixel.Name = "btnDeleteRotataPixel";
            this.btnDeleteRotataPixel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnDeleteRotataPixel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeleteRotataPixel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeleteRotataPixel.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnDeleteRotataPixel.Size = new System.Drawing.Size(152, 27);
            this.btnDeleteRotataPixel.Style = UIDesign.UIStyle.LightOrange;
            this.btnDeleteRotataPixel.TabIndex = 7;
            this.btnDeleteRotataPixel.Text = "Mark点删除";
            this.btnDeleteRotataPixel.Click += new System.EventHandler(this.btnDeleteRotataPixel_Click);
            // 
            // btnSaveRotataPixel
            // 
            this.btnSaveRotataPixel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveRotataPixel.FillColor = System.Drawing.Color.White;
            this.btnSaveRotataPixel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveRotataPixel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveRotataPixel.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSaveRotataPixel.ForeColor = System.Drawing.Color.Black;
            this.btnSaveRotataPixel.Location = new System.Drawing.Point(220, 41);
            this.btnSaveRotataPixel.Name = "btnSaveRotataPixel";
            this.btnSaveRotataPixel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.btnSaveRotataPixel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveRotataPixel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveRotataPixel.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.btnSaveRotataPixel.Size = new System.Drawing.Size(152, 27);
            this.btnSaveRotataPixel.Style = UIDesign.UIStyle.LightOrange;
            this.btnSaveRotataPixel.TabIndex = 6;
            this.btnSaveRotataPixel.Text = "Mark点新增";
            this.btnSaveRotataPixel.Click += new System.EventHandler(this.btnSaveRotataPixel_Click);
            // 
            // contextMenuStrip5
            // 
            this.contextMenuStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除ToolStripMenuItem2});
            this.contextMenuStrip5.Name = "contextMenuStrip5";
            this.contextMenuStrip5.Size = new System.Drawing.Size(109, 28);
            // 
            // 清除ToolStripMenuItem2
            // 
            this.清除ToolStripMenuItem2.Name = "清除ToolStripMenuItem2";
            this.清除ToolStripMenuItem2.Size = new System.Drawing.Size(108, 24);
            this.清除ToolStripMenuItem2.Text = "清除";
            // 
            // picConvertRobotToPixel
            // 
            this.picConvertRobotToPixel.BackColor = System.Drawing.Color.White;
            this.picConvertRobotToPixel.Image = ((System.Drawing.Image)(resources.GetObject("picConvertRobotToPixel.Image")));
            this.picConvertRobotToPixel.Location = new System.Drawing.Point(158, 86);
            this.picConvertRobotToPixel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picConvertRobotToPixel.Name = "picConvertRobotToPixel";
            this.picConvertRobotToPixel.Size = new System.Drawing.Size(56, 34);
            this.picConvertRobotToPixel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picConvertRobotToPixel.TabIndex = 1;
            this.picConvertRobotToPixel.TabStop = false;
            this.toolTip1.SetToolTip(this.picConvertRobotToPixel, " this.Transformation_POINT_INV");
            this.picConvertRobotToPixel.Click += new System.EventHandler(this.picConvertRobotToPixel_Click);
            // 
            // picConvertPixelToRobot
            // 
            this.picConvertPixelToRobot.BackColor = System.Drawing.Color.White;
            this.picConvertPixelToRobot.Image = ((System.Drawing.Image)(resources.GetObject("picConvertPixelToRobot.Image")));
            this.picConvertPixelToRobot.Location = new System.Drawing.Point(159, 43);
            this.picConvertPixelToRobot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picConvertPixelToRobot.Name = "picConvertPixelToRobot";
            this.picConvertPixelToRobot.Size = new System.Drawing.Size(55, 34);
            this.picConvertPixelToRobot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picConvertPixelToRobot.TabIndex = 0;
            this.picConvertPixelToRobot.TabStop = false;
            this.toolTip1.SetToolTip(this.picConvertPixelToRobot, "this.Transformation_POINT");
            this.picConvertPixelToRobot.Click += new System.EventHandler(this.picConvertPixelToRobot_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tag = "客户端定时刷新";
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.uiTabControl1);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(682, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.uiPanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.uiPanel1.Size = new System.Drawing.Size(400, 672);
            this.uiPanel1.Style = UIDesign.UIStyle.LightOrange;
            this.uiPanel1.TabIndex = 6;
            this.uiPanel1.Text = "uiPanel1";
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.相机设置);
            this.uiTabControl1.Controls.Add(this.定位检测);
            this.uiTabControl1.Controls.Add(this.像素坐标);
            this.uiTabControl1.Controls.Add(this.物理坐标);
            this.uiTabControl1.Controls.Add(this.坐标变换);
            this.uiTabControl1.Controls.Add(this.旋转中心);
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiTabControl1.Font = new System.Drawing.Font("宋体", 9F);
            this.uiTabControl1.ItemSize = new System.Drawing.Size(80, 24);
            this.uiTabControl1.Location = new System.Drawing.Point(3, 3);
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(394, 666);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.Style = UIDesign.UIStyle.LightOrange;
            this.uiTabControl1.TabIndex = 0;
            this.uiTabControl1.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.uiTabControl1.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            // 
            // 相机设置
            // 
            this.相机设置.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.相机设置.Controls.Add(this.LogShowBox);
            this.相机设置.Controls.Add(this.uiPanel6);
            this.相机设置.Controls.Add(this.CamParmasSetBox);
            this.相机设置.Controls.Add(this.CamTypeSetBox);
            this.相机设置.Location = new System.Drawing.Point(0, 24);
            this.相机设置.Name = "相机设置";
            this.相机设置.Size = new System.Drawing.Size(394, 642);
            this.相机设置.TabIndex = 0;
            this.相机设置.Text = "相机设置";
            // 
            // LogShowBox
            // 
            this.LogShowBox.BackColor = System.Drawing.SystemColors.Control;
            this.LogShowBox.Controls.Add(this.richTxb);
            this.LogShowBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogShowBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LogShowBox.Font = new System.Drawing.Font("宋体", 9F);
            this.LogShowBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.LogShowBox.Location = new System.Drawing.Point(0, 365);
            this.LogShowBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogShowBox.Name = "LogShowBox";
            this.LogShowBox.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.LogShowBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.LogShowBox.Size = new System.Drawing.Size(394, 277);
            this.LogShowBox.Style = UIDesign.UIStyle.LightOrange;
            this.LogShowBox.TabIndex = 6;
            this.LogShowBox.Text = "测试信息";
            this.LogShowBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.LogShowBox.TitleColor = System.Drawing.Color.Silver;
            this.LogShowBox.TitleHeight = 20;
            // 
            // uiPanel6
            // 
            this.uiPanel6.Controls.Add(this.ImageGrabToolBox);
            this.uiPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiPanel6.Font = new System.Drawing.Font("宋体", 9F);
            this.uiPanel6.Location = new System.Drawing.Point(0, 236);
            this.uiPanel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel6.Name = "uiPanel6";
            this.uiPanel6.Padding = new System.Windows.Forms.Padding(2);
            this.uiPanel6.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.uiPanel6.Size = new System.Drawing.Size(394, 129);
            this.uiPanel6.Style = UIDesign.UIStyle.LightOrange;
            this.uiPanel6.TabIndex = 7;
            this.uiPanel6.Text = null;
            // 
            // ImageGrabToolBox
            // 
            this.ImageGrabToolBox.BackColor = System.Drawing.SystemColors.Control;
            this.ImageGrabToolBox.Controls.Add(this.btnStopGrab);
            this.ImageGrabToolBox.Controls.Add(this.btnContinueGrab);
            this.ImageGrabToolBox.Controls.Add(this.btnSaveCamParm);
            this.ImageGrabToolBox.Controls.Add(this.btnOneShot);
            this.ImageGrabToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageGrabToolBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ImageGrabToolBox.Font = new System.Drawing.Font("宋体", 9F);
            this.ImageGrabToolBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.ImageGrabToolBox.Location = new System.Drawing.Point(2, 2);
            this.ImageGrabToolBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImageGrabToolBox.Name = "ImageGrabToolBox";
            this.ImageGrabToolBox.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.ImageGrabToolBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.ImageGrabToolBox.Size = new System.Drawing.Size(390, 125);
            this.ImageGrabToolBox.Style = UIDesign.UIStyle.LightOrange;
            this.ImageGrabToolBox.TabIndex = 5;
            this.ImageGrabToolBox.Text = "图像采集";
            this.ImageGrabToolBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ImageGrabToolBox.TitleColor = System.Drawing.Color.Silver;
            this.ImageGrabToolBox.TitleHeight = 20;
            // 
            // CamParmasSetBox
            // 
            this.CamParmasSetBox.BackColor = System.Drawing.SystemColors.Control;
            this.CamParmasSetBox.Controls.Add(this.numCamGain);
            this.CamParmasSetBox.Controls.Add(this.numCamExposure);
            this.CamParmasSetBox.Controls.Add(this.CamGainBar);
            this.CamParmasSetBox.Controls.Add(this.label63);
            this.CamParmasSetBox.Controls.Add(this.label64);
            this.CamParmasSetBox.Controls.Add(this.CamExposureBar);
            this.CamParmasSetBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.CamParmasSetBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CamParmasSetBox.Font = new System.Drawing.Font("宋体", 9F);
            this.CamParmasSetBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.CamParmasSetBox.Location = new System.Drawing.Point(0, 118);
            this.CamParmasSetBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CamParmasSetBox.Name = "CamParmasSetBox";
            this.CamParmasSetBox.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.CamParmasSetBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.CamParmasSetBox.Size = new System.Drawing.Size(394, 118);
            this.CamParmasSetBox.Style = UIDesign.UIStyle.LightOrange;
            this.CamParmasSetBox.TabIndex = 4;
            this.CamParmasSetBox.Text = "相机参数";
            this.CamParmasSetBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CamParmasSetBox.TitleColor = System.Drawing.Color.Silver;
            this.CamParmasSetBox.TitleHeight = 20;
            // 
            // numCamGain
            // 
            this.numCamGain.Font = new System.Drawing.Font("宋体", 9F);
            this.numCamGain.Location = new System.Drawing.Point(269, 76);
            this.numCamGain.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCamGain.Name = "numCamGain";
            this.numCamGain.Size = new System.Drawing.Size(100, 25);
            this.numCamGain.TabIndex = 1;
            this.numCamGain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbCamGain_KeyDown);
            // 
            // numCamExposure
            // 
            this.numCamExposure.Font = new System.Drawing.Font("宋体", 9F);
            this.numCamExposure.Location = new System.Drawing.Point(269, 34);
            this.numCamExposure.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numCamExposure.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCamExposure.Name = "numCamExposure";
            this.numCamExposure.Size = new System.Drawing.Size(100, 25);
            this.numCamExposure.TabIndex = 0;
            this.numCamExposure.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCamExposure.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbCamExposure_KeyDown);
            // 
            // CamTypeSetBox
            // 
            this.CamTypeSetBox.BackColor = System.Drawing.SystemColors.Control;
            this.CamTypeSetBox.Controls.Add(this.btnCloseCam);
            this.CamTypeSetBox.Controls.Add(this.cobxCamIndex);
            this.CamTypeSetBox.Controls.Add(this.label62);
            this.CamTypeSetBox.Controls.Add(this.btnOpenCam);
            this.CamTypeSetBox.Controls.Add(this.label65);
            this.CamTypeSetBox.Controls.Add(this.cobxCamType);
            this.CamTypeSetBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.CamTypeSetBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CamTypeSetBox.Font = new System.Drawing.Font("宋体", 9F);
            this.CamTypeSetBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.CamTypeSetBox.Location = new System.Drawing.Point(0, 0);
            this.CamTypeSetBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CamTypeSetBox.Name = "CamTypeSetBox";
            this.CamTypeSetBox.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.CamTypeSetBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.CamTypeSetBox.Size = new System.Drawing.Size(394, 118);
            this.CamTypeSetBox.Style = UIDesign.UIStyle.LightOrange;
            this.CamTypeSetBox.TabIndex = 3;
            this.CamTypeSetBox.Text = "相机选择";
            this.CamTypeSetBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CamTypeSetBox.TitleColor = System.Drawing.Color.Silver;
            this.CamTypeSetBox.TitleHeight = 20;
            // 
            // 定位检测
            // 
            this.定位检测.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.定位检测.Controls.Add(this.LocationDectionSetBox);
            this.定位检测.Location = new System.Drawing.Point(0, 24);
            this.定位检测.Name = "定位检测";
            this.定位检测.Size = new System.Drawing.Size(394, 642);
            this.定位检测.TabIndex = 2;
            this.定位检测.Text = "定位检测";
            // 
            // 像素坐标
            // 
            this.像素坐标.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.像素坐标.Controls.Add(this.tableLayoutPanel2);
            this.像素坐标.Location = new System.Drawing.Point(0, 24);
            this.像素坐标.Name = "像素坐标";
            this.像素坐标.Size = new System.Drawing.Size(394, 642);
            this.像素坐标.TabIndex = 3;
            this.像素坐标.Text = "像素坐标";
            // 
            // 物理坐标
            // 
            this.物理坐标.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.物理坐标.Controls.Add(this.tableLayoutPanel3);
            this.物理坐标.Location = new System.Drawing.Point(0, 24);
            this.物理坐标.Name = "物理坐标";
            this.物理坐标.Size = new System.Drawing.Size(394, 642);
            this.物理坐标.TabIndex = 4;
            this.物理坐标.Text = "物理坐标";
            // 
            // 坐标变换
            // 
            this.坐标变换.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.坐标变换.Controls.Add(this.CoordinateTransBox);
            this.坐标变换.Location = new System.Drawing.Point(0, 24);
            this.坐标变换.Name = "坐标变换";
            this.坐标变换.Size = new System.Drawing.Size(394, 642);
            this.坐标变换.TabIndex = 5;
            this.坐标变换.Text = "坐标变换";
            // 
            // CoordinateTransBox
            // 
            this.CoordinateTransBox.Controls.Add(this.groupBox6);
            this.CoordinateTransBox.Controls.Add(this.groupBox17);
            this.CoordinateTransBox.Controls.Add(this.tableLayoutPanel4);
            this.CoordinateTransBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoordinateTransBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CoordinateTransBox.Font = new System.Drawing.Font("宋体", 9F);
            this.CoordinateTransBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(51)))));
            this.CoordinateTransBox.Location = new System.Drawing.Point(0, 0);
            this.CoordinateTransBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CoordinateTransBox.Name = "CoordinateTransBox";
            this.CoordinateTransBox.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.CoordinateTransBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.CoordinateTransBox.Size = new System.Drawing.Size(394, 642);
            this.CoordinateTransBox.Style = UIDesign.UIStyle.LightOrange;
            this.CoordinateTransBox.TabIndex = 0;
            this.CoordinateTransBox.Text = "坐标系转换";
            this.CoordinateTransBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CoordinateTransBox.TitleColor = System.Drawing.Color.Silver;
            this.CoordinateTransBox.TitleHeight = 20;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.uiPanel4);
            this.groupBox6.Controls.Add(this.uiPanel3);
            this.groupBox6.Controls.Add(this.picConvertRobotToPixel);
            this.groupBox6.Controls.Add(this.picConvertPixelToRobot);
            this.groupBox6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox6.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox6.Location = new System.Drawing.Point(11, 166);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.groupBox6.Size = new System.Drawing.Size(372, 154);
            this.groupBox6.Style = UIDesign.UIStyle.LightOrange;
            this.groupBox6.TabIndex = 28;
            this.groupBox6.Text = null;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.chxbAutoCoorSys);
            this.groupBox17.Controls.Add(this.btnSaveParma);
            this.groupBox17.Controls.Add(this.btnConvert);
            this.groupBox17.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox17.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox17.Location = new System.Drawing.Point(11, 329);
            this.groupBox17.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.groupBox17.Size = new System.Drawing.Size(372, 111);
            this.groupBox17.Style = UIDesign.UIStyle.LightOrange;
            this.groupBox17.TabIndex = 29;
            this.groupBox17.Text = null;
            // 
            // 旋转中心
            // 
            this.旋转中心.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.旋转中心.Controls.Add(this.tableLayoutPanel1);
            this.旋转中心.Location = new System.Drawing.Point(0, 24);
            this.旋转中心.Name = "旋转中心";
            this.旋转中心.Size = new System.Drawing.Size(394, 642);
            this.旋转中心.TabIndex = 6;
            this.旋转中心.Text = "旋转中心";
            // 
            // uiPanel2
            // 
            this.uiPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel2.Location = new System.Drawing.Point(0, 0);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.uiPanel2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.uiPanel2.Size = new System.Drawing.Size(682, 672);
            this.uiPanel2.Style = UIDesign.UIStyle.LightOrange;
            this.uiPanel2.TabIndex = 7;
            this.uiPanel2.Text = "uiPanel2";
            // 
            // frmCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1082, 672);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCalibration";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCalibration3_FormClosing);
            this.Load += new System.EventHandler(this.frmCalibration3_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip4.ResumeLayout(false);
            this.LocationDectionSetBox.ResumeLayout(false);
            this.LocationDectionSetBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.CircleMatchPanel.ResumeLayout(false);
            this.CircleMatchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumParam1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberMinRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberMaxRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumParam2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinDist)).EndInit();
            this.BlobCentrePanel.ResumeLayout(false);
            this.BlobCentrePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumareaHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumareaLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Numminthd)).EndInit();
            this.FindCirclePanel.ResumeLayout(false);
            this.FindCirclePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NummaxRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumEdgeThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumminRadius)).EndInit();
            this.LinesIntersectPanel.ResumeLayout(false);
            this.LinesIntersectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumcanThdup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumcanThdup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxLineGap2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinLineLenght2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumThresholdP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxLineGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumcanThddown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumcanThddown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinLineLenght)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumThresholdP)).EndInit();
            this.ModelMactPanel.ResumeLayout(false);
            this.ModelMactPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMinContourArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxContourArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMincoutourLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxcoutourLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSegthreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMatchValue)).EndInit();
            this.panel16.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.NinePointsOfPixelDatBox.ResumeLayout(false);
            this.NinePointsOfPixelGetBox.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.NinePointsOfRobotGetBox.ResumeLayout(false);
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTitlePanel1.PerformLayout();
            this.NinePointsOfRobotDatBox.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.uiPanel4.ResumeLayout(false);
            this.uiPanel4.PerformLayout();
            this.uiPanel3.ResumeLayout(false);
            this.uiPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.RotateCalBox.ResumeLayout(false);
            this.RotateCalBox.PerformLayout();
            this.RotateOfPixelDatBox.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.RotatePixelGetBox.ResumeLayout(false);
            this.uiTitlePanel3.ResumeLayout(false);
            this.uiTitlePanel3.PerformLayout();
            this.contextMenuStrip5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picConvertRobotToPixel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConvertPixelToRobot)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            this.uiTabControl1.ResumeLayout(false);
            this.相机设置.ResumeLayout(false);
            this.LogShowBox.ResumeLayout(false);
            this.uiPanel6.ResumeLayout(false);
            this.ImageGrabToolBox.ResumeLayout(false);
            this.CamParmasSetBox.ResumeLayout(false);
            this.CamParmasSetBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCamGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCamExposure)).EndInit();
            this.CamTypeSetBox.ResumeLayout(false);
            this.CamTypeSetBox.PerformLayout();
            this.定位检测.ResumeLayout(false);
            this.像素坐标.ResumeLayout(false);
            this.物理坐标.ResumeLayout(false);
            this.坐标变换.ResumeLayout(false);
            this.CoordinateTransBox.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.旋转中心.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbTy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbTx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbTheta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbPhi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbSy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbSx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem 清除ToolStripMenuItem;
        private System.Windows.Forms.Panel LocationDectionSetBox;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox picConvertPixelToRobot;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.PictureBox picConvertRobotToPixel;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label65;
        private UIDesign.UITrackBar CamExposureBar;
        private UIDesign.UITrackBar CamGainBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
        private System.Windows.Forms.ToolStripMenuItem 清除ToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip5;
        private System.Windows.Forms.ToolStripMenuItem 清除ToolStripMenuItem2;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private UIDesign.UILine uiLine2;
        private UIDesign.UILine uiLine3;
        private UIDesign.UIRichTextBox richTxb;
        private UIDesign.UIComboBox cobxCamIndex;
        private UIDesign.UIComboBox cobxCamType;
        private UIDesign.UIButton btnOpenCam;
        private UIDesign.UIButton btnCloseCam;
        private UIDesign.UIButton btnStopGrab;
        private UIDesign.UIButton btnSaveCamParm;
        private UIDesign.UIButton btnOneShot;
        private UIDesign.UIButton btnContinueGrab;
        private UIDesign.UIButton btnSaveModelParmas;
        private UIDesign.UIButton btnRunTool;
        private UIDesign.UIButton btnRunFlow;
        private UIDesign.UIButton btnCoordiRecipe;
        private UIDesign.UIButton btnTest_modelMatch;
        private UIDesign.UIButton btnSaveModel;
        private UIDesign.UIButton btncreateModel;
        private UIDesign.UIButton btnSendDataToControl;
        private UIDesign.UIButton btnGetLine2;
        private UIDesign.UIButton btnLntersectLine;
        private UIDesign.UIComboBox cobxModelType;
        private UIDesign.UIButton btnGetLine1;
        private UIDesign.UIButton btnGetCircle;
        private UIDesign.UICheckBox chxbBlobCentre;
        private UIDesign.UIButton btnGetBlobArea;
        private UIDesign.UICheckBox chxbLinesIntersect;
        private UIDesign.UICheckBox chxbFindCircle;
        private UIDesign.UIButton btnModifyPixelPoint;
        private UIDesign.UIButton btnDeletePixelPoint;
        private UIDesign.UIButton btnNewPixelPoint;
        private UIDesign.UIButton btnGetPixelPoint;
        private UIDesign.UITextBox txbpixelY;
        private UIDesign.UITextBox txbpixelX;
        private UIDesign.UITextBox txbMarkPixelX;
        private UIDesign.UIButton btnConvert;
        private UIDesign.UITextBox txbrobotR;
        private UIDesign.UITextBox txbrobotY;
        private UIDesign.UITextBox txbrobotX;
        private UIDesign.UIButton btnModifyRobotPoint;
        private UIDesign.UIButton btnDeleteRobotPoint;
        private UIDesign.UIButton BtnNewRobotPoint;
        private UIDesign.UIButton btnGetRobotPoint;
        private UIDesign.UIButton btnGetRotataPixel;
        private UIDesign.UIButton btnSaveParma;
        private UIDesign.UITextBox txbRotataPixelX;
        private UIDesign.UITextBox txbMarkRobotY;
        private UIDesign.UITextBox txbMarkRobotX;
        private UIDesign.UITextBox txbMarkPixelY;
        private UIDesign.UITextBox txbRotataPixelY;
        private UIDesign.UITextBox txbCurrRorateCenterY;
        private UIDesign.UITextBox txbCurrRorateCenterX;
        private UIDesign.UIButton btnModifyRotataPixel;
        private UIDesign.UIButton btnDeleteRotataPixel;
        private UIDesign.UIButton btnSaveRotataPixel;
        private UIDesign.UIButton btnRatitoCaliDataSave;
        private UIDesign.UIButton btnCaculateRorateCenter;
        private UIDesign.UICheckBox chxbAutoCoorSys;
        private UIDesign.UIPanel uiPanel1;
        private UIDesign.UIPanel uiPanel2;
        private UIDesign.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage 相机设置;
        private System.Windows.Forms.TabPage 定位检测;
        private System.Windows.Forms.TabPage 像素坐标;
        private System.Windows.Forms.TabPage 物理坐标;
        private System.Windows.Forms.TabPage 坐标变换;
        private System.Windows.Forms.TabPage 旋转中心;
        private UIDesign.UIPanel uiPanel4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private UIDesign.UIPanel uiPanel3;
        private UIDesign.UIPanel panel16;
        private UIDesign.UIPanel ModelMactPanel;
        private UIDesign.UIPanel BlobCentrePanel;
        private UIDesign.UIPanel FindCirclePanel;
        private UIDesign.UIPanel LinesIntersectPanel;
        private UIDesign.UITitlePanel CamTypeSetBox;
        private UIDesign.UITitlePanel LogShowBox;
        private UIDesign.UITitlePanel ImageGrabToolBox;
        private UIDesign.UITitlePanel CamParmasSetBox;
        private UIDesign.UITitlePanel NinePointsOfPixelDatBox;
        private UIDesign.UIPanel NinePointsOfPixelGetBox;
        private UIDesign.UITitlePanel groupBox8;
        private UIDesign.UIPanel NinePointsOfRobotGetBox;
        private UIDesign.UITitlePanel uiTitlePanel1;
        private UIDesign.UITitlePanel NinePointsOfRobotDatBox;
        private UIDesign.UITitlePanel RotateOfPixelDatBox;
        private UIDesign.UIPanel RotatePixelGetBox;
        private UIDesign.UITitlePanel uiTitlePanel3;
        private UIDesign.UIPanel groupBox6;
        private UIDesign.UIPanel RotateCalBox;
        private UIDesign.UIPanel groupBox17;
        private UIDesign.UITitlePanel CoordinateTransBox;
        private UIDesign.UIPanel uiPanel6;
        private UIDesign.UICheckBox chxbModelMatch;
        private UIDesign.UIPanel CircleMatchPanel;
        private UIDesign.UICheckBox chxbAutoCircleMatch;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private UIDesign.UIButton btnTestAutoCircleMatch;
        private UCLib.NumericUpDownEx numCamGain;
        private UCLib.NumericUpDownEx numCamExposure;
        private UCLib.ListViewEx listViewPixel;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private UCLib.ListViewEx listViewRobot;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private UCLib.ListViewEx RoratepointListview;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private UCLib.NumericUpDownEx NumSegthreshold;
        private UCLib.ListViewEx listViewFlow;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private UCLib.NumericUpDownEx NumMatchValue;
        private UCLib.NumericUpDownEx numberMaxRadius;
        private UCLib.NumericUpDownEx numberMinRadius;
        private UCLib.NumericUpDownEx NumcanThddown;
        private UCLib.NumericUpDownEx NumMaxLineGap;
        private UCLib.NumericUpDownEx NumcanThddown2;
        private UCLib.NumericUpDownEx NumMinLineLenght;
        private UCLib.NumericUpDownEx NumThresholdP;
        private UCLib.NumericUpDownEx Numminthd;
        private UCLib.NumericUpDownEx NummaxRadius;
        private UCLib.NumericUpDownEx NumEdgeThreshold;
        private UCLib.NumericUpDownEx NumminRadius;
        private UCLib.NumericUpDownEx NumcanThdup;
        private System.Windows.Forms.Label label13;
        private UCLib.NumericUpDownEx NumcanThdup2;
        private System.Windows.Forms.Label label18;
        private UCLib.NumericUpDownEx NumMaxLineGap2;
        private UCLib.NumericUpDownEx NumMinLineLenght2;
        private UCLib.NumericUpDownEx NumThresholdP2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label15;
        private UCLib.NumericUpDownEx NumareaHigh;
        private System.Windows.Forms.Label label16;
        private UCLib.NumericUpDownEx NumareaLow;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txbXRms;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox txbYRms;
        private UCLib.NumericUpDownEx NumParam1;
        private System.Windows.Forms.Label label54;
        private UCLib.PictureBoxEx picTemplate;
        private UCLib.NumericUpDownEx NumMinContourArea;
        private UCLib.NumericUpDownEx NumMaxContourArea;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private UCLib.NumericUpDownEx NumMincoutourLen;
        private UCLib.NumericUpDownEx NumMaxcoutourLen;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private UCLib.ListViewEx lIstModelInfo;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private UCLib.NumericUpDownEx NumParam2;
        private UCLib.NumericUpDownEx NumMinDist;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label27;
        private UCLib.ComboBoxEx cobxPolarity;
    }
}