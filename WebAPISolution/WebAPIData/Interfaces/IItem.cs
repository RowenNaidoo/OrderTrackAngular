using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIData.Interfaces
{
    public interface IItem
    {
        Item Insert(Item item);
        List<Item> GetList();
        Item GetByID(long Id);
        List<Item> GetByCategoryId(long categoryId);
        Item Update(Item item);
        Boolean Delete(long id);
    }
}
