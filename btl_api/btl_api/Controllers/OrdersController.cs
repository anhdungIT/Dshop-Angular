using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL;
using Model.Models;
namespace btl_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController
    {
        private IOrderBLL _res;
        public OrdersController(IOrderBLL order)
        {
            _res = order;
        }
        [Route("create_order")]
        [HttpPost]
        public bool CreateOrder(Create_Order order)
        {
            return _res.CreateOrder(order);
        }
        [Route("allorder")]
        [HttpGet]
        public List<Order> GetAll()
        {
            return _res.GetAll();
        }
        [Route("getorderbyorderdateil")]
        [HttpGet]
        public List<OrderDetail> Get_OrderDetail(int id)
        {
            return _res.Get_OrderDetail(id);
        }
    }
}
