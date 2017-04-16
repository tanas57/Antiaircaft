using System;
using System.Windows.Forms;

namespace Oyun
{
    public partial class Main : Form
    {
        // game area informations
        public static Item[,] area;
        private int rows;
        private int cols;
        private Gamer gamer;
        public static bool gameStart = false;
        public static int score = 0;
        public Main()
        {
            InitializeComponent();
            rows = 20; cols = 30;
            area = new Item[rows, cols];
            makeEmpty();
            gamer = new Gamer(19, 15);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Score.Text = "0";
            status.Text = "Oyunu bitti |  Skor : ";
        }
        private void control()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if(area[i,j].GetType() == 1)
                    {
                        bool shutted = false;
                        // if the plane is 5.5:, we look areas => 4,4 4,5 4,6 5,4 5,5 5,6 6,4 6,5 6,6
                        for (int a = i - 1; a < i + 3; a++)
                        {
                            for (int b = j - 1; b < j + 3; b++)
                            {
                                if(a > 0 && a < rows && b > 0 && b < cols ) // must not out of board
                                {
                                    if(area[a,b].GetType() == 2)
                                    {
                                        shutted = true;
                                        area[i, j].stop();
                                        area[a, b].stop();
                                        area[i, j].getIMG().Visible = false;
                                        area[a, b].getIMG().Visible = false;
                                        // makes area space
                                        area[i, j] = new Space(i, j);
                                        area[a, b] = new Space(a, b);
                                    }
                                }
                            }
                        }
                        if(shutted) { score++; shutted = false; }
                    }
                }
            }
        }
        // create a new plane
        private void createPlane()
        {
            Random rd = new Random();
            int random = 0, counter = 0;
            bool control = true;
            while (true)
            {
                random = rd.Next(0, 30);
                // planes must not be over the top
                for (int i = 0; i < 7; i++)
                {
                    if (area[i, random].GetType() == 1 || area[i, random].GetType() == 2)
                    {
                        control = false;
                        break;
                    }
                }
                if (control) break;
                counter++;
                if (counter > 3) break;
            }

            if (control)
            {
                Plane ucak = new Plane(0, random);
                area[0, random] = ucak;
                this.Controls.Add(ucak.getIMG());
            }

        }
        public static Item[,] getBoard() { return area; }
        // firstly, make empty all areas
        private void makeEmpty()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    area[i, j] = new Space(i, j); // space
                }
            }
            area[19, 15] = gamer; // the gamer is located
        }
        public void Start()
        {
            Score.Text = "0";
            status.Text = "Oyun başladı |  Skor : ";
            gameStart = true;
            getPlane.Start();
            update.Start();
        }
        private void Stop()
        {
            update.Stop();
            getPlane.Stop();
            status.Text = "Oyun bitti |  Skor : ";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if(area[i,j].GetType() == 2 || area[i, j].GetType() == 1)
                    {
                        area[i, j].stop(); // if the game is over, all objects must be stagnant
                    }
                }
            }
        }
        private void Clear()
        {
            // clear form controls,and print panel1
            this.Controls.Clear();
            this.panel1 = new Panel();
            this.Score = new Label();
            this.gameInfo = new Label();
            this.status = new Label();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.Score);
            this.panel1.Controls.Add(this.gameInfo);
            this.panel1.Controls.Add(this.status);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 55);
            this.panel1.TabIndex = 4;
            // 
            // Score
            // 
            this.Score.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.ForeColor = System.Drawing.Color.Lime;
            this.Score.Location = new System.Drawing.Point(645, 15);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(47, 17);
            // 
            // gameInfo
            //
            this.gameInfo.ForeColor = System.Drawing.Color.White;
            this.gameInfo.Location = new System.Drawing.Point(3, 3);
            this.gameInfo.Name = "gameInfo";
            this.gameInfo.Size = new System.Drawing.Size(369, 45);
            this.gameInfo.Text = "Oyunu başlatmak için ENTER tuşuna basın.\r\nUçaksavar\'ı hareket ettirmek için SAĞ v" +
    "e SOL yön tuşlarını kullanın.\r\nAteş etmek için BOŞLUK tuşunu basın.\r\n";
            // 
            // status
            this.status.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.status.Location = new System.Drawing.Point(535, 17);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(124, 15);
            this.status.TabIndex = 1;
            this.status.Text = "Oyun başladı |  Skor : ";

            this.Controls.Add(panel1);
        }
        // refresh game area
        private void update_Tick(object sender, EventArgs e)
        {
            control();
            Score.Text = score.ToString();
            if (!gameStart) Stop();
        }
        // according to randomly time, create a new plane
        private void getPlane_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            createPlane();
            getPlane.Interval = rd.Next(1000, 5000);
        }
        // keyboard control
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !gameStart)
            {
                makeEmpty();
                Clear();
                this.Controls.Add(gamer.getIMG());
                score = 0;
                Start();
            }
            else if (e.KeyCode == Keys.Space && gameStart)
            {
                bool control = true;
                for (int i = gamer.getTop() - 1; i < 13; i--)
                {
                    if (area[i, gamer.getLeft() + 1].GetType() == 2) { control = false; break; }
                }
                if (control)
                {
                    Bullet mermi = new Bullet(gamer.getTop() - 1, (gamer.getLeft() + 1) < cols ? (gamer.getLeft() + 1) : cols - 1);
                    area[gamer.getTop() - 1, (gamer.getLeft() + 1) < cols ? (gamer.getLeft() + 1) : cols - 1] = mermi;
                    this.Controls.Add(mermi.getIMG());
                }
            }
            else if (e.KeyCode == Keys.Right && gameStart)
            {
                if (gamer.moveRight())
                {
                    gamer.getIMG().Invoke(new MethodInvoker(delegate { gamer.getIMG().Left += 24; }));
                }
            }
            else if (e.KeyCode == Keys.Left && gameStart)
            {
                if(gamer.moveLeft())
                {
                    gamer.getIMG().Invoke(new MethodInvoker(delegate { gamer.getIMG().Left -= 24; }));
                }
            }
        }
    }
}