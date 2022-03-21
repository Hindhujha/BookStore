using BussinessLayer.Interface;
using CommonLayer.PostModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {

        IAdminBL adminBL;
        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;

        }

        [HttpPost("addAdmin")]
        public IActionResult AddAdmin(AdminPostModel adminPost)
        {
            try
            {
                var result = this.adminBL.AddAdmin(adminPost);
                if (result.Equals("Admin Added  successfully"))
                {
                    return this.Ok(new { success = true, message = $"Admin Added Successfully " });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPost("Login/{MailId}/{Password}")]

        public IActionResult AdminLogin(string MailId, string Password)
        {
            try
            {
                var login = this.adminBL.Adminlogin(MailId, Password);
                if (login != null)
                {
                    return this.Ok(new { Success = true, message = "Login Successful", token = login });
                }
                else
                {
                    return this.Ok(new { Success = false, message = "Invalid User Please enter valid email and password." });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });

            }
        }

        [HttpPost("AddAdminsBooks")]

        public IActionResult AdminsBooks(AdminsBookPostModel adminBookPost)
        {
            try
            {
                var result = this.adminBL.AdminsBook(adminBookPost);
                if (result.Equals("book added successfully"))
                {
                    return this.Ok(new { Success = true, message = "Admin's Books Added Successfully" });
                }
                else
                {
                    return this.Ok(new { Success = false, message = result });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });

            }
        }


        [HttpPut("updateAdmin/{AdminId}")]
        public IActionResult UpdateAdmin(int AdminId, AdminPostModel adminPost)
        {
            try
            {
                var result = this.adminBL.UpdateAdmin(AdminId, adminPost);
                if (result.Equals(true))
                {
                    return this.Ok(new { success = true, message = $"Admin details updated Successfully " });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPut("updateAdminBooks/{AdminsBookId}")]
        public IActionResult UpdateAdminBooks(int AdminsBookId, AdminsBookPostModel adminBook)
        {
            try
            {
                var result = this.adminBL.UpdateAdminsBook(AdminsBookId, adminBook);
                if (result.Equals(true))
                {
                    return this.Ok(new { success = true, message = $"Admin's Books  updated Successfully " });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [Authorize]
        [HttpDelete("deleteAdminBook/{AdminsBookId}")]
        public IActionResult DeleteAdminsBook(int AdminsBookId)
        {
            try
            {
                var result = User.FindFirst("MailId").Value.ToString();
                if (result!=null)
                {
                    var datas = this.adminBL.DeleteAdminsBook(AdminsBookId);
                    return this.Ok(new { success = true, message = $"Admin's Book deleted Successfully ", response = datas });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [Authorize]
        [HttpGet("getAdminDetails")]
        public IActionResult GetAdminDetails()
        {
            try
            {
                var result = User.FindFirst("MailId").Value.ToString();            
                if (result != null)
                {
                    var datas=this.adminBL.GetAdminDetails();
                    return this.Ok(new { success = true, message = $"Admin details displayed successfully", response = datas });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = $"Admin details not exist" });
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [Authorize]
        [HttpGet("getAdminBooks")]
        public IActionResult GetAdminsBooks()
        {
            try
            {
                var result = User.FindFirst("MailId").Value.ToString();
                if (result != null)
                {
                    var datas = this.adminBL.GetAdminsBooks();
                    return this.Ok(new { success = true, message = $"Admin's Books displayed successfully", response = datas });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = $"Admin books not exist" });
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
