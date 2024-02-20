using DAL;
using Model.Models;
namespace BLL
{
    public interface IProductCateBLL
    {
        ProductCategory GetCatebyID(int id);
        public bool Createcate(ProductCategory model);
        public bool Updatecate(ProductCategory model);
        public ProductCategory Deletecate(ProductCategory model);
        public List<ProductCategory> GetAllcate();


    }
    public class ProductCateBLL : IProductCateBLL
    {
        private IProductCateDAL _res;
        public ProductCateBLL(IProductCateDAL res)
        {
            _res = res;
        }
       
        public ProductCategory GetCatebyID(int id)
        {
            return _res.GetCatebyID(id);
        }
        public bool Createcate(ProductCategory model)
        {
            return _res.Createcate(model);
        }

        public bool Updatecate(ProductCategory model)
        {
            return _res.Updatecate(model);
        }

        public ProductCategory Deletecate(ProductCategory model)
        {
            return _res.Deletecate(model);
        }

        public List<ProductCategory> GetAllcate()
        {
            return _res.GetAllcate();
        }
    }
}