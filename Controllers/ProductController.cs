using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaDelivery01.Data.Repositories;
using PizzaDelivery01.Data.Repositories.Impl;
using PizzaDelivery01.Entity.Context;
using PizzaDelivery01.Models;
using Product = PizzaDelivery01.Entity.Product;
using ProductContext = PizzaDelivery01.Entity.Context.ProductContext;

namespace PizzaDelivery01.Controllers
{
    public class ProductController : BaseApiController
    {
        public ProductController() : base(new ProductRepository(new ProductContext()))
        {
        }

        public HttpResponseMessage Get() {
            return Request.CreateResponse(HttpStatusCode.OK, theRepository.getAllProducts().ToList());
        }

        public HttpResponseMessage GetProduct(int id)
        {
            try
            {
                Product product = theRepository.getProductById(id);
                if (product != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, product);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public HttpResponseMessage Post([FromBody] Product product)
        {
            try
            {
                if (theRepository.insertProduct(product) && theRepository.saveAll()) {
                    return Request.CreateResponse(HttpStatusCode.Created, product);
                } else {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
                }   
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPatch]
        [HttpPut]
        public HttpResponseMessage Put([FromBody] Product product)
        {
            try
            {
                if (theRepository.updateProduct(product) && theRepository.saveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, product);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (theRepository.deleteProduct(id) && theRepository.saveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
