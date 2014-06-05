using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIData.Interfaces
{
    public interface IOrder
    {
        Order Insert(Order order);
        List<Order> GetList();
        Order GetByID(long Id);
        List<Order> GetByAppUserID(long AppUserId);
        Order Update(Order order);
        Boolean Delete(long id);
    }
}
