using System;
using System.Collections.Generic;

namespace Snake.Game.Models
{
    public partial class Scores
    {
        public int ScoreId { get; set; }
        public int Score { get; set; }
        public DateTime? Date { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
