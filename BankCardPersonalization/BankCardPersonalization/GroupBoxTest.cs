﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BankCardPersonalization
{
    public partial class GroupBoxTest : Form
    {
        private void GroupBoxTest_Load(object sender, EventArgs e)
        {
            myGroupBox myGroupBox = new myGroupBox();
            myGroupBox.Text = "GroupBox1";
            myGroupBox.BorderColor = Color.Red;
            this.Controls.Add(myGroupBox);
        }
    }

    public class myGroupBox : GroupBox
    {
        private Color borderColor;

        public Color BorderColor
        {
            get { return this.borderColor; }
            set { this.borderColor = value; }
        }

        public myGroupBox()
        {
            this.borderColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Size tSize = TextRenderer.MeasureText(this.Text, this.Font);

            Rectangle borderRect = e.ClipRectangle;
            borderRect.Y += tSize.Height / 2;
            borderRect.Height -= tSize.Height / 2;
            ControlPaint.DrawBorder(e.Graphics, borderRect, this.borderColor, ButtonBorderStyle.Solid);

            Rectangle textRect = e.ClipRectangle;
            textRect.X += 6;
            textRect.Width = tSize.Width;
            textRect.Height = tSize.Height;
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), textRect);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect);
        }
    }
}