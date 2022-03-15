using BussinessLayer.Interface;
using CommonLayer.PostModel;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class AdminBL : IAdminBL
    {
        IAdminRL adminRL;

        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }

        public string AddAdmin(AdminPostModel adminPost)
        {
            try
            {
                return adminRL.AddAdmin(adminPost);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
 
        public bool UpdateAdmin(int AdminId, AdminPostModel adminPost)
        {
            try
            {
                return adminRL.UpdateAdmin(AdminId,adminPost);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AdminModel> GetAdminDetails()
        {
            try
            {
                return adminRL.GetAdminDetails();

            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
