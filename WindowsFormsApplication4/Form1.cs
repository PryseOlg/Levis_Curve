using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        List<Color> colors;
        Color mainColor;
        public Form1()
        {
            InitializeComponent();
        }

        void Draw_Levy(GraphicsPath path, float x1, float x2, float y1, float y2, int i)
        {
            float x3, y3;

            if (i == 0)
                path.AddLine(x1, y1, x2, y2);
            else
            {
                x3 = (x1 + x2) / 2 + (y2 - y1) / 2;
                y3 = (y1 + y2) / 2 - (x2 - x1) / 2;

                Draw_Levy(path, x1, x3, y1, y3, i - 1);
                Draw_Levy(path, x3, x2, y3, y2, i - 1);
            }
        }

        GraphicsPath path = new GraphicsPath();

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pictureBox1.CreateGraphics().DrawPath(new Pen(mainColor), path);
        }

        void Build(int iterations)
        {
            path = new GraphicsPath();
            Draw_Levy(path, 320, 920, 600, 600, iterations);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lvl_up_down.Text = "1";
            mainColor = Color.Black;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            BackColor = Color.White;
            initColors();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            pictureBox1.CreateGraphics().Clear(Color.White);

            int depth = Convert.ToInt32(lvl_up_down.Value);
            if (depth < 1)
            {
                depth = 1;
                lvl_up_down.Value = 1;
            }
            Build(Convert.ToInt32(depth));

            mainColor = colors.ElementAt<Color>(depth - 1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Point p = pictureBox1.PointToClient(MousePosition);
            lvl_up_down.Text = getDepth(p.Y) + "";

        }


        public int getDepth(int Y)
        {
            if (Y > 0 && Y <= 23) return 1;
            if (Y > 23 && Y <= 46) return 2;
            if (Y > 46 && Y <= 76) return 3;
            if (Y > 76 && Y <= 104)  return 4;
            if (Y > 104 && Y <= 130) return 5;
            if (Y > 130 && Y <= 155) return 6;
            if (Y > 155 && Y <= 182) return 7;
            if (Y > 182 && Y <= 208) return 8;
            if (Y > 208 && Y <= 234) return 9;
            if (Y > 234 && Y <= 264) return 10;
            if (Y > 264 && Y <= 289) return 11;
            if (Y > 289 && Y <= 317) return 12;
            if (Y > 317 && Y <= 341) return 13;
            if (Y > 341 && Y <= 369) return 14;
            if (Y > 369 && Y <= 384) return 15;

            return 0;
        }

        public void initColors()
        {
            colors = new List<Color>();
            colors.Add(Color.FromArgb(91, 155, 213)); //1 (Голубой)
            colors.Add(Color.FromArgb(255, 0, 0)); //2 (Красный)
            colors.Add(Color.FromArgb(146, 208, 80)); //3 (Зеленый)
            colors.Add(Color.FromArgb(255,255,0)); //4 (Желтый)
            colors.Add(Color.FromArgb(237, 125, 49)); //5 (Оранжевый)
            colors.Add(Color.FromArgb(112, 48, 160)); //6 (Фиолет)
            colors.Add(Color.FromArgb(192, 0, 0)); //7 (Темно красный)
            colors.Add(Color.FromArgb(0, 254, 254)); //8 (Бирюзовый)
            colors.Add(Color.FromArgb(0, 0, 0)); //9 (Черный)
            colors.Add(Color.FromArgb(127, 127, 127)); //10 (Серый)
            colors.Add(Color.FromArgb(0, 32, 96)); //11 (Синий)
            colors.Add(Color.FromArgb(163, 191, 0)); //12 (Салатовый)
            colors.Add(Color.FromArgb(255, 40, 148)); //13 (Розовый)
            colors.Add(Color.FromArgb(255, 192, 0)); //14 (Желто-Оранжевый)
            colors.Add(Color.FromArgb(0, 112, 192)); //15 (Темно голубой)
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
