using Business.Services.Abstractions;
using Data.Entities;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private List<PurchaseOrder> PurchaseOrderList = new List<PurchaseOrder>();

        public void AddPurchaseOrder(PurchaseOrder purchaseOrder) => PurchaseOrderList.Add(purchaseOrder);

        public List<PurchaseOrder> GetPurchaseOrders() => PurchaseOrderList;

        public PurchaseOrder ChangeStatus(int purchaseOrderId, PurchaseOrderStatus status)
        {
            var po = PurchaseOrderList.FirstOrDefault(c => c.Id == purchaseOrderId);
            if( po != null)
            {
                po.ChangeStatus(status);
                return po;
            }
            throw new ApplicationException("No se encontró la orden de compra solicitada.");
        }
    }
}
