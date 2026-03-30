using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_Graphics
{
    public partial class Form1 : Form
    {
        List<MyLine> Lines = new List<MyLine>();
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;

            //default values for Pen
            buttonColor.BackColor = Color.Black;
            numericUpDownWidth.Value = 5;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);

            e.Graphics.DrawString("Example of text", new Font("Arial", 16), Brushes.Black, 100, 100);

            foreach (MyLine line in Lines)
            {
                for (int i = 0; i < line.Count - 1; i++)
                {
                    e.Graphics.DrawLine(line.Pen, line[i], line[i + 1]);
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = e.Location.ToString();

            if (e.Button == MouseButtons.Left)
            {
                Lines.Last().AddPoint(e.Location);
                Invalidate();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Pen myPen = new Pen(buttonColor.BackColor, (int)numericUpDownWidth.Value);
                myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                myPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                Lines.Add(new MyLine(myPen));
                Lines.Last().AddPoint(e.Location);
                Invalidate();
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = buttonColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                buttonColor.BackColor = cd.Color;
            }
        }
    }
}
