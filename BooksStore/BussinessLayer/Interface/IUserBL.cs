using CommonLayer.PostModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
  public interface IUserBL
  {
        Task UserRegister( UserPostModel userPost);

        string login(string EmailId, string password);

        bool ForgotPassword(string EmailId);
        public bool ResetPassword(string EmailId, string password);


    }
}
