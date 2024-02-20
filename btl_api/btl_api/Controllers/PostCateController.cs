using Microsoft.AspNetCore.Mvc;
using BLL;
using Model.Models;
namespace btl_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCateController : ControllerBase
    {
        private IPostCateBLL _res;
        public PostCateController(IPostCateBLL Postcate)
        {
            _res = Postcate;
        }
        [Route("get-Post-by-id")]
        [HttpGet]
        public PostCategory GetPostCatebyID(int id)
        {
            return _res.GetPostCatebyID(id);
        }

        [Route("getAllPost")]
        [HttpGet]
        public List<PostCategory> GetAllPostCate()
        {
            return _res.GetAllPostCate();
        }

        [Route("create-Post")]
        [HttpPost]
        public PostCategory CreatePostCate([FromBody] PostCategory model)
        {
            _res.CreatePostCate(model);
            return model;
        }

        [Route("update-Post")]
        [HttpPost]
        public PostCategory UpdatePostCate(PostCategory model)
        {
            _res.UpdatePostCate(model);

            return model;
        }
        [Route("delete-Post")]
        [HttpPost]
        public PostCategory DeletePostCate(PostCategory model)
        {
            return _res.DeletePostCate(model);

        }
    }
}
