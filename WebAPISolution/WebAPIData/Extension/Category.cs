using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIData.Interfaces;

namespace WebAPIData
{
    public partial class Category:ICategory
    {

        //Create
        public Category Insert(Category category)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                ctx.Category.Add(category);
                ctx.SaveChanges();
                return this;
            }
        }

        //Retrieve List
        public List<Category> GetList()
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.Category.ToList<Category>();
            }
        }

        //Retrieve By ID
        public Category GetByID(long Id)
        {
            using(OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.Category.First(x=>x.CategoryID == Id);
            }
        }

        //Update
        public Category Update(Category category)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                Category Category = ctx.Category.First(x => x.CategoryID == this.CategoryID);
                Category = category;
                ctx.SaveChanges();
                return Category;
            }
        }

        //Delete By ID
        public Boolean Delete(long id)
        {
            using(OrderTrackEntities ctx= new OrderTrackEntities())
            {
                try
                {
                    Category Category = ctx.Category.First(x => x.CategoryID == id);
                    ctx.Category.Remove(Category);
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
