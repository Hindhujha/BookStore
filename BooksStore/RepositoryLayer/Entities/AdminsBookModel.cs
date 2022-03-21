using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Entities
{
   public class AdminsBookModel
    {
        public int AdminsBookId { get; set; }

        public int AdminId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int DiscountPrice { get; set; }
        public int OriginalPrice { get; set; }
        public string BookDescription { get; set; }

        public string Image { get; set; }
        public float Rating { get; set; }
        public int Reviewer { get; set; }
        public int BookCount { get; set; }
    }
}
