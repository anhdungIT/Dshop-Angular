using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using DAL.Helper;
using Common;
namespace DAL
{
    public partial interface IPostCateDAL
    {
        PostCategory GetPostCatebyID(int id);
        bool CreatePostCate(PostCategory model);
        bool UpdatePostCate(PostCategory model);
        PostCategory DeletePostCate(PostCategory model);
        List<PostCategory> GetAllPostCate();
    }
    public class PostCateDAL : IPostCateDAL
    {
        private ITools _tools;
        private IDatabaseHelper _dbHelper;
        public PostCateDAL(IDatabaseHelper dbHelper, ITools tools)
        {
            _dbHelper = dbHelper;
            _tools = tools;
        }
        public PostCategory GetPostCatebyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getbyid_postcate",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<PostCategory>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PostCategory> GetAllPostCate()
        {


            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetAllcatePost"

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<PostCategory>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public string SaveFile(IFormFile file, string folder)
        //{
        //    string filePath = $"{folder}/{file.FileName.Replace("-", "_").Replace("%", "")}";
        //    var fullPath = _tools.CreatePathFile(filePath);
        //    using (var fileStream = new FileStream(fullPath, FileMode.Create))
        //    {
        //        file.CopyToAsync(fileStream);
        //    }
        //    return filePath;
        //}
        public bool CreatePostCate(PostCategory model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_postcate",
                "@name", model.Name,
                "@des", model.Description,
                "@img", model.Image,
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
        public bool UpdatePostCate(PostCategory model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_postcate",
                "@id", model.ID,
                "@name", model.Name,
                "@des", model.Description,
                "@img", model.Image,
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
        public PostCategory DeletePostCate(PostCategory model)
        {
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_postcate",
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
