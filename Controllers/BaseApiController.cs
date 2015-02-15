using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaDelivery01.Data.Repositories;

namespace PizzaDelivery01.Controllers
{
    public class BaseApiController : ApiController
    {
        private IProductRepository repository;

        protected IProductRepository TheRepository
        {
            get { return repository; }
        }
    }
}