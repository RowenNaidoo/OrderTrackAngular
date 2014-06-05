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
    public class CPAController : ApiController
    {
        // GET api/values
        [System.Web.Http.ActionName("Get")]
        public List<CPA> Get()
        {
            return new CPA().GetList();
        }

        // GET api/values/5
        [System.Web.Http.ActionName("GetById")]
        public CPA Get(int id)
        {
            return new CPA().GetByID(id);
        }

        // POST api/values
        [System.Web.Http.ActionName("Update")]
        public CPA Post(CPA cpa)
        {
            return new CPA().Update(cpa);
        }

        // PUT api/values/5
        [System.Web.Http.ActionName("Insert")]
        public CPA Put(CPA cpa)
        {
            return new CPA().Insert(cpa);
        }

        // DELETE api/values/5
        public Boolean Delete(int id)
        {
            return new CPA().Delete(id);
        }
    }
}
