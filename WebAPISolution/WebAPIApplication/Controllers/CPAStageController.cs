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
    public class CPAStageController : ApiController
    {
        // GET api/values
        [System.Web.Http.ActionName("Get")]
        public List<CPAStage> Get()
        {
            return new CPAStage().GetList();
        }

        // GET api/values/5
        [System.Web.Http.ActionName("GetById")]
        public CPAStage Get(int id)
        {
            return new CPAStage().GetByID(id);
        }

        // POST api/values
        [System.Web.Http.ActionName("Update")]
        public CPAStage Post(CPAStage cpastage)
        {
            return new CPAStage().Update(cpastage);
        }

        // PUT api/values/5
        [System.Web.Http.ActionName("Insert")]
        public CPAStage Put(CPAStage cpastage)
        {
            return new CPAStage().Insert(cpastage);
        }

        // DELETE api/values/5
        public Boolean Delete(int id)
        {
            return new CPAStage().Delete(id);
        }
    }
}
