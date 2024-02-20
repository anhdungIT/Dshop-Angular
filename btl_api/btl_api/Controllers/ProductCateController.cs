using Microsoft.AspNetCore.Mvc;
using BLL;
//using Microsoft.AspNetCore.Authorization;
using Model.Models;
namespace btl_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductCateController : ControllerBase
    {
        private IProductCateBLL _res;
        public ProductCateController(IProductCateBLL productcategory)
        {
            _res = productcategory;
        }
        [Route("get-cate-by-id")]
        [HttpGet]
        public ProductCategory GetCatebyID(int id)
        {
            return _res.GetCatebyID(id);
        }

        [Route("getAllcate")]
        [HttpGet]
        public List<ProductCategory> GetAllcate()
        {
            return _res.GetAllcate();
        }

        [Route("create-productCategory")]
        [HttpPost]
        public ProductCategory Createcate([FromBody] ProductCategory model)
        {
            _res.Createcate(model);
            return model;
        }

        [Route("update-productCategory")]
        [HttpPost]
        public ProductCategory Updatecate(ProductCategory model)
        {
            _res.Updatecate(model);

            return model;
        }
        [Route("delete-productCategory")]
        [HttpPost]
        public ProductCategory Deletecate(ProductCategory model)
        {
            return _res.Deletecate(model);

        }
        //    [Route("search-cate")]
        //    [HttpPost]
        //    public KQ Searchcate(SearchRequest searchRequest)
        //    {
        //        try
        //        {
        //            if (!string.IsNullOrEmpty(searchRequest.Search))
        //            {
        //                var result = _res.GetAllcate().Where(s => s.Name.ToUpper().Contains(searchRequest.Search.ToUpper())).ToList();
        //                long total = result.Count();
        //                result = result.Skip(searchRequest.pageSize * (searchRequest.page - 1)).Take(searchRequest.pageSize).ToList();
        //                return (
        //                    new KQ
        //                    {
        //                        page = searchRequest.page,
        //                        totalItem = (int)total,
        //                        pageSize = searchRequest.pageSize,
        //                        data = result,
        //                    }
        //                  );
        //            }
        //            else
        //            {
        //                var result = _res.GetAllcate().ToList();
        //                long total = result.Count();
        //                result = result.Skip(searchRequest.pageSize * (searchRequest.page - 1)).Take(searchRequest.pageSize).ToList();
        //                return (
        //                    new KQ
        //                    {
        //                        page = searchRequest.page,
        //                        totalItem = (int)total,
        //                        pageSize = searchRequest.pageSize,
        //                        data = result,
        //                    }
        //                  );

        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //    }
        //}

        //public class KQ
        //{
        //    public int page { get; set; }
        //    public int pageSize { get; set; }

        //    public long totalItem { get; set; }
        //    public dynamic data { get; set; }
        //}
        //public class SearchRequest
        //{
        //    public int page { get; set; }
        //    public int pageSize { get; set; }
        //    public string? Search { get; set; }


        //}
    }
}

