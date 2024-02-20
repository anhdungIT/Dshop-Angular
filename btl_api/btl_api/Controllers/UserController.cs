using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Common;
using Model.Models;
using static DAL.UserDAL;
using Microsoft.AspNetCore.Authorization;
namespace btl_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private IUserBLL _UserBLL;
        private ITools _tools;

        public UserController(IUserBLL usertBusiness, ITools tools)
        {
            _UserBLL = usertBusiness;
            _tools = tools;
        }
        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public bool Register([FromBody] ApplicationUser user)
        {
            return _UserBLL.Register(user);
        }
        [AllowAnonymous]
        [Route("Authenticate")]
        [HttpPost]
        public string Authenticate([FromBody] LoginRequest request)
        {
            return _UserBLL.Authenticate(request);
        }

        [Route("Delete-User")]
        [HttpPost]
        public bool Delete([FromBody] ApplicationUser user)
        {
            return _UserBLL.Delete(user);
        }

        [Route("Update-User")]
        [HttpPost]
        public bool Update([FromBody] ApplicationUser user)
        {
            return _UserBLL.Update(user);
        }
        [Route("GetAll-User")]
        [HttpGet]
        public List<ApplicationUser> GetAll()
        {
            return _UserBLL.GetAll();
        }
    }
}
