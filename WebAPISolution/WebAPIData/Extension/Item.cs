using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIData.Interfaces;

namespace WebAPIData
{
    public partial class Item:IItem
    {

        //Create
        public Item Insert(Item item)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                ctx.Item.Add(item);
                ctx.SaveChanges();
                return this;
            }
        }

        //Retrieve List
        public List<Item> GetList()
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.Item.ToList<Item>();
            }
        }

        //Retrieve By ID
        public Item GetByID(long Id)
        {
            using(OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.Item.First(x=>x.ItemID == Id);
            }
        }

        //Retreive by categoryId
        public List<Item> GetByCategoryId(long categoryId)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.Item.Where(x => x.CategoryID == categoryId).ToList();
            }
        }

        //Update
        public Item Update(Item item)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                Item Item = ctx.Item.First(x => x.ItemID == this.ItemID);
                Item = item;
                ctx.SaveChanges();
                return Item;
            }
        }

        //Delete By ID
        public Boolean Delete(long id)
        {
            using(OrderTrackEntities ctx= new OrderTrackEntities())
            {
                try
                {
                    Item Item = ctx.Item.First(x => x.ItemID == id);
                    ctx.Item.Remove(Item);
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
