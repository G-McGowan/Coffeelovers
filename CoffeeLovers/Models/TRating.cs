using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace CoffeeLovers.Models
{
    public partial class TRating
    {
        public TRating()
        {
            TComments = new HashSet<TComment>();
        }

        public int RatingId { get; set; }
        public byte Rating { get; set; }
        public int CoffeeId { get; set; }
        public DateTime CreatedOn { get; set; }
        [JsonIgnore]
        public virtual TCoffee Coffee { get; set; }
        [JsonIgnore]
        public virtual ICollection<TComment> TComments { get; set; }
    }
}
