using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace flaminhotdoritosnake
{
    public partial class Form1 : Form
    {
        // Global Variables
        Snake FlaminHotDorito, IceColdDorito;
        Food Cheeto;
        bool twoPlayer;
        int flaminWins, iceWins, ties, flaminHighScore, flaminScore;

        SoundPlayer boomSound = new SoundPlayer("boom.wav");
        SoundPlayer eatingSound = new SoundPlayer("doritosCrunch.wav");
        SoundPlayer hamoodSound = new SoundPlayer("hamood.wav");
        SoundPlayer deathSound = new SoundPlayer("boing.wav");

        // Draws a 60x60 grid
        public void drawBoard(Graphics g)
        {

            Point p1, p2, p3, p4;
            p1 = new Point();
            p2 = new Point();
            p3 = new Point();
            p4 = new Point();

            Pen boardPen = new Pen(Color.LightGray, (float)0.5);

            for (int i = 1; i < 60; i++)
            {

                p1.X = i * 10;
                p1.Y = 0;
                p2.X = p1.X;
                p2.Y = 600;

                p3.X = 0;
                p3.Y = i * 10;
                p4.X = 600;
                p4.Y = p3.Y;

                g.DrawLine(boardPen, p1, p2);
                g.DrawLine(boardPen, p3, p4);
            }

        }

        public Form1()
        {
            InitializeComponent();

            hamoodSound.Play();

            // Instantiate
            FlaminHotDorito = new Snake(false);
            IceColdDorito = new Snake(true);
            Cheeto = new Food();

            try
            {
                //check if file exists
                if (File.Exists("gameStats.bin"))
                {

                    //read from file
                    FileStream fs = new FileStream("gameStats.bin", FileMode.Open);
                    BinaryReader binReader = new BinaryReader(fs);

                    flaminWins = binReader.ReadInt32();
                    iceWins = binReader.ReadInt32();
                    ties = binReader.ReadInt32();
                    flaminHighScore = binReader.ReadInt32();
                    binReader.Close();

                }
                else
                {

                    //load default values
                    flaminWins = 0;
                    iceWins = 0;
                    ties = 0;
                    flaminHighScore = 0;

                }

                updateScoreBoard();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        public class BodyPart
        {
            public int pX;
            public int pY;
            public Color bpCol;
            public int bodyDirection;

            //constructors
            public BodyPart()
            {
                pX = 9;
                pY = 9;
                bpCol = Color.Crimson;
                bodyDirection = 2;
            }

            public BodyPart(int x, int y)
            {
                pX = x;
                pY = y;
                bpCol = Color.Crimson;
                bodyDirection = 2;
            }

            public BodyPart(int x, int y, Color col, int dir)
            {
                pX = x;
                pY = y;
                bpCol = col;
                bodyDirection = dir;
            }

            //draw body segments
            public void Draw(Graphics g)
            {

                Point[] triangle = new Point[3];

                if (bodyDirection == 1) // BP direction for up
                {

                    triangle[0].X = pX * 10 + 5;
                    triangle[0].Y = pY * 10;
                    triangle[1].X = pX * 10 + 10;
                    triangle[1].Y = pY * 10 + 10;
                    triangle[2].X = pX * 10;
                    triangle[2].Y = pY * 10 + 10;

                }
                else if (bodyDirection == 2) // BP direction for right
                {

                    triangle[0].X = pX * 10;
                    triangle[0].Y = pY * 10;
                    triangle[1].X = pX * 10 + 10;
                    triangle[1].Y = pY * 10 + 5;
                    triangle[2].X = pX * 10;
                    triangle[2].Y = pY * 10 + 10;

                }
                else if (bodyDirection == 3) // BP direction for down
                {

                    triangle[0].X = pX * 10;
                    triangle[0].Y = pY * 10;
                    triangle[1].X = pX * 10 + 10;
                    triangle[1].Y = pY * 10;
                    triangle[2].X = pX * 10 + 5;
                    triangle[2].Y = pY * 10 + 10;

                }
                else if (bodyDirection == 4) // BP direction for left
                {

                    triangle[0].X = pX * 10;
                    triangle[0].Y = pY * 10 + 5;
                    triangle[1].X = pX * 10 + 10;
                    triangle[1].Y = pY * 10;
                    triangle[2].X = pX * 10 + 10;
                    triangle[2].Y = pY * 10 + 10;

                }

                SolidBrush bodyBrush = new SolidBrush(bpCol);
                g.FillPolygon(bodyBrush, triangle); // Draw

            }
        }

        public class Snake
        {
            private int direction; // Up: 1, Right: 2, Down: 3, Left: 4
            private int originalDir, originalPX, originalPY; // original vals for reset
            List<BodyPart> bodyList = new List<BodyPart>();

            // constructor
            public Snake(bool playerTwo)
            {
                bodyList.Clear();

                BodyPart head = new BodyPart();
                BodyPart body1 = new BodyPart(head.pX - 1, head.pY, head.bpCol, head.bodyDirection);

                if (playerTwo)
                {
                    head.bodyDirection = 4;
                    head.pX = 50;
                    head.pY = 50;
                    head.bpCol = Color.CornflowerBlue;

                    body1.bodyDirection = head.bodyDirection;
                    body1.pX = head.pX + 1;
                    body1.pY = head.pY;
                    body1.bpCol = head.bpCol;
                }

                originalDir = head.bodyDirection;
                direction = head.bodyDirection;
                originalPX = head.pX;
                originalPY = head.pY;

                bodyList.Add(head);
                bodyList.Add(body1);
            }

            // reset function
            public void resetsnake()
            {
                Color col;

                // We do this just in case they change the color
                col = bodyList[0].bpCol;

                bodyList.Clear();

                BodyPart head = new BodyPart(originalPX, originalPY, col, originalDir);
                BodyPart body1;

                // Check which direction it is facing to add one bodypart
                if (originalDir == 1)
                {
                    body1 = new BodyPart(originalPX, originalPY + 1, col, originalDir);
                }
                else if (originalDir == 2)
                {
                    body1 = new BodyPart(originalPX - 1, originalPY, col, originalDir);
                }
                else if (originalDir == 3)
                {
                    body1 = new BodyPart(originalPX, originalPY - 1, col, originalDir);
                }
                else
                {
                    body1 = new BodyPart(originalPX + 1, originalPY, col, originalDir);
                }

                direction = head.bodyDirection;

                bodyList.Add(head);
                bodyList.Add(body1);
            }

            // getters for head xy
            public int GetHeadX()
            {

                if (bodyList.Count == 0)
                {

                    return -1;

                }
                else
                {

                    return bodyList[0].pX;

                }

            }

            public int GetHeadY()
            {

                if (bodyList.Count == 0)
                {

                    return -1;

                }
                else
                {

                    return bodyList[0].pY;

                }

            }

            public void SetDirection(string dir)
            {

                //check which direction facing and set direction

                // If up or down, you can set left or right
                if (direction == 1 || direction == 3)
                {
                    if (dir.ToLower() == "right")
                        direction = 2;
                    else if (dir.ToLower() == "left")
                        direction = 4;
                }
                // If left or right, you can set up or down
                else if (direction == 2 || direction == 4)
                {
                    if (dir.ToLower() == "up")
                        direction = 1;

                    else if (dir.ToLower() == "down")
                        direction = 3;
                }
            }

            public void Move()
            {

                BodyPart newHead;

                int headPosX, headPosY, newHeadPosX, newHeadPosY;

                //get head pos and new head pos
                headPosX = this.GetHeadX();
                headPosY = this.GetHeadY();
                newHeadPosX = headPosX;
                newHeadPosY = headPosY;

                //check facing direction and update position
                if (direction == 1)
                {

                    newHeadPosX = headPosX;
                    newHeadPosY = headPosY - 1;

                }
                else if (direction == 2)
                {

                    newHeadPosX = headPosX + 1;
                    newHeadPosY = headPosY;

                }

                else if (direction == 3)
                {

                    newHeadPosX = headPosX;
                    newHeadPosY = headPosY + 1;

                }
                else
                {

                    newHeadPosX = headPosX - 1;
                    newHeadPosY = headPosY;

                }

                //add new head
                newHead = new BodyPart(newHeadPosX, newHeadPosY);

                // changes color of new head to color of snake
                Color bodyCol = bodyList[0].bpCol;
                newHead.bpCol = bodyCol;

                // Direction for body part;
                newHead.bodyDirection = direction;


                bodyList.Insert(0, newHead);
                bodyList.RemoveAt(bodyList.Count - 1);


            }

            //draw snake
            public void DrawSnake(Graphics g)
            {

                for (int i = 0; i < bodyList.Count; i++)
                {

                    bodyList[i].Draw(g);

                }

            }

            // Checks if food is on the same square as snake's body
            public bool CheckFood(Food food)
            {
                for(int i = 0; i < bodyList.Count(); i++)
                {
                    if(food.getFoodX() == bodyList[i].pX && food.getFoodY() == bodyList[i].pY)
                    {
                        return true;
                    }
                }
                return false;
            }

            public void Grow()
            {
                BodyPart newHead;

                int headPosX, headPosY, newHeadPosX, newHeadPosY;

                //get head pos and new head pos
                headPosX = this.GetHeadX();
                headPosY = this.GetHeadY();
                newHeadPosX = headPosX;
                newHeadPosY = headPosY;

                //check facing direction and update position
                if (direction == 1)
                {

                    newHeadPosX = headPosX;
                    newHeadPosY = headPosY - 1;

                }
                else if (direction == 2)
                {

                    newHeadPosX = headPosX + 1;
                    newHeadPosY = headPosY;

                }

                else if (direction == 3)
                {

                    newHeadPosX = headPosX;
                    newHeadPosY = headPosY + 1;

                }
                else
                {

                    newHeadPosX = headPosX - 1;
                    newHeadPosY = headPosY;

                }

                //add new head
                newHead = new BodyPart(newHeadPosX, newHeadPosY);

                // changes color of new head to color of snake
                Color bodyCol = bodyList[0].bpCol;
                newHead.bpCol = bodyCol;

                // Direction for body part
                newHead.bodyDirection = direction;

                bodyList.Insert(0, newHead);
            }

            public bool CollideSelf()
            {
                // Loop through body list to check for collision
                int headX, headY;
                headX = this.GetHeadX();
                headY = this.GetHeadY();

                for (int i = 1; i < bodyList.Count(); i++)
                {
                    if (bodyList[i].pX == headX && bodyList[i].pY == headY)
                        return true;
                }

                return false;

            }

            public int CollideOther(Snake other)
            {
                // Head to head = tie
                if (this.GetHeadX() == other.GetHeadX() && this.GetHeadY() == other.GetHeadY())
                {

                    return -1;

                }
                // Loop through bodylist to check if snake hit body
                for (int i = 1; i < this.bodyList.Count; i++)
                {

                    if (this.bodyList[i].pX == other.GetHeadX() && this.bodyList[i].pY == other.GetHeadY())
                    {

                        return 1;

                    }

                }

                return 0;

            }

            // Check if snake head collides wall
            public bool CollideWall()
            {
                if (this.GetHeadX() < 0 || this.GetHeadX() > 59 || this.GetHeadY() < 0 || this.GetHeadY() > 59)
                    return true;
                return false;
            }

            public void ChangeColor(Color newColor)
            {
                // Change color of each body part of bodylist
                for (int i = 0; i < bodyList.Count; i++)
                {
                    bodyList[i].bpCol = newColor;
                }
            }

            // Using == and != operators to check if snake ate food
            public static bool operator ==(Snake snake, Food food)
            {
                if (snake.GetHeadX() == food.getFoodX() && snake.GetHeadY() == food.getFoodY())
                    return true;

                else
                    return false;
            }

            public static bool operator !=(Snake snake, Food food)
            {
                if (snake.GetHeadX() != food.getFoodX() && snake.GetHeadY() != food.getFoodY())
                    return true;

                else
                    return false;
            }

        }

        public class Food
        {

            private int fX, fY, originalFX, originalFY;
            Color col;
            Random randgen = new Random();

            //constructors
            public Food()
            {

                fX = 29;
                fY = 29;
                col = Color.Orange;

                originalFX = fX;
                originalFY = fY;

            }

            //setters and getters for food xy
            public int getFoodX()
            {

                return fX;

            }
            public int getFoodY()
            {

                return fY;

            }

            //generate new position
            public void CreateFood()
            {

                fX = randgen.Next(0, 60);
                //fY = randgen.Next(0, 60);
                fY = 15;

            }

            //Reset food pos
            public void ResetFood()
            {
                fX = originalFX;
                fY = originalFY;
            }

            //draw food
            public void Draw(Graphics g)
            {

                SolidBrush foodBrush = new SolidBrush(col);
                g.FillRectangle(foodBrush, fX * 10, fY * 10, 10, 10);

            }

        }

        // Updates all scoreboards
        public void updateScoreBoard()
        {

            txtP1Wins.Text = flaminWins.ToString();
            txtP2Wins.Text = iceWins.ToString();
            txtTies.Text = ties.ToString();
            txtP1HighScore.Text = flaminHighScore.ToString();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //start timer
                gameTimer.Start();

                //toggle button enabled 
                btnPause.Enabled = true;
                btnStart.Enabled = false;
                btnReset.Enabled = true;

                gbSettings.Enabled = false;
                boomSound.Play();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void pbBoard_Paint(object sender, PaintEventArgs e)
        {

            try
            {
                //call draw functions
                drawBoard(e.Graphics);
                Cheeto.Draw(e.Graphics);
                FlaminHotDorito.DrawSnake(e.Graphics);

                if (twoPlayer)
                {
                    IceColdDorito.DrawSnake(e.Graphics);
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        // checks if score is higher than current high score
        public int checkHighScore(int score, int highscore)
        {
            if (score > highscore)
                return score;
            else
                return highscore;
        }

        // methods for win/loss/tie
        public void flaminWin()
        {
            gameTimer.Stop();
            deathSound.Play();
            MessageBox.Show("Flamin Hot Dorito Wins");
            btnReset.PerformClick();
            flaminWins++;
        }
        public void iceColdWin()
        {
        gameTimer.Stop();
        deathSound.Play();
        MessageBox.Show("Ice Cold Dorito Wins");
        btnReset.PerformClick();
        iceWins++;
            
        }
        public void tie()
        {
            gameTimer.Stop();
            deathSound.Play();
            MessageBox.Show("Tie");
            btnReset.PerformClick();
            ties++;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (twoPlayer)
                {
                    // Win/Loss Conditions
                    //check for tie (head on head collision)
                    if (FlaminHotDorito.CollideOther(IceColdDorito) == -1)
                        tie();

                    //check if p1 and p2 hit wall
                    else if (FlaminHotDorito.CollideWall() && IceColdDorito.CollideWall())
                        tie();

                    //check if p1 and p2 both do self collision
                    else if (FlaminHotDorito.CollideSelf() && IceColdDorito.CollideSelf())
                        tie();

                    //check if p1 and p2 collide each other's bodies
                    else if (FlaminHotDorito.CollideOther(IceColdDorito) == 1 && IceColdDorito.CollideOther(FlaminHotDorito) == 1)
                        tie();

                    //check if p2 hit p1 while p1 hit wall
                    else if (FlaminHotDorito.CollideOther(IceColdDorito) == 1 && FlaminHotDorito.CollideWall())
                        tie();

                    //check if p1 hit p2 while p2 hit wall
                    else if (IceColdDorito.CollideOther(FlaminHotDorito) == 1 && IceColdDorito.CollideWall())
                        tie();

                    // check if p1 collide self while p2 collide wall
                    else if (FlaminHotDorito.CollideSelf() && IceColdDorito.CollideWall())
                        tie();

                    // check if p2 collide self while p1 collide wall
                    else if (IceColdDorito.CollideSelf() && FlaminHotDorito.CollideWall())
                        tie();

                    // Check if p1 self collides while p2 hits p1
                    else if (FlaminHotDorito.CollideSelf() && FlaminHotDorito.CollideOther(IceColdDorito) == 1)
                        tie();

                    // Check if p2 self collides while p1 hits p2
                    else if (IceColdDorito.CollideSelf() && IceColdDorito.CollideOther(FlaminHotDorito) == 1)
                        tie();

                    //check if p1 hit wall, self collision, or other collision
                    else if (FlaminHotDorito.CollideWall() || FlaminHotDorito.CollideSelf() || IceColdDorito.CollideOther(FlaminHotDorito) == 1)
                        iceColdWin();

                    //check if p2 hit wall, self collision, or other collision
                    else if (IceColdDorito.CollideWall() || IceColdDorito.CollideSelf() || FlaminHotDorito.CollideOther(IceColdDorito) == 1)
                        flaminWin();

                    //check if food is eaten p1
                    if (FlaminHotDorito == Cheeto)
                    {
                        eatingSound.Play();
                        IceColdDorito.Move();
                        FlaminHotDorito.Grow();

                        Cheeto.CreateFood();

                        // Will loop until food is not on the snakes
                        while (FlaminHotDorito.CheckFood(Cheeto) && IceColdDorito.CheckFood(Cheeto))
                            Cheeto.CreateFood();
                    }
                    //check if food is eaten p1
                    else if (IceColdDorito == Cheeto)
                    {

                        eatingSound.Play();
                        FlaminHotDorito.Move();
                        IceColdDorito.Grow();

                        Cheeto.CreateFood();

                        // Will loop until food is not on the snakes
                        while (FlaminHotDorito.CheckFood(Cheeto) && IceColdDorito.CheckFood(Cheeto))
                            Cheeto.CreateFood();

                    }
                    // Move both snakes
                    else
                    {
                        FlaminHotDorito.Move();
                        IceColdDorito.Move();
                    }
                }
                //for 1 player mode
                else
                {
                    // WIN
                    if (flaminScore == 3598)
                    {
                        gameTimer.Stop();
                        deathSound.Play();
                        MessageBox.Show("WINNER!");

                        // Scoring
                        flaminHighScore = checkHighScore(flaminScore, flaminHighScore);
                        flaminScore = 0;
                        lblScore.Text = "Score: " + flaminScore.ToString();

                        btnReset.PerformClick();
                    }

                    //check for p1 self collision p1 or hit wall
                    if (FlaminHotDorito.CollideSelf() || FlaminHotDorito.CollideWall())
                    {
                        gameTimer.Stop();
                        deathSound.Play();
                        MessageBox.Show("Flamin Hot Dorito Loses");

                        // Scoring
                        flaminHighScore = checkHighScore(flaminScore, flaminHighScore);
                        flaminScore = 0;
                        lblScore.Text = "Score: " + flaminScore.ToString();

                        btnReset.PerformClick();
                    }
                        
                    //check if food is eaten p1
                    if (FlaminHotDorito == Cheeto)
                    {

                        eatingSound.Play();
                        FlaminHotDorito.Grow();

                        // Update score
                        flaminScore++;
                        lblScore.Text = "Score: " + flaminScore.ToString();

                        Cheeto.CreateFood();

                        // Will loop until food is not on the snake
                        while (FlaminHotDorito.CheckFood(Cheeto))
                        {
                            Cheeto.CreateFood();
                            Console.WriteLine("ONTHESNAKE");
                        }

                    }
                    else
                    {
                        FlaminHotDorito.Move();
                    }
                }

                //update outputs
                updateScoreBoard();
                pbBoard.Invalidate();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string Key;

                //get key code
                Key = e.KeyCode.ToString();

                // P1 Controls
                if (Key.ToLower() == "w")
                {

                    FlaminHotDorito.SetDirection("up");

                }
                else if (Key.ToLower() == "d")
                {

                    FlaminHotDorito.SetDirection("right");

                }
                else if (Key.ToLower() == "s")
                {

                    FlaminHotDorito.SetDirection("down");

                }
                else if (Key.ToLower() == "a")
                {

                    FlaminHotDorito.SetDirection("left");

                }

                // P2 Controls
                if (twoPlayer)
                {
                    if (Key.ToLower() == "up")
                    {

                        IceColdDorito.SetDirection("up");

                    }
                    else if (Key.ToLower() == "right")
                    {

                        IceColdDorito.SetDirection("right");

                    }
                    else if (Key.ToLower() == "down")
                    {

                        IceColdDorito.SetDirection("down");

                    }
                    else if (Key.ToLower() == "left")
                    {

                        IceColdDorito.SetDirection("left");

                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                //stop timer
                gameTimer.Stop();

                // enable/disable buttons
                btnStart.Enabled = true;
                btnPause.Enabled = false;
                boomSound.Play();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                //stop timer
                gameTimer.Stop();

                //reset snake(s) and food
                FlaminHotDorito.resetsnake();
                IceColdDorito.resetsnake();
                Cheeto.ResetFood();

                //reset 1 player score if 1 player mode
                if (!twoPlayer)
                {
                    flaminScore = 0;
                    lblScore.Text = "Score: " + flaminScore.ToString();
                }

                // enable/disable buttons
                btnPause.Enabled = false;
                btnStart.Enabled = true;
                btnReset.Enabled = false;
                gbSettings.Enabled = true;

                pbBoard.Invalidate();
                boomSound.Play();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        // For arrow keys
        private void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        // Resets high score
        private void btnResetHighScore_Click(object sender, EventArgs e)
        {
            try
            {
                flaminHighScore = 0;
                txtP1HighScore.Text = flaminHighScore.ToString();
                boomSound.Play();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        // For arrow keys
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(Control control in this.Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //open file and write
                FileStream fs = new FileStream("gameStats.bin", FileMode.Create);
                BinaryWriter binWriter = new BinaryWriter(fs);

                binWriter.Write(flaminWins);
                binWriter.Write(iceWins);
                binWriter.Write(ties);
                binWriter.Write(flaminHighScore);

                binWriter.Flush();
                binWriter.Close();

                // Message when user leaves
                gameTimer.Stop();
                hamoodSound.Play();
                MessageBox.Show("BYE BYE");
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void btnColP1_Click(object sender, EventArgs e)
        {
            try
            {
                boomSound.Play();
                // Changes color of p1 snake to color selected by user
                btnPause.PerformClick();

                cdSnakeColor.ShowDialog();

                Color newColor = cdSnakeColor.Color;
                FlaminHotDorito.ChangeColor(newColor);

                pbBoard.Invalidate();
                pbBoard.Focus();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void btnColP2_Click(object sender, EventArgs e)
        {
            try
            {
                boomSound.Play();
                // Changes color of p1 snake to color selected by user
                btnPause.PerformClick();

                cdSnakeColor.ShowDialog();

                Color newColor = cdSnakeColor.Color;
                IceColdDorito.ChangeColor(newColor);

                pbBoard.Invalidate();
                pbBoard.Focus();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void btnConfirmSettings_Click(object sender, EventArgs e)
        {
            try
            {
                int gameSpeed;

                //get and set game speed
                gameSpeed = Convert.ToInt32(nudGameSpeed.Value);
                gameTimer.Interval = gameSpeed;

                //check which player count is selected
                if (rbTwoPlayer.Checked)
                {

                    twoPlayer = true;
                    lblScore.Visible = false;

                }
                else
                {

                    twoPlayer = false;
                    lblScore.Visible = true;
                    

                }
                pbBoard.Invalidate();
                boomSound.Play();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
