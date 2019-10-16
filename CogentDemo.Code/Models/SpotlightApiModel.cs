using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CogentDemo.Code.DocumentTypes;

namespace CogentDemo.Code.Models
{
    public class Spotlight
    {
        public string SpotlightName { get; set; }
        public string SpotlightHeading{ get; set; }
        public int Id { get; set; }
        public string Url { get; set; }
        public string SpotlightText { get; set; }
        public string ImageUrl { get; set; }
    }
    public class SpotlightApiRequestModel
    {
        public int PageNumber { get; set; }
        public int Year { get; set; }
    }
}