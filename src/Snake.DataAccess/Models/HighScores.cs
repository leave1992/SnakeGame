using System;

namespace Snake.DataAccess.Models
{
    public class HighScores
    {
        public int HighScoreId { get; set; }
        public string NickName { get; set; }
        public int Score { get; set; }
        public DateTime? Date { get; set; }
    }
}
