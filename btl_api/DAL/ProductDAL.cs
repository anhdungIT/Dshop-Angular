using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using DAL.Helper;
using Common;
using Microsoft.AspNetCore.Http;



namespace DAL
{
    public partial interface IProductDAL
    {
        Product GetproductbyID(int id);
        bool Createpro(Product model);
        bool Updatepro(Product model);
        Product Deletepro(Product model);
        List<Product> GetAllpro();
        List<Product> accessoryproduct();
        List<Product> Get8ptohot();
        List<Product> getproductbyprice(int min, int max);
        public List<Product> GetAllprobycate(int id);

        List<Product> Search(string key);

    }
    public class ProductDAL : IProductDAL
    { 
        private ITools _tools;
        private IDatabaseHelper _dbHelper;
        public ProductDAL(IDatabaseHelper dbHelper,ITools tools) 
        {
            _dbHelper = dbHelper;
            _tools = tools;
        }

        public List<Product> GetAllprobycate(int id)
        {
            try
            {
                string msgError = "";
                //var result = _dbHelper.ExecuteQueryToDataTable("select ID,Name,Alias,Description,ParentID,DisplayOrder,Image,HomeFlag,Status from ProductCategories", out msgError);
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getmhbyloai", "@id", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<Product>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Product GetproductbyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getbyid_product",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Product>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Product> getproductbyprice(int min, int max)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getproductbyprice",
                     "@min",min,"@max",max);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Product>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Product> GetAllpro()
        {


            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetAllProduct"

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Product>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Product> Get8ptohot()
        {


            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "producthot8"

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Product>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Product> accessoryproduct()
        {


            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "accessoryproduct"

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Product>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool Createpro(Product model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_product",
                "@name", model.Name,
                "@cateId", model.CategoryID,
                "@img", model.Image,
                "@price", model.Price,
                "@promotionprice", model.PromotionPrice,
                "@des", model.Description,
                "@content", model.Content,
                "@homeflag", model.HomeFlag,
                "@hotflag", model.HotFlag,
                "@crdate", model.CreatedDate,
                "@creby", model.CreatedBy,
                "@status", model.Status,
                "@warranty", model.Warranty,
                "@quantity", model.Quantity,
                "@oriprice", model.OriginalPrice
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
        public bool Updatepro(Product model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_product",
                "@id", model.ID,
                "@name", model.Name,
                "@cateId", model.CategoryID,
                "@img", model.Image,
                "@price", model.Price,
                "@promotionprice", model.PromotionPrice,
                "@des", model.Description,
                "@content", model.Content,
                "@homeflag", model.HomeFlag,
                "@hotflag", model.HotFlag,
                "@crdate", model.CreatedDate,
                "@creby", model.CreatedBy,
                "@status", model.Status,
                "@warranty", model.Warranty,
                "@quantity", model.Quantity,
                "@oriprice", model.OriginalPrice

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
        public List<Product> Search(string key)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "search_sp",
                   "@key", key);

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Product>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Product Deletepro(Product model)
        {
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_procduct",
                    "@id", model.ID
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
    
}
