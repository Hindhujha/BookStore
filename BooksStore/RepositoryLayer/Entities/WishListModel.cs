using CommonLayer.PostModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Entities
{
   public class WishListModel
    {
        public int WishListId { get; set; }
        public int userId { get; set; }
        public int BookId { get; set; }      
        public BookPostModel bookModel { get; set; }
    }
}
