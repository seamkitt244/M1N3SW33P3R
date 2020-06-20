using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace M1N3SW33P3R
{
    class Grid
    {
        Form form;
        private GameScreen gameScreen;

        private List<Blocks> blocksList = new List<Blocks>();
        public List<Button> buttonList = new List<Button>();

        private int size, diff;
        public int blockSize = 30;
        public static int blockXOrg = 10;
        int blockX = 10;
        int blockY = 40;
        int numMines = 0;
        int numFlags = 0;
        int mineCount = 10;
        public Point point = new Point(0, 0);
        Boolean mode = false;
        int counter = 0;
        Boolean mine, clicked, flaged = false;

        public Grid(int _size, int _diff, List<Blocks> _blocksList, List<Button> _buttonList, Form _form, GameScreen _gameScreen)
        {
            this.blocksList = _blocksList;
            this.buttonList = _buttonList;
            this.size = _size;
            this.diff = _diff;
            this.form = _form;
            if (diff == 3)
            {
                blockSize = 20;
            }
            gameScreen = _gameScreen;
            mineCount = size * diff;
            MakeBlocks(form);
            MakeMines();
            //PlaceNums();
            //for (int i = 0; i < blocksList.Count; i++)
            //{
            //    BackImage(i, blocksList[i].numMines);
            //}
        }
        private void MakeBlocks(Form form)
        {
            for (int i = 0; i < size * size; i++)
            {
                if (blockX > blockXOrg + (size * blockSize) - blockSize)
                {
                    blockX = blockXOrg;
                    blockY = blockY + blockSize;
                }
                Blocks tempBlock = new Blocks(blockX, blockY, numMines, numFlags, mine, clicked, flaged);
                blocksList.Add(tempBlock);
                blockX = blockX + blockSize;
            }
            foreach (Blocks b in blocksList)
            {
                Button button = new Button
                {
                    Name = blocksList.IndexOf(b) + "",
                    Size = new Size(blockSize, blockSize),//size,size
                    Location = new Point(b.blockX, b.blockY),
                    BackgroundImage = Properties.Resources.blankBlock,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Visible = true
                };
                form.Controls.Add(button);
                buttonList.Add(button);
                button.MouseDown += new MouseEventHandler(MouseClick);///leave as mouse down
            }
        }
        private void MakeMines()
        {
            Random rnd = new Random();
            for (int i = 0; i < mineCount; i++)
            {
                int z = rnd.Next(0, blocksList.Count - 1);
                if (blocksList[z].mine == false)
                {
                    blocksList[z].mine = true;
                    //BackImage(z,69);
                    MinesAround(z);
                }
                else
                {
                    i--;
                }
            }
        }
        //private void placeNums()
        //{

        //    for (int i = 0; i < blocksList.Count; i++)
        //    {
        //        for (int j = 0; j < blocksList.Count; j++)
        //        {
        //            if (blocksList[i].mine ==true)
        //                continue;
        //            //int num = NumberOfMines(i, j);
        //            if (num == 0)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                blocksList[i].numMines = num;
        //            }
        //        }
        //    }
        //}


        private void OpenUp(int n)//
        {
            int high = blocksList.Count - n;//the blocks above the index
            int low = n - 1;//the blocks below the index
            int q = blocksList[n].numMines; //number of mines in  a 3x3 square around given block
            BackImage(n, q);


            for (int i = low; i >= 0; i--)
            {
                if (blocksList[n - i].mine == false && blocksList[n].blockX - blockSize + 5 < blocksList[n - i].blockX || blocksList[n - i].blockX < blocksList[n].blockX + blockSize + 5 && blocksList[n].blockY - blockSize + 5 < blocksList[n - i].blockY || blocksList[n - i].blockY < blocksList[n].blockY + blockSize + 5)
                {
                    blocksList[n - i].clicked = true;
                    int z = blocksList[n - i].numMines;
                    BackImage(n - i, z);
                }
            }
            for (int i = 0; i < high; i++)
            {
                if (blocksList[n + i].mine == false && blocksList[n].blockX - blockSize + 5 < blocksList[n + i].blockX || blocksList[n + i].blockX < blocksList[n].blockX + blockSize + 5 && blocksList[n].blockY - blockSize + 5 < blocksList[n + i].blockY && blocksList[n + i].blockY < blocksList[n].blockY + blockSize + 5)
                {
                    blocksList[n + i].clicked = true;
                    int z = blocksList[n + i].numMines;
                    BackImage(n + i, z);
                }

            }
            //if (blocksList[n + i].mine == false && blocksList[n].blockX - blockSize + 5 < blocksList[n + i].blockX && blocksList[n + i].blockX < blocksList[n].blockX + blockSize + 5 && blocksList[n].blockY - blockSize + 5 < blocksList[n + i].blockY && blocksList[n + i].blockY < blocksList[n].blockY + blockSize + 5)
            //{
            //    blocksList[n + i].clicked = true;
            //    int z = blocksList[n + i].numMines;
            //    BackImage(n + i, z);
            //}


            //    }
            //}
        }
        private void MinesAround(int n)
        {
            int high = blocksList.Count - n;
            int low = n - 1;

            for (int i = low; i >= 0; i--)
            {
                if (blocksList[n - i].mine == false && blocksList[n].blockX - 40 < blocksList[n - i].blockX && blocksList[n - i].blockX < blocksList[n].blockX + 40 && blocksList[n].blockY - 40 < blocksList[n - i].blockY && blocksList[n - i].blockY < blocksList[n].blockY + 40)
                {
                    blocksList[n - i].numMines++;
                }
            }
            //for (int i = 0; i < high; i++)
            //{
            //    if (blocksList[n + i].mine == false && blocksList[n].blockX - 40 < blocksList[n + i].blockX && blocksList[n + i].blockX < blocksList[n].blockX + 40 && blocksList[n].blockY == blocksList[n+i].blockY)
            //    {
            //        blocksList[n + i].numMines++;
            //    }
            //}
            for (int i = 0; i < high; i++)
            {
                if (blocksList[n + i].mine == false && blocksList[n].blockX - 40 < blocksList[n + i].blockX && blocksList[n + i].blockX < blocksList[n].blockX + 40 && blocksList[n].blockY - 40 < blocksList[n + i].blockY && blocksList[n + i].blockY < blocksList[n].blockY + 40)
                {
                    blocksList[n + i].numMines++;
                }
            }
        }
        private void FlagsAround(int n)
        {
            int high = (size * size) - n;
            int low = n - 1;


            for (int i = low; i >= 0; i--)
            {
                if (blocksList[n - i].flaged == true && blocksList[n].mine == false && blocksList[n].blockX - 40 < blocksList[n - i].blockX && blocksList[n - i].blockX < blocksList[n].blockX + 40 && blocksList[n].blockY - 40 < blocksList[n - i].blockY && blocksList[n - i].blockY < blocksList[n].blockY + 40)
                {
                    blocksList[n].numFlags++;
                }
            }
            for (int i = 0; i < high; i++)
            {
                if (blocksList[n + i].flaged == true && blocksList[n].mine == false && blocksList[n].blockX - 40 < blocksList[n + i].blockX && blocksList[n + i].blockX < blocksList[n].blockX + 40 && blocksList[n].blockY - 40 < blocksList[n + i].blockY && blocksList[n + i].blockY < blocksList[n].blockY + 40)
                {
                    blocksList[n].numFlags++;
                }
            }
        }

        public void EnoughFlags()
        {
            int flagCounter = 0;
            for (int x = 0; x < blocksList.Count; x++)
            {
                if (blocksList[x].mine && blocksList[x].flaged)
                {
                    flagCounter++;
                }
            }

            if (flagCounter == mineCount)
            {
                counter = flagCounter;
                GameOver();
            }
        }

        #region mouse click on button grid
        public void Click(int i)
        {
            if (blocksList[i].flaged)
            {
                buttonList[i].BackgroundImage = Properties.Resources.blankBlock;
                blocksList[i].flaged = false;
                blocksList[i].clicked = false;
            }

            else
            {
                FlagsAround(i);
                blocksList[i].clicked = true;
                //if (blocksList[i].numFlags == blocksList[i].numMines)
                //{
                OpenUp(i);

                if (blocksList[i].flaged == false)
                {
                    IsMine(i);
                }
            }

        }

        public void Flag(int i)
        {
            if (blocksList[i].flaged)
            {
                int q = blocksList[i].numMines;

                blocksList[i].flaged = false;
                blocksList[i].clicked = false;
                buttonList[i].BackgroundImage = Properties.Resources.blankBlock;
            }
            else
            {
                buttonList[i].BackgroundImage = Properties.Resources.flagBlock;
                blocksList[i].flaged = true;
                blocksList[i].clicked = false;
            }
        }
        public void GetMode(Boolean b)
        {
            mode = b;
        }
        public void MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Button button = (Button)sender;
            int i = buttonList.IndexOf(button);

            EnoughFlags();

            if (mode)
            {
                if (e.Button == MouseButtons.Right)
                {

                    gameScreen.Click(i);

                    if (blocksList[i].flaged == false)
                    {
                        IsMine(i);
                    }
                }
                else
                {
                    gameScreen.Flag(i);
                }
            }
            else if (mode == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    gameScreen.Click(i);
                }
                else
                {
                    gameScreen.Flag(i);
                }
            }
        }
        #endregion


        private void IsMine(int i)
        {
            if (blocksList[i].mine && blocksList[i].flaged == false)
            {
                GameOver();
            }
        }
        public void GameOver()
        {
            for (int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].Enabled = false;
                buttonList[i].Visible = false;
            }
            for (int i = 0; i < buttonList.Count; i++)
            {

                Button buttonToRemove = buttonList[i];
                form.Controls.Remove(buttonList[i]);
                buttonList.Remove(buttonToRemove);
                if (buttonList.Count > 0)
                {
                    for (int j = 0; j < buttonList.Count; j++)
                    {
                        Button buttonToRemove2 = buttonList[j];
                        form.Controls.Remove(buttonList[j]);
                        buttonList.Remove(buttonToRemove2);
                    }
                }
            }
            blocksList.Clear();
            if (counter == mineCount)
            {
                gameScreen.GameWin();
            }
            else
            {
                gameScreen.GameLose();
            }
        }

        private void BackImage(int i, int mineCount)
        {
            if (mineCount == 0)
            {
                buttonList[i].BackgroundImage = null;
                buttonList[i].BackColor = (Color.White);
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
            //if (blocksList[i].mine)
            //{
            //    buttonList[i].BackgroundImage = Properties.Resources.mineBlock;
            //}
        }
    }
}

