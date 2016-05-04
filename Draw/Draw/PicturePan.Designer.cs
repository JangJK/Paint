using System.Windows.Forms;
namespace Draw
{
    partial class PicturePan
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PicturePan));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu_Tool = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool_Pencil = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Line = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Color = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorChose = new System.Windows.Forms.ToolStripMenuItem();
            this.thickness = new System.Windows.Forms.ToolStripMenuItem();
            this.thicknessX1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Strip_Pencil = new System.Windows.Forms.ToolStripButton();
            this.Strip_Line = new System.Windows.Forms.ToolStripButton();
            this.Strip_Clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DrawPan = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.XYLabal = new System.Windows.Forms.ToolStripStatusLabel();
            this.chTxT = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.thicknessX2 = new System.Windows.Forms.ToolStripMenuItem();
            this.thicknessX3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new Draw.JKPictureBox();
            this.Nomal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.DrawPan.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Tool,
            this.Menu_Color,
            this.thickness});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(761, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu_Tool
            // 
            this.Menu_Tool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tool_Pencil,
            this.Menu_Line,
            this.Menu_Clear});
            this.Menu_Tool.Name = "Menu_Tool";
            this.Menu_Tool.Size = new System.Drawing.Size(43, 20);
            this.Menu_Tool.Text = "도구";
            // 
            // Tool_Pencil
            // 
            this.Tool_Pencil.Name = "Tool_Pencil";
            this.Tool_Pencil.Size = new System.Drawing.Size(110, 22);
            this.Tool_Pencil.Text = "연필";
            this.Tool_Pencil.Click += new System.EventHandler(this.Tool_Pencil_Click);
            // 
            // Menu_Line
            // 
            this.Menu_Line.Name = "Menu_Line";
            this.Menu_Line.Size = new System.Drawing.Size(110, 22);
            this.Menu_Line.Text = "직선";
            this.Menu_Line.Click += new System.EventHandler(this.Menu_Line_Click);
            // 
            // Menu_Clear
            // 
            this.Menu_Clear.Name = "Menu_Clear";
            this.Menu_Clear.Size = new System.Drawing.Size(110, 22);
            this.Menu_Clear.Text = "지우개";
            this.Menu_Clear.Click += new System.EventHandler(this.Menu_Clear_Click);
            // 
            // Menu_Color
            // 
            this.Menu_Color.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorChose});
            this.Menu_Color.Name = "Menu_Color";
            this.Menu_Color.Size = new System.Drawing.Size(43, 20);
            this.Menu_Color.Text = "색상";
            // 
            // ColorChose
            // 
            this.ColorChose.Name = "ColorChose";
            this.ColorChose.Size = new System.Drawing.Size(114, 22);
            this.ColorChose.Text = "펜 색상";
            this.ColorChose.Click += new System.EventHandler(this.ColorChose_Click);
            // 
            // thickness
            // 
            this.thickness.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thicknessX1,
            this.thicknessX2,
            this.thicknessX3,
            this.Nomal});
            this.thickness.Name = "thickness";
            this.thickness.Size = new System.Drawing.Size(59, 20);
            this.thickness.Text = "펜 굵기";
            // 
            // thicknessX1
            // 
            this.thicknessX1.Name = "thicknessX1";
            this.thicknessX1.Size = new System.Drawing.Size(152, 22);
            this.thicknessX1.Text = "x1";
            this.thicknessX1.Click += new System.EventHandler(this.thicknessX1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Strip_Pencil,
            this.Strip_Line,
            this.Strip_Clear,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(761, 24);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Strip_Pencil
            // 
            this.Strip_Pencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Strip_Pencil.Image = ((System.Drawing.Image)(resources.GetObject("Strip_Pencil.Image")));
            this.Strip_Pencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Strip_Pencil.Name = "Strip_Pencil";
            this.Strip_Pencil.Size = new System.Drawing.Size(23, 21);
            this.Strip_Pencil.Text = "연필";
            this.Strip_Pencil.Click += new System.EventHandler(this.Strip_Pencil_Click);
            // 
            // Strip_Line
            // 
            this.Strip_Line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Strip_Line.Image = ((System.Drawing.Image)(resources.GetObject("Strip_Line.Image")));
            this.Strip_Line.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Strip_Line.Name = "Strip_Line";
            this.Strip_Line.Size = new System.Drawing.Size(23, 21);
            this.Strip_Line.Text = "직선";
            this.Strip_Line.Click += new System.EventHandler(this.Strip_Line_Click);
            // 
            // Strip_Clear
            // 
            this.Strip_Clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Strip_Clear.Image = ((System.Drawing.Image)(resources.GetObject("Strip_Clear.Image")));
            this.Strip_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Strip_Clear.Name = "Strip_Clear";
            this.Strip_Clear.Size = new System.Drawing.Size(23, 21);
            this.Strip_Clear.Text = "지우개";
            this.Strip_Clear.Click += new System.EventHandler(this.Strip_Clear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
            // 
            // DrawPan
            // 
            this.DrawPan.AutoSize = true;
            this.DrawPan.BackColor = System.Drawing.SystemColors.Control;
            this.DrawPan.Controls.Add(this.pictureBox1);
            this.DrawPan.Location = new System.Drawing.Point(0, 48);
            this.DrawPan.Name = "DrawPan";
            this.DrawPan.Size = new System.Drawing.Size(767, 460);
            this.DrawPan.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XYLabal,
            this.chTxT});
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(761, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // XYLabal
            // 
            this.XYLabal.AutoSize = false;
            this.XYLabal.Name = "XYLabal";
            this.XYLabal.Size = new System.Drawing.Size(150, 17);
            this.XYLabal.Text = "좌표  : ";
            this.XYLabal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chTxT
            // 
            this.chTxT.AutoSize = false;
            this.chTxT.Name = "chTxT";
            this.chTxT.Size = new System.Drawing.Size(150, 17);
            this.chTxT.Text = "선택 : ";
            this.chTxT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // thicknessX2
            // 
            this.thicknessX2.Name = "thicknessX2";
            this.thicknessX2.Size = new System.Drawing.Size(152, 22);
            this.thicknessX2.Text = "x2";
            this.thicknessX2.Click += new System.EventHandler(this.thicknessX2_Click);
            // 
            // thicknessX3
            // 
            this.thicknessX3.Name = "thicknessX3";
            this.thicknessX3.Size = new System.Drawing.Size(152, 22);
            this.thicknessX3.Text = "x3";
            this.thicknessX3.Click += new System.EventHandler(this.thicknessX3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(764, 457);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Nomal
            // 
            this.Nomal.Name = "Nomal";
            this.Nomal.Size = new System.Drawing.Size(152, 22);
            this.Nomal.Text = "기본";
            this.Nomal.Click += new System.EventHandler(this.Nomal_Click);
            // 
            // PicturePan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 526);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.DrawPan);
            this.Controls.Add(this.menuStrip1);
            this.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PicturePan";
            this.Text = "그림판";
            this.Load += new System.EventHandler(this.PicturePan_Load);
            this.Resize += new System.EventHandler(this.PicturePan_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.DrawPan.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem Menu_Tool;
        private ToolStripMenuItem Tool_Pencil;
        private ToolStripMenuItem Menu_Color;
        private ToolStripMenuItem Menu_Line;
        private ToolStripMenuItem Menu_Clear;
        private ToolStripMenuItem ColorChose;
        private ToolStripMenuItem thickness;
        private ToolStripMenuItem thicknessX1;
        private ToolStrip toolStrip1;
        private ToolStripButton Strip_Pencil;
        private ToolStripButton Strip_Line;
        private ToolStripButton Strip_Clear;
        private ToolStripSeparator toolStripSeparator1;
        private Panel DrawPan;
        private JKPictureBox pictureBox1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel XYLabal;
        private ToolStripStatusLabel chTxT;
        private ColorDialog colorDialog1;
        private ToolStripMenuItem thicknessX2;
        private ToolStripMenuItem thicknessX3;
        private ToolStripMenuItem Nomal;



   

    }
}

