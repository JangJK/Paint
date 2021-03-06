﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows;
using System.Drawing;
using System.Timers;
using System.Collections;

using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

namespace Draw
{
    public partial class PicturePan : Form
    {
        private string select = "";
        private Point myPoint = new Point(0, 0);

        private Pen myPen;
        private Pen clearPen;

        private float fastX = 0, fastY = 0;
        private float endX = 0, endY = 0;

        private float now_X = 0, now_Y = 0;

        private LineDataSave psd;
        private List<LineDataSave> saveList = new List<LineDataSave>();

        private bool selectArea = false;

        private Point ps = new Point();
        private Point pe1 = new Point();
        private Point pe2 = new Point();

        private int pcWidth = 0, pcHeight = 0;

        private float zoomScale = 1.0f;
       // private float zoomScale = 1;

        private bool zoomAtion = false;
        private bool panAtion = false;

       //뺄양에 대한 맴버변수
        private float move_X = 0;
        private float move_Y = 0;

       // private Image image;

        private Bitmap gBitmap;

        private int PBwidth = 0;
        private int PBheight = 0;

        public PicturePan()
        {
            InitializeComponent();
            PBwidth = pictureBox1.Width;
            PBheight = pictureBox1.Height;

            gBitmap = new Bitmap(PBwidth, PBheight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(gBitmap))
            g.Clear(SystemColors.Window);

            //pictureBox1.Image = new Bitmap(pictureBox1.Width,pictureBox1.Height);

            myPen = new Pen(new SolidBrush(Color.Black));
            clearPen = new Pen(new SolidBrush(Color.Black));

            //팬 모양 둥글게
            myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            myPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            clearPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            clearPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        }



        private void PicturePan_Load(object sender, EventArgs e)
        {
            pcWidth = this.Width;
            pcHeight = this.Height;
        }

        private void PicturePan_Resize(object sender, EventArgs e)
        {
            int chWidth = 0, chHeight = 0;

            chWidth = this.Width - pcWidth;
            chHeight = this.Width - pcHeight;

            pictureBox1.Width = pcWidth + chWidth;
            pictureBox1.Height = pcHeight + chHeight;
        }

        //===임시
        float bit_X = 0;
        float bit_Y = 0;

