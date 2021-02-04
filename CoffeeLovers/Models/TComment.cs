using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace CoffeeLovers.Models
{
    public partial class TComment
    {
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public int CoffeeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int RatingId { get; set; }
        [JsonIgnore]
        public virtual TCoffee Coffee { get; set; }
        [JsonIgnore]
        public virtual TRating Rating { get; set; }
    }
}
