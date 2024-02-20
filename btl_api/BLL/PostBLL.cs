using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model.Models;

namespace BLL
{
    public interface IPostBLL
    {
        Post GetPostbyID(int id);
        public bool CreatePost(Post model);
        public bool UpdatePost(Post model);
        public Post DeletePost(Post model);
        public List<Post> GetAllPost();
        public List<Post> GetAllPostbycate(int id);


    }
    public class PostBLL : IPostBLL
    {
        private IPostDAL _res;
        public PostBLL(IPostDAL res)
        {
            _res = res;
        }
        public Post GetPostbyID(int id)
        {
            return _res.GetPostbyID(id);
        }
        public bool CreatePost(Post model)
        {
            return _res.CreatePost(model);
        }

        public bool UpdatePost(Post model)
        {
            return _res.UpdatePost(model);
        }

        public Post DeletePost(Post model)
        {
            return _res.DeletePost(model);
        }
        public List<Post> GetAllPostbycate(int id)
        {
            return _res.GetAllPostbycate(id);
        }
        public List<Post> GetAllPost()
        {
            return _res.GetAllPost();
        }
    }
}
