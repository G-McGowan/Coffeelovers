using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLovers.Helpers
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int RatingScore { get; set; }
        public int CoffeeId { get; set; }
    }
}
