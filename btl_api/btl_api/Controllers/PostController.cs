using Microsoft.AspNetCore.Mvc;
using BLL;
using Model.Models;
namespace btl_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostBLL _res;
        public PostController(IPostBLL Post)
        {
            _res = Post;
        }
        [Route("get-Post-by-id")]
        [HttpGet]
        public Post GetPostbyID(int id)
        {
            return _res.GetPostbyID(id);
        }

        [Route("getAllPost")]
        [HttpGet]
        public List<Post> GetAllPost()
        {
            return _res.GetAllPost();
        }

        [Route("create-Post")]
        [HttpPost]
        public Post CreatePost([FromBody] Post model)
        {
            _res.CreatePost(model);
            return model;
        }

        [Route("update-Post")]
        [HttpPost]
        public Post UpdatePost(Post model)
        {
            _res.UpdatePost(model);

            return model;
        }
        [Route("delete-Post")]
        [HttpPost]
        public Post DeletePost(Post model)
        {
            return _res.DeletePost(model);

        }
    }
}
