using CommonLayer.PostModel;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IOrderRL
    {
        string AddOrder(OrderPostModel orderPost);

        List<OrderModel> OrderBooks(int userId);
    }
}
