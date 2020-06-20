using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace M1N3SW33P3R
{/// <summary>
/// higscore class which checks to see if a user made top ten, and lets users check the highscore database
/// </summary>
    public partial class HighScore : UserControl
    {
        public int date, place, time;
        int userPlace = 10;
        public string name;
        int diff;
        double score;
        List<string> scoresList;

        public List<HighScore> highScoreList = new List<HighScore>();
        public HighScore(int _diff)
        {
            diff = 1;
            InitializeComponent();
            loadDB(diff);//object for checking the highscore database
            PrintToScreen();
            nameLabel.Visible = false;
            nameTextbox.Visible = false;
            submitButton.Enabled = false;
            submitButton.Visible = false;
        }
        public List<HighScore> checkList
        {
            get { return highScoreList; }//public list for checking if user made the cut
        }
        public HighScore(double _score, int _diff)
        {
            InitializeComponent();
            nameLabel.Visible = true;
            nameTextbox.Visible = true;
            submitButton.Enabled = true;//highscore object for submitting user info
            submitButton.Visible = true;
            diff = _diff;
            score = _score;
            loadDB(diff);
        }
        public HighScore(int _place, string _name, int _time)
        {
            place = _place;
            name = _name;//highscore object for collecting data from the txt docs
            time = _time;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string userName = nameTextbox.Text;
            int userScore = Convert.ToInt32(score);
            HighScore user = new HighScore(userPlace, userName, userScore);
            highScoreList.RemoveAt(highScoreList.Count - 1);
            highScoreList.Add(user);
            nameLabel.Visible = false;
            nameTextbox.Visible = false;
            submitButton.Visible = false;//submits the user into the highscore datbase
            submitButton.Enabled = false;
            Selection(highScoreList);
            PrintToScreen();
            saveDB();
        }

        public void loadDB(int diff)
        {
            if (diff == 1)//loads the highscores text files
            {
                scoresList = File.ReadAllLines("Resources/highScores.txt").ToList();
            }
            if (diff == 2)
            {
                scoresList = File.ReadAllLines("Resources/highScoresMed.txt").ToList();
            }
            if (diff == 2)
            {
                scoresList = File.ReadAllLines("Resources/highScoresHrd.txt").ToList();
            }
            //firstLabel.Text = scoresList[0];
            for (int i = 0; i < scoresList.Count; i += 3)
            {
                int place = Convert.ToInt32(scoresList[i]);
                string name = Convert.ToString(scoresList[i + 1]);
                int time = Convert.ToInt32(scoresList[i + 2]);
                HighScore h = new HighScore(place, name, time);
                highScoreList.Add(h);
            }

        }
        public void saveDB()
        {//saves the highscores text file
            List<string> tempList = new List<string>();

            // Add all info from each HighScore object to temp list 
            foreach (HighScore hs in highScoreList)
            {
                tempList.Add(Convert.ToString(hs.place));
                tempList.Add(hs.name);
                tempList.Add(Convert.ToString(hs.time));
            }
            if (diff == 1)
            {
                File.WriteAllLines("Resources/highScores.txt", tempList);
            }
            if (diff == 2)
            {
                File.WriteAllLines("Resources/highScoresMed.txt", tempList);
            }
            if (diff == 3)
            {
                File.WriteAllLines("Resources/highScoresHrd.txt", tempList);
            }

        }
        public void Selection(List<HighScore> tempList)
        {
            HighScore temp;//selection sort of the highscore list

            for (int i = 0; i < tempList.Count; i++)
            {
                for (int j = i + 1; j < tempList.Count; j++)
                {
                    if (tempList[j].time < tempList[i].time)
                    {
                        temp = tempList[i];
                        tempList[i] = tempList[j];
                        tempList[j] = temp;
                    }
                }
            }
            highScoreList = tempList;
        }
        private void PrintToScreen()
        {
            foreach (HighScore h in highScoreList)//fill all top 10 placers into the highscore list
            {
                if (highScoreList.IndexOf(h) == 0)
                {
                    firstLabel.Text = "1. " + h.name + "\n" + h.time + " seconds";
                    firstLabel.Visible = true;
                }
                if (highScoreList.IndexOf(h) == 1)
                {
                    secondLabel.Text = "2. " + h.name + "\n" + h.time + " seconds";
                    secondLabel.Visible = true;
                }
                if (highScoreList.IndexOf(h) == 2)
                {
                    thirdLabel.Text = "5. " + h.name + "\n" + h.time + " seconds";
                    thirdLabel.Visible = true;
                }
                if (highScoreList.IndexOf(h) == 3)
                {
                    fourthLabel.Text = "4. " + h.name + "\n" + h.time + " seconds";
                    fourthLabel.Visible = true;
                }
                if (highScoreList.IndexOf(h) == 4)
                {
                    fifthLabel.Text = "5. " + h.name + "\n" + h.time + " seconds";
                    fifthLabel.Visible = true;
                }
                if (highScoreList.IndexOf(h) == 5)
                {
                    sixthLabel.Text = "6. " + h.name + "\n" + h.time + " seconds";
                    sixthLabel.Visible = true;
                }
                if (highScoreList.IndexOf(h) == 6)
                {
                    seventhLabel.Text = "7. " + h.name + "\n" + h.time + " seconds";
                    seventhLabel.Visible = true;
                }
                if (highScoreList.IndexOf(h) == 7)
                {
                    eighthLabel.Text = "8. " + h.name + "\n" + h.time + " seconds";
                    eighthLabel.Visible = true;
                }
                if (highScoreList.IndexOf(h) == 8)
                {
                    ninthLabel.Text = "9. " + h.name + "\n" + h.time + " seconds";
                    ninthLabel.Visible = true;
                }
                if (highScoreList.IndexOf(h) == 9)
                {
                    tenthLabel.Text = "10. " + h.name + "\n" + h.time + " seconds";
                    tenthLabel.Visible = true;
                }
            }
        }
    }
}
