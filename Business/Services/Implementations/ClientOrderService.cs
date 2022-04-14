using Business.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class ClientOrderService : IClientOrderService
    {
        private List<ClientOrder> ClientOrderList = new List<ClientOrder>();

        public void AddClientOrder(ClientOrder clientOrder) => ClientOrderList.Add(clientOrder);

        public List<ClientOrder> GetClientOrders() => ClientOrderList;
    }
}
