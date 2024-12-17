using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningPlatform.Models
{
    public class Leaderboard
    {
        public int RankId { get; set; }
        public int UserId { get; set; }
        public int Points { get; set; }
        public string Username { get; set; }

    }

}