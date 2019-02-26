using System;
using System.Collections.Generic;

namespace KnightArcade.Models
{
    public partial class Submissions
    {
        public int CreatorId { get; set; }
        public int? GameId { get; set; }
        public string SubmissionName { get; set; }
        public string SubmissionStatus { get; set; }
        public string SubmissionImage0 { get; set; }
        public DateTime SubmissionDateUtc { get; set; }
        public DateTime? SubmissionReviewdateUtc { get; set; }
    }
}
