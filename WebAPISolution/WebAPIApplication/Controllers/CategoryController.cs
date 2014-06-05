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
    public class CategoryController : ApiController
    {
        // GET api/values
        [System.Web.Http.ActionName("Get")]
        public List<Category> Get()
        {
            return new Category().GetList();
        }

        // GET api/values/5
        [System.Web.Http.ActionName("GetById")]
        public Category Get(int id)
        {
            return new Category().GetByID(id);
        }

        // POST api/values
        [System.Web.Http.ActionName("Update")]
        public Category Post(Category category)
        {
            return new Category().Update(category);
        }

        // PUT api/values/5
        [System.Web.Http.ActionName("Insert")]
        public Category Put(Category category)
        {
            return new Category().Insert(category);
        }

        // DELETE api/values/5
        public Boolean Delete(int id)
        {
            return new Category().Delete(id);
        }
    }
}
