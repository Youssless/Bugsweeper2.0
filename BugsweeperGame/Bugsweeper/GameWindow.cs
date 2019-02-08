using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bugsweeper {
    public partial class GameWindow : Form {
        class LeaderboardSystem {
            private string name;
            private TextBox time;
            private System.IO.FileStream f;
            
        }
        class GameSquare : Button
        {
            private int x;
            private int y;
            private int noOfContiguosBugSquares; //left, right, bottom, above, and all contiguous diagonal squares
            //private static int squaresShownCount = 0;
            private bool isRevealed = false;
            private bool isBugPresent;
            private bool isFlagged;

            public void setX(int x) {this.x = x;}
            public int getX() {return this.x;}

            public void setY(int y) {this.y = y;}
            public int getY() {return this.y;}

           // public int getCount() { return squaresShownCount; }
            
            public void setIsBugPresent(bool isBugPresent) {this.isBugPresent = isBugPresent;}
            public bool getIsBugPresent() { return isBugPresent; }

            public void setIsRevealed(bool isRevealed) { this.isRevealed = isRevealed; }
            public bool getIsRevealed() { return this.isRevealed; }

            public void setNoOfContiguosBugSquares (int noOfContiguosBugSquares) {this.noOfContiguosBugSquares = noOfContiguosBugSquares;}
            public int getNoOfContiguosBugSquares(){return this.noOfContiguosBugSquares;}

            public bool getIsFlagged() { return isFlagged; }
            public void setIsFlagged(bool isFlagged) { this.isFlagged = isFlagged; }
        }

        class GameTimer : Timer
        {
            private bool isTimerOn;

            public void setIsTimerOn(bool isTimerOn)
            {
                this.isTimerOn = isTimerOn;
            }

            public bool getIsTimerOn()
            {
                return isTimerOn;
            }
        }

        private int x;
        private int y;
        private int noOfGameSquares;
        private int counter;
        private int totalFlags;
        private int squareShownCount;

        private String sec;
        private String min;
        bool isFlagBtnClicked;

        private GameSquare[,] btns;
        private GameTimer gameTimer;
        private DateTime s;
        private Random rnd = new Random();

        private int noOfBugs;
        private float bugToSquareRatio = 0.2f; // > 0 & < 1

        public GameWindow() {
            InitializeComponent();
            x = 5;
            y = 5;

            btns = new GameSquare[x, y];
            gameTimer = new GameTimer();
            gameTimer.setIsTimerOn(true);
            counter = 0;
            totalFlags = 20;
            isFlagBtnClicked = false;
            squareShownCount = 0;
        }

        private void GameWindow_Load(object sender, EventArgs e) {
            // disabling maximize button and loading the grid
            this.BackColor = Color.GhostWhite;
            timerBox.BackColor = Color.GhostWhite;
            timerBox.BorderStyle = BorderStyle.None;
            this.MaximizeBox = false;
            timerBox.SelectionStart = 0;

            gridGen(x, y);

            noOfGameSquares = x * y;
            noOfBugs = (int)(noOfGameSquares * bugToSquareRatio);

            placeBugsRandom(noOfBugs);
            calculateNoOfContiguosBugSquares();
            
        }


        private void btnShow_Click(object sender, EventArgs e) {
            // if the timer is not already on then start the timer
            GameSquare gameSquareSender = sender as GameSquare;
            int x = gameSquareSender.getX();
            int y = gameSquareSender.getY();

            if (!gameTimer.getIsTimerOn())
            {
                s = DateTime.Now;
                gameTimer.Start();
                gameTimer.Interval = 1000;
                gameTimer.Tick += new EventHandler(timer_Tick);
                gameTimer.Enabled = true;
                gameTimer.setIsTimerOn(true);
            }

            if (isFlagBtnClicked)
            {
                btns[x, y].BackgroundImage = flagBtn.BackgroundImage;
                Console.WriteLine("[" + x + ", " + y + "]");
                isFlagBtnClicked = false;
                flagCheck(gameSquareSender);
                btns[x, y].setIsFlagged(true);
            }
            else
                revealSquares(gameSquareSender);
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e) {
            GameSquare gameSquareSender = sender as GameSquare;

            if (e.Button == MouseButtons.Right && !gameSquareSender.getIsRevealed())
            {
                flagCheck(gameSquareSender);
            }
        }

        private void flagCheck(GameSquare gameSquareSender) {
            int x = gameSquareSender.getX();
            int y = gameSquareSender.getY();

            btns[gameSquareSender.getX(), gameSquareSender.getY()].BackgroundImage = flagBtn.BackgroundImage;
            Console.WriteLine("[" + x + ", " + y + "]");

            if (gameSquareSender.getIsFlagged() || isFlagBtnClicked)
            {
                btns[x, y].BackgroundImage = null;
                btns[x, y].setIsFlagged(false);
                btns[x, y].Enabled = true;
                btns[x, y].BackColor = Color.LightGray;
                counter--;
                flagCounter.Text = counter.ToString("#/") + totalFlags.ToString();
                isFlagBtnClicked = false;
            }
            else if (btns[x, y].BackgroundImage.Equals(flagBtn.BackgroundImage))
            {
                //btns[x, y].Enabled = false;
                btns[x, y].BackColor = Color.Yellow;
                //isFlagPlaced = true;
                counter++;
                flagCounter.Text = counter.ToString("#/") + totalFlags.ToString();
                gameSquareSender.setIsFlagged(true);
            }
            else
                revealSquares(gameSquareSender);

        }

        private void gameEndCheck() {
            ExtPopup endPopup;
            if ((noOfGameSquares - noOfBugs) == squareShownCount)
            {
                endPopup = new ExtPopup("WINNER!", "Congratulations, all flagged bugs will be sent to the project leader");
            }
            else
            {
                endPopup = new ExtPopup("Looser", "You have not found all the bugs");
            }
                

        }

        private void flagBtn_Click(object sender, EventArgs e) {
            isFlagBtnClicked = true;
        }

        private void timer_Tick(object sender, EventArgs e) {
            TimeSpan timePassed = DateTime.Now - s;
            min = timePassed.Minutes.ToString("0#");
            sec = timePassed.Seconds.ToString("0#");

            timerBox.Text = min + " : " + sec;
            //timerBox.Update();
        }

        private void gridGen(int x, int y)
        {
            int count = 0;
            for (int i = 0; i < this.y; i++)
            {
                for (int j = 0; j < this.x; j++)
                {
                    // positioning and sizing the buttons
                    btns[i, j] = new GameSquare();
                    btns[i, j].Size = new Size(20, 20);
                    btns[i, j].Location = new Point(i * 19 + 183, j * 19 + 20);
                    btns[i, j].Margin = new Padding(0);
                    btns[i, j].setX(i);
                    btns[i, j].setY(j);
                    btns[i, j].Font = new Font(Button.DefaultFont, FontStyle.Bold);

                    // adding handlers to the buttons - btnShow_Click()
                    btns[i, j].Click += new EventHandler(btnShow_Click);
                    btns[i, j].MouseDown += new MouseEventHandler(btnDown_MouseDown);
                    btns[i, j].AllowDrop = true;

                    // styling the buttons 
                    btns[i, j].FlatStyle = FlatStyle.Popup;
                    btns[i, j].FlatAppearance.BorderColor = Color.White;
                    btns[i, j].BackColor = Color.LightGray;
                    btns[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    // add buttons to window and bring in front of the image 
                    Controls.Add(btns[i,j]);
                    btns[i, j].BringToFront();

                    // btns count
                    if (this.Contains(btns[i, j]))
                        count++;
                }
            }

            // output to the console if all btns are generated
            if (count == (x * y))
                Console.WriteLine("Success: Grid generated");
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void timerBox_TextChanged(object sender, EventArgs e) {
            Update();
        }

        private void placeBugsRandom(int noOfBugs)
        {
            int x;
            int y;

            for (int i=0; i<noOfBugs; i++)
            {

                do
                {
                    x = rnd.Next(0, this.x);
                    y = rnd.Next(0, this.y);

                } while (btns[x, y].getIsBugPresent() == true);

                btns[x, y].setIsBugPresent(true);
                //btns[x, y].BackColor = Color.OrangeRed;
            }
        }

        void calculateNoOfContiguosBugSquares()
        {

            int noOfContingentBugSquares;

            for (int i = 0; i < this.y; i++)
            {
                for (int j = 0; j < this.x; j++)
                {
                    noOfContingentBugSquares = 0;
                    if (i>0)
                    {
                        if (btns[i - 1, j].getIsBugPresent() == true)
                            noOfContingentBugSquares++;
                        if (j < this.y - 1)
                        {
                            if (btns[i - 1, j + 1].getIsBugPresent() == true)
                                noOfContingentBugSquares++;
                        }
                        
                        if (j > 0)
                        {
                            if (btns[i - 1, j - 1].getIsBugPresent() == true)
                                noOfContingentBugSquares++;
                        } 
                    }
                    
                    if (i < this.x-1)
                    {
                        if (btns[i + 1, j].getIsBugPresent() == true)
                            noOfContingentBugSquares++;

                        if (j<this.y-1)
                        {
                            if (btns[i + 1, j + 1].getIsBugPresent() == true)
                                noOfContingentBugSquares++;
                        }
                        
                        if (j>0)
                        {
                            if (btns[i + 1, j - 1].getIsBugPresent() == true)
                                noOfContingentBugSquares++;
                        }
                    }

                    if (j<this.y-1)
                    {
                        if (btns[i, j + 1].getIsBugPresent() == true)
                            noOfContingentBugSquares++;
                    }
                    
                    if (j>0)
                    {
                        if (btns[i, j - 1].getIsBugPresent() == true)
                            noOfContingentBugSquares++;
                    }

                    

                    btns[i, j].setNoOfContiguosBugSquares(noOfContingentBugSquares);
                    //btns[i, j].Text = noOfContingentBugSquares.ToString();
                }
            }
        }

        private void revealSquares(GameSquare gameSquareSender)
        {

            int x = gameSquareSender.getX();
            int y = gameSquareSender.getY();

            if (!gameSquareSender.getIsRevealed()) {
                if (!gameSquareSender.getIsFlagged())
                {
                    if (gameSquareSender.getIsBugPresent() == true)
                    {

                        gameTimer.Stop();
                        s = DateTime.Now;
                        gameSquareSender.BackColor = Color.Red;
                        ExtPopup gameOverPopup = new ExtPopup("Game Over!", "You fixed a bug without notice, you're fired!!!");
                        gameOverPopup.ShowDialog();

                        //if (result == DialogResult.Retry)
                        //{
                        //resetGameControls();
                        //counter = 0;
                        //  flagCounter.Text = counter.ToString("0/") + totalFlags.ToString();
                        //}

                    }
                    else
                    {
                        if (gameSquareSender.getNoOfContiguosBugSquares() == 0)
                        {
                            gameSquareSender.setIsRevealed(true);
                            gameSquareSender.BackColor = Color.WhiteSmoke;
                            squareShownCount++;
                            Console.WriteLine(squareShownCount);

                            if (x + 1 < this.x)
                            {

                                if (btns[x + 1, y].getIsRevealed() == false)
                                {
                                    btns[x + 1, y].PerformClick();
                                }


                                if (y > 0)
                                {
                                    if (btns[x + 1, y - 1].getIsRevealed() == false)
                                    {
                                        btns[x + 1, y - 1].PerformClick();
                                    }
                                }

                                if (y < this.y - 1)
                                {
                                    if (btns[x + 1, y + 1].getIsRevealed() == false)
                                    {
                                        btns[x + 1, y + 1].PerformClick();
                                    }
                                }
                            }

                            if (x > 0)
                            {
                                if (btns[x - 1, y].getIsRevealed() == false)
                                {
                                    btns[x - 1, y].PerformClick();
                                }

                                if (y > 0)
                                {
                                    if (btns[x - 1, y - 1].getIsRevealed() == false)
                                    {
                                        btns[x - 1, y - 1].PerformClick();
                                    }
                                }

                                if (y < this.y - 1)
                                {
                                    if (btns[x - 1, y + 1].getIsRevealed() == false)
                                    {
                                        btns[x - 1, y + 1].PerformClick();
                                    }
                                }
                            }

                            if (y + 1 < this.y)
                            {
                                if (btns[x, y + 1].getIsRevealed() == false)
                                {
                                    btns[x, y + 1].PerformClick();
                                }

                            }

                            if (y > 0)
                            {
                                if (btns[x, y - 1].getIsRevealed() == false)
                                {
                                    btns[x, y - 1].PerformClick();
                                }
                            }

                        }
                        else
                        {
                            squareShownCount++;
                            Console.WriteLine(squareShownCount);
                            btns[x, y].Text = (btns[x, y].getNoOfContiguosBugSquares()).ToString();
                            btns[x, y].setIsRevealed(true);
                            btns[x, y].BackColor = Color.WhiteSmoke;
                        }
                    }
                }
            }
            
            gameEndCheck();
        }

        private void resetGameControls()
        {
            for (int i = 0; i < this.y; i++)
            {
                for (int j = 0; j < this.x; j++)
                {
                    //reset GameSquare buttons
                    btns[i, j].Text = "";
                    btns[i, j].BackColor = Color.LightGray;
                    btns[i, j].setIsRevealed(false);
                    btns[i, j].setIsBugPresent(false);
                    btns[i, j].setNoOfContiguosBugSquares(0);

                    if (btns[i, j].getIsFlagged())
                    {
                        btns[i, j].BackgroundImage = null;
                    }
                }
            }

            //reset timer
            gameTimer.Stop();
            //timerBox.Text = "00 : 00";
            gameTimer.setIsTimerOn(false);

            //setup game
            placeBugsRandom(noOfBugs);
            calculateNoOfContiguosBugSquares();
        }

        private void showMenuControls()
        {

        }

        private void hideMenuControls()
        {

        }

        private void showGameControls()
        {
            for (int i = 0; i < this.y; i++)
            {
                for (int j = 0; j < this.x; j++)
                {
                    btns[i, j].Show();
                }
            }
        }

        private void hideGameControls()
        {
            for (int i = 0; i < this.y; i++)
            {
                for (int j = 0; j < this.x; j++)
                {
                    btns[i, j].Hide();
                }
            }
        }

        private void flagCounter_TextChanged(object sender, EventArgs e)
        {
            //if (counter > 19) {
              //  flagCounter
            //}
        }
    }         
}