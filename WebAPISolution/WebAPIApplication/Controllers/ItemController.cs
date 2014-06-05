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
    public class ItemController : ApiController
    {
        // GET api/values
        [System.Web.Http.ActionName("Get")]
        public List<Item> Get()
        {
            return new Item().GetList();
        }

        // GET api/values/5
        [System.Web.Http.ActionName("GetById")]
        public Item Get(int id)
        {
            return new Item().GetByID(id);
        }

        // GET api/values/5
        [System.Web.Http.ActionName("GetByCategoryId")]
        public List<Item> Get(long categoryId)
        {
            return new Item().GetByCategoryId(categoryId);
        }

        // POST api/values
        [System.Web.Http.ActionName("Update")]
        public Item Post(Item item)
        {
            return new Item().Update(item);
        }

        // PUT api/values/5
        [System.Web.Http.ActionName("Insert")]
        public Item Put(Item item)
        {
            return new Item().Insert(item);
        }

        // DELETE api/values/5
        public Boolean Delete(int id)
        {
            return new Item().Delete(id);
        }
    }
}
