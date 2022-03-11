using CommonLayer.PostModel;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
   public interface ICartBL
   {
        string AddBookToCart(CartPostModel cartBook);

        bool UpdateCart(int CartId, int Quantity);

        string DeleteCart(int CartId);

        List<CartModel> GetAllBooksinCart(int userId);
   }
}
