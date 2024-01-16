using System;
using System.Collections.Generic;

namespace WebAppAzureAss8.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; } = null!;
        public double? BookPrice { get; set; }
        public int? Publisher { get; set; }

        public virtual Publisher? PublisherNavigation { get; set; }
    }
}
