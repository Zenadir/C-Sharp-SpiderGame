using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic_Editor
{
    public partial class Form1 : Form
    {
        
        

        public void Resizebox()
        {
            //Main Box
            int x1 = 50;
            int x2 = ( (Size.Width / 5 * 3) - x1);
            int y1 = 50;
            int y2 = Size.Height - 150;

            this.button2.Location = new System.Drawing.Point(x1, y1);
            this.button2.Size = new System.Drawing.Size(x2, y2);

            // Cordinates
             x1 = ((Size.Width / 5 * 3) - 50) + 100;
             x2 = ( (Size.Width - 50) - x1);
             y1 = 50;
             y2 = Size.Height - 150;

            this.textBox1.Location = new System.Drawing.Point(x1, y1);
            this.textBox1.Size = new System.Drawing.Size(x2, y2);

            //
             x1 = ((Size.Width / 5 * 3) - 50) + 100;
             x2 = 100;
             y1 = 30;
             y2 = 50;

            this.label1.Location = new System.Drawing.Point(x1, y1);
            this.label1.Size = new System.Drawing.Size(x2, y2);



        }
        public Form1()
        {          

            InitializeComponent();

            Resizebox();
                        
        }

        
        static List<GameObject> List;             

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //create a graphics object from the form
            Graphics g = this.CreateGraphics();
            // create  a  pen object with which to draw the line 
            Pen p = new Pen(Color.Red, 7);
            Pen l = new Pen(Color.Black, 10);

            //Test
            g.DrawLine(p, new Point(-5, 100), new Point(100, -5));
            
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = MousePosition.ToString();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Resizebox();
        }


    }
}
