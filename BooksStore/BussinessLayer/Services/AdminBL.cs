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

        public string Adminlogin(string MailId, string Password)
        {
            try
            {
                return adminRL.Adminlogin(MailId,Password);


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string AdminsBook(AdminsBookPostModel adminBookPost)
        {
            try
            {
                return adminRL.AdminsBook(adminBookPost);


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

        public bool UpdateAdminsBook(int AdminsBookId, AdminsBookPostModel adminBook)
        {
            try
            {
                return adminRL.UpdateAdminsBook(AdminsBookId,adminBook);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteAdminsBook(int AdminsBookId)
        {
            try
            {
                return adminRL.DeleteAdminsBook(AdminsBookId);

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

        public List<AdminsBookModel> GetAdminsBooks()
        {
            try
            {
                return adminRL.GetAdminsBooks();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
    }
}
