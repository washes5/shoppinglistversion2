using System;

namespace ShoppingListVersion2.Models
{
    public class ShoppingListItemView
    {
        public int id { get; set; }
        public int ShoppingListId { get; set; }
        public string Contents { get; set; }
        public bool IsChecked { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }

    public enum Priority
    {
        ItCanWait=1,
        NeedItSoon=2,
        GrabItNow=3
    }
}