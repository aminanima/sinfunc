using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace sinfunc
{
    public partial class Form1 : Form
    {
        List<PointF> arr = new List<PointF>(); //Array of points of the sinx
        Pen pen = new Pen(Color.Blue,3); //creating pen
        Pen pencross = new Pen(Color.Black); //creating pen for cross horizontal and vertical lines
        SolidBrush mySolidBrush = new SolidBrush(Color.Green);//creating solid brush
        HatchBrush myHatchBrush = new HatchBrush(HatchStyle.Cross,Color.Black,Color.Transparent);
        public Form1()
        {
            Timer t = new Timer(); //creating the timer
            t.Interval = 150; //the interval of drawing points 
            t.Tick += T_Tick;
            t.Start();
            InitializeComponent();
            arr.Add(new PointF(0, 300));// two points needed to draw a curve
            arr.Add(new PointF(0, 300));//initial points
        }
        int x;
        private void T_Tick(object sender, EventArgs e)
        {
            double y = Math.Sin(x++);
            double px = x * 20;// the frequency
            double py = -y * 20 + 300;//the amplitude
            arr.Add(new PointF((float)px, (float)py));
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e);
            e.Graphics.DrawCurve(pen, arr.ToArray());
        
        }

        private void Draw(PaintEventArgs e)
        {
            Point hr = new Point(0, 0);//cross lines
            Point vr = new Point(0,600);
            e.Graphics.DrawRectangle(pencross,0,0,600,600);// the region to draw cross lines
            e.Graphics.FillRectangle(myHatchBrush, 0,0,600,600);
            Point p1 = new Point(0 , 300);
            Point p2 = new Point(600,300);
            Point p3 = new Point(275, 5);
            Point p4 = new Point(275, 600);
            Pen mypen = new Pen(Color.Red,4);//pen for drawing axis x and y
            e.Graphics.DrawLine(mypen, p1, p2);
            e.Graphics.DrawLine(mypen, p3, p4);
            Pen pentext = new Pen(Color.Violet, 3);
            FontFamily myFontFamily = new FontFamily("Times New Roman");
            PointF myPointF = new PointF(50, 20);
            StringFormat myStringFormat = new StringFormat();
            GraphicsPath myGraphicsPath = new GraphicsPath();// creating graphics path
            myGraphicsPath.AddString("Sine wave", myFontFamily, 0, 30, myPointF, myStringFormat);
            e.Graphics.FillPath(mySolidBrush, myGraphicsPath);// filling the text with color given above 
            e.Graphics.DrawPath(pentext, myGraphicsPath);// drawing the path 
           

        }

    }
}
