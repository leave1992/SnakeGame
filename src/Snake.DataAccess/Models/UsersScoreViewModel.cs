using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