        float bit_Width = 0;
        float bit_height = 0;
       
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e) //컨트롤을 다시 그리면 발생!
        {
            //
            // 4좌표 계 생각 3좌표계랑 4좌표계를 동시있다 생각하고 이미지 비트맵 사이즈만 줌이랑 move 값 더해주면 완성 될듯.

            if (zoomAtion)
            {
                bit_Width = PBwidth;
                bit_height = PBheight;

                e.Graphics.DrawImage(gBitmap, bit_X * zoomScale + move_X, bit_Y * zoomScale + move_Y, bit_Width * zoomScale, bit_height * zoomScale);
            }else{
                e.Graphics.DrawImage(gBitmap, new Point(0, 0));
            }


            float Width = myPen.Width;
            Color color = myPen.Color;

            for (int i = 0; i < saveList.Count; i++)
            {
                myPen.Color = saveList[i].color;
                myPen.Width = saveList[i].Width;

                if (saveList[i].select == "직선" || saveList[i].select == "선" || saveList[i].select == "지우개")
                {
                    if (zoomAtion == true)
                        e.Graphics.DrawLine(myPen, saveList[i].firstX * zoomScale + move_X, saveList[i].firstY * zoomScale + move_Y, saveList[i].endX * zoomScale + move_X, saveList[i].endY * zoomScale + move_Y);
                    else
                        e.Graphics.DrawLine(myPen, saveList[i].firstX + move_X, saveList[i].firstY + move_Y, saveList[i].endX + move_X, saveList[i].endY + move_Y);
                }

                else if (saveList[i].select == "사각형")
                {
                    float resx = Math.Min(saveList[i].firstX, saveList[i].endX);
                    float resy = Math.Min(saveList[i].firstY, saveList[i].endY);

                    float reswidth = Math.Abs(saveList[i].firstX - saveList[i].endX);
                    float resheight = Math.Abs(saveList[i].firstY - saveList[i].endY);

                    if (zoomAtion == true)
                        e.Graphics.DrawRectangle(myPen, resx * zoomScale + move_X, resy * zoomScale + move_Y, reswidth * zoomScale, resheight * zoomScale);
                    else
                        e.Graphics.DrawRectangle(myPen, resx + move_X, resy + move_Y, reswidth, resheight);

                }
                else if (saveList[i].select == "원")
                {
                    float cx = Math.Min(saveList[i].firstX, saveList[i].endX);
                    float cy = Math.Min(saveList[i].firstY, saveList[i].endY);

                    float cWidth = Math.Abs(saveList[i].firstX - saveList[i].endX);
                    float cHeight = Math.Abs(saveList[i].firstY - saveList[i].endY);

                    if (zoomAtion == true)
                        e.Graphics.DrawEllipse(myPen, cx * zoomScale + move_X, cy * zoomScale + move_Y, cWidth * zoomScale, cHeight * zoomScale);
                    else
                        e.Graphics.DrawEllipse(myPen, cx + move_X, cy + move_Y, cWidth, cHeight);
                }
            }
           

            myPen.Color = color;
            myPen.Width = Width;

            if (selectArea)
            {
                if (select == "직선" || select == "선" || select == "지우개")
                {
                   e.Graphics.DrawLine(myPen, ps, pe2);
                }
                if (select == "사각형")
                {
                    float resx = Math.Min(ps.X, pe1.X);
                    float resy = Math.Min(ps.Y, pe1.Y);

                    float reswidth = Math.Abs(ps.X - pe1.X);
                    float resheight = Math.Abs(ps.Y - pe1.Y);


                    e.Graphics.DrawRectangle(myPen, resx, resy, reswidth, resheight);
                }
                else if (select == "원")
                {
                    float cx = Math.Min(ps.X, pe1.X);
                    float cy = Math.Min(ps.Y, pe1.Y);

                    float cWidth = Math.Abs(ps.X - pe1.X);
                    float cHeight = Math.Abs(ps.Y - pe1.Y);


                    e.Graphics.DrawEllipse(myPen, cx, cy, cWidth, cHeight);
                }
            }
            

        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
            if (pictureBox1.Focused == true)
            {
                if (e.Delta > 0)
                {
                    zoomIn(e);
                }
                else
                {
                    zoomOut(e);
                }
            }

        }
        private void zoomIn(MouseEventArgs e)
        {
            zoomAtion = true;
            zoomScale+=0.25f;
            Console.WriteLine("move : "+now_X);
            Console.WriteLine("wheel : " + e.X);


            if (zoomScale >= 7)
            {
                zoomScale = 7;

                move_X = now_X - (now_X * zoomScale);
                move_Y = now_Y - (now_Y * zoomScale);

                now_X = e.X;
                now_Y = e.Y;
            }
            else
            {
                move_X = now_X - (now_X * zoomScale);
                move_Y = now_Y - (now_Y * zoomScale);

                now_X = e.X;
                now_Y = e.Y;
            }

            Console.WriteLine("in : "+zoomScale);
            pictureBox1.Invalidate();
        }

