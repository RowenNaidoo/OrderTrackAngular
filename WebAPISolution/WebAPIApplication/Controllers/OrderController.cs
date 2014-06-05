using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIData;

namespace WebAPIApplication.Controllers
{
    public class OrderController : ApiController
    {
        // GET api/values
        [System.Web.Http.ActionName("Get")]
        public List<Order> Get()
        {
            return new Order().GetList();
        }

        // GET api/values/5
        [System.Web.Http.ActionName("GetById")]
        public Order Get(int id)
        {
            return new Order().GetByID(id);
        }

        // GET api/values/5
        [System.Web.Http.ActionName("GetByAppUserId")]
        public List<Order> GetByAppUserID(int AppUserId)
        {
            return new Order().GetByAppUserID(AppUserId);
        }

        // POST api/values
        [System.Web.Http.ActionName("Update")]
        public Order Post(Order order)
        {
            return new Order().Update(order);
        }

        // PUT api/values/5
        [System.Web.Http.ActionName("Insert")]
        public Order Put(Order order)
        {
            return new Order().Insert(order);
        }

        // DELETE api/values/5
        public Boolean Delete(int id)
        {
            return new Order().Delete(id);
        }
    }
}
