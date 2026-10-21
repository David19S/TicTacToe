using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int current = 1;
        int starting = 1;
        int okk = 1;
        int[,] a = new int[3, 3];
        int x, y;
        int i , j;
        int final = 0 ;
        int cx = 0, c0 = 0;
        
        private void button1_Click(object sender, EventArgs e)
        {
            starting = 3 - starting;
            current = starting;
            final = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    a[i, j] = 0;
            panel1.Enabled = true;
            panel1.Refresh();

            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.AliceBlue, 3);
            g.DrawLine(pen,133,0,133,400);
            g.DrawLine(pen, 266, 0, 266, 400);
            g.DrawLine(pen, 0, 133, 400, 133);
            g.DrawLine(pen, 0, 266, 400, 266);

            UpdateTurnLabel();
            button1.Enabled = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.X < 133 && e.Y < 133)
            {
                x = 15;
                y = 15;
                i = 0;
                j = 0;
            }
            else if (e.X < 133 && e.Y > 133 && e.Y < 266)
            {
                x = 15;
                y = 15 + 133;
                i = 1;
                j = 0;
            }
            else if (e.X < 133 && e.Y > 266)
            {
                x = 15;
                y = 15 + 266;
                i = 2; j = 0;
            }
            else if (e.X > 133 && e.X < 266 && e.Y < 133)
            {
                x = 15 + 133;
                y = 15;
                i = 0; j = 1;
            }
            else if (e.X > 133 && e.X < 266 && e.Y > 133 && e.Y < 266)
            {
                x = 15 + 133;
                y = 15 + 133;
                i = 1; j = 1;
            }
            else if (e.X > 133 && e.X < 266 && e.Y > 266)
            {
                x = 15 + 133;
                y = 15 + 266;
                i = 2; j = 1;
            }
            else if (e.X > 266 && e.Y < 133)
            {
                x = 15 + 266;
                y = 15;
                i = 0; j = 2;
            }
            else if (e.X > 266 && e.Y > 133 && e.Y < 266)
            {
                x = 15 + 266;
                y = 15 + 133;
                i = 1; j = 2;
            }
            else if (e.X > 266 && e.Y > 266)
            {
                x = 15 + 266;
                y = 15 + 266;
                i = 2; j = 2;
            }
            if (current == 1)
            {
                if (a[i, j] == 0)
                {
                    drawx();
                    a[i, j] = 1;
                }
            }
            else
            {
                if (a[i, j] == 0)
                {
                    draw0();
                    a[i, j] = 2;
                }
            }
            vfx();
            vf0();
            vfe();
            if (final != 0)
            {
                EndGame();
                return;
            }
            current = 3 - current;
            UpdateTurnLabel();
        }
        private void EndGame()
        {
            if (final == 1)
            {
                cx++;
                label6.Text = "" + cx;
                MessageBox.Show("Player 1 a castigat");
            }
            else if (final == 2)
            {
                c0++;
                label7.Text = "" + c0;
                MessageBox.Show("Player 2 a castigat");
            }
            else
            {
                MessageBox.Show("Egalitate");
            }
            ResetBoard();
        }
        private void ResetBoard()
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    a[i, j] = 0;
                }
            }
            panel1.Refresh();
            starting = 3 - starting;
            current = starting;
            final = 0;
            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.AliceBlue, 3);
            g.DrawLine(pen, 133, 0, 133, 400);
            g.DrawLine(pen, 266, 0, 266, 400);
            g.DrawLine(pen, 0, 133, 400, 133);
            g.DrawLine(pen, 0, 266, 400, 266);
            UpdateTurnLabel();
        }
        private void draw0()
        {
            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.AliceBlue, 8);
            Rectangle rec = new Rectangle(x,y,100,100);
            g.DrawEllipse(pen, rec);
        }
        private void drawx()
        {
            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.AliceBlue, 8);
            Point p1 = new Point(x, y);
            Point p2 = new Point(x+100, y+100);
            Point p3  = new Point(x+100, y);
            Point p4 = new Point(x, y + 100);
            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p3, p4);
        }
        private void UpdateTurnLabel()
        {
            if (current == 1)
            {
                label5.Text = "Player1";
            }
            else
            {
                label5.Text = "Player2";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            starting = 2;
            
            panel1.Enabled = false;
        }
        private void vfx()
        {
            for (int d = 0; d <= 2; d++)
            {
                if (a[d, 0] == 1 && a[d, 1] == 1 && a[d, 2] == 1)
                {
                    final = 1;
                }
                if (a[0,d]==1 && a[1,d]==1 && a[2, d] == 1)
                {
                    final = 1;
                }
                
            }
            if (a[0, 0] == 1 && a[1, 1] == 1 && a[2, 2] == 1)
            {
                final = 1;
            }
            if (a[0, 2] == 1 && a[2, 0] == 1 && a[1, 1] == 1)
            {
                final = 1;
            }


        }
        private void vf0()
        {
            for (int d = 0; d <= 2; d++)
            {
                if (a[d, 0] == 2 && a[d, 1] == 2 && a[d, 2] == 2)
                {
                    final = 2;
                }
                if (a[0, d] == 2 && a[1, d] == 2 && a[2, d] == 2)
                {
                    final = 2;
                }

            }
            if (a[0, 0] == 2 && a[1, 1] == 2 && a[2, 2] == 2)
            {
                final = 2;
            }
            if (a[0, 2] == 2 && a[2, 0] == 2 && a[1, 1] == 2)
            {
                final = 2;
            }
        }
        private void vfe()
        {
            if (final != 0)
                return;

            bool tablaPlina = true;

            for (int i = 0;i<=2;i++)
            {
                for (int j = 0; j<=2;j++)
                {
                    if (a[i,j] == 0)
                    {
                        tablaPlina = false;
                        break;
                    }
                }
                if (!tablaPlina)
                    break;
            }

            if (tablaPlina)
            {
                final = 3;   
            }
        }
        
    }
}
