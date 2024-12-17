using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningPlatform.Models
{
    public class Reward
    {
        public int RewardId { get; set; }
        public int UserId { get; set; }
        public string RewardName { get; set; }
        public string TimeLeft { get; set; }
    }

}