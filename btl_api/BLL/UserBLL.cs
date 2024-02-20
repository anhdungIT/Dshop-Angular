using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using DAL;
using static DAL.UserDAL;
namespace BLL
{
    public interface IUserBLL
    {
        public bool Register(ApplicationUser user);
        public string Authenticate(LoginRequest request);
        public bool Delete(ApplicationUser user);
        public bool Update(ApplicationUser user);
        public List<ApplicationUser> GetAll();
    }
    public class UserBLL : IUserBLL
    {
        private IUserDAL _res;
        public UserBLL(IUserDAL res)
        {
            _res = res;
        }
        public string Authenticate(LoginRequest request)
        {
            return _res.Authenticate(request);
        }

        public bool Delete(ApplicationUser user)
        {
            return _res.Delete(user);
        }

        public List<ApplicationUser> GetAll()
        {
            return _res.GetAll();
        }

        public bool Register(ApplicationUser user)
        {
            return _res.Register(user);
        }

        public bool Update(ApplicationUser user)
        {
            return _res.Update(user);
        }
    }
}
