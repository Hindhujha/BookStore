﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.PostModel
{
    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int BookId { get; set; }
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