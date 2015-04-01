using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace VS2010_40_CS_Example
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
                green = 255;
                red = (int)(255 * (Value / (double)median));
            }
            else
            {
                green = (int)(255 * (1 - (Value - median) / (double)(Maximum - median)));
                red = 255;
            }
            SolidBrush myBrush = new SolidBrush(Color.FromArgb(red, green, 0));
            e.Graphics.FillRectangle(myBrush, 2, 2, rec.Width, rec.Height);
        }
    }
}
