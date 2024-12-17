using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningPlatform.Models
{
    public class UserProgress
    {
        public int ProgressId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int ProgressPercentage { get; set; }
    }

}