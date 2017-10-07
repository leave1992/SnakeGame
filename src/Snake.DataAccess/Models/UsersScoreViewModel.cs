using System;
using System.ComponentModel.DataAnnotations;

namespace Snake.DataAccess.Models
{
    public class UsersScoreViewModel
    {
        public int Score { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public int? UserId { get; set; }
    }
}
