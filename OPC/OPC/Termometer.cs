/*
 * FILE         |   Termometer.cs
 * PROJECT      |   IAD Assignmet #2
 * DATE         |   31/03/2015
 * AUTHORS      |   Ben Lorantfy, Grigory Kozyrev
 * DETAILS      |   This is the custom thermometer class. It is works exctly the same as progress bar,
 *              |   But color changes from green in start to yellow in the middle and red at the end (with transition in between).
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace OPC
{
    class Termometer : ProgressBar
    {
        public Termometer()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;
            int green = 255;
            int red = 0;
            int median = (int)(Maximum / 2);

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - 4;
            
            if (Value < median)
            {
                //Make sure that color goes from green in start to yellow in the middle
                green = 255;
                red = (int)(255 * (Value / (double)median));
            }
            else
            {   
                //And then to yellow in the middle and red at the end
                green = (int)(255 * (1 - (Value - median) / (double)(Maximum - median)));
                red = 255;
            }
            SolidBrush myBrush = new SolidBrush(Color.FromArgb(red, green, 0));
            e.Graphics.FillRectangle(myBrush, 2, 2, rec.Width, rec.Height);
        }
    }
}
