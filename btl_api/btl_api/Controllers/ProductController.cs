using Microsoft.AspNetCore.Mvc;
using BLL;
using Model.Models;
using Common;

namespace btl_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBLL _res;
        private ITools _tools;

        public ProductController(IProductBLL product, ITools tools)
        {
            _res = product;
            _tools = tools;

        }
        [Route("search")]
        [HttpGet]
        public List<Product> Search(string key)
        {
            return _res.Search(key);
        }
        [Route("upload")]
        [HttpPost]
        public async Task<string> Upload(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string filePath = $"/{file.FileName.Replace("-", "_").Replace("%", "")}";
                    var fullPath = _tools.CreatePathFile(filePath);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return filePath;
                }
                return ("Không thể upload tệp");


            }
            catch (Exception ex)
            {
                return ("Không thể upload tệp");
            }
        }
        [Route("get-pro-by-id")]
        [HttpGet]
        public Product GetproductbyID(int id)
        {
            return _res.GetproductbyID(id);
        }

        [Route("getAllpro")]
        [HttpGet]
        public List<Product> GetAllpro()
        {
            return _res.GetAllpro();
        }

        [Route("create-Product")]
        [HttpPost]
        public Product Createpro([FromBody] Product model)
        {
            _res.Createpro(model);
            return model;
        }

        [Route("update-Product")]
        [HttpPost]
        public Product Updatepro(Product model)
        {
            _res.Updatepro(model);

            return model;
        }
        [Route("delete-Product")]
        [HttpPost]
        public Product Deletepro(Product model)
        {
            return _res.Deletepro(model);

        }
        [Route("search-pro")]
        [HttpPost]
        public KQ Search([FromBody] SearchRequest searchRequest)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchRequest.Search))
                {
                    var result = _res.GetAllpro().Where(s => s.Name.ToUpper().Contains(searchRequest.Search.ToUpper())).ToList();
                    long total = result.Count();
                    result = result.Skip(searchRequest.pageSize * (searchRequest.page - 1)).Take(searchRequest.pageSize).ToList();
                    return (
                        new KQ
                        {
                            page = searchRequest.page,
                            totalItem = (int)total,
                            pageSize = searchRequest.pageSize,
                            data = result,
                        }
                      );
                }
                else
                {
                    var result = _res.GetAllpro().ToList();
                    long total = result.Count();
                    result = result.Skip(searchRequest.pageSize * (searchRequest.page - 1)).Take(searchRequest.pageSize).ToList();
                    return (
                        new KQ
                        {
                            page = searchRequest.page,
                            totalItem = (int)total,
                            pageSize = searchRequest.pageSize,
                            data = result,
                        }
                      );

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public class KQ
        {
            public int page { get; set; }
            public int pageSize { get; set; }

            public long totalItem { get; set; }
            public dynamic data { get; set; }
        }
        public class SearchRequest
        {
            public int page { get; set; }
            public int pageSize { get; set; }
            public string? Search { get; set; }


        }

    }
}

