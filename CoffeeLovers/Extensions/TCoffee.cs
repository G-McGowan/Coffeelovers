using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoffeeLovers.Models
{
    public partial class TCoffee
    {
        /// <summary>
        /// Constructor, takes string string for coffee name and coffee brand.
        /// </summary>
        /// <param name="brandName"></param>
        /// <param name="coffeeName"></param>
        public TCoffee(string brandName, string coffeeName)
        {
            CoffeeBrand = brandName;
            CoffeeName = coffeeName;
        }

        [NotMapped]
        [JsonPropertyName("Average Rating")]
        public decimal AverageRating
        {
            get
            {
                decimal ratingsAvg = 0;
                if (TRatings != null)
                {
                    foreach (var rat in TRatings)
                    {
                        ratingsAvg += rat.Rating;
                    }
                    if (ratingsAvg > 0)
                    {
                        ratingsAvg = ratingsAvg / TRatings.Count;
                    }
                }
                return ratingsAvg;
            }
            set { }

        }

        [NotMapped]
        [JsonPropertyName("Number Of Ratings")]
        public int NumberOfRatings
        {
            get
            {
                var ratings = 0;
                if (TRatings != null)
                {
                    ratings = TRatings.Count;
                }

                return ratings;
            }
            set { }
        }
    }
}
