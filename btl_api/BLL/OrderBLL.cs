using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model.Models;

namespace BLL
{
    public interface IOrderBLL
    {
        bool CreateOrder(Create_Order order);
        List<Order> GetAll();
        List<OrderDetail> Get_OrderDetail(int id);

    }
    public class OrderBLL : IOrderBLL
    {
        
        private IOrdersDAL _res;
        public OrderBLL(IOrdersDAL res)
        {
            _res = res;
        }
        public bool CreateOrder(Create_Order order)
        {
            return _res.CreateOrder(order);
        }
        public List<Order> GetAll()
        {
            return _res.GetAll();
        }
        public List<OrderDetail> Get_OrderDetail(int id)
        {
            return _res.Get_OrderDetail(id);
        }
    }
}
