using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeLovers.Helpers
{
    /// <summary>
    /// Coffee type used in Post to reduce complication and size over the wire. 
    /// </summary>
    public class Coffee
    {
        public string CoffeeName {get;set;}
        public string CoffeeBrand { get; set; }


    }
}
