using System;
using System.Collections.Generic;

namespace Snake.Game.Models
{
    public partial class Users
    {
        public Users()
        {
            Scores = new HashSet<Scores>();
        }

        public int UserId { get; set; }
        public string Nickname { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Scores> Scores { get; set; }
    }
}
