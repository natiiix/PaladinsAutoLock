using System;
using System.Drawing;
using System.Windows.Forms;
using NatiTools.xGraphics;
using NatiTools.xIO;

namespace PaladinsAutoLock
{
    public partial class FormMain : Form
    {
        private const int OFFSET_X = 400;
        private const int OFFSET_Y = 200;

        private const int TARGET_RADIUS = 20;
        private const float TARGET_THICKNESS = 3.5f;

        private Brush TARGER_BRUSH = new SolidBrush(Color.Blue);
        private Pen TARGER_PEN = new Pen(Color.Red, TARGET_THICKNESS);

        private const int COLOR_TOLERANCE = 10;

        private int ClickX = 0;
        private int ClickY = 0;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerCheckScreen.Stop();
        }

        private void pictureBoxChampionSelect_MouseClick(object sender, MouseEventArgs e)
        {
            // Set the click location
            if (e.Button == MouseButtons.Left)
            {
                selectChampion(e.X, e.Y);
            }
            // Clear the click location
            else if (e.Button == MouseButtons.Right)
            {
                clearSelection();
            }
        }

        private void timerCheckScreen_Tick(object sender, EventArgs e)
        {
            using (Bitmap bmpScreen = GraphicsTools.takeScreenshot())
            {
                // Check if we're on the champion select screen
                if (checkPixel(bmpScreen, 1733, 205, 249, 222, 221) &&
                    checkPixel(bmpScreen, 1860, 220, 3, 221, 237) &&
                    checkPixel(bmpScreen, 20, 20, 17, 58, 169) &&
                    checkPixel(bmpScreen, 1900, 900, 125, 27, 43))
                {
                    // Select the champion
                    Mouse.LeftClick(ClickX, ClickY);

                    // Champion should be selected now, go back to the default state
                    clearSelection();
                }
            }
        }

        private bool checkPixel(Bitmap bmp, int x, int y, int r, int g, int b)
        {
            Color c = bmp.GetPixel(x, y);
            return (
                c.R >= r - COLOR_TOLERANCE && c.R <= r + COLOR_TOLERANCE &&
                c.G >= g - COLOR_TOLERANCE && c.G <= g + COLOR_TOLERANCE &&
                c.B >= b - COLOR_TOLERANCE && c.B <= b + COLOR_TOLERANCE);
        }

        private void selectChampion(int x, int y)
        {
            ClickX = OFFSET_X + x;
            ClickY = OFFSET_Y + y;

            pictureBoxChampionSelect.Refresh();

            Graphics g = pictureBoxChampionSelect.CreateGraphics();
            Rectangle rectTarget = new Rectangle(x - TARGET_RADIUS, y - TARGET_RADIUS, TARGET_RADIUS << 1, TARGET_RADIUS << 1);

            g.FillEllipse(TARGER_BRUSH, rectTarget);
            g.DrawEllipse(TARGER_PEN, rectTarget);
            g.DrawLine(TARGER_PEN, x - TARGET_RADIUS, y, x + TARGET_RADIUS, y);
            g.DrawLine(TARGER_PEN, x, y - TARGET_RADIUS, x, y + TARGET_RADIUS);

            timerCheckScreen.Start();
        }

        private void clearSelection()
        {
            timerCheckScreen.Stop();

            pictureBoxChampionSelect.Refresh();

            ClickX = ClickY = 0;
        }
    }
}
