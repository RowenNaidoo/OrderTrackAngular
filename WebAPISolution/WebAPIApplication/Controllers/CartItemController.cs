using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIData;

namespace WebAPIApplication.Controllers
{
    public class CartItemController : ApiController
    {
        // GET api/values
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("Get")]
        public List<CartItem> Get()
        {
            return new CartItem().GetList();
        }

        // GET api/values/5
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("GetById")]
        public CartItem Get(int id)
        {
            return new CartItem().GetByID(id);
        }

        // GET api/values/5
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("GetByOrderID")]
        public Object GetByOrderID(long orderId)
        {
            List<CartItem> data = new CartItem().GetByOrderID(orderId);
            
            var collection =
                data.Select(
                    x =>
                    new 
                        {
                            x.CartItemID,
                            x.ItemID,
                            x.Quantity,
                            x.Price,
                            x.AppUserID,
                            x.OrderID,
                            x.DateAdded,
                            x.IsOrdered,
                            x.DateOrdered,
                            Item = x.Item.Name,
                            UnitPrice = x.Item.Price
                        });
            return collection;
        }

        // POST api/values
        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Update")]
        public CartItem Post(CartItem cartitem)
        {
            return new CartItem().Update(cartitem);
        }

        // POST api/values
        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Checkout")]
        public Boolean Checkout(long orderId)
        {
            return new CartItem().Checkout(orderId);
        }

        // PUT api/values/5
        [System.Web.Http.HttpPut]
        [System.Web.Http.ActionName("Insert")]
        public CartItem Put(CartItem cartitem)
        {
            cartitem.DateAdded = DateTime.Now;
            cartitem.IsOrdered = false;
            cartitem.Quantity = 0;
            cartitem.Price = 0;
            cartitem.DateOrdered = Convert.ToDateTime("1 Jan 1900");
            return new CartItem().Insert(cartitem);
        }

        // DELETE api/values/5
        [System.Web.Http.HttpDelete]
        public Boolean Delete(int id)
        {
            return new CartItem().Delete(id);
        }
    }
}
