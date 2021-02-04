using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLovers.Models
{
    public partial class TComment
    {

        public TComment()
        {

        }
        /// <summary>
        /// Constructor. Takes string, int for comment and coffeeID
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="coffeeID"></param>
        
        public TComment(string comment, int coffeeID)
        {
            Comment = comment;
            CoffeeId = coffeeID;
        }

    }
}
