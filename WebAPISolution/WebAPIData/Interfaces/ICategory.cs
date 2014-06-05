using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIData.Interfaces
{
    public interface ICategory
    {
        Category Insert(Category category);
        List<Category> GetList();
        Category GetByID(long Id);
        Category Update(Category category);
        Boolean Delete(long id);
    }
}
