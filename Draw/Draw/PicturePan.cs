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

namespace Draw
{
    public partial class PicturePan : Form
    {
        string select = "";
        Point myPoint = new Point(0, 0);

        Pen myPen;
        Pen clearPen = new Pen(Color.White);


        private int fastX = 0, fastY = 0;

        LineDataSave psd; //<-= 문제의 녀석 //<== 여기다가 한번 호출 했기때문에 똑같은 값이 계속 들어감 
        List<LineDataSave> saveList = new List<LineDataSave>();

        private bool selectArea = false;

        private Point ps = new Point();
        private Point pe1 = new Point();
        private Point pe2 = new Point();

        int pcWidth = 0, pcHeight = 0;



        public PicturePan()
        {
            InitializeComponent();

            myPen = new Pen(new SolidBrush(Color.Black));
            myPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
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




        private void pictureBox1_Paint(object sender, PaintEventArgs e) //컨트롤을 다시 그리면 발생!
        {
            

            for (int i = 0; i < saveList.Count; i++)
            {
               e.Graphics.DrawLine(saveList[i].myPen, saveList[i].firstX, saveList[i].firstY, saveList[i].endX, saveList[i].endY);
            }

            if (this.selectArea == true)
            {
                e.Graphics.DrawLine(myPen, ps, pe2);
            }
        }





        //==============================================================

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            XYLabal.Text = "X : " + e.X + " Y : " + e.Y;

            switch (select)
            {
                case "선":
                    if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                    {
                        psd = new LineDataSave();

                        if (myPoint != new Point(0, 0))
                        {
                            psd.firstX = e.X;
                            psd.firstY = e.Y;
                            psd.endX = myPoint.X;
                            psd.endY = myPoint.Y;
                            psd.myPen = myPen;
                            saveList.Add(psd);

                        }
                        pictureBox1.Invalidate();
                        myPoint = e.Location;
                    }
                    break;

                case "직선":

                    //페인트에서만..
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
                            psd.myPen = clearPen;
                            saveList.Add(psd);
                        }
                        pictureBox1.Invalidate();
                        myPoint = e.Location;
                    }
                    break;
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (select)
            {
                case "선":
                    myPoint = e.Location;
                    break;

                case "직선":


                    if (fastX == 0 && fastY == 0)
                    {
                        psd = new LineDataSave(); //클릭할때마다 세로운 객채를 생성하여 거기에 값을 저장 한다.

                        if (e.Button == MouseButtons.Left)
                        {

                            selectArea = true;

                            fastX = e.X;
                            fastY = e.Y;

                            psd.firstX = fastX;
                            psd.firstY = fastY;

                            ps.X = e.X;
                            ps.Y = e.Y;

                            pictureBox1.Invalidate();

                        }
                    }
                    break;

                case "지우개":
                    myPoint = e.Location;
                    break;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (select)
            {
                case "선":
                    myPoint = e.Location;
                    break;

                case "직선":
                    psd.endX = e.X;
                    psd.endY = e.Y;
                    psd.myPen = myPen;
                    saveList.Add(psd);
                    selectArea = false;
                    pictureBox1.Invalidate(); //컨트롤의 전체 화면을 무효화하고 컨트롤을 다시 그립니다.

                    fastX = 0;
                    fastY = 0;

                    break;
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
                      //  myPen = new Pen(Color.Black);
                    break;

                case "직선":
                        select = "직선";
                        chTxT.Text = "선택 : " + select;
                        myPen = new Pen(colorDialog1.Color);
                    break;

                case "지우개":
                        select = "지우개";
                        chTxT.Text = "선택 : " + select;
                        clearPen = new Pen(pictureBox1.BackColor, 50);
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
        //=======================색상팔래트============================
        private void ColorChose_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                myPen = new Pen(colorDialog1.Color);
            }
        }
        //=======================두깨 설정 ============================

        private void thicknessX1_Click(object sender, EventArgs e)
        {
            //myPen = new Pen(colorDialog1.Color,10);
            myPen.Width = 10;
        }

        private void thicknessX2_Click(object sender, EventArgs e)
        {
           // myPen = new Pen(colorDialog1.Color,20);
            myPen.Width = 20;
        }

        private void thicknessX3_Click(object sender, EventArgs e)
        {
          //  myPen = new Pen(colorDialog1.Color,30);
            myPen.Width = 30;
        }

        private void Nomal_Click(object sender, EventArgs e)
        {
          //   myPen = new Pen(colorDialog1.Color);
            myPen.Width = 1;
  
        }




    }
}