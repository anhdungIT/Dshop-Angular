using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model.Models;
namespace BLL
{
    public interface IPostCateBLL
    {
        PostCategory GetPostCatebyID(int id);
        public bool CreatePostCate(PostCategory model);
        public bool UpdatePostCate(PostCategory model);
        public PostCategory DeletePostCate(PostCategory model);
        public List<PostCategory> GetAllPostCate();

    }
    public class PostCateBLL : IPostCateBLL
    {
        private IPostCateDAL _res;
        public PostCateBLL(IPostCateDAL res)
        {
            _res = res;
        }
        public PostCategory GetPostCatebyID(int id)
        {
            return _res.GetPostCatebyID(id);
        }
        public bool CreatePostCate(PostCategory model)
        {
            return _res.CreatePostCate(model);
        }

        public bool UpdatePostCate(PostCategory model)
        {
            return _res.UpdatePostCate(model);
        }

        public PostCategory DeletePostCate(PostCategory model)
        {
            return _res.DeletePostCate(model);
        }

        public List<PostCategory> GetAllPostCate()
        {
            return _res.GetAllPostCate();
        }
    }
}
