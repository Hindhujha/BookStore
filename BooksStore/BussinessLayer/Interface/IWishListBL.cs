using CommonLayer.PostModel;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
   public interface IWishListBL
    {
        string AddBookinWishList(WishListPostModel wishListPost);

        bool RemoveBookinWishList(int WishListId);

        List<WishListModel> GetAllBooksinWishList(int userId);
   }
}
