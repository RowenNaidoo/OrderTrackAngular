using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIData.Interfaces;

namespace WebAPIData
{
    public partial class CPA:ICPA
    {

        //Create
        public CPA Insert(CPA cpa)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                ctx.CPA.Add(cpa);
                ctx.SaveChanges();
                return this;
            }
        }

        //Retrieve List
        public List<CPA> GetList()
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.CPA.ToList<CPA>();
            }
        }

        //Retrieve By ID
        public CPA GetByID(long Id)
        {
            using(OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.CPA.First(x=>x.CPAID == Id);
            }
        }

        //Update
        public CPA Update(CPA cpa)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                CPA CPA = ctx.CPA.First(x => x.CPAID == this.CPAID);
                CPA = cpa;
                ctx.SaveChanges();
                return CPA;
            }
        }

        //Delete By ID
        public Boolean Delete(long id)
        {
            using(OrderTrackEntities ctx= new OrderTrackEntities())
            {
                try
                {
                    CPA CPA = ctx.CPA.First(x => x.CPAID == id);
                    ctx.CPA.Remove(CPA);
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
