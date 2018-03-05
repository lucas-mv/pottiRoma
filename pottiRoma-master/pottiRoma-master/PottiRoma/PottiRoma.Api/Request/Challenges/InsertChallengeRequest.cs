using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Request.Challenges
{
    public class InsertChallengeRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Parameter { get; set; }
        public int Goal { get; set; }
        public int Prize { get; set; }
        public string Description { get; set; }
    }
}