using BussinessLayer.Interface;
using CommonLayer.PostModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        IOrderBL orderBL;
        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;

        }

        [HttpPost("orderBooks")]
        public IActionResult AddOrder(OrderPostModel orderPost)
        {
            try
            {
                var result = this.orderBL.AddOrder(orderPost);
                if (result.Equals("books ordered successfully"))
                {
                    return this.Ok(new { success = true, message = $"Books ordered Successfully " });
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

        [HttpGet("getallOrders/{userId}")]
        public IActionResult GetAllOrders(int userId)
        {
            try
            {
                var result = this.orderBL.OrderBooks(userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = $"Ordered Books Displayed Successfully ", response = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = $"Books are not there " });
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
