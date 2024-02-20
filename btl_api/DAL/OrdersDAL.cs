using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using DAL.Helper;
using Common;
using System.Data;

namespace DAL
{
    public class Create_Order
    {
        public Order order { get; set; }
        public List<OrderDetail> listOrderDetail { get; set; }
    }
    public partial interface IOrdersDAL
    {
        bool CreateOrder(Create_Order order);
        List<Order> GetAll();
        List<OrderDetail> Get_OrderDetail(int id);

    }

    public class OrdersDAL : IOrdersDAL
    {
        private ITools _tools;
        private IDatabaseHelper _dbHelper;
        public OrdersDAL(IDatabaseHelper dbHelper, ITools tools)
        {
            _dbHelper = dbHelper;
            _tools = tools;
        }
        public List<OrderDetail> Get_OrderDetail(int id)
        {

            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getorderbyorderdetail2",
                    "@id", id);

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<OrderDetail>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Order> GetAll()
        {


            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "allorders"

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Order>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateOrder(Create_Order order)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Create_Order",
                "@order", order.order != null ? MessageConvert.SerializeObject(order.order) : null,
                "@List_order_detail", order.listOrderDetail != null ? MessageConvert.SerializeObject(order.listOrderDetail) : null


                );

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
