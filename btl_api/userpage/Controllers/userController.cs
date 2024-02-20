using Microsoft.AspNetCore.Mvc;
using BLL;
using Model.Models;
using DAL;

namespace userpage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private IProductBLL _pro;
        private IProductCateBLL _catepro;
        private IPostBLL _post;
        private IPostCateBLL _postcate;
        private IOrderBLL _order;

        public userController( IProductCateBLL productcategory, IProductBLL product, IPostBLL Post, IPostCateBLL Postcate,IOrderBLL order)
        {
            _pro = product;
            _catepro = productcategory;
            _post = Post;
            _postcate = Postcate;
            _order = order;
        }
        [Route("create_order")]
        [HttpPost]
        public bool CreateOrder(Create_Order order)
        {
            return _order.CreateOrder(order);
        }
        [Route("search")]
        [HttpGet]
        public List<Product> Search(string key)
        {
            return _pro.Search(key);
        }
        // controller cateproduct
        [Route("get-catepro-by-id")]
        [HttpGet]
        public ProductCategory GetCatebyID(int id)
        {
            return _catepro.GetCatebyID(id);
        }
        [Route("getAllcatepro")]
        [HttpGet]
        public List<ProductCategory> GetAllcate()
        {
            return _catepro.GetAllcate();
        }
        [Route("GetAllprobycate")]
        [HttpGet]
        public List<Product> GetAllprobycate(int id)
        {
            return _pro.GetAllprobycate(id);
        }
        // controller product
        [Route("get-product-by-id")]
        [HttpGet]
        public Product GetproductbyID(int id)
        {
            return _pro.GetproductbyID(id);
        }

        [Route("getAllproduct")]
        [HttpGet]
        public List<Product> GetAllpro()
        {
            return _pro.GetAllpro();
        }
        [Route("accessoryproduct")]
        [HttpGet]
        public List<Product> accessoryproduct()
        {
            return _pro.accessoryproduct();
        }
        [Route("Get8ptohot")]
        [HttpGet]
        public List<Product> Get8ptohot()
        {
            return _pro.Get8ptohot();
        }
        [Route("getproductbyprice")]
        [HttpGet]
        public List<Product> getproductbyprice(int min, int max)
        {
            return _pro.getproductbyprice(min, max);
        }
        // controller post
        [Route("get-post-by-id")]
        [HttpGet]
        public Post GetPostbyID(int id)
        {
            return _post.GetPostbyID(id);
        }

        [Route("getAllpost")]
        [HttpGet]
        public List<Post> GetAllPost()
        {
            return _post.GetAllPost();
        }
        [Route("GetAllPostbycate")]
        [HttpGet]
        public List<Post> GetAllPostbycate(int id)
        {
            return _post.GetAllPostbycate(id);
        }
        // controller post cate
        [Route("get-Postcate-by-id")]
        [HttpGet]
        public PostCategory GetPostCatebyID(int id)
        {
            return _postcate.GetPostCatebyID(id);
        }

        [Route("getAllPostcate")]
        [HttpGet]
        public List<PostCategory> GetAllPostCate()
        {
            return _postcate.GetAllPostCate();
        }
    }
}
