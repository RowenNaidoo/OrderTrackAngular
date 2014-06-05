using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIData.Interfaces
{
    public interface IAppUser
    {
        AppUser Insert(AppUser appuser);
        List<AppUser> GetList();
        AppUser Login(string Username, string Password);
        //AppUser Login(AppUser appuser);
        AppUser GetByID(long Id);
        AppUser Update(AppUser appuser);
        Boolean Delete(long id);
    }
}
