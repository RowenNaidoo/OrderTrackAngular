using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIData.Interfaces;

namespace WebAPIData
{
    public partial class CartItem : ICartItem
    {

        //Create
        public CartItem Insert(CartItem cartitem)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                ctx.CartItem.Add(cartitem);
                ctx.SaveChanges();
                return this;
            }
        }

        //Retrieve List
        public List<CartItem> GetList()
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.CartItem.ToList<CartItem>();
            }
        }

        //Retrieve By ID
        public CartItem GetByID(long Id)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.CartItem.First(x => x.CartItemID == Id);
            }
        }

        //Retrieve By OrderID
        public List<CartItem> GetByOrderID(long orderId)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.CartItem.Include("Item").Where(x => x.OrderID == orderId).ToList();
            }
        }

        //Update
        public CartItem Update(CartItem cartitem)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                CartItem CartItem = ctx.CartItem.First(x => x.CartItemID == this.CartItemID);
                CartItem = cartitem;
                ctx.SaveChanges();
                return CartItem;
            }
        }

        //Delete By ID
        public Boolean Delete(long id)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                try
                {
                    CartItem CartItem = ctx.CartItem.First(x => x.CartItemID == id);
                    ctx.CartItem.Remove(CartItem);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        //checkout
        public Boolean Checkout(long OrderID)
        {
            try
            {
                using (OrderTrackEntities ctx = new OrderTrackEntities())
                {
                    var items = GetByOrderID(OrderID);
                    foreach (var item in items)
                    {
                        item.IsOrdered = true;
                        item.DateOrdered = DateTime.Now;
                        CartItem cartItem = new CartItem().Update(item);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
