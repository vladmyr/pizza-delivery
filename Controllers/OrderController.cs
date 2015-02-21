using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaDelivery01.Data.Repositories;
using PizzaDelivery01.Data.Repositories.Impl;
using PizzaDelivery01.Entity;
using PizzaDelivery01.Entity.Context;

namespace PizzaDelivery01.Controllers
{
    public class OrderController : BaseApiController {
        public OrderController()
            : base(new ProductRepository(new ProductContext())) {
        }

        public HttpResponseMessage Post([FromBody] Order order)
        {
            try
            {
                if (order.GetType() == typeof (Order) && !order.phone.Trim().Equals("") && order.OrderItems.Count != 0)
                {
                    //get time in miliseconds starting from 1.1.1970
                    order.date = (long)DateTime.Now.Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds;
                    order.isCompleted = false;
                    try
                    {
                        theRepository.addUpdateOrder(order);
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    catch (Exception ex)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                    }
                    
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Requst body is incorrect");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);    
            }
        }
    }
}
