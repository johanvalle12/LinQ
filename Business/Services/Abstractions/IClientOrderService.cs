using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface IClientOrderService
    {
        public void AddClientOrder(ClientOrder clientOrder);
        public List<ClientOrder> GetClientOrders();
    }
}
