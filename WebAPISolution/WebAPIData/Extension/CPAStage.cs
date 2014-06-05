using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIData.Interfaces;

namespace WebAPIData
{
    public partial class CPAStage:ICPAStage
    {

        //Create
        public CPAStage Insert(CPAStage cpastage)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                ctx.CPAStage.Add(cpastage);
                ctx.SaveChanges();
                return this;
            }
        }

        //Retrieve List
        public List<CPAStage> GetList()
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.CPAStage.ToList<CPAStage>();
            }
        }

        //Retrieve By ID
        public CPAStage GetByID(long Id)
        {
            using(OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.CPAStage.First(x=>x.CPAStageID == Id);
            }
        }

        //Update
        public CPAStage Update(CPAStage cpastage)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                CPAStage CPAStage = ctx.CPAStage.First(x => x.CPAStageID == this.CPAStageID);
                CPAStage = cpastage;
                ctx.SaveChanges();
                return CPAStage;
            }
        }

        //Delete By ID
        public Boolean Delete(long id)
        {
            using(OrderTrackEntities ctx= new OrderTrackEntities())
            {
                try
                {
                    CPAStage CPAStage = ctx.CPAStage.First(x => x.CPAStageID == id);
                    ctx.CPAStage.Remove(CPAStage);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
