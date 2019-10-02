using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            panel1.Size = new Size() { Width = 100, Height = 1200 };
            panel1.Top = 5;
            panel1.Left = 10;
            //panel1.Width = 100;

            panel2.Height = frm.Height;
            panel2.Top = 5;
            panel2.Left = 120;
            panel2.Width = 200;

            i = 1;

            panel2.Width = diModel.Max(d => d.VesDown)+10;

            panel1.Refresh();
            panel2.Refresh();

            int gX1 = 0; int gY1 = 0;
            int gX2 = 0; int gY2 = 0;

            Graphics g2 = panel2.CreateGraphics();
            g2.PageUnit = GraphicsUnit.Pixel;
            g2.PageScale = 0.7F;

            foreach (DiModel di in diModel) {

                int y = i * 13;

                DiModel next = diModel.Where(d => d.Dt > di.Dt).FirstOrDefault();              


                SolidBrush sbr = new SolidBrush(Color.Black);
                Graphics g = panel1.CreateGraphics();
                FontFamily fam = new FontFamily("Tahoma");
                Font font = new System.Drawing.Font(fam, 8, FontStyle.Regular);
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
