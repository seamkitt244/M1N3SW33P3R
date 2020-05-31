using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace M1N3SW33P3R
{
    public partial class GameScreen : UserControl
    {
        private GameScreen gameArea;
        form1 form = new form1();
        public static int blockXOrg = 10;
        int blockX = 10;
        int blockY = 60;
        int blockSize = 30;
        int numMines = 0;
        Boolean mine, clicked = false;
        Boolean firstClick = true;
        Brick brick;
        Blocks block;

        int mineCount = 0;
        public GameScreen(int boardSize)
        {
            InitializeComponent();
            OnStart();
        }
        List<Button> buttonList = new List<Button>();
        List<Blocks> blocksList = new List<Blocks>();
        Blocks tempBlock;

        int gridSize = 100;
        int gridLength = 10;

        int numOfMines = 10;
        PictureBox tempPictureBox = new PictureBox();

        int rows = 10;
        int columns = 10;

        //stopwatch
        Stopwatch stopwatch = new Stopwatch();
        TimeSpan elapsed;
        int pause = 0;
        int theme = 0;
        public void OnStart()
        {
            blocksList.Clear();
            buttonList.Clear();
            for (int i = 0; i < gridLength * gridLength; i++)
            {
                if (blockX > blockXOrg + (gridLength * blockSize) - blockSize)
                {
                    blockX = blockXOrg;
                    blockY = blockY + blockSize;
                }
                Blocks tempBlock = new Blocks(blockSize, blockX, blockY, numMines, mine, clicked);
                blocksList.Add(tempBlock);
                blockX = blockX + blockSize;
            }
            MakeMines();
            PlaceNumbers();
            int n = 0;
            foreach (Blocks b in blocksList)//creating buttons
            {
                Button button = new Button
                {
                    Name = "button" + blocksList[n],
                    Size = new Size(blockSize, blockSize),
                    Location = new Point(b.x, b.y),
                    BackgroundImage = Properties.Resources.smile,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Visible = true
                };
                buttonList.Add(button);
                this.Controls.Add(button);
                n++;
            }
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            stopwatch.Start();
            for (int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].MouseDown += MyButtonClickHandler;
            }
            elapsed = stopwatch.Elapsed;
            timerLabel.Text = elapsed.TotalSeconds.ToString("0.0") + "";
        }
        #region Buttons in game
        private void themeButton_Click(object sender, EventArgs e)
        {
            theme++;
            if (theme % 2 == 0)
            {
                this.BackColor = (Color.White);
                timerLabel.ForeColor = (Color.Black);
                themeButton.BackgroundImage = (Properties.Resources.night1);

            }
            else
            {
                this.BackColor = (Color.Black);
                themeButton.BackgroundImage = (Properties.Resources.sun);
                timerLabel.ForeColor = (Color.White);
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            pause++;
            if (pause % 2 == 0)
            {
                timer1.Stop();
                stopwatch.Stop();
                for (int i = 0; i < buttonList.Count; i++)
                {
                    buttonList[i].Enabled = false;
                }
            }
            else
            {
                timer1.Start();
                stopwatch.Start();
                for (int i = 0; i < buttonList.Count; i++)
                {
                    buttonList[i].Enabled = true;
                }
            }

        }
        #endregion
        private void MyButtonClickHandler(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            int i = buttonList.IndexOf(button);
            if (e.Button == MouseButtons.Left)
            {
                buttonList[i].BackgroundImage = Properties.Resources.night1;
                // OpenUp(i);
                NumberOfMines(blocksList[i].numMines, i);
            }
            if (e.Button == MouseButtons.Right)
            {
                buttonList[i].BackgroundImage = Properties.Resources.flagBlock;
            }


            //if (blocksList[i].mine = true)
            //{
            //    OnStart();
            //}
        }
        private void MakeMines()
        {
            Random rnd = new Random();
            for (int i = 0; i < numOfMines; i++)
            {
                int randomBlock = rnd.Next(0, blocksList.Count);
                if (blocksList[randomBlock].mine == false)
                {
                    blocksList[randomBlock].mine = true;
                }
                else
                {
                    i--;
                }
            }
        }
        private void PlaceNumbers()
        {
            for (int i = 0; i < blocksList.Count; i++)
            {
                mineCount = 0;

                if (i < blocksList.Count - 1 && blocksList[i + 1].mine == true)
                {
                    mineCount++;
                }
                if (i > 1 && blocksList[i - 1].mine == true)
                {
                    mineCount++;
                }
                if (i < blocksList.Count - gridLength - 1 && blocksList[i + 9].mine == true)
                {
                    mineCount++;
                }
                if (i > gridLength - 1 && blocksList[i - 9].mine == true)
                {
                    mineCount++;
                }
                if (i < blocksList.Count - gridLength && blocksList[i + gridLength].mine == true)
                {
                    mineCount++;
                }
                if (i > gridLength && blocksList[i - gridLength].mine == true)
                {
                    mineCount++;
                }
                if (i < buttonList.Count - (gridLength - 1) && blocksList[i + gridLength + 1].mine == true)
                {
                    mineCount++;
                }
                if (i > gridLength + 1 && blocksList[i - (gridLength + 1)].mine == true)
                {
                    mineCount++;
                }
                blocksList[i].numMines = mineCount;
            }
        }
        private void OpenUp(int n)
        {
            for (int i = 0; i < blocksList.Count; i++)
            {
                if (blocksList[i - 1].mine == false && blocksList[i - 1].numMines == 0)
                {
                    blocksList[i - 1].clicked = true;
                    buttonList[i - 1].BackgroundImage = Properties.Resources.blankBlock;
                    int sub = (blocksList[i - 2].x - 10) / 30;
                    int z = 0;
                    for (int j = gridLength - sub; j > 0; j--)
                    {
                        if (blocksList[i - z].mine == false && blocksList[i - z].numMines == 0)
                        {

                        }
                        z++;
                    }
                }
            }
        }
        private void NumberOfMines(int mineCount, int i)
        {
            if (mineCount == 0)
            {
                buttonList[i].BackgroundImage = Properties.Resources.blankBlock;
            }
            if (mineCount == 1)
            {
                buttonList[i].BackgroundImage = Properties.Resources.oneBlock;
            }
            if (mineCount == 2)
            {
                buttonList[i].BackgroundImage = Properties.Resources.twoBlock;
            }
            if (mineCount == 3)
            {
                buttonList[i].BackgroundImage = Properties.Resources.threeBlock;
            }
            if (mineCount == 4)
            {
                buttonList[i].BackgroundImage = Properties.Resources.fourBlock;
            }
            if (mineCount == 5)
            {
                buttonList[i].BackgroundImage = Properties.Resources.fiveBlock;
            }
            if (mineCount == 6)
            {
                buttonList[i].BackgroundImage = Properties.Resources.oneBlock;
            }
            if (mineCount == 7)
            {
                buttonList[i].BackgroundImage = Properties.Resources.sevenBlock;
            }
            if (mineCount == 8)
            {
                buttonList[i].BackgroundImage = Properties.Resources.eightBlock;
            }
            if (blocksList[i].mine == true)
            {
                buttonList[i].BackgroundImage = Properties.Resources.mineBlock;
            }
        }
    }
}
