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
    public partial interface IPostDAL
    {
        Post GetPostbyID(int id);
        bool CreatePost(Post model);
        bool UpdatePost(Post model);
        Post DeletePost(Post model);
        List<Post> GetAllPost();
        List<Post> GetAllPostbycate(int id);
    }
    public class PostDAL : IPostDAL
    {
        private ITools _tools;
        private IDatabaseHelper _dbHelper;
        public PostDAL(IDatabaseHelper dbHelper, ITools tools)
        {
            _dbHelper = dbHelper;
            _tools = tools;
        }
        public Post GetPostbyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getbyid_post",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Post>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Post> GetAllPostbycate(int id)
        {


            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getblogbyloai","@id",id

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Post>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Post> GetAllPost()
        {


            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetAllpost"

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Post>().ToList();
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
        public bool CreatePost(Post model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_post",
                "@name", model.Name,
                "@categoryid", model.CategoryID,
                "@img", model.Image,
                "@des", model.Description,
                "@content", model.Content,
                "@homeflag", model.HomeFlag,
                "@hotflag", model.HotFlag,
                "@view", model.ViewCount,
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
        public bool UpdatePost(Post model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_post",
                "@id", model.ID,
                "@name", model.Name,
                "@categoryid", model.CategoryID,
                "@img", model.Image,
                "@des", model.Description,
                "@content", model.Content,
                "@homeflag", model.HomeFlag,
                "@hotflag", model.HotFlag,
                "@view", model.ViewCount,
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
        public Post DeletePost(Post model)
        {
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_post",
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
