using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogentDemo.Code.Models
{
    public class Spotlight
    {
        public string SpotlightName { get; set; }
        public int Id { get; set; }
        public string Url { get; set; }
    }
    public class SpotlightApiRequestModel
    {
        public int PageNumber { get; set; }
        public int Year { get; set; }
    }
}