using CommonLayer.PostModel;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
  public interface IAdminBL
    {
        string AddAdmin(AdminPostModel adminPost);

        bool UpdateAdmin(int AdminId, AdminPostModel adminPost);

        List<AdminModel> GetAdminDetails();
    }
}
