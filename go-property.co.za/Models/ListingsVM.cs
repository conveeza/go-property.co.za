using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using go_property.co.za.Models;

namespace go_property.co.za.Models
{
    public class ListingsVM
    {
        public List<Listing> PropListings { get; set; }
        public List<Listing_Type> Listing_Type { get; set; }
        public List<Property_Type> Property_Type { get; set; }     
    }
}