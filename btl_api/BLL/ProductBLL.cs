using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model.Models;
using Microsoft.AspNetCore.Http;

namespace BLL
{
    public interface IProductBLL
    {
        Product GetproductbyID(int id);
        public bool Createpro(Product model);
        public bool Updatepro(Product model);
        public Product Deletepro(Product model);
        public List<Product> GetAllpro();
        List<Product> accessoryproduct();
        List<Product> Get8ptohot();
        List<Product> getproductbyprice(int min, int max);
        public List<Product> GetAllprobycate(int id);

        List<Product> Search(string key);


    }
    public class ProductBLL : IProductBLL
    {
        private IProductDAL _res;
        public ProductBLL(IProductDAL res)
        {
            _res = res;
        }
       
        public Product GetproductbyID(int id)
        {
            return _res.GetproductbyID(id);
        }
        public List<Product> Search(string key)
        {
            return _res.Search(key);
        }
        public List<Product> GetAllprobycate(int id)
        {
            return _res.GetAllprobycate(id);
        }
        public bool Createpro(Product model)
        {
            return _res.Createpro(model);
        }

        public bool Updatepro(Product model)
        {
            return _res.Updatepro(model);
        }

        public Product Deletepro(Product model)
        {
            return _res.Deletepro(model);
        }

        public List<Product> GetAllpro()
        {
            return _res.GetAllpro();
        }
        public List<Product> getproductbyprice(int min, int max)
        {
            return _res.getproductbyprice(min,max);
        }
        public List<Product> Get8ptohot()
        {
            return _res.Get8ptohot();
        }
        public List<Product> accessoryproduct()
        {
            return _res.accessoryproduct();
        }
    }
}
