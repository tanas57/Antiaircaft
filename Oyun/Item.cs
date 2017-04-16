using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System;

namespace Oyun
{
    public class Item
    {
        private int width;
        private int height;
        private int left;
        private int top;
        private int speed;
        private string imgPath;
        private byte type;
        private PictureBox IMG;
        private System.Timers.Timer timer;
        public Item()
        {
            this.speed = 1000; // started value
        }
        // set size of object
        public void setSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        // set speed of object
        public void setTime(int milliseconds) { this.speed = milliseconds; }
        // set coordinates
        public void setCoord(int x, int y)
        {
            this.left = y;
            this.top = x;
        }
        // get coordinates
        public int getLeft() { return this.left; }
        public void setLeft(int left) { this.left = left; }
        public int getTop() { return this.top; }
        // getter and setter of picture
        public string getImgPath() { return this.imgPath; }
        public void setIMG(string imgPth) { this.imgPath = imgPth; }
        // stop this object by the timer
        public void stop() { try { this.timer.Stop(); } catch (Exception e) { } }
        // according to informations, create and print this object
        public void createPicture()
        {
            // Set properties of picturebox
            IMG = new PictureBox();
            IMG.Image = Image.FromFile(Application.StartupPath + "\\" + imgPath);
            if(type == 3) // gamer
            {
                IMG.Left = (left < 1) ? 0 : left * 24;
                IMG.Top = top * 20;
            }
            else if(type == 2) // bullet
            {
                IMG.Left = (left < 1) ? 0 : left * 24 - 10;
                IMG.Top = top * 20;
            }
            else // the others : plane and space areas
            {
                IMG.Left = (left < 1) ? 0 : left * 24;
                IMG.Top = (top < 1) ? 55 : top * 21;
            }
            
            IMG.Width = width;
            IMG.Height = height;

            if (type != 3 && type != 4) // the timer can start just plane and bullet
            {
                timer = new System.Timers.Timer(speed);
                timer.Elapsed += new ElapsedEventHandler(changePosition);
                timer.Start();
            }
        }
        public PictureBox getIMG() { return IMG; }
        // movement of objects
        private void changePosition(object o, ElapsedEventArgs a)
        {
            if(type == 1) // the plane goes to down
            {
                if (top >= 18)
                {
                    if (timer.Enabled) stop();
                    Main.gameStart = false;
                }
                else
                {
                    Main.area[top, left] = new Space(top, left);
                    top++;
                    getIMG().Invoke(new MethodInvoker(delegate { getIMG().Top += 18; }));
                    Main.area[top, left] = this;
                }
            }
            else if(type == 2) // the bullet goes to up
            {
                Main.area[top, left] = new Space(top, left);
                if (top > 0) { top--; Main.area[top, left] = this; getIMG().Invoke(new MethodInvoker(delegate { getIMG().Top -= 19; })); }
                else
                {
                    if(timer.Enabled) stop();
                }
            }
        }
        public new byte GetType() { return this.type; }
        public void setType(byte type) { this.type = type; }
    }
}
