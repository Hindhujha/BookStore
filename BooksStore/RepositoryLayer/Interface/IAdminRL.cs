using CommonLayer.PostModel;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        string AddAdmin(AdminPostModel adminPost);

        string Adminlogin(string MailId, string Password);

        string AdminsBook(AdminsBookPostModel adminBookPost);

        bool UpdateAdmin(int AdminId, AdminPostModel adminPost);

        bool UpdateAdminsBook(int AdminsBookId, AdminsBookPostModel adminBook);

        bool DeleteAdminsBook(int AdminsBookId);

        List<AdminModel> GetAdminDetails();

        List<AdminsBookModel> GetAdminsBooks();
    }
}
