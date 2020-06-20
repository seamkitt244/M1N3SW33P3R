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
{/// <summary>
/// Minesweeper clone program Seamus Kittmer June 18, 2020
/// </summary>
    public partial class GameScreen : UserControl
    {
        #region Variables
        private Grid grid;
        private HighScore highScore;
        private GameScreen gameScreen;
        Form form = new Form();

        List<Blocks> blocksList = new List<Blocks>();
        List<Button> buttonList = new List<Button>();

        public int blockSize = 30;
        public static int blockXOrg = 10;

        Boolean gameOver = false;
        public Boolean mode = false;

        int size;
        int diff;
        int pause = 0;
        int theme = 0;

        Stopwatch stopwatch = new Stopwatch();
        TimeSpan elapsed;

        double score;

       
        #endregion

        public GameScreen(int _size,int _diff, Form _form)
        {
            InitializeComponent();

            form = _form;
            OnStart();
            diff = _diff;
            size = _size;

            grid = new Grid(size,diff, blocksList, buttonList, form, this);
        }

        public void OnStart()
        {
            gameOver = false;
            blocksList.Clear();
            buttonList.Clear();
            timer1.Start();
            Refresh();
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            stopwatch.Start();
            grid.EnoughFlags();
            score = stopwatch.Elapsed.TotalSeconds;
            elapsed = stopwatch.Elapsed;
            timerLabel.Text = elapsed.TotalSeconds.ToString("0.0") + "";

                Refresh();
        }
        public void GameLose()
        {
            endLabel.Visible = true;
            endLabel.Text = "you lost";
            pauseButton.BackgroundImage = Properties.Resources.dead;
            timer1.Stop();//game lose method
            stopwatch.Stop();
            gameOver = true;
        }
        public void GameWin()
        {
            timer1.Stop();
            stopwatch.Stop();
            for (int i = 0; i < blocksList.Count; i++)
            {
                buttonList[i].Enabled = false;
                buttonList[i].BackgroundImage = Properties.Resources.smile;
            }
            pauseButton.BackgroundImage = Properties.Resources.sunnies;
            endLabel.Visible = true;
            endLabel.Text = "you won!";
            gameOver = true;
            if (score < highScore.checkList[9].time)//if player got a high score they can enter their name
            {
                form = this.FindForm();
                form.Controls.Remove(this);
                HighScore hs = new HighScore(score,diff);
                form.Controls.Add(hs);
            }
        }

        #region Buttons in game
        private void themeButton_Click(object sender, EventArgs e)
        {
            theme++;//changes the theme of the game
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
            if (pause % 2 == 0)//pauses game, and if gameOver==true can restart game
            {
                timer1.Stop();
                stopwatch.Stop();
                for (int i = 0; i < buttonList.Count; i++)
                {
                    buttonList[i].Enabled = false;
                }
            }
            else if (gameOver)
            {
                endLabel.Visible = false;//opens new Gamescreen, and resets everthing
                form = this.FindForm();
                form.Controls.Remove(this);
                GameScreen gs = new GameScreen(size,diff, form);
                form.Controls.Add(gs);
            }
            else
            {
                timer1.Start();// starts game again
                stopwatch.Start();
                for (int i = 0; i < buttonList.Count; i++)
                {
                    buttonList[i].Enabled = true;
                }
            }
        }

        private void modeButton_Click(object sender, EventArgs e)
        {
            mode = !mode;
            grid.GetMode(mode);//changes the game's click mode from uncover to flaging
            if (mode)
            {
                modeButton.BackgroundImage = Properties.Resources.clickedFlagBlock;
            }
            else
            {//
                modeButton.BackgroundImage = Properties.Resources.flagBlock;
            }
        }
        
        public void Click(int i)
        {
            grid.Click(i);//click method- checks if user clicks blocks or not
        }
        public void Flag(int i)
        {
            grid.Flag(i);//flag method- checks if user clicks blocks or not
        }
        #endregion
    }
}