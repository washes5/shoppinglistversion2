using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListVersion2.Models
{
    public class ShoppingListView
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}