using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLovers.Models
{
    public partial class TRating
    {
        /// <summary>
        /// Constructor. Takes int, int rating and coffeeID.
        /// </summary>
        /// <param name="rating"></param>
        /// <param name="CoffeeID"></param>
        public TRating(int rating, int coffeeID)
        {
            Rating = (byte)rating;
            CoffeeId = coffeeID;
        }
    }
}
