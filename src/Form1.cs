using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialUIDemo
{
    public partial class Form1 : Form
    {
        Sorter s;
        int squareLength = 57;
        float cellSize = 10;
        Thread algoThread;
        List<(int, int, Color)> drawCoords = new List<(int, int, Color)>();
        public Form1()
        {
            InitializeComponent();
            s = new Sorter();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetDoubleBuffered(squaresPanel);
            Init(squareLength);
        }

        public void Init(int squareLength)
        {
            //Judge context later
            s.Init(squareLength);
            s.waitTime = (92 - timerTrackBar.Value * 9);
            algorithmSelectorBox.SelectedItem = "Bubble";
        }

        //Method taken from csharp-examples.net
        public static void SetDoubleBuffered(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }


        private void drawGrid(int rows, int cols, float cellSize, Graphics g)
        {
            Pen p = new Pen(Color.ForestGreen, 0.5F);
            for (int y = 0; y < rows+1; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, rows * cellSize, y * cellSize);
            }

            for (int x = 0; x < cols+1; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, cols * cellSize);
            }
        }

        private void gridPanel_Paint(object sender, PaintEventArgs e)
        {
            if(renderGridCheckBox.Checked)
                drawGrid(squareLength, squareLength, cellSize, e.Graphics);
        }

        private void addGridSquare(int x, int y, Color c)
        {
            drawCoords.Add((x, y, c));
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if(me.Button == MouseButtons.Right)
            {
                GlobalConfig.auto = !GlobalConfig.auto;
                return;
            }
            s.Init(squareLength);
            timer1.Start();
            if(algoThread != null)
                algoThread.Abort();
            algoThread = startAlgo();
            algoThread.IsBackground = true;
            algoThread.Start();
            //Valid squares are between 0,0 and 56, 56
            squaresPanel.Refresh();
        }

        private void squaresPanel_Paint(object sender, PaintEventArgs e)
        {
            bool dvg = renderGapsCheckBox.Checked || sortCheckBox.Checked;
            bool dhg = renderGapsCheckBox.Checked;
            if (renderGridCheckBox.Checked)
                dhg = dvg = true;
            Pen p = new Pen(Color.PaleVioletRed, (dhg ? 9.5F : 10F));
            foreach ((int x, int y, Color c) in drawCoords)
            {
                p.Color = c;
                e.Graphics.DrawLine(p, (x * cellSize) + (dvg ? 0.5F : 0), y * cellSize + cellSize / 2, 
                    ((x + 1) * cellSize) - (dvg ? 0.5F : 0), y * cellSize + cellSize / 2);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(s.refreshSemaphore)
                drawCoords = new List<(int, int, Color)>(s.colourInCoords);
            squaresPanel.Refresh();
            gridPanel.Refresh();
            goButton.BackColor = Color.Green;
            goButton.Refresh();
        }

        private void timerTrackBar_Scroll(object sender, EventArgs e)
        {
            s.waitTime = (92 - timerTrackBar.Value * 9);
        }

        //Modify this later to have two halves for pathfinding and sorting
        private Thread startAlgo()
        {
            switch (algorithmSelectorBox.Text)
            {
				case "Bubble":
                    return new Thread(s.bubbleSort);
                case "Selection":
                    return new Thread(s.selectionSort);
                case "Merge":
                    return new Thread(s.mergeSort);

            }
            Console.WriteLine("Error");
            return new Thread(s.selectionSort);
        }

        private void algorithmSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
