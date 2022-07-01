
namespace VisionShowLib
{
    partial class VisionShowControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisionShowControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.矩形toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.旋转矩形toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.圆toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.自适应toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.十字光标toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.加载图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存图片ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.清除overlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.PanelBox = new UCLib.PanelEx();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.扇形toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.PanelBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.矩形toolStripButton,
            this.toolStripSeparator1,
            this.旋转矩形toolStripButton,
            this.toolStripSeparator4,
            this.圆toolStripButton,
            this.toolStripSeparator2,
            this.扇形toolStripButton,
            this.toolStripSeparator5,
            this.自适应toolStripButton,
            this.toolStripSeparator3,
            this.十字光标toolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(691, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 矩形toolStripButton
            // 
            this.矩形toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.矩形toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("矩形toolStripButton.Image")));
            this.矩形toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.矩形toolStripButton.Name = "矩形toolStripButton";
            this.矩形toolStripButton.Size = new System.Drawing.Size(29, 24);
            this.矩形toolStripButton.Text = "矩形";
            this.矩形toolStripButton.Click += new System.EventHandler(this.btnDrawRectangle1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // 旋转矩形toolStripButton
            // 
            this.旋转矩形toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.旋转矩形toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("旋转矩形toolStripButton.Image")));
            this.旋转矩形toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.旋转矩形toolStripButton.Name = "旋转矩形toolStripButton";
            this.旋转矩形toolStripButton.Size = new System.Drawing.Size(29, 24);
            this.旋转矩形toolStripButton.Text = "旋转矩形";
            this.旋转矩形toolStripButton.Click += new System.EventHandler(this.旋转矩形toolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // 圆toolStripButton
            // 
            this.圆toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.圆toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("圆toolStripButton.Image")));
            this.圆toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.圆toolStripButton.Name = "圆toolStripButton";
            this.圆toolStripButton.Size = new System.Drawing.Size(29, 24);
            this.圆toolStripButton.Text = "圆";
            this.圆toolStripButton.Click += new System.EventHandler(this.btnDrawCircle_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // 自适应toolStripButton
            // 
            this.自适应toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.自适应toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("自适应toolStripButton.Image")));
            this.自适应toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.自适应toolStripButton.Name = "自适应toolStripButton";
            this.自适应toolStripButton.Size = new System.Drawing.Size(29, 24);
            this.自适应toolStripButton.Text = "自适应";
            this.自适应toolStripButton.Click += new System.EventHandler(this.自适应toolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // 十字光标toolStripButton
            // 
            this.十字光标toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.十字光标toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("十字光标toolStripButton.Image")));
            this.十字光标toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.十字光标toolStripButton.Name = "十字光标toolStripButton";
            this.十字光标toolStripButton.Size = new System.Drawing.Size(29, 24);
            this.十字光标toolStripButton.Text = "十字光标";
            this.十字光标toolStripButton.Click += new System.EventHandler(this.十字光标toolStripButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载图片ToolStripMenuItem,
            this.保存图片ToolStripMenuItem1,
            this.清除overlayToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 76);
            // 
            // 加载图片ToolStripMenuItem
            // 
            this.加载图片ToolStripMenuItem.Name = "加载图片ToolStripMenuItem";
            this.加载图片ToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.加载图片ToolStripMenuItem.Text = "加载图片";
            this.加载图片ToolStripMenuItem.Click += new System.EventHandler(this.加载图片ToolStripMenuItem_Click);
            // 
            // 保存图片ToolStripMenuItem1
            // 
            this.保存图片ToolStripMenuItem1.Name = "保存图片ToolStripMenuItem1";
            this.保存图片ToolStripMenuItem1.Size = new System.Drawing.Size(161, 24);
            this.保存图片ToolStripMenuItem1.Text = "保存图片";
            this.保存图片ToolStripMenuItem1.Click += new System.EventHandler(this.保存图片ToolStripMenuItem_Click);
            // 
            // 清除overlayToolStripMenuItem
            // 
            this.清除overlayToolStripMenuItem.Name = "清除overlayToolStripMenuItem";
            this.清除overlayToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.清除overlayToolStripMenuItem.Text = "清除overlay";
            this.清除overlayToolStripMenuItem.ToolTipText = "清除overlay";
            this.清除overlayToolStripMenuItem.Click += new System.EventHandler(this.清除overlayToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(109)))), ((int)(((byte)(60)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(691, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("宋体", 10.8F);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(159, 19);
            this.toolStripStatusLabel1.Text = "X:0|Y:0|C:0,0,0";
            // 
            // PanelBox
            // 
            this.PanelBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PanelBox.Controls.Add(this.PicBox);
            this.PanelBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBox.Font = new System.Drawing.Font("宋体", 9F);
            this.PanelBox.Location = new System.Drawing.Point(0, 27);
            this.PanelBox.Name = "PanelBox";
            this.PanelBox.Padding = new System.Windows.Forms.Padding(2);
            this.PanelBox.Size = new System.Drawing.Size(691, 437);
            this.PanelBox.TabIndex = 3;
            // 
            // PicBox
            // 
            this.PicBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PicBox.BackColor = System.Drawing.Color.White;
            this.PicBox.ContextMenuStrip = this.contextMenuStrip1;
            this.PicBox.Location = new System.Drawing.Point(106, 17);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(456, 398);
            this.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBox.TabIndex = 0;
            this.PicBox.TabStop = false;
            this.PicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PicBox_Paint);
            this.PicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseUp_1);
            // 
            // 扇形toolStripButton
            // 
            this.扇形toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.扇形toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("扇形toolStripButton.Image")));
            this.扇形toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.扇形toolStripButton.Name = "扇形toolStripButton";
            this.扇形toolStripButton.Size = new System.Drawing.Size(29, 24);
            this.扇形toolStripButton.Text = "扇形";
            this.扇形toolStripButton.Click += new System.EventHandler(this.扇形toolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // VisionShowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "VisionShowControl";
            this.Size = new System.Drawing.Size(691, 489);
            this.Load += new System.EventHandler(this.VisionShowControl_Load);
            this.SizeChanged += new System.EventHandler(this.VisionShowControl_SizeChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.PanelBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 矩形toolStripButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 加载图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存图片ToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private UCLib.PanelEx PanelBox;
        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton 圆toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton 自适应toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton 十字光标toolStripButton;
        private System.Windows.Forms.ToolStripMenuItem 清除overlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton 旋转矩形toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton 扇形toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}
