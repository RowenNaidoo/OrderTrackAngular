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
    public class AppUserController : ApiController
    {
        // GET api/values
        [System.Web.Http.ActionName("Get")]
        public List<AppUser> Get()
        {
            return new AppUser().GetList();
        }

        // GET api/values/5
        [System.Web.Http.ActionName("GetById")]
        public AppUser Get(int id)
        {
            return new AppUser().GetByID(id);
        }

        [System.Web.Http.ActionName("Login")]
        public AppUser Get(string Username, string Password)
        //public AppUser Get(AppUser appuser)
        {
            return new AppUser().Login(Username, Password);
        }

        // POST api/values
        [System.Web.Http.ActionName("Update")]
        public AppUser Post(AppUser appuser)
        {
            return new AppUser().Update(appuser);
        }

        // PUT api/values/5
        [System.Web.Http.ActionName("Insert")]
        public AppUser Put(AppUser appuser)
        {
            return new AppUser().Insert(appuser);
        }

        // DELETE api/values/5
        public Boolean Delete(int id)
        {
            return new AppUser().Delete(id);
        }
    }
}
