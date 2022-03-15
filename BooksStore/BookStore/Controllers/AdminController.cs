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

        [Authorize]
        [HttpGet("getAdminDetails")]
        public IActionResult GetAdminDetails()
        {
            try
            {
                var result = User.FindFirst("EmailId").Value.ToString();            
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


    }
}
