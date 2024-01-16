using System;
using System.Collections.Generic;

namespace WebAppAzureAss8.Models
{
    public partial class BookCategory
    {
        public int BookCategoryId { get; set; }
        public string Category { get; set; } = null!;
    }
}
