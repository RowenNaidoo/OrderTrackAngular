using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIData.Interfaces;

namespace WebAPIData
{
    public partial class Order:IOrder
    {

        //Create
        public Order Insert(Order order)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                ctx.Order.Add(order);
                ctx.SaveChanges();
                return this;
            }
        }

        //Retrieve List
        public List<Order> GetList()
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.Order.ToList<Order>();
            }
        }

        //Retrieve By ID
        public Order GetByID(long Id)
        {
            using(OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.Order.First(x=>x.OrderID == Id);
            }
        }

        //Retrieve By AppUserID
        public List<Order> GetByAppUserID(long AppUserId)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.Order.Where(x => x.AppUserID == AppUserId).ToList();
            }
        }

        //Update
        public Order Update(Order order)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                Order Order = ctx.Order.First(x => x.OrderID == this.OrderID);
                Order = order;
                ctx.SaveChanges();
                return Order;
            }
        }

        //Delete By ID
        public Boolean Delete(long id)
        {
            using(OrderTrackEntities ctx= new OrderTrackEntities())
            {
                try
                {
                    Order Order = ctx.Order.First(x => x.OrderID == id);
                    ctx.Order.Remove(Order);
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
