using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogentDemo.Code.Models
{
    public class NavItem
    {
        public string NodeName { get; set; }
    }
    public class NavigationApiRequestModel
    {
        public int PageNumber { get; set; }
        public int Year { get; set; }
    }
}
