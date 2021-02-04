using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLovers.Helpers
{
    /// <summary>
    /// Used in POST, simplified object for Comment and Rating creation. 
    /// </summary>
    public class CommentRating
    {
        public int CoffeeID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

    }
}
