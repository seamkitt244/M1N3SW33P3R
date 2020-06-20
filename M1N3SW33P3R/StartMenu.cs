using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M1N3SW33P3R
{
    public partial class StartMenu : UserControl
    {
        int difficulty= 1;
        public static int boardSize =10;
        Form form;
        public StartMenu(Form _form)
        {
            form = _form;
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (easyButton.Checked)
            {
                difficulty = 1;
            }
            if (mediumButton.Checked)
            {
                difficulty = 2;
            }
            if (hardButton.Checked)
            {
                difficulty = 3;
            }
            if (tenButton.Checked)
            {
                boardSize=10;
            }
            if (sixteenButton .Checked)
            {
                boardSize = 16;
            }
            if (thirtyButton.Checked)
            {
                boardSize = 30;
                form.Location = new Point(Width/2, Height-300);
                form.Size = new Size(640,690);
            }
            form = this.FindForm();
            form.Controls.Remove(this);
            GameScreen gs = new GameScreen(boardSize,difficulty,form);
            form.Controls.Add(gs);
        }

        private void highScoreButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            HighScore hs = new HighScore(difficulty);
            f.Controls.Add(hs);
        }
    }
}
