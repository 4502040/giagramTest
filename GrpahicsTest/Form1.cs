using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using FastReport.MSChart;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using FastReport;
using DevExpress.XtraCharts;

namespace GrpahicsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawOnPBox();

            return;

            List<DiModel> diModel = new List<DiModel>();

            Form frm = Application.OpenForms[0];
                       

            int i = 1;

            Random rd = new Random();

            for (DateTime dt = new DateTime(2019, 10, 1); dt <= new DateTime(2019, 10, 2); dt = dt.AddMinutes(5))
            {
                diModel.Add(new DiModel()
                {
                    Id = i,
                    Date = dt.ToString("H:m dd.MM.yyyy"),
                    Dt = dt,
                    Davlenie = rd.Next(5000, 6000),
                    Deepth = 100 + i * 5,
                    Moment = rd.Next(90),
                    Nagruzka = rd.Next(245),
                    Oborot = rd.Next(100),
                    Podacha = rd.Next(100),
                    Speed = rd.Next(20),
                    VesDown = rd.Next(400),
                    VesUp = rd.Next(300),
                });

                


                //panel1.Controls.Add(lbl);

                i++;
            }

            frm.Size = new Size() { Width = 1200, Height = 1200 };

            panel1.Size = new Size() { Width = 150, Height = 1200 };
            panel1.Top = 5;
            panel1.Left = 10;
            //panel1.Width = 100;

            panel2.Height = frm.Height;
            panel2.Top = 5;
            panel2.Left = 150;
            panel2.Width = 200;

            i = 1;

            panel2.Width = diModel.Max(d => d.VesDown)+10;

            //panel1.Refresh();
            //panel2.Refresh();

            int gX1 = 0; int gY1 = 0;
            int gX2 = 0; int gY2 = 0;

            Graphics g = panel1.CreateGraphics();
            Graphics g2 = panel2.CreateGraphics();
            g2.PageUnit = GraphicsUnit.Pixel;
            g2.PageScale = 1F;

            g.Clear(Color.White);
            g2.Clear(Color.White);

            SolidBrush sbr = new SolidBrush(Color.Black);

            FontFamily fam = new FontFamily("Tahoma");
            Font font = new System.Drawing.Font(fam, 8, FontStyle.Regular);

            foreach (DiModel di in diModel) {

                int y = i * 13;

                DiModel next = diModel.Where(d => d.Dt > di.Dt).FirstOrDefault();
                
                g.DrawString(i+" - "+di.Date, font, sbr, new Point(10, y));
                                              

                if (next == null)
                {
                    next = new DiModel();
                    gX1 = di.VesDown; gY1 = 0;
                    gX2 = 20; gY2 = di.VesDown;
                }
                else
                {
                    gX1 = di.VesDown; gY1 = i*2;
                    gX2 = next.VesDown; gY2 = i*2+2;

                    var p = new Pen(Color.Black, 0.5f);
                    var point1 = new Point(gX1, gY1);
                    var point2 = new Point(gX2, gY2);
                    g2.DrawLine(p, point1, point2);
                }

                

                //gX1 = gY2;
                //gY1 = next.VesDown;

                i++;
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DrawOnPBox()
        {
            List<DiModel> diModel = new List<DiModel>();

            Form frm = Application.OpenForms[0];


            int i = 1;

            Random rd = new Random();

            for (DateTime dt = new DateTime(2019, 10, 1); dt <= new DateTime(2019, 10, 2); dt = dt.AddMinutes(5))
            {
                diModel.Add(new DiModel()
                {
                    Id = i,
                    Date = dt.ToString("H:m dd.MM.yyyy"),
                    Dt = dt,
                    Davlenie = rd.Next(5000, 6000),
                    Deepth = 100 + i * 5,
                    Moment = rd.Next(90),
                    Nagruzka = rd.Next(245),
                    Oborot = rd.Next(100),
                    Podacha = rd.Next(100),
                    Speed = rd.Next(20),
                    VesDown = rd.Next(400),
                    VesUp = rd.Next(300),
                });




                //panel1.Controls.Add(lbl);

                i++;
            }

            frm.Size = new Size() { Width = 1200, Height = 1200 };

            pbox.Size = new Size() { Width = 150, Height = 1200 };
            pbox.Top = 5;
            pbox.Left = 10;
            

            i = 1;

            

            //panel1.Refresh();
            //panel2.Refresh();

            int gX1 = 0; int gY1 = 0;
            int gX2 = 0; int gY2 = 0;

            Graphics g = pbox.CreateGraphics();
            
            

            g.Clear(Color.White);
            

            SolidBrush sbr = new SolidBrush(Color.Black);

            FontFamily fam = new FontFamily("Tahoma");
            Font font = new System.Drawing.Font(fam, 8, FontStyle.Regular);

            

            foreach (DiModel di in diModel)
            {

                int y = i * 13;

                DiModel next = diModel.Where(d => d.Dt > di.Dt).FirstOrDefault();

                g.DrawString(i + " - " + di.Date, font, sbr, new Point(10, y));

                                
                //gY1 = next.VesDown;

                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<DiModel> diModel = new List<DiModel>();
            
            int i = 1;

            Random rd = new Random();

            for (DateTime dt = new DateTime(2019, 10, 1); dt <= new DateTime(2019, 10, 2); dt = dt.AddMinutes(5))
            {
                diModel.Add(new DiModel()
                {
                    Id = i,
                    Date = dt.ToString("H:m dd.MM.yyyy"),
                    Dt = dt,
                    Davlenie = rd.Next(5000, 6000),
                    Deepth = 100 + i * 5,
                    Moment = rd.Next(90),
                    Nagruzka = rd.Next(245),
                    Oborot = rd.Next(100),
                    Podacha = rd.Next(100),
                    Speed = rd.Next(20),
                    VesDown = rd.Next(400),
                    VesUp = rd.Next(300),
                });


              

                i++;
            }

            


            DevExpress.XtraCharts.Series s1 = chartControl1.Series[0];
            DevExpress.XtraCharts.Series s2 = chartControl1.Series[1];
            s1.Points.Clear();
            s2.Points.Clear();

            

            foreach (DiModel di in diModel) {
                s1.Points.AddPoint(di.Dt, di.VesUp);
                //s1.Points.Add(new DevExpress.XtraCharts.SeriesPoint() { Argument = di.Date, Values = new [] {Convert.ToDouble(di.Deepth)} });
                s2.Points.AddPoint(di.Dt, di.VesDown);
            }

            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;

            // Define the date-time measurement unit, to which the beginning of
            // a diagram's gridlines and labels should be aligned.
            diagram.AxisX.DateTimeScaleMode = DateTimeScaleMode.Manual;
            //diagram.AxisX.DateTimeGridAlignment = DateTimeMeasurementUnit.Minute;

            // Define the detail level for date-time values.
            diagram.AxisX.DateTimeMeasureUnit = DateTimeMeasurementUnit.Minute;
            diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Continuous;

            // Define the custom date-time format (name of a month) for the axis labels.
            diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
            diagram.AxisX.DateTimeOptions.FormatString = "dd/MM/yyyy\nHH:mm:ss";

            chartControl1.Height = this.Height;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Image img = DrawText("Test", new System.Drawing.Font(new FontFamily("Tahoma"), 18, FontStyle.Regular), Color.Red, Color.Transparent);
            List<DiModel> diModel = new List<DiModel>();
            Random rd = new Random();
            int i = 1;
            for (DateTime dt = new DateTime(2019, 10, 1); dt <= new DateTime(2019, 10, 2); dt = dt.AddMinutes(5))
            {
                diModel.Add(new DiModel()
                {
                    Id = i,
                    Date = dt.ToString("H:m dd.MM.yyyy"),
                    Dt = dt,
                    Davlenie = rd.Next(5000, 6000),
                    Deepth = 100 + i * 5,
                    Moment = rd.Next(90),
                    Nagruzka = rd.Next(245),
                    Oborot = rd.Next(100),
                    Podacha = rd.Next(100),
                    Speed = rd.Next(20),
                    VesDown = rd.Next(400),
                    VesUp = rd.Next(300),
                });


                //panel1.Controls.Add(lbl);

                i++;
            }
                        

            pbox.Image = DrawDateTimes(diModel);

            pbox2.Image = DrawLines(diModel);
        }

        private Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;

        }

        private Image DrawDateTimes(List<DiModel> diModel)
        {      

            System.Drawing.Font font = new System.Drawing.Font(new FontFamily("Tahoma"), 7, FontStyle.Regular);

            Color backColor = Color.Transparent;
            Color textColor = Color.Black;
            string text = "Super";

            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            int pboxHeight = (int)diModel.Count * 13;

            //create a new image of the right size
            pbox.Size = new Size() { Width = 150, Height = pboxHeight };
            pbox.Top = 5;
            pbox.Left = 10;
            img = new Bitmap((int)pbox.Width, pboxHeight);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            int i = 1;

            foreach (DiModel di in diModel) {
                int y = i * 12;
                //int count = (int)(di.Dt.TotalSeconds / tsp2.t.TotalSeconds);
                drawing.DrawString(di.Date, font, textBrush, new Point(10, y));
                i++;
            }            

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;

        }

        private Image DrawLines(List<DiModel> diModel)
        {     

            int pboxHeight = (int)diModel.Count * 13;
            int pboxWidth = diModel.Max(d => d.VesDown) + 10;
            //create a new image of the right size
            pbox2.Size = new Size() { Width = pboxWidth , Height = pboxHeight };
            pbox2.Top = 5;
            pbox2.Left = 130;

            Image img = new Bitmap((int)pbox2.Width, pboxHeight);

            Graphics drawing = Graphics.FromImage(img);
                      

            int i = 1;
            int gX1 = 0; int gY1 = 0;
            int gX2 = 0; int gY2 = 0;

            drawing.PageUnit = GraphicsUnit.Point;
            drawing.PageScale = 0.7F;

            foreach (DiModel di in diModel)
            {
                int y = i * 12;
                DiModel next = diModel.Where(d => d.Dt > di.Dt).FirstOrDefault();

                if (next == null)
                {
                    next = new DiModel();
                    gX1 = di.VesDown; gY1 = 0;
                    gX2 = 20; gY2 = di.VesDown;
                }
                else
                {
                    gX1 = di.VesDown; gY1 = i * 2;
                    gX2 = next.VesDown; gY2 = i * 2+2;

                    var p = new Pen(Color.Black, 0.5f);
                    var point1 = new Point(gX1, gY1);
                    var point2 = new Point(gX2, gY2);
                    drawing.DrawLine(p, point1, point2);
                }

                i++;
            }

            drawing.Save();

           
            drawing.Dispose();

            return img;

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //chartControl1.Width = this.Width;
           // chartControl1.Height = this.Height;
        }
    }

    public class DiModel
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public DateTime Dt { get; set; }

        public int Deepth { get; set; }

        public int VesUp { get; set; }

        public int VesDown { get; set; }

        public int Nagruzka { get; set; }

        public int Moment { get; set; }

        public int Oborot { get; set; }

        public int Podacha { get; set; }

        public int Davlenie { get; set; }

        public int Speed { get; set; }


    }
}
