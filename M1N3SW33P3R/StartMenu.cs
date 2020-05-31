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
        public static int difficulty;
        public static int boardSize;
        public StartMenu()
        {
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
            }
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen(boardSize);
            f.Controls.Add(gs);
        }
    }
}
