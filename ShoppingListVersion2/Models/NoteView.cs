using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListVersion2.Models
{
    public class NoteView
    {
        public int id { get; set; }
        public int ShoppingListItemId { get; set; }
        public string Body { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}