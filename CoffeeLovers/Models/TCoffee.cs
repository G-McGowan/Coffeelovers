using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CoffeeLovers.Models
{
    public partial class TCoffee
    {
        public TCoffee()
        {
            TComments = new HashSet<TComment>();
            TRatings = new HashSet<TRating>();
        }

        [JsonPropertyName("Coffee ID")]
        public int CoffeeId { get; set; }
        [JsonPropertyName("Coffee Name")]
        public string CoffeeName { get; set; }
        [JsonPropertyName("Coffee Brand")]
        public string CoffeeBrand { get; set; }
        [JsonPropertyName("Entry Created On")]
        public DateTime CreatedOn { get; set; }
        [JsonIgnore]
        public byte[] Timestamp { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("Comments")]
        public virtual ICollection<TComment> TComments { get; set; }

        [JsonIgnore]
        public virtual ICollection<TRating> TRatings { get; set; }
    }
}