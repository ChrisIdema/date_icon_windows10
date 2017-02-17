using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.Drawing;

//using System.Threading;

using System.Timers;

namespace date_icon_windows10
{
    public partial class Form1 : Form
    {




        //http://stackoverflow.com/questions/36379547/writing-text-to-the-system-tray-instead-of-an-icon
        //http://stackoverflow.com/questions/12577749/display-text-over-notifyicon-icon-in-windows-application.

        System.Timers.Timer timer;

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


        static int milliseconds_to_midnight(DateTime time)
        {
            return 24*60*60*1000 - (time.TimeOfDay.Milliseconds+ time.TimeOfDay.Seconds*1000+ time.TimeOfDay.Minutes*1000*60+ time.TimeOfDay.Hours*1000*60*60);
        }

        void timer_init(int milliseconds)
        {
     



            timer = new System.Timers.Timer(milliseconds);

            timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            timer.Enabled = true; // Enable it
        }



        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var now = DateTime.Now;

            var datestring = now.ToShortDateString();
            string day_string = now.Day.ToString().PadLeft(2, '0');
            string month_string = now.Month.ToString().PadLeft(2, '0');
            CreateTextIcon(day_string, month_string);

            timer.Interval = milliseconds_to_midnight(now);
        }

        public Form1()
        {
            InitializeComponent();

            WindowState = FormWindowState.Minimized;

            var now = DateTime.Now;

            var datestring = now.ToShortDateString();
            string day_string = now.Day.ToString().PadLeft(2, '0');
            string month_string = now.Month.ToString().PadLeft(2, '0');
            CreateTextIcon(day_string, month_string);

            timer_init(milliseconds_to_midnight(now));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
