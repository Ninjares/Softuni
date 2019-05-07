using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeisterMask.Models
{
    public class TweetViewModel
    {
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