        private void zoomOut(MouseEventArgs e)
        {
            zoomAtion = true;
            zoomScale-=0.25f;

           if(zoomScale<=0)
           {
               zoomScale = 0.25f;
               move_X = now_X - (e.X * zoomScale);
               move_Y = now_Y - (e.Y * zoomScale);

               now_X = e.X;
               now_Y = e.Y;
           }
           else
           {
               move_X = now_X - (e.X * zoomScale);
               move_Y = now_Y - (e.Y * zoomScale);

               now_X = e.X;
               now_Y = e.Y;
           }
            Console.WriteLine("out : " + zoomScale);

            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                panAtion = true;
                this.Cursor = System.Windows.Forms.Cursors.Hand;
                fastX = e.X;
                fastY = e.Y;

                pictureBox1.Invalidate();
            }
            else
            {
                switch (select)
                {
                    case "선":
                        myPoint = e.Location;
                        break;
                    case "원":
                    case "사각형":
                    case "직선":
                        if (fastX == 0 && fastY == 0)
                        {
                            psd = new LineDataSave(); //클릭할때마다 세로운 객채를 생성하여 거기에 값을 저장 한다.

                            if (e.Button == MouseButtons.Left)
                            {
                                selectArea = true;
                                if (selectArea)
                                {
                                    fastX = e.X - move_X;
                                    fastY = e.Y - move_Y;

                                    psd.firstX = fastX;
                                    psd.firstY = fastY;

                                    ps.X = e.X;
                                    ps.Y = e.Y;

                                    if (zoomAtion)
                                    {
                                        fastX = e.X - move_X; // 현재 좌표에서 움직인만큼 빼야 원점 좌표가 된다. 좌표계 3
                                        fastY = e.Y - move_Y;

                                        psd.firstX = fastX / zoomScale;
                                        psd.firstY = fastY / zoomScale;

                                        ps.X = e.X;
                                        ps.Y = e.Y;
                                    }
                                    pictureBox1.Invalidate();
                                }
                            }
                        }
                        break;

                    case "지우개":
                        myPoint = e.Location;
                        break;
                }
            }
        }
        //==============================================================
    
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            XYLabal.Text = "X : " + e.X + " Y : " + e.Y;

            now_X = e.X;
            now_Y = e.Y;

            if (panAtion)
            {
                move_X += e.X - fastX;
                move_Y += e.Y - fastY;

                fastX = e.X;
                fastY = e.Y;

                pictureBox1.Invalidate();
            }
            else
            {

                switch (select)
                {
                    case "선":
                        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                        {
                            psd = new LineDataSave();

                            if (myPoint != new Point(0, 0))
                            {
                                psd.firstX = e.X - move_X;
                                psd.firstY = e.Y - move_Y;
                                psd.endX = myPoint.X;
                                psd.endY = myPoint.Y;

                                psd.color = myPen.Color;
                                psd.Width = myPen.Width;
                                psd.select = select;
                                saveList.Add(psd);

                                if (zoomAtion)
                                {
                                    fastX = e.X - move_X; // 현재 좌표에서 움직인만큼 빼야 원점 좌표가 된다. 좌표계 3
                                    fastY = e.Y - move_Y;

                                    endX = myPoint.X - move_X;
                                    endY = myPoint.Y - move_Y;

                                    psd.firstX = fastX / zoomScale;
                                    psd.firstY = fastY / zoomScale;
                                    psd.endX = endX / zoomScale;
                                    psd.endY = endY / zoomScale;

                                    psd.color = myPen.Color;
                                    psd.Width = myPen.Width;
                                    psd.select = select;
                                    saveList.Add(psd);
                                }
                            }


                            myPoint = e.Location;
                            pictureBox1.Invalidate();

                        }
                        break;

                    case "원":
                    case "사각형":
                    case "직선":

                        pe1 = pe2;
                        pe2 = e.Location;
                        pictureBox1.Invalidate();

                        break;

                    case "지우개":

                        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                        {
                            psd = new LineDataSave();

                            if (myPoint != new Point(0, 0))
                            {
                                psd.firstX = e.X;
                                psd.firstY = e.Y;
                                psd.endX = myPoint.X;
                                psd.endY = myPoint.Y;
                                psd.color = clearPen.Color;
                                psd.Width = clearPen.Width;
                                psd.select = select;

                                saveList.Add(psd);

                                if (zoomAtion)
                                {

                                    fastX = e.X - move_X; // 현재 좌표에서 움직인만큼 빼야 원점 좌표가 된다. 좌표계 3
                                    fastY = e.Y - move_Y;

                                    endX = myPoint.X - move_X;
                                    endY = myPoint.Y - move_Y;

                                    psd.firstX = fastX / zoomScale;
                                    psd.firstY = fastY / zoomScale;
                                    psd.endX = endX / zoomScale;
                                    psd.endY = endY / zoomScale;

                                    psd.color = clearPen.Color;
                                    psd.Width = clearPen.Width;
                                    psd.select = select;

                                    saveList.Add(psd);
                                }
                            }

                            myPoint = e.Location;
                            pictureBox1.Invalidate();
                        }
                        break;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            if (panAtion)
            {
                fastX = e.X;
                fastY = e.Y;

                panAtion = false;
                this.Cursor = System.Windows.Forms.Cursors.Default;

                pictureBox1.Invalidate();

                fastX = 0;
                fastY = 0;
            }
            else
            {
                switch (select)
                {

                    case "선":
                        myPoint = e.Location;
                        break;
                    case "원":
                    case "사각형":
                    case "직선":
                        if (selectArea)
                        {
                            psd.endX = e.X - move_X;
                            psd.endY = e.Y - move_Y;
                            psd.color = myPen.Color;
                            psd.Width = myPen.Width;
                            psd.select = select;
                            saveList.Add(psd);
                            selectArea = false;

                            if (zoomAtion)
                            {
                                endX = e.X - move_X;
                                endY = e.Y - move_Y;

                                psd.endX = endX / zoomScale;
                                psd.endY = endY / zoomScale;

                                psd.color = myPen.Color;
                                psd.Width = myPen.Width;
                                psd.select = select;
                                saveList.Add(psd);
                                selectArea = false;
                            }
                        }

                        pictureBox1.Invalidate(); //컨트롤의 전체 화면을 무효화하고 컨트롤을 다시 그립니다.

                        fastX = 0;
                        fastY = 0;
                        break;
                    case "지우개":
                        myPoint = e.Location;
                        break;
                }
            }
        }
        //====================선,직선,지우개선택=============================

        private void choseTool(string str)
        {
            switch (str)
            {
                case "선":
                    select = "선";
                    chTxT.Text = "선택 : " + select;
                    break;

                case "직선":
                    select = "직선";
                    chTxT.Text = "선택 : " + select;
                    myPen.Color = colorDialog1.Color;

                    break;

                case "지우개":
                    select = "지우개";
                    chTxT.Text = "선택 : " + select;
                    clearPen.Color = pictureBox1.BackColor;
                    clearPen.Width = 50;

                    /* Rectangle eraser = new*/

                    break;


                case "사각형":
                    select = "사각형";
                    chTxT.Text = "선택 : " + select;
                    myPen.Color = colorDialog1.Color;
                    break;

                case "원":
                    select = "원";
                    chTxT.Text = "선택 : " + select;
                    myPen.Color = colorDialog1.Color;
                    break;
            }
        }

        private void Tool_Pencil_Click(object sender, EventArgs e)
        {
            choseTool("선");
        }

        private void Strip_Pencil_Click(object sender, EventArgs e)
        {
            choseTool("선");
        }

        private void Menu_Line_Click(object sender, EventArgs e)
        {
            choseTool("직선");
        }

        private void Strip_Line_Click(object sender, EventArgs e)
        {
            choseTool("직선");
        }

        private void Menu_Clear_Click(object sender, EventArgs e)
        {
            choseTool("지우개");
        }

        private void Strip_Clear_Click(object sender, EventArgs e)
        {
            choseTool("지우개");
        }

        private void Strip_REC_Click(object sender, EventArgs e)
        {
            choseTool("사각형");
        }
        private void Menu_REC_Click(object sender, EventArgs e)
        {
            choseTool("사각형");
        }

        private void Menu_Circle_Click(object sender, EventArgs e)
        {
            choseTool("원");
        }

        private void Strip_Circle_Click(object sender, EventArgs e)
        {
            choseTool("원");
        }


        //=======================색상팔래트============================
        private void ColorChose_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                myPen.Color = colorDialog1.Color;
            }
        }
        //=======================두깨 설정 ============================

        private void thicknessX1_Click(object sender, EventArgs e)
        {
            myPen.Width = 10;
        }

        private void thicknessX2_Click(object sender, EventArgs e)
        {
            myPen.Width = 20;
        }

        private void thicknessX3_Click(object sender, EventArgs e)
        {
            myPen.Width = 30;
        }

        private void Nomal_Click(object sender, EventArgs e)
        {
            myPen.Width = 1;
        }

        //=======================파일 저장 ============================

        

        private void saveBMP_Click(object sender, EventArgs e)
        {
            string saveFileName;
            saveFileDialog1.Filter = "bmp(*.bmp)|*.bmp";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileName = saveFileDialog1.FileName;

                using (Bitmap bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height))
                {
                    pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
                    bmp.Save(saveFileName,System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
        }



        private void openBMP_Click(object sender, EventArgs e)
        {
            string openFileName;
            openFileDialog1.Filter = "bmp(*.bmp)|*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                gBitmap = new Bitmap(openFileName);


               // image = Image.FromFile(openFileName);
               
                

                // 사진을 불러와서 비트맵으로 바꾼다음에 그래픽스로 그려 줘야 하는건가?

                //pictureBox1.Image = image;
                //pictureBox1.Image = gBitmap;

                pictureBox1.Invalidate();

                               
            }

        }

    }
}