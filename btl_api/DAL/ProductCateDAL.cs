using Model.Models;
using DAL.Helper;
namespace DAL
{
    public partial interface IProductCateDAL
    {
        ProductCategory GetCatebyID(int id);
        public bool Createcate(ProductCategory model);
        public bool Updatecate(ProductCategory model);
        public ProductCategory Deletecate(ProductCategory model);
        public List<ProductCategory> GetAllcate();

    }
    public class ProductCateDAL: IProductCateDAL
    {
        private IDatabaseHelper _dbHelper;
        public ProductCateDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        
        public ProductCategory GetCatebyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getbyid_productcategory",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductCategory>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Createcate(ProductCategory model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_procate",
                "@name", model.Name,
                "@des", model.Description,
                "@img", model.Image,
                "@homeflag", model.HomeFlag,
                "@crdate", model.CreatedDate,
                "@creby", model.CreatedBy,
                "@status", model.Status
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
        public bool Updatecate(ProductCategory model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_procate",
                "@id", model.ID,
                "@name", model.Name,
                "@des", model.Description,
                "@img", model.Image,
                "@homeflag", model.HomeFlag,
                "@crdate", model.CreatedDate,
                "@creby", model.CreatedBy,
                "@status", model.Status

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
        public ProductCategory Deletecate(ProductCategory model)
        {
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_procate",
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
        public List<ProductCategory> GetAllcate()
        {
            try
            {
                string msgError = "";
                //var result = _dbHelper.ExecuteQueryToDataTable("select ID,Name,Alias,Description,ParentID,DisplayOrder,Image,HomeFlag,Status from ProductCategories", out msgError);
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetAllcateProduct");
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<ProductCategory>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}