using System;
using CustomExtensions;

namespace QuickType
{
    /// <summary>
    /// Keeps stats for the game
    /// </summary>
    class Stats
    {
        public int Total { get; set; }
        public int Missed { get; set; }
        public int Correct { get; set; }
        public int Accuracy { get; set; }
        public int BestScore { get; set; }
        public int level_inc { get; set; }
        public Stats()
        {
            level_inc = 3;
        }
        public void Update(bool CorrectEntry)
        {
            Total++;
            if (!CorrectEntry)
            {
                Missed++;
            }
            else
            {
                Correct++;
            }

            Accuracy = 100 * Correct / Total;
        }
        public void SetBestScore(int newScore)
        {
          
            if (newScore > type_easy.Properties.Settings.Default.BestScore)
            {
                var ratio = 0.86;
                type_easy.Properties.Settings.Default.BestScore_time =
                    DateTime.Now.ToShortDateString();
                type_easy.Properties.Settings.Default.BestScore = newScore;
                if(newScore > type_easy.Properties.Settings.Default.BestScore * ratio)
                {
                    "audio//sys//applause.wav".PlayWave(true);
                }
                type_easy.Properties.Settings.Default.Level_requirement =
                    type_easy.Properties.Settings.Default.BestScore + level_inc;
                type_easy.Properties.Settings.Default.Save();
                
            }

        }


    }
}
