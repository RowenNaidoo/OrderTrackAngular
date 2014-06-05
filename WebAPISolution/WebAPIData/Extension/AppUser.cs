using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIData.Interfaces;

namespace WebAPIData
{
    public partial class AppUser:IAppUser
    {

        //Create
        public AppUser Insert(AppUser appuser)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                ctx.AppUser.Add(appuser);
                ctx.SaveChanges();
                return this;
            }
        }

        //Retrieve List
        public List<AppUser> GetList()
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.AppUser.ToList<AppUser>();
            }
        }

        //Login
        public AppUser Login(string Username, string Password)
        //public AppUser Login(AppUser appuser)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.AppUser.FirstOrDefault(x => x.Username == Username && x.Password == Password);
            }
        }

        //Retrieve By ID
        public AppUser GetByID(long Id)
        {
            using(OrderTrackEntities ctx = new OrderTrackEntities())
            {
                return ctx.AppUser.First(x=>x.AppUserID == Id);
            }
        }

        //Update
        public AppUser Update(AppUser appuser)
        {
            using (OrderTrackEntities ctx = new OrderTrackEntities())
            {
                AppUser AppUser = ctx.AppUser.First(x => x.AppUserID == this.AppUserID);
                AppUser = appuser;
                ctx.SaveChanges();
                return AppUser;
            }
        }

        //Delete By ID
        public Boolean Delete(long id)
        {
            using(OrderTrackEntities ctx= new OrderTrackEntities())
            {
                try
                {
                    AppUser AppUser = ctx.AppUser.First(x => x.AppUserID == id);
                    ctx.AppUser.Remove(AppUser);
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
