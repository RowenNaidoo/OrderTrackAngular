using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIData.Interfaces
{
    public interface ICartItem
    {
        CartItem Insert(CartItem cartitem);
        List<CartItem> GetList();
        CartItem GetByID(long Id);
        List<CartItem> GetByOrderID(long orderId);
        CartItem Update(CartItem cartitem);
        Boolean Delete(long id);
        Boolean Checkout(long OrderID);
    }
}
