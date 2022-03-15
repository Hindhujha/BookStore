using CommonLayer.PostModel;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
  public interface IOrderBL
    {
        string AddOrder(OrderPostModel orderPost);

        List<OrderModel> OrderBooks(int userId);

    }
}
