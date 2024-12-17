using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningPlatform.Models
{
    public class Achievement
    {
        public int AchievementId { get; set; }
        public int UserId { get; set; }
        public string BadgeName { get; set; }
        public string Description { get; set; }
    }

}