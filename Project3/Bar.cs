//Developer: Syedali Nabi
//Calculator Project
//Rogers Fall 2013
//Software Engineering
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace Project3
{
    class Bar : System.Windows.Forms.PictureBox
    {
        public bool isActive = false;
        public int xVal;
        public int yVal;
        //this class extends the picturebox class



        //constructor
        public Bar(int x, int y)
        {
            xVal = x;
            yVal = y;
            this.BackColor = Color.Black;
            this.Location = new Point(x, y);
            this.Height = 10;
            this.Width = 40;
        }

        public void makeVertical()
        {
            this.Height = 40;
            this.Width = 10;
        }

        public void activate()
        {
            this.Visible = true;
            this.BackColor = Color.Black;
        }

        public void deactivate()
        {

            this.Visible = false;
        }
    }
}
