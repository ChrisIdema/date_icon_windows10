using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing;

using System.Threading;

namespace date_icon_windows10
{
    public partial class Form1 : Form
    {




        //http://stackoverflow.com/questions/36379547/writing-text-to-the-system-tray-instead-of-an-icon
        public void CreateTextIcon2(string str)
        {
            Font fontToUse = new Font("Microsoft Sans Serif", 16, FontStyle.Regular, GraphicsUnit.Pixel);
            Brush brushToUse = new SolidBrush(Color.White);
            Bitmap bitmapText = new Bitmap(16, 16);
            Graphics g = System.Drawing.Graphics.FromImage(bitmapText);

            IntPtr hIcon;

            g.Clear(Color.Transparent);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.DrawString(str, fontToUse, brushToUse, -4, -2);
            hIcon = (bitmapText.GetHicon());
            notifyIcon1.Icon = System.Drawing.Icon.FromHandle(hIcon);
            //DestroyIcon(hIcon.ToInt32);
        }

        public void CreateTextIcon3(string str)
        {
            Font fontToUse = new Font("Trebuchet MS", 10, FontStyle.Regular, GraphicsUnit.Pixel);
            Brush brushToUse = new SolidBrush(Color.White);
            Bitmap bitmapText = new Bitmap(16, 16);
            Graphics g = System.Drawing.Graphics.FromImage(bitmapText);

            IntPtr hIcon;

            g.Clear(Color.Transparent);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.DrawString(str, fontToUse, brushToUse, -2, 0);
            hIcon = (bitmapText.GetHicon());
            notifyIcon1.Icon = System.Drawing.Icon.FromHandle(hIcon);
            //DestroyIcon(hIcon.ToInt32);
        }

        public void CreateTextIcon(string str1, string str2)
        {
            Font fontToUse = new Font("Trebuchet MS", 10, FontStyle.Regular, GraphicsUnit.Pixel);
            Brush brushToUse = new SolidBrush(Color.White);
            Bitmap bitmapText = new Bitmap(16, 16);
            Graphics g = System.Drawing.Graphics.FromImage(bitmapText);

            IntPtr hIcon;

            g.Clear(Color.Transparent);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.DrawString(str1, fontToUse, brushToUse, 5, -3);
            g.DrawString(str2, fontToUse, brushToUse, 5, 5);
            //g.DrawString("1234", fontToUse, brushToUse, -5, 5);
            hIcon = (bitmapText.GetHicon());
            notifyIcon1.Icon = System.Drawing.Icon.FromHandle(hIcon);
            //DestroyIcon(hIcon.ToInt32);
        }



        public Form1()
        {
            InitializeComponent();

            var date = DateTime.Today;

            var datestring = date.ToShortDateString();

            //var icon = GetIcon(datestring);


            //http://stackoverflow.com/questions/12577749/display-text-over-notifyicon-icon-in-windows-application

            //notifyIcon1.Visible = true;

            //CreateTextIcon(datestring);

            string day_string = date.Day.ToString().PadLeft(2, '0');
            string month_string = date.Month.ToString().PadLeft(2, '0');
            CreateTextIcon(day_string, month_string);

            WindowState = FormWindowState.Minimized;
//
            //new Thread

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
